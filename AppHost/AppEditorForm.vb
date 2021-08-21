Imports System.ComponentModel
Imports PersonalUtilities.Forms
Imports PersonalUtilities.Forms.Controls
Imports PersonalUtilities.Forms.Toolbars
Friend Class AppEditorForm : Implements IOkCancelToolbar
    Private ReadOnly MyDefs As DefaultFormProps(Of FieldsChecker)
    Friend Property MyProc As LookingApp
    Friend Sub New(ByRef _Proc As LookingApp)
        InitializeComponent()
        MyProc = _Proc
        MyDefs = New DefaultFormProps(Of FieldsChecker)
    End Sub
    Private Sub AppEditorForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            With MyDefs
                .MyForm = Me
                .MyXML = MyApp.DesignXML
                .MyView = New FormsView(Me) With {.LocationOnly = True}
                .MyView.ImportFromXML(MyApp.DesignXML)
                .MyView.SetMeSize()
                .MyOkCancel = New OkCancelToolbar(Me, Me, CONTAINER_MAIN.BottomToolStripPanel)
                .MyOkCancel.AddThisToolbar()
                If Not MyProc Is Nothing Then
                    With MyProc
                        TXT_PROC_NAME.Text = .AppName
                        TXT_APP_PATH.Text = .AppPath
                        TXT_CHECK_TIMER.Text = .AppCheckTimer
                        TXT_STOP_RESTART.Text = .RestartPrevent
                    End With
                Else
                    TXT_CHECK_TIMER.Text = LookingApp.DefaultCheckTimer
                    TXT_STOP_RESTART.Text = LookingApp.DefaultRestart
                End If
                .MyFieldsChecker = New FieldsChecker
                With .MyFieldsChecker
                    .AddControl(Of String)(TXT_PROC_NAME, TXT_PROC_NAME.CaptionText)
                    .AddControl(Of String)(TXT_APP_PATH, TXT_APP_PATH.CaptionText)
                    .AddControl(Of Integer)(TXT_CHECK_TIMER, TXT_CHECK_TIMER.CaptionText)
                    .AddControl(Of Integer)(TXT_STOP_RESTART, TXT_STOP_RESTART.Text)
                    .EndLoaderOperations()
                End With
                .EndLoaderOperations()
                TextBoxExtended.SetFalseDetector(TP_MAIN, True, AddressOf .Detector, EDP.SendInLog)
            End With
        Catch ex As Exception
            MyDefs.InvokeLoaderError(ex)
        End Try
    End Sub
    Private Sub AppEditorForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not BeforeCloseChecker(MyDefs.ChangesDetected) Then
            e.Cancel = True
        Else
            MyDefs.Dispose()
        End If
    End Sub
    Public Sub ToolbarBttOK() Implements IOkCancelToolbar.ToolbarBttOK
        Try
            If MyDefs.MyFieldsChecker.AllParamsOK Then
                If MyProc Is Nothing Then MyProc = New LookingApp
                With MyProc
                    .AppName = TXT_PROC_NAME.Text
                    .AppPath = TXT_APP_PATH.Text
                    .LookAppNameInsteadPath = CH_LOOK_APP_NAME.Checked
                    .AppCheckTimer = AConvert(Of Integer)(TXT_CHECK_TIMER.Text, LookingApp.DefaultCheckTimer)
                    .RestartPrevent = AConvert(Of Integer)(TXT_STOP_RESTART.Text, LookingApp.DefaultRestart)
                End With
                MyDefs.ChangesDetected = False
                DialogResult = DialogResult.OK
                Close()
            End If
        Catch ex As Exception
            MSDONE("Unexpected error on saving process parameters", MsgBoxStyle.Critical, ex,,, True)
        End Try
    End Sub
    Public Sub ToolbarBttCancel() Implements IOkCancelToolbar.ToolbarBttCancel
        MyDefs.ChangesDetected = False
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub CH_LOOK_APP_NAME_CheckedChanged(sender As Object, e As EventArgs) Handles CH_LOOK_APP_NAME.CheckedChanged
        MyDefs.Detector()
    End Sub
End Class