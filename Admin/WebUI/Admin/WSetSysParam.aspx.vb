' Class: WSetSysParam
' Puspose: Management sys's parameters
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WSetSysParam
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

        Dim objBCSP As New clsBCommonStringProc
        Dim objBParameter As New clsBParameter

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Session("UserID") = 1 Then
                Call WriteErrorMssg(ddlLabel.Items(5).Text)
            End If
            Call Initialize()
            Call BindScript()
            Call ShowParams()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBParameter object
            objBParameter.ConnectionString = Session("ConnectionString")
            objBParameter.DBServer = Session("DBServer")
            objBParameter.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBParameter.Initialize()

            ' Init objBCSP object
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCSP.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WSetSysParam.js'></script>")

            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnUpdate.Attributes.Add("OnClick", "if (document.forms[0].hidAlterParams.value=='') {alert('" & ddlLabel.Items(6).Text & "'); return false;}")
        End Sub

        ' ShowParams method
        ' Purpose: show all system's parameters
        Private Sub ShowParams()
            Dim tblParameters As New DataTable
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim litOption As ListItem
            Dim chkParam As CheckBox
            Dim ddlParam As DropDownList
            Dim txtParam As TextBox
            Dim intCount As Integer
            Dim intMax As Integer
            Dim objOptions() As Object
            Dim intIndex As Integer

            tblParams.CssClass = "lbGrid"
            ' Show all system parameters
            tblParameters = objBParameter.GetParamInfor()
            If Not tblParameters Is Nothing Then
                If tblParameters.Rows.Count > 0 Then
                    ' Create header for parameters
                    tblRow = New TableRow
                    tblRow.HorizontalAlign = HorizontalAlign.Center
                    tblRow.CssClass = "lbGridHeader"
                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(2).Text))
                    tblRow.Cells.Add(tblCell)
                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
                    tblRow.Cells.Add(tblCell)
                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
                    tblRow.Cells.Add(tblCell)
                    tblParams.Rows.Add(tblRow)

                    For intCount = 0 To tblParameters.Rows.Count - 1
                        tblRow = New TableRow
                        If intCount Mod 2 = 0 Then
                            tblRow.CssClass = "lbGridCell"
                        Else
                            tblRow.CssClass = "lbGridAlterCell"
                        End If

                        ' Add Name Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(New LiteralControl(tblParameters.Rows(intCount).Item("Name")))
                        ' tblCell.CssClass = "lbLabel"
                        tblRow.Cells.Add(tblCell)

                        ' Add Value Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        Select Case CInt(tblParameters.Rows(intCount).Item("Type"))
                            Case 1
                                ddlParam = New DropDownList
                                Dim obj As New ListItem
                                ddlParam.ID = tblParameters.Rows(intCount).Item("Name")
                                If Not IsDBNull(tblParameters.Rows(intCount).Item("Options")) Then
                                    Call objBCSP.GLoadArray(tblParameters.Rows(intCount).Item("Options"), objOptions, ",")
                                    For intIndex = 0 To UBound(objOptions)
                                        litOption = New ListItem
                                        litOption.Text = objOptions(intIndex)
                                        litOption.Value = objOptions(intIndex)
                                        ddlParam.Items.Add(litOption)
                                        If tblParameters.Rows(intCount).Item("Val") = objOptions(intIndex) Then
                                            ddlParam.SelectedIndex = intIndex
                                        End If
                                    Next
                                End If
                                ddlParam.Attributes.Add("OnChange", "MarkChange('" & tblParameters.Rows(intCount).Item("Name") & "')")
                                tblCell.Controls.Add(ddlParam)
                            Case 2
                                chkParam = New CheckBox
                                If CInt(tblParameters.Rows(intCount).Item("Val")) = 1 Then
                                    chkParam.Checked = True
                                End If
                                chkParam.ID = tblParameters.Rows(intCount).Item("Name")
                                chkParam.CssClass = "lbCheckBox"
                                chkParam.Attributes.Add("OnClick", "MarkChange('" & tblParameters.Rows(intCount).Item("Name") & "')")
                                tblCell.Controls.Add(chkParam)
                            Case 3
                                txtParam = New TextBox
                                txtParam.Text = tblParameters.Rows(intCount).Item("Val")
                                txtParam.ID = tblParameters.Rows(intCount).Item("Name")
                                txtParam.CssClass = "lbTextBox"
                                txtParam.Attributes.Add("OnChange", "MarkChange('" & tblParameters.Rows(intCount).Item("Name") & "')")
                                tblCell.Controls.Add(txtParam)
                            Case 4
                                txtParam = New TextBox
                                txtParam.TextMode = TextBoxMode.Password
                                txtParam.Text = tblParameters.Rows(intCount).Item("Val")
                                txtParam.ID = tblParameters.Rows(intCount).Item("Name")
                                txtParam.CssClass = "lbTextBox"
                                txtParam.Attributes.Add("OnChange", "MarkChange('" & tblParameters.Rows(intCount).Item("Name") & "')")
                                tblCell.Controls.Add(txtParam)
                            Case 5
                                txtParam = New TextBox
                                txtParam.Text = tblParameters.Rows(intCount).Item("Val")
                                txtParam.ID = tblParameters.Rows(intCount).Item("Name")
                                txtParam.CssClass = "lbTextBox"
                                txtParam.TextMode = TextBoxMode.Password
                                txtParam.Attributes.Add("OnChange", "MarkChange('" & tblParameters.Rows(intCount).Item("Name") & "')")
                                tblCell.Controls.Add(txtParam)
                        End Select
                        tblRow.Cells.Add(tblCell)

                        ' Add Description Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        If Not IsDBNull(tblParameters.Rows(intCount).Item("Description")) Then
                            tblCell.Controls.Add(New LiteralControl(tblParameters.Rows(intCount).Item("Description")))
                        Else
                            tblCell.Controls.Add(New LiteralControl("&nbsp;"))
                        End If
                        ' tblCell.CssClass = "lbLabel"
                        tblRow.Cells.Add(tblCell)

                        ' Add row aboved to table
                        tblParams.Rows.Add(tblRow)
                    Next
                End If
            End If
        End Sub

        ' btnUpdate_Click event
        ' Purpose: Update system parameters (changed parameters only)
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim objParams()
            Dim Param
            Dim strAlterParams As String = hidAlterParams.Value
            Dim strAlterValues As String = ""
            Dim strParam As String = ""
            Dim intRetval As Integer = 0

            strAlterParams = Left(strAlterParams, Len(strAlterParams) - 1)
            objParams = Split(strAlterParams, "#")
            For Each Param In objParams
                strParam = Request(Param)
                If UCase(strParam) = "ON" Then
                    strParam = 1
                ElseIf Trim(strParam) = "" Then
                    strParam = "0"
                End If
                ''PhuongTT 20080929
                ''B1
                'If Param = "SMTP_PASS" Then
                '    If strParam <> "" Then
                '        strParam = objBCSP.EncryptedPassword(strParam)
                '    End If
                'End If
                'B2

                strAlterValues = strAlterValues & strParam & "#"
            Next
            strAlterParams = strAlterParams & "#"
            strAlterValues = Left(strAlterValues, Len(strAlterValues))



            intRetval = objBParameter.UpdateParamInfor(strAlterParams, strAlterValues)
            If intRetval = 0 Then
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "')</script>")
            Else
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "')</script>")
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBParameter Is Nothing Then
                    objBParameter.Dispose(True)
                    objBParameter = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace