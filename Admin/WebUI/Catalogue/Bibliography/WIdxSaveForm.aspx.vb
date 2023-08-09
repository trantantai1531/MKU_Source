Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIDXSaveForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTypeView As System.Web.UI.WebControls.Label
        Protected WithEvents ddlTypeView As System.Web.UI.WebControls.DropDownList
        Protected WithEvents tblDisplay As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tblForm As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBTemp As New clsBTemplate
        Private objBGenIdx As New clsBGenIdx
        Private objBIDX As New clsBIDX

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Init all object use in form
            Call Initialize()
            'Bind javascript for all control need
            Call BindJavascript()
            If Not Page.IsPostBack Then
                'Show data on form
                Call LoadData()
            End If
        End Sub

        ' LoadData method
        ' Purpose: Load data for ddlTemplate
        Private Sub LoadData()
            Dim TblTmp As New DataTable

            objBTemp.IDs = ""
            objBTemp.Type = 1
            TblTmp = objBTemp.GetTemplates
            ddlTemplate.DataSource = TblTmp
            ddlTemplate.DataTextField = "Title"
            ddlTemplate.DataValueField = "ID"
            ddlTemplate.DataBind()
        End Sub

        'Bind javascript for all control need
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WIDXViewForm.js'></script>")

            btnReset.Attributes.Add("OnClick", "ResetForm();return(false);")
            Me.SetCheckNumber(txtPageSize, ddlLabel.Items(6).Text, "20")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            objBTemp.InterfaceLanguage = Session("InterfaceLanguage")
            objBTemp.DBServer = Session("DbServer")
            objBTemp.ConnectionString = Session("ConnectionString")
            objBTemp.Initialize()

            objBGenIdx.InterfaceLanguage = Session("InterfaceLanguage")
            objBGenIdx.DBServer = Session("DbServer")
            objBGenIdx.ConnectionString = Session("ConnectionString")
            objBGenIdx.Initialize()

            objBIDX.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDX.DBServer = Session("DbServer")
            objBIDX.ConnectionString = Session("ConnectionString")
            objBIDX.Initialize()
        End Sub

        ' WriteIDX method
        Private Sub WriteIDX()
            Dim ArrIDX()
            Dim intCount As Integer
            Dim intCurPg As Integer
            Dim arrLabel() As String = {"", "", "", "", "", "", "", ""}
            Dim intIDIDX As Integer
            Dim TblIDX As New DataTable
            Dim strGrpBy As String
            Dim strContent As String = ""
            Dim intTotalPage As Integer
            Dim inti As Integer


            If CStr(Request.QueryString("intIDXID")) <> "" Then
                intIDIDX = CInt(Request.QueryString("intIDXID"))
            Else
                intIDIDX = 0
            End If
            objBIDX.IDs = intIDIDX
            objBIDX.UserID = 0
            TblIDX = objBIDX.IDXRetrieve()
            If TblIDX.Rows.Count > 0 Then
                strGrpBy = TblIDX.Rows(0).Item("GroupedBy")
            End If

            objBGenIdx.GroupBy = strGrpBy
            objBGenIdx.IdxID = intIDIDX
            objBGenIdx.TemplateID = ddlTemplate.SelectedValue
            objBGenIdx.TypeView = 1
            objBGenIdx.TypeViewVal = ""
            objBGenIdx.Label = arrLabel


            Call objBGenIdx.Generate3array()
            If Not objBGenIdx.ItemIDArr Is Nothing Then
                If Trim(txtPageSize.Text) <> "" Then
                    objBGenIdx.PageSize = CInt(txtPageSize.Text)
                    intTotalPage = Math.Ceiling(UBound(objBGenIdx.ItemIDArr) / CInt(txtPageSize.Text))
                Else
                    objBGenIdx.PageSize = 20
                    intTotalPage = Math.Ceiling(UBound(objBGenIdx.ItemIDArr) / 20)
                End If
            End If

            strContent = strContent & "<html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""><BODY>"

            'ArrIDX = objBGenIdx.GenerateData(1, True)
            For intCount = 1 To intTotalPage
                ArrIDX = objBGenIdx.GenerateData(intCount)
                For inti = 0 To UBound(ArrIDX)
                    strContent = strContent & ArrIDX(inti)
                Next inti
            Next
            strContent = Replace(Replace(Replace(strContent, "<TABLE CELLPADDING=3 BORDER = 0>", ""), "</TR>", "<BR>"), "<HR>", "<BR>")
            strContent = strContent & "</BODY></HTML>"
            Dim strFile As String = objBGenIdx.SaveFile(strContent, Server.MapPath("../.."))
            If objBGenIdx.ErrorMsg = "Error opening conversion file" Then
                Page.RegisterClientScriptBlock("AlertJs1", "<script language ='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                If strFile <> "" Then
                    lblClick.Visible = True
                    lnkLink.Visible = True
                    lblLinkTail.Visible = True
                    lnkLink.NavigateUrl = "#"
                    lnkLink.Attributes.Add("OnClick", "javascript:self.location.href='../Attach/" & strFile & "';")
                End If
            Else
                lblClick.Visible = True
                lnkLink.Visible = True
                lblLinkTail.Visible = True
                If strFile <> "" Then
                    lnkLink.NavigateUrl = "#"
                    lnkLink.Attributes.Add("OnClick", "javascript:parent.Hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=" & strFile & "';")
                End If
            End If
        End Sub

        'Event: btnSaveToFile_Click
        Private Sub btnSaveToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveToFile.Click
            Call WriteIDX()
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBTemp Is Nothing Then
                        objBTemp.Dispose(True)
                        objBTemp = Nothing
                    End If
                    If Not objBGenIdx Is Nothing Then
                        objBGenIdx.Dispose(True)
                        objBGenIdx = Nothing
                    End If
                    If Not objBIDX Is Nothing Then
                        objBIDX.Dispose(True)
                        objBIDX = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
