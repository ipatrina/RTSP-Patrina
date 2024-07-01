Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class TCPClient

    Dim SERVER_IP As String
    Dim SERVER_PORT As Integer
    Dim TCP_CLIENT As Socket

    Public Function Available() As String
        Try
            Return TCP_CLIENT.Available
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub Close()
        Try
            TCP_CLIENT.Close()
            TCP_CLIENT.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Connect(DestinationIP As String, DestinationPort As Integer)
        Try
            TCP_CLIENT = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) With {
                .ReceiveBufferSize = 134217728,
                .SendTimeout = 10000,
                .ReceiveTimeout = 10000
            }
            SERVER_IP = DestinationIP
            SERVER_PORT = DestinationPort
        Catch ex As System.Exception

        End Try
    End Sub

    Public Function Receive(Optional ReceiveLength As Integer = 0) As Byte()
        Try
            If ReceiveLength <= 0 Then ReceiveLength = TCP_CLIENT.Available
            Dim ReceiveBuffer As Byte() = New Byte(ReceiveLength - 1) {}
            TCP_CLIENT.Receive(ReceiveBuffer, ReceiveLength, SocketFlags.None)
            Return ReceiveBuffer
        Catch ex As Exception
            Return New Byte() {}
        End Try
    End Function

    Public Sub SendString(Data As String)
        Try
            If TCP_CLIENT.Connected = False Then
                TCP_CLIENT.Connect(New IPEndPoint(IPAddress.Parse(SERVER_IP), SERVER_PORT))
            End If
            TCP_CLIENT.Send(Encoding.UTF8.GetBytes(Data & vbCrLf & vbcrlf))
        Catch ex As System.Exception

        End Try
    End Sub

End Class
