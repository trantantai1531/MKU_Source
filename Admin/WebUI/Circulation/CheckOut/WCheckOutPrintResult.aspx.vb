' Class: WCheckOutPrintResult
' Puspose: Display result for print
' Creator: Oanhtn
' CreatedDate: 01/09/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckOutPrintResult
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents fdf As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBLoanTransaction As New clsBLoanTransaction
        Private objBCTemplate As New clsBCommonTemplate
        Private objBILLInR As New clsBILLInRequest
        Private objBCSP As New clsBCommonStringProc
        Private objBTemplate As New clsBCommonTemplate
        Private objBCDBS As New clsBCommonDBSystem


        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Page.IsPostBack = False Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBLoanTransaction object
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            Call objBLoanTransaction.Initialize()

            ' Initialize objBCTemplate object
            objBCTemplate.ConnectionString = Session("ConnectionString")
            objBCTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCTemplate.DBServer = Session("DBServer")
            objBCTemplate.Initialize()

            ' Initialize objBILLInR object
            objBILLInR.ConnectionString = Session("ConnectionString")
            objBILLInR.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInR.DBServer = Session("DBServer")
            objBILLInR.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBTemplate object
            objBTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBTemplate.DBServer = Session("DBServer")
            objBTemplate.ConnectionString = Session("ConnectionString")
            Call objBTemplate.Initialize()

            ' Initialize objBCC object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        Private Sub BindData()
            Dim tblTemplate As New DataTable, tblMoney As New DataTable, tblFaculty As New DataTable
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim objFields As Object, objData As Object, objFieldDetail As Object, objDataDetail As Object
            Dim strTransIDs As String
            Dim tblCurrentTrans As DataTable
            Dim strOutMsgheader As String = ""
            Dim strOutMsgDetail As String = ""
            Dim strOutMsgFooter As String = ""
            Dim strContent As String = "", strheader As String = "", strfooter As String = "", strdetail As String = ""
            Dim inti As Integer, intj As Integer, intIndex As Integer, intLeft As Integer, intk As Integer

            Try
                objBCTemplate.TemplateID = 0
                objBCTemplate.TemplateType = 37
                objBCTemplate.LibID = clsSession.GlbSite
                tblTemplate = objBCTemplate.GetTemplate
                If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                    'Xu ly khuon dang
                    strContent = tblTemplate.Rows(0).Item("Content")
                    'strheader = "<BODY MARGINWIDTH=11 MARGINHEIGHT=0 TOPMARGIN=0 LEFTMARGIN=11 BGCOLOR=""""FFFFFF"""" STYLE =""""font-family:Arial Unicode MS"""">" & vbCrLf
                    'strheader &= "<FONT FACE = """"Arial Unicode MS"""">" & vbCrLf
                    'strheader &= "<CENTER><B><FONT  FACE = """"Arial Unicode MS"""" SIZE=+1>Phiếu mượn sách</FONT></B></CENTER><P>" & vbCrLf
                    'strheader &= "<UL>" & vbCrLf
                    'strheader &= "<LI>Người mượn:<$NAME$></LI>" & vbCrLf
                    'strheader &= "<LI>Số thẻ:<$CODE$>" & vbCrLf
                    'strheader &= "</UL>" & vbCrLf
                    'strheader &= "<TABLE CELLPADDING=5 CELLSPACING=0 BORDER=0 WIDTH=""96%"" align=""center"" > " & vbCrLf
                    'strheader &= "<TR BGCOLOR=""C0C0C0"">" & vbCrLf
                    'strheader &= "<TH width=""60%"" ALIGN=""LEFT"" VALIGN=""TOP""><SMALL>Tên ấn phẩm</SMALL></TH>" & vbCrLf
                    'strheader &= "<TH width=""15%"" ALIGN=""LEFT"" VALIGN=""TOP""><SMALL>ĐKCB</SMALL></TH>" & vbCrLf
                    'strheader &= "<TH width=""13%"" ALIGN=""LEFT"" VALIGN=""TOP""><SMALL>Ngày mượn</SMALL></TH>" & vbCrLf
                    'strheader &= "<TH width=""12%"" ALIGN=""LEFT"" VALIGN=""TOP""><SMALL>Hạn trả</SMALL></TH>" & vbCrLf
                    'strheader &= "</TR>" & vbCrLf
                    'strheader &= "</TABLE>" & vbCrLf
                    ''intIndex = InStr(strContent, "<~~>")
                    ''strheader = Left(strContent, intIndex - 1)
                    ''strContent = Right(strContent, Len(strContent) - intIndex - 4)
                    ''intIndex = InStr(strContent, "<~~>")
                    ''strfooter = Right(strContent, Len(strContent) - intIndex - 4)
                    ''strContent = Left(strContent, intIndex - 1)
                    'strfooter = "<HR WIDTH=100% SIZE=1 NOSHADE COLOR=""""000000"""">" & vbCrLf
                    'strfooter &= "<SMALL><P ALIGN = """"RIGHT"""">Ngày&nbsp;<$DD$>&nbsp;Tháng&nbsp;<$MM$>&nbsp;Năm&nbsp;<$YYYY$><BR>" & vbCrLf
                    'strfooter &= "Chữ ký người mượn&nbsp;&nbsp;&nbsp;</SMALL>" & vbCrLf
                    'strfooter &= "<P>&nbsp;<P ALIGN = """"RIGHT"""">" & vbCrLf
                    'strfooter &= "<B><$NAME$></B>" & vbCrLf
                    'strfooter &= "</BODY>" & vbCrLf
                End If
                If Not Session("TransactionID") Is Nothing Then
                    strTransIDs = Session("TransactionID")
                    If Not Trim(Session("TransactionID")) = "" Then
                        ' Create grid loan informations
                        tblCurrentTrans = objBLoanTransaction.GetCurrentLoanInfor(CStr(Session("TransactionID")), "LOAN")
                        tblFaculty = objBLoanTransaction.GetCurrentLoanInfor(CStr(Session("TransactionID")), "FACULTY")
                        tblMoney = objBLoanTransaction.GetCurrentLoanInfor(CStr(Session("TransactionID")), "MONEY")
                        If Not tblCurrentTrans Is Nothing And Not tblFaculty Is Nothing And Not tblMoney Is Nothing Then
                            If tblCurrentTrans.Rows.Count > 0 Then
                                If tblFaculty.Rows.Count = 0 Then
                                    tblFaculty = Me.InsertOneRow(tblFaculty, " ")
                                End If
                                'Write header
                                'strOutMsgheader = GenData(strheader, tblCurrentTrans, tblFaculty, tblMoney, False)
                                'Write Content
                                strOutMsgDetail = GenData(strContent, tblCurrentTrans, tblFaculty, tblMoney, True)
                                'Write footer
                                'strOutMsgFooter = GenData(strfooter, tblCurrentTrans, tblFaculty, tblMoney, False)
                            End If
                            tblCurrentTrans = Nothing
                        End If
                        lblDisplay.Visible = True


                        'lblDisplay.Text = strOutMsgheader & strOutMsgDetail & strOutMsgFooter 'objBCSP.ToUTF8Back(strOutMsgheader & strOutMsgDetail & strOutMsgFooter)
                        'QuocDD remove header and footer 
                        lblDisplay.Text = strOutMsgDetail
                    End If
                End If
                If Request("EndSession") = "1" Then
                    Session("TransactionID") = Nothing
                    Session("Remain") = Nothing
                End If
            Catch ex As Exception
            Finally
                'objTemplate = Nothing
            End Try
        End Sub
        Private Function GenData(ByVal strContent As String, ByVal tblCurrentTrans As DataTable, ByVal tblFaculty As DataTable, ByVal tblMoney As DataTable, Optional ByVal blnRepeat As Boolean = False) As String
            Dim strResult As String = strContent
            Try
                Dim dblTotal As Integer = 0
                For inti = 0 To tblMoney.Rows.Count - 1
                    dblTotal = dblTotal + CLng(tblMoney.Rows(inti).Item("FINES"))
                Next
                If Not blnRepeat Then
                    If InStr(strResult, "<$NAME$>") > 0 Then
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("FULLNAME")) Then
                            strResult = Replace(strResult, "<$NAME$>", tblCurrentTrans.Rows(0).Item("FULLNAME"))
                        End If
                    End If
                    If Not IsDBNull(tblCurrentTrans.Rows(0).Item("FULLNAME")) Then
                        strResult = Replace(strResult, "<$FULLNAME$>", tblCurrentTrans.Rows(0).Item("FULLNAME"))
                    End If
                    If InStr(strResult, "<$CODE$>") > 0 Then
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("PATRONCODE")) Then
                            strResult = Replace(strResult, "<$CODE$>", tblCurrentTrans.Rows(0).Item("PATRONCODE"))
                        End If
                    End If
                    If Not IsDBNull(tblCurrentTrans.Rows(0).Item("PATRONCODE")) Then
                        strResult = Replace(strResult, "<$PATRONCODE$>", tblCurrentTrans.Rows(0).Item("PATRONCODE"))
                    End If
                    If InStr(strResult, "<$DOB$>") > 0 Then
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("DOB")) Then
                            strResult = Replace(strResult, "<$DOB$>", tblCurrentTrans.Rows(0).Item("DOB"))
                        End If
                    End If
                    If InStr(strResult, "<$CLASS$>") > 0 Then
                        If Not IsDBNull(tblFaculty.Rows(0).Item("CLASS")) Then
                            strResult = Replace(strResult, "<$CLASS$>", tblCurrentTrans.Rows(0).Item("CLASS"))
                        End If
                    End If
                    If InStr(strResult, "<$FACULTY$>") > 0 Then
                        If Not IsDBNull(tblFaculty.Rows(0).Item("FACULTY")) Then
                            strResult = Replace(strResult, "<$FACULTY$>", tblCurrentTrans.Rows(0).Item("FACULTY"))
                        End If
                    End If
                    If InStr(strResult, "<$GRADE$>") > 0 Then
                        If Not IsDBNull(tblFaculty.Rows(0).Item("GRADE")) Then
                            strResult = Replace(strResult, "<$GRADE$>", tblCurrentTrans.Rows(0).Item("GRADE"))
                        End If
                    End If
                    If InStr(strResult, "<$TITLE$>") > 0 Then
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("TITLE")) Then
                            strResult = Replace(strResult, "<$TITLE$>", tblCurrentTrans.Rows(0).Item("TITLE"))
                        End If
                    End If
                    If InStr(strResult, "<$COPYNUMBER$>") > 0 Then
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("COPYNUMBER")) Then
                            strResult = Replace(strResult, "<$COPYNUMBER$>", tblCurrentTrans.Rows(0).Item("COPYNUMBER"))
                        End If
                    End If
                    If InStr(strResult, "<$CHECKOUTDATE$>") > 0 Then
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("CHECKOUTDATE")) Then
                            strResult = Replace(strResult, "<$CHECKOUTDATE$>", tblCurrentTrans.Rows(0).Item("CHECKOUTDATE"))
                        End If
                    End If
                    If InStr(strResult, "<$DUEDATE$>") > 0 Then
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("DUEDATE")) Then
                            strResult = Replace(strResult, "<$DUEDATE$>", tblCurrentTrans.Rows(0).Item("DUEDATE"))
                        End If
                    End If
                    If InStr(strResult, "<$FEES$>") > 0 Then
                        If Not IsDBNull(tblMoney.Rows(0).Item("FEES")) Then
                            strResult = Replace(strResult, "<$FEES$>", tblCurrentTrans.Rows(0).Item("FEES"))
                        End If
                    End If
                    If InStr(strResult, "<$FINES$>") > 0 Then
                        If Not IsDBNull(tblMoney.Rows(0).Item("FINES")) Then
                            strResult = Replace(strResult, "<$FINES$>", tblCurrentTrans.Rows(0).Item("FINES"))
                        End If
                    End If
                    If InStr(strResult, "<$MONEY$>") > 0 Then
                        If Not IsDBNull(tblMoney.Rows(0).Item("TOTAL")) Then
                            strResult = Replace(strResult, "<$MONEY$>", tblCurrentTrans.Rows(0).Item("TOTAL"))
                        End If
                    End If
                    If InStr(strResult, "<$DD$>") > 0 Then
                        strResult = Replace(strResult, "<$DD$>", CStr(Day(Now)).PadLeft(2, "0"))
                    End If
                    If InStr(strResult, "<$MM$>") > 0 Then
                        strResult = Replace(strResult, "<$MM$>", CStr(Month(Now)).PadLeft(2, "0"))
                    End If
                    If InStr(strResult, "<$YYYY$>") > 0 Then
                        strResult = Replace(strResult, "<$YYYY$>", Year(Now))
                    End If

                    'else
                    'strField = objFields(inti)
                    'intLeft = CInt(Len(strField))
                    'intIndex = InStr(strField, ":")
                    'If intIndex > 0 Then
                    '    intLeft = CInt(Right(strField, Len(strField) - intIndex))
                    '    strField = Left(strField, 5)
                    '    If strField = "TITLE" Then
                    '        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("TITLE")) Then
                    '            objData(inti) = Left(tblCurrentTrans.Rows(0).Item("TITLE"), intLeft) & "..." & Chr(9)
                    '        End If
                    '    End If
                    'End If
                Else
                    Dim St As [String] = strContent
                    Dim pFrom As Integer = St.IndexOf("<$TABLE$>") + "<$TABLE$>".Length
                    Dim pTo As Integer = St.LastIndexOf("</$TABLE$>")
                    Dim contentTable As [String] = St.Substring(pFrom, pTo - pFrom)
                    'strResult = strResult.Replace("</$TABLE$>", "")
                    For intj = 0 To tblCurrentTrans.Rows.Count - 1
                        If InStr(strResult, "<$NAME$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(0).Item("FULLNAME")) Then
                                strResult = Replace(strResult, "<$NAME$>", tblCurrentTrans.Rows(0).Item("FULLNAME"))
                            End If
                        End If
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("FULLNAME")) Then
                            strResult = Replace(strResult, "<$FULLNAME$>", tblCurrentTrans.Rows(0).Item("FULLNAME"))
                        End If
                        If InStr(strResult, "<$CODE$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(0).Item("PATRONCODE")) Then
                                strResult = Replace(strResult, "<$CODE$>", tblCurrentTrans.Rows(0).Item("PATRONCODE"))
                            End If
                        End If
                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("PATRONCODE")) Then
                            strResult = Replace(strResult, "<$PATRONCODE$>", tblCurrentTrans.Rows(0).Item("PATRONCODE"))
                        End If
                        If InStr(strResult, "<$DOB$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("DOB")) Then
                                strResult = Replace(strResult, "<$DOB$>", tblCurrentTrans.Rows(intj).Item("DOB"))
                            End If
                        End If
                        If InStr(strResult, "<$CLASS$>") > 0 Then
                            If Not IsDBNull(tblFaculty.Rows(0).Item("CLASS")) Then
                                strResult = Replace(strResult, "<$CLASS$>", tblCurrentTrans.Rows(intj).Item("CLASS"))
                            End If
                        End If
                        If InStr(strResult, "<$FACULTY$>") > 0 Then
                            If Not IsDBNull(tblFaculty.Rows(0).Item("FACULTY")) Then
                                strResult = Replace(strResult, "<$FACULTY$>", tblCurrentTrans.Rows(intj).Item("FACULTY"))
                            End If
                        End If
                        If InStr(strResult, "<$GRADE$>") > 0 Then
                            If Not IsDBNull(tblFaculty.Rows(0).Item("GRADE")) Then
                                strResult = Replace(strResult, "<$GRADE$>", tblCurrentTrans.Rows(intj).Item("GRADE"))
                            End If
                        End If
                        If InStr(strResult, "<$TITLE$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("TITLE")) Then
                                strResult = Replace(strResult, "<$TITLE$>", tblCurrentTrans.Rows(intj).Item("TITLE"))
                            End If
                        End If
                        If InStr(strResult, "<$COPYNUMBER$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("COPYNUMBER")) Then
                                strResult = Replace(strResult, "<$COPYNUMBER$>", tblCurrentTrans.Rows(intj).Item("COPYNUMBER"))
                            End If
                        End If
                        If InStr(strResult, "<$CHECKOUTDATE$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("CHECKOUTDATE")) Then
                                strResult = Replace(strResult, "<$CHECKOUTDATE$>", tblCurrentTrans.Rows(intj).Item("CHECKOUTDATE"))
                            End If
                        End If
                        If InStr(strResult, "<$DUEDATE$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("DUEDATE")) Then
                                strResult = Replace(strResult, "<$DUEDATE$>", tblCurrentTrans.Rows(intj).Item("DUEDATE"))
                            End If
                        End If
                        If InStr(strResult, "<$FEES$>") > 0 Then
                            If Not IsDBNull(tblMoney.Rows(0).Item("FEES")) Then
                                strResult = Replace(strResult, "<$FEES$>", tblCurrentTrans.Rows(intj).Item("FEES"))
                            End If
                        End If
                        If InStr(strResult, "<$FINES$>") > 0 Then
                            If Not IsDBNull(tblMoney.Rows(0).Item("FINES")) Then
                                strResult = Replace(strResult, "<$FINES$>", tblCurrentTrans.Rows(intj).Item("FINES"))
                            End If
                        End If

                        If InStr(strResult, "<$MONEY$>") > 0 Then
                            If Not IsDBNull(tblMoney.Rows(0).Item("TOTAL")) Then
                                strResult = Replace(strResult, "<$MONEY$>", tblCurrentTrans.Rows(intj).Item("TOTAL"))
                            End If
                        End If
                        If InStr(strResult, "<$DD$>") > 0 Then
                            strResult = Replace(strResult, "<$DD$>", CStr(Day(Now)).PadLeft(2, "0"))
                        End If
                        If InStr(strResult, "<$MM$>") > 0 Then
                            strResult = Replace(strResult, "<$MM$>", CStr(Month(Now)).PadLeft(2, "0"))
                        End If
                        If InStr(strResult, "<$YYYY$>") > 0 Then
                            strResult = Replace(strResult, "<$YYYY$>", Year(Now))
                        End If
                        If InStr(strResult, "<$LOANDEPOSITFEE$>") > 0 Then
                            If Not IsDBNull(tblCurrentTrans.Rows(0).Item("LOANDEPOSITFEE")) Then
                                Dim strDeposit = tblCurrentTrans.Rows(0).Item("LOANDEPOSITFEE")
                                strResult = Replace(strResult, "<$LOANDEPOSITFEE$>", String.Format("{0:###,###}", strDeposit))
                            End If
                        End If

                        If intj < tblCurrentTrans.Rows.Count - 1 Then
                            Dim pToNew As Integer = strResult.LastIndexOf("</$TABLE$>")
                            strResult = strResult.Insert(pToNew, contentTable)
                        End If
                    Next
                    strResult = strResult.Replace("<$TABLE$>", "")
                    strResult = strResult.Replace("</$TABLE$>", "")
                End If
            Catch ex As Exception
            End Try

            Return strResult

            ''Dim objTemplate As New TVCOMLib.LibolTemplate
            'Dim objFields As Object, objData As Object
            'Dim inti As Integer, intj As Integer
            'Dim strOutMsg As String = ""
            'Dim strField As String
            'Dim intLeft As Integer
            'Dim intIndex As Integer
            'Dim dblTotal As Long = 0

            'For inti = 0 To tblMoney.Rows.Count - 1
            '    dblTotal = dblTotal + CLng(tblMoney.Rows(inti).Item("FINES"))
            'Next

            'objTemplate.Template = objBCSP.ToUTF8(strContent)
            'objFields = objTemplate.Fields
            'ReDim objData(UBound(objFields))
            'If blnRepeat = False Then
            '    For inti = LBound(objFields) To UBound(objFields)
            '        objData(inti) = " "
            '        Select Case objFields(inti)
            '            Case "NAME"
            '                If Not IsDBNull(tblCurrentTrans.Rows(0).Item("FULLNAME")) Then
            '                    objData(inti) = tblCurrentTrans.Rows(0).Item("FULLNAME") & Chr(9)
            '                End If
            '            Case "CODE"
            '                If Not IsDBNull(tblCurrentTrans.Rows(0).Item("PATRONCODE")) Then
            '                    objData(inti) = tblCurrentTrans.Rows(0).Item("PATRONCODE") & Chr(9)
            '                End If
            '            Case "DOB"
            '                If Not IsDBNull(tblCurrentTrans.Rows(0).Item("DOB")) Then
            '                    objData(inti) = tblCurrentTrans.Rows(0).Item("DOB") & Chr(9)
            '                End If
            '            Case "CLASS"
            '                If Not IsDBNull(tblFaculty.Rows(0).Item("CLASS")) Then
            '                    objData(inti) = tblFaculty.Rows(0).Item("CLASS") & Chr(9)
            '                End If
            '                'Khoa
            '            Case "FACULTY"
            '                If Not IsDBNull(tblFaculty.Rows(0).Item("FACULTY")) Then
            '                    objData(inti) = tblFaculty.Rows(0).Item("FACULTY") & Chr(9)
            '                End If
            '                'Khóa
            '            Case "GRADE"
            '                If Not IsDBNull(tblFaculty.Rows(0).Item("GRADE")) Then
            '                    objData(inti) = tblFaculty.Rows(0).Item("GRADE") & Chr(9)
            '                End If
            '            Case "TITLE"
            '                If Not IsDBNull(tblCurrentTrans.Rows(0).Item("TITLE")) Then
            '                    objData(inti) = tblCurrentTrans.Rows(0).Item("TITLE") & Chr(9)
            '                End If
            '            Case "COPYNUMBER"
            '                If Not IsDBNull(tblCurrentTrans.Rows(0).Item("COPYNUMBER")) Then
            '                    objData(inti) = tblCurrentTrans.Rows(0).Item("COPYNUMBER") & Chr(9)
            '                End If
            '            Case "CHECKOUTDATE"
            '                If Not IsDBNull(tblCurrentTrans.Rows(0).Item("CHECKOUTDATE")) Then
            '                    objData(inti) = tblCurrentTrans.Rows(0).Item("CHECKOUTDATE") & Chr(9)
            '                End If
            '            Case "DUEDATE"
            '                If Not IsDBNull(tblCurrentTrans.Rows(0).Item("DUEDATE")) Then
            '                    objData(inti) = tblCurrentTrans.Rows(0).Item("DUEDATE") & Chr(9)
            '                End If
            '            Case "FEES"
            '                If Not IsDBNull(tblMoney.Rows(0).Item("FEES")) Then
            '                    objData(inti) = CInt(tblMoney.Rows(0).Item("FEES")) & Chr(9)
            '                End If
            '            Case "FINES"
            '                If Not IsDBNull(tblMoney.Rows(0).Item("FINES")) Then
            '                    objData(inti) = CInt(tblMoney.Rows(0).Item("FINES")) & Chr(9)
            '                End If
            '            Case "MONEY"
            '                If Not IsDBNull(tblMoney.Rows(0).Item("TOTAL")) Then
            '                    objData(inti) = dblTotal & Chr(9)
            '                End If
            '            Case "DD"
            '                objData(inti) = CStr(Day(Now)).PadLeft(2, "0") & Chr(9)
            '            Case "MM"
            '                objData(inti) = CStr(Month(Now)).PadLeft(2, "0") & Chr(9)
            '            Case "YYYY"
            '                objData(inti) = Year(Now)
            '            Case Else
            '                strField = objFields(inti)
            '                intLeft = CInt(Len(strField))
            '                intIndex = InStr(strField, ":")
            '                If intIndex > 0 Then
            '                    intLeft = CInt(Right(strField, Len(strField) - intIndex))
            '                    strField = Left(strField, 5)
            '                    If strField = "TITLE" Then
            '                        If Not IsDBNull(tblCurrentTrans.Rows(0).Item("TITLE")) Then
            '                            objData(inti) = Left(tblCurrentTrans.Rows(0).Item("TITLE"), intLeft) & "..." & Chr(9)
            '                        End If
            '                    End If
            '                End If
            '        End Select
            '        objData(inti) = objBCSP.ToUTF8(objData(inti))
            '    Next
            '    strOutMsg = objTemplate.Generate(objData)
            'Else
            '    For intj = 0 To tblCurrentTrans.Rows.Count - 1
            '        For inti = LBound(objFields) To UBound(objFields)
            '            objData(inti) = " "
            '            Select Case objFields(inti)
            '                Case "NAME"
            '                    If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("FULLNAME")) Then
            '                        objData(inti) = tblCurrentTrans.Rows(intj).Item("FULLNAME") & Chr(9)
            '                    End If
            '                Case "CODE"
            '                    If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("PATRONCODE")) Then
            '                        objData(inti) = tblCurrentTrans.Rows(intj).Item("PATRONCODE") & Chr(9)
            '                    End If
            '                Case "DOB"
            '                    If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("DOB")) Then
            '                        objData(inti) = tblCurrentTrans.Rows(intj).Item("DOB") & Chr(9)
            '                    End If
            '                Case "CLASS"
            '                    If Not IsDBNull(tblFaculty.Rows(0).Item("CLASS")) Then
            '                        objData(inti) = tblFaculty.Rows(0).Item("CLASS") & Chr(9)
            '                    End If
            '                    'Khoa
            '                Case "FACULTY"
            '                    If Not IsDBNull(tblFaculty.Rows(0).Item("FACULTY")) Then
            '                        objData(inti) = tblFaculty.Rows(0).Item("FACULTY") & Chr(9)
            '                    End If
            '                    'Khóa
            '                Case "GRADE"
            '                    If Not IsDBNull(tblFaculty.Rows(0).Item("GRADE")) Then
            '                        objData(inti) = tblFaculty.Rows(0).Item("GRADE") & Chr(9)
            '                    End If
            '                Case "TITLE"
            '                    If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("TITLE")) Then
            '                        objData(inti) = tblCurrentTrans.Rows(intj).Item("TITLE") & Chr(9)
            '                    End If
            '                Case "COPYNUMBER"
            '                    If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("COPYNUMBER")) Then
            '                        objData(inti) = tblCurrentTrans.Rows(intj).Item("COPYNUMBER") & Chr(9)
            '                    End If
            '                Case "CHECKOUTDATE"
            '                    If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("CHECKOUTDATE")) Then
            '                        objData(inti) = tblCurrentTrans.Rows(intj).Item("CHECKOUTDATE") & Chr(9)
            '                    End If
            '                Case "DUEDATE"
            '                    If Not IsDBNull(tblCurrentTrans.Rows(intj).Item("DUEDATE")) Then
            '                        objData(inti) = tblCurrentTrans.Rows(intj).Item("DUEDATE") & Chr(9)
            '                    End If
            '                Case "FEES"
            '                    If Not IsDBNull(tblMoney.Rows(0).Item("FEES")) Then
            '                        objData(inti) = tblMoney.Rows(0).Item("FEES") & Chr(9)
            '                    End If
            '                Case "FINES"
            '                    If Not IsDBNull(tblMoney.Rows(0).Item("FINES")) Then
            '                        objData(inti) = tblMoney.Rows(0).Item("FINES") & Chr(9)
            '                    End If
            '                Case "MONEY"
            '                    If Not IsDBNull(tblMoney.Rows(0).Item("TOTAL")) Then
            '                        objData(inti) = dblTotal & Chr(9)
            '                    End If
            '                Case "DD"
            '                    objData(inti) = CStr(Day(Now)).PadLeft(2, "0") & Chr(9)
            '                Case "MM"
            '                    objData(inti) = CStr(Month(Now)).PadLeft(2, "0") & Chr(9)
            '                Case "YYYY"
            '                    objData(inti) = Year(Now)
            '                Case Else
            '                    strField = objFields(inti)
            '                    intLeft = CInt(Len(strField))
            '                    intIndex = InStr(strField, ":")
            '                    If intIndex > 0 Then
            '                        intLeft = CInt(Right(strField, Len(strField) - intIndex))
            '                        strField = Left(strField, 5)
            '                        If strField = "TITLE" Then
            '                            If Not IsDBNull(tblCurrentTrans.Rows(0).Item("TITLE")) Then
            '                                objData(inti) = Left(tblCurrentTrans.Rows(intj).Item("TITLE"), intLeft) & "..." & Chr(9)
            '                            End If
            '                        End If
            '                    End If
            '            End Select
            '            objData(inti) = objBCSP.ToUTF8(objData(inti))
            '        Next
            '        strOutMsg = strOutMsg & objTemplate.Generate(objData)
            '    Next
            'End If
            'GenData = strOutMsg
        End Function

        ' Event: Page_Unload

        'Private Sub BindData()
        '    If Not Session("TransactionID") Is Nothing Then
        '        If Not Trim(Session("TransactionID")) = "" Then
        '            Dim tblCurrentTransPatron As DataTable = objBLoanTransaction.GetCurrentLoanInforToPrintCheckOut(CStr(Session("TransactionID")), "Patron")

        '            Dim tblCurrentTransLoanCheckOut As DataTable = objBLoanTransaction.GetCurrentLoanInforToPrintCheckOut(CStr(Session("TransactionID")), "LoanCheckOut")

        '            objBTemplate.TemplateID = 36
        '            objBTemplate.TemplateType = 37
        '            Dim tblTemplate As DataTable = objBTemplate.GetTemplate()
        '            If Not IsNothing(tblTemplate) Then
        '                If tblTemplate.Rows.Count > 0 Then
        '                    Dim strHTMLResult As String = tblTemplate.Rows(0).Item("Content") & ""
        '                    Dim splitHTMLResult() As String = strHTMLResult.Split(New String() {"<hr/>"}, StringSplitOptions.None)

        '                    If Not IsNothing(tblCurrentTransPatron) Then
        '                        If tblCurrentTransPatron.Rows.Count > 0 Then
        '                            Dim strHTMLPatron As String = splitHTMLResult(0) & ""
        '                            strHTMLPatron = strHTMLPatron.Replace("<$FULLNAME$>", tblCurrentTransPatron.Rows(0).Item("FullName"))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$FACULTY$>", tblCurrentTransPatron.Rows(0).Item("FACULTY"))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$GRADE$>", tblCurrentTransPatron.Rows(0).Item("GRADE"))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$PATRONCODE$>", tblCurrentTransPatron.Rows(0).Item("PATRONCODE"))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$ADDRESS$>", tblCurrentTransPatron.Rows(0).Item("ADDRESS"))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$MOBILE$>", tblCurrentTransPatron.Rows(0).Item("MOBILE"))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$EMAIL$>", tblCurrentTransPatron.Rows(0).Item("EMAIL"))

        '                            strHTMLPatron = strHTMLPatron.Replace("<$DATE.NOW$>", String.Format("{0:dd/MM/yyyy}", Date.Now))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$DATE.NOW.DAY$>", Day(Now))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$DATE.NOW.MONTH$>", Month(Now))
        '                            strHTMLPatron = strHTMLPatron.Replace("<$DATE.NOW.YEAR$>", Year(Now))

        '                            Dim strHTMLLoanCheckOut As String = ""
        '                            If Not IsNothing(tblCurrentTransLoanCheckOut) Then
        '                                If tblCurrentTransLoanCheckOut.Rows.Count > 0 Then
        '                                    strHTMLPatron = strHTMLPatron.Replace("<$COUNTLOAN$>", tblCurrentTransLoanCheckOut.Rows.Count)

        '                                    If splitHTMLResult.Length > 1 Then
        '                                        Dim strHTMLLoanCheckOutBase As String = splitHTMLResult(1) & ""

        '                                        For Each rows As DataRow In tblCurrentTransLoanCheckOut.Rows
        '                                            Dim strHTMLLoanCheckOutTmp As String = strHTMLLoanCheckOutBase

        '                                            Dim strContent245 As String = rows.Item("Content245") & ""
        '                                            Dim strContent260 As String = rows.Item("Content260") & ""
        '                                            Dim strContent300 As String = rows.Item("Content300") & ""
        '                                            Dim strPrice As String = rows.Item("Price") & ""
        '                                            Dim strCopyNumber As String = rows.Item("COPYNUMBER") & ""
        '                                            Dim strLocationName As String = rows.Item("LOCATIONNAME") & ""
        '                                            Dim strCheckOutDate As String = String.Format("{0:dd/MM/yyyy}", Date.Parse(rows.Item("CHECKOUTDATE")))
        '                                            Dim strDueDate As String = String.Format("{0:dd/MM/yyyy}", Date.Parse(rows.Item("DUEDATE")))

        '                                            Dim strTitle As String = objBCDBS.GetContent(strContent245, "$", "a")
        '                                            Dim strAuthor As String = objBCDBS.GetContent(strContent245, "$", "c")
        '                                            Dim strPublisher As String = objBCDBS.GetContent(strContent260, "$", "b")
        '                                            Dim strPublishyear As String = objBCDBS.GetContent(strContent260, "$", "c")
        '                                            Dim strCountPage As String = objBCDBS.GetContent(strContent300, "$", "a")
        '                                            Dim strSize As String = objBCDBS.GetContent(strContent300, "$", "c")

        '                                            strTitle = strTitle.Replace(" . . ", ". ")
        '                                            strTitle = strTitle.Replace(" , , ", ", ")
        '                                            strTitle = strTitle.Replace(" /", "")
        '                                            If CInt(strPrice) > 0 Then
        '                                                strPrice = String.Format("{0:0,0} VNĐ", CInt(strPrice))
        '                                            Else
        '                                                strPrice = "0 VNĐ"
        '                                            End If
        '                                            strPublisher = strPublisher.Substring(0, strPublisher.Length - 1).Trim()
        '                                            strCountPage = strCountPage.Substring(0, strCountPage.Length - 1).Trim()

        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$245a$>", strTitle.Trim())
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$245c$>", strAuthor)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$260b$>", strPublisher)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$260c$>", strPublishyear)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$300a$>", strCountPage)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$300c$>", strSize)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$DATE.NOW$>", String.Format("{0:dd/MM/yyyy}", Date.Now))
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$PRICE$>", strPrice)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$COPYNUMBER$>", strCopyNumber)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$LOCATIONNAME$>", strLocationName)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$DUEDATE$>", strDueDate)
        '                                            strHTMLLoanCheckOutTmp = strHTMLLoanCheckOutTmp.Replace("<$CHECKOUTDATE$>", strCheckOutDate)

        '                                            strHTMLLoanCheckOut = strHTMLLoanCheckOut & strHTMLLoanCheckOutTmp & vbCr
        '                                        Next
        '                                    End If
        '                                End If
        '                            Else
        '                                strHTMLPatron = strHTMLPatron.Replace("<$COUNTLOAN$>", 0)
        '                            End If
        '                            lblDisplay.Text = strHTMLPatron.Replace("<$DETAILLOAN$>", strHTMLLoanCheckOut)
        '                        End If
        '                    End If

        '                End If
        '            End If
        '        End If
        '    End If
        'End Sub
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
                If Not objBTemplate Is Nothing Then
                    objBTemplate.Dispose(True)
                    objBTemplate = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace