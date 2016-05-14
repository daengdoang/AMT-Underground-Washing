Public Class Struk

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub Struk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        If kembali < 1 Then
            Label21.Visible = True
            GroupBox1.Visible = False
        End If
        Label11.Text = tnomor
        Label12.Text = ""
        Label13.Text = tnama
        Label14.Text = tbarang
        Label15.Text = tproses
        Label16.Text = tbanyak
        Label17.Text = tharga
        Label18.Text = ttotal
        Label19.Text = bayar
        Label20.Text = kembali
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Layanan.Opacity = 100%
        Layanan.Enabled = True
        Layanan.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PrintDialog1.ShowDialog()
    End Sub
End Class