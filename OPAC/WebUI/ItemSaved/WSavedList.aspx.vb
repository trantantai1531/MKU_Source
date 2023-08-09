' purpose : list of items were saved
' Create Date 4/11/2004
' Creator : lent

Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WSavedList
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBDB As New clsBCommonDBSystem

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            'Initialize objBSearchResult
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

            ' Init objBDB object
            objBDB.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()
        End Sub

        ' Method : BindJavascript
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='../JS/Item/OpacItem.js'></script>")
            Page.RegisterClientScriptBlock("ListSavedJs", "<script language='javascript' src='../JS/Item/WSavedList.js'></script>")
            btnDelete.Attributes.Add("OnClick", "return Reload('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "')")
            btnComBack.Attributes.Add("OnClick", "return BackToSelect()")
            btnDownload.Attributes.Add("OnClick", "return FormSubmit('" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(2).Text & "')")
        End Sub

        ' Method : BindData
        Private Sub BindData()
            Dim arrField() As String = {"100", "245", "300", "260"}
            Dim tblTmp As New DataTable
            Dim rowNew As DataRow

            arrlistsaved.Value = Session("SaveIDs")

            If arrlistsaved.Value <> "" Then
                objBSearchResult.ItemIDs = arrlistsaved.Value
                tblTmp = objBSearchResult.GetItemResults(arrField)
                If Not tblTmp Is Nothing AndAlso tblTmp.Rows.Count > 0 Then
                    DisplayISBD(tblTmp, arrlistsaved.Value)
                End If
            Else
                tblTmp.Columns.Add("Content", System.Type.GetType("System.String"))
                tblTmp.Columns.Add("Checked", System.Type.GetType("System.String"))
                rowNew = tblTmp.NewRow()
                rowNew.Item("Content") = ddlLabel.Items(3).Text
                tblTmp.Rows.Add(rowNew)
                dtgSavedList.DataSource = tblTmp
                dtgSavedList.Columns(1).Visible = False
                dtgSavedList.DataBind()
            End If
            'Kiem tra tham so he thong ALLOW_DOWNLOAD
            Dim tblPara As DataTable
            objBDB.SQLStatement = "SELECT Val FROM SYS_PARAMETER  WHERE Name ='ALLOW_DOWNLOAD'"
            tblPara = objBDB.RetrieveItemInfor
            If tblPara.Rows(0).Item(0) = 0 Then
                btnDownload.Visible = False
            End If
        End Sub

        ' purpose :  format data to ISBD type
        ' Creator: dgsoft2016
        Private Sub DisplayISBD(ByVal tblData As DataTable, ByVal strIDs As String)
            Dim strTitle As String
            Dim str260_300 As String
            Dim strCopyNumber As String
            Dim rowi() As DataRow
            Dim intCount As Integer
            Dim intj As Integer
            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            Dim arrIDs()

            tblResult.Columns.Add("Checked", System.Type.GetType("System.String"))
            tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
            arrIDs = Split(strIDs, ",")
            If tblData.Rows.Count > 0 Then
                For intCount = 0 To UBound(arrIDs)
                    ' add new row blank
                    rowNew = tblResult.NewRow()
                    rowNew.Item("Checked") = "<input type='checkbox' name='ListSaved' value='" + CStr(arrIDs(intCount)) + "'>"
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                    If tblData.DefaultView.Count > 0 Then
                        strTitle = tblData.DefaultView(0).Item("Content") & ""
                    End If
                    tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='260' OR Field='300')"
                    For intj = 0 To tblData.DefaultView.Count - 1
                        str260_300 = str260_300 & tblData.DefaultView(intj).Item("Content") & ". - "
                    Next
                    If str260_300 <> "" Then
                        str260_300 = Left(str260_300, Len(str260_300) - 2)
                    End If
                    rowNew.Item("Content") = "<a href='../WShowDetail.aspx?intItemID=" & arrIDs(intCount) & "' class='lblinkfunction'>" & strTitle & "</a> " & str260_300
                    ' insert to DataTable
                    tblResult.Rows.InsertAt(rowNew, intCount)
                    strTitle = ""
                    str260_300 = ""
                Next
            End If
            dtgSavedList.DataSource = tblResult
            dtgSavedList.DataBind()
        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim strJs As String = "<script language='javascript'>"
            Session("SaveIDs") = arrlistsaved.Value
            strJs = strJs & "parent.HiddenSaveIDs.document.forms[0].submit();</script>"
            Page.RegisterClientScriptBlock("SubmitHiddenJs", strJs)
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
