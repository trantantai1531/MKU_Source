Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WControlBarItemList
        Inherits clsWBase

        Private intMinPage As Integer = 1
        Private intMaxPage As Integer = 1

        Private objBItemCollection As New clsBItemCollection

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
            Call BindJS()
        End Sub
        Private Sub BindJS()
            Dim intTopNum As String = Request.QueryString("intTopNum")

            ' Add the attributes for the buttons (navigation and create new)
            btnNext.Attributes.Add("OnClick", "Next(" & intTopNum & "); return false;")
            btnPrev.Attributes.Add("OnClick", "Prev(" & intTopNum & "); return false;")
            btnFirst.Attributes.Add("Onclick", "Home(" & intTopNum & "); return false;")
            btnLast.Attributes.Add("Onclick", "End(" & intTopNum & "); return false;")
            btnCreateNew.Attributes.Add("OnClick", "OpenCreateNewForm(); return false;")

            btnFilter.Attributes.Add("Onclick", "javascript:parent.Workform.location.href = 'WUnifilter.aspx?strFilterView=List'; return false;")
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

        Private Sub BindData()
            Dim intTopNum As String = Request.QueryString("intTopNum")
            Dim tblItemResult As New DataTable
            If Session("Filter") <> 1 Then
                objBItemCollection.TopNum = 0
                objBItemCollection.LibID = clsSession.GlbSite
                tblItemResult = objBItemCollection.GetListOnTopNum("")
            Else   ' Filtered
                objBItemCollection.TopNum = 0
                objBItemCollection.LibID = clsSession.GlbSite
                tblItemResult = objBItemCollection.GetListOnTopNum(Session("sqlFilter"))
            End If

            If Not tblItemResult Is Nothing AndAlso tblItemResult.Rows.Count > 0 Then
                Dim intCountPage As Integer = CInt(tblItemResult.Rows(0).Item("Total")) \ intTopNum
                Dim intMod As Integer = CInt(tblItemResult.Rows(0).Item("Total")) Mod intTopNum
                If intMod > 0 Then
                    intCountPage = intCountPage + 1
                End If
                txtMaxReNum.Text = intCountPage

                txtReNum.Text = 1
                If Not IsNothing(Request.QueryString("intPage")) Then
                    If intCountPage < Request.QueryString("intPage") Then
                        txtReNum.Text = intCountPage
                    Else
                        txtReNum.Text = Request.QueryString("intPage")
                    End If
                End If

                lblJS.Text = "<Script type='text/javascript' language='JavaScript'> parent.Workform.location.href = 'WCatalogueItemList.aspx?intTopNum=" & intTopNum & "&intPage=" & txtReNum.Text & "'; </script>"

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
        Protected Sub btnCancelFil_Click(sender As Object, e As EventArgs) Handles btnCancelFil.Click
            Session("Filter") = 0
            Session("sqlFilter") = ""
            BindData()
        End Sub

    End Class
End Namespace

