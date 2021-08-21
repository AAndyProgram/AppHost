Imports System.ComponentModel
Imports PersonalUtilities.Forms
Imports PersonalUtilities.Functions.XML
Friend Class ProgramsListForm
    Private ReadOnly MyDefs As DefaultFormProps
    Friend Property MyDialogResult As DialogResult = DialogResult.Cancel
    Friend Sub New()
        InitializeComponent()
        MyDefs = New DefaultFormProps
    End Sub
    Private Sub ProgramsListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            MyDefs.MyViewInitialize(Me, MyApp.DesignXML)
            ListRefill()
            MyDefs.EndLoaderOperations()
        Catch ex As Exception
            MyDefs.InvokeLoaderError(ex)
        End Try
    End Sub
    Private Sub ProgramsListForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveToXML()
        MyDefs.Dispose()
        If MyDefs.ErrorLoading Then MyDialogResult = DialogResult.Cancel
        DialogResult = MyDialogResult
    End Sub
    Private Sub ProgramsListForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim b As Boolean = True
        Select Case e.KeyCode
            Case Keys.Insert : BTT_ADD.PerformClick()
            Case Keys.F4 : BTT_EDIT.PerformClick()
            Case Keys.Delete : BTT_DEL.PerformClick()
            Case Else : b = False
        End Select
        If b Then e.Handled = True
    End Sub
    Private Sub SaveToXML()
        Try
            With MyApp.MyApps
                If MyApp.SettingsFile.Exists(,, EDP.None) Then MyApp.SettingsFile.Delete(,,, EDP.None)
                If .Count > 0 Then
                    Using x As New XmlFile With {.XmlReadOnly = True, .AllowSameNames = True, .Name = BackApplication.NameContainer}
                        For i% = 0 To .Count - 1
                            With .Item(i)
                                x.Add(New EContainer(BackApplication.NameNode, String.Empty,
                                                     {New EAttribute(BackApplication.NameProcess, .AppName),
                                                      New EAttribute(BackApplication.NamePath, .AppPath),
                                                      New EAttribute(BackApplication.NameTimer, .AppCheckTimer),
                                                      New EAttribute(BackApplication.NameStopRestart, .RestartPrevent),
                                                      New EAttribute(BackApplication.NameLookAppName, .LookAppNameInsteadPath)
                                                     }),, EDP.ThrowException)
                            End With
                        Next
                        x.Save(MyApp.SettingsFile)
                    End Using
                End If
            End With
        Catch ex As Exception
            MSDONE("Unexpected error on process parameters saving to XML", MsgBoxStyle.Critical, ex,,, True)
        End Try
    End Sub
    Private Sub ListRefill()
        Try
            AppsList.Items.Clear()
            With MyApp.MyApps
                If .Count > 0 Then
                    For i% = 0 To .Count - 1 : AppsList.Items.Add(.Item(i).ToString()) : Next
                    If _LatestIndex >= 0 And _LatestIndex <= .Count - 1 Then AppsList.SelectedIndex = _LatestIndex Else _LatestIndex = -1
                Else
                    _LatestIndex = -1
                End If
            End With
        Catch ex As Exception
            MSDONE("Unexpected error on refill process list", MsgBoxStyle.Critical, ex,,, True)
        End Try
    End Sub
    Private Sub BTT_ADD_Click(sender As Object, e As EventArgs) Handles BTT_ADD.Click
        Using f As New AppEditorForm(Nothing)
            f.ShowDialog()
            If f.DialogResult = DialogResult.OK Then MyApp.MyApps.Add(f.MyProc) : ListRefill() : MyDialogResult = DialogResult.OK
        End Using
    End Sub
    Private Sub BTT_EDIT_Click(sender As Object, e As EventArgs) Handles BTT_EDIT.Click
        Try
            If _LatestIndex >= 0 And _LatestIndex <= MyApp.Count - 1 Then
                Using f As New AppEditorForm(MyApp.MyApps(_LatestIndex))
                    f.ShowDialog()
                    If f.DialogResult = DialogResult.OK Then ListRefill() : MyDialogResult = DialogResult.OK
                End Using
            End If
        Catch ex As Exception
            MSDONE("Unexpected error on editing process parameters", MsgBoxStyle.Critical, ex,,, True)
        End Try
    End Sub
    Private Sub BTT_DEL_Click(sender As Object, e As EventArgs) Handles BTT_DEL.Click
        Try
            If _LatestIndex >= 0 And _LatestIndex <= MyApp.Count - 1 Then
                With MyApp.MyApps
                    .ElementAt(_LatestIndex).Stop()
                    .ElementAt(_LatestIndex).Dispose()
                    .RemoveAt(_LatestIndex)
                    ListRefill()
                    MyDialogResult = DialogResult.OK
                End With
            Else
                MSDONE("Process for delete does not selected", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MSDONE("Unexpected error on deleting process parameters", MsgBoxStyle.Critical, ex,,, True)
        End Try
    End Sub
    Private _LatestIndex As Integer = -1
    Private Sub AppsList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppsList.SelectedIndexChanged
        _LatestIndex = AppsList.SelectedIndex
    End Sub
    Private Sub AppsList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles AppsList.MouseDoubleClick
        BTT_EDIT.PerformClick()
    End Sub
End Class