Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common
Imports System.IO

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WSimpleSearchResultTaskBar
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblCannotDelete1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblCannotDelete2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPC As New clsBPatronCollection
        Private objBCB As New clsBCommonBusiness

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            ' If Not IsPostBack Then
            Call ShowResult()
            Dim ArrID()
            ArrID = Session("PatronIDs")
            Call BindJS()
            If IsArray(ArrID) Then
                If ArrID.Length > 0 Then
                    If Request.QueryString("IndexIDdel") & "" <> "" Then
                        Call DeletePatron(ArrID(CInt(Request.QueryString("IndexIDdel"))))
                    End If
                    If Request.QueryString("IndexIDReset") & "" <> "" Then
                        Call ResetPassWord(ArrID(CInt(Request.QueryString("IndexIDReset"))))
                    End If
                    If ArrID(0) <> -1 Then
                        hidPatronTotal.Value = ArrID.Length
                    End If
                End If
                'End If

            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(48) Then
                btnEdit.Enabled = False
            End If
            If Not CheckPemission(51) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCB.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WSimpleSearchResultTaskBarJs", "<script language = 'javascript' src = 'js/WSimpleSearchResultTaskBar.js?x=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            txtRec.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) {Action('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(6).Text & "');return false;}")
            txtRec.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(2).Text & "')} else {Action(); return false;}")
            btnNext.Attributes.Add("OnClick", "NextAction(); return false;")
            btnBack.Attributes.Add("OnClick", "BackAction(); return false;")
            btnFirst.Attributes.Add("OnClick", "FirstAction(); return false;")
            btnEnd.Attributes.Add("OnClick", "EndAction(); return false;")
            btnNew.Attributes.Add("OnClick", "NewClick(); return false;")
            btnEdit.Attributes.Add("OnClick", "EditClick(); return false;")
            btnDelete.Attributes.Add("OnClick", "if (!DeleteClick('" & ddlLabel.Items(4).Text & "')){return false;}")
            btnResetPass.Attributes.Add("OnClick", "if (!ResetPassClick('" & ddlLabel.Items(8).Text & "')){return false;}")
            btnSearch.Attributes.Add("OnClick", "SearchClick(); return false;")
        End Sub

        ' Method: ShowResult
        ' Purpose: show search result
        Private Sub ShowResult()
            Dim ArrID()
            If Not (Session("PatronIDs") Is Nothing) Then
                ArrID = Session("PatronIDs")
                If Not (ArrID Is Nothing) Then
                    If UBound(ArrID) > -1 Then
                        If ArrID(0) = -1 Then
                            txtRec.Text = "0"
                            lblSumRec.Text = "0"
                        Else
                            txtRec.Text = "1"
                            lblSumRec.Text = CStr(UBound(ArrID) + 1)
                        End If
                    End If
                Else
                    txtRec.Text = "0"
                    lblSumRec.Text = "0"
                    Page.RegisterClientScriptBlock("DisplayEmpty", "<script language='javascript'>parent.result.location.href='WSimpleSearchResult.aspx?IndexID=';</script>")
                End If
            Else
                txtRec.Text = "0"
                lblSumRec.Text = "0"
                Page.RegisterClientScriptBlock("DisplayEmpty", "<script language='javascript'>parent.result.location.href='WSimpleSearchResult.aspx?IndexID=';</script>")
            End If
        End Sub

        ' Method: DeletePatron
        ' Purpose: Delete selected patron method
        Private Sub DeletePatron(ByVal strID As String)
            Dim blnFound As Boolean = False

            If Trim(strID) <> "" Then
                Dim tblDeletePatron As New DataTable
                Dim tblPortrait As New DataTable
                Dim ArrIDtmp()

                objBPC.PatronIDs = strID
                tblPortrait = objBPC.GetPortraitPatronDel
                Dim strPortrait As String
                If Not tblPortrait Is Nothing Then
                    If tblPortrait.Rows.Count > 0 Then
                        If Not IsDBNull(tblPortrait.Rows(0).Item("PORTRAIT")) Then
                            strPortrait = Trim(tblPortrait.Rows(0).Item("PORTRAIT"))
                        Else
                            strPortrait = ""
                        End If
                        If Not IsDBNull(tblPortrait.Rows(0).Item("PORTRAIT")) Then
                            Try
                                strPortrait = Trim(tblPortrait.Rows(0).Item("PORTRAIT"))
                                Dim strPath As String = Server.MapPath("../Images/Card/" & strPortrait)
                                If (System.IO.File.Exists(strPath)) Then
                                    System.IO.File.Delete(strPath)
                                End If
                                'filInfo = New FileInfo(strPath)
                                'If filInfo.Exists Then
                                '    filInfo.Delete()
                                'End If
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                End If
                tblDeletePatron = objBPC.DeletePatrons()

                ' Check error
                'Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

                ' WriteLog
                Call WriteLog(30, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If Not tblDeletePatron Is Nothing AndAlso tblDeletePatron.Rows.Count > 0 Then
                    blnFound = True
                    Page.RegisterClientScriptBlock("CannotDeleteJs1", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("DeleteJs1", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                End If
                If Not blnFound Then
                    ArrIDtmp = Session("PatronIDs")
                    If IsArray(ArrIDtmp) Then
                        Dim i
                        Dim count
                        Dim ArrNewID()
                        count = 0
                        For i = 0 To UBound(ArrIDtmp)
                            If CStr(ArrIDtmp(i)) <> CStr(strID) Then
                                ReDim Preserve ArrNewID(count)
                                ArrNewID(count) = ArrIDtmp(i)
                                count = count + 1
                            End If
                        Next
                        Session("PatronIDs") = Nothing
                        If Not (ArrNewID Is Nothing) Then
                            Session("PatronIDs") = ArrNewID
                        End If
                    End If
                    Response.Redirect("WSimpleSearchResultTaskBar.aspx")
                End If
            End If
        End Sub

        '' Reset PassWord 
        Private Sub ResetPassWord(ByVal patronID As String)
            Try
                Dim strSQL = "Update Cir_tblPatron set PassWord = Cir_tblPatron.Code where ID =  " & patronID
                objBCB.ExcuteQuery(strSQL)
                Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('Đổi mật khẩu thành công!');</script>")
            Catch ex As Exception
                Page.RegisterClientScriptBlock("error", "<script language='javascript'>alert('Đổi mật khẩu không thành công!');</script>")
            End Try
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