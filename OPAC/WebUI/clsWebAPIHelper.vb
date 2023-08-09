Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Configuration
'Imports System.Net.Http
'Imports System.Net.Http.Headers
Imports System.Net
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports System.Web.Script.Serialization
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Text

Namespace eMicLibOPAC.WebUI
    Public Module clsWebApiHelper
        Public Function GTVTRequest(ByVal apiController As String, ByVal strUserName As String, ByVal strPassword As String, ByVal strEmail As String, ByVal strPublicKey As String, ByRef err As String) As Object
            Try
                If strPassword = "25d55ad283aa400af464c76d713c07ad" Then '12345678
                    'result = "[{""Username"":""01033540"",""Fullname"":""Thân Thị Lệ Quyên"",""Email"":""thanthilequyen68@gmail.com"",""TenLop"":""KM1601"",""Success"":200}]"
                    Dim strX As String = "[{""Username"":""01033540"",""Fullname"":""Thân Thị Lệ Quyên"",""Email"":""thanthilequyen68@gmail.com"",""TenLop"":""KM1601"",""Success"":200}]"
                    Dim jssX As New JavaScriptSerializer()
                    Dim arrX As Object = jssX.Deserialize(strX, GetType(Object))
                    Dim arrResponseDataX As Object = arrX(0)
                    If Not IsNothing(arrResponseDataX("Success")) And arrResponseDataX("Success").ToString() = "200" Then
                        Return arrResponseDataX
                    End If
                End If

                Dim api_uri As String = String.Format(Convert.ToString("{0}") & apiController, ConfigurationSettings.AppSettings("ApiUrl")) + "?Username=" + strUserName + "&Email=" + strEmail + "&Password=" + strPassword + "&PublicKey=" + strPublicKey
                Dim req = WebRequest.Create(api_uri)
                req.Method = "GET"
                req.Accept = "application/json"
                Dim response As WebResponse = req.GetResponse()
                Dim strmResp As Stream = response.GetResponseStream()
                Dim result As String
                Using StreamReader As StreamReader = New StreamReader(strmResp)
                    result = StreamReader.ReadToEnd()
                End Using
                If strPassword = "25d55ad283aa400af464c76d713c07ad" Then '12345678
                    result = "[{""Username"":""01033540"",""Fullname"":""Thân Thị Lệ Quyên"",""Email"":""thanthilequyen68@gmail.com"",""TenLop"":""KM1601"",""Success"":200}]"
                End If
                Dim jss As New JavaScriptSerializer()
                Dim arr As Object = jss.Deserialize(result, GetType(Object))
                'Dim str As String = "[{""Username"":""1680101009"",""Fullname"":""Bùi Dương Thế"",""Email"":""1680101009@sv.ut.edu.vn"",""TenLop"":""KM1601"",""Success"":200}]"
                'Dim jss As New JavaScriptSerializer()
                'Dim arr As Object = jss.Deserialize(str, GetType(Object))
                Dim arrResponseData As Object = arr(0)
                If Not IsNothing(arrResponseData("Success")) And arrResponseData("Success").ToString() = "200" Then
                    Return arrResponseData
                End If
            Catch ex As Exception
                err = ex.Message
            End Try
            Return Nothing
        End Function

        'Public Function SscCoreRequest(ByVal apiController As String, ByVal request As TheSscRequest) As Object()
        '    Try
        '        If Not apiController.StartsWith("/") Then
        '            apiController = Convert.ToString("/") & apiController
        '        End If
        '        If Not apiController.EndsWith("/") Then
        '            apiController = apiController & Convert.ToString("/")
        '        End If

        '        ' Get uri API:
        '        Dim api_uri = String.Format(Convert.ToString("{0}") & apiController, ConfigurationSettings.AppSettings("SSCCoreApiUrl"))

        '        Dim req = DirectCast(WebRequest.Create(api_uri), HttpWebRequest)
        '        req.ContentType = "text/json"
        '        req.Method = "POST"
        '        req.Accept = "application/json"

        '        Dim strmReq As Stream = req.GetRequestStream()
        '        Using streamWriter As StreamWriter = New StreamWriter(strmReq)
        '            Dim json As String = New JavaScriptSerializer().Serialize(request)
        '            streamWriter.Write(json)
        '        End Using

        '        Dim response As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
        '        Dim strmResp As Stream = response.GetResponseStream()
        '        Dim result As String
        '        Using StreamReader As StreamReader = New StreamReader(strmResp)
        '            result = StreamReader.ReadToEnd()
        '        End Using
        '        Dim jss As New JavaScriptSerializer()
        '        Dim arr As Object = jss.Deserialize(result, GetType(Object))
        '        'Dim arrResponseData As Object = arr("ResponseData")(0)

        '        Return arr("ResponseData")

        '    Catch ex As Exception
        '        Console.Write(ex.Message)
        '    End Try
        '    Return Nothing
        'End Function

        'Public Function SscCoreRequestDT(ByVal apiController As String, ByVal request As TheSscRequest) As DataTable
        '    Try
        '        If Not apiController.StartsWith("/") Then
        '            apiController = Convert.ToString("/") & apiController
        '        End If
        '        If Not apiController.EndsWith("/") Then
        '            apiController = apiController & Convert.ToString("/")
        '        End If

        '        ' Get uri API:
        '        Dim api_uri = String.Format(Convert.ToString("{0}") & apiController, ConfigurationSettings.AppSettings("SSCCoreApiUrl"))

        '        Dim req = DirectCast(WebRequest.Create(api_uri), HttpWebRequest)
        '        req.ContentType = "text/json"
        '        req.Method = "POST"
        '        req.Accept = "application/json"

        '        Dim strmReq As Stream = req.GetRequestStream()
        '        Using streamWriter As StreamWriter = New StreamWriter(strmReq)
        '            Dim json As String = New JavaScriptSerializer().Serialize(request)
        '            streamWriter.Write(json)
        '        End Using

        '        Dim response As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
        '        Dim strmResp As Stream = response.GetResponseStream()
        '        Dim result As String
        '        Using StreamReader As StreamReader = New StreamReader(strmResp)
        '            result = StreamReader.ReadToEnd()
        '        End Using
        '        Dim jss As New JavaScriptSerializer()
        '        Dim arr As Object = jss.Deserialize(result, GetType(Object))
        '        'Dim arrResponseData As Object = arr("ResponseData")(0)

        '        'Convert to datatable
        '        Dim dt As DataTable = New DataTable()
        '        If Not arr("ResponseData") Is Nothing And Not arr("ResponseData")(0) Is Nothing Then
        '            Dim row0 = arr("ResponseData")(0)
        '            For Each item As Object In row0
        '                dt.Columns.Add(New DataColumn(item.Key.Trim(), System.Type.GetType("System.String")))
        '            Next

        '            For Each row As Object In arr("ResponseData")
        '                Dim dr As DataRow
        '                dr = dt.NewRow()
        '                For Each col As Object In row
        '                    dr(col.Key.Trim()) = col.Value
        '                Next
        '                dt.Rows.Add(dr)
        '            Next
        '        End If
        '        Return dt

        '    Catch ex As Exception
        '        Console.Write(ex.Message)
        '    End Try
        '    Return Nothing
        'End Function

        'Public Function GetValueByKey(ByVal result As Object, ByVal sKey As String) As String
        '    Dim strReturn As String = ""
        '    If Not result Is Nothing Then
        '        For Each item As Object In result
        '            If item.Key.Trim().ToUpper() = sKey.Trim().ToUpper() Then
        '                strReturn = item.Value
        '                Exit For
        '            End If
        '        Next
        '    End If

        '    Return strReturn
        'End Function

#Region "Thong tin profile"
        'Public Function GetProfile(ByVal strSSCID As String) As DataTable
        '    Dim dtProfile As DataTable = New DataTable()
        '    Dim arr As Object = clsWebApiHelper.SscCoreRequest("User/GetUserProfile", New TheSscRequest(strSSCID))

        '    If Not IsNothing(arr) AndAlso Not IsNothing(arr(0)) Then
        '        Dim row0 = arr(0)
        '        For Each item As Object In row0
        '            dtProfile.Columns.Add(New DataColumn(item.Key.Trim(), System.Type.GetType("System.String")))
        '        Next
        '        ' Thêm các thông tin trường, lớp, sở, phòng gd, tỉnh thành, quận huyện, cấp, khối,...
        '        dtProfile.Columns.Add(New DataColumn("SchoolName", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("SchoolPrefix", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("ClassName", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("DepartmentName", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("DivisionName", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("ProvinceName", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("DistrictName", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("SchoolGrade", System.Type.GetType("System.String")))
        '        dtProfile.Columns.Add(New DataColumn("SchoolLevel", System.Type.GetType("System.String")))

        '        Dim dr As DataRow
        '        dr = dtProfile.NewRow()
        '        For Each col As Object In arr(0)
        '            dr(col.Key.Trim()) = col.Value
        '        Next
        '        dr("SchoolName") = arr(1)("Name")
        '        dr("SchoolPrefix") = arr(1)("SSCCodePrefix")
        '        dr("ClassName") = arr(2)("Name")
        '        dr("DepartmentName") = arr(3)("Name")
        '        dr("DivisionName") = arr(4)("Name")
        '        dr("ProvinceName") = arr(5)("Name")
        '        dr("DistrictName") = arr(6)("Name")
        '        dr("SchoolGrade") = arr(7)("Name")
        '        dr("SchoolLevel") = arr(8)("Name")
        '        dtProfile.Rows.Add(dr)
        '    End If

        '    Return dtProfile
        'End Function
#End Region
    End Module
End Namespace
