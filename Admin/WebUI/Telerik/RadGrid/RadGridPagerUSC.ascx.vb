Imports Telerik.Web.UI

Partial Class Telerik_RadGridPagerUSC
    Inherits System.Web.UI.UserControl
    Protected uniqueKey As String
    Public Property NumberOfRecord() As Integer
        Get
            Return m_NumberOfRecord
        End Get
        Set(value As Integer)
            m_NumberOfRecord = value
        End Set
    End Property
    Private m_NumberOfRecord As Integer
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        
        Dim MyGridPagerItem As GridPagerItem = TryCast(NamingContainer, GridPagerItem)
        Dim parentPage As IUCNumberOfRecord = DirectCast(Page, IUCNumberOfRecord)
        NumberOfRecord = parentPage.NumberOfRecord()

        rcbPageSize.DataSource = CheckRecord(NumberOfRecord)
        rcbPageSize.DataBind()

        If MyGridPagerItem.OwnerTableView.CurrentPageIndex = 0 Then
            lbtnFirstPage.Visible = False
            lbtnPreviousPage.Visible = False
            lblNextPage.Visible = False
            lblLastPage.Visible = False
        ElseIf MyGridPagerItem.OwnerTableView.CurrentPageIndex + 1 = MyGridPagerItem.OwnerTableView.PageCount Then
            lblFirstPage.Visible = False
            lblPrevPage.Visible = False
            lbtnNextPage.Visible = False
            lbtnLastPage.Visible = False
        Else
            lblFirstPage.Visible = False
            lblPrevPage.Visible = False
            lblLastPage.Visible = False
            lblNextPage.Visible = False
        End If

        uniqueKey = Guid.NewGuid().ToString("N")
        rcbPageSize.OnClientSelectedIndexChanged = "RadComboBox1_SelectedIndexChanged_" + uniqueKey


    End Sub

    Protected Sub tbPageNumber_TextChanged(sender As Object, e As System.EventArgs)
        Dim MyGridPagerItem As GridPagerItem = TryCast(NamingContainer, GridPagerItem)

        If tbPageNumber.Text = [String].Empty OrElse Integer.Parse(tbPageNumber.Text) - 1 < 1 Then
            MyGridPagerItem.OwnerTableView.CurrentPageIndex = 0

            MyGridPagerItem.OwnerTableView.Rebind()
        Else
            MyGridPagerItem.OwnerTableView.CurrentPageIndex = Integer.Parse(tbPageNumber.Text) - 1

            MyGridPagerItem.OwnerTableView.Rebind()
        End If


    End Sub

    Protected Sub tbRecordsPerPage_TextChanged(sender As Object, e As System.EventArgs)
        Dim MyGridPagerItem As GridPagerItem = TryCast(NamingContainer, GridPagerItem)
        If tbRecordsPerPage.Text = [String].Empty OrElse Integer.Parse(tbRecordsPerPage.Text) < 1 Then
            MyGridPagerItem.OwnerTableView.PageSize = Integer.Parse(rcbPageSize.SelectedValue.ToString())

            MyGridPagerItem.OwnerTableView.Rebind()
        Else
            MyGridPagerItem.OwnerTableView.PageSize = Integer.Parse(tbRecordsPerPage.Text)

            MyGridPagerItem.OwnerTableView.Rebind()
        End If

    End Sub

    Private Function CheckRecord(NumberOfRecord As Integer) As List(Of KeyValuePair(Of String, String))
        rcbPageSize.DataValueField = "Key"
        rcbPageSize.DataTextField = "Value"
        Dim items = New List(Of KeyValuePair(Of String, String))()
        If m_NumberOfRecord < CInt(clsPageSizeEnum.TypeRecord.eSmall) Then
            Dim n As Integer() = DirectCast([Enum].GetValues(GetType(clsPageSizeEnum.SmallRecord)), Integer())
            For Each x In n
                items.Add(New KeyValuePair(Of String, String)(x.ToString(), x.ToString()))
            Next

        Else
            Dim n As Integer() = DirectCast([Enum].GetValues(GetType(clsPageSizeEnum.BigRecord)), Integer())
            For Each x In n
                items.Add(New KeyValuePair(Of String, String)(x.ToString(), x.ToString()))
            Next
        End If
        Return items
    End Function
End Class
