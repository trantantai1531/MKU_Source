Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WTaskBarFunc
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
        Private objBCN As New clsBCopyNumber
        ' Evemt: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call LoadButton()
            If Not Page.IsPostBack Then
                Call LoadData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init for objBCN
            objBCN.InterfaceLanguage = Session("InterfaceLanguage")
            objBCN.DBServer = Session("DBServer")
            objBCN.ConnectionString = Session("ConnectionString")
            objBCN.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Dim intUbound As Integer
            Dim bytMode As Byte
            Page.RegisterClientScriptBlock("DeclareVar", "<script language='javascript'>var strNote='" & lblNote.Text & "';var strNote1='" & lblNote1.Text & "';</script>")
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Location/WTaskBarFunc.js'></script>")

            btnLock.Attributes.Add("Onclick", "return Lock();")
            btnUnlock.Attributes.Add("Onclick", "return UnLock();")
            btnRemove.Attributes.Add("Onclick", "return Remove();")

            btnReceiveUnlock.Attributes.Add("OnClick", "return ReceiveUnlock();")
            btnReceive.Attributes.Add("Onclick", "return Receive();")

            btnRestore.Attributes.Add("OnClick", "return Restore();")
            btnRestoreUnlock.Attributes.Add("OnClick", "return RestoreUnlock();")

            btnSearch.Attributes.Add("Onclick", "return Search();")
            btnDelete.Attributes.Add("Onclick", "return Delete();")
            intUbound = 0
            If Not Session("IDs") Is Nothing Then
                If IsArray(Session("IDs")) AndAlso UBound(Session("IDs")) >= 0 Then
                    intUbound = Math.Ceiling((UBound(Session("IDs")) + 1) / 20)
                    'intUbound = Round(UBound(Session("IDs")) / 20 + 0.5)
                End If
            End If
            lblUboundPage.Text = intUbound & " "
            If Trim(Request.QueryString("Mode") & "") <> "" Then
                bytMode = Request.QueryString("Mode")
            Else
                bytMode = 0 ' default received
            End If
            If CStr(Session("LibID")) <> "" Then
                hrfPrevious.Attributes.Add("OnClick", "javascript:PreviousPage(" & intUbound & "," & Session("LibID") & "," & Session("LocID") & ",'" & Session("Shelf") & "','" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(1).Text & "'," & bytMode & ");")
                hrfNext.Attributes.Add("OnClick", "javascript:NextPage(" & intUbound & "," & Session("LibID") & "," & Session("LocID") & ",'" & Session("Shelf") & "','" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(2).Text & "'," & bytMode & ");")
                txtCurrentPage.Attributes.Add("onKeyDown", "javascript:if(event.keyCode == 13 || event.which == 13 ) {CurrentPageChange(" & intUbound & "," & Session("LibID") & "," & Session("LocID") & ",'" & Session("Shelf") & "','" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(3).Text & "'," & bytMode & ");return false;}")
            Else
                hrfPrevious.Visible = False
                hrfNext.Visible = False
                txtCurrentPage.Visible = False
                lblUboundPage.Visible = False
                lblInPage.Visible = False
                lblTotalPage.Visible = False
            End If
        End Sub

        ' LoadButton method
        Private Sub LoadButton()
            Dim bytMode As Byte
            If Trim(Request.QueryString("Mode") & "") <> "" Then
                bytMode = Request.QueryString("Mode")
            Else
                bytMode = 1
            End If
            Select Case bytMode
                Case 0 ' chua kiem nhan
                    btnReceive.Visible = True
                    btnReceiveUnlock.Visible = True
                    btnDelete.Visible = False
                    ' Check permission
                    If Not CheckPemission(132) Then
                        btnReceive.Enabled = False
                        btnReceiveUnlock.Enabled = False
                        btnSearch.Enabled = False
                    End If
                Case 1 ' trong kho
                    lblReason.Visible = True
                    ddlReasonID.Visible = True
                    btnLock.Visible = True
                    btnUnlock.Visible = True
                    btnRemove.Visible = True
                    btnDelete.Visible = False
                    ' Check permission
                    If Not CheckPemission(133) Then
                        btnLock.Enabled = False
                        btnUnlock.Enabled = False
                        btnRemove.Enabled = False
                        btnSearch.Enabled = False
                    End If
                Case 2 ' huy
                    btnRestore.Visible = True
                    btnRestoreUnlock.Visible = True
                    btnDelete.Visible = True
                    ' Check permission
                    If Not CheckPemission(134) Then
                        btnRestore.Enabled = False
                        btnRestoreUnlock.Enabled = False
                        btnDelete.Enabled = False
                        btnSearch.Enabled = False
                    End If
            End Select
        End Sub

        ' LoadData method
        Private Sub LoadData()
            txtCurrentPage.Text = 0
            If Not Session("IDs") Is Nothing Then
                If IsArray(Session("IDs")) AndAlso UBound(Session("IDs")) >= 0 Then
                    txtCurrentPage.Text = 1
                End If
            End If
            ddlReasonID.DataSource = objBCN.GetRemoveReason
            ddlReasonID.DataTextField = "REASON"
            ddlReasonID.DataValueField = "ID"
            ddlReasonID.DataBind()
            ddlReasonID.Items(0).Selected = True
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCN Is Nothing Then
                    objBCN.Dispose(True)
                    objBCN = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace