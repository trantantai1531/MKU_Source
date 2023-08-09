Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.IO

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WSearch
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Put user code to initialize the page here

            Call Test3()
        End Sub

        Private Sub Test1()

            Dim adapter1 As SqlDataAdapter = New SqlDataAdapter( _
             "SELECT top 100 * FROM PICTURE WHERE MASO IS NULL", "Data Source=192.168.50.123;Initial Catalog=thePhile;UID=sa;PWD=Oanhtn1978;")

            Dim tblTemp As DataTable = New DataTable
            adapter1.Fill(tblTemp)

            ' Test Fisrt picture
            Dim arrPicture() As Byte = CType(tblTemp.Rows(0).Item("picture"), Byte())
            Dim ms As New MemoryStream(arrPicture)
            Dim bmp As New Bitmap(ms)

            ' bmp.GetPropertyItem(1)
            ' bmp.SetResolution(800, 600)
            bmp.Save("C:\Inetpub\wwwroot\Edeliv\Images\Oanhtn1978.gif", System.Drawing.Imaging.ImageFormat.Gif)
            ms = Nothing

            Response.End()
            Dim fs As FileStream = New FileStream("C:\Inetpub\wwwroot\Edeliv\Images\002.gif", FileMode.Open)
            Dim ArrPic As Byte()
            ReDim ArrPic(fs.Length)
            fs.Read(ArrPic, 0, fs.Length())
            fs.Close()

            Dim sqlConn As New SqlConnection("Data Source=192.168.50.123;Initial Catalog=thePhile;UID=sa;PWD=Oanhtn1978;")
            Dim sqlCommand As New sqlCommand

            sqlConn.Open()
            sqlCommand.Connection = sqlConn
            sqlCommand.CommandText = "SP_INSERT_IMAGE"
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New SqlParameter("@imgImage", SqlDbType.Image)).Value = ArrPic
            sqlCommand.ExecuteNonQuery()
            sqlCommand.Dispose()
            sqlConn.Close()
            sqlConn.Dispose()
            sqlConn = Nothing
        End Sub

        Private Sub Test2()
            ' Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\abc.mdb; Jet OLEDB:Database(Password = "")
            ' Dim adapter1 As OleDbDataAdapter = New OleDbDataAdapter("SELECT top 100 * FROM PICTURE WHERE MASO IS NULL", "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=H:\Qlhv.mdb; JetOLEDB:Database Password=")
            Dim adapter1 As OleDbDataAdapter = New OleDbDataAdapter("SELECT MASO, PICTURE FROM PICTURE", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=H:\Qlhv.mdb;")
            ' 
            Dim tblTemp As DataTable = New DataTable
            adapter1.Fill(tblTemp)

            Response.Write("NOR: " & tblTemp.Rows.Count)
        End Sub

        Private Sub Test3()
            Dim intIndex As Integer

            Response.Write("<SPAN class='lbLabel' style='position:absolute;top:230;left: 20px'>" & Chr(10))
            Response.Write("<span id='pgbMain_label'>0%</span><br>" & Chr(10))
            Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=#669999><tr style='HEIGHT: 18px'><td></td></tr></table>" & Chr(10))

            For intIndex = 0 To 100
                Call BindPrg(intIndex, 100)   ' Display the progress bar
            Next

            Response.Write("</SPAN>")
        End Sub

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            Dim strJS As String

            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            If intCurrentPercent Mod 10 = 0 Then
                System.Threading.Thread.Sleep(10000 / intSum)
                strJS = strJS & "<script language=""JavaScript"">" & Chr(10)
                strJS = strJS & "if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%';" & Chr(10)
                strJS = strJS & "if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';" & Chr(10)
                strJS = strJS & "</script>" & Chr(10)
                Response.Write(strJS)
                Response.Flush()
                strJS = ""
            End If
        End Sub
    End Class
End Namespace