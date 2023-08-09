Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBSQL
        Public strSelect As String
        Public strTable As String
        Public strWhere As String
        Public Sub AnalyzerSQL(ByVal strSQL As String)
            Dim strtemp As String = strSQL
            Dim intPos As String
            'get select
            intPos = InStr(strtemp, "FROM")
            strSelect = Trim(Left(strtemp, intPos - 1))
            'get table
            strtemp = Trim(strtemp.Substring(intPos + 4))
            intPos = InStr(strtemp, "WHERE")
            If intPos > 0 Then
                strTable = Trim(Left(strtemp, intPos - 1))
                strWhere = Trim(strtemp.Substring(intPos + 5))
            Else
                strTable = strtemp
                strWhere = ""
            End If
        End Sub
    End Class
    Public Class clsBParseSQL

        Public Function ParseSQL(ByVal strSql As String) As String
            Dim strSelect As String
            Dim strTable As String
            Dim strWhere As String
            Dim strFirst As String
            Dim strEnd As String

            Dim strtemp As String
            Dim intPos As Integer
            Dim objSQL As New clsBSQL
            'repair sql
            strSql = strSql.Replace("( ", "(")
            strSql = strSql.Replace(", ", ",")
            strSql = strSql.Replace(vbCrLf, " ")
            intPos = InStr(strSql, "(")
            strFirst = Trim(Left(strSql, intPos))
            strSql = strSql.Substring(intPos)
            intPos = InStrRev(strSql, ")")
            strEnd = Trim(strSql.Substring(intPos - 1))
            strSql = Trim(strSql.Substring(0, intPos - 1))
            'get statement sql: 
            intPos = InStr(strSql, "AND ITEM.ID IN")
            If intPos > 0 Then
                strtemp = Trim(Left(strSql, intPos - 1))
                objSQL.AnalyzerSQL(strtemp)
                strSelect = objSQL.strSelect
                strTable = objSQL.strTable
                strWhere = objSQL.strWhere
                strSql = strSql.Substring(intPos + 15)
                While intPos > 0
                    intPos = InStr(strSql, "AND ITEM.ID IN")
                    If intPos > 0 Then
                        strtemp = Trim(Left(strSql, intPos - 1))
                        strtemp = Left(strtemp, Len(strtemp) - 1)
                        objSQL.AnalyzerSQL(strtemp)
                        AddTableAndWhere(strTable, strWhere, objSQL.strTable, objSQL.strWhere)
                        strSql = strSql.Substring(intPos + 15)
                    End If
                End While
                If strSql <> "" Then
                    strtemp = Left(strSql, Len(strSql) - 1)
                    objSQL.AnalyzerSQL(strtemp)
                    AddTableAndWhere(strTable, strWhere, objSQL.strTable, objSQL.strWhere)
                End If
            End If
            ParseSQL = strFirst & strSelect & " FROM " & strTable & " WHERE " & strWhere & strEnd
        End Function
        Private Sub AddTableAndWhere(ByRef strtb As String, ByRef strwh As String, ByVal strtbs As String, ByVal strwhs As String)
            Dim arrTb() As String = strtbs.Split(",")
            Dim inti As Integer
            strwh = strwh & " and " & strwhs
            For inti = 0 To arrTb.Length - 1
                If InStr(strtb & ",", arrTb(inti) & ",") = 0 Then
                    strtb = strtb & "," & arrTb(inti)
                    If arrTb(inti).Length > 5 AndAlso Left(arrTb(inti).ToUpper, 5) = "ITEM_" Then
                        If InStr(strwh & " and", "ITEM.ID=" & arrTb(inti) & ".ITEMID and") = 0 Then
                            strwh = strwh & " and ITEM.ID=" & arrTb(inti) & ".ITEMID"
                        End If
                    End If
                End If
            Next
        End Sub
    End Class

End Namespace