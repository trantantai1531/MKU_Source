' Class: WGenCopyNumListF
' Puspose: process generate list copynumber
' Creator: lent
' CreatedDate: 21/02/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WGenCopyNumListF
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
        Private objBLibrary As New clsBLibrary
        Private objBLocation As New clsBLocation

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call LoadLibraries()
            End If
        End Sub

        ' Method: Initialize 
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Initialize objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()
        End Sub

        ' Method: CheckPermission
        ' Purpose: Check permission
        Private Sub CheckPermission()
            If Not CheckPemission(120) Then
                Call WriteErrorMssg(ddlLabelNote.Items(2).Text)
            End If
        End Sub

        ' Method: BindJavascript 
        ' Purpose: Include all need js functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnReset.Attributes.Add("onclick", "javascript:document.forms[0].reset(); return false;")

            txtCopyNum1Page.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabelNote.Items(3).Text & "'); this.value = 20;};if (this.value == '0') {alert('" & ddlLabelNote.Items(5).Text & "');this.value='';this.focus(); return false;};")
        End Sub

        ' Method: LoadLibraries 
        ' Purpose: Load list of libraries in to dropdownlist
        Private Sub LoadLibraries()
            Dim tblResult As DataTable
            Dim listItem As New listItem
            ' Get list of libraies
            objBLibrary.UserID = Session("UserID")
            objBLibrary.LibID = clsSession.GlbSite
            tblResult = objBLibrary.GetLibrary(1)
            ' Bind data for dropdownlist library
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                ddlLibrary.DataSource = InsertOneRow(tblResult, ddlLabelNote.Items(4).Text)
                ddlLibrary.DataTextField = "FullName"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
                ddlLibrary.SelectedIndex = 0
                Call BindData()
            Else
                btnGenList.Enabled = False
                btnReset.Enabled = False
            End If
            tblResult = Nothing
        End Sub

        ' Method: BindData 
        ' Purpose: Load locations of the selected library
        Private Sub BindData()
            Dim tblResult As DataTable

            ' Get list of locations of the selected library
            objBLocation.UserID = Session("UserID")
            objBLocation.LibID = ddlLibrary.SelectedValue
            objBLocation.Status = 1
            tblResult = objBLocation.GetLocation
            ' Bind data for dropdownlist location
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlLocation.DataSource = tblResult
                    ddlLocation.DataTextField = "Symbol"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()
                End If
                tblResult = Nothing
            End If
        End Sub

        ' Event: ddlLibrary_SelectedIndexChanged
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            Call BindData()
        End Sub

        ' Event: btnGenList_Click
        Private Sub btnGenList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenList.Click
            Dim strLocation As String
            If ddlLocation.SelectedValue = "" Then
                strLocation = ""
            Else
                strLocation = ddlLocation.SelectedItem.Text
            End If
            Session("InforListCopyNum") = ddlLibrary.SelectedValue & "," & ddlLocation.SelectedValue & "," & txtShelf.Text & "," & txttoCopyNum.Text & "," & txtfromCopyNum.Text & "," & txtCopyNum1Page.Text & "," & strLocation
            Response.Redirect("WGenCopyNumberFrame.aspx")
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method : Dispose 
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace