Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ODetail
        Inherits clsWBaseJqueryUI 'clsWBase

        Private objBOpacItem As New clsBOPACItem
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBOPACFile As New clsBOPACFile
        Private objBOPACDictionary As New clsBOPACDictionary
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBFilterBrowse As New clsBOPACFilterBrowse
        Private objBholdReq As New clsBOPACHoldRequest
        Private objBResever As New clsBReserve

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindCatalogueData("")
                Call updateViews()
            Else
                  If Not clsUICommon.checkPermission() Then
                    Page.ClientScript.RegisterStartupScript(Page.GetType, "scriptName_FreeText", "<script type=""text/javascript"">close()</script>")
                    'Response.Redirect("OLoginRequest.aspx?RequestLogin=1", True)
                End If
            End If
        End Sub

        Private Sub updateViews()
            Try
                Dim ItemID As Integer = objBOpacItem.ItemID
                If Not String.IsNullOrEmpty(clsSession.GlbUser) Then
                    Dim bolResult As Boolean = objBOPACFile.updateViews(ItemID, DatePart(DateInterval.WeekOfYear, Now.Date), Now.Date.Month, Now.Date.Year, clsSession.GlbUser)
                Else
                    Dim bolResult As Boolean = objBOPACFile.updateViews(ItemID, DatePart(DateInterval.WeekOfYear, Now.Date), Now.Date.Month, Now.Date.Year)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Init method
        ' purpose initialize all components
        ' Creator : phuongtt
        Private Sub Initialize()
            ' Init objBOPACItem object
            objBOPACFile.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACFile.DBServer = Session("DBServer")
            objBOPACFile.ConnectionString = Session("ConnectionString")
            Call objBOPACFile.Initialize()

            ' init Holding Request object
            objBholdReq.InterfaceLanguage = Session("InterfaceLanguage")
            objBholdReq.DBServer = Session("DBServer")
            objBholdReq.ConnectionString = Session("ConnectionString")
            objBholdReq.Initialize()

            ' init OPACItem object
            objBOpacItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOpacItem.DBServer = Session("DBServer")
            objBOpacItem.ConnectionString = Session("ConnectionString")
            objBOpacItem.Initialize()

            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            '  Init objBOPACDictionary
            objBOPACDictionary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACDictionary.ConnectionString = Session("ConnectionString")
            objBOPACDictionary.DBServer = Session("DBServer")
            objBOPACDictionary.Initialize()

            '  Init objBResever
            objBResever.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBResever.ConnectionString = Session("ConnectionString")
            objBResever.DBServer = Session("DBServer")
            objBResever.Initialize()

            ' Init objBHoldingInfo object
            objBFilterBrowse.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBFilterBrowse.DBServer = Session("DBServer")
            objBFilterBrowse.ConnectionString = Session("ConnectionString")
            Call objBFilterBrowse.Initialize()

            ' init objBSearchQr object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

            If Not IsNothing(Request("intItemID")) Then
                objBOpacItem.ItemID = CInt(Request("intItemID"))
                hidItemID.Value = Request("intItemID")
            End If

            If Not IsNothing(Request("searchWord")) Then
                hidWord.Value = Request("searchWord")
            End If


            If clsSession.GlbIds Is Nothing Then
                If Request.QueryString("intItemID") & "" <> "" AndAlso IsNumeric(Request.QueryString("intItemID")) Then
                    objBOpacItem.ItemID = CInt(Request.QueryString("intItemID"))
                Else
                End If
            Else
            End If
        End Sub

        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'Common/eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/ODetail.js'></script>")
        End Sub


        'Private Sub BindHoldingInfor(ByVal strStyle As String)
        '    Try
        '        ltrBarcodeSimple.Text = ""
        '        ltrBarcodeISBD.Text = ""
        '        ltrBarcodeFull.Text = ""
        '        ltrBarcodeMARC.Text = ""
        '        If objBOpacItem.TotalItems > 0 Then
        '            'If (UCase(strStyle)) <> "MARC" Then
        '            Dim strResult As String = ""
        '            strResult &= "<div class='panel-header'>"
        '            strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spBarcodeInfo.InnerText
        '            strResult &= "</div>"
        '            strResult &= "<div class='panel-content'>"
        '            strResult &= "<div class='grid no-margin'>"
        '            strResult &= "<div class='row'>"
        '            strResult &= "<div class='span2'>"
        '            strResult &= "<p class='text-center'>"
        '            strResult &= "<span class='item-title-secondary'>" & objBOpacItem.AvailItems & " / " & objBOpacItem.TotalItems & "</span>"
        '            strResult &= "<br />"
        '            strResult &= spAvailable.InnerText
        '            strResult &= "</p>"
        '            strResult &= "</div>"
        '            strResult &= "<div class='span7'>"
        '            Dim strId As String = objBOpacItem.ItemID
        '            strResult &= objBOpacItem.GetHoldingInfor(Request.QueryString("intSerID"), spFree.InnerText, spBusy.InnerText, spMap.InnerText)
        '            strResult &= "</div>" 'div span7
        '            strResult &= "</div>" 'div grid no-margin
        '            strResult &= "</div>" 'div row
        '            strResult &= "</div>" 'div panel-content
        '            Select Case (UCase(strStyle))
        '                Case "MARC"
        '                    ltrBarcodeMARC.Text = strResult
        '                Case "FULLRECORD"
        '                    ltrBarcodeFull.Text = strResult
        '                Case "ISBD"
        '                    ltrBarcodeISBD.Text = strResult
        '                Case "SIMPLE"
        '                    ltrBarcodeSimple.Text = strResult
        '                Case Else
        '                    'ltrBarcodeFull.Text = strResult
        '                    ltrBarcodeISBD.Text = strResult
        '            End Select
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Sub

        Private Function BindHoldingInfor(ByVal strStyle As String) As String
            Dim strResult As String = ""
            Try
                If objBOpacItem.TotalItems > 0 Then
                    'If (UCase(strStyle)) <> "MARC" Then
                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spBarcodeInfo.InnerText
                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"
                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"
                    'strResult &= "<div class='span2'>"
                    'strResult &= "<p class='text-center'>"
                    'strResult &= "<span class='item-title-secondary'>" & objBOpacItem.AvailItems & " / " & objBOpacItem.TotalItems & "</span>"
                    'strResult &= "<br />"
                    'strResult &= spAvailable.InnerText
                    'strResult &= "</p>"
                    'strResult &= "</div>"
                    'strResult &= "<div class='span7'>"
                    'Dim strId As String = objBOpacItem.ItemID
                    'strResult &= objBOpacItem.GetHoldingInfor(Request.QueryString("intSerID"), spFree.InnerText, spBusy.InnerText, spMap.InnerText)
                    'strResult &= "</div>" 'div span7
                    'strResult &= "</div>" 'div grid no-margin
                    'strResult &= "</div>" 'div row
                    'strResult &= "</div>" 'div panel-content
                    'strResult = strResult

                    Dim strMXGReservation As String = ""
                    Dim strItemCheckOut As String = ""
                    Dim strId As String = objBOpacItem.ItemID
                    Dim holdingInfo As String = objBOpacItem.GetHoldingInfor(Request.QueryString("intSerID"), spFree.InnerText, spBusy.InnerText, spMap.InnerText, strMXGReservation, strItemCheckOut)
                    Dim holdingReserve As DataTable = objBResever.GetResereByItemID(CInt(Request("intItemID")))
                    Dim countReserveRequest As Integer = holdingReserve.Rows.Count
                    strResult &= "<div class='div-blank'></div>"
                    strResult &= "<h3 class='HeadStyles'>" & spBarcodeInfo.InnerText & "</h3>"
                    strResult &= "<div class='ClearFix'>"
                    strResult &= "<div class='col-left-2'><div class='txt-center'>"
                    strResult &= "<p>" & spAvailable.InnerText & "</p><span>" & Space(1) & objBOpacItem.AvailItems & " / " & objBOpacItem.TotalItems & "</span>"
                    strResult &= "<div class='div-blank'></div>"
                    strResult &= "<p>" & spSumOnHold.InnerText & "</p><span>" & Space(1) & countReserveRequest & "</span>"
                    strResult &= "</div></div>"
                    strResult &= "<div class='col-right-8'>" & holdingInfo & "</div>"
                    strResult &= "</div>"

                    'Them nut dang ky hoac dat cho
                    Dim strNote As String = ""
                    If Not objBOpacItem.HaveCopy Then
                    Else
                        Dim strButton As String = ""
                        If objBOpacItem.Locked Then
                        Else
                            If objBOpacItem.Avail Then
                                If ((countReserveRequest < objBOpacItem.AvailItems)) Then

                                    Dim arrMXGReservation() As String = strMXGReservation.Split(",")

                                    strButton = "<input type=""button"" class=""btn-icon"" id=""btReservation"" onclick=""onReservation('" & arrMXGReservation(0) & "');return false;"">"
                                    strButton &= "<div class='btn-value'><span class='mif-pin'></span>" & spRegister.InnerText & "</div>"
                                Else
                                    strButton = "<input type=""button"" class=""btn-icon"" id=""btHolding"" onclick=""onHolding('" & objBOpacItem.ItemID & "');return false;"">"
                                    strButton &= "<div class='btn-value'><span class='mif-pin'></span>" & spReservation.InnerText & "</div>"
                                End If

                            Else
                                strButton = "<input type=""button"" class=""btn-icon"" id=""btHolding"" onclick=""onHolding('" & objBOpacItem.ItemID & "');return false;"">"
                                strButton &= "<div class='btn-value'><span class='mif-pin'></span>" & spReservation.InnerText & "</div>"
                            End If
                            strResult &= "<div class='div-blank'></div>"
                            strResult &= "<div class='ClearFix'>"
                            strResult &= "<div class='col-right-8'>"
                            strResult &= "<div class='button-control'>"
                            strResult &= "<div class='button-form'>"
                            strResult &= strButton
                            strResult &= "</div>"
                            strResult &= "</div>"
                            strResult &= "</div>"
                            strResult &= "</div>"
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function


        Private Sub Reservation(ByVal strMXGReservation As String)
            Dim bytRetCode As Integer = 0
            Dim strMsg As String = ""
            Dim strStatus As String = "warning"
            Try
                With objBholdReq
                    .CardNo = clsSession.GlbUser ' Session("PatronCode") & ""
                    .Password = clsSession.GlbPassword ' Session("PatronPass") & ""
                    .ValidDateReq = DateAdd(DateInterval.Day, 1, Date.Today)
                    .CopyNumber = strMXGReservation
                    .ItemID = objBOpacItem.ItemID
                    bytRetCode = objBholdReq.CreateReserv()
                End With
                Select Case bytRetCode
                    Case 0
                        objBholdReq.CreateReserv_Report()
                        strMsg = lblMSG0.Text
                        strStatus = "information"
                    Case 1
                        strMsg = lblMSG1.Text
                    Case 2
                        strMsg = lblMSG2.Text
                    Case 3
                        strMsg = lblMSG3.Text
                    Case 4
                        strMsg = lblMSG4.Text
                    Case 5
                        strMsg = lblMSG5R.Text
                    Case 6
                        strMsg = lblMSG6H.Text
                End Select
                Dim strInfo As String = ""
                strInfo = "parent.showNotify('" & strStatus & "', '" & strMsg & "');"
                Page.RegisterClientScriptBlock("Mess", "<script language = 'javascript'>" & strInfo & "</script>")
            Catch ex As Exception
            End Try
        End Sub

        Private Sub Holding(ByVal strMXGReservation As String)
            Dim bytRetCode As Integer = 0
            Dim strMsg As String = ""
            Dim strStatus As String = "warning"
            Try
                'With objBholdReq
                '    .CardNo = clsSession.GlbUser ' Session("PatronCode") & ""
                '    .Password = clsSession.GlbPassword ' Session("PatronPass") & ""
                '    .ValidDateReq = DateAdd(DateInterval.Day, 1, Date.Today)
                '    .CopyNumber = strMXGReservation
                '    .ItemID = objBOpacItem.ItemID
                '    bytRetCode = objBholdReq.CreateHolding()
                'End With

                With objBResever
                    .ItemID = CInt(strMXGReservation)
                    .PatronCode = clsSession.GlbUser
                    bytRetCode = .InsertReserve()
                End With


                Select Case bytRetCode
                    Case 0
                        objBResever.InsertReserveReport()
                        strMsg = lblMSG0.Text
                        strStatus = "information"
                    Case 1
                        strMsg = lblMSG2.Text
                    Case 2
                        strMsg = lblMSG3.Text
                    Case -1
                        strMsg = "Error"

                        'Case 1
                        '    strMsg = lblMSG1.Text
                        'Case 2
                        '    strMsg = lblMSG2.Text
                        'Case 3
                        '    strMsg = lblMSG3.Text
                        'Case 4
                        '    strMsg = lblMSG4.Text
                        'Case 5
                        '    strMsg = lblMSG5R.Text
                        'Case 6
                        '    strMsg = lblMSG6H.Text
                End Select
                Dim strInfo As String = ""
                strInfo = "parent.showNotify('" & strStatus & "', '" & strMsg & "');"
                Page.RegisterClientScriptBlock("Mess", "<script language = 'javascript'>" & strInfo & "</script>")
            Catch ex As Exception
            End Try
        End Sub

        'Private Sub BindRelationWordInfor(ByVal strStyle As String)
        '    Try
        '        ltrRelationWordFull.Text = ""
        '        ltrRelationWordSimple.Text = ""
        '        ltrRelationWordISBD.Text = ""
        '        ltrRelationWordMARC.Text = ""
        '        Dim tblAccEn As DataTable = Nothing
        '        Dim tblAuthor As New DataTable
        '        objBFilterBrowse.ItemID = objBOpacItem.ItemID
        '        tblAccEn = objBFilterBrowse.getRelatedWords
        '        Dim strResult As String = ""
        '        Dim strAuthor As String = ""
        '        Dim strNLM As String = ""
        '        Dim strDDC As String = ""
        '        Dim strseries As String = ""
        '        Dim strKeyWord As String = ""
        '        Dim strSH As String = ""
        '        If Not IsNothing(tblAccEn) AndAlso tblAccEn.Rows.Count > 0 Then
        '            strResult &= "<div class='panel-header'>"
        '            strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spRelatedWord.InnerText
        '            strResult &= "</div>"
        '            strResult &= "<div class='panel-content'>"
        '            strResult &= "<div class='grid no-margin'>"

        '            Dim intCount As Integer = 0
        '            tblAccEn.DefaultView.RowFilter = "DicType=1" 'Author
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strAuthor <> "" Then
        '                    strAuthor = Left(strAuthor, Len(strAuthor) - 2)
        '                End If

        '                tblAuthor = objBOpacItem.GetAcessEntryAuthor(tblAccEn.DefaultView(0).Item("AccessEntry"))
        '                If tblAuthor.Rows.Count > 0 Then
        '                    strAuthor = strAuthor & " (see also "
        '                    For intCount = 0 To tblAuthor.Rows.Count - 1
        '                        If intCount = 0 Then
        '                            strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</A>"
        '                        Else
        '                            strAuthor = strAuthor & "," & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</A>"
        '                        End If
        '                    Next
        '                    strAuthor = strAuthor & " )"
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span2'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spAuthor.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strAuthor
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            tblAccEn.DefaultView.RowFilter = "DicType=3" 'Keyword
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strKeyWord = strKeyWord & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strKeyWord <> "" Then
        '                    strKeyWord = Left(strKeyWord, Len(strKeyWord) - 2)
        '                End If

        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span2'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spKeyword.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strKeyWord
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If
        '            tblAccEn.DefaultView.RowFilter = "DicType=4" 'Series
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strseries &= "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strseries <> "" Then
        '                    strseries = Left(strseries, Len(strseries) - 2)
        '                End If

        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span2'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spSeries.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strseries
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            tblAccEn.DefaultView.RowFilter = "DicType=5" 'Suject Heading
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strSH = strSH & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strSH <> "" Then
        '                    strSH = Left(strSH, Len(strSH) - 2)
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span2'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spSubjectHeading.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strSH
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If
        '            tblAccEn.DefaultView.RowFilter = "DicType=7" 'NLM
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strNLM = strNLM & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strNLM <> "" Then
        '                    strNLM = Left(strNLM, Len(strNLM) - 2)
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span2'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spNLM.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strNLM
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            tblAccEn.DefaultView.RowFilter = "DicType=8" 'DDC
        '            If tblAccEn.DefaultView.Count > 0 Then
        '                For intCount = 0 To tblAccEn.DefaultView.Count - 1
        '                    strDDC = strDDC & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
        '                Next
        '                If strDDC <> "" Then
        '                    strDDC = Left(strDDC, Len(strDDC) - 2)
        '                End If
        '                strResult &= "<div class='row'>"
        '                strResult &= "<div class='span2'>"
        '                strResult &= "<p>"
        '                strResult &= "<span class='item-title-secondary'>" & spDDC.InnerText & "</span>"
        '                strResult &= "</p>"
        '                strResult &= "</div>"
        '                strResult &= "<div class='span7'>"
        '                strResult &= strDDC
        '                strResult &= "</div>" 'div span7
        '                strResult &= "</div>" 'div row
        '            End If

        '            strResult &= "</div>" 'div grid no-margin
        '            strResult &= "</div>" 'div panel-content
        '            Select Case (UCase(strStyle))
        '                Case "MARC"
        '                    ltrRelationWordMARC.Text = strResult
        '                Case "FULLRECORD"
        '                    ltrRelationWordFull.Text = strResult
        '                Case "ISBD"
        '                    ltrRelationWordISBD.Text = strResult
        '                Case "SIMPLE"
        '                    ltrRelationWordSimple.Text = strResult
        '                Case Else
        '                    'ltrRelationWordFull.Text = strResult
        '                    ltrRelationWordISBD.Text = strResult
        '            End Select
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Sub

        Private Function BindRelationWordInfor(ByVal strStyle As String) As String
            Dim strResult As String = ""
            Try
                Dim tblAccEn As DataTable = Nothing
                Dim tblAuthor As New DataTable
                objBFilterBrowse.ItemID = objBOpacItem.ItemID
                tblAccEn = objBFilterBrowse.getRelatedWords
                Dim strAuthor As String = ""
                Dim strNLM As String = ""
                Dim strDDC As String = ""
                Dim strseries As String = ""
                Dim strKeyWord As String = ""
                Dim strSH As String = ""
                If Not IsNothing(tblAccEn) AndAlso tblAccEn.Rows.Count > 0 Then
                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spRelatedWord.InnerText
                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"
                    'strResult &= "<div class='grid no-margin'>"
                    strResult &= "<div class='div-blank'></div>"
                    strResult &= "<h3 class='HeadStyles'>" & spRelatedWord.InnerText & "</h3>"
                    strResult &= "<div class='ClearFix'>"

                    Dim intCount As Integer = 0
                    tblAccEn.DefaultView.RowFilter = "DicType=1" 'Author
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
                        Next
                        If strAuthor <> "" Then
                            strAuthor = Left(strAuthor, Len(strAuthor) - 2)
                        End If

                        tblAuthor = objBOpacItem.GetAcessEntryAuthor(tblAccEn.DefaultView(0).Item("AccessEntry"))
                        If tblAuthor.Rows.Count > 0 Then
                            strAuthor = strAuthor & " (see also "
                            For intCount = 0 To tblAuthor.Rows.Count - 1
                                If intCount = 0 Then
                                    strAuthor = strAuthor & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</A>"
                                Else
                                    strAuthor = strAuthor & "," & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAuthor.Rows(intCount).Item("DisplayEntry") & "</A>"
                                End If
                            Next
                            strAuthor = strAuthor & " )"
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span2'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spAuthor.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strAuthor
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row

                        strResult &= "<div class='col-left-2'>"
                        strResult &= "<p><span>" & spAuthor.InnerText & "</span></p>"
                        strResult &= "</div>"
                        strResult &= "<div class='col-right-8'>"
                        strResult &= "<p><span>" & strAuthor & "</span></p>"
                        strResult &= "</div>"
                    End If

                    tblAccEn.DefaultView.RowFilter = "DicType=3" 'Keyword
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strKeyWord = strKeyWord & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
                        Next
                        If strKeyWord <> "" Then
                            strKeyWord = Left(strKeyWord, Len(strKeyWord) - 2)
                        End If

                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span2'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spKeyword.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strKeyWord
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<div class='col-left-2'>"
                        strResult &= "<p><span>" & spKeyword.InnerText & "</span></p>"
                        strResult &= "</div>"
                        strResult &= "<div class='col-right-8'>"
                        strResult &= "<p><span>" & strKeyWord & "</span></p>"
                        strResult &= "</div>"
                    End If
                    tblAccEn.DefaultView.RowFilter = "DicType=4" 'Series
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strseries &= "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
                        Next
                        If strseries <> "" Then
                            strseries = Left(strseries, Len(strseries) - 2)
                        End If

                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span2'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spSeries.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strseries
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<div class='col-left-2'>"
                        strResult &= "<p><span>" & spSeries.InnerText & "</span></p>"
                        strResult &= "</div>"
                        strResult &= "<div class='col-right-8'>"
                        strResult &= "<p><span>" & strseries & "</span></p>"
                        strResult &= "</div>"
                    End If

                    tblAccEn.DefaultView.RowFilter = "DicType=5" 'Suject Heading
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strSH = strSH & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
                        Next
                        If strSH <> "" Then
                            strSH = Left(strSH, Len(strSH) - 2)
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span2'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spSubjectHeading.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strSH
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<div class='col-left-2'>"
                        strResult &= "<p><span>" & spSubjectHeading.InnerText & "</span></p>"
                        strResult &= "</div>"
                        strResult &= "<div class='col-right-8'>"
                        strResult &= "<p><span>" & strSH & "</span></p>"
                        strResult &= "</div>"
                    End If
                    tblAccEn.DefaultView.RowFilter = "DicType=7" 'NLM
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strNLM = strNLM & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
                        Next
                        If strNLM <> "" Then
                            strNLM = Left(strNLM, Len(strNLM) - 2)
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span2'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spNLM.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strNLM
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<div class='col-left-2'>"
                        strResult &= "<p><span>" & spNLM.InnerText & "</span></p>"
                        strResult &= "</div>"
                        strResult &= "<div class='col-right-8'>"
                        strResult &= "<p><span>" & strNLM & "</span></p>"
                        strResult &= "</div>"
                    End If

                    tblAccEn.DefaultView.RowFilter = "DicType=8" 'DDC
                    If tblAccEn.DefaultView.Count > 0 Then
                        For intCount = 0 To tblAccEn.DefaultView.Count - 1
                            strDDC = strDDC & "<a style='cursor:pointer;' onclick=""gotoShowRecord(" & tblAccEn.DefaultView(intCount).Item("DicType") & "," & tblAccEn.DefaultView(intCount).Item("ID") & ")"">" & tblAccEn.DefaultView(intCount).Item("DisplayEntry") & "</A>, "
                        Next
                        If strDDC <> "" Then
                            strDDC = Left(strDDC, Len(strDDC) - 2)
                        End If
                        'strResult &= "<div class='row'>"
                        'strResult &= "<div class='span2'>"
                        'strResult &= "<p>"
                        'strResult &= "<span class='item-title-secondary'>" & spDDC.InnerText & "</span>"
                        'strResult &= "</p>"
                        'strResult &= "</div>"
                        'strResult &= "<div class='span7'>"
                        'strResult &= strDDC
                        'strResult &= "</div>" 'div span7
                        'strResult &= "</div>" 'div row
                        strResult &= "<div class='col-left-2'>"
                        strResult &= "<p><span>" & spDDC.InnerText & "</span></p>"
                        strResult &= "</div>"
                        strResult &= "<div class='col-right-8'>"
                        strResult &= "<p><span>" & strDDC & "</span></p>"
                        strResult &= "</div>"
                    End If

                    'strResult &= "</div>" 'div grid no-margin
                    'strResult &= "</div>" 'div panel-content

                    strResult &= "</div>"
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Function getCutVietnameseAccent(ByVal strSearch As String) As String
            Dim strResult As String = ""
            Try
                strResult = objBCommonStringProc.CutVietnameseAccent(strSearch)
            Catch ex As Exception
            End Try
            Return strResult
        End Function


        '' Purpose : Write Holding information
        '' Creator : PhuongTT
        'Private Sub BindCatalogueData(ByVal strStyle As String)
        '    ltrSimple.Text = ""
        '    ltrISBD.Text = ""
        '    ltrFull.Text = ""
        '    lrtMARC.Text = ""
        '    Dim strId As String = objBOpacItem.ItemID
        '    Dim strWord As String = hidWord.Value
        '    strWord = getCutVietnameseAccent(strWord)
        '    Select Case (UCase(strStyle))
        '        Case "MARC"
        '            Dim ArrTitle(1) As String
        '            ArrTitle(0) = ddlLabel.Items(7).Text
        '            ArrTitle(1) = getIcons(strId)
        '            lrtMARC.Text = objBOpacItem.GetRecordByTypeOPAC("MARC", ArrTitle, strWord, Me.getEDataPATH)
        '        Case "ISBD"
        '            Dim ArrTitle(4) As String
        '            ArrTitle(0) = ddlLabel.Items(7).Text
        '            ArrTitle(1) = getIcons(strId)
        '            ArrTitle(2) = ddlLabel.Items(8).Text
        '            ArrTitle(3) = ddlLabel.Items(9).Text
        '            ArrTitle(4) = ddlLabel.Items(10).Text
        '            ltrISBD.Text = objBOpacItem.GetRecordByTypeOPAC("ISBD", ArrTitle, strWord, Me.getEDataPATH)
        '        Case "FULLRECORD"
        '            Dim ArrTitle(28) As String
        '            Dim inti As Integer
        '            For inti = 0 To 27
        '                ArrTitle(inti) = ddlLabel_FullRecord.Items(inti).Text
        '            Next
        '            ArrTitle(28) = getIcons(strId)
        '            ltrFull.Text = objBOpacItem.GetRecordByTypeOPAC("FULLRECORD", ArrTitle, strWord, Me.getEDataPATH)
        '        Case "SIMPLE"
        '            Dim ArrTitle(11) As String
        '            Dim inti As Integer
        '            For inti = 0 To 10
        '                ArrTitle(inti) = ddlLabel.Items(inti).Text
        '            Next
        '            ArrTitle(11) = getIcons(strId)
        '            ltrSimple.Text = objBOpacItem.GetRecordByTypeOPAC("BRIEFRECORD", ArrTitle, strWord, Me.getEDataPATH)
        '        Case "RELATION"
        '            'Lay tai lieu lien quan: 1:Author, 3:KeyWord, 5 'Subjectheading,2 'publisher,  7 'NLM,4 'Series,6 'Language,8 'DDC, 9:DDC 
        '            Dim DicID As Integer = clsSession.GlbClassification '9 'DDC
        '            Dim strAccessEntry As String = ""
        '            Call getRelation(DicID, strAccessEntry, objBOpacItem.ItemID)
        '        Case Else
        '            'Dim ArrTitle(28) As String
        '            'Dim inti As Integer
        '            'For inti = 0 To 27
        '            '    ArrTitle(inti) = ddlLabel_FullRecord.Items(inti).Text
        '            'Next
        '            'ArrTitle(28) = getIcons(strId)
        '            'ltrFull.Text = objBOpacItem.GetRecordByTypeOPAC("FULLRECORD", ArrTitle, strWord, Me.getEDataPATH)
        '            Dim ArrTitle(4) As String
        '            ArrTitle(0) = ddlLabel.Items(7).Text
        '            ArrTitle(1) = getIcons(strId)
        '            ArrTitle(2) = ddlLabel.Items(8).Text
        '            ArrTitle(3) = ddlLabel.Items(9).Text
        '            ArrTitle(4) = ddlLabel.Items(10).Text
        '            ltrISBD.Text = objBOpacItem.GetRecordByTypeOPAC("ISBD", ArrTitle, strWord, Me.getEDataPATH)
        '    End Select
        '    'Thong tin xep gia
        '    Call BindHoldingInfor(strStyle)
        '    'Thong tin an pham dinh ky
        '    Call BindSerialInfor(strStyle)
        '    'Thong tin muc tu truy cap
        '    Call BindRelationWordInfor(strStyle)
        'End Sub


        ' Purpose : Write Holding information
        ' Creator : PhuongTT
        Private Sub BindCatalogueData(ByVal strStyle As String)
            Dim strId As String = objBOpacItem.ItemID
            Dim strWord As String = hidWord.Value
            strWord = getCutVietnameseAccent(strWord)

            Dim inti As Integer = 0
            'FULLRECORD
            Dim ArrTitleFull(29) As String
            For inti = 0 To 28
                ArrTitleFull(inti) = ddlLabel_FullRecord.Items(inti).Text
            Next
            ArrTitleFull(29) = getIcons(strId)
            ltrViewFull.Text = objBOpacItem.GetRecordByTypeOPAC_SSC("FULLRECORD", ArrTitleFull, strWord, Me.getEDataPATH, clsSession.GlbUser)

            'MARC
            Dim ArrTitleMARC(1) As String
            ArrTitleMARC(0) = ddlLabel.Items(7).Text
            ArrTitleMARC(1) = getIcons(strId)
            ltrViewMARC.Text = objBOpacItem.GetRecordByTypeOPAC_SSC("MARC", ArrTitleMARC, strWord, Me.getEDataPATH)

            'ISBD
            Dim ArrTitleISBN(4) As String
            ArrTitleISBN(0) = ddlLabel.Items(7).Text
            ArrTitleISBN(1) = getIcons(strId)
            ArrTitleISBN(2) = ddlLabel.Items(8).Text
            ArrTitleISBN(3) = ddlLabel.Items(9).Text
            ArrTitleISBN(4) = ddlLabel.Items(10).Text
            ltrViewISBD.Text = objBOpacItem.GetRecordByTypeOPAC_SSC("ISBD", ArrTitleISBN, strWord, Me.getEDataPATH)

            'Cataloger
            Dim ArrTitleCataloger(1) As String
            ArrTitleCataloger(0) = ddlLabel.Items(11).Text
            ArrTitleCataloger(1) = getIcons(strId)
            ltrViewCataloger.Text = objBOpacItem.GetRecordByTypeOPAC_SSC("CATALOGER", ArrTitleCataloger, strWord, Me.getCatalogerPATH)

            ''SIMPLE
            'Dim ArrTitleSimple(11) As String
            'For inti = 0 To 10
            '    ArrTitleSimple(inti) = ddlLabel.Items(inti).Text
            'Next
            'ArrTitleSimple(11) = getIcons(strId)
            'ltrViewSimple.Text = objBOpacItem.GetRecordByTypeOPAC_SSC("BRIEFRECORD", ArrTitleSimple, strWord, Me.getEDataPATH)

            'Thong tin xep gia
            Dim strHoldingInfo As String = ""
            strHoldingInfo = BindHoldingInfor(strStyle)
            'Thong tin an pham dinh ky
            Dim strSerialInfo As String = ""
            strSerialInfo = BindSerialInfor(strStyle)
            'Thong tin muc tu truy cap
            Dim strRelationWordInfor As String = ""
            strRelationWordInfor = BindRelationWordInfor(strStyle)

            ltrViewFull.Text &= strHoldingInfo & strSerialInfo & strRelationWordInfor
            ltrViewMARC.Text &= strHoldingInfo & strSerialInfo & strRelationWordInfor
            ltrViewISBD.Text &= strHoldingInfo & strSerialInfo & strRelationWordInfor
            'ltrViewSimple.Text &= strHoldingInfo & strSerialInfo & strRelationWordInfor


            ''RELATION
            ''Lay tai lieu lien quan: 1:Author, 3:KeyWord, 5 'Subjectheading,2 'publisher,  7 'NLM,4 'Series,6 'Language,8 'DDC, 9:DDC 
            'Dim DicID As Integer = clsSession.GlbClassification '9 'DDC
            'Dim strAccessEntry As String = ""
            'Call getRelation(DicID, strAccessEntry, objBOpacItem.ItemID)
        End Sub

        ' Purpose : Write Serial information
        ' Creator : lent
        'Private Sub BindSerialInfor(ByVal strStyle)
        '    Try
        '        Dim strInfo As String = objBOpacItem.GetSerHolding
        '        ltrMagazineSimple.Text = ""
        '        ltrMagazineISBD.Text = ""
        '        ltrMagazineFull.Text = ""
        '        ltrMagazineMARC.Text = ""
        '        If strInfo <> "" AndAlso strInfo <> "NOINFOR" Then
        '            Dim strResult As String = ""
        '            strResult &= "<div class='panel-header'>"
        '            strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spMagazineInfo.InnerText
        '            strResult &= "</div>"
        '            strResult &= "<div class='panel-content'>"
        '            strResult &= "<div class='grid no-margin'>"
        '            strResult &= "<div class='row'>"
        '            strResult &= "<div class='span10'>"
        '            strResult &= "<span class='line-height'>" & strInfo & "</span>"
        '            strResult &= "</div>" 'div span10
        '            strResult &= "</div>" 'div grid no-margin
        '            strResult &= "</div>" 'div row
        '            strResult &= "</div>" 'div panel-content
        '            Select Case (UCase(strStyle))
        '                Case "MARC"
        '                    ltrMagazineMARC.Text = strResult
        '                Case "FULLRECORD"
        '                    ltrMagazineFull.Text = strResult
        '                Case "ISBD"
        '                    ltrMagazineISBD.Text = strResult
        '                Case "SIMPLE"
        '                    ltrMagazineSimple.Text = strResult
        '                Case Else
        '                    ltrMagazineFull.Text = strResult
        '                    ltrMagazineISBD.Text = strResult
        '            End Select
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Sub


        ' Purpose : Write Serial information
        ' Creator : lent
        Private Function BindSerialInfor(ByVal strStyle) As String
            Dim strResult As String = ""
            Try
                Dim strInfo As String = objBOpacItem.GetSerHolding
                If strInfo <> "" AndAlso strInfo <> "NOINFOR" Then
                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<span class='icon-info-2'>&nbsp;</span>" & spMagazineInfo.InnerText
                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"
                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"
                    'strResult &= "<div class='span10'>"
                    'strResult &= "<span class='line-height'>" & strInfo & "</span>"
                    'strResult &= "</div>" 'div span10
                    'strResult &= "</div>" 'div grid no-margin
                    'strResult &= "</div>" 'div row
                    'strResult &= "</div>" 'div panel-content

                    strResult &= "<div class='div-blank'></div>"
                    strResult &= "<h3 class='HeadStyles'>" & spMagazineInfo.InnerText & "</h3>"
                    strResult &= "<div class='ClearFix'>"
                    strResult &= "<p><span>" & objBOpacItem.AvailItems & " / " & objBOpacItem.TotalItems & "</span></p>"
                    strResult &= "</div>"
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' filterInBrowse method
        ' Purpose: filter information for browse
        Private Sub getRelation(ByVal intDicType As Integer, ByVal strAccessEntry As String, ByVal intItemID As Integer)
            Try
                Dim dtIds As DataTable
                With objBOPACDictionary
                    .DicType = clsSession.GlbClassification 'intDicType
                    .AccessEntry = strAccessEntry
                    dtIds = .getItemFromDictionaryAccessEntry(intItemID, clsSession.GlbSite)
                End With
                If Not IsNothing(dtIds) AndAlso dtIds.Rows.Count > 0 Then
                    Dim strIDs As String = ""
                    For i As Integer = 0 To dtIds.Rows.Count - 1
                        strIDs = strIDs & dtIds.Rows(i).Item("ItemID") & ","
                    Next
                    If strIDs <> "" Then
                        strIDs = Left(strIDs, Len(strIDs) - 1)
                    End If
                    objBSearchResult.ItemIDs = strIDs
                    Dim arrField() As String = {"022", "100", "110", "245", "250", "260", "300", "490", "700", "710", "773", "856"}
                    Dim tblTmp As New DataTable
                    tblTmp = objBSearchResult.GetItemResultsByFields(arrField)
                    Call showBooks(tblTmp, strIDs, 1, 10)
                Else
                    'ltrRelation.Text = spRelationNone.InnerText
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show books
        ' Creator: phuongtt
        Private Sub showBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intCurPage As Integer, ByVal intRecPerPage As Integer, Optional ByVal intDic As Integer = 8)
            Dim strTitle As String ' thong tin nhan de chinh
            Dim strDesPhy As String ' thong tin mo ta vat ly
            Dim strPublish As String ' thong tin xuat ban
            Dim strCover As String ' thong tin bia tai lieu
            Dim strAuthor As String ' thong tin tac gia
            Dim strISSN As String ' thong tin ISSN
            Dim strURL As String ' thong tin URL
            Dim strEDATA As String ' thong tin du lieu dien tu
            Dim strEMAGAZINE As String = ""
            Dim strRANKING As String ' thong tin xep hang
            Dim strType As String ' thong tin loai tai lieu
            Dim intCount As Integer
            Dim arrIDs() As String
            Dim rowView As DataRowView

            If tblData Is Nothing Then
                Exit Sub
            End If
            arrIDs = Split(strIDs, ",")
            Dim strResult As String = ""
            If tblData.Rows.Count > 0 Then


                For intCount = 0 To UBound(arrIDs)

                    strTitle = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                    If tblData.DefaultView.Count > 0 Then
                        strTitle = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    strTitle = (intRecPerPage * (intCurPage - 1)) + intCount + 1 & ". " & strTitle

                    ' get description physical
                    strDesPhy = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='300'"
                    If tblData.DefaultView.Count > 0 Then
                        strDesPhy = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    ' get publish information
                    strPublish = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='260'"
                    If tblData.DefaultView.Count > 0 Then
                        strPublish = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    ' get ISSN information
                    strISSN = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='022'"
                    If tblData.DefaultView.Count > 0 Then
                        strISSN = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'get author info
                    strAuthor = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='100'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='110'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='700'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='710'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            strAuthor &= rowView.Item("Content") & "; "
                        End If
                    Next
                    strAuthor = strAuthor.Trim
                    If Not strAuthor = "" Then
                        strAuthor = strAuthor.Substring(0, strAuthor.Length - 1)
                    End If

                    strURL = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='856'"
                    For Each rowView In tblData.DefaultView
                        If Not IsDBNull(rowView.Item("Content")) Then
                            If InStr(rowView.Item("Content"), "http://") > 0 Then
                                strURL &= "<a href='" & rowView.Item("Content") & "' target='_blank' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                            End If
                        End If
                    Next
                    strURL = strURL.Trim
                    If strURL <> "" Then
                        strURL = strURL.Substring(0, strURL.Length - 1)
                        'Bo span danh dau highlight cac truong 0xx --> 9xx
                        strURL = Replace(strURL, "<span class=""hightlight-text""></span>", "")
                    End If

                    'Du lieu dien tu
                    strEDATA = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EDATA'"
                    If tblData.DefaultView.Count > 0 Then
                        strEDATA = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Du lieu bao in/tap chi dien tu
                    strEMAGAZINE = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EMAGAZINE'"
                    If tblData.DefaultView.Count > 0 Then
                        strEMAGAZINE = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Ranking 
                    strRANKING = "2"
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='RANKING'"
                    If tblData.DefaultView.Count > 0 Then
                        strRANKING = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    'Loai tai lieu
                    strType = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='ETYPE'"
                    If tblData.DefaultView.Count > 0 Then
                        strType = tblData.DefaultView(0).Item("Content") & ""
                    End If

                    strResult &= "<div class='panel-header'>"
                    strResult &= "<a onclick='viewDetail(" & arrIDs(intCount) & ")' style='cursor:pointer;'>" & strTitle & "</a> "
                    strResult &= getIcons(arrIDs(intCount))
                    strResult &= "</div>"
                    strResult &= "<div class='panel-content'>"

                    strResult &= "<div class='grid no-margin'>"
                    strResult &= "<div class='row'>"

                    strResult &= "<div class='span2'>"
                    ' strResult &= "<div class='notice  marker-on-right'>"
                    'Anh Bia
                    strResult &= "<div>"
                    strCover = ""
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                    If tblData.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                            strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                        Else
                            strCover = "Images/Imgviet/Books.png"
                        End If
                    End If
                    strResult &= "<img src='" & strCover & "' class='rounded' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "' style='z-index:1001;cursor:pointer;' onclick='viewDetail(" & arrIDs(intCount) & ")'>"
                    strResult &= "</div>"
                    'strResult &= "</div>"
                    strResult &= "</div>"

                    strResult &= "<div class='span8'>"
                    'Thong tin ISSN
                    If strISSN <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spISSN.InnerText & ":</strong> " & strISSN
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If

                    'Thong tin tac gia
                    If strAuthor <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spAuthor.InnerText & ":</strong> " & strAuthor
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If
                    'Thong tin mo ta vat ly
                    If strDesPhy <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spPhysicalInfo.InnerText & ":</strong> " & strDesPhy
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If
                    'Thong tin xuat ban
                    If strPublish <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spPublisherInfo.InnerText & ":</strong> " & strPublish
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If

                    'Loai tai lieu
                    If strType <> "" Then
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spItemType.InnerText & ":</strong> " & strType
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If

                    'Du lieu dien tu
                    If strEDATA <> "" Then
                        Dim strArr() As String = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            strResult &= "<br/>"
                            strResult &= "<span class='line-height'>"
                            strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'   TARGET='_parent'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            strResult &= "</span>"
                            strResult &= "<br/>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    If strEMAGAZINE <> "" Then
                        strResult &= "<br/>"
                        strResult &= "<span class='line-height'>"
                        strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OMagList.aspx?ItemId=" & arrIDs(intCount) & "'>" & strEMAGAZINE & spEDATAContent.InnerText & "</a>"
                        strResult &= "</span>"
                        strResult &= "<br/>"
                    End If

                    'Ranking
                    If strRANKING <> "" Then
                        strResult &= "<br/>"
                        strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;' >"
                        strResult &= "</div>"
                    End If

                    strResult &= "</div>" 'div span10
                    strResult &= "</div>" 'div grid no-margin
                    strResult &= "</div>" 'div row
                    strResult &= "</div>" 'div panel-content
                Next
                'ltrRelation.Text = strResult
            End If
        End Sub

        Private Sub BindEData()
            Try
                'Dim tblEData As New DataTable
                'tblEData = objBOpacItem.GetEData
                'If Not tblEData Is Nothing AndAlso tblEData.Rows.Count > 0 Then
                '    For intCount As Integer = 0 To tblEData.Rows.Count - 1

                '    Next
                'End If
            Catch ex As Exception

            End Try
        End Sub

        '' Dispose method
        '' Purpose: get icon and set to header panel
        'Private Function getIcons(ByVal iTem As Integer) As String
        '    Dim strResult As String = ""
        '    Try
        '        Dim strId As String = iTem & ","
        '        If InStr(clsSession.GlbMyListIds, strId) > 0 Then
        '            strResult = "<a class='element place-right' onclick='#'><span class='icon-checkmark' id='icon" & iTem & "' data-hint='|" & spInMyList.InnerText & "' data-hint-position='left'></span></a>"
        '        Else
        '            strResult = "<a class='element place-right' onclick='addMyList(" & iTem.ToString & ")'><span class='icon-plus' id='icon" & iTem & "' style='cursor:pointer;' data-hint='|" & spAddToMyList.InnerText & "' data-hint-position='left'></span></a>"
        '        End If
        '    Catch ex As Exception
        '    End Try
        '    Return strResult
        'End Function

        ' Dispose method
        ' Purpose: get icon and set to header panel
        Private Function getIcons(ByVal iTem As Integer) As String
            Dim strResult As String = ""
            'Try
            '    Dim strId As String = iTem & ","
            '    If InStr(clsSession.GlbMyListIds, strId) > 0 Then
            '        'strResult = "<a class='element place-right' onclick='#'><span class='icon-checkmark' id='icon" & iTem & "' data-hint='|" & spInMyList.InnerText & "' data-hint-position='top'></span></a>"
            '        strResult = "<h3 class=""uncheck"" id=""h" & iTem & """><a onclick='checkMyList(" & iTem.ToString & ")' style=""cursor:pointer;""><span class=""mif-heart-broken"" id=""icon" & iTem & """></span><span id=""spCart" & iTem & """>" & spCancelList.InnerText & "</span></a></h3>"
            '    Else
            '        strResult = "<h3 id=""h" & iTem & """><a onclick='checkMyList(" & iTem.ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & iTem & """></span><span id=""spCart" & iTem & """>" & spSaveList.InnerText & "</span></a></h3>"
            '        'strResult = "<a class='element place-right' onclick='addMyList(" & iTem.ToString & ")'><span class='icon-plus' id='icon" & iTem & "' style='cursor:pointer;' data-hint='|" & spAddToMyList.InnerText & "' data-hint-position='top'></span></a>"
            '    End If
            'Catch ex As Exception
            'End Try
            Return strResult
        End Function

        ' raiseView_Click method
        ' Purpose: view url or detail record
        Private Sub raiseView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseView.Click
            Try
                Call BindCatalogueData(hidView.Value)
                Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>setTab('" & hidView.Value & "')</script>")
            Catch ex As Exception
            End Try
        End Sub


        Private Sub raiseReservation_Click(sender As Object, e As EventArgs) Handles raiseReservation.Click
            Try
                Dim strCopyNumber As String = hidCopynumber.Value
                Call Reservation(strCopyNumber)
                Call BindCatalogueData("")
            Catch ex As Exception
            End Try
        End Sub

        Private Sub raiseHolding_Click(sender As Object, e As EventArgs) Handles raiseHolding.Click
            Try
                Dim strCopyNumber As String = hidCopynumber.Value
                Dim strItemID As String = hidItemID.Value
                'Call Holding(strCopyNumber)
                Call Holding(strItemID)
            Catch ex As Exception

            End Try
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACFile Is Nothing Then
                    objBOPACFile.Dispose(True)
                    objBOPACFile = Nothing
                End If
                If Not objBOpacItem Is Nothing Then
                    objBOpacItem.Dispose(True)
                    objBOpacItem = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBOPACDictionary Is Nothing Then
                    objBOPACDictionary.Dispose(True)
                    objBOPACDictionary = Nothing
                End If
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
                If Not objBFilterBrowse Is Nothing Then
                    objBFilterBrowse.Dispose(True)
                    objBFilterBrowse = Nothing
                End If
                If Not objBResever Is Nothing Then
                    objBResever.Dispose(True)
                    objBResever = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace
