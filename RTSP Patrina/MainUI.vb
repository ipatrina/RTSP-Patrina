Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime.InteropServices

Public Class MainUI

    Public Shared CONNECTION_BUFFER As Byte() = New Byte() {}
    Public Shared CONNECTION_CLIENT_PORT As String = ""
    Public Shared CONNECTION_CONTENT_BASE As String = ""
    Public Shared CONNECTION_CSEQ As Integer = 0
    Public Shared CONNECTION_ESTABLISHED As Boolean = False
    Public Shared CONNECTION_INTERLEAVED As String = ""
    Public Shared CONNECTION_RTP As Boolean = False
    Public Shared CONNECTION_SERVER_IP As String = ""
    Public Shared CONNECTION_SERVER_PORT As String = ""
    Public Shared CONNECTION_SESSION As String = ""
    Public Shared DATA_INTERLEAVED_LENGTH As Integer = 0
    Public Shared DEFINITION_LIST As New NameValueCollection
    Public Shared LABEL_STATE_START As String = "Start"
    Public Shared LABEL_STATE_STOP As String = "Stop"
    Public Shared HANDLE_DAEMON_ACTIVE As Boolean = False
    Public Shared HANDLE_DAEMON_KEEPALIVE As Integer = -1
    Public Shared HANDLE_DAEMON_KEEPALIVE_ROUND As Long = 0
    Public Shared HANDLE_OVERRIDE As Integer = 0
    Public Shared HANDLE_PRESET As String = ""
    Public Shared HANDLE_RESEND As Boolean = False
    Public Shared HANDLE_TEARDOWN As Boolean = False
    Public Shared MESSAGE_TABLE As New List(Of String)
    Public Shared RECORDER_FILESTREAM As IO.FileStream = Nothing
    Public Shared RECORDER_INITIALIZED As Boolean = False
    Public Shared RECORDER_UDP_CONNECTION As UdpClient = Nothing
    Public Shared RECORDER_UDP_INITIALIZED As Boolean = False
    Public Shared RECORDER_UDP_IPENDPOINT As IPEndPoint = Nothing
    Public Shared RECORDER_UDP_PORT_ASSIGNED As Boolean = False
    Public Shared RECORDER_WRITER As IO.BinaryWriter = Nothing
    Public Shared RTSP_CONNECTION As TCPClient = Nothing
    Public Shared RTSP_PASSWORD As String = ""
    Public Shared RTSP_REDIRECT_URL As String = ""
    Public Shared RTSP_STATE_PLAY As Boolean = False
    Public Shared RTSP_URL As String = ""
    Public Shared RTSP_USERNAME As String = ""
    Public Shared USER_AUTOSTART As Boolean = False
    Public Shared USER_CLIPBOARD As String = ""
    Public Shared USER_LANGUAGE_ID As Integer = 0
    Public Shared USER_TASKNAME As String = ""
    Public Shared USER_TTL As Long = 0
    Public Shared USER_URL As String = ""

    <DllImport("kernel32.dll")>
    Private Shared Function GetSystemDefaultLangID() As UInt16
    End Function

    Public Shared ReadOnly Property SystemDefaultLangID() As UInt16
        Get
            Return GetSystemDefaultLangID()
        End Get
    End Property

    Private Sub MainUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            USER_LANGUAGE_ID = Int(SystemDefaultLangID())
            If USER_LANGUAGE_ID = 2052 Or USER_LANGUAGE_ID = 1028 Or USER_LANGUAGE_ID = 3076 Then
                LABEL_STATE_START = "开始"
                LABEL_STATE_STOP = "停止"

                LblTitle.Text = "很萌录制器"
                TsiConsole.Text = "控制台"
                TsiLauncher.Text = "任务启动器"
                TsiAbout.Text = "关于"
                LblPreset.Text = "预设:"
                CboPreset.Text = "(无可用预设)"
                LblPresetEdit.Text = "编辑"
                LblURL.Text = "RTSP链接:"
                ChkOverride.Text = "手动发送"
                LblTaskName.Text = "任务名称:"
                BtnHandle.Text = LABEL_STATE_START
                LblRecording.Text = "正在录制"

                TEXT_ERROR = "任务失败"
                TEXT_ERROR_PROMPT = "任务初始化失败。" & vbCrLf & "请打开控制台查看详细信息。"
                TEXT_LAUNCHER = "当存在活动连接时无法打开任务启动器。"
                TEXT_QUIT = "退出"
                TEXT_QUIT_PROMPT = "任务正在进行。您确定结束任务并退出程序吗？"

                ChkOverride.Left = NumOverride.Left - ChkOverride.Width - 4
            End If

            LblSubHeading.Left = LblTitle.Right + 4
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

        Try
            Dim _loc_1 As String() = Environment.GetCommandLineArgs()
            If _loc_1.Count > 1 Then
                DEFINITION_LIST.Clear()
                Dim _loc_2 As Integer = 1
                While _loc_2 < _loc_1.Count
                    If _loc_1(_loc_2).StartsWith("--") Then
                        DEFINITION_LIST.Add(_loc_1(_loc_2).Substring(2), _loc_1(_loc_2 + 1))
                        _loc_2 += 2
                    Else
                        If _loc_1(_loc_2).ToLower.StartsWith("-i") Then
                            TxtURL.Text = _loc_1(_loc_2 + 1)
                            _loc_2 += 2
                        ElseIf _loc_1(_loc_2).ToLower.StartsWith("-p") Then
                            CboPreset.Text = _loc_1(_loc_2 + 1)
                            _loc_2 += 2
                        ElseIf _loc_1(_loc_2).ToLower.StartsWith("-o") Then
                            TxtTaskName.Text = _loc_1(_loc_2 + 1)
                            _loc_2 += 2
                        ElseIf _loc_1(_loc_2).ToLower.StartsWith("-a") Then
                            USER_AUTOSTART = True
                            _loc_2 += 1
                        ElseIf _loc_1(_loc_2).ToLower.StartsWith("-t") Then
                            USER_TTL = Time() + Int(_loc_1(_loc_2 + 1))
                            _loc_2 += 2
                        Else
                            _loc_2 += 1
                        End If
                    End If
                End While
            End If
        Catch ex As Exception

        End Try

        Try
            AcceptButton = BtnHandle
            If USER_AUTOSTART Then
                WORKER_START()
            Else
                If TxtURL.Text = "" Then
                    TmrClipboard.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim TEXT_QUIT As String = "Quit"
    Dim TEXT_QUIT_PROMPT As String = "The task is in progress. Are you sure to end the task and exit the program?"
    Private Sub MainUI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            e.Cancel = 1
            If RECORDER_INITIALIZED Then
                If MsgBox(TEXT_QUIT_PROMPT, vbQuestion + vbYesNo, TEXT_QUIT) = vbNo Then
                    Exit Sub
                End If
            End If
            If RTSP_STATE_PLAY Then
                CONNECTION_CLOSE(True)
            Else
                Dispose()
                End
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnHandle_Click(sender As Object, e As EventArgs) Handles BtnHandle.Click
        Try
            Console.TxtResponse.Clear()
        Catch ex As Exception

        End Try

        Try
            WORKER_START()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click
        Try
            CmsMenu.Show(System.Windows.Forms.Control.MousePosition)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNewTask_Click(sender As Object, e As EventArgs) Handles BtnNewTask.Click
        Try
            Process.Start(Application.ExecutablePath)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPathBrowse_Click(sender As Object, e As EventArgs) Handles BtnPathBrowse.Click
        Try
            If SfdTaskName.ShowDialog = DialogResult.OK Then
                TxtTaskName.Text = SfdTaskName.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkOverride_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOverride.CheckedChanged
        Try
            If ChkOverride.Checked Then
                BtnHandle.Text = LABEL_STATE_START
            Else
                If RTSP_STATE_PLAY Then
                    BtnHandle.Text = LABEL_STATE_STOP
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblPresetEdit_Click(sender As Object, e As EventArgs) Handles LblPresetEdit.Click
        Try
            Dim _loc_1 As String = Application.StartupPath & "\" & CboPreset.Text & ".cfg"
            If My.Computer.FileSystem.FileExists(_loc_1) Then
                Process.Start(_loc_1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblTaskName_Click(sender As Object, e As EventArgs) Handles LblTaskName.Click
        Try
            Dim _loc_1 As String = Application.StartupPath
            If Not LblTaskName.Text = "" Then
                Try
                    _loc_1 = Path.GetDirectoryName(TxtTaskName.Text)
                Catch ex As Exception

                End Try
            End If
            Process.Start("explorer.exe", _loc_1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PicBadge_Click(sender As Object, e As EventArgs) Handles PicBadge.Click
        Try
            TsiAbout_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PicInfo_DoubleClick(sender As Object, e As EventArgs) Handles PicInfo.DoubleClick
        Try
            If IsFFmpegExist() And My.Computer.FileSystem.FileExists(USER_TASKNAME) Then
                Dim _loc_1 As New Process()
                _loc_1.StartInfo.FileName = "cmd.exe"
                _loc_1.StartInfo.Arguments = "/k ffmpeg.exe -i " & Chr(34) & USER_TASKNAME & Chr(34)
                _loc_1.StartInfo.UseShellExecute = False
                _loc_1.Start()
            Else
                TsiConsole_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PicPlay_DoubleClick(sender As Object, e As EventArgs) Handles PicPlay.DoubleClick
        Try
            If My.Computer.FileSystem.FileExists(USER_TASKNAME) Then
                Process.Start(USER_TASKNAME)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TmrClipboard_Tick(sender As Object, e As EventArgs) Handles TmrClipboard.Tick
        Try
            If Clipboard.GetText().StartsWith("rtsp://") Then
                If TxtURL.Text = "" Then
                    TxtURL.Text = Clipboard.GetText()
                End If
                TmrClipboard.Enabled = False
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsiAbout_Click(sender As Object, e As EventArgs) Handles TsiAbout.Click
        Try
            Dim VersionStrings As String() = Application.ProductVersion.ToString.Split(".")
            MsgBox("RTSP Patrina" & vbCrLf & vbCrLf & "Version: " & VersionStrings(0) & "." & VersionStrings(1) & "." & VersionStrings(2) & vbCrLf & "Date: 20" & VersionStrings(3).Substring(0, 2) & "." & VersionStrings(3).Substring(2, 2) & vbCrLf & vbCrLf & "Copyright © 2017-2022." & vbCrLf & "All rights reserved.", vbInformation, TsiAbout.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsiConsole_Click(sender As Object, e As EventArgs) Handles TsiConsole.Click
        Try
            Console.Show()
        Catch ex As Exception

        End Try
    End Sub

    Dim TEXT_LAUNCHER As String = "The task launcher cannot be opened while there is an active connection."
    Private Sub TsiLauncher_Click(sender As Object, e As EventArgs) Handles TsiLauncher.Click
        Try
            If RTSP_STATE_PLAY Then
                MsgBox(TEXT_LAUNCHER, vbExclamation, TsiLauncher.Text)
            Else
                TmrClipboard.Enabled = False
                Launcher.Show()
                Hide()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BgwCoreWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgwCoreWorker.DoWork
        Try
            InvokeControl(BtnHandle, Sub(x) x.Enabled = False)
            If MESSAGE_TABLE.Count <= 0 Then LOAD_PRESET(HANDLE_PRESET)
            If MESSAGE_TABLE.Count <= 0 Then Exit Sub

            Dim HANDLE_INDEX As Integer = 0
            If HANDLE_OVERRIDE > 0 Then
                If HANDLE_OVERRIDE <= MESSAGE_TABLE.Count Then
                    HANDLE_INDEX = HANDLE_OVERRIDE - 1
                Else
                    Exit Sub
                End If
            End If

            While HANDLE_INDEX < MESSAGE_TABLE.Count
                CONNECTION_CSEQ += 1
                Dim MESSAGE_STRING As String = DEFINITION_HANDLE(MESSAGE_TABLE(HANDLE_INDEX).Trim)
                Dim MESSAGE_FIRSTLINE As String = MESSAGE_STRING.Split(vbCrLf)(0)
                Dim MESSAGE_METHOD As String = ""
                Dim MESSAGE_PATH As String = ""
                Dim _loc_1 As Integer = MESSAGE_FIRSTLINE.IndexOf(" ")
                If _loc_1 > 0 Then
                    MESSAGE_METHOD = MESSAGE_FIRSTLINE.Substring(0, _loc_1)
                    Dim _loc_2 As Integer = MESSAGE_FIRSTLINE.IndexOf(" ", _loc_1 + 1)
                    If _loc_2 > 0 Then
                        MESSAGE_PATH = MESSAGE_FIRSTLINE.Substring(_loc_1 + 1, _loc_2 - _loc_1 - 1)
                    End If
                End If

                If CONNECTION_ESTABLISHED = False Then
                    Dim RTSP_SERVER_IP As String = ""
                    Dim RTSP_SERVER_PORT As String = "554"
                    RTSP_USERNAME = ""
                    RTSP_PASSWORD = ""
                    If Not RTSP_REDIRECT_URL = "" Then MESSAGE_PATH = RTSP_REDIRECT_URL
                    Dim _loc_3 As Integer = MESSAGE_PATH.IndexOf("://")
                    Dim _loc_4 As Integer = MESSAGE_PATH.IndexOf("/", _loc_3 + 3)
                    If _loc_4 = -1 Then _loc_4 = MESSAGE_PATH.Length
                    Dim _loc_5 As String = MESSAGE_PATH.Substring(_loc_3 + 3, _loc_4 - _loc_3 - 3)
                    Dim _loc_6 As String() = _loc_5.Split("@")
                    Dim RTSP_HOST As String = _loc_5
                    If _loc_6.Count > 1 Then
                        RTSP_HOST = _loc_6(1)
                        _loc_6 = _loc_6(0).Split(":")
                        If RTSP_REDIRECT_URL = "" Then RTSP_USERNAME = _loc_6(0)
                        If _loc_6.Count > 1 And RTSP_REDIRECT_URL = "" Then RTSP_PASSWORD = _loc_6(1)
                    End If
                    _loc_6 = RTSP_HOST.Split(":")
                    RTSP_SERVER_IP = ParseIP(_loc_6(0))
                    If _loc_6.Count > 1 Then RTSP_SERVER_PORT = Int(_loc_6(1))
                    RTSP_CONNECTION = New TCPClient
                    RTSP_CONNECTION.Connect(RTSP_SERVER_IP, RTSP_SERVER_PORT)
                    RTSP_URL = MESSAGE_PATH.Split("?")(0)
                    CONNECTION_ESTABLISHED = True
                End If

                Dim DO_NOT_SEND As Boolean = False

                If MESSAGE_METHOD.ToUpper = "TEARDOWN" Then
                    If HANDLE_TEARDOWN Or HANDLE_OVERRIDE = HANDLE_INDEX + 1 Then
                        HANDLE_OVERRIDE = HANDLE_INDEX + 1
                        HANDLE_TEARDOWN = True
                    Else
                        DO_NOT_SEND = True
                    End If
                Else
                    If HANDLE_TEARDOWN Then DO_NOT_SEND = True
                End If

                If DO_NOT_SEND Then
                    CONNECTION_CSEQ -= 1
                Else
                    If MESSAGE_METHOD.ToUpper = "PLAY" Then
                        RTSP_STATE_PLAY = True
                        If HANDLE_OVERRIDE <= 0 Then
                            Dim ProgressDaemon As New Thread(AddressOf PROGRESS_DAEMON)
                            ProgressDaemon.Start()
                        End If
                    ElseIf MESSAGE_METHOD.ToUpper = "GET_PARAMETER" Then
                        HANDLE_DAEMON_KEEPALIVE = HANDLE_INDEX
                    End If

                    CONSOLE_PRINT(MESSAGE_STRING & vbCrLf & vbCrLf, False)
                    RTSP_CONNECTION.SendString(MESSAGE_STRING)
                    If HANDLE_DAEMON_ACTIVE = False Then
                        If Not HANDLE_RECEIVE() Then
                            Exit While
                        End If
                    End If
                End If

                If RECORDER_UDP_INITIALIZED And Not CONNECTION_CLIENT_PORT = "" Then
                    RECORDER_UDP_SETUP(CONNECTION_CLIENT_PORT, CONNECTION_SERVER_IP)
                End If

                If RTSP_STATE_PLAY And HANDLE_DAEMON_ACTIVE = False Then
                    HANDLE_DAEMON_ADDROUND()
                    Dim HandleDaemon As New Thread(AddressOf HANDLE_DAEMON)
                    HandleDaemon.Start()
                End If

                If HANDLE_INDEX = HANDLE_OVERRIDE - 1 Then
                    HANDLE_OVERRIDE = 0
                    Exit While
                Else
                    If HANDLE_RESEND Then
                        HANDLE_RESEND = False
                    Else
                        HANDLE_INDEX += 1
                    End If
                End If
            End While

            Dim _loc_11 As Integer = Time() + 10
            While HANDLE_TEARDOWN
                Thread.Sleep(50)
                If Time() > _loc_11 Then
                    CONNECTION_CLOSE()
                End If
            End While
        Catch ex As Exception

        End Try
    End Sub

    Dim TEXT_ERROR As String = "Task Failed"
    Dim TEXT_ERROR_PROMPT As String = "A problem occurred during task initialization." & vbCrLf & "Please open the console to view details."
    Private Sub BgwCoreWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwCoreWorker.RunWorkerCompleted
        Try
            If RTSP_STATE_PLAY Then
                InvokeControl(BtnHandle, Sub(x) x.Text = LABEL_STATE_STOP)
                InvokeControl(ChkOverride, Sub(x) x.Enabled = True)
                InvokeControl(ChkOverride, Sub(x) x.Checked = False)
            Else
                InvokeControl(BtnHandle, Sub(x) x.Text = LABEL_STATE_START)
                InvokeControl(ChkOverride, Sub(x) x.Enabled = False)
                If MESSAGE_TABLE.Count > 0 Then MsgBox(TEXT_ERROR_PROMPT, vbExclamation, TEXT_ERROR)
                CONNECTION_RESET()
            End If
        Catch ex As Exception

        Finally
            InvokeControl(BtnHandle, Sub(x) x.Enabled = True)
        End Try
    End Sub

    Private Sub CONNECTION_CLOSE(Optional Termination As Boolean = False)
        Try
            RECORDER_WRITER.Flush()
            RECORDER_WRITER.Close()
        Catch ex As Exception

        Finally
            InvokeControl(LblRecording, Sub(x) x.Visible = False)
        End Try

        Try
            RTSP_CONNECTION.Close()
            RECORDER_UDP_CONNECTION.Close()
        Catch ex As Exception

        End Try

        Try
            CONNECTION_RESET()
        Catch ex As Exception

        Finally
            If Termination Then
                Dispose()
                End
            End If
        End Try
    End Sub

    Private Delegate Sub CONSOLE_PRINT_DELEGATE(Data As String, Clear As Boolean)

    Private Sub CONSOLE_PRINT(Data As String, Clear As Boolean)
        Try
            If InvokeRequired Then
                Invoke(New CONSOLE_PRINT_DELEGATE(AddressOf CONSOLE_PRINT), New Object() {Data, Clear})
            Else
                If Clear Then Console.TxtResponse.Clear()
                Console.TxtResponse.AppendText(Data)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CONNECTION_RESET()
        Try
            CONNECTION_BUFFER = New Byte() {}
            CONNECTION_CLIENT_PORT = ""
            CONNECTION_CONTENT_BASE = ""
            CONNECTION_CSEQ = 0
            CONNECTION_ESTABLISHED = False
            CONNECTION_INTERLEAVED = ""
            CONNECTION_RTP = False
            CONNECTION_SERVER_IP = ""
            CONNECTION_SERVER_PORT = ""
            CONNECTION_SESSION = ""
            DATA_INTERLEAVED_LENGTH = 0
            DEFINITION_LIST.Clear()
            HANDLE_OVERRIDE = 0
            HANDLE_PRESET = ""
            HANDLE_RESEND = False
            HANDLE_TEARDOWN = False
            HANDLE_DAEMON_ACTIVE = False
            HANDLE_DAEMON_KEEPALIVE = -1
            HANDLE_DAEMON_KEEPALIVE_ROUND = 0
            MESSAGE_TABLE.Clear()
            RECORDER_FILESTREAM = Nothing
            RECORDER_INITIALIZED = False
            RECORDER_UDP_CONNECTION = Nothing
            RECORDER_UDP_INITIALIZED = False
            RECORDER_UDP_IPENDPOINT = Nothing
            RECORDER_UDP_PORT_ASSIGNED = False
            RECORDER_WRITER = Nothing
            RTSP_CONNECTION = Nothing
            RTSP_PASSWORD = ""
            RTSP_REDIRECT_URL = ""
            RTSP_STATE_PLAY = False
            RTSP_URL = ""
            RTSP_USERNAME = ""
            USER_TASKNAME = ""
            USER_URL = ""
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DEBUG_LOG(Content As String)
        Try
            Dim _loc_1 As New System.IO.StreamWriter(Application.StartupPath & "\log.txt", True, Encoding.Default)
            _loc_1.WriteLine("[" & Now & "] [" & USER_TASKNAME & "] " & Content & vbCrLf)
            _loc_1.Close()
            _loc_1.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DEFINITION_ADD(DefinitionName As String, DefinitionValue As String)
        Try
            If String.IsNullOrEmpty(DEFINITION_LIST(DefinitionName)) Then
                DEFINITION_LIST.Add(DefinitionName, DefinitionValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function DEFINITION_HANDLE(SourceString As String)
        Try
            For _loc_1 = 0 To DEFINITION_LIST.Count - 1
                SourceString = SourceString.Replace("{" & DEFINITION_LIST.Keys(_loc_1) & "}", DEFINITION_LIST(_loc_1))
            Next
            If SourceString.Contains("[UDP]") And IsNothing(RECORDER_UDP_IPENDPOINT) Then SourceString = SourceString.Replace("[UDP]", RECORDER_GET_UDPCLIENT())
            SourceString = SourceString.Replace("[Url]", USER_URL).Replace("[CSeq]", CONNECTION_CSEQ).Replace("[Session]", CONNECTION_SESSION).Replace("[Path]", RTSP_URL).Replace("[Content-Base]", CONNECTION_CONTENT_BASE)
            If Not USER_URL = "" And Not RTSP_REDIRECT_URL = "" Then SourceString = SourceString.Replace(USER_URL, RTSP_REDIRECT_URL)
            Return SourceString
        Catch ex As Exception
            Return SourceString
        End Try
    End Function

    Private Sub HANDLE_DAEMON()
        Try
            If HANDLE_DAEMON_ACTIVE Then Exit Sub
            HANDLE_DAEMON_ACTIVE = True
            While CONNECTION_ESTABLISHED
                If HANDLE_DAEMON_KEEPALIVE > -1 And Time() > HANDLE_DAEMON_KEEPALIVE_ROUND Then
                    HANDLE_DAEMON_ADDROUND()
                    Try
                        CONNECTION_CSEQ += 1
                        Dim MESSAGE_STRING As String = DEFINITION_HANDLE(MESSAGE_TABLE(HANDLE_DAEMON_KEEPALIVE).Trim)
                        CONSOLE_PRINT(MESSAGE_STRING & vbCrLf & vbCrLf, True)
                        RTSP_CONNECTION.SendString(MESSAGE_STRING)
                    Catch ex As Exception

                    End Try
                End If
                Thread.Sleep(50)
                HANDLE_RECEIVE()
            End While
        Catch ex As Exception

        Finally
            HANDLE_DAEMON_ACTIVE = False
        End Try
    End Sub

    Private Sub HANDLE_DAEMON_ADDROUND()
        Try
            HANDLE_DAEMON_KEEPALIVE_ROUND = Time() + 10
        Catch ex As Exception

        End Try
    End Sub

    Private Function HANDLE_RECEIVE() As Boolean
        Try
            For _loc_1 = 0 To 100
                If RTSP_CONNECTION.Available > 0 Then
                    Exit For
                End If
                Thread.Sleep(50)
            Next

            If RTSP_CONNECTION.Available <= 0 Then
                Return False
            End If

            Dim _loc_2 As Byte() = RTSP_CONNECTION.Receive()

            If CONNECTION_BUFFER.Length > 0 Then
                Dim _loc_3 As Byte() = New Byte(CONNECTION_BUFFER.Length + _loc_2.Length - 1) {}
                Array.Copy(CONNECTION_BUFFER, 0, _loc_3, 0, CONNECTION_BUFFER.Length)
                Array.Copy(_loc_2, 0, _loc_3, CONNECTION_BUFFER.Length, _loc_2.Length)
                _loc_2 = _loc_3
                CONNECTION_BUFFER = New Byte() {}
            End If

            Dim DATA_INTERLEAVED As Boolean = False
            If _loc_2(0) = &H24 Then
                DATA_INTERLEAVED = True
                Dim _loc_10 As Integer = 0
                While _loc_10 < _loc_2.Length
                    If Not _loc_2(_loc_10) = &H24 Then
                        DATA_INTERLEAVED = False
                        Exit While
                    End If
                    If (_loc_2.Length - _loc_10) >= 4 Then
                        Dim _loc_4 As Integer = Int(_loc_2(_loc_10 + 2)) * 256 + Int(_loc_2(_loc_10 + 3))
                        If (_loc_2.Length - _loc_10) >= _loc_4 + 4 Then
                            DATA_INTERLEAVED_LENGTH = 0
                            Dim DATA_CHANNEL As String() = CONNECTION_INTERLEAVED.Split("-")
                            Dim DATA_PAYLOAD As Byte() = New Byte(_loc_4 - 1) {}
                            Array.Copy(_loc_2, _loc_10 + 4, DATA_PAYLOAD, 0, _loc_4)
                            If Int(_loc_2(_loc_10 + 1)) = Int(DATA_CHANNEL(0)) Then
                                RECORDER_WRITE(DATA_PAYLOAD)
                            ElseIf DATA_CHANNEL.Count > 1 Then
                                If Int(_loc_2(1)) = Int(DATA_CHANNEL(1)) Then

                                End If
                            End If
                            _loc_10 += _loc_4 + 4
                        Else
                            DATA_INTERLEAVED_LENGTH = _loc_4
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                End While
                If _loc_10 < _loc_2.Length Then
                    CONNECTION_BUFFER = New Byte(_loc_2.Length - _loc_10 - 1) {}
                    Array.Copy(_loc_2, _loc_10, CONNECTION_BUFFER, 0, _loc_2.Length - _loc_10)
                    If DATA_INTERLEAVED = False Then
                        _loc_2 = CONNECTION_BUFFER
                        CONNECTION_BUFFER = New Byte() {}
                    End If
                End If
            ElseIf DATA_INTERLEAVED_LENGTH > 0 And DATA_INTERLEAVED_LENGTH < _loc_2.Length Then
                DATA_INTERLEAVED_LENGTH = 0
                Return True
            End If

            If DATA_INTERLEAVED = False Then
                Dim _loc_6 As Integer = 0

                If RTSP_STATE_PLAY And HANDLE_TEARDOWN = False Then
                    For _loc_7 = _loc_2.Length - 1 To 3 Step -1
                        If _loc_2(_loc_7 - 3) = &HD And _loc_2(_loc_7 - 2) = &HA And _loc_2(_loc_7 - 1) = &HD And _loc_2(_loc_7) = &HA Then
                            _loc_6 = _loc_7 + 1
                            Exit For
                        End If
                    Next
                Else
                    _loc_6 = _loc_2.Length
                End If

                If _loc_6 = 0 Then
                    Dim _loc_5 As Boolean = False
                    For _loc_12 = 0 To _loc_2.Length - 2
                        If _loc_2(_loc_12) = &HD And _loc_2(_loc_12 + 1) = &HA Then
                            _loc_5 = True
                        End If
                    Next
                    If _loc_5 = False Then Return False
                End If

                If _loc_6 < _loc_2.Length Then
                    CONNECTION_BUFFER = New Byte(_loc_2.Length - _loc_6 - 1) {}
                    Array.Copy(_loc_2, _loc_6, CONNECTION_BUFFER, 0, _loc_2.Length - _loc_6)
                End If

                Dim _loc_8 As Byte() = New Byte(_loc_6 - 1) {}
                Array.Copy(_loc_2, 0, _loc_8, 0, _loc_6)
                Dim RTSP_RESPONSE As String = Encoding.UTF8.GetString(_loc_8)
                CONSOLE_PRINT(RTSP_RESPONSE & vbCrLf, False)

                Dim _loc_9 As Boolean = False
                If RTSP_RESPONSE.Split(vbCrLf)(0).ToLower.Replace(" ", "").Contains("200ok") Then
                    _loc_9 = True
                ElseIf RTSP_RESPONSE.Split(vbCrLf)(0).ToLower.Replace(" ", "").Contains("454sessionnotfound") Then
                    If RTSP_STATE_PLAY Then WORKER_START()
                    Return False
                ElseIf RTSP_RESPONSE.ToUpper.StartsWith("ANNOUNCE") Then
                    Dim ANNOUNCE_RESPONSE As String = "RTSP/1.0 501 Not Implemented"
                    RTSP_CONNECTION.SendString(ANNOUNCE_RESPONSE)
                    If Not DEFINITION_LIST("[Stop]") = "" And RTSP_RESPONSE.Contains(DEFINITION_LIST("[Stop]")) Then
                        If Not CONNECTION_CLIENT_PORT = "" Then Thread.Sleep(5000)
                        If USER_AUTOSTART Then
                            CONNECTION_CLOSE(True)
                        Else
                            If RTSP_STATE_PLAY Then WORKER_START()
                        End If
                        Return False
                    End If
                End If
                For Each _loc_11 In RTSP_RESPONSE.Split(vbCrLf)
                    If _loc_11.ToLower.Contains("location:") Then
                        RTSP_REDIRECT_URL = Regex.Match(_loc_11, "location:(.*)?", RegexOptions.IgnoreCase).Groups(1).Value.Trim()
                        If RTSP_REDIRECT_URL.ToLower.Contains("rtsp://") Then
                            RTSP_URL = RTSP_REDIRECT_URL.Split("?")(0)
                            HANDLE_RESEND = True
                            CONNECTION_ESTABLISHED = False
                            Return True
                        Else
                            RTSP_REDIRECT_URL = ""
                        End If
                    End If
                    If _loc_9 Then
                        If _loc_11.ToLower.Contains("session:") Then
                            CONNECTION_SESSION = _loc_11.Split(":")(1).Split(";")(0).Replace(" ", "")
                        End If
                        If _loc_11.ToLower.Contains("content-base:") Then
                            CONNECTION_CONTENT_BASE = _loc_11.Split(" ")(1)
                        End If
                        If _loc_11.ToLower.Contains("client_port=") Then
                            Dim _loc_13 As String = Regex.Replace(Regex.Match(_loc_11.ToLower, "client_port=([0-9]*)", RegexOptions.IgnoreCase).Value, "\D", "")
                            If Not _loc_13 = "" Then
                                CONNECTION_CLIENT_PORT = _loc_13
                                If _loc_11.ToLower.Contains("udp") Then RECORDER_UDP_INITIALIZED = True
                            End If
                        End If
                        If _loc_11.ToLower.Contains("server_port=") Then
                            Dim _loc_14 As String = Regex.Replace(Regex.Match(_loc_11.ToLower, "server_port=([0-9]*)", RegexOptions.IgnoreCase).Value, "\D", "")
                            If Not _loc_14 = "" Then CONNECTION_SERVER_PORT = _loc_14
                        End If
                        If _loc_11.ToLower.Contains("source=") Then
                            Dim _loc_15 As String = Regex.Match(_loc_11.ToLower, "source=([0-9a-f.:]*)", RegexOptions.IgnoreCase).Groups(1).Value.Trim()
                            If Not _loc_15 = "" Then
                                CONNECTION_SERVER_IP = ParseIP(_loc_15)
                            End If
                        End If
                        If _loc_11.ToLower.Contains("transport:") Then
                            If _loc_11.ToLower.Contains("interleaved") Then
                                Dim _loc_16 As String = Regex.Match(_loc_11.ToLower, "interleaved=([0-9\-]*)", RegexOptions.IgnoreCase).Groups(1).Value.Trim()
                                CONNECTION_INTERLEAVED = _loc_16
                            End If
                            If _loc_11.ToLower.Contains("rtp") Then CONNECTION_RTP = True
                        End If
                    End If
                Next
                If _loc_9 = False Then Return False

                If HANDLE_TEARDOWN Then
                    CONNECTION_CLOSE()
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub LOAD_PRESET(PresetName As String)
        Try
            Dim _loc_1 As String = Application.StartupPath & "\" & PresetName & ".cfg"
            If My.Computer.FileSystem.FileExists(_loc_1) Then
                Dim _loc_2 As String = My.Computer.FileSystem.ReadAllText(_loc_1)
                Dim _loc_3 As Integer = 0
                While _loc_3 < _loc_2.Length
                    Dim _loc_4 As Integer = _loc_2.IndexOf(vbCrLf & vbCrLf, _loc_3)
                    If _loc_4 = -1 Then _loc_4 = _loc_2.Length
                    Dim _loc_5 As String = _loc_2.Substring(_loc_3, _loc_4 - _loc_3).Trim
                    _loc_3 = _loc_4 + 4
                    If _loc_5.Length > 0 Then
                        If _loc_5.Replace(" ", "").ToLower.StartsWith("#define") Then
                            For Each Definition In _loc_5.Split(vbCrLf)
                                Dim _loc_6 As Integer = Definition.ToLower.IndexOf("define ")
                                If _loc_6 > 0 Then
                                    Dim _loc_7 As Integer = Definition.IndexOf(" ", _loc_6 + 7)
                                    If _loc_7 > -1 Then DEFINITION_ADD(Definition.Substring(_loc_6 + 7, _loc_7 - _loc_6 - 7).Trim, Definition.Substring(_loc_7 + 1).Trim)
                                End If
                            Next
                        Else
                            MESSAGE_TABLE.Add(_loc_5)
                        End If
                    End If
                End While
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PROGRESS_DAEMON()
        Try
            InvokeControl(LblProgress, Sub(x) x.Visible = True)
            Dim _loc_1 As Long = Time()
            Dim _loc_2 As Long = 0
            While RTSP_STATE_PLAY
                Dim _loc_3 As Integer = Time()
                If Not _loc_2 = _loc_3 Then
                    _loc_2 = _loc_3
                    Dim _loc_4 As Integer = _loc_2 - _loc_1
                    InvokeControl(LblProgress, Sub(x) x.Text = Math.Floor(_loc_4 / 3600).ToString.PadLeft(2, "0") & ":" & Math.Floor((_loc_4 Mod 3600) / 60).ToString.PadLeft(2, "0") & ":" & Math.Floor((_loc_4 Mod 3600) Mod 60).ToString.PadLeft(2, "0"))
                End If
                If USER_TTL > 0 And _loc_3 > USER_TTL Then
                    CONNECTION_CLOSE(True)
                    Exit Sub
                End If
                Thread.Sleep(50)
            End While
        Catch ex As Exception

        Finally
            InvokeControl(LblProgress, Sub(x) x.Visible = False)
        End Try
    End Sub

    Private Function RECORDER_GET_UDPCLIENT() As String
        Try
            Randomize()
            Dim _loc_1 As Integer = 10000
            Dim _loc_2 As Integer = 59999
            Dim _loc_3 As String = DEFINITION_LIST("[UDP]")
            If Not _loc_3 = "" Then
                _loc_1 = Int(_loc_3.Split("-")(0))
                _loc_2 = Int(_loc_3.Split("-")(1))
            End If
            Dim _loc_4 As Integer = 60000
            Dim _loc_5 As Integer = True
            While _loc_5
                _loc_4 = Int(New Random().Next(_loc_1, _loc_2))
                If _loc_4 Mod 2 = 1 Then _loc_4 -= 1
                _loc_5 = RECORDER_UDP_INUSE(_loc_4)
            End While
            RECORDER_UDP_PORT_ASSIGNED = True
            Return Int(_loc_4) & "-" & Int(_loc_4 + 1)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function RECORDER_UDP_INUSE(ClientPort As Integer) As Boolean
        Try
            For Each _loc_1 As IPEndPoint In IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners()
                If _loc_1.Port = ClientPort Then Return True
            Next _loc_1
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub RECORDER_UDP_SEND(ServerIP As String, DestPort As String, Message As Byte())
        Try
            If Not ServerIP = "" And Not DestPort = "" And Message.Length > 0 Then
                RECORDER_UDP_CONNECTION.Send(Message, Message.Length, New IPEndPoint(IPAddress.Parse(ServerIP), Int(DestPort.Split("-")(0))))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RECORDER_UDP_SETUP(ClientPort As String, SourceIP As String)
        Try
            RECORDER_UDP_INITIALIZED = False
            Dim _loc_1 As Integer = Int(ClientPort.Split("-")(0))
            RECORDER_UDP_CONNECTION = New UdpClient(_loc_1)
            RECORDER_UDP_CONNECTION.Client.ReceiveTimeout = -1
            RECORDER_UDP_CONNECTION.Client.ReceiveBufferSize = 134217728
            RECORDER_UDP_CONNECTION.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, 134217728)
            RECORDER_UDP_CONNECTION.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
            If SourceIP = "" Then
                RECORDER_UDP_IPENDPOINT = New IPEndPoint(IPAddress.Any, 0)
            Else
                RECORDER_UDP_IPENDPOINT = New IPEndPoint(IPAddress.Parse(SourceIP), 0)
            End If
            If RECORDER_UDP_PORT_ASSIGNED Then
                RECORDER_UDP_SEND(CONNECTION_SERVER_IP, CONNECTION_SERVER_PORT, New Byte() {&H80, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0})
                RECORDER_UDP_SEND(CONNECTION_SERVER_IP, CONNECTION_SERVER_PORT, New Byte() {&H80, &HC9, &H0, &H1, &H0, &H0, &H0, &H0})
            End If
            Dim UDPClientDaemon As New Thread(AddressOf RECORDER_UDP_RECEIVE)
            UDPClientDaemon.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RECORDER_UDP_RECEIVE()
        Try
            Dim _loc_1 As Byte() = New Byte() {}
            While CONNECTION_ESTABLISHED
                Try
                    _loc_1 = RECORDER_UDP_CONNECTION.Receive(RECORDER_UDP_IPENDPOINT)
                    If _loc_1.Length > 0 Then
                        RECORDER_WRITE(_loc_1)
                    End If
                Catch ex As Exception

                End Try
            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RECORDER_WRITE(Data As Byte())
        Try
            If CONNECTION_RTP Then
                Dim RTPHeaderBit As New BitArray(New Byte() {Data(0)})
                Dim _loc_1 As Integer = 12 + (RTPHeaderBit(0) + RTPHeaderBit(1) * 2 + RTPHeaderBit(2) * 4 + RTPHeaderBit(3) * 8) * 4
                If RTPHeaderBit(4) Then
                    _loc_1 += 4
                    _loc_1 += Int(Data(_loc_1 - 2)) * 256 + Int(Data(_loc_1 - 1)) * 4
                End If
                Dim _loc_2 As Byte() = New Byte(Data.Length - _loc_1 - 1) {}
                Array.Copy(Data, _loc_1, _loc_2, 0, Data.Length - _loc_1)
                Data = _loc_2
            End If

            If RECORDER_INITIALIZED = False And RTSP_STATE_PLAY = True Then
                USER_TASKNAME = RegulateFilePath(USER_TASKNAME, ".ts")
                If Not My.Computer.FileSystem.DirectoryExists(Path.GetDirectoryName(USER_TASKNAME)) Then My.Computer.FileSystem.CreateDirectory(Path.GetDirectoryName(USER_TASKNAME))
                RECORDER_FILESTREAM = New IO.FileStream(USER_TASKNAME, IO.FileMode.Create)
                RECORDER_WRITER = New IO.BinaryWriter(RECORDER_FILESTREAM)
                RECORDER_INITIALIZED = True

                Try
                    InvokeControl(LblRecording, Sub(x) x.Visible = True)
                    InvokeControl(Me, Sub(x) x.Text = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(USER_TASKNAME)))
                Catch ex As Exception

                End Try
            End If

            RECORDER_WRITER.Write(Data)
            RECORDER_WRITER.Flush()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WORKER_START()
        Try
            If BgwCoreWorker.IsBusy = False Then
                If BtnHandle.Text = LABEL_STATE_START Then
                    TmrClipboard.Enabled = False
                    BtnHandle.Text = LABEL_STATE_STOP
                    If ChkOverride.Checked Then
                        HANDLE_OVERRIDE = NumOverride.Value
                        ChkOverride.Checked = False
                    End If
                    USER_URL = TxtURL.Text.Trim
                    USER_TASKNAME = TxtTaskName.Text.Trim
                    HANDLE_PRESET = CboPreset.Text
                Else
                    InvokeControl(BtnHandle, Sub(x) x.Text = LABEL_STATE_START)
                    HANDLE_TEARDOWN = True
                End If

                BgwCoreWorker.RunWorkerAsync()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetRndFileName() As String
        Return "REC_" & Format(Now(), "yyyyMMdd_HHmmss") & "_" & GetRndString(4)
    End Function

    Public Function GetRndString(StringLength As Long) As String
        Try
            Randomize()
            Dim _loc_1 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim _loc_2 As New Random
            Dim _loc_3 As New StringBuilder
            For _loc_4 As Integer = 1 To StringLength
                _loc_3.Append(_loc_1.Substring(_loc_2.Next(0, _loc_1.Length - 1), 1))
            Next
            Return _loc_3.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub InvokeControl(Of T As Control)(ByVal Control As T, ByVal Action As Action(Of T))
        If Control.InvokeRequired Then
            Control.Invoke(New Action(Of T, Action(Of T))(AddressOf InvokeControl), New Object() {Control, Action})
        Else
            Action(Control)
        End If
    End Sub

    Private Function IsFFmpegExist() As Boolean
        Try
            Dim _loc_1 As New Process()
            _loc_1.StartInfo.FileName = "ffmpeg.exe"
            _loc_1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            _loc_1.Start()
            _loc_1.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function ParseIP(Input As String)
        Try
            If Input.Contains(":") Then
                Return Input.Trim
            Else
                Dim _loc_1 As String() = Input.Trim.Split(".")
                Dim _loc_2 As String = True
                For Each _loc_3 In _loc_1
                    If Not IsNumeric(_loc_3) Then
                        _loc_2 = False
                        Exit For
                    End If
                Next
                If _loc_2 Then
                    Return Input.Trim
                Else
                    Return ResolveHostName(Input.Trim)
                End If
            End If
        Catch ex As Exception
            Return Input.Trim
        End Try
    End Function

    Private Function RegulateFileName(FileName As String)
        Try
            Return FileName.Replace("/", "_").Replace("\", "_").Replace("*", "_").Replace("?", "_").Replace(":", "_").Replace("<", "_").Replace(">", "_").Replace(Chr(34), "_").Replace("|", "_")
        Catch ex As Exception
            Return FileName
        End Try
    End Function

    Private Function RegulateFilePath(Input As String, Optional DefaultExtension As String = "")
        Try
            Dim DirectoryName As String = Application.StartupPath & "\"
            Dim FileName As String = ""
            Input = Input.Replace("/", "\")
            If Input.EndsWith(":") Then Input &= "\"
            Dim _loc_1 As String() = Input.Split("\")
            If (_loc_1(0) = "" And Not Input.StartsWith("\\")) Or (Not _loc_1(0) = "" And Not _loc_1(0).Contains(":")) Then
                Input = Application.StartupPath & "\" & Input
            End If
            If Input.EndsWith("\") Then
                DirectoryName = Input
            Else
                DirectoryName = Path.GetDirectoryName(Input) & "\"
                FileName = RegulateFileName(_loc_1(_loc_1.Length - 1))
            End If
            If FileName = "" Then FileName = GetRndFileName()
            If Not FileName.Contains(".") Then FileName &= DefaultExtension
            If My.Computer.FileSystem.FileExists(DirectoryName & FileName) Then FileName = Path.GetFileNameWithoutExtension(FileName) & "_" & Format(Now(), "yyyyMMdd_HHmmss") & Path.GetExtension(FileName)
            Return DirectoryName & FileName
        Catch ex As Exception
            Return Input
        End Try
    End Function

    Public Function ResolveHostName(HostName As String) As String
        Dim HostEntry As IPHostEntry
        HostEntry = Dns.GetHostEntry(HostName)

        If HostEntry.AddressList.Length > 0 Then
            Return HostEntry.AddressList(0).ToString()
        Else
            Return HostName
        End If
    End Function

    Public Function Time() As Long
        Return (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
    End Function

End Class
