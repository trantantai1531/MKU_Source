Imports ComponentArt.Web.UI
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Serial

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class Pages_AcqMagazineTableOfContentsAddValue
        Inherits clsWBase
        Private objBMagazine As New clsBMagazine

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Initialize()
            Call BindScript()
            Try
                If Not IsPostBack Then
                    If Not Request.QueryString("addnew") Is Nothing AndAlso Request.QueryString("addnew") = "0" Then
                        If Not IsNothing(Request("magDetailId")) AndAlso Not Request("magDetailId").Trim = "" Then
                            Dim tblItem As New DataTable
                            objBMagazine.Id = CInt(Request("magDetailId"))
                            tblItem = objBMagazine.getManazineTOCByID
                            If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                                For i As Integer = 0 To tblItem.Rows.Count - 1
                                    If Not IsDBNull(tblItem.Rows(i).Item("SubjectName")) AndAlso tblItem.Rows(i).Item("SubjectName").ToString <> "" Then
                                        txtSubject.Text = tblItem.Rows(i).Item("SubjectName")
                                    Else
                                        txtSubject.Text = ""
                                    End If
                                    If Not IsDBNull(tblItem.Rows(i).Item("AuthorName")) AndAlso tblItem.Rows(i).Item("AuthorName").ToString <> "" Then
                                        txtAuthor.Text = tblItem.Rows(i).Item("AuthorName")
                                    Else
                                        txtAuthor.Text = ""
                                    End If
                                    If Not IsDBNull(tblItem.Rows(i).Item("Overview")) AndAlso tblItem.Rows(i).Item("Overview").ToString <> "" Then
                                        txtTableofcontents.Text = tblItem.Rows(i).Item("Overview")
                                    Else
                                        txtTableofcontents.Text = ""
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub


        ' BindScript method
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init for objBPeriodicalCollection
            objBMagazine.InterfaceLanguage = Session("InterfaceLanguage")
            objBMagazine.DBServer = Session("DBServer")
            objBMagazine.ConnectionString = Session("ConnectionString")
            objBMagazine.Initialize()
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBMagazine Is Nothing Then
                    objBMagazine.Dispose(True)
                    objBMagazine = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

