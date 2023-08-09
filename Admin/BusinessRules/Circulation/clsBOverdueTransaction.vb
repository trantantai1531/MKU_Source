' Name: clsBOverdueTransaction
' Purpose: allow manage OverdueTransaction
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:
'   +)27/08/20004: by Sondp create function GetOverdueList, function GetOverduePatron, sub GenOverduePrint
Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation
Imports System.Globalization

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBOverdueTransaction
        Inherits clsBBase
        Private objBOverdueTemplate As New clsBOverdueTemplate
        Private objBCT As New clsBCommonTemplate

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strPatronIDs As String = ""
        Private intOverdueDays As Integer = 0
        Public intOverdueTemplateID As Int16 = 0
        Public intOverduePrintMode As Int16 = 0
        Public intDueTime As Integer
        Public strPickPatronIDs As String
        Public strLogic As String
        Public strOverdueMessage As String
        Public strSelectMode As String = "ALL"
        Public collMainRowTitle As New Collection
        Private objDOverdueTransaction As New clsDOverdueTransaction
        Private objBCDataBaseSystem As New clsBCommonDBSystem
        Private objBCStringProc As New clsBCommonStringProc
        Private strPatronCode As String = ""
        Private strEmail As String = ""

        ' PatronID property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property

        ' Email property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property
        Public objTemp As Object
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' PatronIDs property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property

        ' OverdueDays property
        Public Property OverdueDays() As Integer
            Get
                Return intOverdueDays
            End Get
            Set(ByVal Value As Integer)
                intOverdueDays = Value
            End Set
        End Property

        ' OverdueTemplateID property
        Public Property OverdueTemplateID() As Int16
            Get
                Return intOverdueTemplateID
            End Get
            Set(ByVal Value As Int16)
                intOverdueTemplateID = Value
            End Set
        End Property
        ' OverdueTransaction OverduePrintMode
        Public Property OverduePrintMode() As Int16
            Get
                Return (intOverduePrintMode)
            End Get
            Set(ByVal Value As Int16)
                intOverduePrintMode = Value
            End Set
        End Property
        ' OverdueTransaction PickPatronIDs
        Public Property PickPatronIDs() As String
            Get
                Return (strPickPatronIDs)
            End Get
            Set(ByVal Value As String)
                strPickPatronIDs = Value
            End Set
        End Property
        ' OverdueTransation DueTime
        Public Property DueTime() As Integer
            Get
                Return (intDueTime)
            End Get
            Set(ByVal Value As Integer)
                intDueTime = Value
            End Set
        End Property
        ' OverdueTransaction Login 
        Public Property Logic() As String
            Get
                Return (strLogic)
            End Get
            Set(ByVal Value As String)
                strLogic = Value
            End Set
        End Property

        ' Select Mode property
        Public Property SelectMode() As String
            Get
                Return (strSelectMode)
            End Get
            Set(ByVal Value As String)
                strSelectMode = Value
            End Set
        End Property

        ' MainRowTitle property
        Public Property MainRowTitle() As Collection
            Get
                Return (collMainRowTitle)
            End Get
            Set(ByVal Value As Collection)
                collMainRowTitle = Value
            End Set
        End Property

        ' Overdue Message property
        Public Property OverdueMessage() As String
            Get
                Return (strOverdueMessage)
            End Get
            Set(ByVal Value As String)
                strOverdueMessage = Value
            End Set
        End Property
        'Temp property
        Public Property Temp() As Object
            Get
                Return (objTemp)
            End Get
            Set(ByVal Value As Object)
                objTemp = Value
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
                ' Init objBCDataBaseSystem object
                objBCDataBaseSystem.ConnectionString = strConnectionString
                objBCDataBaseSystem.DBServer = strDBServer
                objBCDataBaseSystem.InterfaceLanguage = strInterfaceLanguage
                Call objBCDataBaseSystem.Initialize()

                ' Init objDOverdueTransaction object
                objDOverdueTransaction.ConnectionString = strConnectionString
                objDOverdueTransaction.DBServer = strDBServer
                objDOverdueTransaction.Initialize()

                ' Init objBOverdueTemplate object
                objBOverdueTemplate.ConnectionString = strConnectionString
                objBOverdueTemplate.DBServer = strDBServer
                objBOverdueTemplate.InterfaceLanguage = strInterfaceLanguage
                Call objBOverdueTemplate.Initialize()

                ' Init objBCStringProc object
                objBCStringProc.ConnectionString = strConnectionString
                objBCStringProc.DBServer = strDBServer
                objBCStringProc.InterfaceLanguage = strInterfaceLanguage
                Call objBCStringProc.Initialize()

                ' Init objBCT object
                objBCT.ConnectionString = strConnectionString
                objBCT.DBServer = strDBServer
                objBCT.InterfaceLanguage = strInterfaceLanguage
                Call objBCT.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetOverdueList method
        ' Purpose: get list of OverdueTransaction
        ' Input: PatronIDs
        ' Output: datatable result
        Public Function GetOverdueList() As DataTable
            Try
                objDOverdueTransaction.PatronIDs = strPatronIDs
                GetOverdueList = objBCDataBaseSystem.ConvertTable(objDOverdueTransaction.GetOverdueList, "MainTitle")
                strErrorMsg = objDOverdueTransaction.ErrorMsg
                interrorcode = objDOverdueTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetOverdueListAuthority method
        ' Purpose: get list of OverdueTransaction depen on UserID
        ' Input: UserID, PatronIDs
        ' Output: datatable result
        Public Function GetOverdueListAuthority(Optional ByVal intFacultyID As Integer = 0, Optional ByVal intPatronGroupID As Integer = 0) As DataTable
            Try
                objDOverdueTransaction.UserID = intUserID
                objDOverdueTransaction.PatronIDs = strPatronIDs
                GetOverdueListAuthority = objBCDataBaseSystem.ConvertTable(objDOverdueTransaction.GetOverdueListAuthority(intFacultyID, intPatronGroupID), "MainTitle")
                strErrorMsg = objDOverdueTransaction.ErrorMsg
                intErrorCode = objDOverdueTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetOverduePatron method
        ' Purpose: get list of Overdue Patron
        ' Input: some infor
        ' Output: datatable result
        Public Function GetOverduePatron(Optional strFullName As String = "", Optional intPatronGroupID As Integer = 0) As DataTable
            Try
                objDOverdueTransaction.SelectMode = strSelectMode
                objDOverdueTransaction.Logic = strLogic
                objDOverdueTransaction.DueTime = intDueTime
                objDOverdueTransaction.PatronIDs = strPatronIDs
                objDOverdueTransaction.LibID = intLibID
                GetOverduePatron = objBCDataBaseSystem.ConvertTable(objDOverdueTransaction.GetOverduePatron(strFullName, intPatronGroupID))
                strErrorMsg = objDOverdueTransaction.ErrorMsg
                intErrorCode = objDOverdueTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetOverduePatron method
        ' Purpose: get list of Overdue Patron
        ' Input: some infor
        ' Output: datatable result
        Public Function GetOverduePatronAuthority() As DataTable
            Try
                objDOverdueTransaction.SelectMode = strSelectMode
                objDOverdueTransaction.UserID = intUserID
                objDOverdueTransaction.Logic = strLogic
                objDOverdueTransaction.DueTime = intDueTime
                objDOverdueTransaction.PatronIDs = strPatronIDs
                objDOverdueTransaction.LibID = intLibID
                GetOverduePatronAuthority = objBCDataBaseSystem.ConvertTable(objDOverdueTransaction.GetOverduePatronAuthority)
                strErrorMsg = objDOverdueTransaction.ErrorMsg
                intErrorCode = objDOverdueTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        '' GenOverdueInfor method 
        '' Purpose: get list of OverdueTransaction
        '' Input: tblData, intOverdueTemplate
        '' Output: strOutMsg result
        'Public Function GenOverdueInfor_OLD(ByVal tblData As DataTable, ByVal OverdueTemplate As Integer, ByVal strBool As String) As String()
        '    Dim tblOverdueTemplate As DataTable = Nothing ' OverdueTemplate Information
        '    Dim tblItem As DataTable = Nothing ' OverdueItem Information
        '    'Dim objtemplate As New TVCOMLib.LibolTemplate
        '    'Dim objTvCom As New TVCOMLib.fonts
        '    ' start declare variable 
        '    Dim objarrContent As Object
        '    Dim objbCols As Object
        '    Dim objData As Object
        '    Dim strOutMsg() As String
        '    Dim objFields As Object
        '    Dim objStream As Object
        '    Dim bUserColAlign() As String 'for Align
        '    Dim bUserColFormat() As String 'for Format
        '    Dim strbHeader As String
        '    Dim strbFooter As String
        '    Dim objbColLabel() As String
        '    Dim objbUserColLabel() As String
        '    Dim bUserColWidth() As String
        '    Dim strWidth As String ' width collum
        '    Dim strAlign As String ' align collum
        '    Dim strFormat As String ' format collum
        '    Dim intk As Integer
        '    Dim inti As Integer
        '    Dim intj As Integer
        '    Dim intIndex As Integer
        '    Dim bollFormat As Boolean ' control format template
        '    ' end declare variable
        '    objBOverdueTemplate.TemplateID = OverdueTemplate
        '    objBOverdueTemplate.TemplateType = 2
        '    tblOverdueTemplate = objBOverdueTemplate.GetTemplate
        '    objarrContent = Split(tblOverdueTemplate.Rows(0).Item("Content"), Chr(9))
        '    'Header
        '    If Not IsDBNull(objarrContent(0)) AndAlso Trim(objarrContent(0)) <> "" Then
        '        strbHeader = objTvCom.Convert("ucs2", "unicode1", Replace(objarrContent(0), "<~>", vbCrLf))
        '    Else
        '        strbHeader = " "
        '    End If
        '    objbCols = Split(objarrContent(1), "<~>") 'Colllums
        '    objbUserColLabel = Split(objarrContent(2), "<~>") 'Collumns Caption
        '    bUserColWidth = Split(objarrContent(3), "<~>") 'Collumns width
        '    bUserColAlign = Split(objarrContent(4), "<~>") 'Collumns Align
        '    bUserColFormat = Split(objarrContent(5), "<~>") 'Collumns Format                
        '    'Footer
        '    If Not IsDBNull(objarrContent(6)) AndAlso Trim(objarrContent(6)) <> "" Then
        '        strbFooter = objTvCom.Convert("ucs2", "unicode1", Replace(objarrContent(6), "<~>", vbCrLf))
        '    Else
        '        strbFooter = " "
        '    End If
        '    strbHeader = "<P CLASS='breakhere'>" & strbHeader
        '    strbFooter = "</P>"
        '    objtemplate.Template = strbHeader & "@@@@@" & strbFooter
        '    objFields = objtemplate.Fields
        '    ReDim objbColLabel(0)
        '    intk = 0
        '    For inti = 0 To UBound(objbCols)
        '        Select Case objbCols(inti)
        '            Case "<$ITEMCODE$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("ITEMCODE")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("ITEMCODE")
        '                End If
        '                intk += 1
        '            Case "<$COPYNUMBER$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("COPYNUMBER")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("COPYNUMBER")
        '                End If
        '                intk += 1
        '            Case "<$ITEMTITLE$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("ITEMTITLE")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("ITEMTITLE")
        '                End If
        '                intk += 1
        '            Case "<$CHECKOUTDATE$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("CHECKOUTDATE")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("CHECKOUTDATE")
        '                End If
        '                intk += 1
        '            Case "<$CHECKINDATE$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("CHECKINDATE")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("CHECKINDATE")
        '                End If
        '                intk += 1
        '            Case "<$OVERDUEDATE$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("OVERDUEDATE")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("OVERDUEDATE")
        '                End If
        '                intk += 1
        '            Case "<$PENATI$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("PENATI")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("PENATI")
        '                End If
        '                intk += 1
        '            Case "<$SEQUENCY$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("SEQUENCY")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("SEQUENCY")
        '                End If
        '                intk += 1
        '            Case "<$LIBRARY$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("LIBRARY")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("LIBRARY")
        '                End If
        '                intk += 1
        '            Case "<$STORE$>"
        '                ReDim Preserve objbColLabel(intk)
        '                If UBound(objbUserColLabel) >= inti Then
        '                    If Not Trim(objbUserColLabel(inti)) = "" Then
        '                        objbColLabel(intk) = objbUserColLabel(inti)
        '                    Else
        '                        objbColLabel(intk) = collMainRowTitle.Item("STORE")
        '                    End If
        '                Else
        '                    objbColLabel(intk) = collMainRowTitle.Item("STORE")
        '                End If
        '                intk += 1
        '        End Select
        '    Next
        '    'Select Overdue Information
        '    strPatronIDs = ""
        '    tblItem = GetOverdueListAuthority()
        '    objTemp = tblItem
        '    'for Header or Footer
        '    Dim arrdt() As DataRow
        '    Dim dt As DataRow
        '    ReDim strOutMsg(tblData.Rows.Count - 1)
        '    For inti = 0 To tblData.Rows.Count - 1 'for each item in datatable
        '        ReDim objData(UBound(objtemplate.Fields))
        '        'PhuongTT
        '        '20081011
        '        'Sua lai so thu tu ban ghi va mang objData(inti) --> objData(intj)
        '        If strBool <> "" Then
        '            arrdt = tblItem.Select("PatronID=" & tblData.Rows(inti).Item("ID") & " And OverdueDate" & strBool)
        '        Else
        '            arrdt = tblItem.Select("PatronID=" & tblData.Rows(inti).Item("ID"))
        '        End If

        '        For intj = LBound(objFields) To UBound(objFields)
        '            Select Case objFields(intj)
        '                Case "CARDNUMBER"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Code")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Code")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If

        '                Case "NAME"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Name")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Name")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If
        '                Case "DOB"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("DOB")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("DOB")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If

        '                Case "OCUPATION"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Occupation")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Occupation")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If
        '                Case "WORKPLACE"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("WorkPlace")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("WorkPlace")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If
        '                Case "WORKADDRESS"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("WorkAddress")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("WorkAddress")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If
        '                Case "HOMEADDRESS"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Address")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Address")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If

        '                Case "PHONE"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Telephone")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Telephone")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If
        '                Case "FACULITY"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Faculty")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Faculty")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If

        '                Case "GRADE"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Grade")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Grade")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If

        '                Case "CARDVALIDDATE"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("ValidDate")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("ValidDate")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If

        '                Case "CARDEXPIREDDATE"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("ExpiredDate")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("ExpiredDate")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If

        '                Case "EMAIL"
        '                    If Not IsDBNull(tblData.Rows(inti).Item("Email")) Then
        '                        objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Email")) & Chr(9)
        '                    Else
        '                        objData(intj) = " " & Chr(9)
        '                    End If
        '                Case "DATE"
        '                    objData(intj) = CStr(Now()) & Chr(9)
        '                Case Else
        '                    objData(intj) = " " & Chr(9)
        '            End Select
        '        Next
        '        'Generete data for Header and Footer
        '        objStream = objtemplate.Generate(objData)
        '        objStream = Replace(objStream, "  ", "&nbsp;&nbsp;")
        '        'Generate String Template 
        '        strOutMsg(inti) = objBCStringProc.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
        '        strOutMsg(inti) = strOutMsg(inti) & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=0  CELLPADDING=0 BGCOLOR=""#000000""><TR><TD WIDTH=100%><TABLE WIDTH=100% BORDER=0  CELLSPACING=0  CELLPADDING=0 COLSPAN=" & UBound(objbColLabel) & " >"
        '        strOutMsg(inti) = strOutMsg(inti) & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 BGCOLOR=""#000000"">"
        '        strOutMsg(inti) = strOutMsg(inti) & "<TR  BGCOLOR=""#FFFFFF""> "
        '        For intj = 0 To UBound(objbColLabel)
        '            strWidth = ""
        '            'Collum Width
        '            If UBound(bUserColWidth) >= intj Then
        '                If Not Trim(bUserColWidth(intj)) = "" Then
        '                    strWidth = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
        '                End If
        '            End If
        '            strAlign = ""
        '            'Collum Align
        '            If UBound(bUserColAlign) >= intj Then
        '                If Not Trim(bUserColAlign(intj)) = "" Then
        '                    strAlign = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
        '                End If
        '            End If
        '            'Collum Format
        '            If UBound(bUserColFormat) >= intj Then
        '                If Not Trim(bUserColFormat(intj)) = "" Then
        '                    strFormat = Trim(bUserColFormat(intj))
        '                End If
        '            End If
        '            If Not strFormat = "" Then
        '                strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " ALIGN=TOP BGCOLOR=""#FFFFFF"" >" & Replace(strFormat, "<$DATA$>", objbColLabel(intj)) & "</TD>"
        '            Else
        '                strOutMsg(inti) = strOutMsg(inti) & "<TD ALIGN=""center"" VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=""#FFFFFF"" >" & objbColLabel(intj) & "</TD>"
        '            End If
        '        Next 'end for intj
        '        intIndex = 1
        '        For Each dt In arrdt
        '            'for table title                
        '            strOutMsg(inti) = strOutMsg(inti) & "</TR><TR  BGCOLOR=""#FFFFFF"">"
        '            'for collum and row objData
        '            For intj = 0 To UBound(objbCols)
        '                'Width
        '                strWidth = ""
        '                If UBound(bUserColWidth) >= intj Then
        '                    If Not Trim(bUserColWidth(intj)) = "" Then
        '                        strWidth = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
        '                    End If
        '                End If
        '                'Align 
        '                strAlign = ""
        '                If UBound(bUserColAlign) >= intj Then
        '                    If Not Trim(bUserColAlign(intj)) = "" Then
        '                        strAlign = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
        '                    End If
        '                End If
        '                'Format
        '                strFormat = ""
        '                bollFormat = False 'default not have Format
        '                If UBound(bUserColFormat) >= intj Then
        '                    If Not Trim(bUserColFormat(intj)) = "" Then
        '                        bollFormat = True 'have Format
        '                    End If
        '                End If
        '                Select Case objbCols(intj)
        '                    Case "<$ITEMCODE$>"
        '                        If bollFormat Then
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("ItemCode")) & "</TD>"
        '                        Else
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("ItemCode") & "&nbsp;</TD>"
        '                        End If
        '                    Case "<$COPYNUMBER$>"
        '                        If bollFormat Then
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CopyNumber")) & "</TD>"
        '                        Else
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CopyNumber") & "&nbsp;</TD>"
        '                        End If
        '                    Case "<$ITEMTITLE$>"
        '                        If bollFormat Then
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("MainTitle")) & "</TD>"
        '                        Else
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("MainTitle") & "&nbsp;</TD>"
        '                        End If
        '                    Case "<$CHECKOUTDATE$>"
        '                        If strDBServer = "ORACLE" Then
        '                            If bollFormat Then
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CHECKOUTDATE")) & "</TD>"
        '                            Else
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CHECKOUTDATE") & "&nbsp;</TD>"
        '                            End If
        '                        Else
        '                            If bollFormat Then
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CheckOutDate")) & "</TD>"
        '                            Else
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CheckOutDate") & "&nbsp;</TD>"
        '                            End If
        '                        End If
        '                    Case "<$CHECKINDATE$>"
        '                        If strDBServer = "ORACLE" Then
        '                            If bollFormat Then
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CHECKINDATE")) & "</TD>"
        '                            Else
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CHECKINDATE") & "&nbsp;</TD>"
        '                            End If
        '                        Else
        '                            If bollFormat Then
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CheckInDate")) & "</TD>"
        '                            Else
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CheckInDate") & "&nbsp;</TD>"
        '                            End If
        '                        End If
        '                    Case "<$OVERDUEDATE$>"
        '                        If strDBServer = "ORACLE" Then
        '                            If bollFormat Then
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("OVERDUEDATE")) & "</TD>"
        '                            Else
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("OVERDUEDATE") & "&nbsp;</TD>"
        '                            End If
        '                        Else
        '                            If bollFormat Then
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("OverdueDate")) & "</TD>"
        '                            Else
        '                                strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("OverdueDate") & "&nbsp;</TD>"
        '                            End If
        '                        End If
        '                    Case "<$PENATI$>"
        '                        If bollFormat Then
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("Penati")) & "</TD>"
        '                        Else
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("Penati") & "&nbsp;</TD>"
        '                        End If
        '                    Case "<$SEQUENCY$>"
        '                        If bollFormat Then
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", intIndex) & "</TD>"
        '                        Else
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & intIndex & "&nbsp;</TD>"
        '                        End If
        '                        intIndex += 1
        '                    Case "<$LIBRARY$>"
        '                        If bollFormat Then
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("LibCode")) & "</TD>"
        '                        Else
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("LibCode") & "&nbsp;</TD>"
        '                        End If
        '                        'intIndex += 1
        '                    Case "<$STORE$>"
        '                        If bollFormat Then
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("LocCode")) & "</TD>"
        '                        Else
        '                            strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("LocCode") & "&nbsp;</TD>"
        '                        End If
        '                        'intIndex += 1
        '                End Select
        '            Next
        '        Next
        '        strOutMsg(inti) = strOutMsg(inti) & "</TR>"
        '        strOutMsg(inti) = strOutMsg(inti) & "</TABLE></TD></TR></TABLE>"
        '        'PhuongTT 20080113
        '        'B1
        '        strOutMsg(inti) = strOutMsg(inti) & "</TD></TR></TABLE>"
        '        'E1
        '        strOutMsg(inti) = strOutMsg(inti) & objBCStringProc.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4)) & "<BR>"
        '    Next
        '    objTvCom = Nothing
        '    objtemplate = Nothing
        '    Return (strOutMsg)
        'End Function


        Public Function GenOverdueInfor(ByVal tblData As DataTable, ByVal OverdueTemplate As Integer, ByVal strBool As String) As String()
            Dim tblOverdueTemplate As DataTable = Nothing ' OverdueTemplate Information
            Dim tblItem As DataTable = Nothing ' OverdueItem Information
            'Dim objtemplate As New TVCOMLib.LibolTemplate
            'Dim objTvCom As New TVCOMLib.fonts
            ' start declare variable 
            Dim objarrContent As Object
            Dim objbCols As Object
            Dim objData As Object
            Dim strOutMsg() As String
            Dim objFields As Object
            Dim objStream As Object
            Dim bUserColAlign() As String 'for Align
            Dim bUserColFormat() As String 'for Format
            Dim strbHeader As String
            Dim strbFooter As String
            Dim objbColLabel() As String
            Dim objbUserColLabel() As String
            Dim bUserColWidth() As String
            Dim strWidth As String ' width collum
            Dim strAlign As String ' align collum
            Dim strFormat As String ' format collum
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim intIndex As Integer
            Dim bollFormat As Boolean ' control format template
            ' end declare variable
            objBOverdueTemplate.TemplateID = OverdueTemplate
            objBOverdueTemplate.TemplateType = 2
            tblOverdueTemplate = objBOverdueTemplate.GetTemplate
            objarrContent = Split(tblOverdueTemplate.Rows(0).Item("Content"), Chr(9))
            'Header
            If Not IsDBNull(objarrContent(0)) AndAlso Trim(objarrContent(0)) <> "" Then
                'strbHeader = objTvCom.Convert("ucs2", "unicode1", Replace(objarrContent(0), "<~>", vbCrLf))
                strbHeader = Replace(objarrContent(0), "<~>", vbCrLf)
            Else
                strbHeader = " "
            End If
            objbCols = Split(objarrContent(1), "<~>") 'Colllums
            objbUserColLabel = Split(objarrContent(2), "<~>") 'Collumns Caption
            bUserColWidth = Split(objarrContent(3), "<~>") 'Collumns width
            bUserColAlign = Split(objarrContent(4), "<~>") 'Collumns Align
            bUserColFormat = Split(objarrContent(5), "<~>") 'Collumns Format                
            'Footer
            If Not IsDBNull(objarrContent(6)) AndAlso Trim(objarrContent(6)) <> "" Then
                'strbFooter = objTvCom.Convert("ucs2", "unicode1", Replace(objarrContent(6), "<~>", vbCrLf))
                strbFooter = Replace(objarrContent(6), "<~>", vbCrLf)
            Else
                strbFooter = " "
            End If
            strbHeader = "<P CLASS='breakhere'>" & strbHeader
            strbFooter += "</P>"
            'objtemplate.Template = strbHeader & "@@@@@" & strbFooter
            'objFields = objtemplate.Fields
            Dim strContentTemp As String = strbHeader & "@@@@@" & strbFooter
            objFields = objBCT.getArrayFromTemplate(strContentTemp)
            ReDim objbColLabel(0)
            intk = 0
            For inti = 0 To UBound(objbCols)
                Select Case objbCols(inti)
                    Case "<$ITEMCODE$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("ITEMCODE")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("ITEMCODE")
                        End If
                        intk += 1
                    Case "<$COPYNUMBER$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("COPYNUMBER")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("COPYNUMBER")
                        End If
                        intk += 1
                    Case "<$ITEMTITLE$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("ITEMTITLE")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("ITEMTITLE")
                        End If
                        intk += 1
                    Case "<$CHECKOUTDATE$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("CHECKOUTDATE")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("CHECKOUTDATE")
                        End If
                        intk += 1
                    Case "<$CHECKINDATE$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("CHECKINDATE")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("CHECKINDATE")
                        End If
                        intk += 1
                    Case "<$OVERDUEDATE$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("OVERDUEDATE")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("OVERDUEDATE")
                        End If
                        intk += 1
                    Case "<$PENATI$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("PENATI")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("PENATI")
                        End If
                        intk += 1
                    Case "<$SEQUENCY$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("SEQUENCY")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("SEQUENCY")
                        End If
                        intk += 1
                    Case "<$LIBRARY$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("LIBRARY")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("LIBRARY")
                        End If
                        intk += 1
                    Case "<$STORE$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("STORE")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("STORE")
                        End If
                        intk += 1
                    Case "<$NOTE$>"
                        ReDim Preserve objbColLabel(intk)
                        If UBound(objbUserColLabel) >= inti Then
                            If Not Trim(objbUserColLabel(inti)) = "" Then
                                objbColLabel(intk) = objbUserColLabel(inti)
                            Else
                                objbColLabel(intk) = collMainRowTitle.Item("NOTE")
                            End If
                        Else
                            objbColLabel(intk) = collMainRowTitle.Item("NOTE")
                        End If
                        intk += 1
                End Select
            Next
            'Select Overdue Information
            strPatronIDs = ""
            tblItem = GetOverdueListAuthority(0, 0)
            objTemp = tblItem
            'for Header or Footer
            Dim arrdt() As DataRow
            Dim dt As DataRow
            ReDim strOutMsg(tblData.Rows.Count - 1)
            Dim strContent As String = strContentTemp
            If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                ReDim objData(UBound(objFields))
            End If
            For inti = 0 To tblData.Rows.Count - 1 'for each item in datatable
                'ReDim objData(UBound(objtemplate.Fields))

                strContent = strContentTemp
                'PhuongTT
                '20081011
                'Sua lai so thu tu ban ghi va mang objData(inti) --> objData(intj)
                If strBool <> "" Then
                    arrdt = tblItem.Select("PatronID=" & tblData.Rows(inti).Item("ID") & " And OverdueDate" & strBool)
                Else
                    arrdt = tblItem.Select("PatronID=" & tblData.Rows(inti).Item("ID"))
                End If
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    For intj = LBound(objFields) To UBound(objFields)
                        Select Case objFields(intj)
                            Case "CARDNUMBER"
                                If Not IsDBNull(tblData.Rows(inti).Item("Code")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Code")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Code") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If

                            Case "NAME"
                                If Not IsDBNull(tblData.Rows(inti).Item("Name")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Name")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Name") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If
                            Case "DOB"
                                If Not IsDBNull(tblData.Rows(inti).Item("DOB")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("DOB")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("DOB") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If

                            Case "OCUPATION"
                                If Not IsDBNull(tblData.Rows(inti).Item("Occupation")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Occupation")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Occupation") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If
                            Case "WORKPLACE"
                                If Not IsDBNull(tblData.Rows(inti).Item("WorkPlace")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("WorkPlace")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("WorkPlace") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If
                            Case "WORKADDRESS"
                                If Not IsDBNull(tblData.Rows(inti).Item("WorkAddress")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("WorkAddress")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("WorkAddress") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If
                            Case "HOMEADDRESS"
                                If Not IsDBNull(tblData.Rows(inti).Item("Address")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Address")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Address") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If

                            Case "PHONE"
                                If Not IsDBNull(tblData.Rows(inti).Item("Telephone")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Telephone")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Telephone") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If
                            Case "FACULITY"
                                If Not IsDBNull(tblData.Rows(inti).Item("Faculty")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Faculty")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Faculty") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If

                            Case "GRADE"
                                If Not IsDBNull(tblData.Rows(inti).Item("Grade")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Grade")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Grade") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If

                            Case "CARDVALIDDATE"
                                If Not IsDBNull(tblData.Rows(inti).Item("ValidDate")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("ValidDate")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("ValidDate") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If

                            Case "CARDEXPIREDDATE"
                                If Not IsDBNull(tblData.Rows(inti).Item("ExpiredDate")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("ExpiredDate")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("ExpiredDate") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If

                            Case "EMAIL"
                                If Not IsDBNull(tblData.Rows(inti).Item("Email")) Then
                                    'objData(intj) = objTvCom.Convert("ucs2", "unicode1", tblData.Rows(inti).Item("Email")) & Chr(9)
                                    objData(intj) = tblData.Rows(inti).Item("Email") & Chr(9)
                                Else
                                    objData(intj) = " " & Chr(9)
                                End If
                            Case "DATE"
                                objData(intj) = DateTime.Now.ToString("dd/MM/yyyy") & Chr(9)
                            Case "NOTE"
                                objData(intj) = tblData.Rows(inti).Item("Note") & Chr(9)
                            Case "LOANCOUNT"
                                objData(intj) = tblData.Rows(inti).Item("LoanCount") & Chr(9)
                            Case Else
                                objData(intj) = " " & Chr(9)
                        End Select
                        strContent = Replace(strContent, "<$" & objFields(intj) & "$>", objData(intj))
                    Next
                End If
                'Generete data for Header and Footer
                'objStream = objtemplate.Generate(objData)
                objStream = strContent

                objStream = Replace(objStream, "  ", "&nbsp;&nbsp;")
                'Generate String Template 
                'strOutMsg(inti) = objBCStringProc.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
                strOutMsg(inti) = Left(objStream, InStr(objStream, "@@@@@") - 1)
                strOutMsg(inti) = strOutMsg(inti) & "<TABLE WIDTH=100% CELLPADDING=3 CELLSPACING=0 BORDER=1 BORDERCOLOR=""#000000"" COLSPAN=" & UBound(objbColLabel) & " >"
                'strOutMsg(inti) = strOutMsg(inti) & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 BGCOLOR=""#000000"">"
                strOutMsg(inti) = strOutMsg(inti) & "<TR  BGCOLOR=""#FFFFFF""> "
                For intj = 0 To UBound(objbColLabel)
                    strWidth = ""
                    'Collum Width
                    If UBound(bUserColWidth) >= intj Then
                        If Not Trim(bUserColWidth(intj)) = "" Then
                            strWidth = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                        End If
                    End If
                    strAlign = ""
                    'Collum Align
                    If UBound(bUserColAlign) >= intj Then
                        If Not Trim(bUserColAlign(intj)) = "" Then
                            strAlign = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
                        End If
                    End If
                    'Collum Format
                    If UBound(bUserColFormat) >= intj Then
                        If Not Trim(bUserColFormat(intj)) = "" Then
                            strFormat = Trim(bUserColFormat(intj))
                        End If
                    End If
                    If Not strFormat = "" Then
                        strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " ALIGN=TOP BGCOLOR=""#FFFFFF"" >" & Replace(strFormat, "<$DATA$>", objbColLabel(intj)) & "</TD>"
                    Else
                        strOutMsg(inti) = strOutMsg(inti) & "<TD ALIGN=""center"" VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=""#FFFFFF"" >" & objbColLabel(intj) & "</TD>"
                    End If
                Next 'end for intj
                intIndex = 1
                For Each dt In arrdt
                    'for table title                
                    strOutMsg(inti) = strOutMsg(inti) & "</TR><TR  BGCOLOR=""#FFFFFF"">"
                    'for collum and row objData
                    For intj = 0 To UBound(objbCols)
                        'Width
                        strWidth = ""
                        If UBound(bUserColWidth) >= intj Then
                            If Not Trim(bUserColWidth(intj)) = "" Then
                                strWidth = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                            End If
                        End If
                        'Align 
                        strAlign = ""
                        If UBound(bUserColAlign) >= intj Then
                            If Not Trim(bUserColAlign(intj)) = "" Then
                                strAlign = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
                            End If
                        End If
                        'Format
                        strFormat = ""
                        bollFormat = False 'default not have Format
                        If UBound(bUserColFormat) >= intj Then
                            If Not Trim(bUserColFormat(intj)) = "" Then
                                bollFormat = True 'have Format
                            End If
                        End If
                        Select Case objbCols(intj)
                            Case "<$ITEMCODE$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("ItemCode")) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("ItemCode") & "&nbsp;</TD>"
                                End If
                            Case "<$COPYNUMBER$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CopyNumber")) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CopyNumber") & "&nbsp;</TD>"
                                End If
                            Case "<$ITEMTITLE$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("MainTitle")) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("MainTitle") & "&nbsp;</TD>"
                                End If
                            Case "<$CHECKOUTDATE$>"
                                If strDBServer = "ORACLE" Then
                                    If bollFormat Then
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CHECKOUTDATE")) & "</TD>"
                                    Else
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CHECKOUTDATE") & "&nbsp;</TD>"
                                    End If
                                Else
                                    If bollFormat Then
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CheckOutDate")) & "</TD>"
                                    Else
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CheckOutDate") & "&nbsp;</TD>"
                                    End If
                                End If
                            Case "<$CHECKINDATE$>"
                                If strDBServer = "ORACLE" Then
                                    If bollFormat Then
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CHECKINDATE")) & "</TD>"
                                    Else
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CHECKINDATE") & "&nbsp;</TD>"
                                    End If
                                Else
                                    If bollFormat Then
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("CheckInDate")) & "</TD>"
                                    Else
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("CheckInDate") & "&nbsp;</TD>"
                                    End If
                                End If
                            Case "<$OVERDUEDATE$>"
                                If strDBServer = "ORACLE" Then
                                    If bollFormat Then
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("OVERDUEDATE")) & "</TD>"
                                    Else
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("OVERDUEDATE") & "&nbsp;</TD>"
                                    End If
                                Else
                                    If bollFormat Then
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("OverdueDate")) & "</TD>"
                                    Else
                                        strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("OverdueDate") & "&nbsp;</TD>"
                                    End If
                                End If
                            Case "<$PENATI$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", formatCurrency(dt.Item("Penati"))) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & formatCurrency(dt.Item("Penati")) & "&nbsp;</TD>"
                                End If
                            Case "<$SEQUENCY$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", intIndex) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & intIndex & "&nbsp;</TD>"
                                End If
                                intIndex += 1
                            Case "<$LIBRARY$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("LibCode")) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("LibCode") & "&nbsp;</TD>"
                                End If
                                'intIndex += 1
                            Case "<$STORE$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", dt.Item("LocCode")) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("LocCode") & "&nbsp;</TD>"
                                End If
                                'intIndex += 1
                            Case "<$NOTE$>"
                                If bollFormat Then
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD  VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & bUserColFormat(intj).Replace("<$DATA$>", formatCurrency(dt.Item("Note"))) & "</TD>"
                                Else
                                    strOutMsg(inti) = strOutMsg(inti) & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=""#FFFFFF"" >" & dt.Item("Note") & "&nbsp;</TD>"
                                End If
                        End Select
                    Next
                Next
                'strOutMsg(inti) = strOutMsg(inti) & "</TR>"
                'strOutMsg(inti) = strOutMsg(inti) & "</TABLE></TD></TR></TABLE>"
                'PhuongTT 20080113
                'B1
                strOutMsg(inti) = strOutMsg(inti) & "</TR></TABLE>"
                'E1
                strOutMsg(inti) = strOutMsg(inti) & Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4) & "<BR>"
            Next
            'objTvCom = Nothing
            'objtemplate = Nothing
            Return (strOutMsg)
        End Function

        ' GetOverdueInfo method
        ' Purpose: Print to Overdue Patrons
        ' Input: 
        Public Function GetOverduePatronPrint(Optional strFullName As String = "", Optional intPatronGroupID As Integer = 0) As String
            Dim tblOverduePatron As DataTable = Nothing
            Dim arrstrOutMsg() As String
            Dim strOutMsg As String = ""
            Dim inti As Integer
            Select Case intOverduePrintMode
                Case 0 ' all overdue Patrons
                    objDOverdueTransaction.SelectMode = "ALL"
                    objDOverdueTransaction.Logic = ""
                    objDOverdueTransaction.DueTime = 0
                    objDOverdueTransaction.PatronIDs = ""
                Case 1 ' some overdue Patrons in DueTime
                    objDOverdueTransaction.SelectMode = "SOME"
                    objDOverdueTransaction.Logic = strLogic
                    objDOverdueTransaction.DueTime = intDueTime
                    objDOverdueTransaction.PatronIDs = ""
                Case 2 ' some overdue Patrons in PickPatronIDs
                    objDOverdueTransaction.SelectMode = "SOME"
                    objDOverdueTransaction.Logic = ""
                    objDOverdueTransaction.DueTime = 0
                    objDOverdueTransaction.PatronIDs = strPickPatronIDs
            End Select
            objDOverdueTransaction.LibID = intLibID
            tblOverduePatron = objDOverdueTransaction.GetOverduePatron(strFullName, intPatronGroupID)
            If Not IsDBNull(tblOverduePatron) Then
                If tblOverduePatron.Rows.Count > 0 Then
                    If intOverduePrintMode = 1 Then
                        arrstrOutMsg = GenOverdueInfor(tblOverduePatron, intOverdueTemplateID, strLogic & intDueTime)
                    Else
                        arrstrOutMsg = GenOverdueInfor(tblOverduePatron, intOverdueTemplateID, "")
                    End If
                    If arrstrOutMsg.Length > 0 Then
                        arrstrOutMsg(0) = arrstrOutMsg(0).Replace("CLASS='breakhere'", "")
                    End If
                    For inti = 0 To UBound(arrstrOutMsg)
                        strOutMsg = strOutMsg & arrstrOutMsg(inti)
                    Next
                    Return (strOutMsg)
                Else
                    Return ("")
                End If
            Else
                Return ("")
            End If
        End Function

        '' Method: GetOverduePatronSendMail
        '' Purpose: Send Mail to OverduePatron
        'Public Function GetOverduePatronSendMail() As String
        '    Dim tblOverduePatron As DataTable = Nothing
        '    Dim tblSMTPMail As DataTable = Nothing
        '    Dim strSMTPPort As String = ""
        '    Dim strSMTPServer As String = ""
        '    Dim strAdminEmail As String = ""
        '    Dim strEmailAddress As String = ""
        '    Dim strPatronName As String = ""
        '    Dim arrOverduePatronInfo() As String
        '    Dim strSMTPSQL As String = "SELECT  Name,Val FROM Sys_tblParameter WHERE Name IN ('SMTP_SERVER','SMTP_PORT','ADMIN_EMAIL_ADDRESS')"
        '    Dim objMail As New ASPEMAILLib.MailSender
        '    Dim dvOP As New DataView
        '    Dim inti As Integer

        '    Try
        '        Select Case intOverduePrintMode
        '            Case 0 ' all overdue Patrons
        '                objDOverdueTransaction.SelectMode = "ALL"
        '                objDOverdueTransaction.Logic = ""
        '                objDOverdueTransaction.DueTime = 0
        '                objDOverdueTransaction.PatronIDs = ""
        '            Case 1 ' some overdue Patrons in DueTime
        '                objDOverdueTransaction.SelectMode = "ALL"
        '                objDOverdueTransaction.Logic = strLogic
        '                objDOverdueTransaction.DueTime = intDueTime
        '                objDOverdueTransaction.PatronIDs = ""
        '            Case 2 ' some overdue Patrons in PickPatronIDs
        '                objDOverdueTransaction.SelectMode = "SOME"
        '                objDOverdueTransaction.Logic = ""
        '                objDOverdueTransaction.DueTime = 0
        '                objDOverdueTransaction.PatronIDs = strPickPatronIDs
        '        End Select
        '        tblOverduePatron = objBCDataBaseSystem.ConvertTable(objDOverdueTransaction.GetOverduePatron)

        '        dvOP = tblOverduePatron.DefaultView

        '        objTemp = Nothing
        '        If dvOP.Count > 0 Then
        '            dvOP.RowFilter = "Email LIKE '%@%'"
        '            tblOverduePatron = dvOP.Table
        '            arrOverduePatronInfo = GenOverdueInfor(tblOverduePatron, intOverdueTemplateID)
        '            objTemp = arrOverduePatronInfo
        '            objBCDataBaseSystem.SQLStatement = strSMTPSQL
        '            tblSMTPMail = objBCDataBaseSystem.RetrieveItemInfor
        '            strSMTPServer = tblSMTPMail.Rows(0).Item("Val")
        '            strSMTPPort = tblSMTPMail.Rows(2).Item("Val")
        '            strAdminEmail = tblSMTPMail.Rows(1).Item("Val")
        '            objMail.From = strAdminEmail
        '            If strSMTPPort = "" Then
        '                strSMTPPort = 25
        '            End If
        '            objMail.Host = strSMTPServer
        '            objMail.Port = strSMTPPort
        '            objMail.Subject = objBCStringProc.ToUTF8(strOverdueMessage)
        '            objMail.From = strAdminEmail
        '            objMail.IsHTML = True
        '            For inti = 0 To tblOverduePatron.Rows.Count - 1
        '                objMail.Reset()
        '                If Not IsDBNull(tblOverduePatron.Rows(inti).Item("Email")) Then
        '                    strEmailAddress = tblOverduePatron.Rows(inti).Item("Email")
        '                    objMail.AddAddress(strEmailAddress)
        '                    objMail.Body = objBCStringProc.ToUTF8(arrOverduePatronInfo(inti))
        '                    objMail.Send()
        '                    strPatronName &= tblOverduePatron.Rows(inti).Item("Name") & ","
        '                End If
        '            Next
        '            objMail = Nothing
        '            If Not strPatronName = "" Then
        '                Return (Left(strPatronName, Len(strPatronName) - 1))
        '            Else
        '                Return ("")
        '            End If
        '        Else
        '            objMail = Nothing
        '            Return ("")
        '        End If
        '        objMail = Nothing
        '    Catch ex As Exception
        '        strErrorMsg = ex.Message.Trim
        '    End Try
        'End Function

        ' Method: GetOverduePatronSendMail
        ' Purpose: Send Mail to OverduePatron
        Public Function GetOverduePatronSendMail(Optional strFullName As String = "", Optional intPatronGroupID As Integer = 0) As DataView
            Dim tblOverduePatron As New DataTable
            Try
                Select Case intOverduePrintMode
                    Case 0 ' all overdue Patrons
                        objDOverdueTransaction.SelectMode = "ALL"
                        objDOverdueTransaction.Logic = ""
                        objDOverdueTransaction.DueTime = 0
                        objDOverdueTransaction.PatronIDs = ""
                    Case 1 ' some overdue Patrons in DueTime
                        objDOverdueTransaction.SelectMode = "ALL"
                        objDOverdueTransaction.Logic = strLogic
                        objDOverdueTransaction.DueTime = intDueTime
                        objDOverdueTransaction.PatronIDs = ""
                    Case 2 ' some overdue Patrons in PickPatronIDs
                        objDOverdueTransaction.SelectMode = "SOME"
                        objDOverdueTransaction.Logic = ""
                        objDOverdueTransaction.DueTime = 0
                        objDOverdueTransaction.PatronIDs = strPickPatronIDs
                End Select
                objDOverdueTransaction.LibID = intLibID
                tblOverduePatron = objDOverdueTransaction.GetOverduePatron(strFullName, intPatronGroupID)
                strErrorMsg = objDOverdueTransaction.ErrorMsg
                intErrorCode = objDOverdueTransaction.ErrorCode

                GetOverduePatronSendMail = objBCDataBaseSystem.ConvertTable(tblOverduePatron).DefaultView
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' Method: UpdatePatronEmail
        ' Purpose: Update Patron Email
        Public Sub UpdatePatronEmail()
            Try
                objDOverdueTransaction.LibID = intLibID
                objDOverdueTransaction.PatronCode = strPatronCode
                objDOverdueTransaction.Email = strEmail

                objDOverdueTransaction.UpDatePatronEmail()
                strErrorMsg = objDOverdueTransaction.ErrorMsg
                intErrorCode = objDOverdueTransaction.ErrorCode

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub


        ' PaidOverdue method
        ' Purpose: Pay OverdueFees
        ' Input: Amount
        Public Sub PaidOverdue()
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function formatCurrency(ByVal str As String) As String
            Return Double.Parse(str).ToString("N0", CultureInfo.InvariantCulture)
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCDataBaseSystem Is Nothing Then
                    objBCDataBaseSystem.Dispose(True)
                    objBCDataBaseSystem = Nothing
                End If
                If Not objDOverdueTransaction Is Nothing Then
                    objDOverdueTransaction.Dispose(True)
                    objDOverdueTransaction = Nothing
                End If
                If Not objBCStringProc Is Nothing Then
                    objBCStringProc.Dispose(True)
                    objBCStringProc = Nothing
                End If
                If Not objBOverdueTemplate Is Nothing Then
                    objBOverdueTemplate.Dispose(True)
                    objBOverdueTemplate = Nothing
                End If
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
            End If
            MyBase.Dispose()
            Dispose()
        End Sub
    End Class
End Namespace