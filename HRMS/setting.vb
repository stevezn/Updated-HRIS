Public Class setting
    Dim connectionString As String = "Server=localhost; User Id=root; Password=; Database=db_hris"
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim tbl_par As New DataTable
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT * FROM db_user WHERE username ='" + teUsername.Text + "' and password='" + tePassword.Text + "'"
        sqlCommand.Connection = SQLConnection

        Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        If tbl_par.Rows.Count > 0 Then
            For index As Integer = 0 To tbl_par.Rows.Count - 1
                SQLConnection = New MySqlConnection()
                SQLConnection.ConnectionString = connectionString
                SQLConnection.Open()
                Try
                    sqlCommand.CommandText = "UPDATE db_user SET username = @username, password= @password, tanggal_ubah=@tanggal ) " +
                                             "WHERE id_user=" + tbl_par.Rows(0).Item(0).ToString()
                    sqlCommand.Parameters.AddWithValue("@username", teUsername.Text)
                    sqlCommand.Parameters.AddWithValue("@password", teNewPassword.Text)
                    sqlCommand.Parameters.AddWithValue("@tanggal", Date.Today().ToString())
                    sqlCommand.Connection = SQLConnection
                    sqlCommand.ExecuteNonQuery()
                    SQLConnection.Close()
                    MessageBox.Show("Succesfully Changed!!")
                Catch ex As Exception
                    SQLConnection.Close()
                    MsgBox(ex.Message)
                End Try
            Next
        Else
            MessageBox.Show("Username & Password Didn't Match!!")
        End If
        SQLConnection.Close()
    End Sub

    Dim act As String = "input"
    Dim sqlCommand As New MySqlCommand
    Private Sub btnJabatan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayrollset.Click
        If teFulltime.Text = "" And teFulltime.Text = "" And teFulltime.Text = "" And teFulltime.Text = "" Then
            MessageBox.Show("Lengkapi kolom jabatan & Gaji terlebih dahulu!")
        Else
            SQLConnection = New MySqlConnection()
            SQLConnection.ConnectionString = connectionString
            SQLConnection.Open()

            Try
                sqlCommand.CommandText = "insert into mst_jabatan value(0,@jabatan, @gaji)"
                sqlCommand.Parameters.AddWithValue("@jabatan", teFulltime.Text)
                sqlCommand.Parameters.AddWithValue("@gaji", Convert.ToDouble(teFulltime.Text))
                sqlCommand.Connection = SQLConnection
                sqlCommand.ExecuteNonQuery()

                SQLConnection.Close()
                MessageBox.Show("Berhasil input jabatan baru!")
            Catch ex As Exception
                SQLConnection.Close()
                MessageBox.Show("Gagal input jabatan baru!")
            End Try
        End If
    End Sub

    Private Sub setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class