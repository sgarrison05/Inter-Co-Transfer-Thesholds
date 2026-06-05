Public Class frmSearch

    Dim display As String
    Private foundWords As String() = Nothing
    Private foundIsICT As Boolean = True

    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles Me.Load

        rdbICT.Checked = True
        txbLastName.Focus()

    End Sub

    Private Function SafeWord(words() As String, index As Integer) As String

        ' Save array accessor - prevents out-of-bounds on short or Pending records
        If index >= 0 AndAlso index < words.Length Then
            Return words(index).TrimEnd()
        End If
        Return String.Empty

    End Function

    Private Sub PopulateEditForm(f As frmEdit, words() As String, isICT As Boolean)

        ' Populates the edit form with data from the found record
        ' Handles both ICT and Interstate column layouts in one place

        f.txbChildName.Text = SafeWord(words, 0)
        f.txbReceiveCo.Text = SafeWord(words, 1)
        f.txbSendCo.Text = SafeWord(words, 2)

        If isICT Then
            f.rdbICT.Checked = True
            f.cmbType.Text = SafeWord(words, 3)
            f.cmbOfficer.Text = SafeWord(words, 4)
            PopulateDates(f, words, startIdx:=5, endIdx:=6)
        Else
            ' Interstate — no type column, indices shift left
            f.rdbICJ.Checked = True
            f.cmbOfficer.Text = SafeWord(words, 3)
            PopulateDates(f, words, startIdx:=4, endIdx:=5)
        End If

    End Sub

    Private Sub PopulateDates(f As frmEdit, words() As String, startIdx As Integer, endIdx As Integer)

        ' Handles date population including Pending and missing date cases

        ' Handle start date — may be "Pending" or blank
        Dim startVal As String = SafeWord(words, startIdx)
        Dim parsedStart As DateTime

        If DateTime.TryParse(startVal, parsedStart) Then
            f.rdbSupervision.Checked = True
            f.dtpStart.Enabled = True
            f.dtpStart.Value = parsedStart
        Else
            ' "Pending" or blank — default to today with date picker disabled
            f.rdbPending.Checked = True
            f.dtpStart.Enabled = False
            f.dtpStart.Value = DateTime.Today
        End If

        ' Handle end date — may be blank if record is Pending
        Dim endVal As String = SafeWord(words, endIdx)
        Dim parsedEnd As DateTime

        If DateTime.TryParse(endVal, parsedEnd) Then
            f.dtpEnd.Enabled = True
            f.dtpEnd.Value = parsedEnd
        Else
            f.dtpEnd.Enabled = False
            f.dtpEnd.Value = DateTime.Today.AddDays(180)
        End If

    End Sub

    Public Sub FillLabel()

        ' Validate before searching — empty search would match every line
        If String.IsNullOrWhiteSpace(txbLastName.Text) Then
            MessageBox.Show("Please enter a last name to search.",
                            "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txbLastName.Focus()
            Return
        End If

        ' Reset display before search
        display = String.Empty
        foundWords = Nothing

        ' Determine target file based on selected radio button
        Dim targetFile As String = If(rdbICT.Checked, frmMain.ictfile, frmMain.icjfile)

        ' Check file exists before attempting to read
        If Not My.Computer.FileSystem.FileExists(targetFile) Then
            MessageBox.Show("No " & If(rdbICT.Checked, "ICT", "Interstate") & " records file found.",
                            "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim myText As String = My.Computer.FileSystem.ReadAllText(targetFile)
            Dim mySentence() As String = Split(myText, vbCrLf)

            ' Minimum columns needed to be a valid data line:
            ' ICT Pending:        at least 5 (Name, RecvCo, SendCo, Type, Officer)
            ' ICT Full:           at least 7 (above + StartDate, Threshold)
            ' Interstate Pending: at least 4 (Name, RecvState, SendState, Officer)
            ' Interstate Full:    at least 6 (above + StartDate, Threshold)
            ' Header/separator lines will have far fewer tabs and are safely skipped
            Dim minColumns As Integer = If(rdbICT.Checked, 6, 5)

            For Each sentence As String In mySentence

                'skip blank lines
                If String.IsNullOrWhiteSpace(sentence) Then Continue For

                Dim words() As String = Split(sentence, vbTab)

                ' Skip header, separator, and any line too short to be a data record
                If words.Length < minColumns Then Continue For

                ' Skip lines that don't start with a plausible name (header lines start with "Child Name:" etc.)
                ' A data line's first word should not contain a colon
                If words(0).Contains(":"c) OrElse words(0).Trim().StartsWith("-"c) Then Continue For

                If sentence.IndexOf(txbLastName.Text, StringComparison.OrdinalIgnoreCase) >= 0 Then

                    foundWords = words ' Store for potential use in edit form
                    foundIsICT = rdbICT.Checked

                    'Put the words back together with padding for display on form
                    If rdbICT.Checked Then
                        display = String.Join(" ".PadRight(5), words(0), words(3),
                                                               words(4), words(6))
                    Else
                        display = String.Join(" ".PadRight(5), words(0), words(3),
                                                               words(4), words(5))
                    End If
                    Exit For
                End If
            Next

            ' Prefix result with record type for context
            Dim recordType As String = If(rdbICT.Checked, "[ICT] ", "[Interstate] ")

            If String.IsNullOrEmpty(display) Then
                lblDisplay.Text = "Name not found."
            Else
                lblDisplay.Text = recordType & display
            End If

        Catch ex As Exception
            MessageBox.Show("Error during search: " & ex.Message,
                            "Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CleanForm()

        txbLastName.Clear()
        lblDisplay.Text = String.Empty
        foundWords = Nothing
        rdbICT.Checked = True
        txbLastName.Focus()

    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        CleanForm()
        Me.Close()
        frmMain.Show()

    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        FillLabel()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        CleanForm()
        txbLastName.Focus()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        ' Validate a search was run and returned a result before allowing update (#7)
        If String.IsNullOrWhiteSpace(txbLastName.Text) Then
            MessageBox.Show("Please search for a record before updating.",
                            "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If foundWords Is Nothing Then
            MessageBox.Show("No record is currently displayed. Please search first.",
                            "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Populate edit form and only close if edit was confirmed
        Using f As New frmEdit()
            PopulateEditForm(f, foundWords, foundIsICT)
            If f.ShowDialog() = DialogResult.OK Then
                CleanForm()
                Me.Close()
                frmMain.lblICJListing.Text = String.Empty
                frmMain.lblICTListing.Text = String.Empty
                frmMain.btnRefresh.PerformClick()
                frmMain.Show()
            End If
        End Using
    End Sub

End Class