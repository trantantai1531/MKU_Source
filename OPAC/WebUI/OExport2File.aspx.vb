Imports Aspose.Words
Imports System.IO
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Collections.Generic


Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OExport2File
        Inherits System.Web.UI.Page

        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBSearchQr As New clsBOPACSearchQuery
        Private fIntTotal As Integer = 0

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Dim intOrderBy As Integer = 1
                Dim intType As Integer = 1
                If Not IsNothing(Request("intType")) AndAlso IsNumeric(Request("intType")) Then
                    intType = CInt(Request("intType"))
                Else
                    intType = 1
                End If
                Dim strSort As String = ""
                Select Case intOrderBy
                    Case 1
                        strSort = "TITLE"
                    Case 2
                        strSort = "AUTHOR"
                    Case 3
                        strSort = "MXG"
                End Select
                Dim strIds As String = objBCommonStringProc.getIdsSring(clsSession.GlbMyListIds)
                Dim strList As String = resortListIds(strIds, strSort)
                Call processBooks(strList, intOrderBy, intType)
            End If
        End Sub


        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            ' init objBSearchQr object
            objBSearchQr.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchQr.DBServer = Session("DBServer")
            objBSearchQr.ConnectionString = Session("ConnectionString")
            objBSearchQr.Initialize()

            ' init objBSearchResult object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

        End Sub

        ' resortListIds method
        ' Purpose: resort by fields
        Private Function resortListIds(ByVal Ids As String, ByVal strSortby As String) As String
            Dim strListIds As String = ""
            Try
                Dim dtListIds As DataTable = Nothing
                objBSearchQr.SortBy = strSortby
                Dim strSQL As String = objBSearchQr.sortByListIds(Ids)
                dtListIds = objBSearchQr.eExecuteQuerySQL(strSQL)
                strListIds = objBCommonStringProc.getiTemString(dtListIds)
            Catch ex As Exception
            End Try
            Return strListIds
        End Function

        ' purpose :  show books by list of ids document
        ' Creator: phuongtt
        Private Sub processBooks(ByVal strIds As String, ByVal intOrderBy As Integer, ByVal intType As Integer)
            Try
                If strIds.Trim <> "" Then
                    strIds = objBCommonStringProc.getIdsSring(strIds)
                    objBSearchResult.ItemIDs = strIds
                    Dim arrField() As String = {"022", "100", "245", "250", "260", "300", "490", "700", "773"}
                    Dim strSort As String = ""
                    Select Case intOrderBy
                        Case 1
                            strSort = ""
                        Case 2
                        Case 3
                        Case 4
                    End Select
                    Dim tblTmp As New DataTable
                    tblTmp = objBSearchResult.GetItemResultsByFields(arrField, True)
                    Dim strBook As String = getBooks(tblTmp, strIds, intOrderBy)
                    Call export2File(strBook, intType)
                Else
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show books
        ' Creator: phuongtt
        Private Function getBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intOrderBy As Integer) As String
            Dim strResult As String = ""
            Try
                Dim strTitle As String = ""
                Dim str100 As String = ""
                Dim str022 As String = ""
                Dim str700 As String = ""
                Dim str773 As String = ""
                Dim str260_300 As String = ""
                Dim intCount As Integer
                Dim arrIDs() As String
                Dim strCover As String = ""
                Dim intJ As Integer = 0
                arrIDs = Split(strIDs, ",")
                fIntTotal = UBound(arrIDs)
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                    strResult = "<TABLE WIDTH='100%' BORDER = '0px'  cellpadding='2px' cellspacing='2px'>"
                    strResult &= "<TR VALIGN='Top'><TD colspan='2'>&nbsp;</TD></TR>"
                    If tblData.Rows.Count > 0 Then
                        For intCount = 0 To fIntTotal
                            strResult &= "<TR VALIGN='Top'>"

                            'GetHolding
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='MXG'"
                            If tblData.DefaultView.Count > 0 Then
                                strResult &= "<TD style='width:10%;'>" & tblData.DefaultView(intJ).Item("Content") & "</TD>"
                            Else
                                strResult &= "<TD style='width:10%;'>&nbsp;</TD>"
                            End If

                            strResult &= "<TD style='width:90%;'>"

                            strTitle = ""
                            str260_300 = ""
                            str773 = ""
                            '022
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='022')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str022 = str022 & tblData.DefaultView(intJ).Item("Content")
                            Next
                            '100
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='100'"
                            If tblData.DefaultView.Count > 0 Then
                                str100 = tblData.DefaultView(0).Item("Content") & ""
                            End If
                            '245
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                            If tblData.DefaultView.Count > 0 Then
                                strTitle = "<b>" & (intCount + 1).ToString & ". " & "</b>" & tblData.DefaultView(0).Item("Content") & ""
                            End If
                            '250
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='250')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                            Next
                            '260
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='260')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                            Next
                            '300
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='300')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                            Next
                            '490
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='490')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & "( " & tblData.DefaultView(intJ).Item("Content") & " )" & ". - "
                            Next
                            '700
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='700')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content")
                            Next
                            '773
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='773')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str773 = str773 & " //" & tblData.DefaultView(intJ).Item("Content")
                            Next
                            strResult &= "<u>" & strTitle & "</u> . - " & str260_300 & str773
                            strResult &= "</TD></TR>"
                            strResult &= "<TR VALIGN='Top'><TD colspan='2'>&nbsp;</TD></TR>"

                            Call BindPrg(intCount, fIntTotal)
                        Next
                        strResult &= "</TABLE>"
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Sub export2File(ByVal strContent As String, Optional ByVal intType As Integer = 1)
            Try
                Dim strFile As String = ""
                Dim applicationPath As String = Server.MapPath("~")
                If Not applicationPath.EndsWith("\") Then
                    applicationPath = applicationPath + "\"
                End If

                Dim licenseFile As String = Path.Combine(applicationPath, "bin\Aspose.Words.lic")
                If (File.Exists(licenseFile)) Then
                    Dim license As Aspose.Words.License = New Aspose.Words.License()
                    license.SetLicense(licenseFile)
                    Dim strDocFile As String = applicationPath & "Template\documentList.doc"
                    Dim doc As Aspose.Words.Document = New Aspose.Words.Document(strDocFile)
                    Dim builder As DocumentBuilder = New DocumentBuilder(doc)
                    builder.MoveToMergeField("HTMLValue")

                    builder.InsertHtml("<span style='font-size:10pt; font-family:Arial;text-align:justify;'>" & strContent & "</span>")
                    strFile = applicationPath & "Template\outTemplate"
                    If Not Directory.Exists(strFile) Then
                        Directory.CreateDirectory(strFile)
                    End If
                    If Not strFile.EndsWith("\") Then
                        strFile = strFile + "\"
                    End If
                    If intType = 1 Then 'Word
                        strFile &= Format(Now, "yyyyMMddhhmmssfff") & ".doc"
                        doc.Save(strFile, Aspose.Words.SaveFormat.Doc)
                    Else 'Pdf
                        strFile &= Format(Now, "yyyyMMddhhmmssfff") & ".pdf"
                        doc.Save(strFile, Aspose.Words.SaveFormat.Pdf)
                    End If
                    If Not IsNothing(doc) Then
                        doc = Nothing
                    End If
                    Response.Write("<script language='javascript'>spnlbProcessing.innerHTML ='" & span_pecent_finish.InnerText & "';</script>")
                    lblResult.Text = ""
                    lblResult.Text &= span_result_choose.InnerText & Space(1) & (fIntTotal + 1).ToString & "<br/>"
                    lnkLink.NavigateUrl = "#"
                    lnkLink.Attributes.Add("OnClick", "self.location.href='OSaveFile.aspx?FileName=" & Replace(strFile, "\", "\\") & "';return false;")
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            If intCurrentPercent > 100 Then
                intCurrentPercent = 100
            End If
            System.Threading.Thread.Sleep(50 / intSum)
            Response.Write("<script language='javascript'>spnProgess.width =" & intCurrentPercent & " + '%'; spnPecent.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBSearchQr Is Nothing Then
                    objBSearchQr.Dispose(True)
                    objBSearchQr = Nothing
                End If
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
