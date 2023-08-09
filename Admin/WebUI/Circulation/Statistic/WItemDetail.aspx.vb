' Class: WItemDetail
' Purpose: Get Item information (Main infor and holding infor)
' Creater: Tuanhv
' CreatedDate: 15/09/2004
' Modification history:
'   - 19/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WItemDetail
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

        Private tblItem As DataTable
        Private tblCode As DataTable
        Private intItemID As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavaScript()
            Call BindData()
        End Sub

        ' Initialze method 
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init for objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()
        End Sub

        ' BindJavaScript method
        Private Sub BindJavaScript()
            Page.RegisterClientScriptBlock("CommonJS", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'Js/WItemDetails.js'></script>")

            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' BindData method
        ' Purpose: Display the Item details
        Private Sub BindData()
            'Declare variable
            Dim intCount As Integer
            Dim intCountItemMainInfor As Integer
            Dim intCountItemDetailInfor As Integer
            Dim intCountCopyNumber As Integer
            Dim intIndex As Integer
            Dim tblItemMainInfor As DataTable
            Dim tblItemDetailInfor As DataTable
            Dim tblCopyNumber As DataTable
            Dim tblItem2 As DataTable
            Dim strAddressNXB As String = ""
            Dim strTG As String = ""
            Dim strISBN As String = ""
            Dim strCopyNumber As String = ""
            Dim strTitle As String = ""

            intItemID = CInt(Request("ItemID"))
            ' Retrieve all Item infor

            'Find Main infor for Item
            objBItemCollection.IsAuthority = 0
            objBItemCollection.ItemIDs = CStr(intItemID)
            tblItemMainInfor = objBItemCollection.GetItemMainInfor
            intCountItemMainInfor = tblItemMainInfor.Rows.Count

            'tblItemDetailInfor
            tblItemDetailInfor = objBItemCollection.GetItemDetailInfor
            intCountItemDetailInfor = tblItemDetailInfor.Rows.Count

            'tblCopyNumber
            objBItemCollection.ItemID = intItemID
            tblCopyNumber = objBItemCollection.GetCopyNumbers
            intCountCopyNumber = tblCopyNumber.Rows.Count

            If intCountItemDetailInfor > 0 Then
                For intIndex = 0 To intCountItemDetailInfor - 1
                    Select Case CStr(tblItemDetailInfor.Rows(intIndex).Item("FieldCode"))
                        Case "260"
                            strAddressNXB = CStr(tblItemDetailInfor.Rows(intIndex).Item("Content"))
                        Case "700"
                            strTG = strTG + ", " + CStr(tblItemDetailInfor.Rows(intIndex).Item("Content"))
                        Case "020"
                            strISBN = strISBN + ", " + CStr(tblItemDetailInfor.Rows(intIndex).Item("Content"))
                        Case "245"
                            strTitle = CStr(tblItemDetailInfor.Rows(intIndex).Item("Content"))
                    End Select
                Next
            End If

            Dim tblRow1 As TableRow
            Dim tblCell11 As TableCell
            Dim tblCell21 As TableCell
            If Trim(strTitle) <> "" Then
                tblRow1 = New TableRow
                tblCell11 = New TableCell
                tblCell11.ColumnSpan = 2
                tblCell11.HorizontalAlign = HorizontalAlign.Left
                tblCell11.CssClass = "lbGroupTitle"
                tblCell11.Width = Unit.Percentage(100%)

                tblCell11.Controls.Add(New LiteralControl(strTitle))
                tblRow1.Cells.Add(tblCell11)
                tblMainInfor.Rows.Add(tblRow1)
            End If
            ' Find Information genarate with one ItemID
            If intCountItemMainInfor > 0 Then
                Dim tblRow As TableRow
                Dim tblCell1 As TableCell
                Dim tblCell2 As TableCell

                For intIndex = 0 To intCountItemMainInfor - 1
                    ' Find AccessEntry
                    If Not tblItemMainInfor.Rows(intIndex).Item("Description") Is DBNull.Value Then
                        If Trim(tblItemMainInfor.Rows(intIndex).Item("Description")) <> "" Then
                            tblRow = New TableRow

                            tblCell1 = New TableCell
                            tblCell1.ColumnSpan = 1
                            tblCell1.HorizontalAlign = HorizontalAlign.Right
                            tblCell1.CssClass = "lbLabel"
                            tblCell1.Width = Unit.Percentage(30%)

                            tblCell2 = New TableCell
                            tblCell2.ColumnSpan = 1
                            tblCell2.CssClass = "lbLabel"
                            tblCell2.Width = Unit.Percentage(70%)
                            tblCell1.Controls.Add(New LiteralControl(lblFieldLabel1.Text))
                            tblCell2.Controls.Add(New LiteralControl(tblItemMainInfor.Rows(intIndex).Item("Description")))
                            tblRow.Cells.Add(tblCell1)
                            tblCell2.Font.Bold = True
                            tblRow.Cells.Add(tblCell2)
                            tblMainInfor.Rows.Add(tblRow)
                        End If
                    End If

                    ' Find AccessLevel
                    If Not tblItemMainInfor.Rows(intIndex).Item("AccessLevel") Is DBNull.Value Then
                        If Trim(tblItemMainInfor.Rows(intIndex).Item("AccessLevel")) <> "" Then
                            tblRow = New TableRow

                            tblCell1 = New TableCell
                            tblCell1.ColumnSpan = 1
                            tblCell1.HorizontalAlign = HorizontalAlign.Right
                            tblCell1.CssClass = "lbLabel"
                            tblCell1.Width = Unit.Percentage(30%)

                            tblCell2 = New TableCell
                            tblCell2.ColumnSpan = 1
                            tblCell2.CssClass = "lbLabel"
                            tblCell2.Width = Unit.Percentage(70%)
                            tblCell1.Controls.Add(New LiteralControl(lblFieldLabel2.Text))
                            tblCell2.Controls.Add(New LiteralControl(CStr(tblItemMainInfor.Rows(intIndex).Item("AccessLevel"))))
                            tblRow.Cells.Add(tblCell1)
                            tblCell2.Font.Bold = True
                            tblRow.Cells.Add(tblCell2)
                            tblMainInfor.Rows.Add(tblRow)
                        End If
                    End If

                    ' Find BibLevel
                    If Not tblItemMainInfor.Rows(intIndex).Item("BibLevel") Is DBNull.Value Then
                        If Trim(tblItemMainInfor.Rows(intIndex).Item("BibLevel")) <> "" Then
                            tblRow = New TableRow

                            tblCell1 = New TableCell
                            tblCell1.ColumnSpan = 1
                            tblCell1.HorizontalAlign = HorizontalAlign.Right
                            tblCell1.CssClass = "lbLabel"
                            tblCell1.Width = Unit.Percentage(30%)

                            tblCell2 = New TableCell
                            tblCell2.ColumnSpan = 1
                            tblCell2.CssClass = "lbLabel"
                            tblCell2.Width = Unit.Percentage(70%)
                            tblCell1.Controls.Add(New LiteralControl(lblFieldLabel3.Text))
                            tblCell2.Controls.Add(New LiteralControl(CStr(tblItemMainInfor.Rows(intIndex).Item("BibLevel"))))
                            tblRow.Cells.Add(tblCell1)
                            tblCell2.Font.Bold = True
                            tblRow.Cells.Add(tblCell2)
                            tblMainInfor.Rows.Add(tblRow)
                        End If
                    End If

                    ' Find TypeName and TypeCode
                    If Not tblItemMainInfor.Rows(intIndex).Item("TypeName") Is DBNull.Value Then
                        If Trim(tblItemMainInfor.Rows(intIndex).Item("TypeName")) <> "" Then
                            tblRow = New TableRow

                            tblCell1 = New TableCell
                            tblCell1.ColumnSpan = 1
                            tblCell1.HorizontalAlign = HorizontalAlign.Right
                            tblCell1.CssClass = "lbLabel"
                            tblCell1.Width = Unit.Percentage(30%)

                            tblCell2 = New TableCell
                            tblCell2.ColumnSpan = 1
                            tblCell2.CssClass = "lbLabel"
                            tblCell2.Width = Unit.Percentage(70%)
                            tblCell1.Controls.Add(New LiteralControl(lblFieldLabel5.Text))
                            tblCell2.Controls.Add(New LiteralControl(CStr(tblItemMainInfor.Rows(intIndex).Item("TypeName"))))
                            tblRow.Cells.Add(tblCell1)
                            tblCell2.Font.Bold = True
                            tblRow.Cells.Add(tblCell2)
                            tblMainInfor.Rows.Add(tblRow)
                        End If
                    End If


                Next
            End If


            ' Find CopyNumber
            If intCountCopyNumber > 0 Then

                For intIndex = 0 To intCountCopyNumber - 1
                    strCopyNumber = strCopyNumber + ", " + tblCopyNumber.Rows(intIndex).Item("CopyNumber")
                Next
            End If

            ' Find AddressNXB and TG,Chi so ISBN


            If Len(strAddressNXB) > 0 Then
                strAddressNXB = Right(strAddressNXB, Len(strAddressNXB) - 2)
            Else
                strAddressNXB = ""
            End If

            If Len(strTG) > 0 Then
                strTG = Right(strTG, Len(strTG) - 2)
            Else
                strTG = ""
            End If

            If Len(strISBN) > 0 Then
                strISBN = Right(strISBN, Len(strISBN) - 2)
            Else
                strISBN = ""
            End If

            If Len(strCopyNumber) > 0 Then
                strCopyNumber = Right(strCopyNumber, Len(strCopyNumber) - 2)
            Else
                strCopyNumber = ""
            End If

            If Trim(strISBN) <> "" Then
                tblRow1 = New TableRow
                tblCell11 = New TableCell
                tblCell11.ColumnSpan = 1
                tblCell11.HorizontalAlign = HorizontalAlign.Right
                tblCell11.CssClass = "lbLabel"
                tblCell11.Width = Unit.Percentage(30%)

                tblCell21 = New TableCell
                tblCell21.ColumnSpan = 1
                tblCell21.CssClass = "lbLabel"
                tblCell21.Width = Unit.Percentage(70%)

                tblCell11.Controls.Add(New LiteralControl(lblFieldLabel4.Text))
                tblRow1.Cells.Add(tblCell11)
                tblCell21.Controls.Add(New LiteralControl(strISBN))
                tblCell21.Font.Bold = True
                tblRow1.Cells.Add(tblCell21)
                tblMainInfor.Rows.Add(tblRow1)
            End If

            If Trim(strAddressNXB) <> "" Then
                tblRow1 = New TableRow
                tblCell11 = New TableCell
                tblCell11.ColumnSpan = 1
                tblCell11.HorizontalAlign = HorizontalAlign.Right
                tblCell11.CssClass = "lbLabel"
                tblCell11.Width = Unit.Percentage(30%)

                tblCell21 = New TableCell
                tblCell21.ColumnSpan = 1
                tblCell21.CssClass = "lbLabel"
                tblCell21.Width = Unit.Percentage(70%)

                tblCell11.Controls.Add(New LiteralControl(lblFieldLabel6.Text))
                tblRow1.Cells.Add(tblCell11)
                tblCell21.Controls.Add(New LiteralControl(strAddressNXB))
                tblCell21.Font.Bold = True
                tblRow1.Cells.Add(tblCell21)
                tblMainInfor.Rows.Add(tblRow1)
            End If

            If Trim(strCopyNumber) <> "" Then
                tblRow1 = New TableRow
                tblCell11 = New TableCell
                tblCell11.ColumnSpan = 1
                tblCell11.HorizontalAlign = HorizontalAlign.Right
                tblCell11.CssClass = "lbLabel"
                tblCell11.Width = Unit.Percentage(30%)

                tblCell21 = New TableCell
                tblCell21.ColumnSpan = 1
                tblCell21.CssClass = "lbLabel"
                tblCell21.Width = Unit.Percentage(70%)

                tblCell11.Controls.Add(New LiteralControl(lblFieldLabel8.Text))
                tblRow1.Cells.Add(tblCell11)
                tblCell21.Controls.Add(New LiteralControl(strCopyNumber))
                tblCell21.Font.Bold = True
                tblRow1.Cells.Add(tblCell21)
                tblMainInfor.Rows.Add(tblRow1)

            End If
            If Trim(strTG) <> "" Then
                tblRow1 = New TableRow
                tblCell11 = New TableCell
                tblCell11.ColumnSpan = 1
                tblCell11.HorizontalAlign = HorizontalAlign.Right
                tblCell11.CssClass = "lbLabel"
                tblCell11.Width = Unit.Percentage(30%)

                tblCell21 = New TableCell
                tblCell21.ColumnSpan = 1
                tblCell21.CssClass = "lbLabel"
                tblCell21.Width = Unit.Percentage(70%)

                tblCell11.Controls.Add(New LiteralControl(lblFieldLabel9.Text))
                tblRow1.Cells.Add(tblCell11)
                tblCell21.Controls.Add(New LiteralControl(strTG))
                tblCell21.Font.Bold = True
                tblRow1.Cells.Add(tblCell21)
                tblMainInfor.Rows.Add(tblRow1)
            End If
        End Sub

        ' Page_UnLoad event    
        ' Purpose: Unload the page and dispose the elements
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
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

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        End Sub
    End Class
End Namespace