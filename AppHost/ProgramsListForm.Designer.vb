<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Friend Class ProgramsListForm : Inherits System.Windows.Forms.Form
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
        Me.ToolbarTOP = New System.Windows.Forms.ToolStrip()
        Me.BTT_ADD = New System.Windows.Forms.ToolStripButton()
        Me.BTT_EDIT = New System.Windows.Forms.ToolStripButton()
        Me.BTT_DEL = New System.Windows.Forms.ToolStripButton()
        Me.AppsList = New System.Windows.Forms.ListBox()
        Me.ToolbarBOTTOM = New System.Windows.Forms.StatusStrip()
        Me.ToolbarTOP.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolbarTOP
        '
        Me.ToolbarTOP.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolbarTOP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTT_ADD, Me.BTT_EDIT, Me.BTT_DEL})
        Me.ToolbarTOP.Location = New System.Drawing.Point(0, 0)
        Me.ToolbarTOP.Name = "ToolbarTOP"
        Me.ToolbarTOP.Size = New System.Drawing.Size(334, 25)
        Me.ToolbarTOP.TabIndex = 0
        '
        'BTT_ADD
        '
        Me.BTT_ADD.AutoToolTip = False
        Me.BTT_ADD.Image = Global.AppHost.My.Resources.Resources.Plus
        Me.BTT_ADD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTT_ADD.Name = "BTT_ADD"
        Me.BTT_ADD.Size = New System.Drawing.Size(75, 22)
        Me.BTT_ADD.Text = "Add (Ins)"
        '
        'BTT_EDIT
        '
        Me.BTT_EDIT.AutoToolTip = False
        Me.BTT_EDIT.Image = Global.AppHost.My.Resources.Resources.PencilPic_01_16
        Me.BTT_EDIT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTT_EDIT.Name = "BTT_EDIT"
        Me.BTT_EDIT.Size = New System.Drawing.Size(70, 22)
        Me.BTT_EDIT.Text = "Edit (F4)"
        '
        'BTT_DEL
        '
        Me.BTT_DEL.AutoToolTip = False
        Me.BTT_DEL.Image = Global.AppHost.My.Resources.Resources.Delete
        Me.BTT_DEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTT_DEL.Name = "BTT_DEL"
        Me.BTT_DEL.Size = New System.Drawing.Size(88, 22)
        Me.BTT_DEL.Text = "Delete (Del)"
        '
        'AppsList
        '
        Me.AppsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppsList.FormattingEnabled = True
        Me.AppsList.Location = New System.Drawing.Point(0, 25)
        Me.AppsList.Name = "AppsList"
        Me.AppsList.Size = New System.Drawing.Size(334, 166)
        Me.AppsList.TabIndex = 1
        '
        'ToolbarBOTTOM
        '
        Me.ToolbarBOTTOM.Location = New System.Drawing.Point(0, 169)
        Me.ToolbarBOTTOM.Name = "ToolbarBOTTOM"
        Me.ToolbarBOTTOM.Size = New System.Drawing.Size(334, 22)
        Me.ToolbarBOTTOM.TabIndex = 2
        '
        'ProgramsListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 191)
        Me.Controls.Add(Me.AppsList)
        Me.Controls.Add(Me.ToolbarBOTTOM)
        Me.Controls.Add(Me.ToolbarTOP)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(350, 230)
        Me.Name = "ProgramsListForm"
        Me.ShowIcon = False
        Me.Text = "Applications"
        Me.ToolbarTOP.ResumeLayout(False)
        Me.ToolbarTOP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents ToolbarTOP As ToolStrip
    Private WithEvents BTT_ADD As ToolStripButton
    Private WithEvents BTT_EDIT As ToolStripButton
    Private WithEvents BTT_DEL As ToolStripButton
    Private WithEvents AppsList As ListBox
    Private WithEvents ToolbarBOTTOM As StatusStrip
End Class