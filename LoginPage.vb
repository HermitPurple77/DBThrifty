Public Class Form1

    Private Const validUsername As String = "admin"
    Private Const validPassword As String = "12345"

    ' Login button click event
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get user input
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Validate credentials
        If username = validUsername And password = validPassword Then
            MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide() ' Hide login form
            Dim mainForm As New mainForm()
            mainForm.Show() ' Open the main application form
            TextBox1.Clear()
            TextBox2.Clear()
        Else
            MessageBox.Show("Invalid Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Clear()
        End If
    End Sub

    ' Exit button to close the application
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

End Class
