' Class: Statistic
' Purpose: Statistic purpose
' Creator: Sondp
' Created date: 02/02/2005
' Modification history:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.Globalization

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBStatistic
        Inherits clsBBase

        Private objDS As New clsDStatistic
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strDAP As String  ' Display DAP
        Private strBAP As String ' Display BAP
        Private strMoney As String ' Money Total
        Private lgTotalBooks As Long
        Private lgTotalCopies As Long
        Private strIndex As String  ' DDC or BBK 
        Private strWhere As String
        Private strBranch As String
        Private objArrLabelChart As Object
        Private objArrDataChart As Object
        Private objArrDataChartNext As Object
        Private objArrlabelChartNext As Object
        Private objArrDataMoney As Object
        Private objArrLabelMoney As Object

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' DataMoney property
        Public ReadOnly Property ArrDataMoney() As Object
            Get
                Return (objArrDataMoney)
            End Get
        End Property

        ' LabelMoney property
        Public ReadOnly Property ArrLabelMoney() As Object
            Get
                Return (objArrLabelMoney)
            End Get
        End Property

        ' Branch property
        Property Branch() As String
            Get
                Return (strBranch)
            End Get
            Set(ByVal Value As String)
                strBranch = Value
            End Set
        End Property

        ' Where property
        Property Where() As String
            Get
                Return (strWhere)
            End Get
            Set(ByVal Value As String)
                strWhere = Value
            End Set
        End Property

        ' Index property
        Property Index() As String
            Get
                Return (strIndex)
            End Get
            Set(ByVal Value As String)
                strIndex = Value
            End Set
        End Property

        ' Lay mang du lieu de hien thi ( truong hop co hon 4 bieu do, nho hon 6 bieu do )
        Public ReadOnly Property ArrDataChartNext() As Object
            Get
                Return (objArrDataChartNext)
            End Get
        End Property

        ' Lay mang nhan (label) de hien thi ( truong hop co hon 4 bieu do, nho hon 6 bieu do )
        Public ReadOnly Property ArrLabelChartNext() As Object
            Get
                Return (objArrlabelChartNext)
            End Get
        End Property

        ' Lay mang du lieu de hien thi
        Public ReadOnly Property ArrDataChart() As Object
            Get
                Return objArrDataChart
            End Get
        End Property

        ' Lay mang nhan de hien thi
        Public ReadOnly Property ArrLabelChart() As Object
            Get
                Return objArrLabelChart
            End Get
        End Property

        ' Property get/set total books
        Public Property TotalBook() As Long
            Get
                Return (lgTotalBooks)
            End Get
            Set(ByVal Value As Long)
                lgTotalBooks = Value
            End Set
        End Property

        ' Property get/set total vollum ( dau an pham )
        Public Property TotalCopies() As Long
            Get
                Return (lgTotalCopies)
            End Get
            Set(ByVal Value As Long)
                lgTotalCopies = Value
            End Set
        End Property

        'property get/set label to display on Header form
        Public Property DAP() As String
            Get
                Return (strDAP)
            End Get
            Set(ByVal Value As String)
                strDAP = Value
            End Set
        End Property

        'property get/set label to display on Header form
        Public Property BAP() As String
            Get
                Return (strBAP)
            End Get
            Set(ByVal Value As String)
                strBAP = Value
            End Set
        End Property

        ' Property Money
        Public Property Money() As String
            Get
                Return (strMoney)
            End Get
            Set(ByVal Value As String)
                strMoney = Value
            End Set
        End Property

        ' Init all objects
        Public Sub Initialize()
            ' Initialize objDS object
            objDS.ConnectionString = strconnectionstring
            objDS.DBServer = strdbserver
            objDS.Initialize()
            ' Initialize objBCDBS object
            objBCDBS.ConnectionString = strconnectionstring
            objBCDBS.DBServer = strdbserver
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
            ' Initialize objBCSP object
            objBCSP.ConnectionString = strconnectionstring
            objBCSP.DBServer = strdbserver
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()
        End Sub

        ' Purpose: Statistic Top 20
        ' Input: intTop20ID, some informations
        ' Output: 
        ' Creator: Sondp
        Public Sub StatTop20(ByVal strDAPTotal As String, ByVal strBAPTotal As String, ByVal intTop20ID As Integer)
            Dim tblCatDicList As DataTable
            Dim tblAcqTop20 As DataTable
            Dim tblRetrieveData As DataTable
            Dim ArrDataDAP() As Integer
            Dim ArrLabelDAP() As String
            Dim ArrDataBAP() As Integer
            Dim ArrLabelBAP() As String
            Dim inti As Integer
            Dim intk As Integer
            Dim intj As Integer
            Dim strIDs As String = ""
            Dim dtrRetrieveData As DataRow()
            Dim rowTop20 As DataRow
            objArrDataChart = Nothing
            objArrLabelChart = Nothing
            objArrDataChartNext = Nothing
            objArrlabelChartNext = Nothing
            Try
                ' Phan thuc hien tinh toan va thong ke top 20 theo tieu chi chon loc, nhan vao la mot ID cua tieu chi thong ke thong qua intTop20ID 
                If intTop20ID = 0 Then ' Khong chon lua, se khong thuc hien thong ke gi ca va tra lai 4 mang rong
                    ReDim ArrDataDAP(0)
                    ReDim ArrLabelDAP(0)
                    ArrDataDAP(0) = 0
                    ArrLabelDAP(0) = "NOT FOUND"
                    ReDim ArrDataBAP(0)
                    ReDim ArrLabelBAP(0)
                    ArrDataBAP(0) = 0
                    ArrLabelBAP(0) = "NOT FOUND"
                    objArrLabelChart = ArrLabelDAP
                    objArrDataChart = ArrDataDAP
                    objArrlabelChartNext = ArrLabelBAP
                    objArrDataChartNext = ArrDataBAP
                Else ' Thuc hien thong ke
                    ' THONG KE CHO DAU AN PHAM
                    objDS.TypeSelect = UCase("DAPTOTAL")
                    tblAcqTop20 = objDS.StatTop20
                    strErrorMsg = objDS.ErrorMsg
                    interrorcode = objDS.ErrorCode
                    If Not tblAcqTop20 Is Nothing Then
                        If tblAcqTop20.Rows.Count > 0 Then
                            lgTotalBooks = CLng(tblAcqTop20.Rows(0).Item("TotalBook"))
                            lgTotalCopies = CLng(tblAcqTop20.Rows(0).Item("TotalCopies")) '
                        Else
                            lgTotalBooks = 0
                            lgTotalCopies = 0
                        End If
                    End If
                    tblAcqTop20 = Nothing
                    objBCDBS.SQLStatement = "SELECT * FROM Cat_tblDicList WHERE ID=" & intTop20ID & "  AND IndexTable IS NOT NULL"
                    tblCatDicList = objBCDBS.RetrieveItemInfor
                    strErrorMsg = objBCDBS.ErrorMsg
                    interrorcode = objBCDBS.ErrorCode
                    strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B></B><SMALL>" & strDAPTotal & lgTotalBooks & "</SMALL></TD></TR><TR>"
                    If Not strDBServer = "ORACLE" Then 'SQL
                        If tblCatDicList.Rows(0).Item("IndexIDField") = "CountryID" Then
                            objBCDBS.SQLStatement = "SELECT TOP 20 Count(*) AS Total," & tblCatDicList.Rows(0).Item("IndexIDField") & " AS Label FROM " & tblCatDicList.Rows(0).Item("IndexTable") & " WHERE FieldCode='044$a' GROUP BY " & tblCatDicList.Rows(0).Item("IndexIDField") & " ORDER BY Total DESC"
                        Else
                            objBCDBS.SQLStatement = "SELECT TOP 20 Count(*) AS Total," & tblCatDicList.Rows(0).Item("IndexIDField") & " AS Label FROM " & tblCatDicList.Rows(0).Item("IndexTable") & " GROUP BY " & tblCatDicList.Rows(0).Item("IndexIDField") & " ORDER BY Total DESC"
                        End If
                    Else 'ORACLE
                        If tblCatDicList.Rows(0).Item("IndexIDField") = "CountryID" Then
                            objBCDBS.SQLStatement = "SELECT A.Total,A.Label FROM (SELECT Count(*) AS Total," & tblCatDicList.Rows(0).Item("IndexIDField") & " AS Label FROM " & tblCatDicList.Rows(0).Item("IndexTable") & " WHERE FieldCode='044$a' GROUP BY " & tblCatDicList.Rows(0).Item("IndexIDField") & " ORDER BY Total DESC) A WHERE Rownum<=20"
                        Else
                            objBCDBS.SQLStatement = "SELECT A.Total,A.Label FROM (SELECT Count(*) AS Total," & tblCatDicList.Rows(0).Item("IndexIDField") & " AS Label FROM " & tblCatDicList.Rows(0).Item("IndexTable") & " GROUP BY " & tblCatDicList.Rows(0).Item("IndexIDField") & " ORDER BY Total DESC) A WHERE Rownum<=20"
                        End If
                    End If
                    tblAcqTop20 = Nothing
                    ' Lay du lieu ra day se la bang chua Total
                    objBCDBS.LibID = intLibID
                    tblAcqTop20 = objBCDBS.RetrieveItemInfor
                    strErrorMsg = objBCDBS.ErrorMsg
                    interrorcode = objBCDBS.ErrorCode
                    If Not tblAcqTop20 Is Nothing Then
                        If tblAcqTop20.Rows.Count > 0 Then ' Co du lieu thi se thuc hien viec thong ke cho dau an pham
                            ' strIDs se la mot chuoi chua cac truong ma sau nay cac truong select tu bang Lib_tblItem va HOLDING ra phai dua nhieu vao no
                            For inti = 0 To tblAcqTop20.Rows.Count - 1
                                strIDs = strIDs & tblAcqTop20.Rows(inti).Item("Label") & ","
                            Next
                            strIDs = Left(strIDs, strIDs.Length - 1)
                            If Not strDBServer = "ORACLE" Then
                                objBCDBS.SQLStatement = "SELECT " & tblCatDicList.Rows(0).Item("DicIDField") & " AS ID, isnull(" & tblCatDicList.Rows(0).Item("CaptionField") & ",'Unknown') AS Label FROM " & tblCatDicList.Rows(0).Item("DicTable") & " WHERE " & tblCatDicList.Rows(0).Item("DicIDField") & " IN (" & strIDs & ")"
                            Else
                                objBCDBS.SQLStatement = "SELECT " & tblCatDicList.Rows(0).Item("DicIDField") & " AS ID, nvl(" & tblCatDicList.Rows(0).Item("CaptionField") & ",'Unknown') AS Label FROM " & tblCatDicList.Rows(0).Item("DicTable") & " WHERE " & tblCatDicList.Rows(0).Item("DicIDField") & " IN (" & strIDs & ")"
                            End If
                            strSQL = objBCDBS.SQLStatement
                            tblRetrieveData = objBCDBS.RetrieveItemInfor ' Lay du lieu tu cau lenh select tren day se la bang se chua Label
                            strErrorMsg = objBCDBS.ErrorMsg
                            interrorcode = objBCDBS.ErrorCode
                            If Not tblRetrieveData Is Nothing Then
                                If tblRetrieveData.Rows.Count > 0 Then ' Co du lieu
                                    ReDim ArrDataDAP(tblAcqTop20.Rows.Count - 1)
                                    ReDim ArrLabelDAP(tblAcqTop20.Rows.Count - 1)
                                    intk = 0
                                    ' Ket hop hai bang da select la tblAcqTop20, tblRetrieveData lai voi nhau de co duoc du lieu can thiet
                                    For inti = 0 To tblAcqTop20.Rows.Count - 1
                                        dtrRetrieveData = tblRetrieveData.Select("ID=" & tblAcqTop20.Rows(inti).Item("Label")) ' Lay ra Label de hien thi
                                        If dtrRetrieveData.Length > 0 Then
                                            For Each rowTop20 In dtrRetrieveData ' Khong co cach nao de lay du lieu tu datarow() cho nen phai dung qua mot datarow de truy cap den datarow()
                                                ArrLabelDAP(inti) = rowTop20.Item("Label")
                                                intk += 1
                                                If intk Mod 4 = 0 Then
                                                    strDAP = strDAP & "</TR><TR>"
                                                End If
                                                strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & rowTop20.Item("Label") & ": " & tblAcqTop20.Rows(inti).Item("Total") & "</SMALL></TD>"
                                            Next
                                        Else
                                            intk += 1
                                            If intk Mod 4 = 0 Then
                                                strDAP = strDAP & "</TR><TR>"
                                            End If
                                            ArrLabelDAP(inti) = tblAcqTop20.Rows(inti).Item("Label")
                                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblAcqTop20.Rows(inti).Item("Label") & ": " & tblAcqTop20.Rows(inti).Item("Total") & "</SMALL></TD>"
                                        End If
                                        ArrDataDAP(inti) = tblAcqTop20.Rows(inti).Item("Total")
                                        dtrRetrieveData = tblRetrieveData.Select()
                                    Next
                                Else ' Khong co du lieu
                                    ReDim ArrDataDAP(0)
                                    ReDim ArrLabelDAP(0)
                                    ArrDataDAP(0) = 0
                                    ArrLabelDAP(0) = "NOT FOUND"
                                    strDAP = ""
                                End If
                            End If
                        Else ' Khong tim thay du lieu
                            ReDim ArrDataDAP(0)
                            ReDim ArrLabelDAP(0)
                            ArrDataDAP(0) = 0
                            ArrLabelDAP(0) = "NOT FOUND"
                            strDAP = ""
                        End If
                    End If
                    If strDAP.Length > 0 Then
                        strDAP = strDAP & "</TR></TABLE>" ' Xong phan hien thi cho dau an pham
                    End If
                    ' Tra lai du lieu len tren thong qua property objArrLabelChar va objArrDataChar
                    objArrLabelChart = ArrLabelDAP
                    objArrDataChart = ArrDataDAP
                    ' THONG KE CHO BAN AN PHAM
                    strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B></B><SMALL>" & strBAPTotal & lgTotalCopies & "</SMALL></TD></TR><TR>"
                    If Not strDBServer = "ORACLE" Then 'SQL
                        objBCDBS.SQLStatement = "SELECT TOP 20 Count(*) AS Total," & tblCatDicList.Rows(0).Item("IndexIDField") & " AS Label FROM Lib_tblHolding," & tblCatDicList.Rows(0).Item("IndexTable") & "  WHERE Lib_tblHolding.ItemID=" & tblCatDicList.Rows(0).Item("IndexTable") & ".ItemID GROUP BY " & tblCatDicList.Rows(0).Item("IndexIDField") & " ORDER BY Total DESC"
                    Else 'ORACLE
                        objBCDBS.SQLStatement = "SELECT A.Total,A.Label FROM(SELECT Count(*) AS Total," & tblCatDicList.Rows(0).Item("IndexIDField") & "  AS Label  FROM Lib_tblHolding," & tblCatDicList.Rows(0).Item("IndexTable") & "  WHERE Lib_tblHolding.ItemID=" & tblCatDicList.Rows(0).Item("IndexTable") & ".ItemID  GROUP BY " & tblCatDicList.Rows(0).Item("IndexIDField") & " ORDER BY Total DESC) A WHERE Rownum<=20"
                    End If
                    tblAcqTop20 = Nothing
                    ' Lay du lieu top20 va sau nay se ket hop voi mot bang nua ( tblRetrieveData) de loc lay Label cua bang do cong voi Total cua bang nay lam du lieu de thong ke, hai bang nay co moi lien he voi nhau thong qua truong tblAcqTop20.Label=tblRetrieveData.ID
                    tblAcqTop20 = objBCDBS.RetrieveItemInfor
                    strErrorMsg = objBCDBS.ErrorMsg
                    interrorcode = objBCDBS.ErrorCode
                    If tblAcqTop20.Rows.Count > 0 Then 'co du lieu
                        ReDim ArrDataBAP(tblAcqTop20.Rows.Count - 1)
                        ReDim ArrLabelBAP(tblAcqTop20.Rows.Count - 1)
                        strIDs = ""
                        For inti = 0 To tblAcqTop20.Rows.Count - 1
                            strIDs &= tblAcqTop20.Rows(inti).Item("Label") & ","
                        Next
                        strIDs = Left(strIDs, strIDs.Length - 1)
                        If Not strDBServer = "ORACLE" Then
                            objBCDBS.SQLStatement = "SELECT " & tblCatDicList.Rows(0).Item("DicIDField") & "  AS ID, isnull(" & tblCatDicList.Rows(0).Item("CaptionField") & ",'Unknown')  AS Label FROM " & tblCatDicList.Rows(0).Item("DicTable") & " WHERE " & tblCatDicList.Rows(0).Item("DicIDField") & " IN(" & strIDs & ")"
                        Else
                            objBCDBS.SQLStatement = "SELECT " & tblCatDicList.Rows(0).Item("DicIDField") & "  AS ID, NVL(" & tblCatDicList.Rows(0).Item("CaptionField") & ",'Unknown') AS Label FROM " & tblCatDicList.Rows(0).Item("DicTable") & " WHERE " & tblCatDicList.Rows(0).Item("DicIDField") & " IN(" & strIDs & ")"
                        End If
                        tblRetrieveData = Nothing
                        ' Lay du lieu ra de thuc hien thong ke
                        tblRetrieveData = objBCDBS.RetrieveItemInfor
                        strErrorMsg = objBCDBS.ErrorMsg
                        interrorcode = objBCDBS.ErrorCode
                        intk = 0
                        For inti = 0 To tblAcqTop20.Rows.Count - 1
                            dtrRetrieveData = tblRetrieveData.Select("ID=" & tblAcqTop20.Rows(inti).Item("Label"))
                            If dtrRetrieveData.Length <= 0 Then 'khong loc ra duoc row nao
                                ArrLabelBAP(inti) = tblAcqTop20.Rows(inti).Item("Label")
                                intk += 1
                                If intk Mod 4 = 0 Then
                                    strBAP = strBAP & "</TR><TR>"
                                End If
                                strBAP &= "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblAcqTop20.Rows(inti).Item("Label") & ": " & tblAcqTop20.Rows(inti).Item("Total") & "</SMALL></TD>"
                            Else ' Loc ra duoc it nhat la 1 row, trong bai nay chi co the loc ra duoc 1 row duy nhat    
                                For Each rowTop20 In dtrRetrieveData
                                    ArrLabelBAP(inti) = rowTop20.Item("Label")
                                    intk += 1
                                    If intk Mod 4 = 0 Then
                                        strBAP = strBAP & "</TR><TR>"
                                    End If
                                    strBAP &= "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & rowTop20.Item("Label") & ": " & tblAcqTop20.Rows(inti).Item("Total") & "</SMALL></TD>"
                                Next
                            End If
                            ArrDataBAP(inti) = tblAcqTop20.Rows(inti).Item("Total")
                            dtrRetrieveData = tblRetrieveData.Select()
                        Next
                    Else ' Khong co du lieu
                        ReDim ArrDataBAP(0)
                        ReDim ArrLabelBAP(0)
                        ArrDataBAP(0) = 0
                        ArrLabelBAP(0) = "NOT FOUND"
                        strBAP = ""
                    End If
                    If strBAP.Length > 0 Then
                        strBAP &= "</TR></TABLE>" ' Ket thuc cho viec hien thi phan text cho ban an pham
                    End If
                    ' Tra lai du lieu len tren thong qua property objArrLabelCharNext va objArrDataCharNext
                    objArrlabelChartNext = ArrLabelBAP
                    objArrDataChartNext = ArrDataBAP
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: For quick view at main ACQ page
        ' In: UserID, Mode
        ' Out: Mode=0-> Get barchart, Mode=1-> Get summary
        ' Creator: Sondp
        ' CreatedDate: 08/11/2005
        Public Function GetSummaryHoldings(ByVal intUserID As Integer, ByVal intMode As Integer) As DataTable
            Try
                If intMode = 0 Then ' Get barchart
                    Dim ArrDataRet(0) As Integer
                    Dim ArrLabelRet(0) As String
                    Dim inti As Integer
                    ArrDataRet(0) = -1
                    ArrLabelRet(0) = "NOT FOUND"
                    objDS.LibID = intLibID
                    GetSummaryHoldings = objDS.GetSummaryHoldings(intUserID, intMode)
                    strErrorMsg = objDS.ErrorMsg
                    interrorcode = objDS.ErrorCode
                    If Not GetSummaryHoldings Is Nothing Then
                        If GetSummaryHoldings.Rows.Count > 0 Then
                            ReDim ArrDataRet(GetSummaryHoldings.Rows.Count - 1)
                            ReDim ArrLabelRet(GetSummaryHoldings.Rows.Count - 1)
                            For inti = 0 To GetSummaryHoldings.Rows.Count - 1
                                ArrDataRet(inti) = GetSummaryHoldings.Rows(inti).Item("Total")
                                ArrLabelRet(inti) = GetSummaryHoldings.Rows(inti).Item("TypeCode")
                            Next
                        End If
                    End If
                    ' Return value
                    objArrLabelChart = ArrLabelRet
                    objArrDataChart = ArrDataRet
                Else ' Get summary
                    GetSummaryHoldings = objDS.GetSummaryHoldings(intUserID, intMode)
                    strErrorMsg = objDS.ErrorMsg
                    interrorcode = objDS.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        ' Method: StatYear
        ' Purpose: Create statisitc by acqyear
        ' Input: Some need info
        ' Creator: Sondp
        Public Sub StatYear(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strInYear As String)
            Dim tblYear As New DataTable
            Dim arrBoocksTotal() As Integer
            Dim arrCopiesTotal() As Integer
            Dim arrMoneyTotal() As Long
            Dim arrYear() As Integer
            Dim inti As Integer

            ReDim arrBoocksTotal(0)
            ReDim arrMoneyTotal(0)
            ReDim arrCopiesTotal(0)
            ReDim arrYear(0)
            arrYear(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""

            Try
                ' Get Total Copies and Items 
                objDS.TypeSelect = "TOTAL"
                objDS.LibID = intLibID
                tblYear = objBCDBS.ConvertTable(objDS.StatYear())
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblYear Is Nothing Then
                    If tblYear.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblYear.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblYear.Rows(0).Item("TotalCopies"))
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                tblYear = Nothing
                ' Statistic Year here
                objDS.TypeSelect = "YEAR"
                tblYear = objBCDBS.ConvertTable(objDS.StatYear())
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblYear Is Nothing Then
                    If tblYear.Rows.Count > 0 Then
                        ' DAP Header
                        strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                        ' BAP Header
                        strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                        ' Money Total
                        strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4></TD></TR>"
                        ReDim arrBoocksTotal(tblYear.Rows.Count - 1)
                        ReDim arrCopiesTotal(tblYear.Rows.Count - 1)
                        ReDim arrMoneyTotal(tblYear.Rows.Count - 1)
                        ReDim arrYear(tblYear.Rows.Count - 1)
                        For inti = 0 To tblYear.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP &= "</TR>"
                                strBAP &= "</TR>"
                                strMoney &= "</TR>"
                            End If
                            arrBoocksTotal(inti) = tblYear.Rows(inti).Item("BooksTotal")
                            arrCopiesTotal(inti) = tblYear.Rows(inti).Item("CopiesTotal")
                            arrMoneyTotal(inti) = tblYear.Rows(inti).Item("MoneyTotal")
                            arrYear(inti) = tblYear.Rows(inti).Item("Year")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & tblYear.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & tblYear.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                            strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & CLng(tblYear.Rows(inti).Item("MoneyTotal")) & "</SMALL></TD>"
                        Next
                    End If
                End If
                If strDAP <> "" Then
                    strDAP &= "</TABLE>"
                End If
                If strBAP <> "" Then
                    strBAP &= "</TABLE>"
                End If
                If strMoney <> "" Then
                    strMoney &= "</TABLE>"
                End If
                ' Return value
                objArrLabelChart = arrYear
                objArrDataChart = arrBoocksTotal
                objArrDataChartNext = arrCopiesTotal
                objArrDataMoney = arrMoneyTotal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub StatYear(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strInYear As String, ByVal intYearStart As Integer, ByVal intYearEnd As Integer)
            Dim tblYear As New DataTable
            Dim arrBoocksTotal() As Integer
            Dim arrCopiesTotal() As Integer
            Dim arrMoneyTotal() As Long
            Dim arrYear() As Integer
            Dim inti As Integer

            ReDim arrBoocksTotal(0)
            ReDim arrMoneyTotal(0)
            ReDim arrCopiesTotal(0)
            ReDim arrYear(0)
            arrYear(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""

            Try
                ' Get Total Copies and Items 
                objDS.TypeSelect = "TOTAL"
                objDS.LibID = intLibID
                tblYear = objBCDBS.ConvertTable(objDS.StatYear())
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblYear Is Nothing Then
                    If tblYear.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblYear.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblYear.Rows(0).Item("TotalCopies"))
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                tblYear = Nothing
                ' Statistic Year here
                objDS.TypeSelect = "YEAR"
                tblYear = objBCDBS.ConvertTable(objDS.StatYear())
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblYear Is Nothing Then

                    Dim tblTemp As New DataTable("tblTemp")
                    tblTemp.Columns.Add("Year")
                    tblTemp.Columns.Add("BooksTotal")
                    tblTemp.Columns.Add("CopiesTotal")
                    tblTemp.Columns.Add("MoneyTotal")

                    If tblYear.Rows.Count > 0 Then
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                        For Each row As DataRow In tblYear.Rows
                            If (CType(row.Item("Year"), Integer) >= intYearStart And CType(row.Item("Year"), Integer) <= intYearEnd) Then
                                Dim rowTemp As DataRow = tblTemp.NewRow()
                                rowTemp.Item("Year") = row.Item("Year")
                                rowTemp.Item("BooksTotal") = row.Item("BooksTotal")
                                rowTemp.Item("CopiesTotal") = row.Item("CopiesTotal")
                                rowTemp.Item("MoneyTotal") = row.Item("MoneyTotal")

                                lgTotalBooks = lgTotalBooks + CType(row.Item("BooksTotal"), Long)
                                lgTotalCopies = lgTotalCopies + CType(row.Item("CopiesTotal"), Long)

                                tblTemp.Rows.Add(rowTemp)
                            End If
                        Next

                        ReDim arrBoocksTotal(tblTemp.Rows.Count - 1)
                        ReDim arrCopiesTotal(tblTemp.Rows.Count - 1)
                        ReDim arrMoneyTotal(tblTemp.Rows.Count - 1)
                        ReDim arrYear(tblTemp.Rows.Count - 1)


                        ' DAP Header
                        strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                        ' BAP Header
                        strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                        ' Money Total
                        strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4></TD></TR>"


                        For inti = 0 To tblTemp.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP &= "</TR>"
                                strBAP &= "</TR>"
                                strMoney &= "</TR>"
                            End If
                            arrBoocksTotal(inti) = tblTemp.Rows(inti).Item("BooksTotal")
                            arrCopiesTotal(inti) = tblTemp.Rows(inti).Item("CopiesTotal")
                            arrMoneyTotal(inti) = tblTemp.Rows(inti).Item("MoneyTotal")
                            arrYear(inti) = tblTemp.Rows(inti).Item("Year")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblTemp.Rows(inti).Item("Year") & ": " & tblTemp.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblTemp.Rows(inti).Item("Year") & ": " & tblTemp.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                            strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblTemp.Rows(inti).Item("Year") & ": " & CLng(tblTemp.Rows(inti).Item("MoneyTotal")) & "</SMALL></TD>"
                        Next
                    End If
                End If
                If strDAP <> "" Then
                    strDAP &= "</TABLE>"
                End If
                If strBAP <> "" Then
                    strBAP &= "</TABLE>"
                End If
                If strMoney <> "" Then
                    strMoney &= "</TABLE>"
                End If
                ' Return value
                objArrLabelChart = arrYear
                objArrDataChart = arrBoocksTotal
                objArrDataChartNext = arrCopiesTotal
                objArrDataMoney = arrMoneyTotal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub StatYear(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strCapTotal As String, ByVal strInYear As String, ByVal intYearStart As Integer, ByVal intYearEnd As Integer)
            Dim tblYear As New DataTable
            Dim arrBoocksTotal() As Integer
            Dim arrCopiesTotal() As Integer
            Dim arrMoneyTotal() As Long
            Dim arrYear() As Integer
            Dim inti As Integer

            ReDim arrBoocksTotal(0)
            ReDim arrMoneyTotal(0)
            ReDim arrCopiesTotal(0)
            ReDim arrYear(0)
            arrYear(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""

            Dim lgTotalPrice As Long = 0

            Dim cul As CultureInfo = CultureInfo.GetCultureInfo("vi-VN")

            Try
                ' Get Total Copies and Items 
                objDS.TypeSelect = "TOTAL"
                objDS.LibID = intLibID
                tblYear = objBCDBS.ConvertTable(objDS.StatYearOther(intYearStart, intYearEnd))
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblYear Is Nothing Then
                    If tblYear.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblYear.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblYear.Rows(0).Item("TotalCopies"))
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                tblYear = Nothing
                ' Statistic Year here
                objDS.TypeSelect = "YEAR"
                tblYear = objBCDBS.ConvertTable(objDS.StatYearOther(intYearStart, intYearEnd))
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblYear Is Nothing Then

                    Dim tblTemp As New DataTable("tblTemp")
                    tblTemp.Columns.Add("Year")
                    tblTemp.Columns.Add("BooksTotal")
                    tblTemp.Columns.Add("CopiesTotal")
                    tblTemp.Columns.Add("MoneyTotal")

                    If tblYear.Rows.Count > 0 Then
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                        lgTotalPrice = 0
                        For Each row As DataRow In tblYear.Rows
                            Dim rowTemp As DataRow = tblTemp.NewRow()
                            rowTemp.Item("Year") = row.Item("Year")
                            rowTemp.Item("BooksTotal") = row.Item("BooksTotal")
                            rowTemp.Item("CopiesTotal") = row.Item("CopiesTotal")
                            rowTemp.Item("MoneyTotal") = row.Item("MoneyTotal")

                            lgTotalBooks = lgTotalBooks + CType(row.Item("BooksTotal"), Long)
                            lgTotalCopies = lgTotalCopies + CType(row.Item("CopiesTotal"), Long)
                            lgTotalPrice = lgTotalPrice + CType(row.Item("MoneyTotal"), Long)
                            tblTemp.Rows.Add(rowTemp)
                        Next

                        ReDim arrBoocksTotal(tblTemp.Rows.Count - 1)
                        ReDim arrCopiesTotal(tblTemp.Rows.Count - 1)
                        ReDim arrMoneyTotal(tblTemp.Rows.Count - 1)
                        ReDim arrYear(tblTemp.Rows.Count - 1)


                        ' DAP Header
                        strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                        ' BAP Header
                        strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                        ' Money Total
                        strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strCapTotal & ": " & lgTotalPrice.ToString("#,###", cul.NumberFormat) & "</B></TD></TR>"


                        For inti = 0 To tblTemp.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP &= "</TR>"
                                strBAP &= "</TR>"
                                strMoney &= "</TR>"
                            End If
                            arrBoocksTotal(inti) = tblTemp.Rows(inti).Item("BooksTotal")
                            arrCopiesTotal(inti) = tblTemp.Rows(inti).Item("CopiesTotal")
                            arrMoneyTotal(inti) = tblTemp.Rows(inti).Item("MoneyTotal")
                            arrYear(inti) = tblTemp.Rows(inti).Item("Year")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblTemp.Rows(inti).Item("Year") & ": " & tblTemp.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblTemp.Rows(inti).Item("Year") & ": " & tblTemp.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                            strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblTemp.Rows(inti).Item("Year") & ": " & CLng(tblTemp.Rows(inti).Item("MoneyTotal")).ToString("#,###", cul.NumberFormat) & "</SMALL></TD>"
                        Next
                    End If
                End If
                If strDAP <> "" Then
                    strDAP &= "</TABLE>"
                End If
                If strBAP <> "" Then
                    strBAP &= "</TABLE>"
                End If
                If strMoney <> "" Then
                    strMoney &= "</TABLE>"
                End If
                ' Return value
                objArrLabelChart = arrYear
                objArrDataChart = arrBoocksTotal
                objArrDataChartNext = arrCopiesTotal
                objArrDataMoney = arrMoneyTotal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function StatYearOtherDetail(ByVal intYearStart As Integer, ByVal intYearEnd As Integer) As DataTable
            Dim tblResult As New DataTable("tblResult")
            Try
                objDS.LibID = intLibID
                If (IsNumeric(intYearStart)) And (IsNumeric(intYearEnd)) Then
                    tblResult = objDS.StatYearOtherDetail(intYearStart, intYearEnd)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return tblResult
        End Function

        ' Purpose: Statistic Month
        ' Input: strYear and some infor
        ' Output:
        ' Creator: Sondp
        Public Sub StatMonth(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strMonth As String, ByVal strYear As String)
            Dim tblMonth As New DataTable
            Dim arrBoocksTotal() As Integer
            Dim arrCopiesTotal() As Integer
            Dim arrMoneyTotal() As Long
            Dim arrMonth() As Integer
            Dim inti As Integer
            ReDim arrBoocksTotal(0)
            ReDim arrMoneyTotal(0)
            ReDim arrCopiesTotal(0)
            ReDim arrMonth(0)
            arrMonth(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""
            Try
                objDS.LibID = intLibID
                If Not strYear = "" Then
                    objDS.TypeSelect = "TOTAL"
                    tblMonth = objBCDBS.ConvertTable(objDS.StatMonth(strYear))
                    strErrorMsg = objDS.ErrorMsg
                    intErrorCode = objDS.ErrorCode
                    If Not tblMonth Is Nothing Then
                        If tblMonth.Rows.Count > 0 Then
                            lgTotalBooks = CLng(tblMonth.Rows(0).Item("TotalBook"))
                            lgTotalCopies = CLng(tblMonth.Rows(0).Item("TotalCopies"))
                        Else
                            lgTotalBooks = 0
                            lgTotalCopies = 0
                        End If
                    End If
                    tblMonth = Nothing
                    objDS.TypeSelect = "MONTH"
                    tblMonth = objBCDBS.ConvertTable(objDS.StatMonth(strYear))
                    strErrorMsg = objDS.ErrorMsg
                    intErrorCode = objDS.ErrorCode
                    If Not tblMonth Is Nothing Then
                        If tblMonth.Rows.Count > 0 Then
                            ' DAP Header
                            strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                            ' BAP Header
                            strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                            ' Money Total
                            strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4></TD></TR>"
                            ReDim arrBoocksTotal(tblMonth.Rows.Count - 1)
                            ReDim arrCopiesTotal(tblMonth.Rows.Count - 1)
                            ReDim arrMoneyTotal(tblMonth.Rows.Count - 1)
                            ReDim arrMonth(tblMonth.Rows.Count - 1)
                            For inti = 0 To tblMonth.Rows.Count - 1
                                If inti Mod 4 = 0 Then
                                    strDAP &= "</TR>"
                                    strBAP &= "</TR>"
                                    strMoney &= "</TR>"
                                End If
                                arrBoocksTotal(inti) = tblMonth.Rows(inti).Item("BooksTotal")
                                arrCopiesTotal(inti) = tblMonth.Rows(inti).Item("CopiesTotal")
                                arrMoneyTotal(inti) = tblMonth.Rows(inti).Item("MoneyTotal")
                                arrMonth(inti) = tblMonth.Rows(inti).Item("Month")
                                strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strMonth & " " & tblMonth.Rows(inti).Item("Month") & ": " & tblMonth.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                                strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strMonth & " " & tblMonth.Rows(inti).Item("Month") & ": " & tblMonth.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                                strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strMonth & " " & tblMonth.Rows(inti).Item("Month") & ": " & CLng(tblMonth.Rows(inti).Item("MoneyTotal")) & "</SMALL></TD>"
                            Next
                        End If
                    End If
                End If
                If strDAP <> "" Then
                    strDAP &= "</TABLE>"
                End If
                If strBAP <> "" Then
                    strBAP &= "</TABLE>"
                End If
                If strMoney <> "" Then
                    strMoney &= "</TABLE>"
                End If
                ' Return value
                objArrLabelChart = arrMonth
                objArrDataChart = arrBoocksTotal
                objArrDataChartNext = arrCopiesTotal
                objArrDataMoney = arrMoneyTotal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function StatMonthDetail(ByVal strYear As String) As DataTable
            Dim tblResult As New DataTable("tblResult")
            Try
                objDS.LibID = intLibID
                If strYear <> "" Then
                    tblResult = objDS.StatMonthDetail(strYear)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return tblResult
        End Function

        ' Method: StatDay
        ' Purpose: Statistic Day
        ' Input: strMonth, strYear and some infor
        ' Creator: Sondp
        Public Sub StatDay(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strInDay As String, ByVal strMonth As String, ByVal strYear As String)
            Dim tblDay As New DataTable
            Dim strDay As String
            Dim inti As Integer
            Dim ArrDay() As Integer
            Dim ArrBooksTotal() As String
            Dim ArrCopiesTotal() As String
            Dim ArrMoneyTotal() As String
            ReDim ArrDay(0)
            ReDim ArrBooksTotal(0)
            ReDim ArrCopiesTotal(0)
            ReDim ArrMoneyTotal(0)
            ArrDay(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""

            Try
                objDS.LibID = intLibID
                If strMonth <> "" And strYear <> "" Then
                    strDay = GetDaysInMonth(CInt(strMonth), CInt(strYear))
                    objDS.TypeSelect = "TOTAL"
                    tblDay = objBCDBS.ConvertTable(objDS.StatDay(strDay, strMonth, strYear))
                    strErrorMsg = objDS.ErrorMsg
                    intErrorCode = objDS.ErrorCode
                    If Not tblDay Is Nothing Then
                        If tblDay.Rows.Count > 0 Then
                            lgTotalBooks = CLng(tblDay.Rows(0).Item("TotalBook"))
                            lgTotalCopies = CLng(tblDay.Rows(0).Item("TotalCopies")) '
                        Else
                            lgTotalBooks = 0
                            lgTotalCopies = 0
                        End If
                    End If
                    tblDay = Nothing
                    objDS.TypeSelect = "DAY"
                    tblDay = objBCDBS.ConvertTable(objDS.StatDay(strDay, strMonth, strYear))
                    strErrorMsg = objDS.ErrorMsg
                    intErrorCode = objDS.ErrorCode
                    If Not tblDay Is Nothing Then
                        If tblDay.Rows.Count > 0 Then
                            ' DAP Header
                            strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                            ' BAP Header
                            strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                            ' Money Total
                            strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4></TD></TR>"
                            ReDim ArrDay(tblDay.Rows.Count - 1)
                            ReDim ArrBooksTotal(tblDay.Rows.Count - 1)
                            ReDim ArrCopiesTotal(tblDay.Rows.Count - 1)
                            ReDim ArrMoneyTotal(tblDay.Rows.Count - 1)
                            For inti = 0 To tblDay.Rows.Count - 1
                                If inti Mod 4 = 0 Then
                                    strDAP &= "</TR>"
                                    strBAP &= "</TR>"
                                    strMoney &= "</TR>"
                                End If
                                ArrDay(inti) = tblDay.Rows(inti).Item("Day")
                                ArrBooksTotal(inti) = tblDay.Rows(inti).Item("BooksTotal")
                                ArrCopiesTotal(inti) = tblDay.Rows(inti).Item("CopiesTotal")
                                ArrMoneyTotal(inti) = tblDay.Rows(inti).Item("MoneyTotal")
                                strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInDay & " " & tblDay.Rows(inti).Item("Day") & ": " & tblDay.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                                strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInDay & " " & tblDay.Rows(inti).Item("Day") & ": " & tblDay.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                                strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInDay & " " & tblDay.Rows(inti).Item("Day") & ": " & CLng(tblDay.Rows(inti).Item("MoneyTotal")) & "</SMALL></TD>"
                            Next
                        Else 'khong co du lieu
                            ReDim ArrDay(0)
                            ReDim ArrBooksTotal(0)
                            ReDim ArrCopiesTotal(0)
                            ReDim ArrMoneyTotal(0)
                            ArrDay(0) = -1
                        End If
                    End If
                End If
                If strDAP <> "" Then
                    strDAP &= "</TABLE>"
                End If
                If strBAP <> "" Then
                    strBAP &= "</TABLE>"
                End If
                If strMoney <> "" Then
                    strMoney &= "</TABLE>"
                End If
                ' Return value
                objArrLabelChart = ArrDay
                objArrDataChart = ArrBooksTotal
                objArrDataChartNext = ArrCopiesTotal
                objArrDataMoney = ArrMoneyTotal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function StatDayDetail(ByVal strMonth As String, ByVal strYear As String) As DataTable
            Dim tblResult As New DataTable("tblResult")
            Try
                objDS.LibID = intLibID
                If strMonth <> "" And strYear <> "" Then
                    tblResult = objDS.StatDayDetail(strMonth, strYear)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return tblResult
        End Function

        Public Function StatTimes(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strInDay As String, ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Dim tblDay As New DataTable
            Dim inti As Integer
            Dim ArrDay() As String
            Dim ArrBooksTotal() As String
            Dim ArrCopiesTotal() As String
            Dim ArrMoneyTotal() As String
            ReDim ArrDay(0)
            ReDim ArrBooksTotal(0)
            ReDim ArrCopiesTotal(0)
            ReDim ArrMoneyTotal(0)
            ArrDay(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""

            Try
                objDS.LibID = intLibID
                If strDateFrom <> "" And strDateTo <> "" Then
                    objDS.TypeSelect = "TOTAL"
                    tblDay = objBCDBS.ConvertTable(objDS.StatTimes(strDateFrom, strDateTo))
                    strErrorMsg = objDS.ErrorMsg
                    intErrorCode = objDS.ErrorCode
                    If Not tblDay Is Nothing Then
                        If tblDay.Rows.Count > 0 Then
                            lgTotalBooks = CLng(tblDay.Rows(0).Item("TotalBook"))
                            lgTotalCopies = CLng(tblDay.Rows(0).Item("TotalCopies")) '
                        Else
                            lgTotalBooks = 0
                            lgTotalCopies = 0
                        End If
                    End If
                    tblDay = Nothing
                    objDS.TypeSelect = "DATE"
                    tblDay = objBCDBS.ConvertTable(objDS.StatTimes(strDateFrom, strDateTo))
                    strErrorMsg = objDS.ErrorMsg
                    intErrorCode = objDS.ErrorCode
                    If Not tblDay Is Nothing Then
                        If tblDay.Rows.Count > 0 Then
                            ' DAP Header
                            strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                            ' BAP Header
                            strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                            ' Money Total
                            strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4></TD></TR>"
                            ReDim ArrDay(tblDay.Rows.Count - 1)
                            ReDim ArrBooksTotal(tblDay.Rows.Count - 1)
                            ReDim ArrCopiesTotal(tblDay.Rows.Count - 1)
                            ReDim ArrMoneyTotal(tblDay.Rows.Count - 1)
                            For inti = 0 To tblDay.Rows.Count - 1
                                If inti Mod 4 = 0 Then
                                    strDAP &= "</TR>"
                                    strBAP &= "</TR>"
                                    strMoney &= "</TR>"
                                End If
                                ArrDay(inti) = String.Format("{0:dd/MM/yyyy}", tblDay.Rows(inti).Item("DATE"))
                                ArrBooksTotal(inti) = tblDay.Rows(inti).Item("BooksTotal")
                                ArrCopiesTotal(inti) = tblDay.Rows(inti).Item("CopiesTotal")
                                ArrMoneyTotal(inti) = tblDay.Rows(inti).Item("MoneyTotal")
                                strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInDay & " " & String.Format("{0:dd/MM/yyyy}", tblDay.Rows(inti).Item("DATE")) & ": " & tblDay.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                                strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInDay & " " & String.Format("{0:dd/MM/yyyy}", tblDay.Rows(inti).Item("DATE")) & ": " & tblDay.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                                strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInDay & " " & String.Format("{0:dd/MM/yyyy}", tblDay.Rows(inti).Item("DATE")) & ": " & CLng(tblDay.Rows(inti).Item("MoneyTotal")) & "</SMALL></TD>"
                            Next
                        Else 'khong co du lieu
                            ReDim ArrDay(0)
                            ReDim ArrBooksTotal(0)
                            ReDim ArrCopiesTotal(0)
                            ReDim ArrMoneyTotal(0)
                            ArrDay(0) = "NOT FOUND"
                        End If
                        If strDAP <> "" Then
                            strDAP &= "</TABLE>"
                        End If
                        If strBAP <> "" Then
                            strBAP &= "</TABLE>"
                        End If
                        If strMoney <> "" Then
                            strMoney &= "</TABLE>"
                        End If
                        ' Return value
                        objArrLabelChart = ArrDay
                        objArrDataChart = ArrBooksTotal
                        objArrDataChartNext = ArrCopiesTotal
                        objArrDataMoney = ArrMoneyTotal
                    Else 'khong co du lieu
                        ReDim ArrDay(0)
                        ReDim ArrBooksTotal(0)
                        ReDim ArrCopiesTotal(0)
                        ReDim ArrMoneyTotal(0)
                        ArrDay(0) = "NOT FOUND"
                        objArrLabelChart = ArrDay
                        objArrDataChart = ArrBooksTotal
                        objArrDataChartNext = ArrCopiesTotal
                        objArrDataMoney = ArrMoneyTotal
                    End If
                End If

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function StatTimesDetail(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Dim tblResult As New DataTable("tblResult")
            Try
                objDS.LibID = intLibID
                If strDateFrom <> "" And strDateTo <> "" Then
                    tblResult = objDS.StatTimesDetail(strDateFrom, strDateTo)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return tblResult
        End Function

        ' Purpose: Statistic ClassCopyNumber ( Dau an pham )
        ' Input: Some informations
        ' Output:
        ' Creator: Sondp
        Public Sub StatClassCopyNumber()
            Dim tblClassCopyNumber As New DataTable
            Dim arrData() As String  ' Content Data
            Dim arrLabel() As String ' Content Label
            Dim inti As Integer
            Try
                If strBranch = "" Then ' Statistic all ClassCopyNumber
                    objDS.TypeSelect = "DAPITEMS0"
                    objDS.Index = strIndex
                    objDS.Where = strWhere
                    objDS.Branch = strBranch
                    tblClassCopyNumber = objBCDBS.ConvertTable(objDS.StatClassCopyNumber())
                    strErrorMsg = objDS.ErrorMsg
                    interrorcode = objDS.ErrorCode
                Else ' Statistic ClassCopyNumber depennd on xLabel selected on WebUI
                    objDS.TypeSelect = "DAPITEMS1"
                    objDS.Index = strIndex
                    objDS.Where = strWhere
                    objDS.Branch = strBranch
                    tblClassCopyNumber = objBCDBS.ConvertTable(objDS.StatClassCopyNumber())
                    strErrorMsg = objDS.ErrorMsg
                    interrorcode = objDS.ErrorCode
                End If
                If Not tblClassCopyNumber Is Nothing Then
                    If tblClassCopyNumber.Rows.Count > 0 Then
                        ReDim arrData(tblClassCopyNumber.Rows.Count - 1)
                        ReDim arrLabel(tblClassCopyNumber.Rows.Count - 1)
                        For inti = 0 To tblClassCopyNumber.Rows.Count - 1
                            arrData(inti) = tblClassCopyNumber.Rows(inti).Item("NOR")
                            arrLabel(inti) = tblClassCopyNumber.Rows(inti).Item("Branch")
                        Next
                    Else ' Don't have data
                        ReDim arrData(0)
                        ReDim arrLabel(0)
                        arrLabel(0) = "NOT FOUND"
                        arrData(0) = -1
                    End If
                    objArrDataChart = arrData
                    objArrLabelChart = arrLabel
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: Statistic ClassItemID ( Ban an pham )
        ' Input: Some informations
        ' Output: 
        ' Creator: Sondp
        Public Sub StatClassItemID()
            Dim tblClassItemID As New DataTable
            Dim arrData() As String  ' Content Data
            Dim arrLabel() As String ' Content Label
            Dim inti As Integer
            Try
                If strBranch = "" Then ' Statistic all classItemID
                    objDS.TypeSelect = "BAPITEMS0"
                Else ' Statistic ClassItemID depennd on xLabel selected on WebUI
                    objDS.TypeSelect = "BAPITEMS1"
                End If
                objDS.Index = strIndex
                objDS.Where = strWhere
                objDS.Branch = strBranch
                tblClassItemID = objBCDBS.ConvertTable(objDS.StatClassItemID())
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblClassItemID Is Nothing Then
                    If tblClassItemID.Rows.Count > 0 Then
                        ReDim arrData(tblClassItemID.Rows.Count - 1)
                        ReDim arrLabel(tblClassItemID.Rows.Count - 1)
                        For inti = 0 To tblClassItemID.Rows.Count - 1
                            arrData(inti) = tblClassItemID.Rows(inti).Item("NOR")
                            arrLabel(inti) = tblClassItemID.Rows(inti).Item("Branch")
                        Next
                    Else ' Don't have data
                        ReDim arrData(0)
                        ReDim arrLabel(0)
                        arrLabel(0) = "NOT FOUND"
                        arrData(0) = -1
                    End If
                    objArrDataChart = arrData
                    objArrLabelChart = arrLabel
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: Statistic Language
        ' Input: some Informations
        ' Output: some Informations
        ' Creator: Sondp
        Public Sub StatLanguage(ByVal strDapTotal As String, ByVal strBapTotal As String)
            Dim tblLanguage As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            ' Thong ke cho dau an pham
            Try
                objDS.TypeSelect = UCase("DAPTOTAL")
                objDS.LibID = intLibID
                tblLanguage = objDS.StatLanguage
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblLanguage Is Nothing Then
                    If tblLanguage.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblLanguage.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblLanguage.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                tblLanguage = Nothing
                objDS.TypeSelect = "DAPITEMS"
                tblLanguage = objDS.StatLanguage
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4 CLASS=""lbGroupTitle""><B>" & strDapTotal & lgTotalBooks & "</B></TD></TR>"
                If tblLanguage.Rows.Count > 0 Then ' Co du lieu
                    ReDim ArrDataRet(tblLanguage.Rows.Count - 1)
                    ReDim ArrLabelRet(tblLanguage.Rows.Count - 1)
                    For inti = 0 To tblLanguage.Rows.Count - 1
                        If inti Mod 4 = 0 Then
                            strDAP = strDAP & "</TR>"
                        End If
                        ArrDataRet(inti) = tblLanguage.Rows(inti).Item("Total")
                        ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblLanguage.Rows(inti).Item("ISOCode") & "")
                        strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblLanguage.Rows(inti).Item("ISOCode") & ": " & tblLanguage.Rows(inti).Item("Total") & "</SMALL></TD>"
                    Next
                Else ' Khong tim thay du lieu
                    ReDim ArrDataRet(0)
                    ReDim ArrLabelRet(0)
                    ArrDataRet(0) = 0
                    ArrLabelRet(0) = "NOT FOUND"
                    strDAP = ""
                End If
                If Len(strDAP) > 0 Then
                    strDAP = strDAP & "</TABLE>" ' Xong phan hien thi cho dau an pham
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            ' Thong ke cho ban an pham
            tblLanguage = Nothing
            Try
                objDS.TypeSelect = UCase("BAPTOTAL")
                tblLanguage = objDS.StatLanguage
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblLanguage Is Nothing Then
                    If tblLanguage.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblLanguage.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblLanguage.Rows(0).Item("TotalCopies"))
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                tblLanguage = Nothing
                objDS.TypeSelect = "BAPITEMS"
                tblLanguage = objDS.StatLanguage
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4 CLASS=""lbGroupTitle""><B></B><SMALL>" & strBapTotal & lgTotalCopies & "</SMALL></TD></TR>"
                If Not tblLanguage Is Nothing Then
                    If tblLanguage.Rows.Count > 0 Then ' Co du lieu
                        ReDim ArrDataRet(tblLanguage.Rows.Count - 1)
                        ReDim ArrLabelRet(tblLanguage.Rows.Count - 1)
                        For inti = 0 To tblLanguage.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strBAP = strBAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblLanguage.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblLanguage.Rows(inti).Item("ISOCode") & "")
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblLanguage.Rows(inti).Item("ISOCode") & ": " & tblLanguage.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else ' Khong tim thay du lieu
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strBAP = ""
                    End If
                End If
                If Len(strBAP) > 0 Then
                    strBAP = strBAP & "</TABLE> " ' Xong phan hien thi cho ban an pham
                End If
                objArrlabelChartNext = ArrLabelRet
                objArrDataChartNext = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Methopd: StatLocation
        ' Purpose: Create statistic by location
        ' Input: intLocID
        ' Output: some Information
        ' Creator: Sondp
        Public Sub StatLocation(ByVal strDapTotal As String, ByVal strBapTotal As String, Optional ByVal intLocID As Integer = 0)
            Dim tblLocation As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer

            ' Thong ke cho dau an pham
            Try
                ' Lay thong ke tong quat cho ca dau an pham va ban an pham
                objDS.TypeSelect = "TOTAL"
                tblLocation = objDS.StatLocation(intLocID)
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblLocation Is Nothing Then
                    If tblLocation.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblLocation.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblLocation.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                tblLocation = Nothing
                objDS.TypeSelect = "DAPITEMS"
                tblLocation = objDS.StatLocation(intLocID)
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strDapTotal & lgTotalBooks & "</B></TD></TR>" ' dau an pham
                strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strBapTotal & lgTotalCopies & "</B></TD></TR>" ' ban an pham
                If tblLocation.Rows.Count > 0 Then ' Co du lieu
                    ReDim ArrDataRet(tblLocation.Rows.Count - 1)
                    ReDim ArrLabelRet(tblLocation.Rows.Count - 1)
                    For inti = 0 To tblLocation.Rows.Count - 1
                        If inti Mod 4 = 0 Then
                            strDAP = strDAP & "</TR>"
                        End If
                        ArrDataRet(inti) = tblLocation.Rows(inti).Item("Total")
                        ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblLocation.Rows(inti).Item("Code") & "")
                        strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblLocation.Rows(inti).Item("Code") & ": " & tblLocation.Rows(inti).Item("Total") & "</SMALL></TD>"
                    Next
                Else ' Khong tim thay du lieu
                    ReDim ArrDataRet(0)
                    ReDim ArrLabelRet(0)
                    ArrDataRet(0) = 0
                    ArrLabelRet(0) = "NOT FOUND"
                    strDAP = ""
                End If
                If Len(strDAP) > 0 Then
                    strDAP = strDAP & "</TABLE>" ' Xong phan hien thi cho dau an pham
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            ' Thong ke cho ban an pham
            tblLocation = Nothing
            Try
                objDS.TypeSelect = "BAPITEMS"
                tblLocation = objDS.StatLocation(intLocID)
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblLocation Is Nothing Then
                    If tblLocation.Rows.Count > 0 Then ' Co du lieu
                        ReDim ArrDataRet(tblLocation.Rows.Count - 1)
                        ReDim ArrLabelRet(tblLocation.Rows.Count - 1)
                        For inti = 0 To tblLocation.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strBAP = strBAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblLocation.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblLocation.Rows(inti).Item("Code") & "")
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblLocation.Rows(inti).Item("Code") & ": " & tblLocation.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else ' Khong tim thay du lieu
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strBAP = ""
                    End If
                End If
                If Len(strBAP) > 0 Then
                    strBAP = strBAP & "</TABLE> " ' Xong phan hien thi cho ban an pham
                End If
                objArrlabelChartNext = ArrLabelRet
                objArrDataChartNext = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: Create statistic by medium
        ' Input: some main information
        ' Creator: Sondp
        Public Sub StatMedium(ByVal strDAPTotal As String, ByVal strBAPTotal As String)
            Dim tblMedium As DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer

            ' Thong ke cho dau an pham
            Try
                objDS.TypeSelect = UCase("DAPTOTAL")
                objDS.LibID = intLibID
                tblMedium = objDS.StatMedium()
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblMedium Is Nothing Then
                    If tblMedium.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblMedium.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblMedium.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strDAPTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                tblMedium = Nothing

                objDS.TypeSelect = "DAPITEMS"
                tblMedium = objDS.StatMedium
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblMedium Is Nothing Then
                    If tblMedium.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblMedium.Rows.Count - 1)
                        ReDim ArrLabelRet(tblMedium.Rows.Count - 1)
                        For inti = 0 To tblMedium.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP = strDAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblMedium.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblMedium.Rows(inti).Item("Code") & "")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblMedium.Rows(inti).Item("Code") & ": " & tblMedium.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strDAP = ""
                    End If
                End If
                strDAP = strDAP & "</TABLE>" ' Xong phan hien thi cho dau an pham
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                tblMedium = Nothing
            End Try

            ' Thong ke cho ban an pham
            Try
                objDS.TypeSelect = UCase("BAPTOTAL")
                tblMedium = objDS.StatMedium
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblMedium Is Nothing Then
                    If tblMedium.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblMedium.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblMedium.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strBAPTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                tblMedium = Nothing

                objDS.TypeSelect = "BAPITEMS"
                tblMedium = objDS.StatMedium
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblMedium Is Nothing Then
                    If tblMedium.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblMedium.Rows.Count - 1)
                        ReDim ArrLabelRet(tblMedium.Rows.Count - 1)
                        For inti = 0 To tblMedium.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strBAP = strBAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblMedium.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblMedium.Rows(inti).Item("Code") & "")
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblMedium.Rows(inti).Item("Code") & ": " & tblMedium.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strBAP = ""
                    End If
                End If
                strBAP = strBAP & "</TABLE> "
                objArrlabelChartNext = ArrLabelRet
                objArrDataChartNext = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                tblMedium = Nothing
            End Try
        End Sub

        ' Purpose: Statistic ItemType
        ' Input: Some information
        ' Output: strDAP, strBAP, arrDataRet, arrDatRetNext, arrLabelRet, arrLabelRetNext
        ' Creator: Sondp
        Public Sub StatItemType(ByVal strDAPTotal As String, ByVal strBAPTotal As String)
            Dim tblItemType As DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer

            ' Thong ke cho dau an pham
            Try
                objDS.TypeSelect = UCase("DAPTOTAL")
                objDS.LibID = intLibID
                tblItemType = objDS.StatItemType()

                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblItemType Is Nothing Then
                    If tblItemType.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblItemType.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblItemType.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strDAPTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                tblItemType = Nothing
                objDS.TypeSelect = "DAPITEMS"
                tblItemType = objDS.StatItemType
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblItemType Is Nothing Then
                    If tblItemType.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblItemType.Rows.Count - 1)
                        ReDim ArrLabelRet(tblItemType.Rows.Count - 1)
                        For inti = 0 To tblItemType.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP = strDAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblItemType.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblItemType.Rows(inti).Item("TypeCode") & "")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblItemType.Rows(inti).Item("TypeCode") & ": " & tblItemType.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strDAP = ""
                    End If
                End If
                strDAP = strDAP & "</TABLE>" ' Xong phan hien thi cho dau an pham
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

            ' Thong ke cho ban an pham
            Try
                objDS.TypeSelect = UCase("BAPTOTAL")
                tblItemType = objDS.StatItemType()
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblItemType Is Nothing Then
                    If tblItemType.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblItemType.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblItemType.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                tblItemType = Nothing
                objDS.TypeSelect = UCase("BAPITEMS")
                tblItemType = objDS.StatItemType
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strBAPTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                If Not tblItemType Is Nothing Then
                    If tblItemType.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblItemType.Rows.Count - 1)
                        ReDim ArrLabelRet(tblItemType.Rows.Count - 1)
                        For inti = 0 To tblItemType.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strBAP = strBAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblItemType.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblItemType.Rows(inti).Item("TypeCode") & "")
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblItemType.Rows(inti).Item("TypeCode") & ": " & tblItemType.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strBAP = ""
                    End If
                End If
                strBAP = strBAP & "</TABLE> "
                objArrlabelChartNext = ArrLabelRet
                objArrDataChartNext = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: Statistic Nation Publisher
        ' Input: Some information
        ' Output: Some information
        ' Creator: Sondp
        Public Sub StatNationPub(ByVal strDAPTotal As String, ByVal strBAPTotal As String)
            Dim tblSource As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            ' Thong ke cho dau an pham
            Try
                objDS.LibID = intLibID
                objDS.TypeSelect = UCase("DAPTOTAL")
                tblSource = objDS.StatNationPub
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblSource Is Nothing Then
                    If tblSource.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblSource.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblSource.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strDAPTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                tblSource = Nothing
                objDS.TypeSelect = "DAPITEMS"
                tblSource = objDS.StatNationPub
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblSource Is Nothing Then
                    If tblSource.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblSource.Rows.Count - 1)
                        ReDim ArrLabelRet(tblSource.Rows.Count - 1)
                        For inti = 0 To tblSource.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP = strDAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblSource.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblSource.Rows(inti).Item("ISOCode") & "")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblSource.Rows(inti).Item("ISOCode") & ": " & tblSource.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strDAP = ""
                    End If
                End If
                strDAP = strDAP & "</TABLE>" ' Xong phan hien thi cho dau an pham
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            ' Thong ke cho ban an pham
            Try
                tblSource = Nothing
                objDS.TypeSelect = UCase("BAPITEMS")
                tblSource = objDS.StatNationPub
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strBAPTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                If Not tblSource Is Nothing Then
                    If tblSource.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblSource.Rows.Count - 1)
                        ReDim ArrLabelRet(tblSource.Rows.Count - 1)
                        For inti = 0 To tblSource.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strBAP = strBAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblSource.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblSource.Rows(inti).Item("ISOCode") & "")
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblSource.Rows(inti).Item("ISOCode") & ": " & tblSource.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strBAP = ""
                    End If
                End If
                strBAP = strBAP & "</TABLE> "
                objArrlabelChartNext = ArrLabelRet
                objArrDataChartNext = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: Statistic Source
        ' Input: Some information
        ' Output: Some information
        ' Creator: Sondp
        Public Sub StatSource(ByVal strDAPTotal As String, ByVal strBAPTotal As String, ByVal strFromDate As String, ByVal strToDate As String)
            Dim tblSource As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            ' Thong ke cho dau an pham
            Try
                objDS.TypeSelect = UCase("DAPTOTAL")
                tblSource = objDS.StatSource(objBCDBS.ConvertDateBack(strFromDate), objBCDBS.ConvertDateBack(strToDate))

                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblSource Is Nothing Then
                    If tblSource.Rows.Count > 0 Then
                        lgTotalBooks = CLng(tblSource.Rows(0).Item("TotalBook"))
                        lgTotalCopies = CLng(tblSource.Rows(0).Item("TotalCopies")) '
                    Else
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                    End If
                End If
                strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strDAPTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                tblSource = Nothing
                objDS.TypeSelect = "DAPITEMS"
                tblSource = objDS.StatSource(objBCDBS.ConvertDateBack(strFromDate), objBCDBS.ConvertDateBack(strToDate))
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                If Not tblSource Is Nothing Then
                    If tblSource.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblSource.Rows.Count - 1)
                        ReDim ArrLabelRet(tblSource.Rows.Count - 1)
                        For inti = 0 To tblSource.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP = strDAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblSource.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblSource.Rows(inti).Item("Source") & "")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblSource.Rows(inti).Item("Source") & ": " & tblSource.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strDAP = ""
                    End If
                End If
                If strDAP.Length > 0 Then
                    strDAP = strDAP & "</TABLE>" ' Xong phan hien thi cho dau an pham
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            ' Thong ke cho ban an pham

            Try
                tblSource = Nothing
                objDS.TypeSelect = UCase("BAPITEMS")
                tblSource = objDS.StatSource(objBCDBS.ConvertDateBack(strFromDate), objBCDBS.ConvertDateBack(strToDate))
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
                strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=""4"" CLASS=""lbGroupTitle""><B>" & strBAPTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                If Not tblSource Is Nothing Then
                    If tblSource.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblSource.Rows.Count - 1)
                        ReDim ArrLabelRet(tblSource.Rows.Count - 1)
                        For inti = 0 To tblSource.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strBAP = strBAP & "</TR>"
                            End If
                            ArrDataRet(inti) = tblSource.Rows(inti).Item("Total")
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblSource.Rows(inti).Item("Source") & "")
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & tblSource.Rows(inti).Item("Source") & ": " & tblSource.Rows(inti).Item("Total") & "</SMALL></TD>"
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                        strBAP = ""
                    End If
                End If
                If strBAP.Length > 0 Then
                    strBAP = strBAP & "</TABLE> "
                End If
                objArrlabelChartNext = ArrLabelRet
                objArrDataChartNext = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: GetAcqYear
        ' Purpose: Get AcqYear in holding table
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetAcqYear() As DataTable
            Try
                GetAcqYear = objBCDBS.ConvertTable(objDS.GetAcqYear)
                strErrorMsg = objDS.ErrorMsg
                interrorcode = objDS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetItemPulishYear(Optional ByVal intYearStart As Integer = 0, Optional ByVal intYearEnd As Integer = 0) As DataTable
            Try
                GetItemPulishYear = objBCDBS.ConvertTable(objDS.GetItemPulishYear(intYearStart, intYearEnd))
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetItemPulishYearDetail(Optional ByVal intYearStart As Integer = 0, Optional ByVal intYearEnd As Integer = 0) As DataTable
            Dim tblResult As New DataTable("tblResult")
            Try
                objDS.LibID = intLibID
                If (IsNumeric(intYearStart)) And (IsNumeric(intYearEnd)) Then
                    tblResult = objDS.GetItemPulishYearDetail(intYearStart, intYearEnd)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return tblResult
        End Function

        Public Sub StatPulishYear(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strInYear As String, ByVal intYearStart As Integer, ByVal intYearEnd As Integer)
            Dim tblYear As New DataTable
            Dim arrBoocksTotal() As Integer
            Dim arrCopiesTotal() As Integer
            Dim arrMoneyTotal() As Long
            Dim arrYear() As Integer
            Dim inti As Integer

            ReDim arrBoocksTotal(0)
            ReDim arrMoneyTotal(0)
            ReDim arrCopiesTotal(0)
            ReDim arrYear(0)
            arrYear(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""

            Try
                ' Get Total Copies and Items 
                tblYear = objBCDBS.ConvertTable(objDS.GetItemPulishYear(intYearStart, intYearEnd))
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblYear Is Nothing Then

                    If tblYear.Rows.Count > 0 Then
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                        For Each row As DataRow In tblYear.Rows
                            lgTotalBooks = lgTotalBooks + CType(row.Item("BooksTotal"), Long)
                            lgTotalCopies = lgTotalCopies + CType(row.Item("CopiesTotal"), Long)
                        Next

                        ReDim arrBoocksTotal(tblYear.Rows.Count - 1)
                        ReDim arrCopiesTotal(tblYear.Rows.Count - 1)
                        ReDim arrMoneyTotal(tblYear.Rows.Count - 1)
                        ReDim arrYear(tblYear.Rows.Count - 1)


                        ' DAP Header
                        strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                        ' BAP Header
                        strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                        ' Money Total
                        strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4></TD></TR>"


                        For inti = 0 To tblYear.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP &= "</TR>"
                                strBAP &= "</TR>"
                                strMoney &= "</TR>"
                            End If
                            arrBoocksTotal(inti) = tblYear.Rows(inti).Item("BooksTotal")
                            arrCopiesTotal(inti) = tblYear.Rows(inti).Item("CopiesTotal")
                            arrMoneyTotal(inti) = tblYear.Rows(inti).Item("MoneyTotal")
                            arrYear(inti) = tblYear.Rows(inti).Item("Year")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & tblYear.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & tblYear.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                            strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & CLng(tblYear.Rows(inti).Item("MoneyTotal")) & "</SMALL></TD>"
                        Next
                    End If
                End If
                If strDAP <> "" Then
                    strDAP &= "</TABLE>"
                End If
                If strBAP <> "" Then
                    strBAP &= "</TABLE>"
                End If
                If strMoney <> "" Then
                    strMoney &= "</TABLE>"
                End If
                ' Return value
                objArrLabelChart = arrYear
                objArrDataChart = arrBoocksTotal
                objArrDataChartNext = arrCopiesTotal
                objArrDataMoney = arrMoneyTotal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub StatPulishYear(ByVal strDapTotal As String, ByVal strBapTotal As String, ByVal strCapTotal As String, ByVal strInYear As String, ByVal intYearStart As Integer, ByVal intYearEnd As Integer)
            Dim tblYear As New DataTable
            Dim arrBoocksTotal() As Integer
            Dim arrCopiesTotal() As Integer
            Dim arrMoneyTotal() As Long
            Dim arrYear() As Integer
            Dim inti As Integer

            ReDim arrBoocksTotal(0)
            ReDim arrMoneyTotal(0)
            ReDim arrCopiesTotal(0)
            ReDim arrYear(0)
            arrYear(0) = -1
            strDAP = ""
            strBAP = ""
            strMoney = ""

            Dim lgTotalPrice As Long = 0

            Dim cul As CultureInfo = CultureInfo.GetCultureInfo("vi-VN")
            Try
                ' Get Total Copies and Items 
                tblYear = objBCDBS.ConvertTable(objDS.GetItemPulishYear(intYearStart, intYearEnd))
                strErrorMsg = objDS.ErrorMsg
                intErrorCode = objDS.ErrorCode
                If Not tblYear Is Nothing Then

                    If tblYear.Rows.Count > 0 Then
                        lgTotalBooks = 0
                        lgTotalCopies = 0
                        lgTotalPrice = 0
                        For Each row As DataRow In tblYear.Rows
                            lgTotalBooks = lgTotalBooks + CType(row.Item("BooksTotal"), Long)
                            lgTotalCopies = lgTotalCopies + CType(row.Item("CopiesTotal"), Long)
                            lgTotalPrice = lgTotalPrice + CType(row.Item("MoneyTotal"), Long)
                        Next

                        ReDim arrBoocksTotal(tblYear.Rows.Count - 1)
                        ReDim arrCopiesTotal(tblYear.Rows.Count - 1)
                        ReDim arrMoneyTotal(tblYear.Rows.Count - 1)
                        ReDim arrYear(tblYear.Rows.Count - 1)


                        ' DAP Header
                        strDAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strDapTotal & ": " & lgTotalBooks & "</B></TD></TR>"
                        ' BAP Header
                        strBAP = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strBapTotal & ": " & lgTotalCopies & "</B></TD></TR>"
                        ' Money Total
                        strMoney = "<TABLE WIDTH=100% CELLSPACING=0 CELLPADDING=2><TR><TD COLSPAN=4><B>" & strCapTotal & ": " & lgTotalPrice.ToString("#,###", cul.NumberFormat) & "</B></TD></TR>"


                        For inti = 0 To tblYear.Rows.Count - 1
                            If inti Mod 4 = 0 Then
                                strDAP &= "</TR>"
                                strBAP &= "</TR>"
                                strMoney &= "</TR>"
                            End If
                            arrBoocksTotal(inti) = tblYear.Rows(inti).Item("BooksTotal")
                            arrCopiesTotal(inti) = tblYear.Rows(inti).Item("CopiesTotal")
                            arrMoneyTotal(inti) = tblYear.Rows(inti).Item("MoneyTotal")
                            arrYear(inti) = tblYear.Rows(inti).Item("Year")
                            strDAP = strDAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & tblYear.Rows(inti).Item("BooksTotal") & "</SMALL></TD>"
                            strBAP = strBAP & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & tblYear.Rows(inti).Item("CopiesTotal") & "</SMALL></TD>"
                            strMoney = strMoney & "<TD VALIGN=""TOP"" CLASS=""lbSubTitle""><SMALL>" & strInYear & " " & tblYear.Rows(inti).Item("Year") & ": " & CLng(tblYear.Rows(inti).Item("MoneyTotal")).ToString("#,###", cul.NumberFormat) & "</SMALL></TD>"
                        Next
                    End If
                End If
                If strDAP <> "" Then
                    strDAP &= "</TABLE>"
                End If
                If strBAP <> "" Then
                    strBAP &= "</TABLE>"
                End If
                If strMoney <> "" Then
                    strMoney &= "</TABLE>"
                End If
                ' Return value
                objArrLabelChart = arrYear
                objArrDataChart = arrBoocksTotal
                objArrDataChartNext = arrCopiesTotal
                objArrDataMoney = arrMoneyTotal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: Get day in month
        ' Input: intMonth, intYear
        ' Output: Day in this month and year
        ' Creator: sondp.
        Function GetDaysInMonth(ByVal intMonth As Integer, ByVal intYear As Integer) As String
            Select Case intMonth
                Case 1, 3, 5, 7, 8, 10, 12
                    GetDaysInMonth = "31"
                Case 4, 6, 9, 11
                    GetDaysInMonth = "30"
                Case 2
                    If IsDate("February 29, " & intYear) Then
                        GetDaysInMonth = "29"
                    Else
                        GetDaysInMonth = "28"
                    End If
            End Select
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDS Is Nothing Then
                    objDS.Dispose(True)
                    objDS = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace