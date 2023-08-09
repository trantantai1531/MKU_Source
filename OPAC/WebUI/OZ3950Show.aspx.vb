Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OZ3950Show
        Inherits clsWBaseJqueryUI

        ' Declare variables
        Private objBCSP As New clsBCommonStringProc
        Private objBZ3950 As New clsBZ3950
        Private ProccessedQuery As Boolean
        Private strSearchedCount As String = "0"

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            BindData()
            If Not Page.IsPostBack Then
                Call ProcessZQuery(1)
                ShowResult()
            End If
        End Sub

        ' Method: Initialize
        ' This method used to init all objects
        Private Sub Initialize()
            objBZ3950.InterfaceLanguage = Session("InterfaceLanguage")
            objBZ3950.DBServer = Session("DBServer")
            objBZ3950.ConnectionString = Session("ConnectionString")
            Call objBZ3950.Initialize()

            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        ' Method: BindJS
        Sub BindJS()
            'Page.RegisterClientScriptBlock("WZFindJs", "<script language = 'javascript' src = 'Js/Z3950/OZ3950Show.js'></script>")
        End Sub
        Public Sub BindData()
            If Not Session("Hits") Is Nothing Then
                lblSumrec.Text = Session("Hits")
            End If
            'If Not Page.IsPostBack Then
            '    If UCase(CStr(Request("chkVietUSMARC") & "")) = "ON" Then
            '        Session("VietUSMARC") = True
            '    Else
            '        Session("VietUSMARC") = False
            '    End If
            '    If Not Request("txtZServer") = "" Then
            '        Session("zServer") = Request("txtZServer")
            '    End If
            '    If Not Request("txtzPort") = "" Then
            '        Session("zPort") = Request("txtzPort")
            '    End If
            '    If Not Request("txtzDatabase") = "" Then
            '        Session("zDatabase") = Request("txtzDatabase")
            '    End If
            '    If Not Request("ddlFieldName1") = "" Then
            '        Session("FieldName1") = Request("ddlFieldName1")
            '    End If
            '    If Not Request("ddlFieldName2") = "" Then
            '        Session("FieldName2") = Request("ddlFieldName2")
            '    End If
            '    If Not Request("ddlFieldName3") = "" Then
            '        Session("FieldName3") = Request("ddlFieldName3")
            '    End If
            '    'If Not Request("txtFieldValue1") = "" Then
            '    Session("FieldValue1") = Request("txtFieldValue1")
            '    'End If
            '    'If Not Request("txtFieldValue2") = "" Then
            '    Session("FieldValue2") = Request("txtFieldValue2")
            '    'End If
            '    'If Not Request("txtFieldValue3") = "" Then
            '    Session("FieldValue3") = Request("txtFieldValue3")
            '    'End If
            '    If Not Request("ddlOperator2") = "" Then
            '        Session("Operator2") = Request("ddlOperator2")
            '    End If
            '    If Not Request("ddlOperator3") = "" Then
            '        Session("Operator3") = Request("ddlOperator3")
            '    End If
            '    If Not Request("ddlLimit") = "" Then
            '        Session("ddlLimit") = Request("ddlLimit")
            '    End If
            '    'ddlLimit
            '    Select Case LCase(Request("optDisplay"))
            '        Case "optisbd"
            '            ddlDisplay.SelectedIndex = 1
            '        Case "optmarc"
            '            ddlDisplay.SelectedIndex = 0
            '        Case "optsimple"
            '            ddlDisplay.SelectedIndex = 2
            '        Case Else
            '            ddlDisplay.SelectedIndex = 1
            '    End Select
            'End If
            Session("VietUSMARC") = False
            Dim colData As New Collection
            colData = Session("z3950Data")
            If Not IsNothing(colData.Item("txtzServer")) AndAlso colData.Item("txtzServer") <> "" Then
                Session("zServer") = colData.Item("txtzServer")
            End If
            If Not IsNothing(colData.Item("txtZPort")) AndAlso colData.Item("txtZPort") <> "" Then
                Session("zPort") = colData.Item("txtZPort")
            End If
            If Not IsNothing(colData.Item("txtZDatabase")) AndAlso colData.Item("txtZDatabase") <> "" Then
                Session("zDatabase") = colData.Item("txtZDatabase")
            End If
            If Not IsNothing(colData.Item("ddlFieldName1")) AndAlso colData.Item("ddlFieldName1") <> "" Then
                Session("FieldName1") = colData.Item("ddlFieldName1")
            End If
            If Not IsNothing(colData.Item("ddlFieldName2")) AndAlso colData.Item("ddlFieldName2") <> "" Then
                Session("FieldName2") = colData.Item("ddlFieldName2")
            End If
            If Not IsNothing(colData.Item("ddlFieldName3")) AndAlso colData.Item("ddlFieldName3") <> "" Then
                Session("FieldName3") = colData.Item("ddlFieldName3")
            End If
            If Not IsNothing(colData.Item("txtFieldValue1")) AndAlso colData.Item("txtFieldValue1") <> "" Then
                Session("FieldValue1") = colData.Item("txtFieldValue1")
            End If
            If Not IsNothing(colData.Item("txtFieldValue2")) AndAlso colData.Item("txtFieldValue2") <> "" Then
                Session("FieldValue2") = colData.Item("txtFieldValue2")
            End If
            If Not IsNothing(colData.Item("txtFieldValue3")) AndAlso colData.Item("txtFieldValue3") <> "" Then
                Session("FieldValue3") = colData.Item("txtFieldValue3")
            End If
            If Not IsNothing(colData.Item("ddlOperator2")) AndAlso colData.Item("ddlOperator2") <> "" Then
                Session("Operator2") = colData.Item("ddlOperator2")
            End If
            If Not IsNothing(colData.Item("ddlOperator3")) AndAlso colData.Item("ddlOperator3") <> "" Then
                Session("Operator3") = colData.Item("ddlOperator3")
            End If
            If Not IsNothing(colData.Item("ddlLimit")) AndAlso colData.Item("ddlLimit") <> "" Then
                Session("ddlLimit") = colData.Item("ddlLimit")
            End If
            'If Not IsNothing(colData.Item("Display")) AndAlso colData.Item("Display") <> "" Then
            '    'ddlLimit
            '    Select Case LCase(colData.Item("Display"))
            '        Case "optisbd"
            '            ddlDisplay.SelectedIndex = 1
            '        Case "optmarc"
            '            ddlDisplay.SelectedIndex = 0
            '        Case "optsimple"
            '            ddlDisplay.SelectedIndex = 2
            '        Case Else
            '            ddlDisplay.SelectedIndex = 1
            '    End Select
            'End If

            'set session display
            lbShowRemote.Text = spServer.InnerText & Session("zServer") & ":" & Session("zPort")
            lbShowDatabase.Text = spDatabase.InnerText & Session("zDatabase")
            If ddlDisplay.SelectedIndex < 3 Then
                Session("Display") = ddlDisplay.SelectedIndex
            End If
        End Sub

        Private Sub ProcessZQuery(ByVal intStart As Integer)
            Session("Hits") = Nothing
            'process query
            'ShowWaitingOnPage(ddlLabel.Items(6).Text, "..")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            objBZ3950.zServer = Session("zServer")
            objBZ3950.zPort = Session("zPort")
            objBZ3950.zDatabase = Session("zDatabase")
            objBZ3950.FieldName1 = Session("FieldName1")
            objBZ3950.FieldValue1 = Session("FieldValue1")
            objBZ3950.FieldName2 = Session("FieldName2")
            objBZ3950.FieldValue2 = Session("FieldValue2")
            objBZ3950.FieldName3 = Session("FieldName3")
            objBZ3950.FieldValue3 = Session("FieldValue3")
            objBZ3950.Operator2 = Session("Operator2")
            objBZ3950.Operator3 = Session("Operator3")

            objBZ3950.VietUSMARC = Session("VietUSMARC")
            'objBZ3950.Start = intStart
            'objBZ3950.Howmany = 50 'Select 50 records/transaction
            'If CStr(hidCountrec.Value) <> "" Then
            '    If CInt(hidCountrec.Value) - intStart >= 50 Then
            '        objBZ3950.Howmany = 50 'Select 50 records/transaction
            '    Else
            '        objBZ3950.Howmany = CInt(hidCountrec.Value) - intStart
            '    End If
            'End If

            Dim intTop As Integer = 50
            If Not IsNothing(Session("ddlLimit")) AndAlso Session("ddlLimit") <> "" Then
                intTop = Session("ddlLimit")
            End If

            'Process ZQuery
            Call objBZ3950.ProccessQuery(intTop)
            ProccessedQuery = False
            hidCountrec.Value = 0
            If objBZ3950.ErrorMsg = "" Then
                hidCountrec.Value = objBZ3950.Hits
                Session("Hits") = CStr(objBZ3950.Hits)
                If objBZ3950.Hits <= 0 Then
                    Session("objBZ3950Record") = Nothing
                    lblSumrec.Text = "0"
                    'NotFound.Text = ddlLabel.Items(10).Text
                    NotFound.Visible = True
                Else
                    strSearchedCount = CInt(hidCountrec.Value) - 1
                    If hidCountrec.Value < 0 Then
                        strSearchedCount = "0"
                    End If
                    lblSumrec.Text = Session("Hits")
                    ProccessedQuery = True
                    Session("objBZ3950Record") = objBZ3950.Record
                    Session("RecZ3950Start") = intStart
                    'txtNext.Text = intStart + 10
                End If
            Else
                Session("objBZ3950Record") = Nothing
                NotFound.Text = ddlLabel.Items(10).Text & ": " & objBZ3950.ZError
            End If
            'hidden progess bar
            'ShowWaitingOnPage("", "", True)
        End Sub

        Private Sub ShowResult()
            ' Declare variables
            'Dim objResult As Object
            Dim objTagName() As String
            Dim objTagValue() As String
            Dim intCounter As Integer
            Dim objResult() As String = Session("objBZ3950Record")
            ' Process
            If objResult Is Nothing Then
                ' Error
                NotFound.Visible = True
                ddlDisplay.Visible = False
                lblDisplay.Visible = False
            Else
                ReDim objTagName(0)
                ReDim objTagValue(0)
                ddlDisplay.Visible = True
                lblDisplay.Visible = True
                lblSumrec.Text = Session("Hits")
                Dim intTotal As Integer = Session("Hits")
                Dim intPagezise As Integer = Application("ePageSize")
                Dim intPageLength As Integer = Application("ePageLength")
                Dim intPageSpace As Integer = Application("ePageSpace")
                Dim intSumPage As Integer = 0
                Dim intStart, intStop As Integer
                Dim intCurPage As Integer
                intSumPage = (intTotal - 1) \ intPagezise + 1
                intCurPage = hidCurrentPage.Value
                intStart = (intCurPage - 1) * intPagezise
                intStop = (((intCurPage - 1) * intPagezise) + intPagezise) - 1
                If intStart > intTotal - 1 Then
                    intStart = intTotal - 1
                End If
                If intStop > intTotal - 1 Then
                    intStop = intTotal - 1
                End If

                Call showPagingControl(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop)

                'Dim strResult As String = ""
                'strResult &= "<div>"
                'strResult &= "<div class='listview-outlook' data-role='listview'>"
                'For intCounter = intStart To intStop
                '    strResult &= "<a class='list' onclick='#'  style='cursor:default;'>"
                '    strResult &= "<div class='list-content'>" 'list-title
                '    strResult &= "<span class='list-title'>"
                '    strResult &= (intCounter + 1).ToString & ". " & getRecord(intCounter, objResult(intCounter))
                '    strResult &= "</span>"
                '    strResult &= "</div>"
                '    strResult &= "</a>"
                'Next
                'strResult &= "</div>" 'Close data-role='listview'
                'strResult &= "</div>" 'Close div class='span4'

                Dim strResult As String = ""
                strResult &= "<table class='table striped'>"
                strResult &= "<tbody>"
                strResult &= "<thead>"
                strResult &= "<tr>"
                strResult &= "<th  class='text-left'>"
                strResult &= lblDisplay.Text & ddlDisplay.Text
                strResult &= "</th>"
                strResult &= "</tr>"
                strResult &= "</thead>"
                For intCounter = intStart To intStop
                    strResult &= "<tr>"
                    strResult &= "<td class='list-content'>" 'list-title
                    strResult &= "<span class='list-title'>"
                    strResult &= (intCounter + 1).ToString & ". " & getRecord(intCounter, objResult(intCounter))
                    strResult &= "</span>"
                    strResult &= "</td>"
                    strResult &= "</tr>"
                Next
                strResult &= "</tbody>" 'Close data-role='listview'
                strResult &= "</table>" 'Close div class='span4'

                ltrContent.Text = strResult

            End If
        End Sub

        '' purpose :  show paging as google paging
        '' Creator: phuongtt
        'Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer)
        '    Try
        '        Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
        '        Dim strPagination As String = ""
        '        Dim PreviousPage As Integer = intPage - 1
        '        Dim NextPage As Integer = intPage + 1
        '        If PreviousPage >= 1 Then
        '            strPagination &= "<li class='prev'><a onclick='showRecordByPage(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top'><i class='icon-previous' style='padding:1px;'></i></a></li>"
        '        End If
        '        Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
        '        Dim alpha As Integer = (xy - 1) * intPageSpace
        '        Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

        '        For j As Integer = 1 + alpha To iPageCount
        '            If j = intPage Then
        '                strPagination &= "<li class='active'>"
        '            Else
        '                strPagination &= "<li>"
        '            End If
        '            strPagination &= "<a onclick='showRecordByPage(" & j.ToString & ")'>" & j.ToString & "</a><li>"
        '        Next
        '        If NextPage <= iPage Then
        '            strPagination &= "<li class='next'><a onclick='showRecordByPage(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'><i class='icon-next' style='padding:1px;'></i></a></li>"
        '        End If
        '        lrtPagination1.Text = strPagination
        '        lrtPagination2.Text = strPagination

        '        Dim strItemInfo As String = ""
        '        strItemInfo &= "<div style='vertical-align:middle;'><span class='tertiary-text-secondary'>"
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= spRecordItem.InnerText
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= intPagezise * (intPage - 1) + 1
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= spRecordTo.InnerText
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= intStop + 1
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= spRecordOf.InnerText
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= intCount
        '        'strItemInfo &= "</strong> "
        '        strItemInfo &= "</span>"
        '        strItemInfo &= "</div>"
        '        lrtPagination1.Text &= strItemInfo
        '        lrtPagination2.Text &= strItemInfo
        '    Catch ex As Exception
        '    End Try
        'End Sub


        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer)
            Try
                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    strPagination &= "<li><a onclick='showRecordByPage(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                End If
                Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                Dim alpha As Integer = (xy - 1) * intPageSpace
                Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                For j As Integer = 1 + alpha To iPageCount
                    strPagination &= "<li>"
                    If j = intPage Then
                        strPagination &= "<a onclick='showRecordByPage(" & j.ToString & ")' class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    Else
                        strPagination &= "<a onclick='showRecordByPage(" & j.ToString & ")'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    End If
                    strPagination &= "</li>"
                Next
                If NextPage <= iPage Then
                    strPagination &= "<li><a onclick='showRecordByPage(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
                End If
                lrtPagination1.Text = strPagination
                lrtPagination2.Text = strPagination

                Dim strItemInfo As String = ""
                strItemInfo &= "<div style='vertical-align:middle;'><span class='tertiary-text-secondary'>"
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordItem.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intPagezise * (intPage - 1) + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordTo.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intStop + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordOf.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intCount, 0)
                'strItemInfo &= "</strong> "
                strItemInfo &= "</span>"
                strItemInfo &= "</div>"
                lrtPagination1.Text &= strItemInfo
                lrtPagination2.Text &= strItemInfo
            Catch ex As Exception
            End Try
        End Sub

        Private Function getRecord(ByVal intCurRec As Integer, ByVal strRec As String) As String
            Dim objTagName() As String
            Dim objTagValue() As String
            ReDim objTagName(0)
            ReDim objTagValue(0)
            Dim strResult As String = ""
            Try
                Select Case Trim(Session("Display") & "")

                    Case 1
                        ddlDisplay.SelectedIndex = 1
                        'show ISBD
                        Call objBZ3950.FillValueFieldsToArray(strRec, objTagName, objTagValue, "$")
                        strRec = ISBDDisplay(objTagName, objTagValue)
                        strResult = strRec

                    Case 0
                        ddlDisplay.SelectedIndex = 0
                        'show MARC
                        Call objBZ3950.FillValueFieldsToArray(strRec, objTagName, objTagValue, "$", True)
                        strRec = MARCDisplay(objTagName, objTagValue)
                        strResult = strRec

                    Case 2
                        ddlDisplay.SelectedIndex = 2
                        'show Simple
                        Call objBZ3950.FillValueFieldsToArray(strRec, objTagName, objTagValue, "$")
                        strRec = SimpleDisplay(objTagName, objTagValue)

                        strResult = strRec
                    Case Else
                        ddlDisplay.SelectedIndex = 0
                        'show MARC
                        Call objBZ3950.FillValueFieldsToArray(strRec, objTagName, objTagValue, "$", True)
                        strRec = MARCDisplay(objTagName, objTagValue)
                        strResult = strRec

                End Select
            Catch ex As Exception
            End Try
            Return strResult

        End Function

        ' ISBDDisplay method
        Public Function ISBDDisplay(ByVal Array1() As String, ByVal Array2() As String) As String
            Dim strResult As String = ""
            Dim strTemp As String = ""
            For i As Integer = 0 To UBound(Array1)
                If Not Array1(i) Is Nothing AndAlso Not Array2(i) Is Nothing Then
                    Select Case Array1(i)
                        Case "100", "110", "111"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & objBCSP.TrimSubFieldCodes(strTemp) & ". </B>"
                        Case "245"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= objBCSP.TrimSubFieldCodes(strTemp)
                        Case "260"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= ". - " & objBCSP.TrimSubFieldCodes(strTemp)
                        Case "300"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= ". - " & objBCSP.TrimSubFieldCodes(strTemp)
                    End Select
                End If
            Next
            Return strResult
        End Function

        ' ISBDDisplay method
        Public Function SimpleDisplay(ByVal Array1() As String, ByVal Array2() As String) As String
            Dim strResult As String = ""
            Dim strTemp As String = ""
            For i As Integer = 0 To UBound(Array1)
                If Not Array1(i) Is Nothing AndAlso Not Array2(i) Is Nothing Then
                    Select Case Array1(i)
                        Case "100", "110", "111"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(2).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                        Case "245"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(3).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                        Case "260"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(4).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                        Case "300"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(5).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                    End Select
                End If
            Next
            Return strResult
        End Function


        Public Function MARCDisplay(ByVal Array1() As String, ByVal Array2() As String) As String
            Dim strResult As String = ""
            Dim strTemp As String = ""
            For i As Integer = 0 To UBound(Array1)
                If Not Array1(i) Is Nothing AndAlso Not Array2(i) Is Nothing Then
                    strTemp = Array1(i) & Space(1) & objBZ3950.ConvertUTF8toUni(Array2(i)) & "<BR />"
                    strResult &= strTemp
                End If
            Next
            strResult &= "<hr />"
            Return strResult
        End Function


        Private Sub raiseShowRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseShowRecord.Click
            Try
                Dim intCurrenPage As Integer = hidCurrentPage.Value
                Call ShowResult()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub ddlDisplay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDisplay.SelectedIndexChanged
            Try
                Dim intCurrenPage As Integer = hidCurrentPage.Value
                If ddlDisplay.SelectedIndex < 3 Then
                    Session("Display") = ddlDisplay.SelectedIndex
                End If
                Call ShowResult()
            Catch ex As Exception
            End Try
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBZ3950 Is Nothing Then
                    objBZ3950.Dispose(True)
                    objBZ3950 = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

      
        
    End Class
End Namespace
