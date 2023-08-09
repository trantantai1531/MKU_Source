Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WUpdateEdata
        Inherits clsWBase

        ' Declare module variables
        Private objBEData As New clsBEData
        Private objBCommonBussiness As New clsBCommonBusiness

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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindDropdownList()
                Call BindData()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(4).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Init objBEData object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()

            ' Init objBCommonBussiness object
            objBCommonBussiness.DBServer = Session("DBServer")
            objBCommonBussiness.ConnectionString = Session("ConnectionString")
            objBCommonBussiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBussiness.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = ""javascript"" src = ""../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & """></script>")
            btnUpdate.Attributes.Add("OnClick", "javascript:if (CheckNull(document.forms[0].txtPrice)){alert('" & ddlLabel.Items(2).Text & "'); return false;}")
            txtPrice.Attributes.Add("OnChange", "javascript:return CheckNumBer(this,'" & ddlLabel.Items(1).Text & "')")
            txtPagination.Attributes.Add("OnChange", "javascript:return CheckNumBer(this,'" & ddlLabel.Items(1).Text & "')")
            btnClose.Attributes.Add("Onclick", "javascript:self.close();return false;")
            btnReset.Attributes.Add("Onclick", "javascript:document.forms[0].reset();return false;")
        End Sub

        ' BindData method
        ' Purpose: Load the edeliv file details
        Private Sub BindData()
            Dim tblEdata As DataTable
            Dim blnInvalid As Boolean = False

            If Not Request("objID") & "" = "" Then
                objBEData.FileIDs = Request("objID")
                tblEdata = objBEData.GetGeneralInfor(7, 0, 0, 0)
                Call WriteErrorMssg(ddlLabel.Items(6).Text, objBEData.ErrorMsg, ddlLabel.Items(5).Text, objBEData.ErrorCode)
                If Not tblEdata Is Nothing Then
                    If tblEdata.Rows.Count > 0 Then
                        ' FileName
                        If Not IsDBNull(tblEdata.Rows(0).Item("FileName")) Then
                            lblFileName.Text = tblEdata.Rows(0).Item("FileName")
                        Else
                            lblFileName.Text = ""
                        End If
                        ' Price
                        If Not IsDBNull(tblEdata.Rows(0).Item("Price")) Then
                            txtPrice.Text = tblEdata.Rows(0).Item("Price")
                        Else
                            txtPrice.Text = ""
                        End If
                        ' Note
                        If Not IsDBNull(tblEdata.Rows(0).Item("Note")) Then
                            txtNote.Text = tblEdata.Rows(0).Item("Note")
                        Else
                            txtNote.Text = ""
                        End If
                        ' FileFormat
                        If Not IsDBNull(tblEdata.Rows(0).Item("FileFormat")) Then
                            txtFileFormat.Text = tblEdata.Rows(0).Item("FileFormat")
                        Else
                            txtFileFormat.Text = ""
                        End If
                        ' Pagination
                        If Not IsDBNull(tblEdata.Rows(0).Item("Pagination")) Then
                            txtPagination.Text = tblEdata.Rows(0).Item("Pagination")
                        Else
                            txtPagination.Text = ""
                        End If
                        ' Currency
                        If Not IsDBNull(tblEdata.Rows(0).Item("Currency")) Then
                            Dim intIndex As Integer
                            For intIndex = 0 To ddlCurrency.Items.Count - 1
                                If Trim(ddlCurrency.Items(intIndex).Value) = Trim(tblEdata.Rows(0).Item("Currency")) Then
                                    ddlCurrency.SelectedIndex = intIndex
                                End If
                            Next
                        End If
                    Else
                        blnInvalid = True
                    End If
                Else
                    blnInvalid = True
                End If
            Else
                blnInvalid = True
            End If

            If blnInvalid = True Then
                Page.RegisterClientScriptBlock("InvalidFile", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "'); self.close();</script>")
            End If

        End Sub

        ' BindDropdownList method
        Private Sub BindDropdownList()
            Dim tblCurrency As DataTable

            ' get the currency and bind to the dropdown list
            tblCurrency = objBCommonBussiness.GetCurrency
            Call WriteErrorMssg(ddlLabel.Items(6).Text, objBEData.ErrorMsg, ddlLabel.Items(5).Text, objBEData.ErrorCode)

            If Not tblCurrency Is Nothing Then
                If tblCurrency.Rows.Count > 0 Then
                    With ddlCurrency
                        .DataSource = tblCurrency
                        .DataTextField = "CurrencyCode"
                        .DataValueField = "CurrencyCode"
                        .DataBind()
                    End With
                End If
            End If
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Call objBEData.InitVariablesForEdataFile()
            objBEData.Price = CDbl(txtPrice.Text)
            If Trim(txtNote.Text) = "" Then
                objBEData.Note = "NULL"
            Else
                objBEData.Note = EscDoubleQuote(txtNote.Text)
            End If
            objBEData.Currency = ddlCurrency.SelectedValue
            If Trim(txtFileFormat.Text) = "" Then
                objBEData.FileFormat = "NULL"
            Else
                objBEData.FileFormat = EscDoubleQuote(txtFileFormat.Text)
            End If
            If Trim(txtPagination.Text) = "" Then
                objBEData.Pagination = "NULL"
            Else
                objBEData.Pagination = txtPagination.Text
            End If
            objBEData.FileIDs = Request("objID")
            objBEData.UpdateFileRecord()
            Call WriteErrorMssg(ddlLabel.Items(6).Text, objBEData.ErrorMsg, ddlLabel.Items(5).Text, objBEData.ErrorCode)
            Page.RegisterClientScriptBlock("UpdateSucc", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "'); self.close();</script>")
        End Sub

        ' EscDoubleQuote function
        Public Function EscDoubleQuote(ByVal strIn As String) As String
            EscDoubleQuote = Replace(strIn, "'", "''")
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
                If Not objBCommonBussiness Is Nothing Then
                    objBCommonBussiness.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace