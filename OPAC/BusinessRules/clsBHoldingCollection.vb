Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC


Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBHoldingCollection
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intItemID As Integer
        Private objDHoldingCollection As New clsDHoldingCollection
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' CardNo property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDHoldingCollection object
            objDHoldingCollection.DBServer = strDBServer
            objDHoldingCollection.ConnectionString = strConnectionString
            objDHoldingCollection.Initialize()

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

        ' Purpose: GenerateHoldingComposit
        ' Input: 
        ' Output: 
        ' Created by:
        Public Function GenerateHoldingComposit() As String
            Try

            Catch ex As Exception

            End Try
        End Function

        Public Function GetHoldingInfor() As DataTable
            Dim inti As Integer
            Try
                objDHoldingCollection.ItemID = intItemID
                GetHoldingInfor = objBCDBS.ConvertTable(objDHoldingCollection.GetHoldingInfor)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDHoldingCollection Is Nothing Then
                    Call objDHoldingCollection.Dispose(True)
                    objDHoldingCollection = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace