﻿' Class: WManualDic
' Propose: Management manual dictionaries
' CreatedDate: 26/05/2005
' Creator: Oanhtn
'  Modification history 

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports OfficeOpenXml
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WEngVnDic
        Inherits clsWBase
        Implements IUCNumberOfRecord
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidSizeDic As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Delclare variables
        Private objBCatLibraryDictionary As New clsBLibraryDictionary
        Private objBDicSelfMade As New clsBDictionarySelfMade

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()

        End Sub

        ' Method: Initialze
        ' Purpose: Init all object use in form
        Private Sub Initialze()
            ' Init objBCatDiclist object 
            objBCatLibraryDictionary.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatLibraryDictionary.DBServer = Session("DbServer")
            objBCatLibraryDictionary.ConnectionString = Session("ConnectionString")
            Call objBCatLibraryDictionary.Initialize()

            ' Init objBDicSelfMade object
            objBDicSelfMade.InterfaceLanguage = Session("InterfaceLanguage")
            objBDicSelfMade.DBServer = Session("DbServer")
            objBDicSelfMade.ConnectionString = Session("ConnectionString")
            Call objBDicSelfMade.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WEngVnDic.js'></script>")
            btnNewDic.Attributes.Add("onClick", "return CheckInput('" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "');")
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: check permission
        Private Sub CheckFormPermission()

            If Not CheckPemission(147) And Not CheckPemission(8) And Not CheckPemission(169) And Not CheckPemission(170) And Not CheckPemission(171) Then
                Call WriteErrorMssg(ddlLabel.Items(9).Text)
            Else
                'Quyen quan ly 
                If Not CheckPemission(147) Then
                    ' View entries
                    If Not CheckPemission(8) Then
                        dtgDicData.Columns(5).Visible = False
                    End If
                    ' New dictionary
                    If Not CheckPemission(169) Then
                        btnNewDic.Enabled = False
                    End If
                    ' Update dictionary
                    If Not CheckPemission(170) Then
                        dtgDicData.Columns(5).Visible = False
                    End If
                    ' Delete dictionary
                    If Not CheckPemission(171) Then
                        dtgDicData.Columns(6).Visible = False
                    End If
                End If
            End If
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As DataTable

            tblTemp = objBCatLibraryDictionary.GetAllVocabulary()
            If Not tblTemp Is Nothing Then
                dtgDicData.DataSource = tblTemp
            End If
        End Sub


        Private Sub btnNewDic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDic.Click
            Dim intRET As Integer
            Dim strJS
            objBCatLibraryDictionary.EnglishVocabulary = txtEnglishVocabuary.Text
            objBCatLibraryDictionary.Mean = txtMean.Text
            intRET = objBCatLibraryDictionary.Create

            Select Case intRET
                Case 0 ' exist dicName in database
                    strJS = ddlLabel.Items(2).Text
                Case 1 ' OK !
                    strJS = ddlLabel.Items(3).Text
                    txtEnglishVocabuary.Text = ""
                    txtMean.Text = ""
            End Select
            Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & strJS & "')</script>")
            Call BindData()
            dtgDicData.Rebind()
        End Sub

        ' Event: dtgDicSelfMade_ItemCreated
        Private Sub dtgDicSelfMade_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dtgDicData.ItemCreated

            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem

                    'Dim myDeleteButton As LinkButton
                    'Dim myUpdateButton As LinkButton = TryCast(e.Item.FindControl("lnkBudgetName"), LinkButton)
                    'myDeleteButton = myTableCell.Controls(0)
                    'myDeleteButton.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(4).Text & "')==false) {return false}")

                    'myUpdateButton.Attributes.Add("Onclick", "return (CheckDicManualUpdate('document.forms[0].dtgDicSelfMade__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "'," & DataBinder.Eval(e.Item.DataItem, "FieldSize") & "));")

            End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCatLibraryDictionary Is Nothing Then
                        objBCatLibraryDictionary.Dispose(True)
                        objBCatLibraryDictionary = Nothing
                    End If
                    If Not objBDicSelfMade Is Nothing Then
                        objBDicSelfMade.Dispose(True)
                        objBDicSelfMade = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Dispose()
            End Try
        End Sub

        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

        Protected Sub dtgDicSelfMade_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgDicData.NeedDataSource
            BindData()

        End Sub

        Protected Sub dtgDicSelfMade_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgDicData.DeleteCommand
            Dim intRet As Integer

            objBCatLibraryDictionary.Id = CType(e.Item.FindControl("lblID"), Label).Text
            intRet = objBCatLibraryDictionary.Delete()
            If intRet = 1 Then
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Xóa từ điển thành công')</script>")
            Else
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Xóa từ điển không thành công')</script>")
            End If

            Call BindData()
            dtgDicData.Rebind()
        End Sub

        Protected Sub dtgDicSelfMade_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgDicData.UpdateCommand
         
            Dim intRet As Integer

            objBCatLibraryDictionary.id = CType(e.Item.FindControl("lblID"), Label).Text
            objBCatLibraryDictionary.Mean = CType(e.Item.FindControl("txtMean"), TextBox).Text
            objBCatLibraryDictionary.EnglishVocabulary = CType(e.Item.FindControl("txtEnglishVocabulary"), TextBox).Text
            intRet = objBCatLibraryDictionary.Update()
            If intRet = 1 Then
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Cập nhật từ điển thành công')</script>")
            Else
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Cập nhật từ điển không thành công')</script>")
            End If

            Call BindData()
            dtgDicData.Rebind()
        End Sub

        '     Event: dtgDicSelfMade_CancelCommand
        'Private Sub dtgDicSelfMade_CancelCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dtgDicSelfMade.CancelCommand
        '    dtgDicSelfMade.EditItemIndex = -1
        '    Call BindData()
        'End Sub

        Protected Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
            lblError.Text = ""
            If (fupload.HasFile AndAlso (IO.Path.GetExtension(fupload.FileName) = ".xlsx" Or IO.Path.GetExtension(fupload.FileName) = ".xls")) Then
                Using excel = New ExcelPackage(fupload.PostedFile.InputStream)
                    Dim tbl = New DataTable()
                    Dim ws = excel.Workbook.Worksheets.First()
                    Dim hasHeader = True ' change it if required '
                    ' create DataColumns '
                    For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                        tbl.Columns.Add(If(hasHeader,
                                           firstRowCell.Text,
                                           String.Format("Column {0}", firstRowCell.Start.Column)))
                    Next
                    ' add rows to DataTable '
                    Dim startRow = If(hasHeader, 2, 1)
                    For rowNum = startRow To ws.Dimension.End.Row
                        Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
                        Dim row = tbl.NewRow()
                        For Each cell In wsRow
                            row(cell.Start.Column - 1) = cell.Text
                        Next
                        tbl.Rows.Add(row)
                    Next
                    Dim listError As New List(Of String)
                    For Each row As DataRow In tbl.Rows
                        If row.Item(1) <> "" AndAlso row.Item(0) <> "" Then
                            objBCatLibraryDictionary.EnglishVocabulary = row.Item(1)
                            objBCatLibraryDictionary.Mean = row.Item(0)
                            Dim intRET = objBCatLibraryDictionary.Create
                            If intRET = 0 Then
                                listError.Add(row.Item(0))
                            End If
                        End If

                     

                    Next

                    If listError.Count > 0 Then
                        lblError.Text = "Các từ vựng không import được: " & [String].Join("; ", listError.ToList()).ToString()
                    Else
                        lblError.Text = "Import dữ liệu thành công"

                    End If


                End Using
            Else

            End If
            Call BindData()
            dtgDicData.Rebind()
        End Sub
    End Class
End Namespace