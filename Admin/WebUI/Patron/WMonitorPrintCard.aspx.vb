' Class: WMonitorPrintCard
' Puspose: management print card
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WMonitorPrintCard
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

        Private objBPC As New clsBPatronCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize  objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(148) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'js/WMonitorPrintCard.js'></script>")

            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkDOB, txtDOB, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkValidDate, txtValidDate, ddlLabel.Items(4).Text)

            btnSearch.Attributes.Add("Onclick", "if (!CheckAll('" & ddlLabel.Items(3).Text & "')){return false;}")
            btnReset.Attributes.Add("OnClick", "ClearAll(); return false;")
            btnPrintCard.Attributes.Add("OnClick", "parent.Workform.location.href='WCards.aspx'; return false;")
        End Sub

        ' Method: BindData
        Sub BindData()
            objBPC.TypeSearch = "Simple"
            objBPC.Code = txtCode.Text.Trim
            objBPC.FullName = txtFullName.Text.Trim
            objBPC.Sex = ddlSex.SelectedItem.Value
            objBPC.ValidDate = txtValidDate.Text.Trim
            objBPC.DOB = txtDOB.Text.Trim
            objBPC.Classs = txtClass.Text.Trim
            objBPC.Grade = txtGrade.Text.Trim
            objBPC.OrderBy = 0
            objBPC.PrintCard = 1
            'objBPC.SelectTop = ddlSelectTop.SelectedItem.Value
            objBPC.SelectTop = 0

            Dim ArrPID()
            ArrPID = objBPC.Search

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

            Dim tblData As New DataTable
            If Not (ArrPID Is Nothing) Then
                Dim inti As Integer
                Dim strPID As String
                Dim intSelectTop As Integer
                strPID = ""
                For inti = 0 To UBound(ArrPID)
                    strPID = strPID & ArrPID(inti) & ","
                Next
                If strPID <> "" Then
                    strPID = Left(strPID, Len(strPID) - 1)
                End If
                intSelectTop = ddlSelectTop.SelectedItem.Value
                tblData = objBPC.GetCardPrinted(strPID, intSelectTop)
            End If

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

            DgrResult.Visible = False
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                DgrResult.Visible = True
                DgrResult.DataSource = tblData
                DgrResult.DataBind()
            End If
        End Sub

        ' Event: btnSearch_Click
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call BindData()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
        End Sub
    End Class
End Namespace