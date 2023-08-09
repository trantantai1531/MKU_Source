' WCheckItemResult class
' Purpose: show detail informations of all existing items
' Creator: Oanhtn
' CreatedDate: 24/05/2004
' Modification history:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Circulation
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
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' ShowTableResult method
        Private Sub ShowTableResult()
            Dim tblMainInfor As New DataTable
            Dim tblDetailInfor As New DataTable
            Dim intCounter As Integer
            Dim intRowCount As Integer
            Dim lngItemID As Long
            Dim strItemCode As String
            Dim tblRow As TableRow
            Dim dtrows() As DataRow
            Dim tblCell As TableCell
            Dim strIndicators As String
            Dim strFieldCode As String
            Dim strContent As String
            Dim strLabel1 As String = ddlLabel.Items(2).Text
            Dim strLabel2 As String = ddlLabel.Items(3).Text
            Dim strLabel3 As String = ddlLabel.Items(4).Text

            objBItemCollection.ItemIDs = Request("ItemIDs")
            tblMainInfor = objBItemCollection.GetItemMainInfor

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

            tblDetailInfor = objBItemCollection.GetItemDetailInfor

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

            If tblMainInfor.Rows.Count > 0 Then
                'Title
                tblRow = New TableRow
                tblCell = New TableCell

                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.ColumnSpan = 3
                tblCell.Controls.Add(New LiteralControl(strLabel1))
                tblCell.CssClass = "lbPageTitle"
                tblRow.Cells.Add(tblCell)

                tblResult.Rows.Add(tblRow)

                For intCounter = 0 To tblMainInfor.Rows.Count - 1
                    lngItemID = tblMainInfor.Rows(intCounter).Item("ItemID")
                    strItemCode = tblMainInfor.Rows(intCounter).Item("Code")

                    'Show main details infor
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
                    tblCell.Controls.Add(New LiteralControl("926"))
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
                    tblCell.Controls.Add(New LiteralControl("<input type=""button"" value=""" & strLabel3 & """ class=""lbButton"" onClick=""OpenWindow('WItemDetails.aspx?ItemType=1&ItemCode=" & strItemCode & "','ViewItem',600,400,150,50);"">"))
                    tblCell.Controls.Add(New LiteralControl("<input type=""button"" value=""" & strLabel2 & """ class=""lbButton"" onClick=""opener.parent.Workform.CheckOutMain.location.href='WAddCopyNumber.aspx?ItemCode=" & strItemCode & "'; self.close()"">"))
                    tblRow.Cells.Add(tblCell)

                    tblRow.CssClass = "lbLabel"
                    tblResult.Rows.Add(tblRow)
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
            Dim strLabel1 As String = ddlLabel.Items(2).Text
            Dim strLabel2 As String = ddlLabel.Items(3).Text
            Dim strLabel3 As String = ddlLabel.Items(4).Text

            ' Get result
            objBItemCollection.ItemIDs = Request("ItemIDs")
            tblMainInfor = objBItemCollection.GetItemMainInfor

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

            tblDetailInfor = objBItemCollection.GetItemDetailInfor
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

            ' Write result
            If Not tblMainInfor Is Nothing Then
                If tblMainInfor.Rows.Count > 0 Then
                    strResult = strResult & "<TABLE WIDTH=""100%"" BORDER=""0"">" & Chr(13)
                    strResult = strResult & "<TR>" & Chr(13)
                    strResult = strResult & "<TD COLSPAN=""3"" ALIGN=""Center"">" & strLabel1 & Chr(13)
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
                        If Not tblDetailInfor Is Nothing Then
                            If tblDetailInfor.Rows.Count > 0 Then
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
                            End If
                        End If

                        ' Show main detail infor (continue)
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

                        strResult = strResult & "</TABLE>"
                    Next
                    ' Release resources
                    tblMainInfor.Dispose()
                    tblMainInfor = Nothing
                    tblDetailInfor.Dispose()
                    tblDetailInfor = Nothing
                End If
            End If

            Response.Write(strResult)
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