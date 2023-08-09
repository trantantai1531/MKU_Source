Imports System.Collections.Generic
Imports System.Text

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBExportHelper

        Public Shared Function ListRow(ByVal input As String) As List(Of String)
            Dim result As New List(Of String)
            If Not String.IsNullOrEmpty(input) Then
                Dim arr_row() As String = input.Split("/")
                For i As Integer = 0 To arr_row.Length - 2
                    result.Add(arr_row(i))
                Next
            End If
            Return result
        End Function

        Public Shared Function css_word(ByVal top As String, ByVal right As String, ByVal bottom As String, ByVal left As String, ByVal landscape As Boolean) As String
            Dim result As String = ""

            result = result & "@page Section1 {size:595.45pt 841.7pt; margin:" & top & " " & right & " " & bottom & " " & left & ";mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}"
            result = result & "div.Section1 {page:Section1;}"

            If landscape = True Then
                result = result & "@page Section2 {size:841.7pt 595.45pt;"
                result = result & "mso-page-orientation:landscape;"
                result = result & "margin:" & top & " " & right & " " & bottom & " " & left & ";mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}"
            Else
                result = result & "@page Section2 {size:595.45pt 841.7pt;"
                result = result & "margin:" & top & " " & right & " " & bottom & " " & left & ";mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}"
            End If

            result = result & "div.Section2 {page:Section2;}"

            Return result
        End Function

        Public Shared Function css_word(ByVal landscape As Boolean) As String
            Dim result As String = ""

            result = result & "@page Section1 {size:595.45pt 841.7pt; margin:1.0in 1.25in 1.0in 1.25in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}"
            result = result & "div.Section1 {page:Section1;}"
            result = result & "@page Section2 {size:841.7pt 595.45pt;"

            If landscape = True Then
                result = result & "mso-page-orientation:landscape;"
            End If

            result = result & "margin:1.25in 1.0in 1.25in 1.0in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;}"
            result = result & "div.Section2 {page:Section2;}"

            Return result
        End Function

        Public Shared Function Xml_Word() As String
            Dim result As String = ""
            result = result & "<w:WordDocument>"
            result = result & "<w:View>Print</w:View>"
            result = result & "<w:Zoom>100%</w:Zoom>"
            result = result & "</w:WordDocument>"

            Return result
        End Function

        Public Shared Function HeaderWord(ByVal header_text As String) As String
            Dim result As String = ""
            result = result & "<p class=MsoHeader style='text-align:left'>"
            result = result & "<p>" & header_text & "</p></p>"

            Return result
        End Function

        Public Shared Function FooterWord(ByVal footer_text As String) As String
            Dim result As String = ""
            result = result & "<p class=MsoFooter style='text-align:left'>"
            result = result & "<p>" & footer_text & "</p></p>"

            Return result
        End Function

        Public Shared Function GenDataTableToString(ByVal dataInput As DataTable, Optional title As String = Nothing) As String
            Dim strResult As String = "<table border='1' cellpadding='0' cellspacing='0' width='100%'>"
            If title IsNot Nothing Then
                strResult = strResult & String.Format("<caption><h1>{0}</h1></caption>", title)
            End If
            If Not IsNothing(dataInput) AndAlso dataInput.Rows.Count > 0 Then
                Dim rowHeader As DataRow = dataInput.Rows(dataInput.Rows.Count - 1)
                strResult = strResult & "<tr>"
                For i As Integer = 0 To rowHeader.ItemArray.Length - 1
                    strResult = strResult & "<th align='center'>" & rowHeader.Item(i).ToString() & "</th>"
                Next
                strResult = strResult & "</tr>"

                For i As Integer = 0 To dataInput.Rows.Count - 2
                    strResult = strResult & "<tr>"
                    For j As Integer = 0 To dataInput.Rows(i).ItemArray.Length - 1
                        Dim Data As  String = dataInput.Rows(i).Item(j).ToString()
                        Dim strStyle As  String = "mso-number-format:'\@'"
                        If Data.Trim().Length > 1 AndAlso  Data.StartsWith("0") Then
                            strResult = strResult & "<td style="& Chr(34) & strStyle & Chr(34) & ">" & dataInput.Rows(i).Item(j).ToString() & "</td>"
                            Else 
                                strResult = strResult & "<td>" & dataInput.Rows(i).Item(j).ToString() & "</td>"
                        End If
                        
                    Next
                    strResult = strResult & "</tr>"
                Next
            End If
            Return strResult & "</table>"
        End Function

        Public Shared Function GenHeader(ByVal strLeft As String, ByVal strRight As String, ByVal strTitle As String) As String
            Dim strResult As String = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>"
            strResult = strResult & "<tr>"
            strResult = strResult & "<td style='width:50%' align='center'>" & strLeft & "</td>"
            strResult = strResult & "<td style='width:50%' align='center'>" & strRight & "</td>"
            strResult = strResult & "</tr>"
            strResult = strResult & "<tr>"
            strResult = strResult & "<td colspan='2' align='center'><br/>" & strTitle & "</td>"
            strResult = strResult & "</tr>"
            Return strResult & "</table>"
        End Function
        Public Shared Function GenFooter(ByVal strCountBook As String, ByVal strCountCopyNumber As String) As String
            Dim strResult As String = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>"
            strResult = strResult & "<tr>"
            strResult = strResult & "<td style='width:50%' align='left'>" & strCountBook & "</td>"
            strResult = strResult & "<td style='width:50%' align='right'>" & strCountCopyNumber & "</td>"
            strResult = strResult & "</tr>"
            Return strResult & "</table>"
        End Function
        Public Shared Function GenFooterCenter(ByVal strCountBook As String, ByVal strCountCopyNumber As String) As String
            Dim strResult As String = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>"
            strResult = strResult & "<tr>"
            strResult = strResult & "<td style='width:50%' align='center'>" & strCountBook & "</td>"
            strResult = strResult & "<td style='width:50%' align='center'>" & strCountCopyNumber & "</td>"
            strResult = strResult & "</tr>"
            Return strResult & "</table>"
        End Function

        Public Shared Function GenDataTableToStringBuilder(ByVal dataInput As DataTable) As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()
            Dim strResult As String = "<table border='1' cellpadding='0' cellspacing='0' width='100%'>"
            If Not IsNothing(dataInput) AndAlso dataInput.Rows.Count > 0 Then
                For i As Integer = 0 To dataInput.Rows.Count - 1
                    strResult = strResult & "<tr>"
                    For j As Integer = 0 To dataInput.Rows(i).ItemArray.Length - 1
                        strResult = strResult & "<td>" & dataInput.Rows(i).Item(j).ToString() & "</td>"
                    Next
                    strResult = strResult & "</tr>"
                Next
            End If
            strResult = strResult & "</table>"
            sBuilder.Append(strResult)
            Return sBuilder
        End Function

        Public Shared Function GenToStringBuilderHighlightRowDuplicate(ByVal dataInput As DataTable, ByVal RowsHighlight As ArrayList, ByVal RowsHighlight2 As ArrayList) As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()
            Dim strResult As String = "<table border='1' cellpadding='0' cellspacing='0' width='100%'>"
            If Not IsNothing(dataInput) AndAlso dataInput.Rows.Count > 0 Then
                For i As Integer = 0 To dataInput.Rows.Count - 1
                    If i = 0 Then '' header table
                        strResult = strResult & "<tr style='background: darkgray;'>"
                        For j As Integer = 0 To dataInput.Rows(i).ItemArray.Length - 1
                            strResult = strResult & "<th>" & dataInput.Rows(i).Item(j).ToString() & "</th>"
                        Next
                    End If
                    If i > 0 Then
                        '''' row table
                        Dim stt = dataInput.Rows(i).Item("STT")
                        If RowsHighlight.Contains(stt) Then
                            '''' Highlight row
                            strResult = strResult & "<tr style='background: yellow;'>"
                        ElseIf RowsHighlight2.Contains(stt) Then
                            strResult = strResult & "<tr style='background: greenyellow;'>"
                        Else
                            strResult = strResult & "<tr>"
                        End If
                        For j As Integer = 0 To dataInput.Rows(i).ItemArray.Length - 1
                            strResult = strResult & "<td>" & dataInput.Rows(i).Item(j).ToString() & "</td>"
                        Next
                    End If
                    strResult = strResult & "</tr>"
                Next
            End If
            strResult = strResult & "</table>"
            sBuilder.Append(strResult)
            Return sBuilder
        End Function

        Public Shared Function GenToExcel(ByVal objLabel As String(), ByVal objValue As Integer(), Optional ByVal strHeaderTitle As String = "") As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()
            sBuilder.Append("<table width=""100%"" border=""1"" >")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"" colspan=""" & objLabel.Length & """><b>" & strHeaderTitle & "</b></td>")
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objLabel.Length - 1
                sBuilder.Append("<td align=""center"">" & objLabel(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objValue.Length - 1
                sBuilder.Append("<td align=""center"">" & objValue(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("</table>")

            Return sBuilder
        End Function

        Public Shared Function GenToExcel(ByVal objLabel As Integer(), ByVal objValue As Integer(), Optional ByVal strHeaderTitle As String = "") As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()

            sBuilder.Append("<table width=""100%"" border=""1"" >")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"" colspan=""" & objLabel.Length & """><b>" & strHeaderTitle & "</b></td>")
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objLabel.Length - 1
                sBuilder.Append("<td align=""center"">" & objLabel(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objValue.Length - 1
                sBuilder.Append("<td align=""center"">" & objValue(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("</table>")

            Return sBuilder
        End Function

        Public Shared Function GenToExcel(ByVal objLabel As Integer(), ByVal objValue As String(), Optional ByVal strHeaderTitle As String = "") As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()

            sBuilder.Append("<table width=""100%"" border=""1"" >")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"" colspan=""" & objLabel.Length & """><b>" & strHeaderTitle & "</b></td>")
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objLabel.Length - 1
                sBuilder.Append("<td align=""center"">" & objLabel(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objValue.Length - 1
                sBuilder.Append("<td align=""center"">" & objValue(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("</table>")

            Return sBuilder
        End Function

        Public Shared Function GenToExcel(ByVal objLabel As String(), ByVal objValue As String(), Optional ByVal strHeaderTitle As String = "") As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()

            sBuilder.Append("<table width=""100%"" border=""1"" >")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"" colspan=""" & objLabel.Length & """><b>" & strHeaderTitle & "</b></td>")
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objLabel.Length - 1
                sBuilder.Append("<td align=""center"">" & objLabel(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objValue.Length - 1
                sBuilder.Append("<td align=""center"">" & objValue(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("</table>")

            Return sBuilder
        End Function

        Public Shared Function GenToExcel(ByVal objLabel As Integer(), ByVal objValue As Long(), Optional ByVal strHeaderTitle As String = "") As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()

            sBuilder.Append("<table width=""100%"" border=""1"" >")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"" colspan=""" & objLabel.Length & """><b>" & strHeaderTitle & "</b></td>")
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objLabel.Length - 1
                sBuilder.Append("<td align=""center"">" & objLabel(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            For i As Integer = 0 To objValue.Length - 1
                sBuilder.Append("<td align=""center"">" & objValue(i) & "</td>")
            Next
            sBuilder.Append("</tr>")
            sBuilder.Append("</table>")

            Return sBuilder
        End Function

        Public Shared Function GenToExcel(ByVal listColumnName As String(), ByVal listRowName As String(), ByVal tblData As DataTable, ByVal strColumnFilter As String, ByVal strRowFilter As String, ByVal strItemGet As String, Optional ByVal strHeaderTitle As String = "", Optional ByVal strFirstColumn As String = "", Optional ByVal isTotal As Boolean = False, Optional ByVal strTitleTotal As String = "") As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()

            sBuilder.Append("<table width=""100%"" border=""1"" >")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"" colspan=""" & listColumnName.Length + 1 & """><b>" & strHeaderTitle & "</b></td>")
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"">" & strFirstColumn & "</td>")
            For i As Integer = 0 To listColumnName.Length - 1
                sBuilder.Append("<td align=""center"">" & listColumnName(i) & "</td>")
            Next
            sBuilder.Append("</tr>")

            Dim arrTotal() As Integer
            ReDim arrTotal(listColumnName.Length - 1)

            If isTotal = True Then
                sBuilder.Append("<tr>")
                sBuilder.Append("<td align=""center""><b>" & strTitleTotal & "</b></td>")
                For i As Integer = 0 To listColumnName.Length - 1
                    sBuilder.Append("<td align=""center""><b>" & String.Format("Total-{0}-", i) & "</b></td>")
                    arrTotal(i) = 0
                Next
                sBuilder.Append("</tr>")
            End If

            For i As Integer = 0 To listRowName.Length - 1
                sBuilder.Append("<tr>")
                sBuilder.Append("<td align=""center"">" & listRowName(i) & "</td>")
                For j As Integer = 0 To listColumnName.Length - 1
                    tblData.DefaultView.RowFilter = strRowFilter & "='" & listRowName(i) & "' AND " & strColumnFilter & "='" & listColumnName(j) & "'"
                    If tblData.DefaultView.Count = 0 Then
                        sBuilder.Append("<td align=""center"">0</td>")
                        If isTotal = True Then
                            arrTotal(j) = arrTotal(j) + 0
                        End If
                    Else
                        sBuilder.Append("<td align=""center"">" & tblData.DefaultView.Item(0).Item(strItemGet) & "</td>")
                        If isTotal = True Then
                            arrTotal(j) = arrTotal(j) + CInt(tblData.DefaultView.Item(0).Item(strItemGet).ToString())
                        End If
                    End If
                Next
                sBuilder.Append("</tr>")
            Next

            sBuilder.Append("</table>")

            If isTotal = True Then
                Dim strBuilder As String = sBuilder.ToString()
                For i As Integer = 0 To listColumnName.Length - 1
                    strBuilder = strBuilder.Replace(String.Format("Total-{0}-", i), arrTotal(i).ToString())
                Next
                sBuilder.Clear()
                sBuilder.Append(strBuilder)
            End If

            Return sBuilder
        End Function

        Public Shared Function GenToExcel(ByVal listColumnName As String(), ByVal listRowName As String(), ByVal tblData As DataTable, ByVal strColumnFilter As String, ByVal strRowFilter As String, ByVal strItemGet As String, ByVal strItemTotalGet As String, Optional ByVal strHeaderTitle As String = "", Optional ByVal strFirstColumn As String = "", Optional ByVal isTotal As Boolean = False, Optional ByVal strTitleTotal As String = "") As StringBuilder
            Dim sBuilder As StringBuilder = New System.Text.StringBuilder()

            sBuilder.Append("<table width=""100%"" border=""1"" >")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"" colspan=""" & listColumnName.Length + 3 & """><b>" & strHeaderTitle & "</b></td>")
            sBuilder.Append("</tr>")
            sBuilder.Append("<tr>")
            sBuilder.Append("<td align=""center"">" & strFirstColumn & "</td>")
            sBuilder.Append("<td align=""center"">Tổng biểu ghi</td>")
            sBuilder.Append("<td align=""center"">Tổng xếp giá</td>")
            For i As Integer = 0 To listColumnName.Length - 1
                sBuilder.Append("<td align=""center"">" & listColumnName(i) & "</td>")
            Next
            sBuilder.Append("</tr>")

            Dim arrTotal() As Integer
            ReDim arrTotal(listColumnName.Length - 1)
            Dim arrTotalItem() As Integer
            ReDim arrTotalItem(listRowName.Length - 1)
            Dim arrTotalHolding() As Integer
            ReDim arrTotalHolding(listRowName.Length - 1)

            Dim intTotalItemAll As Integer = 0
            Dim intTotalHoldingAll As Integer = 0

            For i As Integer = 0 To listRowName.Length - 1
                arrTotalItem(i) = 0
                arrTotalHolding(i) = 0
            Next


            If isTotal = True Then
                sBuilder.Append("<tr>")
                sBuilder.Append("<td align=""center""><b>" & strTitleTotal & "</b></td>")
                sBuilder.Append("<td align=""center""><b>" & String.Format("Total-Item-All") & "</b></td>")
                sBuilder.Append("<td align=""center""><b>" & String.Format("Total-Holding-All") & "</b></td>")
                For i As Integer = 0 To listColumnName.Length - 1
                    sBuilder.Append("<td align=""center""><b>" & String.Format("Total-{0}-", i) & "</b></td>")
                    arrTotal(i) = 0
                Next
                sBuilder.Append("</tr>")
            End If

            For i As Integer = 0 To listRowName.Length - 1
                sBuilder.Append("<tr>")
                sBuilder.Append("<td align=""center"">" & listRowName(i) & "</td>")
                sBuilder.Append("<td align=""center"">" & String.Format("Total-Item-{0}-", i) & "</td>")
                sBuilder.Append("<td align=""center"">" & String.Format("Total-Holding-{0}-", i) & "</td>")
                For j As Integer = 0 To listColumnName.Length - 1
                    tblData.DefaultView.RowFilter = strRowFilter & "='" & listRowName(i) & "' AND " & strColumnFilter & "='" & listColumnName(j) & "'"
                    If tblData.DefaultView.Count = 0 Then
                        sBuilder.Append("<td align=""center"">0</td>")
                    Else
                        sBuilder.Append("<td align=""center"">" & tblData.DefaultView.Item(0).Item(strItemGet) & "</td>")
                        arrTotalItem(i) = arrTotalItem(i) + CInt(tblData.DefaultView.Item(0).Item(strItemTotalGet).ToString())
                        arrTotalHolding(i) = arrTotalHolding(i) + CInt(tblData.DefaultView.Item(0).Item(strItemGet).ToString())
                        If isTotal = True Then
                            arrTotal(j) = arrTotal(j) + CInt(tblData.DefaultView.Item(0).Item(strItemGet).ToString())
                        End If
                    End If
                Next
                intTotalItemAll = intTotalItemAll + arrTotalItem(i)
                intTotalHoldingAll = intTotalHoldingAll + arrTotalHolding(i)

                sBuilder.Append("</tr>")
            Next

            sBuilder.Append("</table>")

            If isTotal = True Then
                Dim strBuilder As String = sBuilder.ToString()
                For i As Integer = 0 To listColumnName.Length - 1
                    strBuilder = strBuilder.Replace(String.Format("Total-{0}-", i), arrTotal(i).ToString())
                Next
                sBuilder.Clear()
                sBuilder.Append(strBuilder)
            End If

            If Not String.IsNullOrEmpty(sBuilder.ToString()) Then
                Dim strBuilder As String = sBuilder.ToString()
                strBuilder = strBuilder.Replace("Total-Item-All", intTotalItemAll.ToString())
                strBuilder = strBuilder.Replace("Total-Holding-All", intTotalHoldingAll.ToString())
                For i As Integer = 0 To listRowName.Length - 1
                    strBuilder = strBuilder.Replace(String.Format("Total-Item-{0}-", i), arrTotalItem(i).ToString())
                    strBuilder = strBuilder.Replace(String.Format("Total-Holding-{0}-", i), arrTotalHolding(i).ToString())
                Next
                sBuilder.Clear()
                sBuilder.Append(strBuilder)
            End If

            Return sBuilder
        End Function
    End Class
End Namespace

