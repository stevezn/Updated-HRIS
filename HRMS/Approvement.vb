Imports System.IO
Public Class Approvement
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim tbl_par As New DataTable

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        Dim host As String
        Dim id As String
        Dim password As String
        Dim db As String
        If File.Exists("settinghost.txt") Then
            host = File.ReadAllText("settinghost.txt")
        Else
            host = "localhost"
        End If
        If File.Exists("settingid.txt") Then
            id = File.ReadAllText("settingid.txt")
        Else
            id = "root"
        End If
        If File.Exists("settingpass.txt") Then
            password = File.ReadAllText("settingpass.txt")
        Else
            password = ""
        End If
        If File.Exists("settingdb.txt") Then
            db = File.ReadAllText("settingdb.txt")
        Else
            db = "db_hris"
        End If
        connectionString = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
    End Sub

    Private Sub Approvement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        autofill()
        autofill2()
    End Sub

    Sub autofill()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter("select EmployeeCode from db_pegawai", SQLConnection)
        da.Fill(dt)
        Dim r As DataRow
        TextBox1.AutoCompleteCustomSource.Clear()
        For Each r In dt.Rows
            TextBox1.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        Next
    End Sub

    Sub autofill2()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter("select FullName from db_pegawai", SQLConnection)
        da.Fill(dt)
        Dim r As DataRow
        TextBox2.AutoCompleteCustomSource.Clear()
        For Each r In dt.Rows
            TextBox2.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        Next
    End Sub

    Sub emp()
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select FullName From db_pegawai where Employeecode = '" & TextBox1.Text & "'"
            Dim quer As String = CStr(query.ExecuteScalar)
            TextBox2.Text = quer.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Timer1.Stop()
        emp()
    End Sub

    Dim sel As New selectemp

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Timer1.Start()
        If sel Is Nothing OrElse sel.IsDisposed OrElse sel.MinimizeBox Then
            sel.Close()
            sel = New selectemp
        End If
        sel.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select name from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
            TextBox2.Text = quer1.ToString

            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            TextBox1.Text = quer2.ToString
        Catch ex As Exception
        End Try
    End Sub

    Sub sc()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select MemoNo, EmployeeCode, FullName, tgl as Dates, ChangeType, JobTitle, OfficeLocation, Department, Grouping, ApprovedBy, Status from db_statuschange where status = 'Requested'"
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        GridControl1.DataSource = dt
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LabelControl5.Text = "Status Change"
        GridView1.Columns.Clear()
        sc()
    End Sub

    Sub terminate()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select MemoNo, EmployeeCode, FullName, tgl as Dates, JobTitle, Status, Allowance, AllowanceTax, PaymentDate, Reason, ApprovedBy, ApprovedStatus from db_terminate where ApprovedStatus = 'Requested'"
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        GridControl1.DataSource = dt
        GridView1.BestFitColumns()
    End Sub

    Sub leaves()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select MemoNo, EmployeeCode, FullName, tgl as Dates, Reason, StartDate, EndDate, TotalDays, Ket as Reason, ApprovedBy, ApprovedStatus from db_attrec where Approvedstatus = 'Requested'"
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        GridControl1.DataSource = dt
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        LabelControl5.Text = "Termination"
        GridView1.Columns.Clear()
        terminate()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        LabelControl5.Text = "Leave Request"
        GridView1.Columns.Clear()
        leaves()
    End Sub

    Sub updatest()
        Try
            Dim cm As MySqlCommand = SQLConnection.CreateCommand
            cm.CommandText = "select grouping from db_statuschange where employeecode = @ec"
            cm.Parameters.AddWithValue("@ec", TextBox3.Text)
            Dim cm1 As String = CStr(cm.ExecuteScalar)

            cm.CommandText = "select department from db_statuschange where employeecode = @ec"
            cm.Parameters.AddWithValue("@ec", TextBox3.Text)
            Dim cm2 As String = CStr(cm.ExecuteScalar)

            cm.CommandText = "select position from db_statuschange where employeecode = @ec"
            cm.Parameters.AddWithValue("@ec", TextBox3.Text)
            Dim cm3 As String = CStr(cm.ExecuteScalar)
            Dim cmmd As MySqlCommand = SQLConnection.CreateCommand

            cmmd.CommandText = "update db_pegawai set Grouping = @grp, Department = @dept, Position = @pos where EmployeeCode = @ec"
            cmmd.Parameters.AddWithValue("@grp", cm1)
            cmmd.Parameters.AddWithValue("@dept", cm2)
            cmmd.Parameters.AddWithValue("@pos", cm3)
            cmmd.Parameters.AddWithValue("@ec", TextBox3.Text)
            cmmd.ExecuteNonQuery()
            MsgBox("Changed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub updateterminate()
        Dim cmd As MySqlCommand = SQLConnection.CreateCommand
        cmd.CommandText = "update db_pegawai set status = 'Terminated' where employeecode = '" & TextBox3.Text & "'"
        cmd.ExecuteNonQuery()

        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select idnumber from db_pegawai where employeecode = '" & TextBox3.Text & "'"
        Dim hsl As String = CStr(query.ExecuteScalar)

        query.CommandText = "select blacklist from db_terminate where employeecode = '" & TextBox3.Text & "'"
        Dim bl As Integer = CInt(query.ExecuteScalar)

        query.CommandText = "update db_recruitment set blacklist = @check where idnumber = @id"
        query.Parameters.AddWithValue("@id", hsl.ToString)
        query.Parameters.AddWithValue("@check", bl)
        query.ExecuteNonQuery()
    End Sub

    Sub approvement()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select user from db_temp"
        Dim quer As String = CStr(query.ExecuteScalar)
        Dim fn As String
        fn = InputBox("Reason")
        If LabelControl5.Text = "Status Change" Then
            query.CommandText = "update db_statuschange set status = 'Approved', reason = @reason, ApprovedBy = @app where MemoNo = '" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@reason", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Approved")
            updatest()
            sc()
        ElseIf LabelControl5.Text = "Termination" Then
            query.CommandText = "update db_terminate set ApprovedStatus = 'Approved', purpose = @purpose,  ApprovedBy = @app where MemoNo = '" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@purpose", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Approved")
            updateterminate()
            terminate()
        ElseIf LabelControl5.Text = "Leave Request" Then
            query.CommandText = "update db_attrec set ApprovedStatus = 'Approved', purpose = @purpose,  ApprovedBy = @app where MemoNo ='" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@purpose", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Approved")
            leaves()
        ElseIf LabelControl5.Text = "Loans" Then
            query.CommandText = "update db_loan set status = 'Approved',  reason = @purpose, ApprovedBy = @app where EmployeeCode = '" & TextBox3.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@purpose", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Approved")
            loans()
        ElseIf LabelControl5.Text = "Other Income" Then
            query.CommandText = "update db_addition set status = 'Approved', purpose = @purpose, ApprovedBy = @app where MemoNo = '" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@purpose", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Approved")
            others()
        End If
    End Sub

    Sub rejection()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select user from db_temp"
        Dim quer As String = CStr(query.ExecuteScalar)
        Dim fn As String
        fn = InputBox("Reason")
        If LabelControl5.Text = "Status Change" Then
            query.CommandText = "update db_statuschange set status = 'Rejected', Reason = @reason, ApprovedBy = @app where MemoNo = '" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@reason", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Rejected")
            sc()
        ElseIf LabelControl5.Text = "Termination" Then
            query.CommandText = "update db_terminate set ApprovedStatus = 'Rejected', Purpose = @reason, ApprovedBy = @app where MemoNo = '" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@reason", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Rejected")
            terminate()
        ElseIf LabelControl5.Text = "Leave Request" Then
            query.CommandText = "update db_attrec set ApprovedStatus = 'Rejected', Purpose = @reason, ApprovedBy = @app where MemoNo ='" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@reason", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Rejected")
            leaves()
        ElseIf LabelControl5.Text = "Loans" Then
            query.CommandText = "update db_loan set status = 'Rejected', Reason = @purpose, ApprovedBy = @app where EmployeeCode = '" & TextBox3.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@purpose", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Rejected")
            loans()
        ElseIf LabelControl5.Text = "Other Income" Then
            query.CommandText = "update db_addition set status = 'Rejected', purpose = @purpose, ApprovedBy = @app where MemoNo = '" & Label1.Text & "'"
            query.Parameters.AddWithValue("@app", quer.ToString)
            query.Parameters.AddWithValue("@purpose", fn.ToString)
            query.ExecuteNonQuery()
            MsgBox("Rejected")
            others()
        End If
    End Sub

    Sub trick()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()
        query.CommandText = "insert into db_tmpname " +
                            "(EmployeeCode, Name, Initial)" +
                            "values (@employeecode, @Name, @initial)"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@EmployeeCode", Label1.Text)
        query.Parameters.AddWithValue("@Name", TextBox4.Text)
        query.Parameters.AddWithValue("@initial", "1")
        query.ExecuteNonQuery()
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            If LabelControl5.Text <> "Loans" Then
                param = "And MemoNo='" + GridView1.GetFocusedRowCellValue("MemoNo").ToString() + "'"
            Else
                param = "And EmployeeCode = '" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
            End If
        Catch ex As Exception
        End Try
        Try
            If LabelControl5.Text = "Status Change" Then
                sqlCommand.CommandText = "SELECT * FROM db_statuschange WHERE 1 = 1 " + param.ToString()
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(datatabl)
                If datatabl.Rows.Count > 0 Then
                    Label1.Text = datatabl.Rows(0).Item(0).ToString
                    TextBox4.Text = datatabl.Rows(0).Item(2).ToString
                    TextBox3.Text = datatabl.Rows(0).Item(1).ToString
                End If
            ElseIf LabelControl5.Text = "Termination" Then
                sqlCommand.CommandText = "SELECT * FROM db_terminate WHERE 1 = 1 " + param.ToString()
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(datatabl)
                If datatabl.Rows.Count > 0 Then
                    Label1.Text = datatabl.Rows(0).Item(0).ToString
                    TextBox3.Text = datatabl.Rows(0).Item(3).ToString
                    TextBox4.Text = datatabl.Rows(0).Item(2).ToString
                End If
            ElseIf LabelControl5.Text = "Leave Request" Then
                sqlCommand.CommandText = "SELECT * FROM db_attrec WHERE 1 = 1 " + param.ToString()
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(datatabl)
                If datatabl.Rows.Count > 0 Then
                    Label1.Text = datatabl.Rows(0).Item(0).ToString
                    TextBox3.Text = datatabl.Rows(0).Item(2).ToString
                    TextBox4.Text = datatabl.Rows(0).Item(3).ToString
                End If
            ElseIf LabelControl5.Text = "Loans" Then
                sqlCommand.CommandText = "SELECT * FROM db_loan WHERE 1 = 1 " + param.ToString()
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(datatabl)
                If datatabl.Rows.Count > 0 Then
                    TextBox4.Text = datatabl.Rows(0).Item(0).ToString
                    TextBox3.Text = datatabl.Rows(0).Item(1).ToString
                End If
            ElseIf LabelControl5.Text = "Other Income" Then
                sqlCommand.CommandText = "SELECT a.MemoNo, a.EmployeeCode, b.FullName FROM db_addition a, db_pegawai b WHERE a.EmployeeCode = b.EmployeeCode " + param.ToString()
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(datatabl)
                If datatabl.Rows.Count > 0 Then
                    Label1.Text = datatabl.Rows(0).Item(0).ToString
                    TextBox3.Text = datatabl.Rows(0).Item(1).ToString
                    TextBox4.Text = datatabl.Rows(0).Item(2).ToString
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        'If TextBox1.Text = "" OrElse TextBox2.Text = "" Then
        '    MsgBox("Fill Approvement field")
        'Else
        approvement()
        'TextBox1.Text = ""
        ''TextBox2.Text = ""
        'End If
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        'If TextBox1.Text = "" OrElse TextBox2.Text = "" Then
        '    MsgBox("Fill Approvement field")
        'Else
        rejection()
        '    TextBox1.Text = ""
        '    TextBox2.Text = ""
        'End If
    End Sub

    Dim sch As New StatusChange
    Dim tmnt As New Termination
    Dim leavex As New LeaveRequest

    Sub filter()
        If LabelControl5.Text = "Status Change" Then
            If sch Is Nothing OrElse sch.IsDisposed OrElse sch.MinimizeBox Then
                sch.Close()
                sch = New StatusChange
            End If
            sch.Show()
        ElseIf LabelControl5.Text = "Termination" Then
            If tmnt Is Nothing OrElse tmnt.IsDisposed OrElse tmnt.MinimizeBox Then
                tmnt.Close()
                tmnt = New Termination
            End If
            tmnt.Show()
        ElseIf LabelControl1.Text = "Leave Request" Then
            If leavex Is Nothing OrElse leavex.IsDisposed OrElse leavex.MinimizeBox Then
                leavex.Close()
                leavex = New LeaveRequest
            End If
            leavex.Show()
        ElseIf LabelControl5.Text = "Loans" Then
        Else
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        trick()
        filter()
    End Sub

    Sub loans()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select FullName, EmployeeCode, Dates, AmountOfLoan, FromMonths, PaymentPerMonth, CompletedOn, ApprovedBy, Status From db_loan where Status = 'Requested'"
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        GridControl1.DataSource = dt
        GridView1.BestFitColumns()
    End Sub

    Sub others()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select a.MemoNo, a.EmployeeCode, b.FullName, a.Tanggal as Dates, a.Period, a.Until, a.Amount, as1 as Sebagai, a.Reason, a.ApprovedBy, a.Status  from db_addition a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.Status = 'Requested'"
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        GridControl1.DataSource = dt
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        LabelControl5.Text = "Loans"
        GridView1.Columns.Clear()
        loans()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        LabelControl5.Text = "Other Income"
        GridView1.Columns.Clear()
        others()
    End Sub
End Class