Imports System.Data.OleDb

Public Class BarangMasuk

    Dim jupro As Integer = 0
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub combobox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Layanan.Opacity = 100%
        Layanan.Enabled = True
        Layanan.Show()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton2.Checked = True Then
            If TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
                MessageBox.Show("Masukan Data", "Masukan Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Data Berhasil dimasukan", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim lay As Integer
                cmd = New OleDbCommand("select max(id_customer) from Customer", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                lay = rd.GetValue(0)


                Dim simpan As String = "insert into Customer values ('" & lay + 1 & "','" & combobox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                tnama = combobox1.Text
                tdate = DateTimePicker1.Text
                jumlahproses = Val(TextBox3.Text)
                Me.Hide()
                ProsesBarangMasuk.Show()
            End If
        Else

            tnama = ComboBox1.Text
            tdate = DateTimePicker1.Text
            jumlahproses = Val(TextBox3.Text)

            Me.Hide()
            ProsesBarangMasuk.Show()
        End If
    End Sub

    Private Sub BarangMasuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'UnderwashDataSet.Customer' table. You can move, or remove it, as needed.
        Me.CustomerTableAdapter.Fill(Me.UnderwashDataSet.Customer)
        Me.CenterToScreen()

        If RadioButton1.Checked = True Then
            combobox1.Enabled = True
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
        ElseIf RadioButton2.Checked = True Then
            TextBox2.Enabled = True
            combobox1.Enabled = False
            TextBox4.Enabled = True
            TextBox5.Enabled = True
        End If
    End Sub

    Private Sub combobox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            combobox1.Enabled = True
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
        ElseIf RadioButton2.Checked = True Then
            TextBox2.Enabled = True
            combobox1.Enabled = False
            TextBox4.Enabled = True
            TextBox5.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton1.Checked = True Then
            combobox1.Enabled = True
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
        ElseIf RadioButton2.Checked = True Then
            TextBox2.Enabled = True
            combobox1.Enabled = False
            TextBox4.Enabled = True
            TextBox5.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        jupro = jupro + 1
        TextBox3.Text = jupro
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        jupro = jupro - 1
        TextBox3.Text = jupro
    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class