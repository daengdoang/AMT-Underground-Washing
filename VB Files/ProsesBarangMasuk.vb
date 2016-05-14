Imports System.Data.OleDb
Public Class ProsesBarangMasuk
    Dim harg As Integer
    Dim stat As Integer = 0
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        tbarang = ComboBox1.Text
        tproses = ComboBox2.Text
        tbanyak = Val(TextBox3.Text)
        tharga = Val(TextBox4.Text)
        ttotal = tharga * tbanyak
        TextBox2.Text = ttotal
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Layanan.Opacity = 100%
        Layanan.Enabled = True
        Layanan.Show()
    End Sub

    Private Sub ProsesBarangMasuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        'TODO: This line of code loads data into the 'UnderwashDataSet4.Barang' table. You can move, or remove it, as needed.
        Me.BarangTableAdapter.Fill(Me.UnderwashDataSet4.Barang)
        Me.LayananTableAdapter1.Fill(Me.UnderwashDataSet4.Layanan)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("DATA BELUM LENGKAP", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            tbarang = ComboBox1.Text
            tproses = ComboBox2.Text
            tbanyak = Val(TextBox3.Text)
            tfaktur = Val(TextBox5.Text)
            tharga = Val(TextBox4.Text)
            ttotal = tharga * tbanyak
            TextBox2.Text = ttotal
            bayar = TextBox6.Text
            kembali = bayar - ttotal
            Dim lay As Integer
            cmd = New OleDbCommand("select max(id_transaksi) from Transaksi", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            lay = rd.GetValue(0)
            tnomor = lay + 1
            Dim simpan As String = "insert into Transaksi values ('" & lay + 1 & "','2','3','4','7','" & tdate & "','" & tnama & "','" & tbarang & "','" & tproses & "','" & tbanyak & "','" & tharga & "','" & ttotal & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteNonQuery()


            Me.Hide()


            Dim layu As Integer
            cmd = New OleDbCommand("select max(id_masuk) from Barang_Masuk", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            layu = rd.GetValue(0)

            If CheckBox1.Checked = True Then
                Dim simpanse As String = "insert into Barang_Masuk values ('" & layu + 1 & "','" & tdate & "','" & tnama & "','" & tbarang & "','" & tproses & "','" & tbanyak & "','" & tharga & "','" & ttotal & "','K')"
                cmd = New OleDbCommand(simpanse, conn)
                cmd.ExecuteNonQuery()
            Else
                Dim simpanse As String = "insert into Barang_Masuk values ('" & layu + 1 & "','" & tdate & "','" & tnama & "','" & tbarang & "','" & tproses & "','" & tbanyak & "','" & tharga & "','" & ttotal & "','P')"
                cmd = New OleDbCommand(simpanse, conn)
                cmd.ExecuteNonQuery()
                Me.Hide()
            End If

            If CheckBox1.Checked = True Then
                Struk.Show()
            Else
                Layanan.Opacity = 100%
                Layanan.Enabled = True
                Layanan.Show()
            End If
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

        tharga = Val(TextBox4.Text)
        ttotal = tharga * tbanyak
        TextBox2.Text = ttotal
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        tbarang = ComboBox1.Text
        tproses = ComboBox2.Text
        tbanyak = Val(TextBox3.Text)
        tharga = Val(TextBox4.Text)
        ttotal = tharga * tbanyak
        TextBox2.Text = ttotal
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        cmd = New OleDbCommand("select Harga from Layanan where Proses_Cuci = '" & ComboBox2.Text & "' ", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        harg = rd.GetValue(0)

        TextBox4.Text = harg
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        harg = harg + Val(TextBox1.Text)
        TextBox4.Text = harg
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        harg = harg - Val(TextBox1.Text)
        TextBox4.Text = harg
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If stat = 0 Then
            TextBox6.Enabled = True
            stat = 1
        Else
            TextBox6.Enabled = False
            stat = 0
        End If
    End Sub
End Class