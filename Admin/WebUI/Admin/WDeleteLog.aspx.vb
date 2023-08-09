' Class: WDeleteLog
' Puspose: Delete log
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:
'   + 24/11/2004 by Oanhtn: write process methods

Imports System
Imports System.Web
Imports eMicLibAdmin.BusinessRules.Admin

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WDeleteLog
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

        Dim objBLog As New clsBLog

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBLog object
            objBLog.ConnectionString = Session("ConnectionString")
            objBLog.DBServer = Session("DBServer")
            objBLog.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLog.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WDeleteLog.js'></script>")
            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkToDate, txtToDate, ddlLabel.Items(2).Text)

            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].txtFromDate.value=''; document.forms[0].txtToDate.value=''; document.forms[0].txtFromTime.value=''; document.forms[0].txtToTime.value=''; document.forms[0].txtFromDate.focus(); return false;")
            btnDelete.Attributes.Add("OnClick", "if (!CheckAllInput('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "','" & Session("DateFormat") & "'))return false;")
        End Sub

        ' btnDelete_Click event
        ' Purpose: delete logs
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim strFromDate As String = Trim(txtFromDate.Text.Trim)
            Dim strToDate As String = Trim(txtToDate.Text.Trim)
            Dim strFromTime As String = Trim(txtFromTime.Text.Trim)
            Dim strToTime As String = Trim(txtToTime.Text.Trim)

            If Not strFromDate = "" Then
                If Not strFromTime = "" Then
                    strFromDate = strFromDate & " " & strFromTime
                Else
                    strFromDate = strFromDate & " 00:00:00"
                End If
            End If

            If Not strToDate = "" Then
                If Not strToTime = "" Then
                    strToDate = strToDate & " " & strToTime
                Else
                    strToDate = strToDate & " 23:59:59"
                End If
            End If

            If Not strFromDate = "" Then
                objBLog.LogTimeFrom = strFromDate
            End If
            If Not strToDate = "" Then
                objBLog.LogTimeTo = strToDate
            End If
            Call objBLog.DeleteLog()
            Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLog Is Nothing Then
                    objBLog.Dispose(True)
                    objBLog = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace