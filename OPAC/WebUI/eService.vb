Imports System.IO
Imports System.IO.Path
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports eMicLibLogin

<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class eService
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    '<ScriptMethod(UseHttpGet:=True, ResponseFormat:=ServiceModel.Web.WebMessageFormat.Json)> _
    'Public Function getToc(ByVal magId As Integer, ByVal pageNum As Integer) As String
    '    Dim strJSON As String = JsonConvert.Null
    '    Try
    '        Dim procs As New BusinessLayer.eMagazine
    '        Dim iFiles As IList = procs.Select_magazine_toc(magId, pageNum)
    '        strJSON = JsonConvert.SerializeObject(iFiles)
    '    Catch ex As Exception
    '    End Try
    '    Return strJSON
    'End Function

    <WebMethod>
    <ScriptMethod(UseHttpGet:=False, ResponseFormat:=ResponseFormat.Json)>
    Public Function GetTimeBusyInRoom(ByVal strDate As String, ByVal intRoomID As Integer) As String
        Dim tblData As New DataTable
        Dim objLg As New clseMicLibLogin

        Dim arrStrDate() As String = strDate.Split("/")

        Dim strDateConver As New Date(CInt(arrStrDate(2)), CInt(arrStrDate(1)), CInt(arrStrDate(0)))

        Dim objBOPACRoomsBooking As New eMicLibOPAC.BusinessRules.OPAC.clsBOPACRoomsBooking
        With objBOPACRoomsBooking
            .InterfaceLanguage = "unicode"
            .DBServer = objLg.DBServer
            .ConnectionString = objLg.GetConnectionString
            .Initialize()
            .RoomID = intRoomID
            tblData = .GetTimeBusyByDate(String.Format("{0:yyyy-MM-dd}", strDateConver))
        End With

        If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then
            Dim strResult As String = ""
            For i As Integer = 0 To tblData.Rows.Count - 1 Step 1
                If i = 0 Then
                    strResult = tblData.Rows(i).Item("TimesBusy")
                Else
                    strResult = strResult & ", " & tblData.Rows(i).Item("TimesBusy")
                End If
            Next
            Return strResult
        End If

        Return ""
    End Function

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ServiceModel.Web.WebMessageFormat.Json)>
    Public Function getTocAll(ByVal magId As Integer) As String
        Dim strJSON As String = JsonConvert.Null
        Try
            Dim tblItem As New DataTable
            Dim objBMagazine As New eMicLibOPAC.BusinessRules.OPAC.clsBOPACeMagazine
            With objBMagazine
                .InterfaceLanguage = Session("InterfaceLanguage")
                .DBServer = Session("DBServer")
                .ConnectionString = Session("ConnectionString")
                .Initialize()
                .MagID = magId
                tblItem = .GetMagazineNumberDetailTOCByMagID
            End With
            strJSON = JsonConvert.SerializeObject(tblItem, Formatting.Indented)
        Catch ex As Exception
        End Try
        Return strJSON
    End Function

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ServiceModel.Web.WebMessageFormat.Json)>
    Public Function getAnnotation(ByVal magId As Integer) As String
        Dim strJSON As String = JsonConvert.Null
        Try
            Dim tblItem As New DataTable
            Dim objBMagazine As New eMicLibOPAC.BusinessRules.OPAC.clsBOPACeMagazine
            With objBMagazine
                .InterfaceLanguage = Session("InterfaceLanguage")
                .DBServer = Session("DBServer")
                .ConnectionString = Session("ConnectionString")
                .Initialize()
                .MagID = magId
                tblItem = .GetMagazineNumberDetailAnnotationByMagID
            End With
            strJSON = JsonConvert.SerializeObject(tblItem, Formatting.Indented)
        Catch ex As Exception
        End Try
        Return strJSON
    End Function

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ServiceModel.Web.WebMessageFormat.Json)>
    Public Function showAllMarker() As String
        Dim strJSON As String = JsonConvert.Null
        Try
            Dim strLang As String = "vie"
            If Not IsNothing(Session("Language")) Then
                strLang = Session("Language")
            End If
            Dim tblItem As New DataTable
            Dim objBSysLibrary As New eMicLibOPAC.BusinessRules.OPAC.clsBSysLibrary
            With objBSysLibrary
                .InterfaceLanguage = Session("InterfaceLanguage")
                .DBServer = Session("DBServer")
                .ConnectionString = Session("ConnectionString")
                .Initialize()
                .Language = strLang
                tblItem = .SysGetAllLibraryMap
            End With
            Call copyFile(tblItem)
            strJSON = JsonConvert.SerializeObject(tblItem, Formatting.Indented)
        Catch ex As Exception
        End Try
        Return strJSON
    End Function

    Sub copyFile(ByVal dt As DataTable)
        Try
            Dim strTempImageCover As String = ""
            Dim strTempImageCoverTemp As String = ""
            Dim strImageCover As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                strImageCover = ""
                strTempImageCover = dt.Rows(i).Item("CoverPath").ToString
                If File.Exists(strTempImageCover) Then
                    strTempImageCoverTemp = Server.MapPath("~") & "/Upload/ImageCover/" & dt.Rows(i).Item("collectionID").ToString
                    strTempImageCoverTemp = Replace(strTempImageCoverTemp, "/", "\")
                    If Not Directory.Exists(strTempImageCoverTemp) Then
                        Directory.CreateDirectory(strTempImageCoverTemp)
                    End If
                    strTempImageCoverTemp &= "\" & GetFileName(strTempImageCover)
                    If Not File.Exists(strTempImageCoverTemp) Then
                        File.Copy(strTempImageCover, strTempImageCoverTemp)
                    End If
                    'strImageCover = "Upload/ImageCover/" & dt.Rows(i).Item("LibId").ToString & "/" & GetFileName(strTempImageCover)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ServiceModel.Web.WebMessageFormat.Json)>
    Public Function getFiles(ByVal ItemID As Integer) As String
        Dim strJSON As String = JsonConvert.Null
        Try
            Dim dt As DataTable
            Dim objBOPACFile As New eMicLibOPAC.BusinessRules.OPAC.clsBOPACFile
            With objBOPACFile
                .InterfaceLanguage = Session("InterfaceLanguage")
                .DBServer = Session("DBServer")
                .ConnectionString = Session("ConnectionString")
                .Initialize()
                .ItemID = ItemID
                dt = .GetFileDetail
            End With
            Dim iCount As Integer = dt.Rows.Count - 1
            Dim objTOC As New System.Collections.Generic.List(Of eFiles)
            Dim node As eFiles
            Dim strdescription As String = ""
            Dim strfile As String = ""
            Dim strcover As String = ""
            Dim strtype As String = ""
            Dim strdownloadFile As String = ""

            If iCount >= 0 Then
                Dim objSysPara() As String
                Dim objPara() As String = {"OPAC_FORUM_URL", "LDAP_LOCATION", "LDAP_SERVER_TYPE", "LDAP_LOGON_USER", "LDAP_LOGON_PASSWORD", "SMTP_SERVER", "ADMIN_EMAIL_ADDRESS", "EDATA_LOCATIONS", "OPAC_URL", "DATE_FORMAT", "OPAC_SERVER_LOCAL", "OPAC_SERVER_PUBLIC", "OPAC_PHYSICAL_PATH", "OPAC_PICTURE_PATH"}
                Dim objBCDBS As New eMicLibOPAC.BusinessRules.Common.clsBCommonDBSystem
                objBCDBS.ConnectionString = Session("ConnectionString")
                objBCDBS.DBServer = Session("DBServer")
                Call objBCDBS.Initialize()
                objSysPara = objBCDBS.GetSystemParameters(objPara)
                Dim objSysPara10 As String, objSysPara11 As String, objSysPara12 As String
                objSysPara10 = objSysPara(10)
                objSysPara11 = objSysPara(11)
                objSysPara12 = objSysPara(12)
                For i As Integer = 0 To iCount
                    strdescription = ""
                    If Not IsDBNull(dt.Rows(i).Item("description")) Then
                        strdescription = dt.Rows(i).Item("description")
                    End If
                    strfile = ""
                    If Not IsDBNull(dt.Rows(i).Item("XMLpath")) Then
                        strfile = ChangeMapVirtualPath(dt.Rows(i).Item("XMLpath"), objSysPara10, objSysPara11, objSysPara12)
                    End If
                    strcover = ""
                    If Not IsDBNull(dt.Rows(i).Item("CoverPicture")) Then
                        strcover = ChangeMapVirtualPath(dt.Rows(i).Item("CoverPicture"), objSysPara10, objSysPara11, objSysPara12)
                    End If
                    strdownloadFile = ""
                    node = New eFiles(strdescription, strfile, strcover, strtype, strdownloadFile)
                    objTOC.Add(node)
                Next
            End If

            strJSON = JsonConvert.SerializeObject(objTOC)
        Catch ex As Exception
        End Try
        Return strJSON
    End Function

    Private Function ChangeMapVirtualPath(ByVal strPath As String, objSysPara10 As String, objSysPara11 As String, objSysPara12 As String) As String
        Dim strResult As String = ""
        Try
            Dim strVirtualPath As String = ""
            Dim strPhysicalPath As String = objSysPara12
            If objSysPara10.IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_LOCAL
                strVirtualPath = objSysPara10
            ElseIf objSysPara11.IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_PUBLIC
                strVirtualPath = objSysPara11
            End If

            'B test
            strVirtualPath = objSysPara11
            'E test
            strResult = Replace(strPath, strPhysicalPath, strVirtualPath)
            strResult = Replace(strResult, "\", "/")
        Catch ex As Exception
        End Try
        Return strResult
    End Function
    Public Class eFiles
        Private Property strDescription() As String
        Private Property strFile() As String
        Private Property strCover() As String
        Private Property strType() As String
        Private Property strDownloadFile() As String
        Public Property description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property
        Public Property file() As String
            Get
                Return strFile
            End Get
            Set(ByVal Value As String)
                strFile = Value
            End Set
        End Property

        Public Property cover() As String
            Get
                Return strCover
            End Get
            Set(ByVal Value As String)
                strCover = Value
            End Set
        End Property

        Public Property type() As String
            Get
                Return strType
            End Get
            Set(ByVal Value As String)
                strType = Value
            End Set
        End Property

        Public Property downloadFile() As String
            Get
                Return strDownloadFile
            End Get
            Set(ByVal Value As String)
                strDownloadFile = Value
            End Set
        End Property

        Public Sub New(strdescription As String, strFile As String, strCover As String, strType As String, strDownloadFile As String)
            Me.description = strdescription
            Me.file = strFile
            Me.cover = strCover
            Me.type = strType
            Me.downloadFile = strDownloadFile
        End Sub
    End Class
End Class