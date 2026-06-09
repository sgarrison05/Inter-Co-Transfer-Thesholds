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

        f.IsEditMode = True
        f.IncomingIsICT = isICT

        f.IncomingOriginalName = SafeWord(words, 0)

        f.incomingChildName = SafeWord(words, 0)
        f.IncomingReceiving = SafeWord(words, 1)
        f.incomingSending = SafeWord(words, 2)

        If isICT Then
            f.incomingType = SafeWord(words, 3)
            f.incomingOfficer = SafeWord(words, 4)
            DetermineAndSetDates(f, words, startIdx:=5, endIdx:=6)
        Else
            ' Interstate — no type column, indices shift left
            f.incomingType = String.Empty ' No type for Interstate records
            f.incomingOfficer = SafeWord(words, 3)
            DetermineAndSetDates(f, words, startIdx:=4, endIdx:=5)
        End If

    End Sub

    Private Sub DetermineAndSetDates(f As frmEdit, words() As String, startIdx As Integer, endIdx As Integer)

        ' Handles date population including Pending and missing date cases

        ' Handle start date — may be "Pending" or blank
        Dim startVal As String = SafeWord(words, startIdx)
        Dim parsedStart As DateTime

        If DateTime.TryParse(startVal, parsedStart) Then
            f.IncomingIsPending = False
            f.IncomingStartDate = parsedStart

            Dim endVal As String = SafeWord(words, endIdx)
            Dim parsedEnd As DateTime
            f.IncomingEndDate = If(DateTime.TryParse(endVal, parsedEnd),
                                   parsedEnd,
                                   DateTime.Today.AddDays(180))
        Else
            f.IncomingIsPending = True
            f.IncomingStartDate = DateTime.Today
            f.IncomingEndDate = DateTime.Today.AddDays(180)
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

            For Each sentence As String In mySentence

                'skip blank lines
                If String.IsNullOrWhiteSpace(sentence) Then Continue For

                Dim words() As String = Split(sentence, vbTab)

                ' Skip lines that don't start with a plausible name (header lines start with "Child Name:" etc.)
                ' A data line's first word should not contain a colon
                If words(0).Contains(":"c) OrElse words(0).Trim().StartsWith("-"c) Then Continue For

                ' Must have at least 3 columns to be a valid data line (Child Name, Receiving Co, Sending Co)
                If words.Length < 3 Then Continue For

                If SafeWord(words, 0).IndexOf(txbLastName.Text, StringComparison.OrdinalIgnoreCase) >= 0 Then

                    foundWords = words ' Store for potential use in edit form
                    foundIsICT = rdbICT.Checked

                    'Put the words back together with padding for display on form
                    If rdbICT.Checked Then
                        display = String.Join(" ".PadRight(5), SafeWord(words, 0), SafeWord(words, 3),
                                                               SafeWord(words, 4), SafeWord(words, 5))
                    Else
                        display = String.Join(" ".PadRight(5), SafeWord(words, 0), SafeWord(words, 3),
                                                               SafeWord(words, 4), SafeWord(words, 4))
                    End If
                    Exit For
                End If
            Next

            ' Prefix result with record type for context
            Dim recordType As String = If(rdbICT.Checked, "[ICT]     ", "[Interstate]     ")

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
        frmMain.Show()
        frmMain.btnRefresh.PerformClick() ' Refresh main form data when returning
        Me.Close()

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

        Using f As New frmEdit()
            PopulateEditForm(f, foundWords, foundIsICT)
            f.ShowDialog()
        End Using

        CleanForm()

        btnReturn.PerformClick() ' Return to main form and refresh data after editing
    End Sub

End Class