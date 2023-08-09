Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC


Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACSubjBrowse
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intIDDic As Integer
        Private strWord As String
        Private objDSubjBrowse As New clsDOPACSubjBrowse
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property DicID() As Integer
            Get
                Return intIDDic
            End Get
            Set(ByVal Value As Integer)
                intIDDic = Value
            End Set
        End Property
        Public Property Word() As String
            Get
                Return strWord
            End Get
            Set(ByVal Value As String)
                strWord = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDHoldingCollection object
            objDSubjBrowse.DBServer = strDBServer
            objDSubjBrowse.ConnectionString = strConnectionString
            objDSubjBrowse.Initialize()

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

        Public Function GetSubjBrowse() As DataView
            Dim inti As Integer
            Try
                objDSubjBrowse.DicID = intIDDic
                objDSubjBrowse.Word = strWord
                'If intIDDic = 6 Then
                '    GetSubjBrowse = objBCDBS.SortTable(objBCDBS.ConvertTable(objDSubjBrowse.GetSubjBrowse(), "DisplayEntry"), "DisplayEntry")
                'Else
                GetSubjBrowse = objBCDBS.SortTable(objBCDBS.ConvertTable(objDSubjBrowse.GetSubjBrowse()), "DisplayEntry")
                'End If

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function SelectSubjBrowseByID(ByVal intIDDic As Integer, ByVal intID As Integer) As DataTable
            Dim inti As Integer
            Try
                SelectSubjBrowseByID = objDSubjBrowse.SelectSubjBrowseByID(intIDDic, intID)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        'Dispose method
        'Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
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

    End Class
End Namespace

