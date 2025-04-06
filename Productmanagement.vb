Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class productForm
    Dim conn As New SqlConnection("Data Source=LAPTOP-IM7S35L9\SQLEXPRESS;Initial Catalog=ThriftTrack;Integrated Security=True")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Hide TextBoxes
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True

        ' Hide Labels
        Label6.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True

        ' Optional: Hide ComboBox too
        ComboBox1.Visible = True
        DataGridView1.Visible = False
        Try
            conn.Open()
            Dim cmd As New SqlCommand("INSERT INTO Products (ProductName, Category, Quantity, Price) VALUES (@name, @cat, @qty, @price)", conn)
            cmd.Parameters.AddWithValue("@name", TextBox2.Text)
            cmd.Parameters.AddWithValue("@cat", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(TextBox3.Text))
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(TextBox4.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product added successfully.")
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            conn.Close()
        Finally
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Visible = False
        ' Hide TextBoxes
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True

        ' Hide Labels
        Label6.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True

        ' Optional: Hide ComboBox too
        ComboBox1.Visible = True
        Try
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE Products SET ProductName=@name, Category=@cat, Quantity=@qty, Price=@price WHERE ProductID=@id", conn)
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(TextBox1.Text))
            cmd.Parameters.AddWithValue("@name", TextBox2.Text)
            cmd.Parameters.AddWithValue("@cat", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(TextBox3.Text))
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(TextBox4.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product updated successfully.")
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            conn.Close()
        Finally
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataGridView1.Visible = False
        ' Hide TextBoxes
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True

        ' Hide Labels
        Label6.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True

        ' Optional: Hide ComboBox too
        ComboBox1.Visible = True
        Try
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM Products WHERE ProductID=@id", conn)
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(TextBox1.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product deleted.")
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            conn.Close()
        Finally
            TextBox1.Text = " "
            TextBox2.Text = " "
            TextBox3.Text = " "
            TextBox4.Text = " "
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Visible = False
        Me.Close() ' Close the product form
        mainForm.Show() ' Show homepage again
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DataGridView1.Visible = True
        ' Hide TextBoxes
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False

        ' Hide Labels
        Label6.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False

        ' Optional: Hide ComboBox too
        ComboBox1.Visible = False

        Try
            conn.Open()
            Dim adapter As New SqlDataAdapter("SELECT * FROM Products", conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub productForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Visible = False
        ComboBox1.Items.Add("Clothing")
        ComboBox1.Items.Add("Accessories")
        ComboBox1.Items.Add("Bags")
        ComboBox1.Items.Add("Footwear")
        ComboBox1.Items.Add("Others..")
    End Sub
End Class
