Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class eService
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)> _
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ServiceModel.Web.WebMessageFormat.Json)> _
    Public Function getAnnotation(ByVal magId As Integer) As String
        Dim strJSON As String = JsonConvert.Null
        Try
            Dim tblItem As New DataTable
            Dim objBMagazine As New eMicLibAdmin.BusinessRules.Serial.clsBMagazine
            With objBMagazine
                .InterfaceLanguage = Session("InterfaceLanguage")
                .DBServer = Session("DBServer")
                .ConnectionString = Session("ConnectionString")
                .Initialize()
                .MagId = magId
                tblItem = .getAnnotationByMagID
            End With
            strJSON = JsonConvert.SerializeObject(tblItem, Formatting.Indented)
        Catch ex As Exception
        End Try
        Return strJSON
    End Function
End Class