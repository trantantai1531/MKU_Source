' Class: WDownLoad
' Puspose: Allow download & edit selected file
' Creator: Oanhtn
' CreatedDate: 22/01/2005
' Modification History:

Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WEditFile
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBED As New clsBEData

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Page_load event
            ' Init objBED
            objBED.InterfaceLanguage = Session("InterfaceLanguage")
            objBED.DBServer = Session("DBServer")
            objBED.ConnectionString = Session("ConnectionString")
            Call objBED.Initialize()
            ' process
            Call GetFile(Request.QueryString("FieldID"))
        End Sub

        ' GetFile method
        ' Purpose: get file from server & allow user edit on workstation
        Private Sub GetFile(ByVal FieldID As Integer)
            Dim tblEdata As New DataTable
            tblEdata = objBED.GetEdataFile(clsSession.GlbUser, FieldID)
            If Not tblEdata Is Nothing AndAlso tblEdata.Rows.Count > 0 Then
                Dim objFileInfor As FileInfo
                Dim strFileName As String
                Dim strFileExt As String
                Dim strURL, strFileLoc As String
                Dim objBASP As New BASP21Lib.Basp21
                Dim objFileContent As Object

                ' Process for x-libol-edit                
                If Application("AppURL") & "" = "" Then
                    Application("AppURL") = "http://" & Server.MachineName & Request.ApplicationPath & "/Edeliv/EData/"
                End If
                strURL = tblEdata.Rows(0).Item("URL")
                If InStr(strURL, ":\") = 0 Then
                    strFileLoc = Server.MapPath(strURL)
                Else
                    strFileLoc = strURL
                End If

                strFileName = tblEdata.Rows(0).Item("PhysicalPath")
                objFileInfor = New FileInfo(strFileName)
                ' Check file exist
                If objFileInfor.Exists() Then
                    objFileContent = ReadBinaryFile(strFileLoc)
                    If Not objFileContent Is Nothing Then
                        Response.ContentType = "application/x-libol-edit"
                        Response.Charset = ""
                        Response.Buffer = True
                        Response.Clear()
                        Response.Write("url:" & Application("AppURL") & "WSaveFile.aspx?FileName=" & strFileName & Chr(10))
                        Response.Write("fileloc:" & strFileName & Chr(10))
                        Response.Write("meta_type:Text" & Chr(10))
                        Response.Write("auth:Basic " & objBASP.Base64(clsSession.GlbUser & Chr(9) & Session("Password") & Chr(9) & Session("DatabaseID")) & Chr(10))
                        If objFileInfor.Exists Then
                            strFileExt = Replace(LCase(objFileInfor.Extension), ".", "")
                            Select Case strFileExt
                                Case "gif"
                                    Response.Write("content_type:image/gif" & Chr(10))
                                Case "jpg", "jpeg", "jpe"
                                    Response.Write("content_type:image/jpeg" & Chr(10))
                                Case "png"
                                    Response.Write("content_type:image/png" & Chr(10))
                                Case "doc"
                                    Response.Write("content_type:application/msword" & Chr(10))
                                Case "xls"
                                    Response.Write("content_type:application/msexcel" & Chr(10))
                                Case "ppt", "pps"
                                    Response.Write("application/vnd.ms-powerpoint" & Chr(10))
                                Case "js"
                                    Response.Write("content_type:text/javascript" & Chr(10))
                                Case "htm", "html"
                                    Response.Write("content_type:text/html" & Chr(10))
                                Case "rtf"
                                    Response.Write("content_type:text/rtf" & Chr(10))
                                Case "txt"
                                    Response.Write("content_type:text/plain" & Chr(10))
                            End Select
                            Response.Write(Chr(10))
                            Response.BinaryWrite(objFileContent)
                            Response.Flush()
                            ' Stop the execution of this page
                            Response.End()
                        End If

                    End If
                    objFileInfor = Nothing
                Else
                    Response.Write("File not exist")
                End If
            Else
                Response.Write("File not exist or is locked")
            End If
        End Sub

        Private Function ReadBinaryFile(ByVal strFileName As String) As Object
            If strFileName <> "" Then
                Dim objBinary() As Byte
                Dim objFile As New FileInfo(strFileName)
                If objFile.Exists Then
                    Try
                        Dim objFS As New FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
                        ReDim objBinary(objFile.Length)
                        objFS.Read(objBinary, 0, objBinary.Length)
                        objFS.Close()
                        ReadBinaryFile = objBinary
                        objFile = Nothing
                        objFS = Nothing
                    Catch ex As Exception
                        objFile = Nothing
                    End Try
                End If
            End If

            'Dim BinaryStream As New Object
            'Try
            '    BinaryStream = Server.CreateObject("ADODB.Stream")
            '    BinaryStream.Type = 1 ' Binary
            '    BinaryStream.Open()
            '    BinaryStream.LoadFromFile(strFileName)
            '    ReadBinaryFile = BinaryStream.Read
            '    BinaryStream.Close()
            '    BinaryStream = Nothing
            'Catch ex As Exception
            '    ReadBinaryFile = Nothing
            'End Try
        End Function

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBED Is Nothing Then
                    objBED.Dispose(True)
                    objBED = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace