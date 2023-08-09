'KhoaNA created
'Date created 15/04/2004
'Modified by HieuNT on 26/7/2004
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCataDefault
        Inherits clsBBase
        Private boolIsAuthority As Boolean = False
        Private strFieldCode As String
        Private strIndicator As String
        Private strFieldValue As String
        Private strSeparate As String
        Private blnRepeat As Boolean
        Private hidAction As String
        Private strID As String
        'private object
        Private strOldIndicator As String

        Private objDField As New clsDField
        Public Property ID() As String
            Get
                ID = strID
            End Get
            Set(ByVal Value As String)
                strID = Value
            End Set
        End Property
        Public Property OldIndicator() As String
            Get
                OldIndicator = strOldIndicator
            End Get
            Set(ByVal Value As String)
                strOldIndicator = Value
            End Set
        End Property
        Public Property Action() As String
            Get
                Action = hidAction
            End Get
            Set(ByVal Value As String)
                hidAction = Value
            End Set
        End Property
        'Repeat property
        Public Property Repeat() As Boolean
            Get
                Repeat = blnRepeat
            End Get
            Set(ByVal Value As Boolean)
                blnRepeat = Value
            End Set
        End Property
        'Separate
        Public Property Separate() As String
            Get
                Separate = strSeparate
            End Get
            Set(ByVal Value As String)
                strSeparate = Value
            End Set
        End Property
        'FieldCode
        Public Property FieldCode() As String
            Get
                FieldCode = strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property
        'Indicator
        Public Property Indicator() As String
            Get
                Indicator = strIndicator
            End Get
            Set(ByVal Value As String)
                strIndicator = Value
            End Set
        End Property
        'FieldValue
        Public Property FieldValue() As String
            Get
                FieldValue = strFieldValue
            End Get
            Set(ByVal Value As String)
                strFieldValue = Value
            End Set
        End Property
        'intIsAuthority Property
        Public Property IsAuthority() As Boolean
            Get
                IsAuthority = boolIsAuthority
            End Get
            Set(ByVal Value As Boolean)
                boolIsAuthority = Value
            End Set
        End Property
        'If IsAuthority=0,1 then
        Public Function MakeDataTable(ByRef secFieldCode, ByRef secIndicator, ByRef secFieldValue, ByRef secIDs) As DataTable
            Dim arrFieldCode()
            Dim arrIndicator()
            Dim arrFieldValue()
            Dim arrIDs()
            Dim i As Integer
            'If InStr(secFieldCode, strFieldCode) > 0 Then
            arrIDs = Split(secIDs, strSeparate)
            If hidAction = "ADD" Then
                'True la khong lap
                If blnRepeat = False And InStr(secFieldCode, strFieldCode) > 0 Then
                    'If blnRepeat = False And InStr(secFieldCode, strFieldCode) > 0 And InStr(secFieldValue, strFieldValue) > 0 Then
                    hidAction = "UPDATE"
                Else
                    secFieldCode = secFieldCode & strSeparate & strFieldCode
                    secIndicator = secIndicator & strSeparate & strIndicator
                    secFieldValue = secFieldValue & strSeparate & strFieldValue
                    secIDs = secIDs & strSeparate & UBound(arrIDs)
                End If
            End If

            'strSeparate la dau :::
            arrFieldCode = Split(secFieldCode, strSeparate)
            arrIndicator = Split(secIndicator, strSeparate)
            arrFieldValue = Split(secFieldValue, strSeparate)
            arrIDs = Split(secIDs, strSeparate)
            'Tao mot DataTable tam tblTmp, lam trung gian
            Dim tblTmp As DataTable = New DataTable("Temp")
            Dim dtcCols As DataColumn
            Dim dtrRow As DataRow

            ' tao cot thu nhat va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "ID"
            tblTmp.Columns.Add(dtcCols)

            ' tao cot thu hai va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "FieldCode"
            tblTmp.Columns.Add(dtcCols)

            ' tao cot thu ba va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "Indicator"
            tblTmp.Columns.Add(dtcCols)

            ' tao cot thu tu va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "FieldValue"
            tblTmp.Columns.Add(dtcCols)

            secIDs = ""
            secFieldCode = ""
            secIndicator = ""
            secFieldValue = ""
            For i = 0 To UBound(arrFieldCode)
                ' them thanh phan trong array vao row
                If Len(arrFieldCode(i)) > 0 Then
                    Select Case hidAction
                        Case "MODIFY"
                            dtrRow = tblTmp.NewRow()
                            If CInt(arrIDs(i)) = CInt(strID) Then
                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = strFieldCode
                                dtrRow("Indicator") = strIndicator
                                dtrRow("FieldValue") = strFieldValue
                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & strFieldCode
                                secIndicator = secIndicator & strSeparate & strIndicator
                                secFieldValue = secFieldValue & strSeparate & strFieldValue
                            Else
                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = arrFieldCode(i)
                                dtrRow("Indicator") = arrIndicator(i)
                                dtrRow("FieldValue") = arrFieldValue(i)
                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                                secIndicator = secIndicator & strSeparate & arrIndicator(i)
                                secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            End If
                            tblTmp.Rows.Add(dtrRow)
                        Case "DELETE"
                            If arrIDs(i) <> strID Then
                                dtrRow = tblTmp.NewRow()

                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = arrFieldCode(i)
                                dtrRow("Indicator") = arrIndicator(i)
                                dtrRow("FieldValue") = arrFieldValue(i)
                                secIDs = secIDs & strSeparate & arrIDs(i)

                                secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                                secIndicator = secIndicator & strSeparate & arrIndicator(i)
                                secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                                tblTmp.Rows.Add(dtrRow)
                            End If
                        Case "ADD"
                            dtrRow = tblTmp.NewRow()

                            dtrRow("ID") = arrIDs(i)
                            dtrRow("FieldCode") = arrFieldCode(i)
                            dtrRow("Indicator") = arrIndicator(i)
                            dtrRow("FieldValue") = arrFieldValue(i)
                            secIDs = secIDs & strSeparate & arrIDs(i)
                            secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                            secIndicator = secIndicator & strSeparate & arrIndicator(i)
                            secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            tblTmp.Rows.Add(dtrRow)

                        Case "UPDATE"
                            dtrRow = tblTmp.NewRow()
                            If arrFieldCode(i) = strFieldCode Then

                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = strFieldCode
                                dtrRow("Indicator") = strIndicator
                                dtrRow("FieldValue") = strFieldValue

                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & strFieldCode
                                secIndicator = secIndicator & strSeparate & strIndicator
                                secFieldValue = secFieldValue & strSeparate & strFieldValue
                            Else
                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = arrFieldCode(i)
                                dtrRow("Indicator") = arrIndicator(i)
                                dtrRow("FieldValue") = arrFieldValue(i)
                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                                secIndicator = secIndicator & strSeparate & arrIndicator(i)
                                secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            End If
                            tblTmp.Rows.Add(dtrRow)
                        Case Else
                            dtrRow = tblTmp.NewRow()

                            dtrRow("ID") = arrIDs(i)
                            dtrRow("FieldCode") = arrFieldCode(i)
                            dtrRow("Indicator") = arrIndicator(i)
                            dtrRow("FieldValue") = arrFieldValue(i)
                            secIDs = secIDs & strSeparate & arrIDs(i)
                            secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                            secIndicator = secIndicator & strSeparate & arrIndicator(i)
                            secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            tblTmp.Rows.Add(dtrRow)
                    End Select
                End If
            Next
            Return tblTmp
        End Function
        Public Sub Initialize()
            'objDCatDicList Properties
            objDField.DBServer = strDBServer
            objDField.ConnectionString = strConnectionString
            objDField.Initialize()
        End Sub
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDField Is Nothing Then
                        objDField.Dispose(True)
                        objDField = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace