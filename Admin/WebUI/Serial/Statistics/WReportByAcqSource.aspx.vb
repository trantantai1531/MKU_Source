' Class: WReportByAcqSource
' Puspose: create AcqSource report
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   Date: 10/10/2004
'       Modify by: Tuanhv, Lent   
'           Works: 
'                 + Change method: BindData
'                 + Repair: Interface form

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WReportByAcqSource
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
        Private objBPC As New clsBPeriodicalCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            Call objBPC.Initialize()
        End Sub

        'Bind javascript
        Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistics/WStatistic.js'></script>")
        End Sub

        'Bind data to datagrid
        Sub BindData()
            Dim intAcqSourceID As Integer
            Dim intOnSubscription As Integer
            Dim intRow As Integer
            Dim tblResult As DataTable

            'Check statistic link to form
            Try

                If Request("AcqSourceID") <> "" Then
                    intAcqSourceID = CInt(Trim(Request.QueryString("AcqSourceID")))
                End If
                If Request("OnSubscription") <> "" Then
                    intOnSubscription = CInt(Request.QueryString("OnSubscription"))
                End If
                Try
                    'Show result
                    tblResult = objBPC.GetGenIssueItem(intAcqSourceID, intOnSubscription)

                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)
                    Dim inti As Integer
                    For inti = 0 To tblResult.Rows.Count - 1
                        tblResult.Rows(inti).Item("TITLE") = "<a href='../Acquisition/WViewInListMode.aspx?ItemId=" & tblResult.Rows(inti).Item("ITEMID") & "&title=" & tblResult.Rows(inti).Item("TITLE") & "'>" & tblResult.Rows(inti).Item("TITLE") & "</a>"
                    Next
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            DtgResult.DataSource = tblResult
                            DtgResult.DataBind()

                            'Change some colume
                            For intRow = 0 To tblResult.Rows.Count - 1
                                'Change colume OnSubscription
                                Try
                                    If CInt(tblResult.Rows(intRow).Item("OnSubscription")) = 1 Then
                                        DtgResult.Items(intRow).Cells(7).Text = ddlLabel.Items(3).Text
                                    Else
                                        DtgResult.Items(intRow).Cells(7).Text = ddlLabel.Items(4).Text
                                    End If
                                Catch ex As Exception
                                End Try
                                'Change colume Ceased
                                Try
                                    If Trim(CStr(tblResult.Rows(intRow).Item("Ceased"))) = "True" Then
                                        DtgResult.Items(intRow).Cells(4).Text = "x"
                                    Else
                                        DtgResult.Items(intRow).Cells(4).Text = " "
                                    End If
                                Catch ex As Exception
                                End Try
                                'Change colume Category
                                Try
                                    Select Case CInt(tblResult.Rows(intRow).Item("AcqSourceID"))
                                        Case 1
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(5).Text
                                        Case 2
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(6).Text
                                        Case 3
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(7).Text
                                        Case 4
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(8).Text
                                        Case 6
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(9).Text
                                        Case 9
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(10).Text
                                        Case 5
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(12).Text
                                        Case 7
                                            DtgResult.Items(intRow).Cells(8).Text = ddlLabel.Items(11).Text
                                    End Select
                                Catch ex As Exception
                                End Try
                            Next
                        End If
                        tblResult = Nothing
                    End If
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
        End Sub

        ' Event: DtgResult_PageIndexChanged
        Private Sub DtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DtgResult.PageIndexChanged
            DtgResult.CurrentPageIndex = e.NewPageIndex
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
                If Not objBPC Is Nothing Then
                    objBPC.Dispose(True)
                    objBPC = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace