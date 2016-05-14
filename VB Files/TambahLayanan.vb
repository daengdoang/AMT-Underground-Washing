Imports System.Data.OleDb


Public Class TambahLayanan

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Masukan Data", "Masukan Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Data Berhasil dimasukan", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim lay As Integer
            cmd = New OleDbCommand("select max(id_layanan) from Layanan", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            lay = rd.GetValue(0)

            Dim harga As Integer
            harga = CInt(TextBox2.Text)
            Dim simpan As String = "insert into Layanan values ('" & lay + 1 & "','" & TextBox1.Text & "','" & harga & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteNonQuery()


            Me.Hide()
            Layanan.Opacity = 100%
            Layanan.Enabled = True
            Layanan.Show()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Layanan.Opacity = 100%
        Layanan.Enabled = True
        Layanan.Show()
    End Sub
End Class