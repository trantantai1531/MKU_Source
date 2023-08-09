' Name: clsBCommonTemplate
' Purpose: base for another templates
' Creator: Oanhtn
' CreatedDate: 18/08/2004
' Modification History:
'   + 21/8/2004: by Sondp

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBCommonTemplate
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************
        Protected strCreator As String = ""
        Protected strModifier As String = ""
        Protected strLastModifiedDate As String = ""
        Protected intTemplateID As Integer = 0
        Protected intLenght As Integer
        Protected intTemplateType As Integer
        Protected intStartPosition As Integer
        Protected boolEnable As Boolean
        Protected intEndPosition As Integer
        Protected strName As String = ""
        Protected strContent As String = ""
        Protected strHeader As String = ""
        Protected strFooter As String = ""
        Protected intLibID As Integer

        Protected objBCSP As New clsBCommonStringProc
        Protected objBCDBS As New clsBCommonDBSystem
        Private objDCommonTemplate As New clsDCommonTemplate

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Creator property
        Public Property Creator() As String
            Get
                Return strCreator
            End Get
            Set(ByVal Value As String)
                strCreator = Value
            End Set
        End Property

        'Modifier property
        Public Property Modifier() As String
            Get
                Return (strModifier)
            End Get
            Set(ByVal Value As String)
                strModifier = Value
            End Set
        End Property

        ' LastModifiedDate property
        Public Property LastModifiedDate() As String
            Get
                Return strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property

        ' TemplateID property
        Public Property TemplateID() As Integer
            Get
                Return intTemplateID
            End Get
            Set(ByVal Value As Integer)
                intTemplateID = Value
            End Set
        End Property
        ' Lenght property
        Public Property Lenght() As Integer
            Get
                Return intLenght
            End Get
            Set(ByVal Value As Integer)
                intLenght = Value
            End Set
        End Property

        ' StartPosition property
        Public Property StartPosition() As Integer
            Get
                Return intStartPosition
            End Get
            Set(ByVal Value As Integer)
                intStartPosition = Value
            End Set
        End Property

        ' EndPosition property
        Public Property EndPosition() As Integer
            Get
                Return intEndPosition
            End Get
            Set(ByVal Value As Integer)
                intEndPosition = Value
            End Set
        End Property

        ' EndPosition property
        Public Property Enable() As Boolean
            Get
                Return boolEnable
            End Get
            Set(ByVal Value As Boolean)
                boolEnable = Value
            End Set
              End Property
        'Template Type
        Public Property TemplateType() As Integer
            Get
                Return intTemplateType
            End Get
            Set(ByVal Value As Integer)
                intTemplateType = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' Content property
        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        ' Header property
        Public Property Header() As String
            Get
                Return strHeader
            End Get
            Set(ByVal Value As String)
                strHeader = Value
            End Set
        End Property

        ' Footer property
        Public Property Footer() As String
            Get
                Return strFooter
            End Get
            Set(ByVal Value As String)
                strFooter = Value
            End Set
        End Property
        ' TemplateID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' Init objBCSP object
                objBCSP.ConnectionString = strConnectionString
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                Call objBCSP.Initialize()

                'Init objDCommonTemplate
                objDCommonTemplate.ConnectionString = strConnectionString
                objDCommonTemplate.DBServer = strDBServer
                objDCommonTemplate.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: CreateTemplate
        ' Purpose: Create new Template
        ' Input: some main information of Template
        ' Output: 0 if success, 1 if exists title
        Public Function CreateTemplate() As Integer
            Try
                objDCommonTemplate.Name = objBCSP.ConvertItBack(Replace(Replace(Replace(Replace(strName, "&lt;", "<"), "&gt;", ">"), "'", ""), "''", ""))
                objDCommonTemplate.Creator = objBCSP.ConvertItBack(strCreator)
                objDCommonTemplate.Modifier = objBCSP.ConvertItBack(strModifier)
                objDCommonTemplate.Content = objBCSP.ConvertItBack(Replace(Replace(strContent, "&lt;", "<"), "&gt;", ">"))
                objDCommonTemplate.TemplateType = intTemplateType
                objDCommonTemplate.LibID = intLibID
                CreateTemplate = objDCommonTemplate.CreateTemplate()
                ErrorCode = objDCommonTemplate.ErrorCode
                ErrorMsg = objDCommonTemplate.ErrorMsg
            Catch ex As Exception
                strerrormsg = ex.Message
            Finally
            End Try
        End Function

        ' Function: GetTemplate
        ' Purpose: Create new Template
        ' Input: TemplateType, TemplateID
        ' Output: datatable result
        Public Function GetTemplate() As DataTable
            Try
                objDCommonTemplate.TemplateID = intTemplateID
                objDCommonTemplate.TemplateType = intTemplateType
                objDCommonTemplate.LibID = intLibID
                GetTemplate = objBCDBS.ConvertTable(objDCommonTemplate.GetTemplate)
                ErrorCode = objDCommonTemplate.ErrorCode
                ErrorMsg = objDCommonTemplate.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: UpdateTemplate
        ' Purpose: Update information of the selected Template
        ' Input: some main information of the selected Template
        ' Output: 0 if success, 1 if exists title
        Public Function UpdateTemplate() As Integer
            Try
                objDCommonTemplate.TemplateID = intTemplateID
                objDCommonTemplate.TemplateType = intTemplateType
                objDCommonTemplate.Name = objBCSP.ConvertItBack(Replace(Replace(Replace(strName, "&lt;", "<"), "&gt;", ">"), "'", ""))
                objDCommonTemplate.Content = objBCSP.ConvertItBack(Replace(Replace(strContent, "&lt;", "<"), "&gt;", ">"))
                objDCommonTemplate.LibID = intLibID
                objDCommonTemplate.Modifier = objBCSP.ConvertItBack(strModifier)
                UpdateTemplate = objDCommonTemplate.UpdateTemplate()
                ErrorCode = objDCommonTemplate.ErrorCode
                ErrorMsg = objDCommonTemplate.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

          Public Function UpdateHoldingTemplate() As Integer
            Try
                objDCommonTemplate.TemplateID = intTemplateID
                objDCommonTemplate.Lenght = intLenght
                objDCommonTemplate.StartPosition = intStartPosition
                objDCommonTemplate.EndPosition = intEndPosition
                objDCommonTemplate.Enable = boolEnable
                objDCommonTemplate.LibID = intLibID
                UpdateHoldingTemplate = objDCommonTemplate.UpdateHoldingTemplate()
                ErrorCode = objDCommonTemplate.ErrorCode
                ErrorMsg = objDCommonTemplate.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Function: GetHoldingTemplate
        ' Purpose: GetHoldingTemplate
        ' Input: intLibID
        ' Output: datatable result
        Public Function GetHoldingTemplate() As DataTable
            Try
                objDCommonTemplate.LibID = intLibID
                GetHoldingTemplate = objBCDBS.ConvertTable(objDCommonTemplate.GetHoldingTemplate())
                ErrorCode = objDCommonTemplate.ErrorCode
                ErrorMsg = objDCommonTemplate.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        
        ' Method: DeleteTemplate
        ' Purpose: delete information of the selected Template
        ' Input: intTemplateID
        ' Creator: Sondp
        Public Sub DeleteTemplate()
            Try
                objDCommonTemplate.TemplateID = intTemplateID
                objDCommonTemplate.TemplateType = intTemplateType
                objDCommonTemplate.DeleteTemplate()
                ErrorCode = objDCommonTemplate.ErrorCode
                ErrorMsg = objDCommonTemplate.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Function getArrayFromTemplate(ByVal strContent As String, Optional ByVal strPrefix As String = "<$", Optional ByVal strSuffix As String = "$>") As String()
            Dim strArr() As String
            Try
                Dim intI As Integer = 0
                Dim intSeqPre As Integer = 0
                Dim intSeqSuf As Integer = 0
                Dim strValue As String = ""
                While InStr(strContent, strPrefix) > 0
                    intSeqPre = InStr(strContent, strPrefix) + strPrefix.Length - 1
                    intSeqSuf = InStr(strContent, strSuffix) - strSuffix.Length + 1
                    strValue = strContent.Substring(intSeqPre, intSeqSuf - intSeqPre)
                    ReDim Preserve strArr(intI)
                    strArr(intI) = strValue
                    intI += 1
                    strContent = strContent.Substring(intSeqSuf + strSuffix.Length, strContent.Length - (intSeqSuf + strSuffix.Length))
                End While
            Catch ex As Exception
            End Try
            Return strArr
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDCommonTemplate Is Nothing Then
                    objDCommonTemplate.Dispose(True)
                    objDCommonTemplate = Nothing
                End If
            End If
            Call MyBase.Dispose()
            Call Dispose()
        End Sub
    End Class
End Namespace