Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACLocation
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intLocationID As Integer
        Private objDOPACLocation As New clsDOPACLocation
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private intLibID As Integer
        Private intItemID As Integer
        Private intLocID As Integer
        Private strLanguage As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' LocID property
        Public Property LocID() As Integer
            Get
                Return intLocID
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' LocationID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        Public Property Language() As String
            Get
                Return strLanguage
            End Get
            Set(ByVal Value As String)
                strLanguage = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACLocation object
            objDOPACLocation.DBServer = strDBServer
            objDOPACLocation.ConnectionString = strConnectionString
            objDOPACLocation.Initialize()

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
        End Sub

        ' Purpose: GetCalendar
        ' Input: dtFromdate, dtTodate, intLocationID
        ' Output: DataTable
        ' Created by: dgsoft2016
        Public Function GetCalendar(ByVal intMonth As Integer, ByVal intYear As Integer, ByVal intLocationID As Integer, Optional ByVal chrSelectMode As Char = "0") As DataTable
            Try
                Select Case chrSelectMode
                    Case "1"
                        GetCalendar = objDOPACLocation.GetCalendar(intMonth, intYear, intLocationID, chrSelectMode)
                    Case Else
                        GetCalendar = objBCDBS.ConvertTable(objDOPACLocation.GetCalendar(intMonth, intYear, intLocationID, chrSelectMode))
                End Select
                strerrormsg = objDOPACLocation.ErrorMsg
                interrorcode = objDOPACLocation.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function


        ' Purpose: Get all locations in all libraries
        ' Input: 
        ' Output: DataTable
        ' Created by: dgsoft2016
        Public Function GetAllLocations() As DataTable
            Try
                GetAllLocations = objBCDBS.ConvertTable(objDOPACLocation.GetAllLocations)
                strerrormsg = objDOPACLocation.ErrorMsg
                interrorcode = objDOPACLocation.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function
        ' Purpose: Get infor's map in Location shelf Schema
        ' Created by: dgsoft2016
        Public Function GetInfoShelfLocation() As DataTable
            'Try
            objDOPACLocation.LocID = intLocID
            GetInfoShelfLocation = objDOPACLocation.GetInfoShelfLocation
            strerrormsg = objDOPACLocation.ErrorMsg
            interrorcode = objDOPACLocation.ErrorCode
            'Catch ex As Exception
            '    strerrormsg = ex.Message
            'End Try
        End Function
        ' Purpose: Get infor's map in Holding shelf Schema
        ' Created by: dgsoft2016
        Public Function GetHoldingShelfSchema() As DataTable
            Try
                objDOPACLocation.LocID = intLocID
                GetHoldingShelfSchema = objBCDBS.ConvertTable(objDOPACLocation.GetHoldingShelfSchema)
                strerrormsg = objDOPACLocation.ErrorMsg
                interrorcode = objDOPACLocation.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function
        ' Purpose: Get infor's map in Holding location Schema
        ' Created by: dgsoft2016
        Public Function GetHoldingLocSchema() As DataTable
            Try
                objDOPACLocation.LocID = intLocID
                GetHoldingLocSchema = objBCDBS.ConvertTable(objDOPACLocation.GetHoldingLocSchema)
                strerrormsg = objDOPACLocation.ErrorMsg
                interrorcode = objDOPACLocation.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' Purpose: Get infor's map in Holding location Schema
        ' Created by: dgsoft2016
        Public Function GetHoldingLocSchemaImage() As Byte()
            Dim tblResult As DataTable
            Try
                objBCDBS.SQLStatement = "select imgbyte from holding_location_schema WHERE LocID =" & intLocID
                tblResult = objBCDBS.RetrieveItemInfor
                GetHoldingLocSchemaImage = tblResult.Rows(0).Item(0)
                strerrormsg = objBCDBS.ErrorMsg
                interrorcode = objBCDBS.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function


        ' Purpose: Get Content in Field200s with Fieldcodes=448
        ' Created by: dgsoft2016
        Public Function GetContentField200s() As String
            Dim tblField200s As DataTable
            Try
                objDOPACLocation.ItemID = intItemID
                tblField200s = objBCDBS.ConvertTable(objDOPACLocation.GetContentField200s)
                GetContentField200s = objBCSP.TrimSubFieldCodes(tblField200s.Rows(0).Item("Content"))
                strerrormsg = objDOPACLocation.ErrorMsg
                interrorcode = objDOPACLocation.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function



        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACLocation Is Nothing Then
                    Call objDOPACLocation.Dispose(True)
                    objDOPACLocation = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub

        ' Purpose: Get all locations in all libraries
        ' Input: 
        ' Output: DataTable
        ' Created by: dgsoft2016
        Public Function GetAllLibrary() As DataTable
            Dim dtResult As DataTable = Nothing
            Try
                objDOPACLocation.Language = strLanguage
                dtResult = objBCDBS.ConvertTable(objDOPACLocation.GetAllLibrary)
                strErrorMsg = objDOPACLocation.ErrorMsg
                intErrorCode = objDOPACLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dtResult
        End Function

    End Class
End Namespace