Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports System.IO
Imports System
Imports System.Web
Imports System.Web.UI

Namespace eMicLibAdmin.WebUI.Admin
    Public Class WManDatabase
        Inherits System.Web.UI.Page

        Dim objBLogin As New clsBLogin
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
        Dim objBCommon As New clsBCommonDBSystem
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserName As System.Web.UI.WebControls.Label
        Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblPassWord As System.Web.UI.WebControls.Label
        Protected WithEvents txtPassWord As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDataSource As System.Web.UI.WebControls.Label
        Protected WithEvents txtDataSource As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblServerName As System.Web.UI.WebControls.Label
        Protected WithEvents txtServerName As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblServerIP As System.Web.UI.WebControls.Label
        Protected WithEvents txtServerIP As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
        Protected WithEvents ddlLabel As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblDatabase As System.Web.UI.WebControls.Label
        Protected WithEvents ddlDatabase As System.Web.UI.WebControls.DropDownList

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindStyleJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        'Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBUser object
            objBLogin.ConnectionString = Session("ConnectionString")
            objBLogin.DBServer = Session("DBServer")
            objBLogin.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLogin.Initialize()
            objBCommon.ConnectionString = Session("ConnectionString")
            objBCommon.DBServer = Session("DBServer")
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommon.Initialize()
        End Sub

        ' Initialize method
        ' Purpose: Init all style sheet and javascript
        Private Sub BindStyleJS()
            Dim strName As String = "Admin"
            Dim strStyleSheetURL As String
            strName = strName & "." & Session("InterfaceLanguage") & ".css"
            strStyleSheetURL = String.Format(Request.ApplicationPath & "/Resources/StyleSheet/" & strName)
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", strStyleSheetURL))
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim strFilePath As String = ""
            Dim tblTest As DataTable
            Dim objXe As XCrypt.XCryptEngine
            'Put user code to initialize the page here
            Dim strEncript As String = ""

            strFilePath = Server.MapPath("../WLoginDB.xml")
            tblTest = GetXmlFile(strFilePath)
            If Not tblTest Is Nothing AndAlso tblTest.Rows.Count > 0 Then
                If Session("DBServer") = "SQLSERVER" Then
                    txtDataSource.Text = tblTest.Rows(0).Item("DataSource")
                    txtPassWord.Text = tblTest.Rows(0).Item("PassWord")
                    txtServerIP.Text = tblTest.Rows(0).Item("ServerIP")
                    txtServerName.Text = tblTest.Rows(0).Item("ServerName")
                    txtUserName.Text = tblTest.Rows(0).Item("UserName")
                    objXe = New XCrypt.XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.TripleDES)
                    strEncript = objXe.Decrypt(txtPassWord.Text)
                    txtPassWord.Text = strEncript
                Else
                    txtDataSource.Text = tblTest.Rows(1).Item("DataSource")
                    txtPassWord.Text = tblTest.Rows(1).Item("PassWord")
                    txtServerIP.Text = tblTest.Rows(1).Item("ServerIP")
                    txtServerName.Text = tblTest.Rows(1).Item("ServerName")
                    txtUserName.Text = tblTest.Rows(1).Item("UserName")
                    objXe = New XCrypt.XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.TripleDES)
                    strEncript = objXe.Decrypt(txtPassWord.Text)
                    txtPassWord.Text = strEncript
                End If
            End If
        End Sub

        ' Method: ChangeContentLangXml
        ' Purpose: Change data for file type .xml, content change in two language Source and target
        Private Sub ChangeContentXml()
            Dim fs As StreamWriter
            Dim strFilePath As String = ""
            Dim objXe As XCrypt.XCryptEngine
            Dim tblTemp As New DataTable

            ' Update password in database
            objBLogin.UserName = Session("UserNameDB")
            objBLogin.OldPassWord = Session("PassWordDB")
            objBLogin.PassWord = txtPassWord.Text
            objBLogin.UpdatePassUser()

            ' Reset session
            Session("UserNameDB") = txtUserName.Text
            Session("PassWordDB") = txtPassWord.Text
            Session("DataSourceDB") = txtDataSource.Text
            Session("ServerNameDB") = txtServerName.Text
            Session("ServerIPDB") = txtServerIP.Text

            ' Write information about password new to file WLoginDB.xml
            strFilePath = Server.MapPath("../WLoginDB.xml")
            If File.Exists(strFilePath) Then
                tblTemp = GetXmlFile(strFilePath)
                File.Delete(strFilePath)
            End If
            If ddlDatabase.SelectedValue = 0 Then
                fs = File.CreateText(strFilePath)
                fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
                fs.WriteLine("<Head>")
                fs.WriteLine("<data>")
                fs.WriteLine("<UserName>" & Session("UserNameDB") & "</UserName>")
                objXe = New XCrypt.XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.TripleDES)
                fs.WriteLine("<PassWord>" & objXe.Encrypt(Session("PassWordDB")) & "</PassWord>")
                fs.WriteLine("<DataSource>" & Session("DataSourceDB") & "</DataSource>")
                fs.WriteLine("<ServerName>" & Session("ServerNameDB") & "</ServerName>")
                fs.WriteLine("<ServerIP>" & Session("ServerIPDB") & "</ServerIP>")
                fs.WriteLine("<DBServer>" & "SQLSERVER" & "</DBServer>")
                fs.WriteLine("<Run>" & "1" & "</Run>")
                fs.WriteLine("</data>")
                fs.WriteLine("<data>")
                fs.WriteLine("<UserName>" & tblTemp.Rows(1).Item("UserName") & "</UserName>")
                fs.WriteLine("<PassWord>" & tblTemp.Rows(1).Item("PassWord") & "</PassWord>")
                fs.WriteLine("<DataSource>" & tblTemp.Rows(1).Item("DataSource") & "</DataSource>")
                fs.WriteLine("<ServerName>" & tblTemp.Rows(1).Item("ServerName") & "</ServerName>")
                fs.WriteLine("<ServerIP>" & tblTemp.Rows(1).Item("ServerIP") & "</ServerIP>")
                fs.WriteLine("<DBServer>" & tblTemp.Rows(1).Item("DBServer") & "</DBServer>")
                fs.WriteLine("<Run>" & "0" & "</Run>")
                fs.WriteLine("</data>")
                fs.WriteLine("</Head>")
                fs.Close()
                Session("ConnectionString") = "Data Source=" & Session("ServerIPDB") & ";Initial Catalog=" & Session("DataSourceDB") & ";UID=" & Session("UserNameDB") & ";PWD=" & Session("PassWordDB") & ";"
            Else
                fs = File.CreateText(strFilePath)
                fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
                fs.WriteLine("<Head>")
                fs.WriteLine("<data>")
                fs.WriteLine("<UserName>" & tblTemp.Rows(0).Item("UserName") & "</UserName>")
                fs.WriteLine("<PassWord>" & tblTemp.Rows(0).Item("PassWord") & "</PassWord>")
                fs.WriteLine("<DataSource>" & tblTemp.Rows(0).Item("DataSource") & "</DataSource>")
                fs.WriteLine("<ServerName>" & tblTemp.Rows(0).Item("ServerName") & "</ServerName>")
                fs.WriteLine("<ServerIP>" & tblTemp.Rows(0).Item("ServerIP") & "</ServerIP>")
                fs.WriteLine("<DBServer>" & tblTemp.Rows(0).Item("DBServer") & "</DBServer>")
                fs.WriteLine("<Run>" & "0" & "</Run>")
                fs.WriteLine("</data>")
                fs.WriteLine("</Head>")
                fs.WriteLine("<data>")
                fs.WriteLine("<UserName>" & Session("UserNameDB") & "</UserName>")
                objXe = New XCrypt.XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.TripleDES)
                fs.WriteLine("<PassWord>" & objXe.Encrypt(Session("PassWordDB")) & "</PassWord>")
                fs.WriteLine("<DataSource>" & Session("DataSourceDB") & "</DataSource>")
                fs.WriteLine("<ServerName>" & Session("ServerNameDB") & "</ServerName>")
                fs.WriteLine("<ServerIP>" & Session("ServerIPDB") & "</ServerIP>")
                fs.WriteLine("<DBServer>" & "ORACLE" & "</DBServer>")
                fs.WriteLine("<Run>" & "1" & "</Run>")
                fs.WriteLine("</data>")
                fs.Close()
                Session("ConnectionString") = "User ID=" & Session("UserNameDB") & ";Password=" & Session("PassWordDB") & ";Data Source=" & Session("DataSourceDB")
            End If
        End Sub

        Public Function GetXmlFile(ByVal strFileNameXml As String) As DataTable
            ' Use function ConvertTable
            Dim blnReadyFile As Boolean
            blnReadyFile = False
            Dim strName As String = ""
            Dim dsResource As New DataSet
            Try
                dsResource.ReadXml(strFileNameXml)
                If dsResource.Tables.Count > 0 Then
                    GetXmlFile = dsResource.Tables(0)
                    dsResource.Tables.Clear()
                End If
            Catch ex As Exception
            Finally
            End Try
        End Function

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strJs As String
            Call ChangeContentXml()
            Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "');</script>")
            clsSession.GlbUser = ""
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLogin Is Nothing Then
                    objBLogin.Dispose(True)
                    objBLogin = Nothing
                End If
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
