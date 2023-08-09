Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OSearch
        Inherits clsWBase

        Private objBOPACItem As New clsBOPACItem
        Private objBSearchQr As New clsBOPACSearchQuery

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not IsPostBack Then
                'Call getSearch()
            End If
        End Sub

        ' purpose : Init all objects
        Private Sub Initialize()

            ' Init objBOPACItem object
            objBOPACItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACItem.DBServer = Session("DBServer")
            objBOPACItem.ConnectionString = Session("ConnectionString")
            Call objBOPACItem.Initialize()

            ' init objBSearchQr object
            objBSearchQr.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchQr.DBServer = Session("DBServer")
            objBSearchQr.ConnectionString = Session("ConnectionString")
            objBSearchQr.Initialize()

            If Session("SecuredOPAC") & "" <> "" Then
                objBSearchQr.SecuredOPAC = True
            Else
                objBSearchQr.SecuredOPAC = False
            End If

            If clsSession.GlbUserLevel & "" <> "" Then
                objBSearchQr.AccessLevel = clsSession.GlbUserLevel
            End If
        End Sub

        Private Sub getSearch()
            Try
                Dim strSearch As String = ""
                If Not IsNothing(Request("txtSearch")) Then
                    strSearch = Request("txtSearch").Trim
                    Call CreateArray(strSearch)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub CreateArray(ByVal strSearch As String)
            Dim arrValue() As String
            Dim arrName() As String
            Dim arrBool() As String
            Dim intCount As Integer
            Dim colData As New Collection
            Dim strSort As String

            intCount = 0
            If strSearch <> "" Then
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)

                arrValue(intCount) = "%" & strSearch & "%"

                arrName(intCount) = "fulltext"
                arrBool(intCount) = "AND"
                intCount = intCount + 1

                strSort = ""
                colData.Add("", "SortBy")

                objBSearchQr.SortBy = strSort
                objBSearchQr.NameArray = arrName
                objBSearchQr.ValueArray = arrValue
                objBSearchQr.BoolArray = arrBool
                objBSearchQr.SearchMode = "ADVANCE"
                colData.Add("ADVANCE", "SearchMode")
                'If optISBD.Checked Then
                '    colData.Add("ISBD", "Display")
                'Else

                'End If
                colData.Add("Simple", "Display")

                Session("colSearch") = colData
                clsSession.GlbIds = objBSearchQr.ExecuteQuery()
            End If

            'If Not clsSession.GlbIds Is Nothing AndAlso CType(clsSession.GlbIds, DataTable).Rows.Count > 0 Then
            '    'Response.Redirect("WShowResult.aspx", True)
            '    Response.Redirect(String.Format("{0}", "WShowresult.aspx"), False)
            'Else
            '    Page.RegisterClientScriptBlock("AlertMsg", "<script language='javascript'>alert('" & spMsgNotFound.InnerText & "')</script>")
            'End If
            Response.Redirect(String.Format("{0}", "OShow.aspx"), False)
        End Sub

    End Class
End Namespace
