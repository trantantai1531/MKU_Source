' Class: clsBCopyRightCompliance
' Purpose: Management copiright compliance
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBCopyRightCompliance
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private strName As String
        Private intID As Integer

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDCopyRight As New clsDCopyRightCompliance

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' Type property 
        Public Property Name() As String
            Get
                Return (strName)
            End Get
            Set(ByVal Value As String)
                strName = Value
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
        ' Purpose: init all neccessary objects
        Public Sub Initialize()
            ' Initialize objDCopyRight object
            objDCopyRight.ConnectionString = strConnectionString
            objDCopyRight.DBServer = strDBServer
            Call objDCopyRight.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.DBServer = strDBServer
            Call objBCDBS.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.ConnectionString = strConnectionString
            objBCSP.DBServer = strDBServer
            Call objBCSP.Initialize()
        End Sub

        ' Method: GetCopyright
        ' Purpose: Get copyright
        ' Input: intID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetCopyright() As DataTable
            Try
                objDCopyRight.ID = intID
                objDCopyRight.LibID = intLibID
                GetCopyright = objBCDBS.ConvertTable(objDCopyRight.GetCopyright())
                strErrorMsg = objDCopyRight.ErrorMsg
                intErrorCode = objDCopyRight.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose: Create copy right
        ' Input: strName, strSelectMode
        ' Creator: Sondp
        Public Function Create() As Integer
            Try
                objDCopyRight.Name = Trim(objBCSP.ConvertItBack(strName))
                objDCopyRight.LibID = intLibID
                Create = objDCopyRight.Create()
                strErrorMsg = objDCopyRight.ErrorMsg
                interrorcode = objDCopyRight.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose: Update copy right
        ' Input: strName, intID
        ' Creator: Sondp
        Public Function Update() As Integer
            Try
                objDCopyRight.ID = intID
                objDCopyRight.Name = Trim(objBCSP.ConvertItBack(strName))
                Update = objDCopyRight.Update()
                strErrorMsg = objDCopyRight.ErrorMsg
                intErrorCode = objDCopyRight.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Delete
        ' Purpose: Delete copy right
        ' Input: intID
        ' Creator: Sondp
        Public Function Delete() As Integer
            Try
                objDCopyRight.ID = intID
                Delete = objDCopyRight.Delete()
                strErrorMsg = objDCopyRight.ErrorMsg
                intErrorCode = objDCopyRight.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDCopyRight Is Nothing Then
                        objDCopyRight.Dispose(True)
                        objDCopyRight = Nothing
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