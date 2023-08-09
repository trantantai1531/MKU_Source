Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports System.Web.Services

Namespace eMicLibAdmin.WebUI.Cataloguer
    Partial Class WAddSH
        Inherits clsWBase 'Web.UI.Page 'clsWBase

        Private objBSH As New clsBCatDicSH
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            If Not Page.IsPostBack Then
                If (Not IsNothing(Request("intSHID"))) Then
                    Dim result As Integer = objBSH.InsertSHBibliography(CType(Request("intSHID").ToString(), Integer))
                    If (result = 1) Then
                        'Dim strJava As String = "var x = window.opener.document.getElementById('ddlKeyword');"
                        'strJava = strJava & " var option = window.opener.document.createElement('option');"
                        'strJava = strJava & " option.text = '" & Request("strDisplayEntry").ToString() & "';"
                        'strJava = strJava & " option.value = '" & Request("intKeywordID").ToString() & "';"
                        'strJava = strJava & " x.add(option);"

                        Dim strJava As String = ""
                        strJava = strJava & " alert('Thêm từ khóa vào điều kiện lọc thành công');"
                        strJava = strJava & " window.opener.location.href = 'WCataSH.aspx';"
                        Page.RegisterClientScriptBlock("JSSelf", "<script type='text/javascript'>" & strJava & "</script>")
                    End If
                End If
                Session("pageIndex") = 0
                BindData()
                If Not (String.IsNullOrEmpty(Request("txtSH"))) Then
                    txtSHSearch.Text = Request("txtSH").ToString()
                End If
            End If
        End Sub

        Private Sub BindData()
            Try
                Dim tblResult As DataTable = objBSH.GetAll(If(String.IsNullOrEmpty(Request("txtSH")), "", Request("txtSH").ToString()))

                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                        newColumn.DefaultValue = "1"
                        tblResult.Columns.Add(newColumn)
                        Dim indexRows As Integer = 1
                        For Each rows As DataRow In tblResult.Rows
                            If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                                rows.Item("STT") = indexRows.ToString()
                                indexRows = indexRows + 1
                            End If
                        Next
                    End If
                End If

                dtgPolicy.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                dtgPolicy.DataSource = tblResult
                dtgPolicy.DataBind()
            Catch ex As Exception
            End Try
        End Sub
        Private Sub Initialze()
            objBSH.InterfaceLanguage = Session("InterfaceLanguage")
            objBSH.DBServer = Session("DBServer")
            objBSH.ConnectionString = Session("ConnectionString")
            Call objBSH.Initialize()
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBSH Is Nothing Then
                    objBSH.Dispose(True)
                    objBSH = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub dtgPolicy_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgPolicy.PageIndexChanging
            Session("pageIndex") = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub dtgPolicy_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles dtgPolicy.RowEditing
            dtgPolicy.EditIndex = e.NewEditIndex
            BindData()
        End Sub

        '<WebMethod(True)>
        'Public Shared Function AddKeywordBibliography(ByVal intKeywordID As Integer) As Integer
        '    objBKeywordShare.InterfaceLanguage = HttpContext.Current.Session("InterfaceLanguage")
        '    objBKeywordShare.DBServer = HttpContext.Current.Session("DBServer")
        '    objBKeywordShare.ConnectionString = HttpContext.Current.Session("ConnectionString")
        '    objBKeywordShare.Initialize()
        '    Dim result As Integer = objBKeywordShare.InsertKeywordBibliography(intKeywordID)
        '    Return result
        'End Function

        Protected Sub dtgPolicy_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles dtgPolicy.RowUpdating
            Dim row As GridViewRow = CType(dtgPolicy.Rows(e.RowIndex), GridViewRow)
            Dim hidID As HiddenField = CType(row.FindControl("hidID"), HiddenField)
            Dim txtSHModify As TextBox = CType(row.FindControl("txtSHModify"), TextBox)
            Dim stringConvert As New clsBCommonStringProc

            objBSH.ID = hidID.Value
            objBSH.DisplayEntry = txtSHModify.Text
            objBSH.AccessEntry = txtSHModify.Text.ToUpper()
            objBSH.VietnameseAccent = stringConvert.CutVietnameseAccent(txtSHModify.Text.ToUpper())
            objBSH.Update()
            dtgPolicy.EditIndex = -1
            BindData()
        End Sub

        Protected Sub dtgPolicy_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles dtgPolicy.RowCancelingEdit
            dtgPolicy.EditIndex = -1
            BindData()
        End Sub


        Protected Sub btnSearchSH_Click(sender As Object, e As EventArgs) Handles btnSearchSH.Click
            Response.Redirect("WAddSH.aspx?txtSH=" + txtSHSearch.Text)
        End Sub

        'Protected Sub btnAddKeyword_Click(sender As Object, e As EventArgs) Handles btnAddKeyword.Click

        'End Sub
    End Class
End Namespace
