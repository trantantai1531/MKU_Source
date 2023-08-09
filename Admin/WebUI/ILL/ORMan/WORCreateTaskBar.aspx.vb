' class WORCreateTaskBar.aspx
' Puspose: 
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORCreateTaskBar
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WORCreateTaskBarJs", "<script language='javascript' src='../JS/ORMan/WORCreateTaskbar.js'></script>")
            If Request("CreateNew") & "" <> "0" Then
                Page.RegisterClientScriptBlock("LoadForm", "<script language='javascript'>parent.Workform.location.href='WORCreate.aspx';</script>")
                btnProcess.Attributes.Add("OnClick", "javascript:if(confirm('" & ddlLabel.Items(0).Text & "')){parent.Sentform.location.href='../WRequestTaskBar.aspx?ReqType=2';}return(false);")
            Else
                btnProcess.Attributes.Add("OnClick", "javascript:parent.Sentform.location.href='../WRequestTaskBar.aspx?ReqType=2';return(false);")
            End If
            btnCreate.Attributes.Add("OnClick", "javascript:Submitform('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "','" & Session("DateFormat") & "');return(false);")
            btnReset.Attributes.Add("OnClick", "javascript:parent.Workform.document.forms[0].reset();return(false);")
            ckbReview.Attributes.Add("OnClick", "javascript:SetStatus();")
        End Sub

    End Class
End Namespace

