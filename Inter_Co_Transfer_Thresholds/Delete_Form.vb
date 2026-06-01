Imports System.IO
Imports System.Text

Public Class frmDelete

    Private Sub frmDelete_Load(sender As Object, e As EventArgs) Handles Me.Load
        rdbICJ.Checked = True
        txbLastName.Focus()

    End Sub

    Private Sub DeleteRecord(filepath As String, name As String)

        Dim tempPath = Path.Combine(Path.GetDirectoryName(filepath),
                        Path.GetFileNameWithoutExtension(filepath) & ".tmp" &
                        Path.GetExtension(filepath))

        Dim readtxt As String
        Dim entry As String
        Dim newLineIndex As Integer = 0
        Dim entryIndex As Integer = 0
        Dim recordFound As Boolean = False

        If My.Computer.FileSystem.FileExists(filepath) Then

            Try

                readtxt = File.ReadAllText(filepath)

                'Primer for first read of readtext
                newLineIndex = readtxt.IndexOf(ControlChars.NewLine, entryIndex)

                Do Until newLineIndex = -1

                    'get each line (don't forget about the new line character " + 1")
                    entry = readtxt.Substring(entryIndex, (newLineIndex - entryIndex) + 1)

                    'finds line with name and skips it
                    If entry.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 Then

                        recordFound = True

                    Else

                        'if not found writes line to temp file and moves on
                        My.Computer.FileSystem.WriteAllText(tempPath, entry, True)
                    End If

                    entryIndex = newLineIndex + 1
                    newLineIndex = readtxt.IndexOf(ControlChars.NewLine, entryIndex)

                Loop

                'Deletes Falseoriginal file and renames temp file to original name
                File.Delete(filepath)
                File.Move(tempPath, filepath)

                If recordFound Then
                    MessageBox.Show("Record for " & name & " has been deleted.",
                                    "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No record found for: " & name,
                                    "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show("Error deleting record: " & ex.Message,
                                "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else

            MessageBox.Show("File does not exist.")

        End If

    End Sub

    Public Sub CleanForm()

        txbLastName.Clear()
        rdbICT.Checked = True
        txbLastName.Focus()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim lastName As String = txbLastName.Text.Trim()

        If String.IsNullOrWhiteSpace(lastName) Then
            MessageBox.Show("Please enter a last name to delete.",
                    "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete the record for: " & lastName & "?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            DeleteRecord(frmMain.ictfile, lastName)
            CleanForm()
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        CleanForm()

    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        CleanForm()
        frmMain.lblICTListing.Text = String.Empty
        frmMain.lblICJListing.Text = String.Empty
        frmMain.Show()
        frmMain.btnRefresh.PerformClick()
        Me.Close()

    End Sub

End Class