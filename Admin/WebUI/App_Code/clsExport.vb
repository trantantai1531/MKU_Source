Imports eMicLibAdmin.BusinessRules.Common
Imports Aspose.Pdf
Imports System.IO
Public Class clsExport
    Public Shared Sub StringToExcel(ByVal str As String)
        System.Web.HttpContext.Current.Response.Clear()
        System.Web.HttpContext.Current.Response.Buffer = True
        System.Web.HttpContext.Current.Response.ContentType = "application/excel"
        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & String.Format("{0:ddMMyyyyHHmmssttt}", System.DateTime.Now) & ".xls")

        System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode
        System.Web.HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        System.Web.HttpContext.Current.Response.Output.Write(str)
        System.Web.HttpContext.Current.Response.Flush()
        System.Web.HttpContext.Current.Response.End()
    End Sub

    Public Shared Sub StringBuilderToExcel(ByVal strBuilder As StringBuilder)
        System.Web.HttpContext.Current.Response.Clear()
        System.Web.HttpContext.Current.Response.Buffer = True
        System.Web.HttpContext.Current.Response.ContentType = "application/excel"
        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & String.Format("{0:ddMMyyyyHHmmssttt}", System.DateTime.Now) & ".xls")

        System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode
        System.Web.HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        System.Web.HttpContext.Current.Response.Output.Write(strBuilder.ToString())
        System.Web.HttpContext.Current.Response.Flush()
        System.Web.HttpContext.Current.Response.End()
    End Sub

    Public Shared Sub CountPagesPdf(ByVal pathFile As Document)
        Dim licenseFile As String = Path.Combine(HttpContext.Current.Server.MapPath("\bin\"), "Aspose.Pdf.lic")
        If (File.Exists(licenseFile)) Then
            Dim license As Aspose.Pdf.License = New Aspose.Pdf.License()
            license.SetLicense(licenseFile)
        End If

    End Sub
End Class
