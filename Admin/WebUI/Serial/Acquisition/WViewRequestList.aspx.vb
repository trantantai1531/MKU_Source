' Class: WViewRequestList
' Puspose: View requested list
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 29/09/2004 by Tuanhv
'           Add: Load view requested list

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WViewRequestList
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lbUrgency1 As System.Web.UI.WebControls.Label
        Protected WithEvents lbUrgency2 As System.Web.UI.WebControls.Label
        Protected WithEvents lbUrgency3 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBIO As New clsBItemOrder

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(82) Then
                Call WriteErrorMssg(lblError.Text)
            End If
        End Sub
        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            Call objBIO.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: Include some JS functions
        Private Sub BindJS()
            lnkAcquire.NavigateUrl = "WACQsRequest.aspx"
        End Sub

        ' BindData method
        ' Purpose: Show data
        Sub BindData()
            Dim tblResult As DataTable
            Dim intRow As Integer
            Dim intStartRec As Integer
            Dim intStopRec As Integer
            Dim dtgItem As DataGridItem
            Dim strUrgency As String
            Dim lblUrgency As Label

            dgrResult.Visible = False

            ' Get data
            tblResult = objBIO.GetSerialRequestList(0)
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                dgrResult.Visible = True
                dgrResult.DataSource = tblResult
                dgrResult.DataBind()

                intStartRec = dgrResult.CurrentPageIndex * dgrResult.PageSize + 1
                intStopRec = intStartRec + dgrResult.PageSize
                If tblResult.Rows.Count < intStopRec Then
                    intStopRec = tblResult.Rows.Count - 1
                End If

                ' Change urgency in text mode.
                For Each dtgItem In dgrResult.Items
                    strUrgency = CStr(CType(dtgItem.FindControl("lblUrgencyTemp"), Label).Text)
                    lblUrgency = dtgItem.FindControl("lblUrgency")

                    Select Case Trim(strUrgency)
                        Case "1"
                            lblUrgency.Text = lblUrgency1.Text
                        Case "2"
                            lblUrgency.Text = lblUrgency2.Text
                        Case "3"
                            lblUrgency.Text = lblUrgency3.Text
                    End Select
                Next
            End If
        End Sub

        ' DgrResult_PageIndexChanged event
        ' Purpose: Change the page index
        Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrResult.PageIndexChanged
            dgrResult.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBIO Is Nothing Then
                    objBIO.Dispose(True)
                    objBIO = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace