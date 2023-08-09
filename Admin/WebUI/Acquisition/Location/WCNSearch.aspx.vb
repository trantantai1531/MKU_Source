Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCNSearch
        Inherits clsWBase

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

        Private objBLib As New clsBLibrary
        Private objBLoc As New clsBLocation

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        Private Sub BindData()
            Dim tblTemp As DataTable
            ' set default value
            Session("CallNumber") = ""
            Session("CopyNumber") = ""
            Session("Volume") = ""
            Session("Title") = ""

            objBLib.UserID = Session("UserID")
            objBLib.LibID = clsSession.GlbSite
            tblTemp = objBLib.GetLibrary
            tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(0).Text)
            ddlLib.DataSource = tblTemp
            ddlLib.DataTextField = "Code"
            ddlLib.DataValueField = "ID"
            ddlLib.DataBind()

            'objBLoc.UserID = Session("UserID")
            'objBLoc.LocID = 0
            'objBLoc.LibID = ddlLib.SelectedValue
            'ddlLoc.DataSource = objBLoc.GetLocation
            'ddlLoc.DataTextField = "Symbol"
            'ddlLoc.DataValueField = "ID"
            'ddlLoc.DataBind()
        End Sub

        Private Sub Initialize()
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            objBLoc.Initialize()

            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            objBLib.Initialize()
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Session("CallNumber") = Trim(txtCallNumber.Text & "")
            Session("CopyNumber") = Trim(txtCopyNumber.Text & "")
            Session("Volume") = Trim(txtVolume.Text & "")
            Session("Title") = Trim(txtTitle.Text & "")
            Session("ItemCode") = Trim(txtItemCode.Text & "")
            Session("Author") = Trim(txtAuthor.Text & "")
            Select Case Trim(Request.QueryString("Mode") & "")
                Case "1"
                    Response.Redirect("WProcInventory.aspx?search=1&LibID=" & ddlLib.SelectedValue & "&LocID=" & ddlLoc.SelectedValue & "&shelf=" & txtShelf.Text)
                Case "2"
                    Response.Redirect("WProcLost.aspx?search=1&LibID=" & ddlLib.SelectedValue & "&LocID=" & ddlLoc.SelectedValue & "&shelf=" & txtShelf.Text)
                Case Else
                    Response.Redirect("WProcReceive.aspx?search=1&LibID=" & ddlLib.SelectedValue & "&LocID=" & ddlLoc.SelectedValue & "&shelf=" & txtShelf.Text)
            End Select
        End Sub

        'Private Sub ddlLib_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    If ddlLib.SelectedValue = 0 Then
        '        ddlLoc.DataSource = ""
        '        ddlLoc.DataBind()
        '    Else
        '        objBLoc.UserID = Session("UserID")
        '        objBLoc.LocID = 0
        '        objBLoc.LibID = ddlLib.SelectedValue
        '        ddlLoc.DataSource = objBLoc.GetLocation
        '        ddlLoc.DataTextField = "Symbol"
        '        ddlLoc.DataValueField = "ID"
        '        ddlLoc.DataBind()
        '    End If
        'End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLoc Is Nothing Then
                    objBLoc.Dispose(True)
                    objBLoc = Nothing
                End If
                If Not objBLib Is Nothing Then
                    objBLib.Dispose(True)
                    objBLib = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


        Private Sub ddlLib_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLib.SelectedIndexChanged
            If ddlLib.SelectedValue = 0 Then
                ddlLoc.DataSource = ""
                ddlLoc.DataBind()
            Else
                objBLoc.UserID = Session("UserID")
                objBLoc.LocID = 0
                objBLoc.LibID = ddlLib.SelectedValue
                ddlLoc.DataSource = objBLoc.GetLocation
                ddlLoc.DataTextField = "Symbol"
                ddlLoc.DataValueField = "ID"
                ddlLoc.DataBind()
            End If
        End Sub
    End Class
End Namespace