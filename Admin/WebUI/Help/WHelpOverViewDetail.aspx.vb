' purpose : Input Help
' Creator: thaott
' Created Date: 30/Aug/2006
' Modification History: 
Imports eMicLibAdmin.BusinessRules
Namespace eMicLibAdmin.WebUI
    Partial Class WHelpOverViewDetail
        Inherits clsWHelpBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                GetData()
                bindJS()
            End If
        End Sub
        Private Sub bindJS()
            Page.RegisterClientScriptBlock("UaJs", "<script language = 'javascript' src = 'JS/WHelpInput.js'></script>")
        End Sub
        Private Sub GetData()
            If Not Page.IsPostBack Then
                Dim blnLoadFile As String
                Dim strDicID As String
                Dim strTitle As String
                Dim strContent As String
                strTitle = Request.QueryString("Title")
                strContent = Request.QueryString("Content")
                strDicID = Request.QueryString("DicID")
                If IsNothing(strDicID) Then strDicID = Session("ParentID")
                blnLoadFile = Request.QueryString("New")
                If blnLoadFile <> "" Then '--LoadByfile
                    Dim objBHelp As New clsBHelp
                    Dim dtFile As New DataTable
                    Call Initialize(objBHelp)
                    If Session("strPathName") <> "" Then
                        objBHelp.FileURL = Session("strPathName")
                        dtFile = objBHelp.GetHepCatFileByURL()
                        If dtFile.Rows.Count > 0 Then
                            strDicID = dtFile.Rows(0).Item("CatDicID")
                        End If
                    Else
                        strDicID = Session("ParentID")
                    End If
                End If
                LoadData(strDicID, strTitle, strContent)
            End If
        End Sub
        Private Sub LoadData(ByVal intDicID As String, ByVal strTitle As String, ByVal strContent As String)
            Dim objBHelp As New clsBHelp
            Call Initialize(objBHelp)
            Dim dtCatDic As New DataTable
            Dim dtCatDicItem As New DataTable
            Dim dtCatFile As New DataTable
            Dim dtItemLinnk As New DataTable
            Dim inttmpDicID As Integer
            Dim strTmp As String
            '---
            objBHelp.CatDicID = intDicID
            objBHelp.ListCatDicID = intDicID
            If intDicID <> "0" Then
                '--Load content
                dtCatDicItem = objBHelp.GetHepDicItemByID
                If dtCatDicItem.Rows.Count > 0 Then
                    lblContent.Text = dtCatDicItem.Rows(0).Item("HelpContent")
                End If
            End If
            '--Load CatDic           
            objBHelp.Type = Session("HelpLibolType")
            dtCatDic = objBHelp.GetHepCatDicByID
            If dtCatDic.Rows.Count > 0 Then
                lblTitle.Text = dtCatDic.Rows(0).Item("HelpTitle")
            End If
            '--Load LinkItem
            Dim strCatDicID As String = ""
            Dim dtCatDicItemLink As New DataTable
            Dim i As Integer
            If intDicID > 0 Then
                objBHelp.CatDicID = intDicID
                dtItemLinnk = objBHelp.GetHepItemLinkByID
                If dtItemLinnk.Rows.Count > 0 Then
                    For i = 0 To dtItemLinnk.Rows.Count - 1
                        strCatDicID = strCatDicID & dtItemLinnk.Rows(i).Item("CatDicIDLink") & ","
                    Next
                    strCatDicID = Left(strCatDicID, Len(strCatDicID) - 1)
                End If
            End If
            If strCatDicID.Trim <> "" Then
                objBHelp.NotSelectCatDicID = ""
                objBHelp.ListCatDicID = strCatDicID
                dtCatDicItemLink = objBHelp.GetHepCatDicByID
                If dtCatDicItemLink.Rows.Count > 0 Then
                    lblTitleItemLink.Visible = True
                    dtgItemLink.DataSource = dtCatDicItemLink
                    dtgItemLink.DataBind()
                Else
                    lblTitleItemLink.Visible = False
                End If
            Else
                lblTitleItemLink.Visible = False
            End If
        End Sub
        Private Sub Initialize(ByVal obj As clsBHelp)
            ' Init objBHelp object
            obj.InterfaceLanguage = Session("InterfaceLanguage")
            obj.DBServer = Session("DBServer")
            obj.ConnectionString = Session("ConnectionString")
            Call obj.Initialize()
        End Sub

        Private Sub dtgItemLink_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItemLink.ItemCreated
            'Select Case e.Item.ItemType
            Dim lnkTemp As HyperLink
            Dim strLnk As String
            strLnk = "#"
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    lnkTemp = e.Item.FindControl("lnkDetail")
                    lnkTemp.NavigateUrl = strLnk
                    lnkTemp.Attributes.Add("onClick", "parent.right.location.href='WHelpOverViewDetail.aspx?DicID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';")
            End Select
        End Sub
    End Class
End Namespace
