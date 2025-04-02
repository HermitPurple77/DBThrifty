Public Class mainForm
    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Thrift Store Management - Home"
        Label1.Text = "Welcome to the ThriftTrack!"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim productForm As New ProductForm()
        productForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim orderForm As New orderForm()
        orderForm.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim paymentForm As New paymentForm()
        paymentForm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim sellerForm As New DonorForm()
        sellerForm.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Me.Close() ' Close the main form
        Form1.Show() ' Show login form again
    End Sub
End Class
