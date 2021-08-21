Public Class LOADER
    Private Sub LOADER_Load(sender As Object, e As EventArgs) Handles Me.Load
        Hide()
        MyApp = New BackApplication
        If MyApp.Count = 0 Then
            Using f As New ProgramsListForm
                f.ShowDialog()
                If f.DialogResult = DialogResult.Cancel Then Dispose()
            End Using
        End If
    End Sub
End Class