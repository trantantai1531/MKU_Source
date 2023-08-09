Imports System.IO.Path
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqViewer
        Inherits clsWBase 'System.Web.UI.Page
        Protected fXMLPath As String = ""
        Protected fImgTotal As Integer = 0
        Protected fbookPage As Integer = 0

        Protected objSysPara() As String
        Private objPara() As String = {"OPAC_FORUM_URL", "LDAP_LOCATION", "LDAP_SERVER_TYPE", "LDAP_LOGON_USER", "LDAP_LOGON_PASSWORD", "SMTP_SERVER", "ADMIN_EMAIL_ADDRESS", "EDATA_LOCATIONS", "OPAC_URL", "DATE_FORMAT", "OPAC_SERVER_LOCAL", "OPAC_SERVER_PUBLIC", "OPAC_PHYSICAL_PATH", "OPAC_PICTURE_PATH", "ROOT_SITE"}

        Private objBEData As New clsBEData
        Private objBCSP As New clsBCommonStringProc

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                Call Initialize()
                'If Not IsPostBack Then
                Dim strXMLPath As String = ""
                Dim intDocId As Integer = 0
                Dim intFileId As Integer = 0
                If Not IsNothing(Request("DocId")) Then
                    intDocId = Request("DocId")
                End If
                If Not IsNothing(Request("fileId")) Then
                    intFileId = Request("fileId")
                End If
                If Not IsNothing(Request("XMLPath")) Then
                    strXMLPath = Request("XMLPath")
                End If
                If Not IsNothing(Request("Page")) Then
                    fbookPage = Request("Page")
                    If fbookPage > 0 Then
                        fbookPage -= 1
                    End If
                End If
                If intFileId Then
                    'Dim strXMLPath As String = getXMLpath(intDocId, intFileId)
                    fXMLPath = getURL(strXMLPath)
                    fImgTotal = getImageTotal(strXMLPath)
                End If
                'End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub Initialize()
            Response.Expires = 0
            ' Init objBCSP object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()
            'objBEData.FileID = lngObjID
            ' Init BCommonStringProc object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        Private Function getURL(ByVal strPath As String) As String
            'Dim strResult As String = ""
            'Try
            '    Dim _tempDir As String = strPath
            '    _tempDir = Replace(_tempDir, "\", "/")
            '    Dim _XMLViewer_physicalPath As String = Replace(clsCommon._XMLViewer_physicalPath, "\", "/")
            '    Dim _XMLViewer_VirtualPath As String = clsCommon.ChangeMapVirtualPath() ' clsCommon._XMLViewer_VirtualPath
            '    _tempDir = Replace(_tempDir, _XMLViewer_physicalPath, _XMLViewer_VirtualPath)
            '    strResult = Left(_tempDir, InStrRev(_tempDir, "/"))
            'Catch ex As Exception
            'End Try
            'Return strResult

            Dim strResult As String = ""
            Try
                'Dim strVirtualPath As String = ""
                'Dim strPhysicalPath As String = objSysPara(12)
                'If objSysPara(10).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_LOCAL
                '    strVirtualPath = objSysPara(10)
                'ElseIf objSysPara(11).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_PUBLIC
                '    strVirtualPath = objSysPara(11)
                'End If
                'strResult = Replace(strPath, strPhysicalPath, strVirtualPath)
                'strResult = Replace(strResult, "\", "/")
                strResult = Me.ChangeMapVirtualPath(strPath)
                strResult = Left(strResult, InStrRev(strResult, "/"))
            Catch ex As Exception
            End Try
            Return strResult
        End Function
        Private Function getImageTotal(ByVal strPath As String) As Integer
            Dim intResult As Integer = 0
            Try
                Dim strFolder As String = System.IO.Path.GetDirectoryName(strPath)
                intResult = System.IO.Directory.GetFiles(strFolder & "\img").GetUpperBound(0)
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        Private Function getXMLpath(ByVal DocId As Integer, FileId As Integer) As String
            Dim strResult As String = ""
            ''Try
            ''    Dim procs As New BusinessLayer.Opac
            ''    Dim _ilist As IList = procs.Select_cat_files_scan_id(fileId)
            ''    procs = Nothing
            ''    If (Not IsNothing(_ilist) AndAlso _ilist.Count > 0) Then
            ''        For Each _list In _ilist
            ''            strResult = _list.XMLpath.ToString()
            ''        Next
            ''    End If
            ''Catch ex As Exception
            ''End Try
            ''Return strResult
            'Try
            '    Dim tblTmp As New DataTable
            '    objBOPACFile.ItemID = DocId
            '    tblTmp = objBOPACFile.GetFileDetail
            '    If Not IsNothing(tblTmp) AndAlso tblTmp.Rows.Count > 0 Then
            '        tblTmp.DefaultView.RowFilter = "ID=" & FileId
            '        If tblTmp.DefaultView.Count > 0 Then
            '            If Not IsDBNull(tblTmp.DefaultView(0).Item("XMLpath")) Then
            '                strResult = tblTmp.DefaultView(0).Item("XMLpath")
            '            End If
            '        End If
            '    End If
            'Catch ex As Exception
            'End Try
            Return strResult
        End Function

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
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

