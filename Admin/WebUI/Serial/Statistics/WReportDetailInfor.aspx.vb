' Class: WReportDetailInfor
' Puspose: View Report detail infor items
' Creator: Tuanhv
' CreatedDate: 06/10/2004
' Modification history:
'   Date: 21/04/2005
'       Modify by: Tuanhv
'           Works: View code & Update

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WReportDetailInfor
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

        Private objBCommonChart As New clsBCommonChart
        Private objBPC As New clsBPeriodicalCollection
        Private objBCommonStringProc As New clsBCommonStringProc

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.Initialize()

            ' Init for objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.Initialize()

            objBCommonChart.Initialize()
        End Sub

        ' BindJS method
        Sub BindJS()
            btnClose.Attributes.Add("OnClick", "self.close();")
        End Sub

        ' BindData method
        ' Purpose: Bind data to datagrid
        Sub BindData()
            Dim strCatagory As String = ""
            Dim strGenclassification As String = ""
            Dim strLocation As String = ""
            Dim strFreq As String = ""
            Dim strLanguage As String = ""
            Dim strCountry As String = ""
            ' Declare variables
            Dim intCount As Integer
            Dim intIndex As Integer
            Dim strContent As String
            Dim arrItemVal()
            Dim strEdition As String
            Dim tblItem As DataTable
            Dim intNextItem As Integer = 0

            ' Check statistic link to form
            If Trim(Request("Catagory")) <> "" Then
                strCatagory = Trim(Request("Catagory"))
            End If
            If Trim(Request("Genclassification")) <> "" Then
                strGenclassification = Trim(Request("GenClassification"))
            End If
            If Trim(Request("Location")) <> "" Then
                strLocation = Trim(Request("Location"))
            End If
            If Trim(Request("Freq")) <> "" Then
                If Len(Trim(Request("Freq"))) > 1 Then
                    strFreq = "NULL"
                Else
                    strFreq = Trim(Request("Freq"))
                End If
            End If
            If Trim(Request("Language")) <> "" Then
                strLanguage = Trim(Request("Language"))
            End If
            If Trim(Request("Country")) <> "" Then
                strCountry = Trim(Request("Country"))
                'If Len(Trim(Request("Country"))) > 1 Then
                '    strCountry = "NULL"
                'Else
                '    strCountry = Trim(Request("Country"))
                'End If
            End If

            Try
                ' Show result
                tblItem = objBPC.GetReportDetailInfor(strCatagory, strGenclassification, strLocation, strFreq, strLanguage, strCountry)
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

                If Not tblItem Is Nothing Then
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
                        Dim tblCell3 As TableCell

                        tblMainInfor.Width = Unit.Percentage(100)
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
                                                tblCell2.ForeColor = SystemColors.InfoText
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

                                If intIndex > 0 Then
                                    If tblItem.Rows(intIndex).Item("ID") <> tblItem.Rows(intIndex - 1).Item("ID") Then
                                        tblCell3 = New TableCell
                                        tblCell3.ColumnSpan = 2
                                        tblCell3.HorizontalAlign = HorizontalAlign.Center
                                        tblCell3.Width = Unit.Percentage(100)
                                        tblCell3.Controls.Add(New LiteralControl("<HR>"))
                                        tblRow.Cells.Add(tblCell3)
                                        tblMainInfor.Rows.Add(tblRow)
                                        tblRow = New TableRow
                                    End If
                                End If

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
                tblItem = Nothing
            Catch ex As Exception
            End Try
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPC Is Nothing Then
                    objBPC.Dispose(True)
                    objBPC = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace