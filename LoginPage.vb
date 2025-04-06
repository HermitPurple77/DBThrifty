Imports System.Data.SqlClient

Public Class Form1
    Dim connectionString As String = "Data Source=LAPTOP-IM7S35L9\SQLEXPRESS;Initial Catalog=ThriftTrack;Integrated Security=True"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()

        If username = "" Or password = "" Then
            Label1.Text = "Please enter both username and password."
            Exit Sub
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Heads WHERE Username = @username AND PasswordHash = @password"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password) ' NOTE: Store hash in real use

                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                conn.Close()

                If count = 1 Then
                    MessageBox.Show("Login successful!")
                    ' Proceed to main form
                    Dim dashboard As New mainForm()
                    dashboard.Show()
                    Me.Hide()
                Else
                    Label1.ForeColor = Color.Red
                    Label1.Text = "Invalid username or password."
                End If
            End Using
        End Using
    End Sub
End Class
