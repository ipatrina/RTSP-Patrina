<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainUI
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainUI))
        Me.LblSubHeading = New System.Windows.Forms.Label()
        Me.BtnNewTask = New System.Windows.Forms.Button()
        Me.BtnMenu = New System.Windows.Forms.Button()
        Me.TxtTaskName = New System.Windows.Forms.TextBox()
        Me.LblTaskName = New System.Windows.Forms.Label()
        Me.TxtURL = New System.Windows.Forms.TextBox()
        Me.LblURL = New System.Windows.Forms.Label()
        Me.PicBadge = New System.Windows.Forms.PictureBox()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.CboPreset = New System.Windows.Forms.ComboBox()
        Me.LblPresetEdit = New System.Windows.Forms.Label()
        Me.BtnHandle = New System.Windows.Forms.Button()
        Me.ChkOverride = New System.Windows.Forms.CheckBox()
        Me.NumOverride = New System.Windows.Forms.NumericUpDown()
        Me.BtnPathBrowse = New System.Windows.Forms.Button()
        Me.LblPreset = New System.Windows.Forms.Label()
        Me.SfdTaskName = New System.Windows.Forms.SaveFileDialog()
        Me.BgwCoreWorker = New System.ComponentModel.BackgroundWorker()
        Me.LblRecording = New System.Windows.Forms.Label()
        Me.LblProgress = New System.Windows.Forms.Label()
        Me.CmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsiConsole = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsiLauncher = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.TmrClipboard = New System.Windows.Forms.Timer(Me.components)
        Me.PicInfo = New System.Windows.Forms.PictureBox()
        Me.PicPlay = New System.Windows.Forms.PictureBox()
        CType(Me.PicBadge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumOverride, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsMenu.SuspendLayout()
        CType(Me.PicInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblSubHeading
        '
        Me.LblSubHeading.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubHeading.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSubHeading.ForeColor = System.Drawing.Color.Aqua
        Me.LblSubHeading.Location = New System.Drawing.Point(228, 15)
        Me.LblSubHeading.Name = "LblSubHeading"
        Me.LblSubHeading.Size = New System.Drawing.Size(52, 26)
        Me.LblSubHeading.TabIndex = 103
        Me.LblSubHeading.Text = "5.0"
        Me.LblSubHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnNewTask
        '
        Me.BtnNewTask.BackColor = System.Drawing.Color.BlueViolet
        Me.BtnNewTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewTask.Font = New System.Drawing.Font("微软雅黑", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnNewTask.ForeColor = System.Drawing.Color.White
        Me.BtnNewTask.Location = New System.Drawing.Point(418, 9)
        Me.BtnNewTask.Name = "BtnNewTask"
        Me.BtnNewTask.Size = New System.Drawing.Size(45, 40)
        Me.BtnNewTask.TabIndex = 201
        Me.BtnNewTask.Text = "+"
        Me.BtnNewTask.UseVisualStyleBackColor = False
        '
        'BtnMenu
        '
        Me.BtnMenu.BackColor = System.Drawing.Color.BlueViolet
        Me.BtnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMenu.Font = New System.Drawing.Font("微软雅黑", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnMenu.ForeColor = System.Drawing.Color.White
        Me.BtnMenu.Location = New System.Drawing.Point(467, 9)
        Me.BtnMenu.Name = "BtnMenu"
        Me.BtnMenu.Size = New System.Drawing.Size(45, 40)
        Me.BtnMenu.TabIndex = 203
        Me.BtnMenu.Text = "···"
        Me.BtnMenu.UseVisualStyleBackColor = False
        '
        'TxtTaskName
        '
        Me.TxtTaskName.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtTaskName.Location = New System.Drawing.Point(110, 226)
        Me.TxtTaskName.Name = "TxtTaskName"
        Me.TxtTaskName.Size = New System.Drawing.Size(363, 29)
        Me.TxtTaskName.TabIndex = 803
        '
        'LblTaskName
        '
        Me.LblTaskName.AutoSize = True
        Me.LblTaskName.BackColor = System.Drawing.Color.Transparent
        Me.LblTaskName.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblTaskName.Location = New System.Drawing.Point(8, 230)
        Me.LblTaskName.Name = "LblTaskName"
        Me.LblTaskName.Size = New System.Drawing.Size(96, 21)
        Me.LblTaskName.TabIndex = 801
        Me.LblTaskName.Text = "Task name:"
        '
        'TxtURL
        '
        Me.TxtURL.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtURL.Location = New System.Drawing.Point(12, 119)
        Me.TxtURL.MaxLength = 0
        Me.TxtURL.Multiline = True
        Me.TxtURL.Name = "TxtURL"
        Me.TxtURL.Size = New System.Drawing.Size(500, 100)
        Me.TxtURL.TabIndex = 601
        '
        'LblURL
        '
        Me.LblURL.AutoSize = True
        Me.LblURL.BackColor = System.Drawing.Color.Transparent
        Me.LblURL.Location = New System.Drawing.Point(8, 90)
        Me.LblURL.Name = "LblURL"
        Me.LblURL.Size = New System.Drawing.Size(87, 21)
        Me.LblURL.TabIndex = 501
        Me.LblURL.Text = "RTSP URL:"
        '
        'PicBadge
        '
        Me.PicBadge.BackColor = System.Drawing.Color.Transparent
        Me.PicBadge.Image = CType(resources.GetObject("PicBadge.Image"), System.Drawing.Image)
        Me.PicBadge.Location = New System.Drawing.Point(12, 12)
        Me.PicBadge.Name = "PicBadge"
        Me.PicBadge.Size = New System.Drawing.Size(64, 64)
        Me.PicBadge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicBadge.TabIndex = 238
        Me.PicBadge.TabStop = False
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.BackColor = System.Drawing.Color.Transparent
        Me.LblTitle.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(83, 14)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(142, 27)
        Me.LblTitle.TabIndex = 101
        Me.LblTitle.Text = "RTSP Patrina"
        '
        'CboPreset
        '
        Me.CboPreset.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CboPreset.FormattingEnabled = True
        Me.CboPreset.Location = New System.Drawing.Point(151, 48)
        Me.CboPreset.Name = "CboPreset"
        Me.CboPreset.Size = New System.Drawing.Size(209, 28)
        Me.CboPreset.TabIndex = 303
        Me.CboPreset.Text = "(No available preset)"
        '
        'LblPresetEdit
        '
        Me.LblPresetEdit.AutoSize = True
        Me.LblPresetEdit.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblPresetEdit.ForeColor = System.Drawing.Color.Blue
        Me.LblPresetEdit.Location = New System.Drawing.Point(366, 51)
        Me.LblPresetEdit.Name = "LblPresetEdit"
        Me.LblPresetEdit.Size = New System.Drawing.Size(39, 21)
        Me.LblPresetEdit.TabIndex = 305
        Me.LblPresetEdit.Text = "Edit"
        '
        'BtnHandle
        '
        Me.BtnHandle.Font = New System.Drawing.Font("微软雅黑", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnHandle.Location = New System.Drawing.Point(184, 267)
        Me.BtnHandle.Name = "BtnHandle"
        Me.BtnHandle.Size = New System.Drawing.Size(156, 60)
        Me.BtnHandle.TabIndex = 901
        Me.BtnHandle.Text = "Start"
        Me.BtnHandle.UseVisualStyleBackColor = True
        '
        'ChkOverride
        '
        Me.ChkOverride.AutoSize = True
        Me.ChkOverride.Enabled = False
        Me.ChkOverride.Location = New System.Drawing.Point(302, 89)
        Me.ChkOverride.Name = "ChkOverride"
        Me.ChkOverride.Size = New System.Drawing.Size(154, 25)
        Me.ChkOverride.TabIndex = 511
        Me.ChkOverride.Text = "Manual override"
        Me.ChkOverride.UseVisualStyleBackColor = True
        '
        'NumOverride
        '
        Me.NumOverride.Location = New System.Drawing.Point(461, 87)
        Me.NumOverride.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumOverride.Name = "NumOverride"
        Me.NumOverride.Size = New System.Drawing.Size(51, 29)
        Me.NumOverride.TabIndex = 513
        '
        'BtnPathBrowse
        '
        Me.BtnPathBrowse.Location = New System.Drawing.Point(478, 225)
        Me.BtnPathBrowse.Name = "BtnPathBrowse"
        Me.BtnPathBrowse.Size = New System.Drawing.Size(35, 31)
        Me.BtnPathBrowse.TabIndex = 805
        Me.BtnPathBrowse.Text = "&..."
        Me.BtnPathBrowse.UseVisualStyleBackColor = True
        '
        'LblPreset
        '
        Me.LblPreset.AutoSize = True
        Me.LblPreset.BackColor = System.Drawing.Color.Transparent
        Me.LblPreset.Location = New System.Drawing.Point(84, 51)
        Me.LblPreset.Name = "LblPreset"
        Me.LblPreset.Size = New System.Drawing.Size(61, 21)
        Me.LblPreset.TabIndex = 301
        Me.LblPreset.Text = "Preset:"
        '
        'SfdTaskName
        '
        Me.SfdTaskName.Filter = "All Files|*.*"
        '
        'BgwCoreWorker
        '
        '
        'LblRecording
        '
        Me.LblRecording.BackColor = System.Drawing.Color.Red
        Me.LblRecording.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblRecording.ForeColor = System.Drawing.Color.White
        Me.LblRecording.Location = New System.Drawing.Point(365, 301)
        Me.LblRecording.Name = "LblRecording"
        Me.LblRecording.Size = New System.Drawing.Size(129, 25)
        Me.LblRecording.TabIndex = 993
        Me.LblRecording.Text = "RECORDING"
        Me.LblRecording.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblRecording.Visible = False
        '
        'LblProgress
        '
        Me.LblProgress.BackColor = System.Drawing.Color.Transparent
        Me.LblProgress.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblProgress.Location = New System.Drawing.Point(346, 271)
        Me.LblProgress.Name = "LblProgress"
        Me.LblProgress.Size = New System.Drawing.Size(166, 25)
        Me.LblProgress.TabIndex = 991
        Me.LblProgress.Text = "00:00:00"
        Me.LblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblProgress.Visible = False
        '
        'CmsMenu
        '
        Me.CmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsiConsole, Me.ToolStripSeparator1, Me.TsiLauncher, Me.TsiAbout})
        Me.CmsMenu.Name = "ContextMenuStrip1"
        Me.CmsMenu.Size = New System.Drawing.Size(129, 76)
        '
        'TsiConsole
        '
        Me.TsiConsole.Name = "TsiConsole"
        Me.TsiConsole.Size = New System.Drawing.Size(128, 22)
        Me.TsiConsole.Text = "Console"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(125, 6)
        '
        'TsiLauncher
        '
        Me.TsiLauncher.Name = "TsiLauncher"
        Me.TsiLauncher.Size = New System.Drawing.Size(128, 22)
        Me.TsiLauncher.Text = "Launcher"
        '
        'TsiAbout
        '
        Me.TsiAbout.Name = "TsiAbout"
        Me.TsiAbout.Size = New System.Drawing.Size(128, 22)
        Me.TsiAbout.Text = "About"
        '
        'TmrClipboard
        '
        Me.TmrClipboard.Interval = 1000
        '
        'PicInfo
        '
        Me.PicInfo.BackColor = System.Drawing.Color.Transparent
        Me.PicInfo.Image = CType(resources.GetObject("PicInfo.Image"), System.Drawing.Image)
        Me.PicInfo.Location = New System.Drawing.Point(46, 282)
        Me.PicInfo.Name = "PicInfo"
        Me.PicInfo.Size = New System.Drawing.Size(30, 30)
        Me.PicInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicInfo.TabIndex = 995
        Me.PicInfo.TabStop = False
        '
        'PicPlay
        '
        Me.PicPlay.BackColor = System.Drawing.Color.Transparent
        Me.PicPlay.Image = CType(resources.GetObject("PicPlay.Image"), System.Drawing.Image)
        Me.PicPlay.Location = New System.Drawing.Point(12, 282)
        Me.PicPlay.Name = "PicPlay"
        Me.PicPlay.Size = New System.Drawing.Size(30, 30)
        Me.PicPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicPlay.TabIndex = 994
        Me.PicPlay.TabStop = False
        '
        'MainUI
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(524, 341)
        Me.Controls.Add(Me.PicInfo)
        Me.Controls.Add(Me.PicPlay)
        Me.Controls.Add(Me.LblProgress)
        Me.Controls.Add(Me.LblRecording)
        Me.Controls.Add(Me.LblPreset)
        Me.Controls.Add(Me.BtnPathBrowse)
        Me.Controls.Add(Me.NumOverride)
        Me.Controls.Add(Me.ChkOverride)
        Me.Controls.Add(Me.BtnHandle)
        Me.Controls.Add(Me.LblPresetEdit)
        Me.Controls.Add(Me.CboPreset)
        Me.Controls.Add(Me.LblSubHeading)
        Me.Controls.Add(Me.BtnNewTask)
        Me.Controls.Add(Me.BtnMenu)
        Me.Controls.Add(Me.TxtTaskName)
        Me.Controls.Add(Me.LblTaskName)
        Me.Controls.Add(Me.TxtURL)
        Me.Controls.Add(Me.LblURL)
        Me.Controls.Add(Me.PicBadge)
        Me.Controls.Add(Me.LblTitle)
        Me.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "MainUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RTSP Patrina"
        CType(Me.PicBadge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumOverride, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsMenu.ResumeLayout(False)
        CType(Me.PicInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblSubHeading As Label
    Friend WithEvents BtnNewTask As Button
    Friend WithEvents BtnMenu As Button
    Friend WithEvents TxtTaskName As TextBox
    Friend WithEvents LblTaskName As Label
    Friend WithEvents TxtURL As TextBox
    Friend WithEvents LblURL As Label
    Friend WithEvents PicBadge As PictureBox
    Friend WithEvents LblTitle As Label
    Friend WithEvents CboPreset As ComboBox
    Friend WithEvents LblPresetEdit As Label
    Friend WithEvents BtnHandle As Button
    Friend WithEvents ChkOverride As CheckBox
    Friend WithEvents NumOverride As NumericUpDown
    Friend WithEvents BtnPathBrowse As Button
    Friend WithEvents LblPreset As Label
    Friend WithEvents SfdTaskName As SaveFileDialog
    Friend WithEvents BgwCoreWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblRecording As Label
    Friend WithEvents LblProgress As Label
    Friend WithEvents CmsMenu As ContextMenuStrip
    Friend WithEvents TsiConsole As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TsiLauncher As ToolStripMenuItem
    Friend WithEvents TsiAbout As ToolStripMenuItem
    Friend WithEvents TmrClipboard As Timer
    Friend WithEvents PicInfo As PictureBox
    Friend WithEvents PicPlay As PictureBox
End Class
