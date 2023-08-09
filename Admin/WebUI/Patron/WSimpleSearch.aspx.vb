' Class: WSimpleSearch
' Puspose: Show simple search form
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 28/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WSimpleSearch
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents VAN As System.Web.UI.WebControls.TextBox
        Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents altInvalidData As System.Web.UI.WebControls.Label
        Protected WithEvents altIV_Table As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBF As New clsBFaculty
        Private objBPG As New clsBPatronGroup
        Private objBO As New clsBOccupation
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
        ' Purpose: Init all need objects
        Public Sub Initialize()
            Session("ResultTabDataSource") = Nothing

            ' Init objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()

            ' Init objBF object
            objBF.DBServer = Session("DBServer")
            objBF.ConnectionString = Session("ConnectionString")
            objBF.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBF.Initialize()

            ' Init objBO object
            objBO.DBServer = Session("DBServer")
            objBO.ConnectionString = Session("ConnectionString")
            objBO.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBO.Initialize()

            ' Init objBPG object
            objBPG.DBServer = Session("DBServer")
            objBPG.ConnectionString = Session("ConnectionString")
            objBPG.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPG.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(45) Then
                btnSearch.Enabled = False
                btnSearchAdv.Enabled = False
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JScriptSelf", "<script language = 'javascript' src = 'js/WSimpleSearch.js'></script>")

            btnSearch.Attributes.Add("OnClick", "if (!Check_All('" & ddlLabel.Items(5).Text & " (" & Session("DateFormat") & ")','" & Session("DateFormat") & "')) {return false}")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnSearchAdv.Attributes.Add("OnClick", "self.location.href='WAdvanceSearch.aspx'; return false;")
            btnSetFieldShow.Attributes.Add("OnClick", "SetFieldShow('" & ddlLabel.Items(6).Text & "'); return false;")
            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkDOB, txtDOB, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkExpiredDate, txtExpiredDate, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkValidDate, txtValidDate, ddlLabel.Items(5).Text)

        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As New DataTable
            Dim lsItem As New ListItem
            Dim blnFound As Boolean = False

            ' Occupation
            tblTemp = objBO.GetOccupation

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBO.ErrorMsg, ddlLabel.Items(1).Text, objBO.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlOccupation.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(3).Text)
                    ddlOccupation.DataTextField = "Occupation"
                    ddlOccupation.DataValueField = "ID"
                    ddlOccupation.DataBind()
                    blnFound = True
                End If
                tblTemp = Nothing
            End If
            If Not blnFound Then
                lsItem.Text = ddlLabel.Items(3).Text
                lsItem.Value = 0
                ddlOccupation.Items.Add(lsItem)
            End If

            ' Get faculties
            blnFound = False
            tblTemp = objBF.GetFaculty()

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBF.ErrorMsg, ddlLabel.Items(1).Text, objBF.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlFaculty.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(3).Text)
                    ddlFaculty.DataTextField = "FC"
                    ddlFaculty.DataValueField = "ID"
                    ddlFaculty.DataBind()
                    blnFound = True
                End If
                tblTemp = Nothing
            End If
            If Not blnFound Then
                lsItem.Text = ddlLabel.Items(3).Text
                lsItem.Value = 0
                ddlFaculty.Items.Add(lsItem)
            End If

            ' Get patrongroups
            objBPG.LibID = clsSession.GlbSite
            tblTemp = objBPG.GetPatronGroup

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPG.ErrorMsg, ddlLabel.Items(1).Text, objBPG.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    lstGroupID.DataSource = tblTemp
                    lstGroupID.DataTextField = "Name"
                    lstGroupID.DataValueField = "ID"
                    lstGroupID.DataBind()
                End If
                tblTemp = Nothing
            End If
        End Sub

        ' Method: Search
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim blnFound As Boolean = False

            objBPC.Code = txtCode.Text.Trim
            objBPC.DOB = txtDOB.Text.Trim
            objBPC.FullName = txtFullName.Text.Trim
            objBPC.Sex = ddlSex.SelectedItem.Value
            objBPC.ValidDate = txtValidDate.Text.Trim
            objBPC.ExpiredDate = txtExpiredDate.Text.Trim
            objBPC.Classs = txtClass.Text.Trim
            objBPC.Faculty = ddlFaculty.SelectedItem.Value
            objBPC.Grade = txtGrade.Text.Trim
            objBPC.OccupationID = ddlOccupation.SelectedItem.Value
            objBPC.OrderBy = ddlOrderBy.SelectedItem.Value
            objBPC.SelectTop = ddlSelectTop.SelectedItem.Value

            Dim lstTmp As ListItem
            Dim strGroupID As String

            strGroupID = hidPatronGroupIDs.Value
            'For Each lstTmp In lstGroupID.Items
            '    If lstTmp.Selected = True Then
            '        strGroupID = strGroupID & lstTmp.Value & ","
            '    End If
            'Next
            If strGroupID <> "" Then
                objBPC.PatronGroupID = Left(strGroupID, Len(strGroupID) - 1)
            End If
            Session("FieldShow") = txtFieldShow.Value
            Session("PatronIDs") = Nothing
            objBPC.LibID = clsSession.GlbSite
            Session("PatronIDs") = objBPC.Search

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

            ' Write log
            Call WriteLog(27, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If Not Session("PatronIDs") Is Nothing Then
                If IsArray(Session("PatronIDs")) Then
                    If CLng(Session("PatronIDs")(0)) > -1 Then
                        blnFound = True
                        Select Case ddlTypeShow.SelectedItem.Value
                            Case 0 ' document type
                                Response.Redirect("WSimpleSearchResultFrame.aspx")
                            Case 1 ' table type
                                Session("FieldShow") = Nothing
                                Session("FieldShow") = txtFieldShow.Value
                                Session("Pagesize") = Nothing
                                Session("Pagesize") = txtPageSize.Value
                                Response.Redirect("WSearchTableResult.aspx")
                        End Select
                    End If
                End If
            End If

            If Not blnFound Then
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text.Trim & "');</script>")
            End If
        End Sub

        ' Method: Page_Unload
        ' Purpose: release all objetcs
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBF Is Nothing Then
                objBF.Dispose(True)
                objBF = Nothing
            End If
            If Not objBO Is Nothing Then
                objBO.Dispose(True)
                objBO = Nothing
            End If
            If Not objBPG Is Nothing Then
                objBPG.Dispose(True)
                objBPG = Nothing
            End If
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
        End Sub
    End Class
End Namespace