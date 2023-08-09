Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Path
Imports System.Web.Services

Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OLibrarySubject
        Inherits clsWBaseJqueryUI

        Private objBLibrarySubject As New clsBLibrarySubject
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
        Public Shared Function GetSubject(ByVal prefix As String) As String()
            Dim ctx As HttpContext = System.Web.HttpContext.Current
            Dim objBLibrarySubject1 As New clsBLibrarySubject
            objBLibrarySubject1.InterfaceLanguage = ctx.Session("InterfaceLanguage")
            objBLibrarySubject1.DBServer = ctx.Session("DBServer")
            objBLibrarySubject1.ConnectionString = ctx.Session("ConnectionString")
            Call objBLibrarySubject1.Initialize()
            Dim data As New List(Of String)()

            Dim result As DataTable = objBLibrarySubject1.GetSubjectByName(prefix)
            For Each item As DataRow In result.Rows
                data.Add(String.Format("{0}------", item("Subject")))
            Next
            Return data.ToArray()
        End Function


        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()

            ' Init objBHoldingInfo object
            objBLibrarySubject.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBLibrarySubject.DBServer = Session("DBServer")
            objBLibrarySubject.ConnectionString = Session("ConnectionString")
            Call objBLibrarySubject.Initialize()

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
                If Not objBLibrarySubject Is Nothing Then
                    objBLibrarySubject.Dispose(True)
                    objBLibrarySubject = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub btnSearchVocabulary_Click(sender As Object, e As EventArgs) Handles btnSearchVocabulary.Click
            lblMean.Text = "Từ vựng không có trong cơ sở dữ liệu"
            Dim tblTemp As DataView = Nothing
            Dim strResult As String = ""
            Dim result As DataTable = objBLibrarySubject.GetSubjectByName(txtSearchVocabulary.Text)
            'If Not result Is Nothing AndAlso result.Rows.Count > 0 Then

            '    lblMean.Text = result.Rows(0).Item("Subj")

            'End If
            Dim strIconCss = " class=""mif-shareable"" "
            'result = objBLibrarySubject.GetAllSubject()
            If Not result Is Nothing AndAlso result.Rows.Count > 0 Then
                strResult = getCollections(result.DefaultView, strIconCss)
                lblMean.Text = ""
            Else

            End If


            ltrList.Text = strResult
        End Sub



        Private Function getCollections(ByVal dv As DataView, Optional strIconCss As String = "") As String
            Dim strResult As String = ""
            Try
                strResult &= "<h3> </h3>"
                strResult &= "<div id='treeviewCollection' class='treeview' data-role='treeview'>"
                strResult &= "<ul>"
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim boldviewLeaf As Boolean = False
                dv.RowFilter = "ParentID = 0"

                Dim strImageCover As String = ""
                Dim strSearch As String = ""

                If dv.Count > 0 Then
                    dview = dv
                    For Each rowView In dv
                        strImageCover = "Upload/ImageCover/collectionCover.jpg"

                        dview.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dview.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dview.RowFilter = ""
                        If boldviewLeaf Then
                            strResult &=
                                  "<li  class='node '><span class='leaf' >" & "&nbsp;" & clsUICommon.HightLightText(rowView.Item("Subject"), strSearch) & " </span>"
                            Call getCollectionsChild(dview, rowView.Item("ID"), strResult, strSearch)
                            strResult &= "</li>"
                        Else
                            strResult &=
                                  "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' >" & "<img src='" + strImageCover + "' class='icon' style='width:10%;heigth:10%;'/>&nbsp;" & clsUICommon.HightLightText(rowView.Item("Subject"), strSearch) & "&nbsp; <span class='mif-books fg-emerald'></span></span>"
                            Call getCollectionsChild(dview, rowView.Item("ID"), strResult, strSearch)
                            strResult &= "</li>"
                        End If
                        'strResult &=
                        '            "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' >" & "<img src='" + strImageCover + "' class='icon' style='width:10%;heigth:10%;'/>&nbsp;" & clsUICommon.HightLightText(rowView.Item("Subject"), strSearch) & " <span class='mif-books fg-emerald'></span></span>"
                        'Call getCollectionsChild(dview, rowView.Item("ID"), strResult, strSearch)
                        'strResult &= "</li>"

                    Next
                End If
                strResult &= "</ul>" 'Close treeview
                strResult &= "</div>" 'Close div
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function

        Private Sub getCollectionsChild(ByVal dv As DataView, ByVal intLevel As Integer, ByRef strResultOut As String, ByVal strSearch As String)
            Try
                dv.RowFilter = "ParentID = " & intLevel
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim dviewLeaf As DataView
                Dim boldviewLeaf As Boolean = False

                Dim strTempImageCoverTemp As String = ""
                If dv.Count > 0 Then
                    dview = dv
                    dviewLeaf = dv
                    strResultOut &= "<ul>"
                    For Each rowView In dv

                        dviewLeaf.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dviewLeaf.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dviewLeaf.RowFilter = ""
                        If boldviewLeaf Then
                            strResultOut &= "<li><span class='leaf'>" & clsUICommon.HightLightText(rowView.Item("Subject"), strSearch) & " </span>"
                            strResultOut &= "</li>"
                        Else
                            strResultOut &= "<li  class='node collapsed'><span class='node-toggle'></span>" & clsUICommon.HightLightText(rowView.Item("Subject"), strSearch) & "&nbsp;<span class='leaf' ><span class='mif-books fg-emerald'></span></span>"
                            Call getCollectionsChild(dview, rowView.Item("ID"), strResultOut, strSearch)
                            strResultOut &= "</li>"
                        End If
                    Next
                    strResultOut &= "</ul>"
                End If
                dv.RowFilter = ""
            Catch ex As Exception
            End Try
        End Sub


    End Class
End Namespace
