Imports ComponentArt.Web.UI
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqTableOfContentsAddValue
        Inherits clsWBase

        Private objBEData As New clsBEData

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not IsPostBack Then
                If Not IsNothing(Request("nodeId")) AndAlso Not Request("nodeId").Trim = "" Then
                    Dim tblData As DataTable
                    objBEData.TocID = Request("nodeId")
                    tblData = objBEData.getTableOfConentsByID
                    If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                        txtTableofcontents.Text = tblData.Rows(0).Item("Name").ToString
                        txtNum.Value = tblData.Rows(0).Item("NumOfPage").ToString
                    End If
                ElseIf Not IsNothing(Request("page")) AndAlso Not Request("page").Trim = "" Then
                    txtNum.Value = Request("page").Trim
                End If
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            Response.Expires = 0
            ' Init objBCSP object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not IsNothing(objBEData) Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace

