Imports System.Data.OleDb
Public Class LihatData
    Sub tampilTransaksi2()
        Call buka()
        da = New OleDbDataAdapter("Select tgl_transaksi,nama_customer,jenis_barang,proses_cuci,jumlah,harga from Transaksi where tgl_transaksi='" & DateTimePicker1.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds, "Transaksi")
        DataGridView1.DataSource = ds.Tables("Transaksi")
    End Sub
    Sub tampilTransaksi()
        Call buka()
        da = New OleDbDataAdapter("Select tgl_masuk,proses_cuci,jenis_barang,nama_customer,jumlah,harga,total from Barang_Masuk where tgl_masuk='" & DateTimePicker1.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds, "Barang_Masuk")
        DataGridView1.DataSource = ds.Tables("Barang_Masuk")
    End Sub
    Sub tampilTransaksikel()
        Call buka()
        da = New OleDbDataAdapter("Select tgl_transaksi,nama_customer,jenis_barang,proses_cuci,jumlah,harga from Transaksi ", conn)
        ds = New DataSet
        da.Fill(ds, "Transaksi")
        DataGridView1.DataSource = ds.Tables("Transaksi")
    End Sub
    Sub tampilTransaksimas()
        Call buka()
        da = New OleDbDataAdapter("Select * from Barang_Masuk order by id_masuk desc", conn)
        ds = New DataSet
        da.Fill(ds, "Barang_Masuk")
        DataGridView1.DataSource = ds.Tables("Barang_Masuk")
    End Sub
    Sub tampilTransaksix()
        da = New OleDbDataAdapter("Select * from Barang_Masuk order by id_masuk desc", conn)
        ds = New DataSet
        da.Fill(ds, "Barang_Masuk")
        DataGridView1.DataSource = ds.Tables("Barang_Masuk")
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If ComboBox1.Text = "Data Barang Masuk" Then
            tampilTransaksi()
        Else
            tampilTransaksi2()
        End If

    End Sub

    Private Sub LihatData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        tampilTransaksix()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Data Barang Masuk" Then
            tampilTransaksi()
        Else
            tampilTransaksi2()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Layanan.Opacity = 100%
        Layanan.Enabled = True
        Layanan.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "Data Barang Masuk" Then
            tampilTransaksimas()
        Else
            tampilTransaksikel()
        End If
    End Sub
End Class