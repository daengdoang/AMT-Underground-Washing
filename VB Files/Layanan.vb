Imports System.Data.OleDb


Public Class Layanan
    Sub tampilLayanan()
        da = New OleDbDataAdapter("Select * from Layanan", conn)
        ds = New DataSet
        da.Fill(ds, "Layanan")
        DataGridView1.DataSource = ds.Tables("Layanan")
    End Sub
    Sub tampilBarang()
        da = New OleDbDataAdapter("Select * from Barang", conn)
        ds = New DataSet
        da.Fill(ds, "Barang")
        DataGridView1.DataSource = ds.Tables("Barang")
    End Sub
    Sub tampilCustomer()
        da = New OleDbDataAdapter("Select * from Customer order by id_customer asc", conn)
        ds = New DataSet
        da.Fill(ds, "Customer")
        DataGridView1.DataSource = ds.Tables("Customer")
    End Sub
    Sub tampilTransaksi()
        da = New OleDbDataAdapter("Select id_transaksi,tgl_transaksi,nama_customer,jenis_barang,proses_cuci,jumlah,harga from Transaksi", conn)
        ds = New DataSet
        da.Fill(ds, "Transaksi")
        DataGridView1.DataSource = ds.Tables("Transaksi")
    End Sub
    Sub tampilCariProses()
        Dim ari As String
        ari = TextBox1.Text + "%"
        da = New OleDbDataAdapter("Select * from Layanan where Proses_Cuci like  '" & ari & "' ", conn)
        ds = New DataSet
        da.Fill(ds, "Layanan")
        DataGridView1.DataSource = ds.Tables("Layanan")
    End Sub
    Sub tampilCariBarang()
        Dim ari As String
        ari = TextBox1.Text + "%"
        da = New OleDbDataAdapter("Select * from Barang where nama_barang like  '" & ari & "' ", conn)
        ds = New DataSet
        da.Fill(ds, "Barang")
        DataGridView1.DataSource = ds.Tables("Barang")
    End Sub
    Sub tampilCariCustomer()
        Dim ari As String
        ari = TextBox1.Text + "%"
        da = New OleDbDataAdapter("Select * from Customer where nama_customer like  '" & ari & "' ", conn)
        ds = New DataSet
        da.Fill(ds, "Customer")
        DataGridView1.DataSource = ds.Tables("Customer")
    End Sub
    Sub tampilMasuk()
        da = New OleDbDataAdapter("Select * from Barang_Masuk order by id_masuk asc", conn)
        ds = New DataSet
        da.Fill(ds, "Barang_Masuk")
        DataGridView1.DataSource = ds.Tables("Barang_Masuk")
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        statusmenu = 1
        Me.CenterToScreen()
        Call buka()
        Call tampilLayanan()

       
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        statusmenu = 2
        tampilBarang()
        btn_tambah.Text = "Tambah Jenis Barang"
        btn_hapus.Text = "Hapus Jenis"
        btn_edit.Text = "Cari Data"


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tampilLayanan()
        statusmenu = 1
        btn_tambah.Text = "Tambah Layanan"
        btn_hapus.Text = "Hapus Layanan"
        btn_edit.Text = "Cari Data"
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cetak.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        statusmenu = 3
        tampilCustomer()
        btn_tambah.Text = "Tambah Customer"
        btn_hapus.Text = "Hapus Customer"
        btn_edit.Text = "Edit Data"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        statusmenu = 4
        tampilMasuk()
        btn_tambah.Text = "Tambah Barang Masuk"
        btn_hapus.Text = "Hapus Barang"
        btn_edit.Text = "Edit Data"
        btn_tambah.Text = "Kirim Barang"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tambah.Click
        Me.Enabled = False
        Me.Opacity = 10%
        If statusmenu = 1 Then
            TambahLayanan.Show()
        ElseIf statusmenu = 2 Then
            Dim barangbaru As String
            barangbaru = InputBox("Masukan Nama barang")

            Dim lay As Integer
            cmd = New OleDbCommand("select max(id_barang) from Barang", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            lay = rd.GetValue(0)

            Dim simpan As String = "insert into Barang values ('" & lay + 1 & "','" & barangbaru & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            Me.Opacity = 100%
            Me.Enabled = True
            Me.Show()
        ElseIf statusmenu = 3 Then
            TambahCustomer.Show()
        ElseIf statusmenu = 4 Then
            Dim kirim As Integer
            kirim = InputBox("Masukan nomor transaksi yang ingin dikirim", "insert value")
            If kirim <> 0 Then
                Dim simpan As String = "update Barang_Masuk set status = 'K' where id_masuk = " & kirim & " "
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
            End If
            Me.Opacity = 100%
            Me.Enabled = True
            Me.Show()
            ElseIf statusmenu = 5 Then
                BarangMasuk.Show()
            End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        Admin.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        statusmenu = 5
        tampilTransaksi()
        btn_tambah.Text = "Tambah Transaksi"
        btn_hapus.Text = "Hapus Transaksi"
        btn_edit.Text = "Edit Data"
    End Sub

    Private Sub btn_hasil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hasil.Click

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btn_cari_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        If statusmenu = 1 Then
            tampilCariProses()
        ElseIf statusmenu = 2 Then
            tampilCariBarang()
        ElseIf statusmenu = 3 Then
            tampilCariCustomer()
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If statusmenu = 1 Then
            tampilCariProses()
        ElseIf statusmenu = 2 Then
            tampilCariBarang()
        ElseIf statusmenu = 3 Then
            tampilCariCustomer()
        End If
    End Sub
    Sub tampilGrid()
        da = New OleDbDataAdapter("Select * from Barang_Masuk", conn)
        ds = New DataSet
        da.Fill(ds, "Barang_Masuk")
        DataGridView1.DataSource = ds.Tables("Barang_Masuk")
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click

        Dim id = InputBox("Masukkan id dari data layanan yang akan dihapus : ")
        If statusmenu = 1 Then
            Dim hapus As String = "delete from Layanan where id_layanan =" & id & ""
            cmd = New OleDbCommand(hapus, conn)
            MessageBox.Show("Data Berhasil dihapus", "data berhasil dihapus", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmd.ExecuteNonQuery()
            Call tampilLayanan()
        ElseIf statusmenu = 2 Then
            Dim hapus As String = "delete from Barang where id_barang =" & id & ""
            cmd = New OleDbCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            Call tampilBarang()
        ElseIf statusmenu = 3 Then
            Dim hapus As String = "delete from Customer where id_customer =" & id & ""
            cmd = New OleDbCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            Call tampilCustomer()
        ElseIf statusmenu = 4 Then
            Dim hapus As String = "delete from Barang_Masuk where id_masuk =" & id & ""
            cmd = New OleDbCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            Call tampilGrid()
        ElseIf statusmenu = 5 Then
            Dim hapus As String = "delete from Transaksi where id_transaksi =" & id & ""
            cmd = New OleDbCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            Call tampilTransaksi()
        End If

           
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        LihatData.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub BindingSource1_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingSource1.CurrentChanged

    End Sub
End Class