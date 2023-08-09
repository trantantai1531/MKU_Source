Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACEDelivTools
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDEDeTool As New clsDOPACEDelivTools
        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private intRequestID As Integer

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' Release resource method

        ' Request ID property
        Public Property RequestID() As Integer
            Get
                Return intRequestID
            End Get
            Set(ByVal Value As Integer)
                intRequestID = Value
            End Set
        End Property

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBSP.DBServer = strDBServer
            objBSP.ConnectionString = strConnectionString
            objBSP.InterfaceLanguage = strInterfaceLanguage
            objBSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDAcqPurchaseOrder object
            objDEDeTool.DBServer = strDBServer
            objDEDeTool.ConnectionString = strConnectionString
            objDEDeTool.Initialize()
        End Sub

        ' purpose : Read all informations about Currency
        ' Created by: dgsoft
        Public Function GetCurrency() As DataTable
            Try
                GetCurrency = objDEDeTool.GetCurrency
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' purpose : Read all informations about Receive
        ' Created by: dgsoft
        Public Function GetReceiveMode() As DataTable
            'Try
            GetReceiveMode = objDEDeTool.GetCurrency
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Function

        ' GetCountries fucntion
        ' Purpose: Get all countries in the system
        Public Function GetCountries() As DataTable
            Try
                GetCountries = objBCDBS.ConvertTable(objDEDeTool.GetCountries)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSP Is Nothing Then
                    objBSP.Dispose(True)
                    objBSP = Nothing
                End If
                If Not objDEDeTool Is Nothing Then
                    objDEDeTool.Dispose(True)
                    objDEDeTool = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace