' Name: clsBPhotocopyType
' Purpose: allow manage all Type of PhotocopyTypes
' Creator: Oanhtn
' CreatedDate: 17/08/2004
' Modification History:

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBPhotocopyType
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private intTypeID As Integer
        Private strTypeName As String = ""
        Private dblPricePerPage As Double = 0
        Private strTypeIDs As String

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDPhotoType As New clsDPhotocopyType

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' TypeID property
        Public Property TypeID() As Integer
            Get
                Return intTypeID
            End Get
            Set(ByVal Value As Integer)
                intTypeID = Value
            End Set
        End Property

        ' TypeID property
        Public Property TypeIDs() As String
            Get
                Return strTypeIDs
            End Get
            Set(ByVal Value As String)
                strTypeIDs = Value
            End Set
        End Property

        ' TypeName property
        Public Property TypeName() As String
            Get
                Return strTypeName
            End Get
            Set(ByVal Value As String)
                strTypeName = Value
            End Set
        End Property

        ' PricePerPage property
        Public Property PricePerPage() As Double
            Get
                Return dblPricePerPage
            End Get
            Set(ByVal Value As Double)
                dblPricePerPage = Value
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
                ' Init objBCSP object
                objBCSP.ConnectionString = strConnectionString
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                Call objBCSP.Initialize()

                ' Init objDPhotoType object
                objDPhotoType.ConnectionString = strConnectionString
                objDPhotoType.DBServer = strDBServer
                objDPhotoType.Initialize()

                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function CreatePhotocopyType() As Integer
            Try
                objDPhotoType.TypeName = objBCSP.ConvertItBack(strTypeName)
                objDPhotoType.PricePerPage = dblPricePerPage
                CreatePhotocopyType = objDPhotoType.CreatePhotocopyType()
                strErrorMsg = objDPhotoType.ErrorMsg
                intErrorCode = objDPhotoType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function UpdatePhotocopyType() As Integer
            Try
                objDPhotoType.TypeID = intTypeID
                objDPhotoType.TypeName = objBCSP.ConvertItBack(strTypeName)
                objDPhotoType.PricePerPage = dblPricePerPage
                UpdatePhotocopyType = objDPhotoType.UpdatePhotocopyType()
                strErrorMsg = objDPhotoType.ErrorMsg
                intErrorCode = objDPhotoType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' DeletePhotocopyType method
        ' Purpose: Delete information of the selected PhotocopyType
        ' Input: intTypeID
        Public Sub DeletePhotocopyType()
            Try
                objDPhotoType.TypeIDs = objBCSP.ConvertItBack(strTypeIDs)
                objDPhotoType.DeletePhotocopyType()
                strErrorMsg = objDPhotoType.ErrorMsg
                intErrorCode = objDPhotoType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        ' GetPhotocopyTypes method
        ' Purpose: Get information of all PhotocopyTypes
        ' Input: 
        ' Output: datatable result
        Public Function GetPhotocopyTypes() As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                objDPhotoType.TypeIDs = objBCSP.ConvertItBack(strTypeIDs)
                tblResult = objBCDBS.ConvertTable(objDPhotoType.GetPhotocopyTypes())
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    For inti = 0 To tblResult.Rows.Count - 1
                        tblResult.Rows(inti).Item("PricePerPage") = CLng(tblResult.Rows(inti).Item("PricePerPage"))
                    Next
                End If
                GetPhotocopyTypes = tblResult
                strErrorMsg = objDPhotoType.ErrorMsg
                intErrorCode = objDPhotoType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDPhotoType Is Nothing Then
                    objDPhotoType.Dispose(True)
                    objDPhotoType = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace