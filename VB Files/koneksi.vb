Imports System.Data.OleDb


Module koneksi

    Public conn As OleDbConnection
    Public cmd As OleDbCommand
    Public ds As New DataSet
    Public da As OleDbDataAdapter
    Public rd As OleDbDataReader
    Public lokasidata As String
    Public simpan As String
    Public ubah As String
    Public hapus As String


    Public Sub buka()
        lokasidata = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\underwash.accdb"
        conn = New OleDbConnection(lokasidata)

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

End Module
