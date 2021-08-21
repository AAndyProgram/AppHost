<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Friend Class AppEditorForm : Inherits System.Windows.Forms.Form
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ActionButton1 As PersonalUtilities.Forms.Controls.Base.ActionButton = New PersonalUtilities.Forms.Controls.Base.ActionButton()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppEditorForm))
        Dim TT_MAIN As System.Windows.Forms.ToolTip
        Me.TP_MAIN = New System.Windows.Forms.TableLayoutPanel()
        Me.CH_LOOK_APP_NAME = New System.Windows.Forms.CheckBox()
        Me.TXT_APP_PATH = New PersonalUtilities.Forms.Controls.TextBoxExtended()
        Me.TXT_PROC_NAME = New PersonalUtilities.Forms.Controls.TextBoxExtended()
        Me.TXT_CHECK_TIMER = New PersonalUtilities.Forms.Controls.TextBoxExtended()
        Me.TXT_STOP_RESTART = New PersonalUtilities.Forms.Controls.TextBoxExtended()
        Me.CONTAINER_MAIN = New System.Windows.Forms.ToolStripContainer()
        TT_MAIN = New System.Windows.Forms.ToolTip(Me.components)
        Me.TP_MAIN.SuspendLayout()
        CType(Me.TXT_APP_PATH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_PROC_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_CHECK_TIMER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_STOP_RESTART, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CONTAINER_MAIN.ContentPanel.SuspendLayout()
        Me.CONTAINER_MAIN.SuspendLayout()
        Me.SuspendLayout()
        '
        'TP_MAIN
        '
        Me.TP_MAIN.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TP_MAIN.ColumnCount = 1
        Me.TP_MAIN.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TP_MAIN.Controls.Add(Me.CH_LOOK_APP_NAME, 0, 4)
        Me.TP_MAIN.Controls.Add(Me.TXT_APP_PATH, 0, 1)
        Me.TP_MAIN.Controls.Add(Me.TXT_PROC_NAME, 0, 0)
        Me.TP_MAIN.Controls.Add(Me.TXT_CHECK_TIMER, 0, 2)
        Me.TP_MAIN.Controls.Add(Me.TXT_STOP_RESTART, 0, 3)
        Me.TP_MAIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TP_MAIN.Location = New System.Drawing.Point(0, 0)
        Me.TP_MAIN.Name = "TP_MAIN"
        Me.TP_MAIN.RowCount = 5
        Me.TP_MAIN.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TP_MAIN.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TP_MAIN.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TP_MAIN.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TP_MAIN.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TP_MAIN.Size = New System.Drawing.Size(576, 141)
        Me.TP_MAIN.TabIndex = 0
        '
        'CH_LOOK_APP_NAME
        '
        Me.CH_LOOK_APP_NAME.AutoSize = True
        Me.CH_LOOK_APP_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CH_LOOK_APP_NAME.Location = New System.Drawing.Point(4, 116)
        Me.CH_LOOK_APP_NAME.Name = "CH_LOOK_APP_NAME"
        Me.CH_LOOK_APP_NAME.Padding = New System.Windows.Forms.Padding(100, 0, 0, 0)
        Me.CH_LOOK_APP_NAME.Size = New System.Drawing.Size(568, 21)
        Me.CH_LOOK_APP_NAME.TabIndex = 4
        Me.CH_LOOK_APP_NAME.Text = "Look Application Name Instead Path"
        TT_MAIN.SetToolTip(Me.CH_LOOK_APP_NAME, "If checked than application name (instead application path) will be looking for i" &
        "n processes.")
        Me.CH_LOOK_APP_NAME.UseVisualStyleBackColor = True
        '
        'TXT_APP_PATH
        '
        ActionButton1.BackgroundImage = CType(resources.GetObject("ActionButton1.BackgroundImage"), System.Drawing.Image)
        ActionButton1.Index = 0
        ActionButton1.Name = "BTT_OPEN"
        Me.TXT_APP_PATH.Buttons.Add(ActionButton1)
        Me.TXT_APP_PATH.CaptionText = "Application Path"
        Me.TXT_APP_PATH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXT_APP_PATH.Location = New System.Drawing.Point(4, 32)
        Me.TXT_APP_PATH.Name = "TXT_APP_PATH"
        Me.TXT_APP_PATH.Size = New System.Drawing.Size(568, 22)
        Me.TXT_APP_PATH.TabIndex = 1
        '
        'TXT_PROC_NAME
        '
        Me.TXT_PROC_NAME.CaptionText = "Process Name"
        Me.TXT_PROC_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXT_PROC_NAME.Location = New System.Drawing.Point(4, 4)
        Me.TXT_PROC_NAME.Name = "TXT_PROC_NAME"
        Me.TXT_PROC_NAME.Size = New System.Drawing.Size(568, 22)
        Me.TXT_PROC_NAME.TabIndex = 0
        '
        'TXT_CHECK_TIMER
        '
        Me.TXT_CHECK_TIMER.CaptionText = "Check Timer"
        Me.TXT_CHECK_TIMER.CaptionToolTipEnabled = True
        Me.TXT_CHECK_TIMER.CaptionToolTipText = "Application will be checked for started by this interval (in seconds)"
        Me.TXT_CHECK_TIMER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXT_CHECK_TIMER.Location = New System.Drawing.Point(4, 60)
        Me.TXT_CHECK_TIMER.Name = "TXT_CHECK_TIMER"
        Me.TXT_CHECK_TIMER.Size = New System.Drawing.Size(568, 22)
        Me.TXT_CHECK_TIMER.TabIndex = 2
        '
        'TXT_STOP_RESTART
        '
        Me.TXT_STOP_RESTART.CaptionText = "Stop Restart After"
        Me.TXT_STOP_RESTART.CaptionToolTipEnabled = True
        Me.TXT_STOP_RESTART.CaptionToolTipText = "Application will not be restarted after restart count will be grown more than thi" &
    "s value"
        Me.TXT_STOP_RESTART.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXT_STOP_RESTART.Location = New System.Drawing.Point(4, 88)
        Me.TXT_STOP_RESTART.Name = "TXT_STOP_RESTART"
        Me.TXT_STOP_RESTART.Size = New System.Drawing.Size(568, 22)
        Me.TXT_STOP_RESTART.TabIndex = 3
        '
        'CONTAINER_MAIN
        '
        '
        'CONTAINER_MAIN.ContentPanel
        '
        Me.CONTAINER_MAIN.ContentPanel.Controls.Add(Me.TP_MAIN)
        Me.CONTAINER_MAIN.ContentPanel.Size = New System.Drawing.Size(576, 141)
        Me.CONTAINER_MAIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CONTAINER_MAIN.LeftToolStripPanelVisible = False
        Me.CONTAINER_MAIN.Location = New System.Drawing.Point(0, 0)
        Me.CONTAINER_MAIN.Name = "CONTAINER_MAIN"
        Me.CONTAINER_MAIN.RightToolStripPanelVisible = False
        Me.CONTAINER_MAIN.Size = New System.Drawing.Size(576, 166)
        Me.CONTAINER_MAIN.TabIndex = 0
        Me.CONTAINER_MAIN.TopToolStripPanelVisible = False
        '
        'AppEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 166)
        Me.Controls.Add(Me.CONTAINER_MAIN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(592, 205)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(592, 205)
        Me.Name = "AppEditorForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Application"
        Me.TP_MAIN.ResumeLayout(False)
        Me.TP_MAIN.PerformLayout()
        CType(Me.TXT_APP_PATH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_PROC_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_CHECK_TIMER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_STOP_RESTART, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CONTAINER_MAIN.ContentPanel.ResumeLayout(False)
        Me.CONTAINER_MAIN.ResumeLayout(False)
        Me.CONTAINER_MAIN.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents CONTAINER_MAIN As ToolStripContainer
    Private WithEvents TP_MAIN As TableLayoutPanel
    Private WithEvents CH_LOOK_APP_NAME As CheckBox
    Private WithEvents TXT_APP_PATH As PersonalUtilities.Forms.Controls.TextBoxExtended
    Private WithEvents TXT_PROC_NAME As PersonalUtilities.Forms.Controls.TextBoxExtended
    Private WithEvents TXT_CHECK_TIMER As PersonalUtilities.Forms.Controls.TextBoxExtended
    Private WithEvents TXT_STOP_RESTART As PersonalUtilities.Forms.Controls.TextBoxExtended
End Class