' Class: WLocPos
' Puspose: Display, update and delete the map of location
' Creator: Lent
' CreatedDate: 09/03/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review
'   - 09/06/2005 by Oanhtn: fix errors

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports system.IO


Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WLocPos
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

        ' Declare variables
        Private objBLibrary As New clsBLibrary
        Private objBLocation As New clsBLocation
        Private objBCommonDBSystem As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call LoadLibraries()
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(130) Then
                Call WriteErrorMssg(ddlLabelNote.Items(12).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Initialize objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()

            ' Initialize objBCommonDBSystem object
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            objBCommonDBSystem.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonDBSystem.Initialize()

            ipShowImage.Visible = False
            lblHelp1.Visible = False
            lblHelp2.Visible = False
            lblHelp3.Visible = False
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Dim intXimg As Integer = 0
            Dim intYimg As Integer = 0
            Dim intIndex As Integer

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WLocPos.js'></script>")

            ' set value coor on image 
            If Not Request("ipShowImage.x") Is Nothing Then
                ipShowImage.Visible = True
                lblHelp1.Visible = True
                lblHelp2.Visible = True
                lblHelp3.Visible = True

                intXimg = CInt(Request("ipShowImage.x"))
                intYimg = CInt(Request("ipShowImage.y"))
                intIndex = dtgContent.EditItemIndex
                CType(dtgContent.Items(intIndex).Cells(5).FindControl("txtdtgTopCoor"), TextBox).Text = CStr(intYimg)
                CType(dtgContent.Items(intIndex).Cells(6).FindControl("txtdtgLeftCoor"), TextBox).Text = CStr(intXimg)
            End If
        End Sub

        ' Method: LoadLibraries 
        Private Sub LoadLibraries()
            Dim tblResult As DataTable
            Dim listItem As New listItem
            tblResult = objBLibrary.GetLibrary
            'bind data for dropdownlist library
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                ddlLibrary.DataSource = tblResult
                ddlLibrary.DataTextField = "FullName"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
            Else
                listItem.Text = ddlLabelNote.Items(14).Text
                listItem.Value = 0
                ddlLibrary.Items.Add(listItem)
            End If
            ddlLibrary.SelectedIndex = 0
        End Sub


        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intItem As Integer
            Dim intCount As Integer

            ' Bind data for datagrid
            objBLocation.LibID = ddlLibrary.SelectedValue
            objBLocation.LocID = 0
            objBLocation.UserID = Session("UserID")
            tblResult = objBLocation.GetHoldingLocSchema(ddlLabelNote.Items(1).Text)
            dtgContent.Visible = False
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                intCount = Math.Ceiling(tblResult.Rows.Count / dtgContent.PageSize)
                If dtgContent.CurrentPageIndex >= intCount Then
                    dtgContent.CurrentPageIndex = dtgContent.CurrentPageIndex - 1
                End If
                dtgContent.DataSource = tblResult
                dtgContent.DataBind()
                dtgContent.Visible = True
            Else
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabelNote.Items(15).Text.Trim & "');</script>")
            End If
        End Sub

        ' Event: ddlLibrary_SelectedIndexChanged
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            Call BindData()
        End Sub

        ' Event: dtgContent_CancelCommand
        Private Sub dtgContent_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.CancelCommand
            dtgContent.EditItemIndex = -1
            Call BindData()
        End Sub

        ' Event: dtgContent_DeleteCommand
        Private Sub dtgContent_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.DeleteCommand
            objBLocation.LocID = CInt(e.Item.Cells(0).Text)
            Call objBLocation.DeleteLocPosition()
            ' Write log
            Call WriteLog(89, ddlLabelNote.Items(7).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & e.Item.Cells(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Reload form
            dtgContent.EditItemIndex = -1
            Call BindData()
        End Sub

        ' Event: dtgContent_EditCommand
        Private Sub dtgContent_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.EditCommand
            dtgContent.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        ' Event: dtgContent_ItemCreated
        Private Sub dtgContent_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgContent.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem
                    Dim lnkdtgDelete As LinkButton
                    Dim lblShowImgTmp As Label
                    Dim txtdtgTemp As TextBox
                    Dim lnkdtgUpdate As LinkButton

                    lnkdtgDelete = e.Item.Cells(8).Controls(0)
                    lblShowImgTmp = e.Item.FindControl("lbldtgShowImage")

                    If Not lblShowImgTmp Is Nothing Then
                        If IsDBNull(DataBinder.Eval(e.Item.DataItem, "LocID")) Then
                            lblShowImgTmp.Visible = False
                        End If
                    End If
                    If IsDBNull(DataBinder.Eval(e.Item.DataItem, "LocID")) Then
                        lnkdtgDelete.Attributes.Add("Onclick", "alert(' " & ddlLabelNote.Items(2).Text & " ');return false;")
                    Else
                        lnkdtgDelete.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabelNote.Items(0).Text & " ')==false) {swapBG(this,'red');return false}")
                    End If
                    txtdtgTemp = CType(e.Item.FindControl("txtdtgImgWidthMetter"), TextBox)

                    If Not txtdtgTemp Is Nothing Then
                        ' set value for hidden input: hidImgHeight,hidImgWidth 
                        hidImgHeight.Value = DataBinder.Eval(e.Item.DataItem, "ImgHeight")
                        hidImgWidth.Value = DataBinder.Eval(e.Item.DataItem, "ImgWidth")
                        ipShowImage.Visible = True
                        lblHelp1.Visible = True
                        lblHelp2.Visible = True
                        lblHelp3.Visible = True

                        'ipShowImage.Src = ".." & DataBinder.Eval(e.Item.DataItem, "ImgURL")
                        ipShowImage.Src = "..\..\Common\ShowSchemaPicture.aspx?LocID=" & (DataBinder.Eval(e.Item.DataItem, "LocID"))

                        txtdtgTemp.Attributes.Add("onChange", "javascript:if(CheckSizeValue('document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgImgWidthMetter','" & ddlLabelNote.Items(13).Text & "','" & ddlLabelNote.Items(6).Text & "')) CheckRatio(0,'document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & ddlLabelNote.Items(3).Text & "','" & ddlLabelNote.Items(4).Text & "','" & ddlLabelNote.Items(5).Text & "');")
                        txtdtgTemp = CType(e.Item.FindControl("txtdtgImgHeightMetter"), TextBox)
                        txtdtgTemp.Attributes.Add("onChange", "javascript:if(CheckSizeValue('document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgImgHeightMetter','" & ddlLabelNote.Items(13).Text & "','" & ddlLabelNote.Items(6).Text & "')) CheckRatio(1,'document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & ddlLabelNote.Items(3).Text & "','" & ddlLabelNote.Items(4).Text & "','" & ddlLabelNote.Items(5).Text & "');")
                        txtdtgTemp = CType(e.Item.FindControl("txtdtgTopCoor"), TextBox)
                        txtdtgTemp.Attributes.Add("onChange", "javascript:CheckValue('document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgTopCoor','" & ddlLabelNote.Items(13).Text & "','" & ddlLabelNote.Items(6).Text & "');")
                        txtdtgTemp = CType(e.Item.FindControl("txtdtgLeftCoor"), TextBox)
                        txtdtgTemp.Attributes.Add("onChange", "javascript:CheckValue('document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgLeftCoor','" & ddlLabelNote.Items(13).Text & "','" & ddlLabelNote.Items(6).Text & "');")
                    End If

                    lnkdtgUpdate = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkdtgUpdate Is Nothing Then
                        If IsDBNull(DataBinder.Eval(e.Item.DataItem, "LocID")) Then
                            lnkdtgUpdate.Attributes.Add("OnClick", "javascript:return(CheckInserUpdate(0,'document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & ddlLabelNote.Items(13).Text & "','" & ddlLabelNote.Items(6).Text & "'));")
                        Else
                            lnkdtgUpdate.Attributes.Add("OnClick", "javascript:return(CheckInserUpdate(1,'document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & ddlLabelNote.Items(13).Text & "','" & ddlLabelNote.Items(6).Text & "'));")
                        End If
                    End If
            End Select
        End Sub

        ' Event: dtgContent_UpdateCommand
        Private Sub dtgContent_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.UpdateCommand
            Dim intLocID As Integer
            Dim strImgURL As String = ""
            Dim strImgPath As String = ""
            Dim intImgWidth As Integer
            Dim intImgHeight As Integer
            Dim intTopCoor As Integer
            Dim intLeftCoor As Integer
            Dim dbImgWidthMetter As Single
            Dim dbImgHeightMetter As Single
            Dim strVirPath As String = "\Images\Schema\"
            Dim strPath As String = ""
            Dim fldtgImageName As HtmlInputFile
            Dim txtdtgTemp As TextBox
            Dim strFileName As String
            Dim objBitmapLib As New BitmapLibrary.NewIdentifier
            Dim strExt As String

            strPath = Server.MapPath("..")
            intLocID = CInt(e.Item.Cells(0).Text)
            strFileName = "LocSchema" & "_" & CStr(e.Item.Cells(1).Text) & "_" & CStr(intLocID) & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second

            fldtgImageName = CType(e.Item.FindControl("fldtgImageUpload"), HtmlInputFile)
            If fldtgImageName.Value <> "" Then

                strImgURL = strVirPath & UpLoadFiles(fldtgImageName, strPath & strVirPath, strFileName)

                'get infor of image
                If objBitmapLib.SetImage(strPath & strImgURL) = "" Then
                    intImgWidth = objBitmapLib.ImageWidth
                    intImgHeight = objBitmapLib.ImageHeight

                End If
            End If
            objBitmapLib = Nothing

            txtdtgTemp = e.Item.FindControl("txtdtgImgWidthMetter")
            dbImgWidthMetter = CDbl(txtdtgTemp.Text)
            txtdtgTemp = e.Item.FindControl("txtdtgImgHeightMetter")
            dbImgHeightMetter = CDbl(txtdtgTemp.Text)
            txtdtgTemp = e.Item.FindControl("txtdtgTopCoor")
            intTopCoor = CInt(txtdtgTemp.Text)
            txtdtgTemp = e.Item.FindControl("txtdtgLeftCoor")
            intLeftCoor = CInt(txtdtgTemp.Text)

            objBLocation.LocID = intLocID
            objBLocation.ImgURL = strImgURL
            objBLocation.ImgPath = Server.MapPath("..") & strImgURL
            objBLocation.ImgWidth = intImgWidth
            objBLocation.ImgHeight = intImgHeight
            objBLocation.TopCoor = intTopCoor
            objBLocation.LeftCoor = intLeftCoor
            objBLocation.ImgWidthMetter = dbImgWidthMetter
            objBLocation.ImgHeightMetter = dbImgHeightMetter
            If e.Item.Cells(9).Text = "&nbsp;" Then
                ' Create
                Call objBLocation.CreateLocPosition()
                ' Write log
                Call WriteLog(89, ddlLabelNote.Items(10).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & e.Item.Cells(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Else
                ' Update data
                Call objBLocation.UpdateLocPosition()
                ' Writelog
                Call WriteLog(89, ddlLabelNote.Items(11).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & e.Item.Cells(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
            dtgContent.EditItemIndex = -1
            Call BindData()
        End Sub

        ' dtgContent_PageIndexChanged event
        Private Sub dtgContent_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgContent.PageIndexChanged
            dtgContent.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace