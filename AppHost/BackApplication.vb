Imports PersonalUtilities.Functions.XML
Friend Class BackApplication : Implements IDisposable
#Region "XML Names"
    Friend Const NameContainer As String = "Applications"
    Friend Const NameNode As String = "Application"
    Friend Const NameProcess As String = "Process"
    Friend Const NamePath As String = "Path"
    Friend Const NameTimer As String = "CheckingTimer"
    Friend Const NameStopRestart As String = "StopRestart"
    Friend Const NameLookAppName As String = "LookAppName"
#End Region
    Private WithEvents BTT_TRAY As NotifyIcon
    Private WithEvents MenuStrip As ContextMenuStrip
    Private WithEvents BTT_CLOSE As ToolStripMenuItem
    Private WithEvents BTT_OPEN_SETTINGS As ToolStripMenuItem
    Private WithEvents BTT_SHOW_INFO As ToolStripMenuItem
    Friend ReadOnly MyApps As List(Of LookingApp)
    Friend ReadOnly SettingsFile As SFile = "Settings.xml"
    Friend Property DesignXML As XmlFile
    Friend Sub New()
        MyApps = New List(Of LookingApp)
        BTT_CLOSE = New ToolStripMenuItem With {.DisplayStyle = ToolStripItemDisplayStyle.Text, .Text = "Close"}
        BTT_OPEN_SETTINGS = New ToolStripMenuItem With {.DisplayStyle = ToolStripItemDisplayStyle.Text, .Text = "Settings"}
        BTT_SHOW_INFO = New ToolStripMenuItem With {.DisplayStyle = ToolStripItemDisplayStyle.Text, .Text = "Information"}
        MenuStrip = New ContextMenuStrip With {.UseWaitCursor = False}
        MenuStrip.Items.AddRange({BTT_SHOW_INFO, BTT_OPEN_SETTINGS, New ToolStripSeparator, BTT_CLOSE})
        BTT_TRAY = New NotifyIcon With {.Icon = My.Resources.TrayIcon, .Visible = True, .ContextMenuStrip = MenuStrip}
        Using x As New XmlFile(SettingsFile, ProtectionLevels.All, False) With {.XmlReadOnly = True, .AllowSameNames = True}
            x.LoadData()
            x.DefaultsLoading(False)
            If x.Count > 0 Then
                Dim a As New EAttribute
                For Each e In x
                    MyApps.Add(New LookingApp With {
                                .AppName = e.Attribute(NameProcess, a).Value,
                                .AppPath = e.Attribute(NamePath, a).Value,
                                .AppCheckTimer = AConvert(Of Integer)(e.Attribute(NameTimer, a).Value, LookingApp.DefaultCheckTimer),
                                .RestartPrevent = AConvert(Of Integer)(e.Attribute(NameStopRestart, a).Value, LookingApp.DefaultRestart),
                                .LookAppNameInsteadPath = AConvert(Of Boolean)(e.Attribute(NameLookAppName, a).Value, False)
                                })
                Next
            End If
        End Using
        DesignXML = New XmlFile("Design.xml", ProtectionLevels.All)
        DesignXML.DefaultsLoading(False)
        If MyApps.Count > 0 Then MyApps.ForEach(Sub(aa) aa.Start())
    End Sub
    Friend ReadOnly Property Count As Integer
        Get
            Return MyApps.Count
        End Get
    End Property
    Private Sub BTT_SHOW_INFO_Click(sender As Object, e As EventArgs) Handles BTT_SHOW_INFO.Click
        With MyApps
            If .Count > 0 Then
                Dim OutText$ = String.Empty
                .ForEach(Sub(a) OutText.StringAppendLine($"{a.AppName}: {a.RestartedCount} times restarted", vbCr))
                MSDONE(OutText)
            Else
                MSDONE("No one application detected", MsgBoxStyle.Exclamation)
            End If
        End With
    End Sub
    Private Sub BTT_OPEN_SETTINGS_Click(sender As Object, e As EventArgs) Handles BTT_OPEN_SETTINGS.Click
        Using f As New ProgramsListForm : f.ShowDialog() : End Using
    End Sub
    Private Sub BTT_CLOSE_Click(sender As Object, e As EventArgs) Handles BTT_CLOSE.Click
        Dispose()
    End Sub
#Region "IDisposable Support"
    Private disposedValue As Boolean = False
    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                If MyApps.Count > 0 Then MyApps.ListClearDispose(, EDP.None)
                BTT_TRAY.Visible = False
            End If
            disposedValue = True
            LOADER.Dispose()
        End If
    End Sub
    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
    Friend Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class