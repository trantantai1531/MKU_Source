' clsBZImport class
' Purpose: used to process ZImport class on BusinessRules layer
' Creator: Oanhtn
' Created Date: 12/08/2004
' Modification History

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBZImport
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strzServer As String
        Private strzPort As String
        Private strzDatabase As String
        Private strzHost As String
        Private strzFormat As String = "usmarc"
        Private strFieldName1 As String
        Private strFieldName2 As String
        Private strFieldName3 As String
        Private strFieldValue1 As String
        Private strFieldValue2 As String
        Private strFieldValue3 As String
        Private strOperator2 As String
        Private strOperator3 As String
        Private blnVietUSMARC As Boolean
        Private strZError As String
        Private intHits As Integer
        Private objRecord As Object
        Private intStart As Integer
        Private intHowmany As Integer

        Private objDCF As New clsDCatalogueForm
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objZclient As MLZ3950.Z3950 'ZCOMLib.client

        ' *******************************************************************************************************
        ' Properties here
        ' *******************************************************************************************************

        ' zServer Property
        Public Property zServer() As String
            Get
                Return strzServer
            End Get
            Set(ByVal Value As String)
                strzServer = Value
            End Set
        End Property

        ' zPort Property
        Public Property zPort() As String
            Get
                Return strzPort
            End Get
            Set(ByVal Value As String)
                strzPort = Value
            End Set
        End Property

        ' zDatabase Property
        Public Property zDatabase() As String
            Get
                Return strzDatabase
            End Get
            Set(ByVal Value As String)
                strzDatabase = Value
            End Set
        End Property

        ' zHost Property
        Public Property zHost() As String
            Get
                Return strzHost
            End Get
            Set(ByVal Value As String)
                strzHost = Value
            End Set
        End Property

        ' zFormat property
        Public Property zFormat() As String
            Get
                zFormat = strzFormat
            End Get
            Set(ByVal Value As String)
                strzFormat = Value
            End Set
        End Property

        ' FieldName1 Property
        Public Property FieldName1() As String
            Get
                Return strFieldName1
            End Get
            Set(ByVal Value As String)
                strFieldName1 = Value
            End Set
        End Property

        ' FieldName2 Property
        Public Property FieldName2() As String
            Get
                Return strFieldName2
            End Get
            Set(ByVal Value As String)
                strFieldName2 = Value
            End Set
        End Property

        ' FieldName3
        Public Property FieldName3() As String
            Get
                Return strFieldName3
            End Get
            Set(ByVal Value As String)
                strFieldName3 = Value
            End Set
        End Property

        ' FieldValue1 property
        Public Property FieldValue1() As String
            Get
                Return strFieldValue1
            End Get
            Set(ByVal Value As String)
                strFieldValue1 = Value
            End Set
        End Property

        ' FieldValue2 property
        Public Property FieldValue2() As String
            Get
                Return strFieldValue2
            End Get
            Set(ByVal Value As String)
                strFieldValue2 = Value
            End Set
        End Property

        ' FieldValue3 property
        Public Property FieldValue3() As String
            Get
                Return strFieldValue3
            End Get
            Set(ByVal Value As String)
                strFieldValue3 = Value
            End Set
        End Property

        ' Operator3 property
        Public Property Operator3() As String
            Get
                Return strOperator3
            End Get
            Set(ByVal Value As String)
                strOperator3 = Value
            End Set
        End Property

        ' Operator2 property
        Public Property Operator2() As String
            Get
                Return strOperator2
            End Get
            Set(ByVal Value As String)
                strOperator2 = Value
            End Set
        End Property

        ' VietUSMARC property
        Public Property VietUSMARC() As Boolean
            Get
                Return blnVietUSMARC
            End Get
            Set(ByVal Value As Boolean)
                blnVietUSMARC = Value
            End Set
        End Property

        ' ZError property
        Public Property ZError() As String
            Get
                Return strZError
            End Get
            Set(ByVal Value As String)
                strZError = Value
            End Set
        End Property

        ' Hits Property
        Public Property Hits() As Integer
            Get
                Return intHits
            End Get
            Set(ByVal Value As Integer)
                intHits = Value
            End Set
        End Property

        ' objRecord Property
        Public Property Record() As Object
            Get
                Return objRecord
            End Get
            Set(ByVal Value As Object)
                objRecord = Value
            End Set
        End Property

        ' Start property
        Public Property Start() As Integer
            Get
                Return intStart
            End Get
            Set(ByVal Value As Integer)
                intStart = Value
            End Set
        End Property

        ' Howmany property
        Public Property Howmany() As Integer
            Get
                Return intHowmany
            End Get
            Set(ByVal Value As Integer)
                intHowmany = Value
            End Set
        End Property

        ' *******************************************************************************************************
        ' Methods here
        ' *******************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objZclient object
            'objZclient = New ZCOMLib.client

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDCF object
            objDCF.DBServer = strDBServer
            objDCF.ConnectionString = strConnectionString
            objDCF.Initialize()
        End Sub

        ' ProccessQuery method
        Public Sub ProccessQuery(Optional ByVal intTop As Integer = 1000)
            Dim strzQuery As String
            Dim blnReInit As Boolean
            Dim intCounter As Integer
            zServer = strzServer
            zPort = strzPort
            zDatabase = strzDatabase
            strzHost = zServer & ":" & zPort & "#" & zDatabase
            strzQuery = FormingZQuery()

            With objZclient
                .Host = strzServer
                .Port = strzPort
                .Database = strzDatabase
                .Top = intTop ' CInt(cboRecordLimit.SelectedValue)
                .Search(strzQuery)
                If Not .Hits = .Fail Then
                    objRecord = .Records
                Else
                    If .zerror <> "" Then
                        strZError = .zerror
                    End If
                End If
            End With

            'objZclient.Format = strzFormat

            '' Reset zServer:zPort
            'If Not objZclient.Host = zServer & ":" & zPort Then
            '    objZclient.Host = zServer & ":" & zPort
            'End If

            '' Reset zDatabase
            'If Not objZclient.Database = zDatabase Then
            '    objZclient.Database = zDatabase
            'End If

            'If Not objZclient.Connected Then
            '    blnReInit = True
            'End If

            '' objZclient Error
            'If objZclient.Init() = objZclient.FAIL Then
            '    strZError = "Init Stage: " & objZclient.LastError
            'Else
            '    Hits = objZclient.Search(strzQuery)
            '    If Hits = objZclient.FAIL Then
            '        strZError = "Init Stage: " & objZclient.LastError
            '    End If
            'End If

            '' Get intHowmany records start with intStart
            'If objZclient.Present(intStart, intHowmany) = objZclient.FAIL Then
            '    strZError = "Present Stage: " & objZclient.LastError
            'End If

            ' Record 
            objRecord = objZclient.Records
            If UBound(objRecord) >= 0 Then
                For intCounter = LBound(objRecord) To UBound(objRecord)
                    objRecord(intCounter, 0) = objBCSP.ZConvertIt(objRecord(intCounter, 0), blnVietUSMARC)
                Next
            End If
        End Sub


        ' FormingZQuery method
        Public Function FormingZQuery() As String
            Dim strQuery As String
            strQuery = strFieldName1 & " """ & strFieldValue1 & """"
            If Not strFieldValue2 = "" Then
                strQuery = strOperator2 & " " & strFieldName2 & " """ & strFieldValue2 & """ " & strQuery
            End If

            If Not strFieldValue3 = "" Then
                strQuery = strOperator3 & " " & strFieldName3 & " """ & strFieldValue3 & """ " & strQuery
            End If

            FormingZQuery = objBCSP.ZConvertItBack(strQuery, blnVietUSMARC)
        End Function

        ' ParseTaggedRecord method
        Public Sub ParseTaggedRecord(ByVal strRec As String, ByRef objTag As Object, ByRef objTagVal As Object, ByVal strDesignator As String)
            ReDim objTag(0)
            ReDim objTagVal(0)
            Dim strTagname As String
            Dim strIndicators As String
            Dim strVal As String
            Dim objTagArr As Object
            Dim intIndex1 As Integer = 0
            Dim intIndex2 As Integer
            Dim intIndex3 As Integer
            strRec = Replace(strRec, strDesignator, "$")
            Call objBCSP.GLoadArray(strRec, objTagArr, "##")
            For intIndex2 = LBound(objTagArr) To UBound(objTagArr) - 1
                strVal = Trim(objTagArr(intIndex2))
                strTagname = Left(strVal, 3)
                If InStr(strTagname, "00") = 1 Then
                    If Len(strVal) > 4 Then
                        strVal = Right(strVal, Len(strVal) - 4)
                    End If
                Else
                    If Len(strVal) > 7 Then
                        strVal = Right(strVal, Len(strVal) - 7)
                    End If
                End If
                intIndex3 = FindIndex(objTag, strTagname)
                If intIndex3 = -1 Then
                    ReDim Preserve objTag(intIndex1)
                    ReDim Preserve objTagVal(intIndex1)
                    objTag(intIndex1) = strTagname
                    objTagVal(intIndex1) = strVal
                    intIndex1 = intIndex1 + 1
                Else
                    objTagVal(intIndex3) = objTagVal(intIndex3) & ". - " & strVal
                End If
            Next
        End Sub

        ' FindIndex method
        Public Function FindIndex(ByVal objTemp As Object, ByVal strTemp As String)
            Dim intTemp As Integer
            Dim intIndex As Integer
            intTemp = -1
            For intIndex = LBound(objTemp) To UBound(objTemp)
                If UCase(strTemp) = UCase(objTemp(intIndex)) Then
                    intTemp = intIndex
                    Exit For
                End If
            Next
            FindIndex = intTemp
        End Function

        ' FindRecordID method
        ' Purpose: Get RecordID
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objZclient Is Nothing Then
                    objZclient = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDCF Is Nothing Then
                    objDCF.Dispose(True)
                    objDCF = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace