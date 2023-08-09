' Purpose: used to process items
' Creator: Oanhtn
' Created Date: 13/05/2004
' Modification history:
'   - 30/06/2004 by Oanhtn: allow modify contents of the selected Item
'           - Add new method: GetModiFields
'   - 13/8/2004 
'           - Add new method: GetAuthorityInfor method
'           Purpose: Retrieve  Authority infor by searching

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatalogueForm
        Inherits clsBForm

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strPath As String = ""
        Private strGeneralPurpose As String = ""
        Private intCutterType As Integer = 0
        Private strAddedFieldCodes As String = ""
        Private intGroupBy As Integer = 0
        Private lngAuthorityID As Long = 0
        Private strPortalURL As String
        Private strUsedFieldCodes As String
        Private strAccessEntry As String
        Private lngReferenceID As Long

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDCatalogueForm As New clsDCatalogueForm
        'Private objCutter As New libolmisc.misc

        ' *******************************************************************************************************
        ' End declare variables
        ' Declare properties here
        ' *******************************************************************************************************

        ' PortalURL property
        Public ReadOnly Property PortalURL()
            Get
                PortalURL = strPortalURL
            End Get
        End Property

        ' Path property
        Public Property Path() As String
            Get
                Return strPath
            End Get
            Set(ByVal Value As String)
                strPath = Value
            End Set
        End Property

        ' GeneralPurpose property
        Public Property GeneralPurpose() As String
            Get
                Return strGeneralPurpose
            End Get
            Set(ByVal Value As String)
                strGeneralPurpose = Value
            End Set
        End Property

        ' CutterType property
        Public Property CutterType() As Integer
            Get
                Return intCutterType
            End Get
            Set(ByVal Value As Integer)
                intCutterType = Value
            End Set
        End Property

        ' AddedFieldCodes property
        Public Property AddedFieldCodes() As String
            Get
                Return strAddedFieldCodes
            End Get
            Set(ByVal Value As String)
                strAddedFieldCodes = Value
            End Set
        End Property

        ' GroupBy property
        Public Property GroupBy() As Integer
            Get
                Return intGroupBy
            End Get
            Set(ByVal Value As Integer)
                intGroupBy = Value
            End Set
        End Property

        ' AuthorityID property
        Public Property AuthorityID() As Long
            Get
                Return lngAuthorityID
            End Get
            Set(ByVal Value As Long)
                lngAuthorityID = Value
            End Set
        End Property

        ' UsedFieldCodes property
        Public Property UsedFieldCodes() As String
            Get
                Return strUsedFieldCodes
            End Get
            Set(ByVal Value As String)
                strUsedFieldCodes = Value
            End Set
        End Property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' ReferenceID property
        Public Property ReferenceID() As Long
            Get
                Return lngReferenceID
            End Get
            Set(ByVal Value As Long)
                lngReferenceID = Value
            End Set
        End Property

        ' *******************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *******************************************************************************************************

        ' Initialize method
        ' Purpose: init all neccessary objects
        Public Overloads Sub Initialize()
            ' Init objDCatalogueForm object
            objDCatalogueForm.DBServer = strDBServer
            objDCatalogueForm.ConnectionString = strConnectionString
            Call objDCatalogueForm.Initialize()

            ' Init Base object
            MyBase.DBServer = strDBServer
            MyBase.ConnectionString = strConnectionString
            MyBase.InterfaceLanguage = strInterfaceLanguage
            Call MyBase.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()
        End Sub

        ' GetCatalogueFields method
        ' Purpose: Get all fields of the selected catalogue form
        ' Output: datatable
        Public Function GetCatalogueFields() As DataTable
            Try
                objDCatalogueForm.IsAuthority = intIsAuthority
                objDCatalogueForm.FormID = intFormID
                objDCatalogueForm.FieldCodes = Trim(strFieldCodes)
                objDCatalogueForm.AddedFieldCodes = Trim(strAddedFieldCodes)
                objDCatalogueForm.GroupBy = intGroupBy
                GetCatalogueFields = objDCatalogueForm.GetCatalogueFields()
                strSQL = objDCatalogueForm.SQLStatement
                strErrorMsg = objDCatalogueForm.ErrorMsg
                intErrorCode = objDCatalogueForm.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetCutter method
        ' Purpose: calculate cutter value
        ' Input: string to calculate cutter
        ' Output: string of cutter value
        Public Function GetCutter() As String
            Dim intOption As Integer = 0 ' NLV Cutter
            Dim strCutter As String = ""
            Dim strCutterScheme As String
            Dim str090b As String
            Dim objPara() As String = {"OCLC_CUTTER_SCHEME"}
            Dim objSysPara() As Object

            str090b = strGeneralPurpose
            ' Convert to unicode1 if InterfaceLanguage is unicode
            If LCase(strInterfaceLanguage) = "unicode" Then
                objBCSP.InterfaceLanguage = "unicode1"
                str090b = objBCSP.UCS2Back(str090b)
                objBCSP.InterfaceLanguage = strInterfaceLanguage
            End If

            Try
                ' Get OCLC_CUTTER_SCHEME from sys parameter table
                objSysPara = objBCDBS.GetSystemParameters(objPara)
                strCutterScheme = objSysPara(0)
                If intCutterType = 1 Then ' OCLC Cutter
                    If strCutterScheme = "sanborn four-figure" Then
                        intOption = 1
                    Else
                        intOption = 2
                    End If
                End If
                ' Generate Cutter
                Select Case intOption
                    'Case 0
                    '    strCutter = objCutter.GenerateTVQGCutter(str090b)
                    'Case 1
                    '    strCutter = objCutter.GenerateSanborn4FigCutter(str090b, strPath)
                    'Case 2
                    '    strCutter = objCutter.Generate4FigCutter(str090b, strPath)
                End Select
                strErrorMsg = objDCatalogueForm.ErrorMsg
                intErrorCode = objDCatalogueForm.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            GetCutter = objBCSP.ConvertIt(strCutter)
        End Function

        ' GetAuthority method
        ' Purpose: get Authoritydata from FieldAuthority
        ' Output: datatable
        Public Function GetAuthority() As DataTable
            Try
                objDCatalogueForm.AuthorityID = lngAuthorityID
                GetAuthority = objBCDBS.ConvertTable(objDCatalogueForm.GetAuthority)
                strErrorMsg = objDCatalogueForm.ErrorMsg
                intErrorCode = objDCatalogueForm.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' ParseTag method
        Public Sub ParseTag(ByVal strValue As String, ByRef arr1() As Object, ByRef arr2() As Object, ByRef arr3() As Object, ByRef intTagCount As Integer)
            Dim strSubTag As String = ""
            Dim strLastChar As String = ""
            Dim strSubTagVal As String = ""

            intTagCount = 0
            ReDim Preserve arr3(0)
            arr3(0) = ""
            Do While Len(strValue) > 0
                If InStr(strValue, "$") > 0 Then
                    strSubTagVal = Left(strValue, InStr(strValue, "$") - 1)
                    If Not strSubTag = "" Then
                        ReDim Preserve arr1(intTagCount)
                        ReDim Preserve arr2(intTagCount)
                        ReDim Preserve arr3(intTagCount + 1)
                        arr1(intTagCount) = strSubTag
                        arr2(intTagCount) = GEntryTrim(strSubTagVal, strLastChar)
                        If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = "." Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                            arr3(intTagCount + 1) = strLastChar
                        Else
                            arr3(intTagCount + 1) = ""
                        End If
                        intTagCount = intTagCount + 1
                        strLastChar = ""
                    End If
                    strSubTag = Mid(strValue, InStr(strValue, "$"), 2)
                    strValue = Right(strValue, Len(strValue) - InStr(strValue, "$") - 1)
                Else
                    If Not strSubTag = "" Then
                        ReDim Preserve arr1(intTagCount)
                        ReDim Preserve arr2(intTagCount)
                        ReDim Preserve arr3(intTagCount + 1)
                        arr1(intTagCount) = strSubTag
                        arr2(intTagCount) = GEntryTrim(strValue, strLastChar)
                        If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = "." Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                            arr3(intTagCount + 1) = strLastChar
                        Else
                            arr3(intTagCount + 1) = ""
                        End If
                        intTagCount = intTagCount + 1
                        strLastChar = ""
                    End If
                    strValue = ""
                End If
            Loop
        End Sub

        ' GEntryTrim method
        ' Purpose: Get the last character of input string
        ' Input: strInput
        ' Output: string value of the input string after cut last char
        Public Function GEntryTrim(ByVal strInput As String, ByVal strLastChar As String) As String
            strInput = Trim(strInput)
            If strInput <> "" Then
                strLastChar = Right(strInput, 1)
                If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = "." Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                    strInput = Left(strInput, Len(strInput) - 1)
                End If
            Else
                strErrorMsg = "Empty String"
            End If
            GEntryTrim = strInput
        End Function

        ' IsModifyHoldings method
        ' Purpose: Check ModifyHoldings from catalogue module
        ' Input: string value of ALLOW_MODIFY_HOLDINGS_IN_CATALOG_MODULE parameter 
        ' Output: boolean value (true if allow)
        Public Function IsModifyHoldings() As Boolean
            Dim objParameter() As String = {"ALLOW_MODIFY_HOLDINGS_IN_CATALOG_MODULE"}
            Dim objSysParameter() As String
            IsModifyHoldings = False
            Try
                objSysParameter = objBCDBS.GetSystemParameters(objParameter)
                If Not objSysParameter Is Nothing Then
                    If CInt(objSysParameter(0)) = 1 Then
                        IsModifyHoldings = True
                    End If
                End If
                strErrorMsg = objDCatalogueForm.ErrorMsg
                intErrorCode = objDCatalogueForm.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetModiFields method
        ' Purpose: Get all fields of the selected item to modify
        ' Output: datatable
        Public Function GetModiFields() As DataTable
            Try
                objDCatalogueForm.FormID = intFormID
                objDCatalogueForm.IsAuthority = intIsAuthority
                objDCatalogueForm.FieldCodes = Trim(strFieldCodes)
                objDCatalogueForm.AddedFieldCodes = Trim(strAddedFieldCodes)
                objDCatalogueForm.UsedFieldCodes = Trim(strUsedFieldCodes)
                objDCatalogueForm.GroupBy = intGroupBy
                GetModiFields = objDCatalogueForm.GetModiFields()
                strSQL = objDCatalogueForm.SQLStatement
                strErrorMsg = objDCatalogueForm.ErrorMsg
                intErrorCode = objDCatalogueForm.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetAuthorityInfor method 
        Public Function GetAuthorityInfor(ByVal intISCode As Byte, ByVal intFormID As Byte) As DataTable
            Try
                objDCatalogueForm.AccessEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(strAccessEntry))
                objDCatalogueForm.ReferenceID = lngReferenceID
                GetAuthorityInfor = objDCatalogueForm.GetAuthorityInfor(intISCode, intFormID)
            Catch ex As Exception
                strErrorMsg = ex.Message
                intErrorCode = objDCatalogueForm.ErrorCode
            Finally
            End Try
        End Function

        ' Dispose method
        ' Release all resources
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDCatalogueForm Is Nothing Then
                    objDCatalogueForm.Dispose(True)
                    objDCatalogueForm = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                'If Not objCutter Is Nothing Then
                '    objCutter = Nothing
                'End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace