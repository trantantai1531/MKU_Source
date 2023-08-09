Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WItemDetails
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

        Private objBItem As New clsBItem
        Private objBCommonStringProc As New clsBCommonStringProc

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call BindData()
        End Sub

        ' Initialze method 
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init for objBItem
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.Initialize()

            ' Init for objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "self.close();return false;")
        End Sub

        ' BindData method
        ' Purpose: Display the Item details
        Private Sub BindData()
            ' Declare variables
            Dim intCount As Integer
            Dim intIndex As Integer
            Dim strContent As String
            Dim arrItemVal()
            Dim strEdition As String
            Dim tblItem As DataTable

            If Not Request("ItemID") Is Nothing Then
                If IsNumeric(Request("ItemID")) Then
                    objBItem.ItemID = Request("ItemID")
                    tblItem = objBItem.GetItemInfor

                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItem.ErrorMsg, ddlLabel.Items(1).Text, objBItem.ErrorCode)

                    If Not tblItem Is Nothing Then
                        If tblItem.Rows.Count > 0 Then
                            intCount = tblItem.Rows.Count
                        End If
                    End If

                    ' Draw the table
                    If intCount > 0 Then
                        Dim tblRow As TableRow
                        Dim tblCell1 As TableCell
                        Dim tblCell2 As TableCell

                        For intIndex = 0 To intCount - 1
                            strContent = ""
                            tblRow = New TableRow

                            tblCell1 = New TableCell
                            tblCell1.ColumnSpan = 1
                            tblCell1.HorizontalAlign = HorizontalAlign.Right
                            tblCell1.CssClass = "lbLabel"
                            tblCell1.Width = Unit.Percentage(40)

                            tblCell2 = New TableCell
                            tblCell2.ColumnSpan = 1
                            tblCell2.CssClass = "lbLabel"
                            tblCell2.Width = Unit.Percentage(60)

                            If Not IsDBNull(tblItem.Rows(intIndex).Item("FieldCode")) Then
                                Select Case CStr(tblItem.Rows(intIndex).Item("FieldCode"))
                                    Case "022" ' ISSN
                                        If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                            If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                                tblCell1.Controls.Add(New LiteralControl(ddlLabel.Items(2).Text))
                                                Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                                If Not arrItemVal(0) = "" Then
                                                    strContent = arrItemVal(0)
                                                End If
                                            End If
                                        End If
                                    Case "100" ' Author
                                        If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                            If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                                tblCell1.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
                                                Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                                If Not arrItemVal(0) = "" Then
                                                    strContent = arrItemVal(0)
                                                End If
                                            End If
                                        End If
                                    Case "110" ' Group author
                                        If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                            If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                                tblCell1.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
                                                Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                                If Not arrItemVal(0) = "" Then
                                                    strContent = arrItemVal(0)
                                                End If
                                            End If
                                        End If
                                    Case "111" ' Ten hoi nghi
                                        If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                            If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                                tblCell1.Controls.Add(New LiteralControl(ddlLabel.Items(5).Text))
                                                Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                                If Not arrItemVal(0) = "" Then
                                                    strContent = arrItemVal(0)
                                                End If
                                            End If
                                        End If
                                    Case "245" ' Title
                                        If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                            If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                                tblCell1.Controls.Add(New LiteralControl(ddlLabel.Items(6).Text))
                                                tblCell2.ForeColor = Drawing.Color.Red
                                                Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                                If Not arrItemVal(0) = "" Then
                                                    strContent = arrItemVal(0)
                                                End If
                                            End If
                                        End If
                                    Case "260" ' Edition, publisher and pub year
                                        If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                            If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                                tblCell1.Controls.Add(New LiteralControl(ddlLabel.Items(7).Text))
                                                strContent = objBCommonStringProc.TrimSubFieldCodes(tblItem.Rows(intIndex).Item("Content"))
                                            End If
                                        End If
                                    Case "300" ' Physical charactor
                                        If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                            If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                                tblCell1.Controls.Add(New LiteralControl(ddlLabel.Items(8).Text))
                                                strContent = objBCommonStringProc.TrimSubFieldCodes(tblItem.Rows(intIndex).Item("Content"))
                                            End If
                                        End If
                                End Select

                                ' Display the Item details
                                If Not strContent = "" Then
                                    tblRow.Cells.Add(tblCell1)
                                    tblCell2.Controls.Add(New LiteralControl(strContent))
                                    tblCell2.Font.Bold = True
                                    tblRow.Cells.Add(tblCell2)
                                    tblMainInfor.Rows.Add(tblRow)
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End Sub

        ' Purpose: Unload the page and dispose the elements
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
            Catch ex As Exception
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

