' Class: WOverduePrintLetter
' Puspose: Display to Print Overdue Patron
' Creator: Sondp
' CreatedDate: 27/8/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOrverduePrintLetterResult
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

        ' Declare some variables
        Private objBOverdueTransaction As New clsBOverdueTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                lblPrintLetter.Text = ""
                If Not Request("ddlOverdueTemplate") Is Nothing And CInt(Request("ddlOverdueTemplate")) > 0 Then
                    Call BindData()
                    If Not Request("txtOverduePatron") = "" Then
                        objBOverdueTransaction.DueTime = CInt(Request("txtOverduePatron"))
                    Else
                        objBOverdueTransaction.DueTime = 1
                    End If
                    objBOverdueTransaction.UserID = Session("UserID")
                    objBOverdueTransaction.OverduePrintMode = CShort(Request("txtOverduePrintMode"))
                    objBOverdueTransaction.Logic = Request("ddlOverduePatron")
                    objBOverdueTransaction.PickPatronIDs = Request("txtPickPatron")
                    objBOverdueTransaction.OverdueTemplateID = CInt(Request("ddlOverdueTemplate"))
                    objBOverdueTransaction.LibID = clsSession.GlbSite
                    lblPrintLetter.Text = objBOverdueTransaction.GetOverduePatronPrint
                    ' WriteLog
                    Call WriteLog(108, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                Else ' don't have any request
                    Response.Write(lblError.Text)
                End If
                If lblPrintLetter.Text.Trim = "" Then
                    Page.RegisterClientScriptBlock("NotFoundJs", "<script language='javascript'>alert('" & lblError.Text & "');window.location.href='WOverduePrintLetter.aspx';</script>")
                End If
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            'Init objBOverdueTransaction
            objBOverdueTransaction.ConnectionString = Session("ConnectionString")
            objBOverdueTransaction.DBServer = Session("DBServer")
            objBOverdueTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTransaction.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData()
            objBOverdueTransaction.MainRowTitle.Add(lblItemCode.Text, "ITEMCODE")
            objBOverdueTransaction.MainRowTitle.Add(lblCopyNumber.Text, "COPYNUMBER")
            objBOverdueTransaction.MainRowTitle.Add(lblItemTitle.Text, "ITEMTITLE")
            objBOverdueTransaction.MainRowTitle.Add(lblCheckOutDate.Text, "CHECKOUTDATE")
            objBOverdueTransaction.MainRowTitle.Add(lblCheckInDate.Text, "CHECKINDATE")
            objBOverdueTransaction.MainRowTitle.Add(lblOverDueDate.Text, "OVERDUEDATE")
            objBOverdueTransaction.MainRowTitle.Add(lblPenati.Text, "PENATI")
            objBOverdueTransaction.MainRowTitle.Add(lblSequency.Text, "SEQUENCY")
            objBOverdueTransaction.MainRowTitle.Add(lblLibrary.Text, "LIBRARY")
            objBOverdueTransaction.MainRowTitle.Add(lblStore.Text, "STORE")
            objBOverdueTransaction.MainRowTitle.Add(lblNote.Text, "NOTE")
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOverdueTransaction Is Nothing Then
                    objBOverdueTransaction.Dispose(True)
                    objBOverdueTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace