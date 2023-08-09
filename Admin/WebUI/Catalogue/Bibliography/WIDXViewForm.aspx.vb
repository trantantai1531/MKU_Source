Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIDXViewForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlAboutAction As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCT As New clsBCommonTemplate
        Private objBGenIdx As New clsBGenIdx
        Private objBIDX As New clsBIDX

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call LoadData()
                Select Case CStr(Request.QueryString("intTypeview") & "")
                    Case "2" ' GrpName
                        ddlTypeView.SelectedIndex = 1
                    Case "3" ' GrpID
                        ddlTypeView.SelectedIndex = 2
                        txtTypeViewID.Text = Request.QueryString("intIDXID")
                    Case Else ' All
                        ddlTypeView.SelectedIndex = 0
                End Select
            End If
            Page.RegisterClientScriptBlock("JSDisplay", "<script language= 'javascript'>parent.Sentform.Form1.style.display='none';</script>")
        End Sub

        ' Initialize method
        ' Purpose: Init all object use in form
        Private Sub Initialize()
            'Object objBCT
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DbServer")
            objBCT.ConnectionString = Session("ConnectionString")
            Call objBCT.Initialize()

            'Object objBGenIdx
            objBGenIdx.InterfaceLanguage = Session("InterfaceLanguage")
            objBGenIdx.DBServer = Session("DbServer")
            objBGenIdx.ConnectionString = Session("ConnectionString")
            Call objBGenIdx.Initialize()

            ' Init objBIDX
            objBIDX.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDX.DBServer = Session("DbServer")
            objBIDX.ConnectionString = Session("ConnectionString")
            objBIDX.Initialize()
        End Sub

        ' Method: LoadData
        ' Purpose: Get data for view catalog
        Private Sub LoadData()
            Dim tblTemplate As New DataTable

            ' Load template
            objBCT.TemplateType = 1
            objBCT.LibID = clsSession.GlbSite
            tblTemplate = objBCT.GetTemplate
            'Show data
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    ddlTemplate.DataSource = tblTemplate
                    ddlTemplate.DataTextField = "Title"
                    ddlTemplate.DataValueField = "ID"
                    ddlTemplate.DataBind()
                End If
            End If

            ' Load type view
            Dim arrT() As String = {ddlLabel.Items(0).Text, ddlLabel.Items(4).Text, ddlLabel.Items(3).Text}
            Dim arrV() As Integer = {1, 2, 3}
            tblTemplate = CreateTable(arrT, arrV)
            'Show data
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    ddlTypeView.DataSource = tblTemplate
                    ddlTypeView.DataTextField = "TextField"
                    ddlTypeView.DataValueField = "ValueField"
                    ddlTypeView.DataBind()
                End If
            End If

            tblTemplate = Nothing
        End Sub

        ' BindJS method
        ' Purpose: Bind javascript for all control need
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WIDXViewForm.js'></script>")

            btnView.Attributes.Add("OnClick", "return ValidView('" & ddlLabel.Items(2).Text & "')")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset();")
            Me.SetCheckNumber(txtPageSize, ddlLabel.Items(1).Text, "20")
        End Sub

        ' btnView_Click event
        ' Purpose: Show data
        Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
            ' Declare variables
            Dim strGrpBy As String = ""
            Dim tblIndex As New DataTable
            Dim colPara As New Collection
            Dim intIDIDX As Integer
            Dim intType As Integer
            Dim intTemplateID As Integer = ddlTemplate.SelectedValue
            Dim intTypeView As Integer = ddlTypeView.SelectedValue
            Dim strTypeViewVal As String = txtTypeViewID.Text & ""
            Dim intPageSize As Integer = txtPageSize.Text & ""
            Dim strJS As String

            Session("colPara") = colPara
            Session("colPara") = Nothing

            If CStr(Request.QueryString("intID")) & "" <> "" And Not Request.QueryString("intTypeview") & "" = "" Then
                intIDIDX = CInt(Request.QueryString("intID"))
            Else
                If CStr(Request.QueryString("intIDXID")) & "" <> "" Then
                    intIDIDX = CInt(Request.QueryString("intIDXID"))
                Else
                    intIDIDX = 0
                End If
            End If

            ' Add to collection
            colPara.Add(intIDIDX, "intIDXID")
            colPara.Add(intTemplateID, "intTemplateID")
            colPara.Add(intTypeView, "intTypeView")
            colPara.Add(strTypeViewVal, "strTypeViewVal")
            colPara.Add(intPageSize, "intPageSize")

            ' Display by Group
            If CStr(Request.QueryString("intID")) & "" <> "" Then
                objBIDX.IDs = CStr(Request.QueryString("intID"))
            Else
                ' Display all group in biography
                objBIDX.IDs = colPara.Item("intIDXID")
            End If

            objBIDX.UserID = 0
            tblIndex = objBIDX.IDXRetrieve()
            If Not tblIndex Is Nothing Then
                If tblIndex.Rows.Count > 0 Then
                    strGrpBy = tblIndex.Rows(0).Item("GroupedBy")
                End If
            End If
            colPara.Add(strGrpBy, "strGrpBy")

            ' Generate 3 array 
            ' Display by Group
            If CStr(Request.QueryString("intID")) & "" <> "" Then
                objBGenIdx.IdxID = CStr(Request.QueryString("intID"))
            Else
                ' Display all group in biography
                objBGenIdx.IdxID = colPara.Item("intIDXID")
            End If

            objBGenIdx.TypeView = colPara.Item("intTypeView")
            objBGenIdx.TypeViewVal = colPara.Item("strTypeViewVal")
            Call objBGenIdx.Generate3array()
            colPara.Add(objBGenIdx.IndexArr, "IndexArr")
            colPara.Add(objBGenIdx.ItemIDArr, "ItemIDArr")
            colPara.Add(objBGenIdx.TitleArr, "TitleArr")

            Session("colPara") = colPara
            If IsArray(colPara.Item("ItemIDArr")) And Not (colPara.Item("ItemIDArr") Is Nothing) Then
                If UBound(colPara.Item("ItemIDArr")) >= 0 Then
                    strJS = "parent.Workform.location.href='WIDXView.aspx?intPg=1';parent.Sentform.location.href='WIDXTaskBar.aspx?intIDXID=" & intIDIDX & "';"
                Else
                    strJS = "alert('" & ddlLabel.Items(1).Text & "');"
                End If
            Else
                strJS = "alert('" & ddlLabel.Items(1).Text & "');"
            End If
            Page.RegisterClientScriptBlock("JSRedirect", "<script language = 'javascript'>" & strJS & "</script>")
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
                    If Not objBCT Is Nothing Then
                        objBCT.Dispose(True)
                        objBCT = Nothing
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