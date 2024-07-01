<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Launcher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Launcher))
        Me.LsvQueue = New System.Windows.Forms.ListView()
        Me.ClhStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClhTaskName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClhURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TxtURL = New System.Windows.Forms.TextBox()
        Me.LblURL = New System.Windows.Forms.Label()
        Me.TxtTaskName = New System.Windows.Forms.TextBox()
        Me.LblTaskName = New System.Windows.Forms.Label()
        Me.BtnStorePathBrowse = New System.Windows.Forms.Button()
        Me.TxtStorePath = New System.Windows.Forms.TextBox()
        Me.LblStorePath = New System.Windows.Forms.Label()
        Me.LblOptions = New System.Windows.Forms.Label()
        Me.LblPreset = New System.Windows.Forms.Label()
        Me.CboPreset = New System.Windows.Forms.ComboBox()
        Me.LblDelayUnit = New System.Windows.Forms.Label()
        Me.LblTimeoutUnit = New System.Windows.Forms.Label()
        Me.LblIntervalUnit = New System.Windows.Forms.Label()
        Me.LblDelay = New System.Windows.Forms.Label()
        Me.NumInterval = New System.Windows.Forms.NumericUpDown()
        Me.NumDelay = New System.Windows.Forms.NumericUpDown()
        Me.LblInterval = New System.Windows.Forms.Label()
        Me.LblTimeout = New System.Windows.Forms.Label()
        Me.NumTimeout = New System.Windows.Forms.NumericUpDown()
        Me.LblLaunch = New System.Windows.Forms.Label()
        Me.ChkStart = New System.Windows.Forms.CheckBox()
        Me.LblOffset = New System.Windows.Forms.Label()
        Me.NumOffset = New System.Windows.Forms.NumericUpDown()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.BtnAddLocal = New System.Windows.Forms.Button()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.OfdAddLocal = New System.Windows.Forms.OpenFileDialog()
        Me.SFDExport = New System.Windows.Forms.SaveFileDialog()
        Me.FbdPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.TmrLauncher = New System.Windows.Forms.Timer(Me.components)
        Me.TmrCountdown = New System.Windows.Forms.Timer(Me.components)
        CType(Me.NumInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LsvQueue
        '
        Me.LsvQueue.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClhStatus, Me.ClhTaskName, Me.ClhURL})
        Me.LsvQueue.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LsvQueue.FullRowSelect = True
        Me.LsvQueue.HideSelection = False
        Me.LsvQueue.Location = New System.Drawing.Point(12, 12)
        Me.LsvQueue.Name = "LsvQueue"
        Me.LsvQueue.Size = New System.Drawing.Size(760, 290)
        Me.LsvQueue.TabIndex = 101
        Me.LsvQueue.UseCompatibleStateImageBehavior = False
        Me.LsvQueue.View = System.Windows.Forms.View.Details
        '
        'ClhStatus
        '
        Me.ClhStatus.Text = "STATUS"
        Me.ClhStatus.Width = 65
        '
        'ClhTaskName
        '
        Me.ClhTaskName.Text = "NAME"
        Me.ClhTaskName.Width = 200
        '
        'ClhURL
        '
        Me.ClhURL.Text = "URL"
        Me.ClhURL.Width = 475
        '
        'TxtURL
        '
        Me.TxtURL.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtURL.Location = New System.Drawing.Point(12, 340)
        Me.TxtURL.MaxLength = 0
        Me.TxtURL.Multiline = True
        Me.TxtURL.Name = "TxtURL"
        Me.TxtURL.Size = New System.Drawing.Size(322, 99)
        Me.TxtURL.TabIndex = 303
        '
        'LblURL
        '
        Me.LblURL.AutoSize = True
        Me.LblURL.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblURL.Location = New System.Drawing.Point(8, 311)
        Me.LblURL.Name = "LblURL"
        Me.LblURL.Size = New System.Drawing.Size(50, 21)
        Me.LblURL.TabIndex = 301
        Me.LblURL.Text = "[URL]"
        '
        'TxtTaskName
        '
        Me.TxtTaskName.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtTaskName.Location = New System.Drawing.Point(12, 486)
        Me.TxtTaskName.Name = "TxtTaskName"
        Me.TxtTaskName.Size = New System.Drawing.Size(322, 29)
        Me.TxtTaskName.TabIndex = 403
        '
        'LblTaskName
        '
        Me.LblTaskName.AutoSize = True
        Me.LblTaskName.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblTaskName.Location = New System.Drawing.Point(8, 455)
        Me.LblTaskName.Name = "LblTaskName"
        Me.LblTaskName.Size = New System.Drawing.Size(105, 21)
        Me.LblTaskName.TabIndex = 401
        Me.LblTaskName.Text = "[Task Name]"
        '
        'BtnStorePathBrowse
        '
        Me.BtnStorePathBrowse.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnStorePathBrowse.Location = New System.Drawing.Point(673, 340)
        Me.BtnStorePathBrowse.Name = "BtnStorePathBrowse"
        Me.BtnStorePathBrowse.Size = New System.Drawing.Size(35, 30)
        Me.BtnStorePathBrowse.TabIndex = 615
        Me.BtnStorePathBrowse.Text = "&..."
        Me.BtnStorePathBrowse.UseVisualStyleBackColor = True
        '
        'TxtStorePath
        '
        Me.TxtStorePath.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtStorePath.Location = New System.Drawing.Point(448, 340)
        Me.TxtStorePath.Name = "TxtStorePath"
        Me.TxtStorePath.ReadOnly = True
        Me.TxtStorePath.Size = New System.Drawing.Size(219, 29)
        Me.TxtStorePath.TabIndex = 613
        '
        'LblStorePath
        '
        Me.LblStorePath.AutoSize = True
        Me.LblStorePath.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblStorePath.Location = New System.Drawing.Point(347, 343)
        Me.LblStorePath.Name = "LblStorePath"
        Me.LblStorePath.Size = New System.Drawing.Size(94, 21)
        Me.LblStorePath.TabIndex = 611
        Me.LblStorePath.Text = "Store path:"
        '
        'LblOptions
        '
        Me.LblOptions.AutoSize = True
        Me.LblOptions.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblOptions.Location = New System.Drawing.Point(347, 311)
        Me.LblOptions.Name = "LblOptions"
        Me.LblOptions.Size = New System.Drawing.Size(80, 21)
        Me.LblOptions.TabIndex = 601
        Me.LblOptions.Text = "[Options]"
        '
        'LblPreset
        '
        Me.LblPreset.AutoSize = True
        Me.LblPreset.BackColor = System.Drawing.Color.Transparent
        Me.LblPreset.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblPreset.Location = New System.Drawing.Point(347, 379)
        Me.LblPreset.Name = "LblPreset"
        Me.LblPreset.Size = New System.Drawing.Size(61, 21)
        Me.LblPreset.TabIndex = 631
        Me.LblPreset.Text = "Preset:"
        '
        'CboPreset
        '
        Me.CboPreset.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CboPreset.FormattingEnabled = True
        Me.CboPreset.Location = New System.Drawing.Point(448, 375)
        Me.CboPreset.Name = "CboPreset"
        Me.CboPreset.Size = New System.Drawing.Size(219, 29)
        Me.CboPreset.TabIndex = 633
        Me.CboPreset.Text = "(No available preset)"
        '
        'LblDelayUnit
        '
        Me.LblDelayUnit.AutoSize = True
        Me.LblDelayUnit.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDelayUnit.Location = New System.Drawing.Point(531, 489)
        Me.LblDelayUnit.Name = "LblDelayUnit"
        Me.LblDelayUnit.Size = New System.Drawing.Size(39, 21)
        Me.LblDelayUnit.TabIndex = 815
        Me.LblDelayUnit.Text = "min"
        '
        'LblTimeoutUnit
        '
        Me.LblTimeoutUnit.AutoSize = True
        Me.LblTimeoutUnit.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblTimeoutUnit.Location = New System.Drawing.Point(531, 413)
        Me.LblTimeoutUnit.Name = "LblTimeoutUnit"
        Me.LblTimeoutUnit.Size = New System.Drawing.Size(39, 21)
        Me.LblTimeoutUnit.TabIndex = 655
        Me.LblTimeoutUnit.Text = "min"
        '
        'LblIntervalUnit
        '
        Me.LblIntervalUnit.AutoSize = True
        Me.LblIntervalUnit.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblIntervalUnit.Location = New System.Drawing.Point(530, 524)
        Me.LblIntervalUnit.Name = "LblIntervalUnit"
        Me.LblIntervalUnit.Size = New System.Drawing.Size(17, 21)
        Me.LblIntervalUnit.TabIndex = 835
        Me.LblIntervalUnit.Text = "s"
        '
        'LblDelay
        '
        Me.LblDelay.AutoSize = True
        Me.LblDelay.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblDelay.Location = New System.Drawing.Point(347, 489)
        Me.LblDelay.Name = "LblDelay"
        Me.LblDelay.Size = New System.Drawing.Size(56, 21)
        Me.LblDelay.TabIndex = 811
        Me.LblDelay.Text = "Delay:"
        '
        'NumInterval
        '
        Me.NumInterval.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumInterval.Location = New System.Drawing.Point(448, 521)
        Me.NumInterval.Maximum = New Decimal(New Integer() {86400, 0, 0, 0})
        Me.NumInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumInterval.Name = "NumInterval"
        Me.NumInterval.Size = New System.Drawing.Size(75, 29)
        Me.NumInterval.TabIndex = 833
        Me.NumInterval.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'NumDelay
        '
        Me.NumDelay.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumDelay.Location = New System.Drawing.Point(448, 486)
        Me.NumDelay.Maximum = New Decimal(New Integer() {43200, 0, 0, 0})
        Me.NumDelay.Name = "NumDelay"
        Me.NumDelay.Size = New System.Drawing.Size(75, 29)
        Me.NumDelay.TabIndex = 813
        '
        'LblInterval
        '
        Me.LblInterval.AutoSize = True
        Me.LblInterval.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblInterval.Location = New System.Drawing.Point(347, 524)
        Me.LblInterval.Name = "LblInterval"
        Me.LblInterval.Size = New System.Drawing.Size(71, 21)
        Me.LblInterval.TabIndex = 831
        Me.LblInterval.Text = "Interval:"
        '
        'LblTimeout
        '
        Me.LblTimeout.AutoSize = True
        Me.LblTimeout.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblTimeout.Location = New System.Drawing.Point(347, 413)
        Me.LblTimeout.Name = "LblTimeout"
        Me.LblTimeout.Size = New System.Drawing.Size(77, 21)
        Me.LblTimeout.TabIndex = 651
        Me.LblTimeout.Text = "Timeout:"
        '
        'NumTimeout
        '
        Me.NumTimeout.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumTimeout.Location = New System.Drawing.Point(448, 410)
        Me.NumTimeout.Maximum = New Decimal(New Integer() {43200, 0, 0, 0})
        Me.NumTimeout.Name = "NumTimeout"
        Me.NumTimeout.Size = New System.Drawing.Size(75, 29)
        Me.NumTimeout.TabIndex = 653
        '
        'LblLaunch
        '
        Me.LblLaunch.AutoSize = True
        Me.LblLaunch.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblLaunch.Location = New System.Drawing.Point(347, 455)
        Me.LblLaunch.Name = "LblLaunch"
        Me.LblLaunch.Size = New System.Drawing.Size(75, 21)
        Me.LblLaunch.TabIndex = 801
        Me.LblLaunch.Text = "[Launch]"
        '
        'ChkStart
        '
        Me.ChkStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ChkStart.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChkStart.Location = New System.Drawing.Point(657, 489)
        Me.ChkStart.Name = "ChkStart"
        Me.ChkStart.Size = New System.Drawing.Size(115, 61)
        Me.ChkStart.TabIndex = 991
        Me.ChkStart.Text = "&Start"
        Me.ChkStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkStart.UseVisualStyleBackColor = False
        '
        'LblOffset
        '
        Me.LblOffset.AutoSize = True
        Me.LblOffset.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblOffset.Location = New System.Drawing.Point(8, 524)
        Me.LblOffset.Name = "LblOffset"
        Me.LblOffset.Size = New System.Drawing.Size(125, 21)
        Me.LblOffset.TabIndex = 411
        Me.LblOffset.Text = "Counter offset:"
        '
        'NumOffset
        '
        Me.NumOffset.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumOffset.Location = New System.Drawing.Point(143, 521)
        Me.NumOffset.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NumOffset.Name = "NumOffset"
        Me.NumOffset.Size = New System.Drawing.Size(75, 29)
        Me.NumOffset.TabIndex = 413
        '
        'BtnExport
        '
        Me.BtnExport.BackColor = System.Drawing.Color.IndianRed
        Me.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExport.Font = New System.Drawing.Font("微软雅黑", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnExport.ForeColor = System.Drawing.Color.White
        Me.BtnExport.Location = New System.Drawing.Point(723, 413)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(50, 45)
        Me.BtnExport.TabIndex = 921
        Me.BtnExport.Tag = ""
        Me.BtnExport.Text = "o"
        Me.BtnExport.UseVisualStyleBackColor = False
        '
        'BtnAddLocal
        '
        Me.BtnAddLocal.BackColor = System.Drawing.Color.IndianRed
        Me.BtnAddLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddLocal.Font = New System.Drawing.Font("微软雅黑", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnAddLocal.ForeColor = System.Drawing.Color.White
        Me.BtnAddLocal.Location = New System.Drawing.Point(723, 311)
        Me.BtnAddLocal.Name = "BtnAddLocal"
        Me.BtnAddLocal.Size = New System.Drawing.Size(50, 45)
        Me.BtnAddLocal.TabIndex = 901
        Me.BtnAddLocal.Text = "+"
        Me.BtnAddLocal.UseVisualStyleBackColor = False
        '
        'BtnRemove
        '
        Me.BtnRemove.BackColor = System.Drawing.Color.IndianRed
        Me.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRemove.Font = New System.Drawing.Font("微软雅黑", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnRemove.ForeColor = System.Drawing.Color.White
        Me.BtnRemove.Location = New System.Drawing.Point(723, 362)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(50, 45)
        Me.BtnRemove.TabIndex = 911
        Me.BtnRemove.Text = "-"
        Me.BtnRemove.UseVisualStyleBackColor = False
        '
        'OfdAddLocal
        '
        Me.OfdAddLocal.Filter = "All Files|*.*"
        '
        'SFDExport
        '
        Me.SFDExport.Filter = "Text File|*.txt|All Files|*.*"
        '
        'TmrLauncher
        '
        Me.TmrLauncher.Interval = 5000
        '
        'TmrCountdown
        '
        Me.TmrCountdown.Interval = 60000
        '
        'Launcher
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.BtnAddLocal)
        Me.Controls.Add(Me.BtnRemove)
        Me.Controls.Add(Me.LblOffset)
        Me.Controls.Add(Me.NumOffset)
        Me.Controls.Add(Me.ChkStart)
        Me.Controls.Add(Me.LblLaunch)
        Me.Controls.Add(Me.LblDelayUnit)
        Me.Controls.Add(Me.LblTimeoutUnit)
        Me.Controls.Add(Me.LblIntervalUnit)
        Me.Controls.Add(Me.LblDelay)
        Me.Controls.Add(Me.NumInterval)
        Me.Controls.Add(Me.NumDelay)
        Me.Controls.Add(Me.LblInterval)
        Me.Controls.Add(Me.LblTimeout)
        Me.Controls.Add(Me.NumTimeout)
        Me.Controls.Add(Me.LblPreset)
        Me.Controls.Add(Me.CboPreset)
        Me.Controls.Add(Me.BtnStorePathBrowse)
        Me.Controls.Add(Me.TxtStorePath)
        Me.Controls.Add(Me.LblStorePath)
        Me.Controls.Add(Me.LblOptions)
        Me.Controls.Add(Me.TxtURL)
        Me.Controls.Add(Me.LblURL)
        Me.Controls.Add(Me.TxtTaskName)
        Me.Controls.Add(Me.LblTaskName)
        Me.Controls.Add(Me.LsvQueue)
        Me.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Launcher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Launcher"
        CType(Me.NumInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumOffset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents LsvQueue As ListView
    Friend WithEvents ClhStatus As ColumnHeader
    Friend WithEvents ClhTaskName As ColumnHeader
    Friend WithEvents ClhURL As ColumnHeader
    Friend WithEvents TxtURL As TextBox
    Friend WithEvents LblURL As Label
    Friend WithEvents TxtTaskName As TextBox
    Friend WithEvents LblTaskName As Label
    Friend WithEvents BtnStorePathBrowse As Button
    Friend WithEvents TxtStorePath As TextBox
    Friend WithEvents LblStorePath As Label
    Friend WithEvents LblOptions As Label
    Friend WithEvents LblPreset As Label
    Friend WithEvents CboPreset As ComboBox
    Friend WithEvents LblDelayUnit As Label
    Friend WithEvents LblTimeoutUnit As Label
    Friend WithEvents LblIntervalUnit As Label
    Friend WithEvents LblDelay As Label
    Friend WithEvents NumInterval As NumericUpDown
    Friend WithEvents NumDelay As NumericUpDown
    Friend WithEvents LblInterval As Label
    Friend WithEvents LblTimeout As Label
    Friend WithEvents NumTimeout As NumericUpDown
    Friend WithEvents LblLaunch As Label
    Friend WithEvents ChkStart As CheckBox
    Friend WithEvents LblOffset As Label
    Friend WithEvents NumOffset As NumericUpDown
    Friend WithEvents BtnExport As Button
    Friend WithEvents BtnAddLocal As Button
    Friend WithEvents BtnRemove As Button
    Friend WithEvents OfdAddLocal As OpenFileDialog
    Friend WithEvents SFDExport As SaveFileDialog
    Friend WithEvents FbdPath As FolderBrowserDialog
    Friend WithEvents TmrLauncher As Timer
    Friend WithEvents TmrCountdown As Timer
End Class
