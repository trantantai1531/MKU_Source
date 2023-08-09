Imports Microsoft.VisualBasic
Namespace eMicLibAdmin.WebUI.Common
    Public Class clsGirdPager
        Public Property gridView As GridView
        Public Sub ApplyPaging(ByVal listPageSize As Integer(), Optional ByVal showPageNumber As Boolean = False, Optional ByVal showTextBoxCurrentPage As Boolean = True, Optional ByVal showNextPrev As Boolean = True, Optional ByVal showFirstLast As Boolean = True, Optional ByVal showPageSize As Boolean = True)
            Dim row As GridViewRow = gridView.BottomPagerRow
            Dim ph As PlaceHolder
            Dim lnkPaging As LinkButton

            Dim lnkFirstPage As LinkButton
            Dim lnkPrevPage As LinkButton

            Dim lnkNextPage As LinkButton
            Dim lnkLastPage As LinkButton
            Dim ddl As DropDownList

            Dim table = New Table


            table.CssClass = "footer-pager"
            Dim rowFooter = New TableRow()
            Dim tCell As New TableCell()


            
            ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
            ph.Controls.Clear()

            'If showFirstLast Then
            lnkFirstPage = New LinkButton()
            lnkFirstPage.Text = HttpUtility.HtmlEncode("<<")
            lnkFirstPage.Width = Unit.Pixel(50)
            lnkFirstPage.CommandName = "Page"
            lnkFirstPage.CommandArgument = "first"
            ph.Controls.Add(lnkFirstPage)
            lnkFirstPage.Enabled = True
            If gridView.PageIndex = 0 Then
                lnkFirstPage.Enabled = False

            End If
            ' End If


            If showNextPrev Then
                lnkPrevPage = New LinkButton()
                lnkPrevPage.Text = HttpUtility.HtmlEncode("<")
                lnkPrevPage.Width = Unit.Pixel(50)
                lnkPrevPage.CommandName = "Page"
                lnkPrevPage.CommandArgument = "prev"
                ph.Controls.Add(lnkPrevPage)
                lnkPrevPage.Enabled = True
                If gridView.PageIndex = 0 Then
                    lnkPrevPage.Enabled = False
                End If
            End If


            'check exit dll  
            ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
            Dim dllcurrent As DropDownList
            Dim currentSize = 0
            If ph Is Nothing Then
                dllcurrent = DirectCast(ph.FindControl("dllPageSize"), DropDownList)
                If dllcurrent Is Nothing Then
                    currentSize = dllcurrent.SelectedValue
                    gridView.PageSize = currentSize
                End If
            End If

            ' PageNumber
            If showPageNumber Then
                For i As Integer = 1 To gridView.PageCount
                    lnkPaging = New LinkButton()
                    lnkPaging.Width = Unit.Pixel(20)
                    lnkPaging.CssClass = "LinkPaging"
                    lnkPaging.Text = i.ToString()
                    lnkPaging.CommandName = "Page"
                    lnkPaging.CommandArgument = i.ToString()
                    If i = gridView.PageIndex + 1 Then
                        lnkPaging.BackColor = System.Drawing.Color.White
                        lnkPaging.ForeColor = Color.Black
                        lnkPaging.CssClass = "current-page"
                        lnkPaging.BorderStyle = BorderStyle.None
                    End If
                    ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
                    ph.Controls.Add(lnkPaging)
                Next
            End If

            ' textbox current page index
            If showTextBoxCurrentPage Then
                Dim textBoxSize = New TextBox
                textBoxSize.Text = (gridView.PageIndex + 1).ToString()
                textBoxSize.CssClass = "txt-page-size"
                textBoxSize.ID = "txtPageIndex"
                textBoxSize.AutoPostBack = True
                ph.Controls.Add(textBoxSize)
                Dim lblBoxSize = New Label
                lblBoxSize.Text = " / " & (gridView.PageCount).ToString()
                lblBoxSize.CssClass = "lbl-box-page-size"
                ph.Controls.Add(lblBoxSize)
                ph.Controls.Add(lblBoxSize)
            End If



            If showNextPrev Then
                lnkNextPage = New LinkButton()
                lnkNextPage.Text = HttpUtility.HtmlEncode(">")
                lnkNextPage.Width = Unit.Pixel(50)
                lnkNextPage.CommandName = "Page"
                lnkNextPage.CommandArgument = "next"
                ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
                ph.Controls.Add(lnkNextPage)
                lnkNextPage.Enabled = True
                If gridView.PageIndex = gridView.PageCount - 1 Then
                    lnkNextPage.Enabled = False

                End If
            End If



            If showFirstLast Then
                lnkLastPage = New LinkButton()
                lnkLastPage.Text = HttpUtility.HtmlEncode(">>")
                lnkLastPage.Width = Unit.Pixel(50)
                lnkLastPage.CommandName = "Page"
                lnkLastPage.CommandArgument = "last"

                ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
                ph.Controls.Add(lnkLastPage)
                lnkLastPage.Enabled = True
                If gridView.PageIndex = gridView.PageCount - 1 Then
                    lnkLastPage.Enabled = False
                End If
            End If


            ddl = New DropDownList()
            ddl.AutoPostBack = True
            ddl.ID = "dllPageSize"
            ddl.CssClass = "ddl-page-size"
            For Each num In listPageSize
                ddl.Items.Add(New ListItem(num.ToString(), num.ToString()))
            Next
            ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
            ph.Controls.Add(ddl)

            Dim lblPageSize = New Label
            lblPageSize.Text = "Page Size "
            lblPageSize.CssClass = "lbl-page-size"


            ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
            ph.Controls.Add(lblPageSize)

            DllPageSizeControl.SelectedValue = gridView.PageSize

            Dim pagerRow = gridView.BottomPagerRow
            gridView.BottomPagerRow.Visible = True
            If Not pagerRow Is Nothing AndAlso pagerRow.Visible = False Then
                pagerRow.Visible = True
            End If



            'tCell.Controls.Add(ph)
            'rowFooter.Cells.Add(tCell)
            'Dim cell = New TableCell()
            'table.Rows.Add(rowFooter)
            'cell.co()
            'row.Controls.Add(ph)
        End Sub

        Public Function DllPageSizeControl() As DropDownList
            Dim row As GridViewRow = gridView.BottomPagerRow
            Dim ph As PlaceHolder
            ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
            Dim dll As DropDownList
            dll = DirectCast(ph.FindControl("dllPageSize"), DropDownList)
            Return dll
        End Function

        Public Function TxtPageIndexControl() As TextBox
            Dim row As GridViewRow = gridView.BottomPagerRow
            Dim ph As PlaceHolder
            ph = DirectCast(row.FindControl("phPageSize"), PlaceHolder)
            Dim txt As TextBox
            txt = DirectCast(ph.FindControl("txtPageIndex"), TextBox)
            Return txt
        End Function
    End Class
End Namespace