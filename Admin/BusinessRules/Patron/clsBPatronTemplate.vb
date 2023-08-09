' Name: clsBPatronTemplate
' Purpose: Template process
' Creator: Sondp
' Created Date: 12/1/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron

    Public Class clsBPatronTemplate
        Inherits clsBBase
        Private objDPatronTemplate As New clsDPatronTemplate
        Private objBCT As New clsBCommonTemplate
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Protected strCreator As String = ""
        Protected strModifier As String = ""
        Protected strLastModifiedDate As String = ""
        Protected intTemplateID As Integer = 0
        Protected intTemplateType As Integer = 0
        Protected strName As String = ""
        Protected strContent As String = ""
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
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

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                ' Init objBCT object
                objBCT.ConnectionString = strConnectionString
                objBCT.DBServer = strDBServer
                objBCT.InterfaceLanguage = strInterfaceLanguage
                Call objBCT.Initialize()

                ' Init objDPatronTemplate object
                objDPatronTemplate.ConnectionString = strConnectionString
                objDPatronTemplate.DBServer = strDBServer
                Call objDPatronTemplate.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose : GetPatronTemplate
        ' In: TemplateID, TemplateType
        ' Out: Datatable
        ' Created by: Sondp
        Public Function GetPatronTemplate() As DataTable
            Try
                objBCT.TemplateID = intTemplateID
                objBCT.TemplateType = intTemplateType
                GetPatronTemplate = objBCT.GetTemplate
                strerrormsg = objBCT.ErrorMsg
                interrorcode = objBCT.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' Purpose : Create one PatronTemplate
        ' In: Some informations
        ' Out: integer(1: successful, else 0)
        ' Created by: Sondp
        Public Function Create() As Integer
            Try
                objBCT.Name = strName
                objBCT.Creator = strCreator
                objBCT.Modifier = strModifier
                objBCT.Content = strContent
                objBCT.TemplateType = intTemplateType
                Create = objBCT.CreateTemplate()
                ErrorCode = objBCT.ErrorCode
                ErrorMsg = objBCT.ErrorMsg
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' Purpose : Update one PatronTemplate
        ' In: Some informations
        ' Out: integer(1: successful, else 0)
        ' Created by: Sondp
        Public Function Update() As Integer
            Try
                objBCT.TemplateID = intTemplateID
                objBCT.TemplateType = intTemplateType
                objBCT.Name = strName.Replace("'", "")
                objBCT.Content = strContent.Replace("'", "")
                objBCT.Modifier = strModifier.Replace("'", "")
                objBCT.UpdateTemplate()
                ErrorCode = objBCT.ErrorCode
                ErrorMsg = objBCT.ErrorMsg
                Update = 1
            Catch ex As Exception
                strErrorMsg = ex.Message
                Update = 0
            End Try
        End Function

        ' Purpose : Delete one PatronTemplate
        ' In: Some informations
        ' Out: integer(1: successful, else 0)
        ' Created by: Sondp
        Public Function Delete() As Integer
            Try
                objBCT.TemplateID = intTemplateID
                objBCT.TemplateType = intTemplateType
                objBCT.DeleteTemplate()
                ErrorCode = objBCT.ErrorCode
                ErrorMsg = objBCT.ErrorMsg
                Delete = 1
            Catch ex As Exception
                strErrorMsg = ex.Message
                Delete = 0
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDPatronTemplate Is Nothing Then
                    objDPatronTemplate.Dispose(True)
                    objDPatronTemplate = Nothing
                End If
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace