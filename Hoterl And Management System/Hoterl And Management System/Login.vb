Public Class Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" And txtPassword.Text = "" Then
            MessageBox.Show("Please enter your username and password", "Login Message")
        ElseIf txtUsername.Text = "" Then
            MessageBox.Show("Please enter your username", "Login Message")
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Please enter your password", "Login Message")
        ElseIf txtUsername.Text = "admin" And txtPassword.Text = "admin" Then
            MessageBox.Show("Login Success", "Delorian Hotel And Management")
            Dim obj = Form1
            obj.Show()
            Me.Hide()
            txtUsername.Text = ""
            txtPassword.Text = ""
        ElseIf txtUsername.Text <> "aaron" And txtPassword.Text <> "bujatin" Then
            MessageBox.Show("Wrong username and password", "Login Message")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub
End Class