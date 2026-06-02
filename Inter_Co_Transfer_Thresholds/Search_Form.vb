Public Class frmSearch

    Dim display As String
    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles Me.Load

        rdbICT.Checked = True
        txbLastName.Focus()

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
                If sentence.IndexOf(txbLastName.Text, StringComparison.OrdinalIgnoreCase) >= 0 Then

                    Dim words() As String = Split(sentence, vbTab)

                    'Put the words back together with padding for display on form
                    If rdbICT.Checked Then
                        display = String.Join(" ".PadRight(5), words(0), words(3), words(4), words(6))
                    Else
                        display = String.Join(" ".PadRight(5), words(0), words(3), words(4), words(5))
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

End Class
