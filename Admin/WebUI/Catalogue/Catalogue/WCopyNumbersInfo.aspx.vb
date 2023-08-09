Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCopyNumbersInfo
        Inherits clsWBase
        ' Declare variables
        Private objBItemCollection As New clsBItemCollection
        Private objBInput As New clsBInput
        Private objBItem As New clsBItem
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCopyNumber As New clsBCopyNumber
        Private index As String
        Private strItemTopNum As String
        Private strAction As String
        Private strPostID As String
        Private strFormID As String = ""
        Private intType As Integer ' View type


        ' Page Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindVariables()
            Call BindLabel()
            Call BindJS()
            Call BindData()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()

            'Init objBItem
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.IsAuthority = Session("IsAuthority")
            Call objBItem.Initialize()


            'Init objBInput
            objBInput.ConnectionString = Session("ConnectionString")
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            Call objBInput.Initialize()

            ' Init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()
        End Sub

        ' BindVariable method
        ' Purpose: Get the value for the variables
        Private Sub BindVariables()
            index = Request("index")
        End Sub

        ' Bindlabel method
        ' Purpose: Bind the text label for the controls
        Private Sub BindLabel()
            lblMainTitle.Text = ddlLabel.Items(3).Text
            lblMainTitle1.Text = ddlLabel.Items(4).Text
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("Catalog", "<script language = 'javascript' src = '../Js/Catalogue/WCopyNumbersInfo.js'></script>")
        End Sub

        ' BindData Method 
        ' Purpose: Bind the data 
        Private Sub BindData()
            Dim strTempID As String = ""
            Dim tblTemp As New DataTable

            ' Get the IDs string and post to the control bar (if get the top number)
            If index <> "" Then
                Dim copyNumberId As Integer = DirectCast(Session("tblCopyNumberIds"), DataTable).Rows(CInt(index - 1)).Item("ID")
                objBCDBS.SQLStatement = "SELECT ItemID AS ID,CopyNumber FROM Lib_tblHolding WHERE ID=" & copyNumberId
                tblTemp = objBCDBS.RetrieveItemInfor()
                If tblTemp IsNot Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    Dim copyNumber As String = tblTemp.Rows(0).Item("CopyNumber")
                    ' Display the item infor
                    objBItemCollection.LibID = clsSession.GlbSite
                    objBItemCollection.ItemIDs = tblTemp.Rows(0).Item("ID")
                    grdProperty.DataSource = objBItemCollection.GetContents
                    grdProperty.DataBind()
                    tblTemp = objBCopyNumber.GetHolding(tblTemp.Rows(0).Item("ID"))
                    Dim dtv As DataView = tblTemp.DefaultView
                    dtv.RowFilter = "CopyNumber='" & copyNumber & "'"
                    dtgHoldingInfo.DataSource = dtv.ToTable()
                    dtgHoldingInfo.DataBind()
                End If
            End If
        End Sub

        ' grdProperty_ItemCreated event
        ' Purpose: Add attributes for the controls in datagrid
        Private Sub grdProperty_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProperty.ItemCreated
            Dim strJs As String
            Dim tblCell As TableCell
            Dim lnk As HyperLink

            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' alert the content of fields for the view and delete case only
                    If strAction = "View" Or strAction = "Delete" Then
                        ' Not alert with leader and field 001
                        If DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "001" And DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "Ldr" And DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "852" Then
                            ' Get the property of field code to indicate the field having indicator or not

                            tblCell = e.Item.Cells(0)
                            lnk = CType(tblCell.FindControl("lnkFieldCode"), HyperLink)
                            lnk.NavigateUrl = "WCataViewHidden.aspx"
                            Dim strField As String = ""
                            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "FieldCode")) Then
                                strField = CStr(DataBinder.Eval(e.Item.DataItem, "FieldCode")).Trim
                            End If
                            Dim strInd As String = ""
                            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "Ind")) Then
                                strInd = CStr(DataBinder.Eval(e.Item.DataItem, "Ind")).Trim
                            End If
                            Dim strContent As String = ""
                            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "Content")) Then
                                strContent = CStr(DataBinder.Eval(e.Item.DataItem, "Content")).Trim
                            End If
                            strJs = "WCataViewHidden.aspx?FieldCode=" & strField & "&Indicator=" & strInd.Replace("#", "a") & "&FieldValue=" & strContent.Replace("'", "\'")
                            lnk.Target = "Hiddenbase"
                            'lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href='" & strJs & "';"
                            lnk.Attributes.Add("OnClick", "javascript:parent.Hiddenbase.location.href='" & strJs & "';return false;")
                        End If
                    End If
            End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If


                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

