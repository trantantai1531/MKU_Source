Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WILLBook
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

        Private objBILLOut As New clsBOPACILLOutGoingReq
        Private objBCommon As New clsBCommonDBSystem
        ' Page_load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()

            If Not IsPostBack Then
                Dim tblTemp As DataTable
                objBCommon.SQLStatement = "select * from ACQ_Currency"
                tblTemp = objBCommon.RetrieveItemInfor
                ' Check error
                ddlCurrency.DataSource = tblTemp
                ddlCurrency.DataTextField = "CurrencyCode"
                ddlCurrency.DataValueField = "CurrencyCode"
                ddlCurrency.DataBind()
            End If

        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBILLOut
            objBILLOut.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBILLOut.DBServer = Session("DBServer")
            objBILLOut.ConnectionString = Session("ConnectionString")
            objBILLOut.Initialize()

            objBCommon.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommon.DBServer = Session("DBServer")
            objBCommon.ConnectionString = Session("ConnectionString")
            objBCommon.Initialize()

        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/ILL/WILLBook.js'></script>")

            txtPubDate.Attributes.Add("onchange", "if (!CheckDate(this,'dd/mm/yyyy','" & lblMsgInvalidDate.Text & "')) return false;")
            txtExpireDate.Attributes.Add("onchange", "if (!CheckDate(this,'dd/mm/yyyy','" & lblMsgInvalidDate.Text & "')) return false;")
            txtMaxCost.Attributes.Add("onchange", "return CheckNumBer(this,'" & lblMsgInvalidNumber.Text & "');")

            btnPostRequest.Attributes.Add("Onclick", "javascript:return CheckValid('" & lblMsg1.Text & "','" & lblMsg2.Text & "','" & lblMsg3.Text & "','" & lblMsg4.Text & "','" & lblMsgInvalidDate.Text & "','" & lblMsg6.Text & "','" & lblMsg7.Text & "');")
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset();return false;")
            'lnkCal.Attributes.Add("onclick", "OpenWindow('../Common/WCalendar.aspx?id=opener.document.forms[0].txtExpireDate','Calendar',200,256,220,100);return false;")
            'lnkPubDate.Attributes.Add("onclick", "OpenWindow('../Common/WCalendar.aspx?id=opener.document.forms[0].txtPubDate','Calendar',200,256,220,100);return false;")
            Me.RegisterCalendar("../")
            SetOnclickCalendar(lnkCal, "txtExpireDate")
            SetOnclickCalendar(lnkPubDate, "txtPubDate")
        End Sub

        ' PostRequest_Click event
        Private Sub btnPostRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostRequest.Click
            Call PostRequest()
        End Sub

        ' PostRequest method
        Private Sub PostRequest()
            Dim strNote As String
            Dim intRetval As Integer
            objBILLOut.Type = 1
            objBILLOut.PatronCode = txtCardNum.Text
            objBILLOut.Password = txtPassword.Text
            objBILLOut.PubDate = txtPubDate.Text
            objBILLOut.NeedBeforeDate = txtExpireDate.Text
            If txtMaxCost.Text <> "" Then objBILLOut.MaxCost = txtMaxCost.Text
            objBILLOut.CurrencyCode = ddlCurrency.SelectedValue

            strNote = ""
            If txtFoundAt.Text <> "" Then
                strNote = strNote & lblDisOtherInfor.Text & ": " & Trim(txtFoundAt.Text) & ". "
            End If
            If txtOtherInfor.Text <> "" Then
                strNote = strNote & txtOtherInfor.Text
            End If
            objBILLOut.Note = strNote
            objBILLOut.Title = txtTitle.Text
            objBILLOut.Author = txtAuthor.Text
            intRetval = objBILLOut.CreateRequest
            Select Case intRetval
                Case 3
                    Page.RegisterClientScriptBlock("PatronError", "<Script language='JavaScript'>alert('" & lblMsgCreateFail.Text & "')</Script>")
                Case 1
                    hidReset.Value = 1
                    Page.RegisterClientScriptBlock("CreateSuccess", "<Script language='JavaScript'>alert('" & lblMsgCreateSuccess.Text & "')</Script>")
                Case 2
                    Page.RegisterClientScriptBlock("CreateFail", "<Script language='JavaScript'>alert('" & lblMsg5.Text & "')</Script>")
                Case 0
                    Page.RegisterClientScriptBlock("CreateError", "<Script language='JavaScript'>alert('" & lblError.Text & "')</Script>")
            End Select
            'If intRetval = 1 Then
            '    hidReset.Value = 1
            '    Page.RegisterClientScriptBlock("CreateSuccess", "<Script language='JavaScript'>alert('" & lblMsgCreateSuccess.Text & "')</Script>")
            'ElseIf intRetval = 2 Then
            '    Page.RegisterClientScriptBlock("CreateFail", "<Script language='JavaScript'>alert('" & lblMsg5.Text & "')</Script>")
            'Else
            '    Page.RegisterClientScriptBlock("CreateFail", "<Script language='JavaScript'>alert('" & lblMsgCreateFail.Text & "')</Script>")
            'End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOut Is Nothing Then
                    objBILLOut.Dispose(True)
                    objBILLOut = Nothing
                End If
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace