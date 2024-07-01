Public Class Console

    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If MainUI.USER_LANGUAGE_ID = 2052 Or MainUI.USER_LANGUAGE_ID = 1028 Or MainUI.USER_LANGUAGE_ID = 3076 Then
                Text = "控制台"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtResponse_TextChanged(sender As Object, e As EventArgs) Handles TxtResponse.TextChanged
        Try
            TxtResponse.Select(TxtResponse.Text.Length, 0)
            TxtResponse.ScrollToCaret()
        Catch ex As Exception

        End Try
    End Sub

End Class