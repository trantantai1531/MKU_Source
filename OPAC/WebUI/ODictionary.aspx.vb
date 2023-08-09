Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Path
Imports System.Web.Services
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ODictionary
        Inherits clsWBaseJqueryUI

        Private objBLibraryDictionary As New clsBLibraryDictionary
        Private objBFilterBrowse As New clsBOPACFilterBrowse
        Private objBCommonStringProc As New clsBCommonStringProc

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            lblMean.Text = ""
            If Not Page.IsPostBack Then
                Call resetObject()
            End If
        End Sub

        ' resetObject method
        ' Purpose: delete all Object
        Private Sub resetObject()
            Try
                clsSession.GlbBrowseIds = Nothing
            Catch ex As Exception
            End Try
        End Sub
        <WebMethod()>
        Public Shared Function GetVocabulary(ByVal prefix As String, ByVal type As Integer) As String()
            Dim ctx As HttpContext = System.Web.HttpContext.Current
            Dim objBLibraryDictionary1 As New clsBLibraryDictionary
            objBLibraryDictionary1.InterfaceLanguage = ctx.Session("InterfaceLanguage")
            objBLibraryDictionary1.DBServer = ctx.Session("DBServer")
            objBLibraryDictionary1.ConnectionString = ctx.Session("ConnectionString")
            Call objBLibraryDictionary1.Initialize()
            Dim data As New List(Of String)()
            objBLibraryDictionary1.SearchType = type
            Dim result As DataTable = objBLibraryDictionary1.GetVocabulary(prefix)
            For Each item As DataRow In result.Rows
                data.Add(String.Format("{0}------{1}", item("vocabulary"), item("vocabulary")))
            Next
            Return data.ToArray()
        End Function


        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()

            ' Init objBHoldingInfo object
            objBLibraryDictionary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBLibraryDictionary.DBServer = Session("DBServer")
            objBLibraryDictionary.ConnectionString = Session("ConnectionString")
            Call objBLibraryDictionary.Initialize()

            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()
        End Sub
        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OBrowse.js'></script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBLibraryDictionary Is Nothing Then
                    objBLibraryDictionary.Dispose(True)
                    objBLibraryDictionary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub btnSearchVocabulary_Click(sender As Object, e As EventArgs) Handles btnSearchVocabulary.Click
            lblMean.Text = "Từ vựng không có trong cơ sở dữ liệu"
            objBLibraryDictionary.SearchType = dllDictionaryType.SelectedValue
            Dim result As DataTable = objBLibraryDictionary.GetMeanVocabulary(txtSearchVocabulary.Text)
            If Not result Is Nothing AndAlso result.Rows.Count > 0 Then
                If dllDictionaryType.SelectedValue = 1 Then
                    lblMean.Text = result.Rows(0).Item("Mean")
                Else
                    lblMean.Text = result.Rows(0).Item("EnglishVocabulary")
                End If

            End If
        End Sub
    End Class
End Namespace
