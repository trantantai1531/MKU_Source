Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WReceiveUnlock
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
        Private objBCopyNumber As New clsBCopyNumber
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckPemissions()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckPemission method
        Private Sub CheckPemissions()
            ' Check permisssion
            If Not CheckPemission(116) Then
                Call WriteErrorMssg(ddlLabel.Items(6).Text)
            End If
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

            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.Initialize()
        End Sub
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WReceiveUnlock.js'></script>")
            btnReceiveUnlock.Attributes.Add("Onclick", "javascript:return(CheckMoveLocation('" & ddlLabel.Items(4).Text & "'))")
        End Sub
        Private Sub BindData()
            Dim tblLib As DataTable
            objBLib.UserID = Session("UserID")
            objBLib.LibID = 0
            ddlLib.DataSource = InsertOneRow(objBLib.GetLibrary, ddlLabel.Items(3).Text)
            ddlLib.DataTextField = "Code"
            ddlLib.DataValueField = "ID"
            ddlLib.DataBind()
        End Sub

        Private Sub ddlLib_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLib.SelectedIndexChanged
            If ddlLib.SelectedValue > 0 Then
                objBLoc.UserID = Session("UserID")
                objBLoc.LocID = 0
                objBLoc.LibID = ddlLib.SelectedValue
                ddlLoc.DataSource = objBLoc.GetLocation
                ddlLoc.DataTextField = "Symbol"
                ddlLoc.DataValueField = "ID"
                ddlLoc.DataBind()
            Else
                objBLoc.UserID = Session("UserID")
                objBLoc.LocID = -1
                objBLoc.LibID = 0
                ddlLoc.DataSource = objBLoc.GetLocation
                ddlLoc.DataTextField = "Symbol"
                ddlLoc.DataValueField = "ID"
                ddlLoc.DataBind()
            End If

        End Sub

        Private Sub btnReceiveUnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceiveUnlock.Click
            Dim strCopyNumberFrom As String
            Dim strCopyNumberTo As String
            Dim intOutPut As Integer
            Dim tblItem As DataTable
            strCopyNumberFrom = txtCopyNumberFrom.Text.Trim
            strCopyNumberTo = txtCopyNumberTo.Text.Trim
            If ddlLib.SelectedValue > 0 Then
                objBCopyNumber.LibID = ddlLib.SelectedValue
                objBCopyNumber.LocID = ddlLoc.SelectedValue
            Else
                objBCopyNumber.LibID = 0
                objBCopyNumber.LocID = 0
            End If

            objBCopyNumber.FromCopyNum = strCopyNumberFrom
            objBCopyNumber.ToCopyNum = strCopyNumberTo
            objBCopyNumber.ReceiveUnlock()
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopyNumber.ErrorMsg, ddlLabel.Items(0).Text, objBCopyNumber.ErrorCode)

            Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(2).Text & "');</script>")
            txtCopyNumberFrom.Text = ""
            txtCopyNumberTo.Text = ""



        End Sub
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
    End Class
End Namespace
