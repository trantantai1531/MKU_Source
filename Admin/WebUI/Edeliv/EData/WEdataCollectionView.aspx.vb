' Class: WEdataCollection
' Puspose: Manger data collection form
' Creator: Tuanhv
' CreatedDate: 14/02/2005
' Modification History:

Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WEdataCollectionView
        Inherits clsWBase
        Dim objBEData As New clsBEData

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
            Call CheckFormPemission()
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Init objBCSP object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            'Bind data for dropdownlist
            Dim tblResult As DataTable
            Dim strFileIDsSelect As String = ""
            Dim intCount As Integer
            tblResult = objBEData.GetCollection
            Call WriteErrorMssg(ddlLabel.Items(2).Text, objBEData.ErrorMsg, ddlLabel.Items(1).Text, objBEData.ErrorCode)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    strFileIDsSelect = CStr(Request("FileIDsSelect"))
                    If strFileIDsSelect <> "" Then
                        hidFileIDsSelect.Value = strFileIDsSelect
                    End If
                    ddlCollection.DataSource = tblResult
                    ddlCollection.DataTextField = "Collection"
                    ddlCollection.DataValueField = "CollectionID"
                    ddlCollection.SelectedIndex = 0
                    ddlCollection.DataBind()
                Else
                    lblCollectionName.Visible = False
                    ddlCollection.Visible = False
                    btnSelect.Visible = False
                End If
            Else
                lblCollectionName.Visible = False
                ddlCollection.Visible = False
                btnSelect.Visible = False
            End If
        End Sub

        'Event btnSelect_Click
        Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
            Dim strFileIDs As String = ""
            Dim intCollectionID As Integer
            strFileIDs = Right(Left(hidFileIDsSelect.Value, Len(hidFileIDsSelect.Value) - 1), Len(Left(hidFileIDsSelect.Value, Len(hidFileIDsSelect.Value) - 1)) - 1)
            intCollectionID = CInt(ddlCollection.SelectedValue)
            Call objBEData.UpdateEdataCollection(strFileIDs, intCollectionID)
            Call WriteErrorMssg(ddlLabel.Items(2).Text, objBEData.ErrorMsg, ddlLabel.Items(1).Text, objBEData.ErrorCode)
            If Request("Refresh") = "1" Then
                Page.RegisterClientScriptBlock("RefreshOpenner", "<script language='javascript'>opener.parent.top.main.Workform.location.href='WEDataManager.aspx';self.close();</script>")
            Else
                Page.RegisterClientScriptBlock("CloseForm", "<script language='javascript'>self.close();</script>")
            End If
        End Sub

        'Event Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
