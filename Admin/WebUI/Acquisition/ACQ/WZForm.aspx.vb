Namespace eMicLibAdmin.WebUI.Acquisition
    Public Class WZForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMainTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblzServer As System.Web.UI.WebControls.Label
        Protected WithEvents txtzServer As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkZServerList As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblZPort As System.Web.UI.WebControls.Label
        Protected WithEvents txtZPort As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblZDatabase As System.Web.UI.WebControls.Label
        Protected WithEvents txtZDatabase As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSubTitle As System.Web.UI.WebControls.Label
        Protected WithEvents ddlFieldName1 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFieldValue1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlOperator2 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlFieldName2 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFieldValue2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlOperator3 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlFieldName3 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFieldValue3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblDisplay As System.Web.UI.WebControls.Label
        Protected WithEvents optMARC As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optISBD As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optSimple As System.Web.UI.WebControls.RadioButton
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnReset As System.Web.UI.WebControls.Button
        Protected WithEvents ddlLabel As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlLabelZ As System.Web.UI.WebControls.DropDownList


        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJS()

            If Not Page.IsPostBack Then
                ' Bind Data
                Call BindControl()
                Call SetPreSession()
            End If
        End Sub
        Private Sub SetPreSession()
            txtzServer.Text = Session("zServer")
            txtZPort.Text = Session("zPort")
            txtZDatabase.Text = Session("zDatabase")
            txtFieldValue1.Text = Session("txtFieldValue1")
            txtFieldValue2.Text = Session("txtFieldValue2")
            txtFieldValue3.Text = Session("txtFieldValue3")
            Dim i As Integer
            Dim tblTemp As DataTable
            Dim ArrFieldNameText() As String = {ddlLabel.Items(0).Text, ddlLabel.Items(1).Text, ddlLabel.Items(2).Text, ddlLabel.Items(3).Text, ddlLabel.Items(4).Text, ddlLabel.Items(5).Text, ddlLabel.Items(6).Text, ddlLabel.Items(7).Text}
            Dim ArrFieldNameValue() As String = {"@attr 1=4", "@attr 1=5", "@attr 1=1", "@attr 1=2", "@attr 1=21", "@attr 1=7", "@attr 1=8", "@attr 1=1016"}
            tblTemp = CreateTable(ArrFieldNameText, ArrFieldNameValue)
            For i = 0 To tblTemp.Rows.Count - 1
                If Session("ddlFieldName1") = tblTemp.Rows(i).Item("ValueField") Then
                    ddlFieldName1.SelectedIndex = i
                    Exit For
                End If
            Next
            For i = 0 To tblTemp.Rows.Count - 1
                If Session("ddlFieldName2") = tblTemp.Rows(i).Item("ValueField") Then
                    ddlFieldName2.SelectedIndex = i
                    Exit For
                End If
            Next
            For i = 0 To tblTemp.Rows.Count - 1
                If Session("ddlFieldName3") = tblTemp.Rows(i).Item("ValueField") Then
                    ddlFieldName3.SelectedIndex = i
                    Exit For
                End If
            Next
            tblTemp = Nothing
            Dim ArrLogicOpeText() As String = {"AND", "OR", "NOT"}
            Dim ArrLogicOpeValue() As String = {"AND", "OR", "AND NOT"}

            tblTemp = CreateTable(ArrLogicOpeText, ArrLogicOpeValue)

            For i = 0 To tblTemp.Rows.Count - 1
                If Session("ddlOperator2") = tblTemp.Rows(i).Item("ValueField") Then
                    ddlOperator2.SelectedIndex = i
                    Exit For
                End If
            Next
            For i = 0 To tblTemp.Rows.Count - 1
                If Session("ddlOperator3") = tblTemp.Rows(i).Item("ValueField") Then
                    ddlOperator3.SelectedIndex = i
                    Exit For
                End If
            Next
            Select Case Session("Display")
                Case "MARC"
                    optMARC.Checked = True
                Case "ISBD"
                    optISBD.Checked = True
                Case Else
                    optSimple.Checked = True
            End Select
        End Sub
        ' Method: BindJS
        ' Purpose: This method used to init all objects
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            lnkZServerList.NavigateUrl = "javascript:openModal('WZServerList.aspx','WZServerList',400,350,160,100,'yes','',0);"

            btnSearch.Attributes.Add("onClick", "return CheckformZ3950('" & ddlLabelZ.Items(2).Text & "','" & ddlLabelZ.Items(3).Text & "','" & ddlLabelZ.Items(4).Text & "','" & ddlLabelZ.Items(0).Text & "','" & ddlLabelZ.Items(1).Text & "');")
            btnReset.Attributes.Add("onClick", "document.forms[0].reset();return false;")
        End Sub

        ' Method: BindControl
        Private Sub BindControl()
            Dim tblTemp As New DataTable

            ' txtzServer TextBox
            txtzServer.Text = Session("zServer")
            txtZPort.Text = Session("zPort")
            txtZDatabase.Text = Session("zDatabase")

            ' Operator dropdownlist
            Dim ArrLogicOpeText() As String = {"AND", "OR", "NOT"}
            Dim ArrLogicOpeValue() As String = {"AND", "OR", "AND NOT"}

            tblTemp = CreateTable(ArrLogicOpeText, ArrLogicOpeValue)
            ddlOperator2.DataSource = tblTemp
            ddlOperator2.DataTextField = "TextField"
            ddlOperator2.DataValueField = "ValueField"
            ddlOperator2.DataBind()
            ddlOperator3.DataSource = tblTemp
            ddlOperator3.DataTextField = "TextField"
            ddlOperator3.DataValueField = "ValueField"
            ddlOperator3.DataBind()
            tblTemp.Clear()

            ' FieldName dropdownlist
            Dim ArrFieldNameText() As String = {ddlLabel.Items(0).Text, ddlLabel.Items(1).Text, ddlLabel.Items(2).Text, ddlLabel.Items(3).Text, ddlLabel.Items(4).Text, ddlLabel.Items(5).Text, ddlLabel.Items(6).Text, ddlLabel.Items(7).Text}
            Dim ArrFieldNameValue() As String = {"@attr 1=4", "@attr 1=5", "@attr 1=1", "@attr 1=2", "@attr 1=21", "@attr 1=7", "@attr 1=8", "@attr 1=1016"}

            tblTemp = CreateTable(ArrFieldNameText, ArrFieldNameValue)
            ddlFieldName1.DataSource = tblTemp
            ddlFieldName1.DataTextField = "TextField"
            ddlFieldName1.DataValueField = "ValueField"
            ddlFieldName1.DataBind()
            ddlFieldName2.DataSource = tblTemp
            ddlFieldName2.DataTextField = "TextField"
            ddlFieldName2.DataValueField = "ValueField"
            ddlFieldName2.DataBind()
            ddlFieldName3.DataSource = tblTemp
            ddlFieldName3.DataTextField = "TextField"
            ddlFieldName3.DataValueField = "ValueField"
            ddlFieldName3.DataBind()
            tblTemp.Clear()

            ' Release object
            'tblTemp.Dispose()
            'tblTemp = Nothing
        End Sub

        ' btnSearch_Click event
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Session("zServer") = txtzServer.Text.Trim
            Session("zPort") = txtZPort.Text.Trim
            Session("zDatabase") = txtZDatabase.Text.Trim
            Session("ddlFieldName1") = ddlFieldName1.SelectedValue
            Session("ddlFieldName2") = ddlFieldName2.SelectedValue
            Session("ddlFieldName3") = ddlFieldName3.SelectedValue
            Session("txtFieldValue1") = txtFieldValue1.Text.Trim
            Session("txtFieldValue2") = txtFieldValue2.Text.Trim
            Session("txtFieldValue3") = txtFieldValue3.Text.Trim
            Session("ddlOperator2") = ddlOperator2.SelectedValue
            Session("ddlOperator3") = ddlOperator3.SelectedValue
            If optMARC.Checked Then
                Session("Display") = "MARC"
            ElseIf optISBD.Checked Then
                Session("Display") = "ISBD"
            Else
                Session("Display") = "SIMPLE"
            End If
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'>self.location.href='WZFind.aspx'</script>")
        End Sub
    End Class
End Namespace