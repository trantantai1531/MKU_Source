Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class OLibrary
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Typer As System.Web.UI.WebControls.DropDownList
        Protected WithEvents FontType As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblLanguage As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBSysLibrary As New clsBSysLibrary

        ' Event :  Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
                Call LoadData()
            End If
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            objBSysLibrary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSysLibrary.DBServer = Session("DBServer")
            objBSysLibrary.ConnectionString = Session("ConnectionString")
            objBSysLibrary.Initialize()
        End Sub

        ' Method :  LoadData
        Private Sub LoadData()
            Try
                Dim i As Integer
                If clsSession.GlbLanguage & "" <> "" Then
                    Dim strLanguage As String
                    strLanguage = clsSession.GlbLanguage
                    For i = 0 To ddlLanguage.Items.Count - 1
                        If ddlLanguage.Items(i).Value = strLanguage Then
                            ddlLanguage.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
                Dim tblResult As DataTable
                objBSysLibrary.Language = clsSession.GlbLanguage
                tblResult = objBSysLibrary.SysGetAllLibrary
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    Dim tblCell As TableCell = Nothing
                    Dim tblRow As TableRow = Nothing
                    Dim img As System.Web.UI.WebControls.Image
                    Dim hpl As HyperLink = Nothing
                    Dim LibType As Integer = 0
                    Dim lbl As Label = Nothing
                    For i = 0 To tblResult.Rows.Count - 1
                        If LibType <> tblResult.Rows(i).Item("LibTypeId") Then
                            'Them dong trang
                            'tblCell = New TableCell
                            'With tblCell
                            '    .Width = Unit.Percentage(100)
                            '    .Height = Unit.Pixel(20)
                            '    .ColumnSpan = 2
                            '    .VerticalAlign = VerticalAlign.Top
                            '    .HorizontalAlign = HorizontalAlign.Center
                            'End With
                            'tblRow = New TableRow
                            'tblRow.Cells.Add(tblCell)
                            'tbLibrary.Rows.Add(tblRow)


                            lbl = New Label
                            With lbl
                                .ID = "lbl" & tblResult.Rows(i).Item("LibId")
                                .CssClass = "lbGroupTitle"
                                .Text = tblResult.Rows(i).Item("LibType")
                            End With

                            tblCell = New TableCell
                            With tblCell
                                .CssClass = "lbRowTable"
                                .Width = Unit.Percentage(100)
                                .ColumnSpan = 2
                                .VerticalAlign = VerticalAlign.Top
                                .HorizontalAlign = HorizontalAlign.Center
                                .Controls.Add(lbl)
                            End With
                            tblRow = New TableRow
                            tblRow.Cells.Add(tblCell)
                            tbLibrary.Rows.Add(tblRow)
                        End If

                        tblRow = New TableRow
                        If LibType <> tblResult.Rows(i).Item("LibTypeId") Then
                            img = New System.Web.UI.WebControls.Image
                            With img
                                .ID = "img" & tblResult.Rows(i).Item("LibId")
                                .ImageUrl = tblResult.Rows(i).Item("LibImage").ToString
                            End With
                            tblCell = New TableCell
                            With tblCell
                                .VerticalAlign = VerticalAlign.Top
                                '.CssClass = "autofield"
                                .Width = Unit.Percentage(10)
                                .Controls.Add(img)
                            End With
                            tblRow.Cells.Add(tblCell)


                            img = New System.Web.UI.WebControls.Image
                            With img
                                .ID = "img" & tblResult.Rows(i).Item("LibId")
                                .ImageUrl = "images/library/Library.png"
                                .ImageAlign = ImageAlign.AbsMiddle
                            End With
                            tblCell = New TableCell
                            hpl = New HyperLink
                            With hpl
                                .ID = "hpl" & tblResult.Rows(i).Item("LibId")
                                '.CssClass = "lbSubTitle"
                                .Text = tblResult.Rows(i).Item("LibName").ToString
                                .NavigateUrl = "OIndex.aspx?Site=" & tblResult.Rows(i).Item("LibId")
                            End With
                            tblCell = New TableCell
                            With tblCell
                                .VerticalAlign = VerticalAlign.Top
                                '.CssClass = "autofield"
                                .Width = Unit.Percentage(90)
                                .Controls.Add(img)
                                .Controls.Add(hpl)
                            End With
                            tblRow.Cells.Add(tblCell)
                        Else
                            tblCell = New TableCell
                            With tblCell
                                .VerticalAlign = VerticalAlign.Top
                                .Width = Unit.Percentage(10)
                            End With
                            tblRow.Cells.Add(tblCell)


                            img = New System.Web.UI.WebControls.Image
                            With img
                                .ID = "img" & tblResult.Rows(i).Item("LibId")
                                .ImageUrl = "images/library/Library.png"
                                .ImageAlign = ImageAlign.AbsMiddle
                            End With

                            hpl = New HyperLink
                            With hpl
                                .ID = "hpl" & tblResult.Rows(i).Item("LibId")
                                '.CssClass = "lbSubTitle"
                                .Text = tblResult.Rows(i).Item("LibName").ToString
                                .NavigateUrl = "OIndex.aspx?Site=" & tblResult.Rows(i).Item("LibId")
                            End With
                            tblCell = New TableCell
                            With tblCell
                                .VerticalAlign = VerticalAlign.Top
                                .ColumnSpan = 2
                                .Width = Unit.Percentage(90)
                                .Controls.Add(img)
                                .Controls.Add(hpl)
                            End With
                            tblRow.Cells.Add(tblCell)
                        End If
                        tbLibrary.Rows.Add(tblRow)
                        LibType = tblResult.Rows(i).Item("LibTypeId")
                    Next


                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Method :  BindJavascript
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='JS/OLibrary.js'></script>")
        End Sub

        ' Event : ddlTyping_SelectedIndexChanged 
        Private Sub ddlLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLanguage.SelectedIndexChanged
            clsSession.GlbInterfaceLanguage = "unicode"
            clsSession.GlbLanguage = ddlLanguage.SelectedValue
            Page.RegisterClientScriptBlock("ReLoadAll", "<Script Language='JavaScript'>ReLoadForm();</Script>")
        End Sub

        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBSysLibrary Is Nothing Then
                    objBSysLibrary.Dispose(True)
                    objBSysLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
