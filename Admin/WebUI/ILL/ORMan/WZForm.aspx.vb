Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WZForm
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

        Private objBDB As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            If Not Page.IsPostBack Then
                ' Reset all sessions
                Session("zServer") = "192.168.50.199"
                Session("zPort") = "210"
                Session("zDatabase") = "Libol"
                Session("ddlFieldName1") = ""
                Session("ddlFieldName2") = ""
                Session("ddlFieldName3") = ""
                Session("txtFieldValue1") = ""
                Session("txtFieldValue2") = ""
                Session("txtFieldValue3") = ""
                Session("ddlOperator2") = ""
                Session("ddlOperator3") = ""
                ' Bind Data
                Call BindControl()
            End If
        End Sub

        ' This method used to init all objects
        Private Sub Initialize()
            ' Init for objBDB
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            objBDB.Initialize()

            ' Resister Javascripts File
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            lnkZServerList.NavigateUrl = "javascript:openModal('WZServerList.aspx','WZServerList',400,350,160,100,'yes','',0);"
            btnSearch.Attributes.Add("onClick", "return CheckformZ3950('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(1).Text & "');")
            btnReset.Attributes.Add("onClick", "document.forms[0].reset();return false;")
        End Sub

        ' BindControl method
        Private Sub BindControl()
            Dim tblTemp As New DataTable

            ' txtzServer TextBox
            txtzServer.Text = Session("zServer")
            txtZPort.Text = Session("zPort")
            txtZDatabase.Text = Session("zDatabase")

            ' Operator dropdownlist
            Dim ArrLogicOpeText() As String = {"AND", "OR", "NOT"}
            Dim ArrLogicOpeValue() As String = {"AND", "OR", "AND NOT"}
            tblTemp = objBDB.CreateTable(ArrLogicOpeText, ArrLogicOpeValue)
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
            Dim ArrFieldNameText() As String = {lblTitle.Text, lblSeri.Text, lblAuthor.Text, lblAuthorGr.Text, lblSubject.Text, lblISBN.Text, lblISSN.Text, lblAllFields.Text}
            Dim ArrFieldNameValue() As String = {"@attr 1=4", "@attr 1=5", "@attr 1=1", "@attr 1=2", "@attr 1=21", "@attr 1=7", "@attr 1=8", "@attr 1=1016"}
            tblTemp = objBDB.CreateTable(ArrFieldNameText, ArrFieldNameValue)
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
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' btnSearch_Click event
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Session("zServer") = txtzServer.Text
            Session("zPort") = txtZPort.Text
            Session("zDatabase") = txtZDatabase.Text
            Session("ddlFieldName1") = ddlFieldName1.SelectedValue
            Session("ddlFieldName2") = ddlFieldName2.SelectedValue
            Session("ddlFieldName3") = ddlFieldName3.SelectedValue
            Session("txtFieldValue1") = txtFieldValue1.Text
            Session("txtFieldValue2") = txtFieldValue2.Text
            Session("txtFieldValue3") = txtFieldValue3.Text
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

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBDB Is Nothing Then
                    objBDB.Dispose(True)
                    objBDB = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace