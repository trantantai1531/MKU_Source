' Class: WCatalogue
' Puspose: Show catalogue form
' Creator: Oanhtn
' CreatedDate: 01/02/2005
' Modification History:
'   - 17/02/2005 by Oanhtn: write update & delete functions

Imports System
Imports System.Math
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WCatalogue
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txb011 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txb012 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txb010 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txb020 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txb030 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txb040 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Textbox10 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Button16 As System.Web.UI.WebControls.Button
        Protected WithEvents Button17 As System.Web.UI.WebControls.Button
        Protected WithEvents Textbox11 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Button18 As System.Web.UI.WebControls.Button
        Protected WithEvents Button19 As System.Web.UI.WebControls.Button
        Protected WithEvents Textbox12 As System.Web.UI.WebControls.TextBox
        Protected WithEvents Button20 As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private tblMetadataDef As DataTable
        Private objBEData As New clsBEData
        Private strJS As String = Chr(10)
        Private lngObjID As Long

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call ShowForm()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(10).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            Response.Expires = 0

            ' Get ObjectID
            If Not Request("objID") = "" Then
                lngObjID = CLng(Request("objID"))
            End If

            ' Init objBCSP object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()
            objBEData.FileID = lngObjID

            ' Get metadata define field
            tblMetadataDef = GetMetadataDef()
        End Sub

        ' BindJS method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = ""javascript"" src = ""../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & """></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/EData/WCatalogue.js'></script>")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return false;")
            btnDelete.Attributes.Add("OnClick", "if(confirm('" & ddlLabel.Items(13).Text & "')) return true;return false;")
        End Sub

        ' ShowForm method
        ' Purpose: show form
        Private Sub ShowForm()
            Dim intIndex As Integer

            ' Restore value by javascript code
            strJS = strJS & "<script language = ""javascript"">" & Chr(10)
            For intIndex = 0 To tblMetadataDef.Rows.Count - 1
                Call ShowOneRow(intIndex)
            Next
            strJS = strJS & "</script>" & Chr(10)

            ' Load form where modify object
            If hidIsLoad.Value = "0" Then
                strJS = LoadHiddenValue() & strJS
            ElseIf hidIsLoad.Value = "2" Then
                strJS = ClearFormValue() & strJS
            End If
            lblJS.Text = strJS
        End Sub

        ' ClearFormValue function
        ' Purpose: clear all value of form's controls
        Private Function ClearFormValue()
            Dim strTemp As String = ""
            Dim intIndex As Integer

            strTemp = strTemp & "<script language = ""javascript"">" & Chr(10)
            For intIndex = 0 To tblMetadataDef.Rows.Count - 1
                strTemp = strTemp & "document.forms[0].hid" & CStr(tblMetadataDef.Rows(intIndex).Item("MetadataID")).PadLeft(2, "0") & ".value='';" & Chr(10)
            Next
            strTemp = strTemp & "</script>" & Chr(10)

            Return strTemp
        End Function

        ' LoadHiddenValue method
        ' Purpose: assign value for hidden controls
        Private Function LoadHiddenValue() As String
            Dim strJSLoad As String = "<script language = ""javascript"">" & Chr(10)
            Dim intIndex As Integer
            Dim strTemp As String
            Dim strMetadataDef As String
            Dim tblData As DataTable
            Dim dtrow() As DataRow
            Dim intSubIndex As Integer

            ' Get metadata of the selected object
            tblData = objBEData.GetMetadata
            Call WriteErrorMssg(ddlLabel.Items(8).Text, objBEData.ErrorMsg, ddlLabel.Items(9).Text, objBEData.ErrorCode)

            For intIndex = 0 To tblMetadataDef.Rows.Count - 1
                strMetadataDef = tblMetadataDef.Rows(intIndex).Item("MetadataID")
                If CInt(tblMetadataDef.Rows(intIndex).Item("MetadataID")) < 10 Then
                    strMetadataDef = "0" & strMetadataDef
                End If
                dtrow = tblData.Select("MetadataID=" & tblMetadataDef.Rows(intIndex).Item("MetadataID"))
                If dtrow.Length > 0 Then
                    For intSubIndex = 0 To dtrow.Length - 1
                        strTemp = strTemp & EscDoubleQuote(dtrow(intSubIndex).Item("DisplayEntry")) & "$&"
                    Next
                End If
                If Not strTemp = "" Then
                    strJSLoad = strJSLoad & "document.forms[0].hid" & strMetadataDef & ".value='" & strTemp & "';" & Chr(10)
                End If
                strTemp = ""
            Next
            strJSLoad = strJSLoad & "</script>" & Chr(10)

            ' Load form where modify object
            hidIsLoad.Value = "1"
            Return strJSLoad
        End Function

        ' ShowOneRow method
        ' Purpose: show one row of form
        Private Sub ShowOneRow(ByVal intIndex As Integer)
            ' Declare variables
            Dim tblRow As TableRow
            Dim tblCell As TableCell

            Dim btnEData As Button
            Dim lblEData As Label
            Dim txbEData As TextBox
            Dim strTemp As String = ""
            Dim strMess1 As String = ddlLabel.Items(0).Text
            Dim strMess2 As String = ddlLabel.Items(1).Text

            tblRow = New TableRow

            strTemp = tblMetadataDef.Rows(intIndex).Item("MetadataID")
            If CInt(tblMetadataDef.Rows(intIndex).Item("MetadataID")) < 10 Then
                strTemp = "0" & tblMetadataDef.Rows(intIndex).Item("MetadataID")
            End If

            ' Add label
            lblEData = New Label
            lblEData.ID = "lb" & strTemp
            lblEData.Text = tblMetadataDef.Rows(intIndex).Item("Metadata")
            lblEData.CssClass = "lbLabel"

            tblCell = New TableCell
            tblCell.Controls.Add(lblEData)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            tblCell.Width = Unit.Percentage(12)
            tblRow.Controls.Add(tblCell)

            ' Add textbox
            txbEData = New TextBox
            txbEData.ID = "txb" & strTemp
            txbEData.CssClass = "lbTextbox"
            txbEData.Width = Unit.Percentage(100)
            txbEData.Attributes.Add("OnChange", "UpdateRecord('" & strTemp & "')")
            txbEData.Attributes.Add("OnFocus", "ChangeTab('" & strTemp & "')")

            tblCell = New TableCell
            tblCell.Controls.Add(txbEData)
            tblRow.Controls.Add(tblCell)

            ' Add navigate buttons
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(26)
            tblCell.HorizontalAlign = HorizontalAlign.Left

            ' Move first
            btnEData = New Button
            btnEData.ID = "btn" & strTemp & "1"
            btnEData.CssClass = "lbButton"
            btnEData.Text = "|<"
            btnEData.Width = Unit.Pixel(20)
            btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" & strTemp & "', 1, '" & strMess1 & "', '" & strMess2 & "'); return false;")
            btnEData.ToolTip = ddlLabel.Items(2).Text
            tblCell.Controls.Add(btnEData)
            tblCell.Controls.Add(New LiteralControl(" "))

            ' Move prev
            btnEData = New Button
            btnEData.ID = "btn" & strTemp & "2"
            btnEData.CssClass = "lbButton"
            btnEData.Text = "<"
            btnEData.Width = Unit.Pixel(20)
            btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" & strTemp & "', parseInt(document.forms[0].nr" & strTemp & "1.value)-1, '" & strMess1 & "', '" & strMess2 & "'); return false;")
            btnEData.ToolTip = ddlLabel.Items(3).Text
            tblCell.Controls.Add(btnEData)
            tblCell.Controls.Add(New LiteralControl(" "))

            ' Add nr1 textbox
            txbEData = New TextBox
            txbEData.ID = "nr" & strTemp & "1"
            txbEData.CssClass = "lbTextbox"
            txbEData.Width = Unit.Pixel(25)
            txbEData.Enabled = False
            txbEData.Text = 0
            tblCell.Controls.Add(txbEData)
            tblCell.Controls.Add(New LiteralControl(" "))

            ' Move next
            btnEData = New Button
            btnEData.ID = "btn" & strTemp & "3"
            btnEData.CssClass = "lbButton"
            btnEData.Text = ">"
            btnEData.Width = Unit.Pixel(20)
            btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" & strTemp & "', parseInt(document.forms[0].nr" & strTemp & "1.value)+1, '" & strMess1 & "', '" & strMess2 & "'); return false;")
            btnEData.ToolTip = ddlLabel.Items(4).Text
            tblCell.Controls.Add(btnEData)
            tblCell.Controls.Add(New LiteralControl(" "))

            ' Move last
            btnEData = New Button
            btnEData.ID = "btn" & strTemp & "4"
            btnEData.CssClass = "lbButton"
            btnEData.Text = ">|"
            btnEData.Width = Unit.Pixel(20)
            btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" & strTemp & "', parseInt(document.forms[0].nr" & strTemp & "2.value), '" & strMess1 & "', '" & strMess2 & "'); return false;")
            btnEData.ToolTip = ddlLabel.Items(5).Text
            tblCell.Controls.Add(btnEData)
            tblCell.Controls.Add(New LiteralControl(" "))

            ' New
            btnEData = New Button
            btnEData.ID = "btn" & strTemp & "5"
            btnEData.CssClass = "lbButton"
            btnEData.Text = ">*"
            btnEData.Width = Unit.Pixel(20)
            btnEData.Attributes.Add("OnClick", "javascript:AddNewRecord('" & strTemp & "', 'document.forms[0].nr" & strTemp & "1', 'document.forms[0].nr" & strTemp & "2'); return false;")
            btnEData.ToolTip = ddlLabel.Items(6).Text
            tblCell.Controls.Add(btnEData)
            tblCell.Controls.Add(New LiteralControl(" "))

            ' Add nr2 textbox
            txbEData = New TextBox
            txbEData.ID = "nr" & strTemp & "2"
            txbEData.CssClass = "lbTextbox"
            txbEData.Width = Unit.Pixel(25)
            txbEData.Enabled = False
            txbEData.Text = 0
            tblCell.Controls.Add(txbEData)
            tblCell.Controls.Add(New LiteralControl(" "))

            ' Delete
            btnEData = New Button
            btnEData.ID = "btn" & strTemp & "6"
            btnEData.CssClass = "lbButton"
            btnEData.Text = "X"
            btnEData.Width = Unit.Pixel(20)
            btnEData.Attributes.Add("OnClick", "javascript:DeleteRecord('" & strTemp & "', parseInt(document.forms[0].nr" & strTemp & "1.value)); return false;")
            btnEData.ToolTip = ddlLabel.Items(7).Text
            tblCell.Controls.Add(btnEData)

            ' Add cell to row
            tblRow.Controls.Add(tblCell)

            ' Add row to table
            tblDetail.Controls.Add(tblRow)

            ' Create JS string
            strJS = strJS & "LoadRecNo('" & strTemp & "')" & Chr(10)
            strJS = strJS & "ViewRecord('" & strTemp & "', 1, '', '')" & Chr(10)
        End Sub

        ' btnUpdate_Click event
        ' Purpose: update edata record
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strControlName As String
            Dim intCounter As Integer = 0
            Dim intIndex As Integer = 0
            Dim arrTemp()
            Dim arrFieldName()
            Dim arrFieldValue()
            Dim strFieldIDs As String = ""
            Dim strMetadata As String = ""

            For Each strControlName In Request.Form
                If Left(strControlName, 3) = "hid" And Not Trim(Request.Form(strControlName)) = "" And Not LCase(strControlName) = "hidisload" Then
                    arrTemp = Split(CStr(Request.Form(strControlName)), "$&")
                    For intIndex = LBound(arrTemp) To UBound(arrTemp)
                        If Not Trim(arrTemp(intIndex)) = "" Then
                            strFieldIDs = strFieldIDs & CInt(Right(strControlName, Len(strControlName) - 3)) & ","
                            strMetadata = strMetadata & arrTemp(intIndex) & "$$$"
                        End If
                    Next
                End If
            Next

            If Not strFieldIDs = "" Then
                Call objBEData.UpdateMetadata(strFieldIDs, strMetadata)
                Call WriteErrorMssg(ddlLabel.Items(8).Text, objBEData.ErrorMsg, ddlLabel.Items(9).Text, objBEData.ErrorCode)
                Page.RegisterClientScriptBlock("SuccessUpdated", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "')</script>")
            Else
                Page.RegisterClientScriptBlock("ErrorUpdated", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "')</script>")
            End If
            Call ShowForm()
        End Sub

        ' GetMetadataDef method
        ' Purpose: get metadata define
        Private Function GetMetadataDef() As DataTable
            GetMetadataDef = objBEData.GetMetadataDef
            Call WriteErrorMssg(ddlLabel.Items(8).Text, objBEData.ErrorMsg, ddlLabel.Items(9).Text, objBEData.ErrorCode)
        End Function

        ' btnDelete_Click event
        ' Purpose: Delete current record
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Call objBEData.DeleteMetadata()
            Call WriteErrorMssg(ddlLabel.Items(8).Text, objBEData.ErrorMsg, ddlLabel.Items(9).Text, objBEData.ErrorCode)
            hidIsLoad.Value = "2"
            Call ShowForm()
        End Sub

        ' EscDoubleQuote function
        Public Function EscDoubleQuote(ByVal strIn As String) As String
            EscDoubleQuote = Replace(strIn, "'", "\'")
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                objBEData.Dispose(True)
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace