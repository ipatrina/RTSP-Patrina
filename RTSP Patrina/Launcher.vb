Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Launcher
    Public StrQueueStatus1 As String = "□"
    Public StrQueueStatus2 As String = "■"

    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If MainUI.USER_LANGUAGE_ID = 2052 Or MainUI.USER_LANGUAGE_ID = 1028 Or MainUI.USER_LANGUAGE_ID = 3076 Then
                Text = "任务启动器"
                ClhStatus.Text = "状态"
                ClhTaskName.Text = "任务名称"
                ClhURL.Text = "链接"
                LblURL.Text = "[ 链接 ]"
                LblTaskName.Text = "[ 任务名称 ]"
                LblOffset.Text = "计数器偏移量:"
                LblOptions.Text = "[ 选项 ]"
                LblStorePath.Text = "存储目录:"
                LblPreset.Text = "预设:"
                CboPreset.Text = "(无可用预设)"
                LblTimeout.Text = "超时:"
                LblTimeoutUnit.Text = "分钟"
                LblLaunch.Text = "[ 启动 ]"
                LblDelay.Text = "推迟:"
                LblDelayUnit.Text = "分钟"
                LblInterval.Text = "启动间隔:"
                LblIntervalUnit.Text = "秒"
                ChkStart.Text = "开始"

                TEXT_QUIT = "您确定要退出任务启动器吗？"
                TEXT_REMOVE = "您确定要移除所有任务吗？"
                TEXT_TASK = " 项任务"
                TEXT_TASKS = ""
            End If
        Catch ex As Exception

        End Try

        Try
            For Each PresetFile In Directory.GetFiles(Application.StartupPath, "*.cfg")
                Dim PresetFileName As String = Path.GetFileNameWithoutExtension(PresetFile)
                CboPreset.Items.Add(PresetFileName)
                CboPreset.Text = PresetFileName
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim TEXT_QUIT As String = "Are you sure to exit the task launcher?"
    Private Sub Launcher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            e.Cancel = 1
            If MsgBox(TEXT_QUIT, vbQuestion + vbYesNo, "") = vbNo Then
                Exit Sub
            End If
            MainUI.Dispose()
            End
        Catch ex As Exception
            MainUI.Dispose()
            End
        End Try
    End Sub

    Private Sub Launcher_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Launcher_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Try
            Filter(e.Data.GetData(DataFormats.FileDrop)(0))
        Catch ex As Exception

        Finally
            CountTasks()
        End Try
    End Sub

    Private Sub BtnAddLocal_Click(sender As Object, e As EventArgs) Handles BtnAddLocal.Click
        Try
            If TxtURL.Text = "" Then
                If OfdAddLocal.ShowDialog() = DialogResult.OK Then
                    Filter(OfdAddLocal.FileName)
                End If
            Else
                AddQueue(TxtURL.Text)
                TxtURL.Text = ""
                If Not TxtTaskName.Text.Contains("\") Then TxtTaskName.Text = ""
            End If
        Catch ex As Exception

        Finally
            CountTasks()
        End Try
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Try
            If SFDExport.ShowDialog = DialogResult.OK Then
                Dim _loc_1 As New System.IO.StreamWriter(SFDExport.FileName, False, New UTF8Encoding(False))
                For _loc_2 = 0 To LsvQueue.Items.Count - 1
                    _loc_1.WriteLine("<")
                    _loc_1.WriteLine(LsvQueue.Items(_loc_2).SubItems(2).Text)
                    _loc_1.WriteLine(LsvQueue.Items(_loc_2).SubItems(1).Text)
                    _loc_1.WriteLine(">")
                Next
                _loc_1.Close()
                _loc_1.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim TEXT_REMOVE As String = "Are you sure to remove all tasks?"
    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        Try
            If LsvQueue.SelectedItems.Count > 0 Then
                For Each _loc_1 In LsvQueue.SelectedItems
                    LsvQueue.Items.Remove(_loc_1)
                Next
            Else
                If MsgBox(TEXT_REMOVE, vbQuestion + vbYesNo, "") = vbYes Then
                    LsvQueue.Items.Clear()
                End If
            End If
        Catch ex As Exception

        Finally
            CountTasks()
        End Try
    End Sub

    Private Sub BtnStorePathBrowse_Click(sender As Object, e As EventArgs) Handles BtnStorePathBrowse.Click
        Try
            If FbdPath.ShowDialog = DialogResult.OK Then
                TxtStorePath.Text = FbdPath.SelectedPath
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkStart_CheckedChanged(sender As Object, e As EventArgs) Handles ChkStart.CheckedChanged
        Try
            If ChkStart.Checked Then
                TmrLauncher.Interval = NumInterval.Value * 1000
                TmrLauncher.Enabled = True
                TmrLauncher_Tick(sender, e)
            Else
                TmrLauncher.Enabled = False
                TmrCountdown.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblStorePath_Click(sender As Object, e As EventArgs) Handles LblStorePath.Click
        Try
            Process.Start("explorer.exe", TxtStorePath.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LsvQueue_DoubleClick(sender As Object, e As EventArgs) Handles LsvQueue.DoubleClick
        Try
            Clipboard.SetText(LsvQueue.SelectedItems(0).SubItems(2).Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LsvQueue_MouseDown(sender As Object, e As MouseEventArgs) Handles LsvQueue.MouseDown
        Try
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                LsvQueue.SelectedItems(0).SubItems(0).Text = StrQueueStatus1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TmrCountdown_Tick(sender As Object, e As EventArgs) Handles TmrCountdown.Tick
        Try
            If NumDelay.Value > 0 Then
                NumDelay.Value -= 1
            End If

            If NumDelay.Value = 0 Then
                TmrCountdown.Enabled = False
                TmrLauncher.Interval = NumInterval.Value * 1000
                TmrLauncher.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TmrLauncher_Tick(sender As Object, e As EventArgs) Handles TmrLauncher.Tick
        Try
            If NumDelay.Value = 0 Then
                For _loc_1 = 0 To LsvQueue.Items.Count - 1
                    If LsvQueue.Items(_loc_1).SubItems(0).Text = StrQueueStatus1 Then
                        StartTask(_loc_1)
                        Exit Sub
                    End If
                Next
                ChkStart.Checked = False
            Else
                TmrLauncher.Enabled = False
                TmrCountdown.Interval = 60 * 1000
                TmrCountdown.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddQueue(URL As String, Optional FileName As String = "")
        Try
            Dim _loc_1 As Integer = LsvQueue.Items.Count
            Dim _loc_2 As ListViewItem = LsvQueue.Items.Add(StrQueueStatus1)
            _loc_2.EnsureVisible()
            Dim _loc_3 As String = TxtTaskName.Text.Replace("\s", Int(_loc_1 + 1 + NumOffset.Value).ToString.PadLeft(2, "0"))
            If Not FileName = "" Then _loc_3 = FileName
            LsvQueue.Items(_loc_1).SubItems.Add(_loc_3)
            LsvQueue.Items(_loc_1).SubItems.Add(URL)
        Catch ex As Exception

        End Try
    End Sub

    Private Function ARGv(Input As String) As String
        Try
            If Input.EndsWith("\") Then
                Input &= "\"
            End If
            Input = Chr(34) & Input.Replace(Chr(34), "\""") & Chr(34)
            Return Input
        Catch ex As Exception
            Return Input
        End Try
    End Function

    Dim TEXT_TASK As String = " Task"
    Dim TEXT_TASKS As String = "s"
    Private Sub CountTasks()
        Try
            Text = LsvQueue.Items.Count & TEXT_TASK
            If LsvQueue.Items.Count > 1 Then Text &= TEXT_TASKS
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Filter(Input As String)
        Try
            Dim _loc_1 As String = My.Computer.FileSystem.ReadAllText(Input)
            Dim _loc_2 As MatchCollection = Regex.Matches(_loc_1, "DESCRIBE (.*?) RTSP\/1.0", RegexOptions.None)
            If _loc_2.Count > 0 Then
                Dim _loc_3 As Match
                For Each _loc_3 In _loc_2
                    AddQueue(_loc_3.Groups(1).Value)
                Next _loc_3
            Else
                If _loc_1.StartsWith("<") Then
                    Dim _loc_5 As String() = _loc_1.Split(vbCrLf)
                    For _loc_6 = 0 To _loc_5.Count - 4
                        If _loc_5(_loc_6).Trim.StartsWith("<") Then
                            If _loc_5(_loc_6 + 3).Trim.StartsWith(">") Then
                                AddQueue(_loc_5(_loc_6 + 1).Trim, _loc_5(_loc_6 + 2).Trim)
                            End If
                        End If
                    Next
                Else
                    For Each _loc_4 In _loc_1.Split(vbCrLf)
                        If _loc_4.Trim.Length > 0 Then AddQueue(_loc_4.Trim)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StartTask(TaskIndex As Integer)
        Try
            LsvQueue.Items(TaskIndex).SubItems(0).Text = StrQueueStatus2

            Dim _loc_1 As String = LsvQueue.Items(TaskIndex).SubItems(1).Text
            If My.Computer.FileSystem.DirectoryExists(TxtStorePath.Text) Then
                _loc_1 = TxtStorePath.Text & "\" & _loc_1
            End If

            Dim _loc_2 As String = "-i " & ARGv(LsvQueue.Items(TaskIndex).SubItems(2).Text) & " -p " & Chr(34) & CboPreset.Text & Chr(34) & " -o " & ARGv(_loc_1) & " -a"
            If NumTimeout.Value > 0 Then _loc_2 &= " -t " & Int(NumTimeout.Value * 60).ToString
            Dim _loc_11 As New Process()
            _loc_11.StartInfo.FileName = Application.ExecutablePath
            _loc_11.StartInfo.Arguments = _loc_2
            _loc_11.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            _loc_11.Start()
        Catch ex As Exception

        End Try
    End Sub

End Class