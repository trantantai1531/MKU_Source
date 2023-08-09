Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Xml


Namespace eMicLibOPAC.WebUI
    Public Class clsS3capcha
        Public Shared s3name As String = "s3capcha"
        Public Shared IconNames As String()
        Public Shared IconTitles As String()
        Public Shared Width As Integer
        Public Shared Height As Integer
        Public Shared Message As String
        Public Shared Folder As String
        Public Shared Extention As String
        Private Shared RowTemplate As String = "<div style=""float:left""><span>{0} <input type=""radio"" name=""s3capcha"" value=""{1}"" /></span><div style=""background:url({2}) bottom left no-repeat; width:{3}px; height:{4}px;cursor:pointer;display:none;"" class=""img"" data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white' data-hint=""|{5}"" data-hint-position=""top""></div></div>"

        Private Shared Function LoadConfig() As Boolean
            Dim FilePath As String = "~/s3capcha/config.xml"
            FilePath = HttpContext.Current.Server.MapPath(FilePath)
            If System.IO.File.Exists(FilePath) Then
                Dim doc As New XmlDocument()
                doc.Load(FilePath)
                Dim BaseNode As String = "/s3capcha/icons/"

                Dim node As XmlNode = doc.SelectSingleNode(BaseNode + "name")
                IconNames = node.InnerText.Split(New Char() {","c})

                node = doc.SelectSingleNode(BaseNode + "title")
                IconTitles = node.InnerText.Split(New Char() {","c})

                node = doc.SelectSingleNode(BaseNode + "width")
                Width = Convert.ToInt32(node.InnerText)

                node = doc.SelectSingleNode(BaseNode + "height")
                Height = Convert.ToInt32(node.InnerText)

                node = doc.SelectSingleNode(BaseNode + "ext")
                Extention = node.InnerText

                node = doc.SelectSingleNode(BaseNode + "folder")
                Folder = node.InnerText

                node = doc.SelectSingleNode("s3capcha/message")
                Message = node.InnerText

                doc = Nothing
                Return True
            End If
            Return False
        End Function

        Public Shared Function shuffle(ByVal input As List(Of Integer)) As List(Of Integer)
            Dim output As New List(Of Integer)()
            Dim rnd As New Random()

            Dim FIndex As Integer
            While input.Count > 0
                FIndex = rnd.[Next](0, input.Count)
                output.Add(input(FIndex))
                input.RemoveAt(FIndex)
            End While

            input.Clear()
            input = Nothing
            rnd = Nothing

            Return output
        End Function

        Public Shared Function Verify(ByVal SessionValue As Object, ByVal FormValue As String) As Boolean
            Dim IsValid As Boolean = False
            If SessionValue <> Nothing Then
                If Not String.IsNullOrEmpty(FormValue) Then
                    If FormValue = Convert.ToString(SessionValue) Then
                        IsValid = True
                    End If
                End If
            End If
            Return IsValid
        End Function

        Public Shared Function GetHtmlCodes(ByVal PathTo As String, ByRef SessionValue As Integer) As String
            Dim HasValue As Boolean = False
            If String.IsNullOrEmpty(Message) Then
                HasValue = LoadConfig()
            Else
                HasValue = True
            End If

            If HasValue Then
                Dim Rnd As New Random()
                Dim RandomIndex As Integer = Rnd.[Next](0, IconNames.Length)

                Dim values As New List(Of Integer)()
                Dim i As Integer = 0
                While i < IconNames.Length
                    values.Add(i)
                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
                End While
                values = shuffle(values)

                Dim WriteThis As String = "<div class=""s3capcha""><p>" + String.Format(Message, "<strong>" + IconTitles(values(RandomIndex)) + "</strong>") + "</p>"
                Dim RandomValues As Integer() = New Integer(IconNames.Length - 1) {}
                i = 0
                While i < IconNames.Length
                    RandomValues(i) = Rnd.[Next]()
                    WriteThis += String.Format(RowTemplate, IconTitles(values(i)), RandomValues(i), PathTo + "/icons/" + Folder + "/" + IconNames(values(i)) + "." + Extention, Width, Height, IconTitles(values(i)))
                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
                End While
                WriteThis += "<div style=""clear:left""></div></div>"
                SessionValue = RandomValues(RandomIndex)
                Return WriteThis
            Else
                SessionValue = -1
                Return "Invalid data, config file not found"
            End If
        End Function
    End Class

End Namespace
