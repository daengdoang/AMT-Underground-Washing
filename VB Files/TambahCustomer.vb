Imports System.Data.OleDb


Public Class TambahCustomer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("Masukan Data", "Masukan Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Data Berhasil dimasukan", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim lay As Integer
            cmd = New OleDbCommand("select max(id_customer) from Customer", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            lay = rd.GetValue(0)


            Dim simpan As String = "insert into Customer values ('" & lay + 1 & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteNonQuery()


            Me.Hide()
            Layanan.Opacity = 100%
            Layanan.Enabled = True
            Layanan.Show()
        End If
    End Sub

    Private Sub TambahCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Layanan.Opacity = 100%
        Layanan.Enabled = True
        Layanan.Show()
    End Sub
End Class