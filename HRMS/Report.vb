Imports System.IO

Public Class Report
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim tbl_par As New DataTable

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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

    Dim lis As New Lists

    Sub showallemp()
        Dim showemps As MySqlCommand = SQLConnection.CreateCommand
        showemps.CommandText = "select EmployeeCode, FullName, Status, changedate As DateChanged from db_pegawai where changedate between @date1 and @date2 and status = 'active' or status = 'terminate' or status = 'fired'"
        showemps.Parameters.AddWithValue("@date1", DateTimePicker3.Value.Date)
        showemps.Parameters.AddWithValue("@date2", DateTimePicker4.Value)
        Dim tab As New DataTable
        tab.Load(showemps.ExecuteReader)
        lis.GridControl1.DataSource = tab
    End Sub

    Sub showterminate()
        Dim showtmnt As MySqlCommand = SQLConnection.CreateCommand
        showtmnt.CommandText = "select EmployeeCode, FullName, Status, TerminateDate from db_pegawai where terminatedate between @date1 and @date2 and status = 'terminate'"
        showtmnt.Parameters.AddWithValue("@date1", DateTimePicker3.Value.Date)
        showtmnt.Parameters.AddWithValue("@date2", DateTimePicker4.Value)
        Dim dt As New DataTable
        dt.Load(showtmnt.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Sub shownew()
        Dim showtmnt As MySqlCommand = SQLConnection.CreateCommand
        showtmnt.CommandText = "select EmployeeCode, FullName, Position, Status, WorkDate from db_pegawai where workdate between @date1 and @date2 and status = 'Active' and status = 'Training'"
        showtmnt.Parameters.AddWithValue("@date1", DateTimePicker3.Value.Date)
        showtmnt.Parameters.AddWithValue("@date2", DateTimePicker4.Value)
        Dim dt As New DataTable
        dt.Load(showtmnt.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Sub showfire()
        Dim showtmnt As MySqlCommand = SQLConnection.CreateCommand
        showtmnt.CommandText = "select EmployeeCode, FullName, Position, Status, WorkDate from db_pegawai where workdate between @date1 and @date2 and status = 'Fired'"
        showtmnt.Parameters.AddWithValue("@date1", DateTimePicker3.Value.Date)
        showtmnt.Parameters.AddWithValue("@date2", DateTimePicker4.Value)
        Dim dt As New DataTable
        dt.Load(showtmnt.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Sub showrecruit()
        Dim newrec As MySqlCommand = SQLConnection.CreateCommand
        newrec.CommandText = "select IdRec, InterviewTimes, FullName, PlaceOfBirth, Address, Gender, Religion, PhoneNumber, IdNumber, Status, Interviewdate, InterviewDates, Reason from db_recruitment where createddate between @date1 and @date2"
        newrec.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        newrec.Parameters.AddWithValue("@date2", DateTimePicker2.Value)
        Dim dt As New DataTable
        dt.Load(newrec.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Sub izin()
        Dim iz As MySqlCommand = SQLConnection.CreateCommand
        iz.CommandText = "select a.FullName, a.EmployeeCode, b.Reason , b.StartDate, b.EndDate, b.Ket as Keterangan from db_pegawai a, db_attrec b where a.EmployeeCode = b.EmployeeCode and b.startdate between @date1 and @date2 and b.reason = 'Izin'"
        iz.Parameters.AddWithValue("@date1", DateTimePicker5.Value.Date)
        iz.Parameters.AddWithValue("@date2", DateTimePicker6.Value)
        Dim dt As New DataTable
        dt.Load(iz.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Sub sakit()
        Dim skt As MySqlCommand = SQLConnection.CreateCommand
        skt.CommandText = "select a.FullName, a.EmployeeCode, b.Reason , b.StartDate, b.EndDate, b.Ket as Keterangan from db_pegawai a, db_attrec b where a.EmployeeCode = b.EmployeeCode and b.startdate between @date1 and @date2 and b.reason = 'Sakit'"
        skt.Parameters.AddWithValue("@date1", DateTimePicker5.Value.Date)
        skt.Parameters.AddWithValue("@date2", DateTimePicker6.Value)
        Dim dt As New DataTable
        dt.Load(skt.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Sub absen()
        Dim abs As MySqlCommand = SQLConnection.CreateCommand
        abs.CommandText = "select a.FullName, a.EmployeeCode, b.Reason , b.StartDate, b.EndDate, b.Ket as keterangan from db_pegawai a, db_attrec b where a.EmployeeCode = b.EmployeeCode and b.startdate between @date1 and @date2 and b.reason = 'absen'"
        abs.Parameters.AddWithValue("@date1", DateTimePicker5.Value.Date)
        abs.Parameters.AddWithValue("@date2", DateTimePicker6.Value)
        Dim dt As New DataTable
        dt.Load(abs.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Sub salchg()
        Dim change As MySqlCommand = SQLConnection.CreateCommand
        change.CommandText = "select FullName, EmployeeCode, StatusWajibPajak, MemilikiNpwp, BasicRate, Allowance, Incentives, Mealrate, Transport, JaminanKesehatan, Bpjs, JaminanKecelakaanKerja, JaminanKematian, JaminanHariTua, IuranPensiun, BiayaJabatan, Rapel, Loan, SalaryType, ChangeDate, ChangeBy from db_salarychange where changedate between @date1 and @date2"
        change.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        change.Parameters.AddWithValue("@date2", DateTimePicker8.Value)

        Dim bpjs As MySqlCommand = SQLConnection.CreateCommand
        bpjs.CommandText = "select bpjs from db_salarychange where changedate between @date1 and @date2"
        bpjs.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        bpjs.Parameters.AddWithValue("@date2", DateTimePicker8.Value.Date)
        Dim realbpjs As String = DirectCast(bpjs.ExecuteScalar, String)
        Dim bpjstxt As String
        If realbpjs = "1" Then
            bpjstxt = "Yes"
        Else
            bpjstxt = "No"
        End If

        Dim jamkes As MySqlCommand = SQLConnection.CreateCommand
        jamkes.CommandText = "select jaminankesehatan from db_salarychange where changedate between @date1 and @date2"
        jamkes.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        jamkes.Parameters.AddWithValue("@date2", DateTimePicker8.Value.Date)
        Dim realjamkes As String = DirectCast(jamkes.ExecuteScalar, String)
        Dim jamkestxt As String
        If realjamkes = "1" Then
            jamkestxt = "Yes"
        Else
            jamkestxt = "No"
        End If

        Dim jkk As MySqlCommand = SQLConnection.CreateCommand
        jkk.CommandText = "select JaminanKecelakaanKerja from db_salarychange where changedate between @date1 and @date2"
        jkk.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        jkk.Parameters.AddWithValue("@date2", DateTimePicker8.Value.Date)
        Dim realjkk As String = DirectCast(jkk.ExecuteScalar, String)
        Dim jkktxt As String
        If realjkk = "1" Then
            jkktxt = "Yes"
        Else
            jkktxt = "No"
        End If

        Dim jamkem As MySqlCommand = SQLConnection.CreateCommand
        jamkem.CommandText = "select Jaminankematian from db_salarychange where changedate between @date1 and @date2"
        jamkem.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        jamkem.Parameters.AddWithValue("@date2", DateTimePicker8.Value.Date)
        Dim realjamkem As String = DirectCast(jamkem.ExecuteScalar, String)
        Dim jamkemtxt As String
        If realjamkem = "1" Then
            jamkemtxt = "Yes"
        Else
            jamkemtxt = "No"
        End If

        Dim jht As MySqlCommand = SQLConnection.CreateCommand
        jht.CommandText = "select jaminanharitua from db_salarychange where changedate between @date1 and @date2"
        jht.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        jht.Parameters.AddWithValue("@date2", DateTimePicker8.Value)
        Dim realjht As String = DirectCast(jht.ExecuteScalar, String)
        Dim jhttxt As String
        If realjht = "1" Then
            jhttxt = "Yes"
        Else
            jhttxt = "No"
        End If

        Dim iupe As MySqlCommand = SQLConnection.CreateCommand
        iupe.CommandText = "select IuranPensiun from db_salarychange where changedate between @date1 and @date2"
        iupe.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        iupe.Parameters.AddWithValue("@date2", DateTimePicker8.Value)
        Dim realiupe As String = DirectCast(iupe.ExecuteScalar, String)
        Dim iupetxt As String
        If realiupe = "1" Then
            iupetxt = "Yes"
        Else
            iupetxt = "No"
        End If

        Dim bj As MySqlCommand = SQLConnection.CreateCommand
        bj.CommandText = "select BiayaJabatan from db_salarychange where changedate between @date1 and @date2"
        bj.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        bj.Parameters.AddWithValue("@date2", DateTimePicker8.Value)
        Dim realbj As String = DirectCast(bj.ExecuteScalar, String)
        Dim bjtxt As String
        If realbj = "1" Then
            bjtxt = "Yes"
        Else
            bjtxt = "No"
        End If

        Dim rapel As MySqlCommand = SQLConnection.CreateCommand
        rapel.CommandText = "select rapel from db_salarychange where changedate between @date1 and @date2"
        rapel.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        rapel.Parameters.AddWithValue("@date2", DateTimePicker8.Value)
        Dim realrapel As String = DirectCast(rapel.ExecuteScalar, String)
        Dim rapeltxt As String
        If realrapel = "1" Then
            rapeltxt = "Yes"
        Else
            rapeltxt = "No"
        End If

        Dim loan As MySqlCommand = SQLConnection.CreateCommand
        loan.CommandText = "select loan from db_salarychange where changedate between @date1 and @date2"
        loan.Parameters.AddWithValue("@date1", DateTimePicker7.Value.Date)
        loan.Parameters.AddWithValue("@date2", DateTimePicker8.Value)
        Dim realloan As String = CStr(loan.ExecuteScalar)
        Dim loantxt As String
        If realloan = "1" Then
            loantxt = "Yes"
        Else
            loantxt = "No"
        End If
        Dim dt As New DataTable
        dt.Load(change.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If RadioButton4.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            showterminate()
            lis.Show()
        ElseIf RadioButton5.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            shownew()
            lis.Show()
        ElseIf radiobutton6.checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            showfire()
            lis.Show()
        ElseIf RadioButton7.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            showallemp()
            lis.Show()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If RadioButton1.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            showrecruit()
            lis.Show()
        End If
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        If RadioButton10.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            sakit()
            lis.Show()
        ElseIf RadioButton11.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            izin()
            lis.Show()
        ElseIf RadioButton12.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            absen()
            lis.Show()
        End If
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        If RadioButton13.Checked = True Then
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis = New Lists
            End If
            salchg()
            lis.Show()
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        recruitment.Show()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        employee.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        attendance.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        payroll.Show()
    End Sub
End Class