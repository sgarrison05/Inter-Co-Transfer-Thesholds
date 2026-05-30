Public Class frmSearch

    Dim display As String
    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles Me.Load

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

        display = String.Empty

        Try
            Dim myText As String = My.Computer.FileSystem.ReadAllText(frmMain.ictfile)
            Dim mySentence() As String = Split(myText, vbCrLf)

            For Each sentence As String In mySentence
                If sentence.IndexOf(txbLastName.Text, StringComparison.OrdinalIgnoreCase) >= 0 Then

                    Dim words() As String = Split(sentence, vbTab)

                    'Put the words back together with padding for display on form
                    display = String.Join(" ".PadRight(1), words(0), words(3), words(4), words(6))
                    Exit For
                End If
            Next

            If String.IsNullOrEmpty(display) Then
                display = "Name not found."
            End If

            lblDisplay.Text = display

        Catch ex As Exception
            MessageBox.Show("Error during search: " & ex.Message,
                            "Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CleanForm()

        txbLastName.Clear()
        lblDisplay.Text = String.Empty
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