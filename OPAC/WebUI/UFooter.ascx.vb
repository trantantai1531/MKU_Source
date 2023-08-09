Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Globalization
Imports eMicLibOPAC.BusinessRules.Common


Namespace eMicLibOPAC.WebUI.OPAC
    Public Class UFooter
        Inherits System.Web.UI.UserControl
        Private xmlDoc As XmlDocument
        Private objBCounter As New clsBCounter

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindCounter()
            If Not IsPostBack Then
                'Call ReadXmlFile("divFooter")
            End If
        End Sub
        Private Sub Initialize()
            objBCounter.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCounter.DBServer = Session("DBServer")
            objBCounter.ConnectionString = Session("ConnectionString")
            objBCounter.Initialize()

        End Sub

        Private Sub BindCounter()
            Dim total As Integer = objBCounter.GetCounterTotal()
            Dim lastday As Integer = objBCounter.GetCounterLastDay()
            Dim lastweek As Integer = objBCounter.GetCounterLastWeek()
            Dim lastmonth As Integer = objBCounter.GetCounterLastMonth()

            lbTotal.Text = String.Format("{0}", total)
            lbLastDay.Text = String.Format("{0}", lastday)
            lbLastWeek.Text = String.Format("{0}", lastweek)
            lbLastMonth.Text = String.Format("{0}", lastmonth)

        End Sub

        'Private Sub ReadXmlFile(ByVal strControlName As String)
        '    Try
        '        Dim strColLanguage As String = clsSession.GlbLanguage
        '        Dim strPathName As String = ""
        '        strPathName = "\Resources\LabelString\UFooter.xml"
        '        strPathName = Server.MapPath(Request.ApplicationPath) & strPathName
        '        Dim objFileInfo As New FileInfo(strPathName)
        '        If objFileInfo.Exists Then
        '            If Me.xmlDoc Is Nothing Then
        '                Me.xmlDoc = New XmlDocument()
        '            End If
        '            Me.xmlDoc.Load(strPathName)
        '            strControlName = strControlName.ToUpper(New CultureInfo("en"))

        '            If Not Me.xmlDoc Is Nothing Then
        '                Dim nodes As XmlNodeList
        '                nodes = Me.xmlDoc.SelectNodes("/Head/data")
        '                For Each node As XmlNode In nodes
        '                    If node.SelectSingleNode("name").InnerText.ToUpper = strControlName.ToUpper Then
        '                        With node
        '                            divFooter.InnerHtml = .SelectSingleNode(strColLanguage).InnerText
        '                        End With
        '                    End If
        '                Next
        '            End If
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Sub
    End Class
End Namespace
