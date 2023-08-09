' Name: clsBOPACFile
' Purpose: 
' Creator: PhuongTT
' Created Date: 2014.09.03
' Modification History:

Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACFile
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intItemID As Integer
        Private intFileID As Integer
        Private strWordSearch As String
        Private objDOPACFile As New clsDOPACFile
        Private objBCDBS As New clsBCommonDBSystem

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        
        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' ItemID property
        Public Property FileID() As Integer
            Get
                Return intFileID
            End Get
            Set(ByVal Value As Integer)
                intFileID = Value
            End Set
        End Property

        ' WordSearch property
        Public Property WordSearch() As String
            Get
                Return strWordSearch
            End Get
            Set(ByVal Value As String)
                strWordSearch = Value
            End Set
        End Property
        
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACItem object
            objDOPACFile.DBServer = strDBServer
            objDOPACFile.ConnectionString = strConnectionString
            objDOPACFile.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        ' purpose : Get files by ItemID
        ' IN: ItemID
        ' OUT : DataTable
        ' Creator : PhuongTT
        Public Function GetFiles() As DataTable
            objDOPACFile.ItemID = intItemID
            GetFiles = objDOPACFile.GetFiles
        End Function


        Public Function GetItemFile() As DataTable
            objDOPACFile.ItemID = intItemID
            objDOPACFile.FileID = intFileID
            GetItemFile = objDOPACFile.GetItemFile
        End Function

        ' purpose : Get file detail by ItemID
        ' IN: ItemID
        ' OUT : DataTable
        ' Creator : PhuongTT
        Public Function GetFileDetail() As DataTable
            objDOPACFile.ItemID = ItemID
            GetFileDetail = objBCDBS.ConvertTable(objDOPACFile.GetFileDetail, "Content")
        End Function

        ' purpose : Update views statistic
        ' IN: ItemID,Weekly,Monthly,Yearly
        ' OUT : boolean
        ' Creator : PhuongTT
        Public Function updateViews(ByVal ItemID As Integer, ByVal Weekly As Integer, ByVal Monthly As Integer, ByVal Yearly As Integer) As Boolean
            Dim bolResult As Boolean = False
            bolResult = objDOPACFile.updateViews(ItemID, Weekly, Monthly, Yearly)
            Return bolResult
        End Function

        ' purpose : Update views statistic
        ' IN: ItemID,Weekly,Monthly,Yearly
        ' OUT : boolean
        ' Creator : PhuongTT
        Public Function updateViews(ByVal ItemID As Integer, ByVal Weekly As Integer, ByVal Monthly As Integer, ByVal Yearly As Integer, ByVal PatronCode As String) As Boolean
            Dim bolResult As Boolean = False
            bolResult = objDOPACFile.updateViews(ItemID, Weekly, Monthly, Yearly, PatronCode)
            Return bolResult
        End Function

        ' ' Purpose: Get treeview Table of content data
        ' Input: ItemID
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.09.04
        Public Function GetTreeviewTableOfContent() As DataTable
            objDOPACFile.ItemID = ItemID
            GetTreeviewTableOfContent = objDOPACFile.GetTreeviewTableOfContent
        End Function

        ' ' Purpose: Get total of record by ItemID
        ' Input: ItemID
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.09.04
        Public Function GetCountFulltext() As DataTable
            objDOPACFile.ItemID = ItemID
            GetCountFulltext = objDOPACFile.GetCountFulltext
        End Function

        ' ' Purpose: Get all of page document by fulltext search
        ' Input: word search
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.09.05
        Public Function fulltextWordSearch() As DataTable
            objDOPACFile.ItemID = ItemID
            objDOPACFile.WordSearch = WordSearch
            fulltextWordSearch = objDOPACFile.fulltextWordSearch
        End Function


        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACFile Is Nothing Then
                    Call objDOPACFile.Dispose(True)
                    objDOPACFile = Nothing
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