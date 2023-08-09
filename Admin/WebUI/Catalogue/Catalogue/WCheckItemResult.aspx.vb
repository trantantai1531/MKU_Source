' WCheckItemResult class
' Purpose: show detail informations of all existing items
' Creator: Oanhtn
' CreatedDate: 24/05/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCheckItemResult
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            Call ShowTableResult()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        Private Sub ShowTableResult()
            Dim tblMainInfor As New DataTable
            Dim tblDetailInfor As New DataTable
            Dim intCounter As Integer
            Dim intRowCount As Integer
            Dim lngItemID As Long
            Dim tblRow As TableRow
            Dim dtrows() As DataRow
            Dim tblCell As TableCell
            Dim strIndicators As String
            Dim strFieldCode As String
            Dim strContent As String

            objBItemCollection.ItemIDs = Request("ItemIDs")
            ' lblLabel4
            tblMainInfor = objBItemCollection.GetItemMainInfor

            tblDetailInfor = objBItemCollection.GetItemDetailInfor
            If tblMainInfor.Rows.Count > 0 Then
                'Title
                tblRow = New TableRow
                tblCell = New TableCell

                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.ColumnSpan = 3
                tblCell.Controls.Add(New LiteralControl(lblLabel1.Text))
                tblCell.CssClass = "main-group-form"
                tblRow.Cells.Add(tblCell)

                tblResult.Rows.Add(tblRow)

                For intCounter = 0 To tblMainInfor.Rows.Count - 1
                    lngItemID = tblMainInfor.Rows(intCounter).Item("ItemID")

                    'Show main details infor
                    tblRow = New TableRow

                    'Tên trường
                    tblRow = New TableRow
                    'Tên trường cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl("Tên trường"))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(""))
                    tblRow.Cells.Add(tblCell)
                    'Tên trường cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl("Nội dụng trường"))
                    tblRow.Cells.Add(tblCell)
                    'add row
                    tblRow.CssClass = "lbGridHeader"
                    tblResult.Rows.Add(tblRow)

                    'Ldr row
                    tblRow = New TableRow
                    'Ldr cell
                    tblCell = New TableCell
                    tblCell.Width = System.Web.UI.WebControls.Unit.Percentage(5)
                    tblCell.Controls.Add(New LiteralControl("Ldr"))
                    tblRow.CssClass = "lbLabel"
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Width = System.Web.UI.WebControls.Unit.Percentage(3)
                    tblCell.Controls.Add(New LiteralControl(""))
                    tblRow.Cells.Add(tblCell)
                    'Leader data cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("Leader")))
                    tblRow.Cells.Add(tblCell)
                    'add row
                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)

                    '001
                    tblRow = New TableRow
                    '001 cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl("001"))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(""))
                    tblRow.Cells.Add(tblCell)
                    'Code cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("Code")))
                    tblRow.Cells.Add(tblCell)
                    'add row
                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)

                    'Filter now
                    dtrows = tblDetailInfor.Select("ItemID = " & lngItemID)
                    If dtrows.Length > 0 Then
                        For intRowCount = 0 To dtrows.Length - 1
                            strIndicators = ""
                            If Not IsDBNull(dtrows(intRowCount).Item("Ind1")) Then
                                strIndicators = dtrows(intRowCount).Item("Ind1")
                            Else
                                strIndicators = " "
                            End If
                            If Not IsDBNull(dtrows(intRowCount).Item("Ind2")) Then
                                strIndicators = strIndicators & dtrows(intRowCount).Item("Ind2")
                            Else
                                strIndicators = strIndicators & " "
                            End If
                            strIndicators = Replace(strIndicators, " ", "##")
                            strContent = dtrows(intRowCount).Item("Content")
                            strFieldCode = dtrows(intRowCount).Item("FieldCode")
                            If InStr(Request("FieldCode"), strFieldCode) > 0 Then
                                strFieldCode = "<B>" & strFieldCode & "</B>"
                            End If
                            tblRow = New TableRow
                            'strFieldCode cell
                            tblCell = New TableCell
                            tblCell.Controls.Add(New LiteralControl(strFieldCode))
                            tblRow.Cells.Add(tblCell)
                            'strIndicators cell
                            tblCell = New TableCell
                            tblCell.Controls.Add(New LiteralControl(strIndicators))
                            tblRow.Cells.Add(tblCell)
                            'strContent cell
                            tblCell = New TableCell
                            tblCell.Controls.Add(New LiteralControl(strContent))
                            tblRow.Cells.Add(tblCell)
                            'add row
                            tblRow.CssClass = "lbLabel"
                            tblResult.Rows.Add(tblRow)
                        Next
                    End If

                    'Show main detail infor (continue)
                    'New Record 
                    tblRow = New TableRow
                    '900 cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl("900"))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(""))
                    tblRow.Cells.Add(tblCell)
                    'NewRecord cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("NewRecord")))
                    tblRow.Cells.Add(tblCell)
                    'add row
                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)
                    'CoverPicture
                    If Not IsDBNull(tblMainInfor.Rows(intCounter).Item("CoverPicture")) Then
                        tblRow = New TableRow
                        '907 cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl("907"))
                        tblRow.Cells.Add(tblCell)
                        'blank cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)
                        'CoverPicture cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("CoverPicture")))
                        tblRow.Cells.Add(tblCell)
                        'add row
                        tblRow.CssClass = "lbLabel"
                        tblResult.Rows.Add(tblRow)
                    End If

                    ' Cataloguer
                    If Not IsDBNull(tblMainInfor.Rows(intCounter).Item("Cataloguer")) Then
                        tblRow = New TableRow
                        '911
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl("911"))
                        tblRow.Cells.Add(tblCell)
                        'blank cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)
                        'Cataloguer cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("Cataloguer")))
                        tblRow.Cells.Add(tblCell)
                        'add row
                        tblRow.CssClass = "lbLabel"
                        tblResult.Rows.Add(tblRow)
                    End If

                    ' Reviewer
                    If Not IsDBNull(tblMainInfor.Rows(intCounter).Item("Reviewer")) Then
                        tblRow = New TableRow
                        '912 cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl("912"))
                        tblRow.Cells.Add(tblCell)
                        'blank cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)
                        'Reviewer cell
                        tblCell = New TableCell
                        tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("Reviewer")))
                        tblRow.Cells.Add(tblCell)
                        'add row
                        tblRow.CssClass = "lbLabel"
                        tblResult.Rows.Add(tblRow)
                    End If

                    ' MediumCode
                    tblRow = New TableRow
                    '925 cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl("925"))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(""))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("MediumCode")))
                    tblRow.Cells.Add(tblCell)
                    'add row
                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)

                    ' AccessLevel
                    tblRow = New TableRow
                    '926 cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl("925"))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(""))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("AccessLevel")))
                    tblRow.Cells.Add(tblCell)
                    'add row
                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)

                    ' TypeCode
                    tblRow = New TableRow
                    '927 cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl("927"))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(""))
                    tblRow.Cells.Add(tblCell)
                    'blank cell
                    tblCell = New TableCell
                    tblCell.Controls.Add(New LiteralControl(tblMainInfor.Rows(intCounter).Item("TypeCode")))
                    tblRow.Cells.Add(tblCell)
                    'add row
                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)

                    ' Show 2 action buttons
                    tblRow = New TableRow
                    tblCell = New TableCell
                    tblCell.ColumnSpan = 3
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblCell.Controls.Add(New LiteralControl("<input type=""button"" value=""" & lblLabel3.Text & """ class=""lbButton"" onClick=""opener.top.main.Sentform.location.href='WCataModify.aspx?Clone=0&ItemID=" & lngItemID & "'; self.close()"">"))
                    tblCell.Controls.Add(New LiteralControl("<input type=""button"" value=""" & lblLabel2.Text & """ class=""lbButton"" onClick=""opener.top.main.Sentform.location.href='WCataModify.aspx?Clone=1&ItemID=" & lngItemID & "'; self.close()"">"))
                    tblRow.Cells.Add(tblCell)
                    'addrow
                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)

                    If intCounter <> tblMainInfor.Rows.Count - 1 Then
                        ' Add hr tag
                        tblRow = New TableRow
                        tblCell = New TableCell
                        tblCell.ColumnSpan = 3
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl("<hr/>"))

                        tblRow.Cells.Add(tblCell)
                        'addrow
                        tblRow.CssClass = "lbLabel"
                        tblResult.Rows.Add(tblRow)
                    End If
                Next
            End If
            tblResult.Dispose()
            tblResult = Nothing
        End Sub

        ' ShowResult method
        ' Purpose: Show detail informations of all result items 
        Private Sub ShowResult()
            Dim tblMainInfor As DataTable
            Dim tblDetailInfor As DataTable
            Dim dtrows() As DataRow
            Dim strIndicators As String = ""
            Dim strContent As String = ""
            Dim strFieldCode As String = ""
            Dim strResult As String = ""
            Dim intCounter As Integer
            Dim intRowCount As Integer
            Dim lngItemID As Long

            ' Get result
            objBItemCollection.ItemIDs = Request("ItemIDs")
            tblMainInfor = objBItemCollection.GetItemMainInfor
            tblDetailInfor = objBItemCollection.GetItemDetailInfor

            ' Write result
            If tblMainInfor.Rows.Count > 0 Then
                strResult = strResult & "<TABLE WIDTH=""100%"" BORDER=""0"">" & Chr(13)
                strResult = strResult & "<TR>" & Chr(13)
                strResult = strResult & "<TD COLSPAN=""3"" ALIGN=""Center"">" & lblLabel1.Text & Chr(13)
                strResult = strResult & "</TD>" & Chr(13)
                strResult = strResult & "</TR>" & Chr(13)
                For intCounter = 0 To tblMainInfor.Rows.Count - 1
                    lngItemID = tblMainInfor.Rows(intCounter).Item("ItemID")
                    ' Show main detail infor
                    strResult = strResult & "<TR>" & Chr(13)
                    strResult = strResult & "<TD WIDTH=""5%"">Ldr</TD>" & Chr(13)
                    strResult = strResult & "<TD WIDTH=""3%""></TD>" & Chr(13)
                    strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("Leader") & "</TD>" & Chr(13)
                    strResult = strResult & "</TR>" & Chr(13)
                    strResult = strResult & "<TR>" & Chr(13)
                    strResult = strResult & "<TD>001</TD>" & Chr(13)
                    strResult = strResult & "<TD></TD>" & Chr(13)
                    strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("Code") & "</TD>" & Chr(13)
                    strResult = strResult & "</TR>" & Chr(13)
                    ' Filter now
                    dtrows = tblDetailInfor.Select("ItemID = " & lngItemID)
                    If dtrows.Length > 0 Then
                        For intRowCount = 0 To dtrows.Length - 1
                            strIndicators = ""
                            If Not IsDBNull(dtrows(intRowCount).Item("Ind1")) Then
                                strIndicators = dtrows(intRowCount).Item("Ind1")
                            Else
                                strIndicators = " "
                            End If
                            If Not IsDBNull(dtrows(intRowCount).Item("Ind2")) Then
                                strIndicators = strIndicators & dtrows(intRowCount).Item("Ind2")
                            Else
                                strIndicators = strIndicators & " "
                            End If
                            strIndicators = Replace(strIndicators, " ", "##")
                            strContent = dtrows(intRowCount).Item("Content")
                            strFieldCode = dtrows(intRowCount).Item("FieldCode")
                            If InStr(Request("FieldCode"), strFieldCode) > 0 Then
                                strFieldCode = "<B>" & strFieldCode & "</B>"
                            End If

                            strResult = strResult & "<TR>" & Chr(13)
                            strResult = strResult & "<TD>" & strFieldCode & Chr(13)
                            strResult = strResult & "<TD>" & strIndicators & Chr(13)
                            strResult = strResult & "<TD>" & strContent & Chr(13)
                            strResult = strResult & "</TD>" & Chr(13)
                            strResult = strResult & "</TR>" & Chr(13)
                        Next
                    End If
                    ' Show main detail infor (continue)
                    ' NewRecord
                    strResult = strResult & "<TR>" & Chr(13)
                    strResult = strResult & "<TD>900</TD>" & Chr(13)
                    strResult = strResult & "<TD></TD>" & Chr(13)
                    strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("NewRecord") & "</TD>" & Chr(13)
                    strResult = strResult & "</TR>" & Chr(13)
                    strResult = strResult & "<TR>" & Chr(13)
                    ' CoverPicture
                    If Not IsDBNull(tblMainInfor.Rows(intCounter).Item("CoverPicture")) Then
                        strResult = strResult & "<TD>907</TD>" & Chr(13)
                        strResult = strResult & "<TD></TD>" & Chr(13)
                        strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("CoverPicture") & "</TD>" & Chr(13)
                        strResult = strResult & "</TR>" & Chr(13)
                    End If
                    ' Cataloguer
                    If Not IsDBNull(tblMainInfor.Rows(intCounter).Item("Cataloguer")) Then
                        strResult = strResult & "<TR>"
                        strResult = strResult & "<TD>911</TD>"
                        strResult = strResult & "<TD></TD>"
                        strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("Cataloguer") & "</TD>"
                        strResult = strResult & "</TR>"
                    End If
                    ' Reviewer
                    If Not IsDBNull(tblMainInfor.Rows(intCounter).Item("Reviewer")) Then
                        strResult = strResult & "<TR>"
                        strResult = strResult & "<TD>912</TD>"
                        strResult = strResult & "<TD></TD>"
                        strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("Reviewer") & "</TD>"
                        strResult = strResult & "</TR>"
                    End If
                    ' MediumCode
                    strResult = strResult & "<TR>"
                    strResult = strResult & "<TD>925</TD>"
                    strResult = strResult & "<TD></TD>"
                    strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("MediumCode") & "</TD>"
                    strResult = strResult & "</TR>"
                    ' AccessLevel
                    strResult = strResult & "<TR>"
                    strResult = strResult & "<TD>926</TD>"
                    strResult = strResult & "<TD></TD>"
                    strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("AccessLevel") & "</TD>"
                    strResult = strResult & "</TR>"
                    ' TypeCode
                    strResult = strResult & "<TR>"
                    strResult = strResult & "<TD>927</TD>"
                    strResult = strResult & "<TD></TD>"
                    strResult = strResult & "<TD>" & tblMainInfor.Rows(intCounter).Item("TypeCode") & "</TD>"
                    strResult = strResult & "</TR>"

                    ' Show 2 action buttons
                    strResult = strResult & "<TR>" & Chr(13)
                    strResult = strResult & "<TD COLSPAN=""3"" ALIGN=""Center"">" & Chr(13)
                    strResult = strResult & "<input type=""button"" value=""" & lblLabel3.Text & """ class=""lbButton"" onClick=""opener.top.main.Sentform.location.href='WCataModify.aspx?Clone=0&ItemID=" & lngItemID & "'; self.close()"">&nbsp;"
                    strResult = strResult & "<input type=""button"" value=""" & lblLabel2.Text & """ class=""lbButton"" onClick=""opener.top.main.Sentform.location.href='WCataModify?Clone=1&ItemID=" & lngItemID & "'; self.close()"">"
                    strResult = strResult & "</TD>" & Chr(13)
                    strResult = strResult & "</TR>" & Chr(13)

                    ' hr tag
                    strResult = strResult & "<TR>"
                    strResult = strResult & "<TD  COLSPAN=""3""><hr/></TD>"
                    strResult = strResult & "</TR>"

                    strResult = strResult & "</TABLE>"
                Next
            End If

            Response.Write(strResult)

            ' Release resources
            tblMainInfor.Dispose()
            tblMainInfor = Nothing
            tblDetailInfor.Dispose()
            tblDetailInfor = Nothing
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace