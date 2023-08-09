Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatalogueItemList
        Inherits clsWBase

        ' Declare class variables
        Private objBItemCollection As New clsBItemCollection

        ' Page Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Page.IsPostBack = False Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("Catalog", "<script language = 'javascript' src = '../Js/Catalogue/WCatalogueItemList.js?t=" & String.Format("{0:yyyyMMddHHmmss}", Date.Now) & "'></script>")
        End Sub

        ' BindData Method 
        ' Purpose: Bind the data 
        Private Sub BindData()
            Dim intTopNum As String = Request.QueryString("intTopNum")
            Dim intPage As String = Request.QueryString("intPage")
            Dim tblItemResult As New DataTable
            If Session("Filter") <> 1 Then
                objBItemCollection.TopNum = intTopNum
                objBItemCollection.LibID = clsSession.GlbSite
                tblItemResult = objBItemCollection.GetListOnTopNum("", intPage)

            Else   ' Filtered
                objBItemCollection.TopNum = intTopNum
                objBItemCollection.LibID = clsSession.GlbSite
                tblItemResult = objBItemCollection.GetListOnTopNum(Session("sqlFilter"), intPage)
            End If

            If Not tblItemResult Is Nothing AndAlso tblItemResult.Rows.Count > 0 Then
                Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                newColumn.DefaultValue = "1"
                tblItemResult.Columns.Add(newColumn)
                Dim indexRows As Integer = ((intPage - 1) * intTopNum) + 1
                For Each rows As DataRow In tblItemResult.Rows
                    If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                        rows.Item("STT") = indexRows.ToString()
                        indexRows = indexRows + 1
                    End If
                Next

                grdProperty.DataSource = tblItemResult
                grdProperty.DataBind()
            End If

        End Sub

        Protected Sub grdProperty_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdProperty.RowCommand
            Dim rowIndex As Integer = CInt(e.CommandArgument.ToString())
            Dim intID As Integer = CInt(grdProperty.DataKeys(rowIndex)("ID"))
            If (e.CommandName = "Delete") Then
                objBItemCollection.ItemIDs = intID
                Dim tblItem As DataTable = objBItemCollection.RetrieveCode_Title()
                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    If tblItem.Rows(0).Item("Nor") = 0 Then ' If not existing holding copies
                        Dim tmlItem As DataTable = objBItemCollection.GetItemByID(intID)
                        If (tmlItem.Rows.Count > 0) Then
                            Dim valueCode As String = tmlItem.Rows(0).Item("Code").ToString
                            Dim firstCodeItem As String = objBItemCollection.GenFirstCodeItem()
                            Dim idBookCode As Integer = Integer.Parse(valueCode.Substring(firstCodeItem.Length))

                            objBItemCollection.DeleteBookCodeByCode(idBookCode)
                            objBItemCollection.DeleteItem()

                            Page.RegisterClientScriptBlock("JSLoadBack", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text.Trim & "');</script>")
                            Page.RegisterClientScriptBlock("JSLoadControlBar", "<script language='javascript'>LoadControlBar();</script>")

                        Else
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('Lỗi xóa bản ghi biên mục');</script>")
                        End If
                    Else
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text.Trim & "');</script>")
                    End If
                Else
                    Dim tmlItem As DataTable = objBItemCollection.GetItemByID(intID)
                    If (tmlItem.Rows.Count > 0) Then
                        Dim valueCode As String = tmlItem.Rows(0).Item("Code").ToString
                        Dim firstCodeItem As String = objBItemCollection.GenFirstCodeItem()
                        Dim idBookCode As Integer = Integer.Parse(valueCode.Substring(firstCodeItem.Length))

                        objBItemCollection.DeleteBookCodeByCode(idBookCode)
                        objBItemCollection.DeleteItem()

                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text.Trim & "');</script>")
                        Page.RegisterClientScriptBlock("JSLoadControlBar", "<script language='javascript'>LoadControlBar();</script>")

                    Else
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('Lỗi xóa bản ghi biên mục');</script>")
                    End If
                End If
            End If

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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub grdProperty_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdProperty.RowDataBound
            For i = 0 To grdProperty.Rows.Count - 1
                Dim hidID As Integer = CInt(grdProperty.DataKeys(i).Value.ToString())
                Dim linkView As HyperLink = CType(grdProperty.Rows(i).FindControl("linkView"), HyperLink)
                linkView.Attributes.Add("onclick", "OpenProperty(" & hidID & ")")
                linkView.Attributes.Add("href", "javascript:void('" & hidID & "')")

                Dim btnDelete As Button = CType(grdProperty.Rows(i).FindControl("btnDelete"), Button)
                btnDelete.OnClientClick = String.Format("return DeleteItem('{0}');", linkView.Text)

                Dim hidCurrentID As HiddenField = CType(grdProperty.Rows(i).FindControl("CurrentID"), HiddenField)
                Dim hidFormID As HiddenField = CType(grdProperty.Rows(i).FindControl("FormID"), HiddenField)
                Dim hidItemID As HiddenField = CType(grdProperty.Rows(i).FindControl("ItemID"), HiddenField)

                Dim btnEdit As LinkButton = CType(grdProperty.Rows(i).FindControl("btnEdit"), LinkButton)
                btnEdit.OnClientClick = String.Format("javascript:ChangeToModifyPage('" & hidCurrentID.Value & "', '" & hidItemID.Value & "', '" & hidFormID.Value & "'); return false;")

                Dim btnCopy As LinkButton = CType(grdProperty.Rows(i).FindControl("btnCopy"), LinkButton)
                btnCopy.OnClientClick = String.Format("javascript:ChangeToReusePage('" & hidCurrentID.Value & "', '" & hidItemID.Value & "', '" & hidFormID.Value & "'); return false;")
            Next
        End Sub

        Protected Sub grdProperty_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdProperty.RowDeleting
            grdProperty.EditIndex = -1
            Call BindData()
        End Sub

    End Class
End Namespace

