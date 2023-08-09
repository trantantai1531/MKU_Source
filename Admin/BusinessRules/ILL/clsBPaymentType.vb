' Name: clsBZ3950Server
' Purpose: Z3950 purpose
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBPaymentType
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private strType As String
        Private intID As Integer

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDPaymentType As New clsDPaymentType

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' Type property 
        Public Property Type() As String
            Get
                Return (strType)

            End Get
            Set(ByVal Value As String)
                strType = Value
            End Set
        End Property

        ' ID property
        Public Property ID() As Integer
            Get
                Return (intID)
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Initialize objDPaymentType object
            objDPaymentType.ConnectionString = strconnectionstring
            objDPaymentType.DBServer = strdbserver
            objDPaymentType.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strinterfacelanguage
            objBCDBS.ConnectionString = strconnectionstring
            objBCDBS.DBServer = strdbserver
            objBCDBS.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strinterfacelanguage
            objBCSP.ConnectionString = strconnectionstring
            objBCSP.DBServer = strdbserver
            objBCSP.Initialize()
        End Sub

        ' Purpose: Get Payment Type 
        ' Input: intID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetPaymentType() As DataTable
            Try
                objDPaymentType.ID = intID
                objDPaymentType.LibID = intLibID
                GetPaymentType = objBCDBS.ConvertTable(objDPaymentType.GetPaymentType())
                strErrorMsg = objDPaymentType.ErrorMsg
                intErrorCode = objDPaymentType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose: Create payment type
        ' Input: strType
        ' Output: integer value (0 if success, 1 if exist)
        ' Creator: Sondp
        Public Function Create() As Integer
            Try
                objDPaymentType.Type = objBCSP.ConvertItBack(strType)
                objDPaymentType.LibID = intLibID
                Create = objDPaymentType.Create()
                strErrorMsg = objDPaymentType.ErrorMsg
                interrorcode = objDPaymentType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose: Update payment type
        ' Input: intID, strType
        ' Output: integer value (0 if success, 1 if exist)
        ' Creator: Sondp
        Public Function Update() As Integer
            Try
                objDPaymentType.ID = intID
                objDPaymentType.Type = objBCSP.ConvertItBack(strType)
                Update = objDPaymentType.Update()
                strErrorMsg = objDPaymentType.ErrorMsg
                intErrorCode = objDPaymentType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Delete payment type
        ' Input: intID
        ' Creator: Sondp
        Public Function Delete() As Integer
            Try
                objDPaymentType.ID = intID
                Delete = objDPaymentType.Delete()
                strErrorMsg = objDPaymentType.ErrorMsg
                intErrorCode = objDPaymentType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDPaymentType Is Nothing Then
                        objDPaymentType.Dispose(True)
                        objDPaymentType = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace