Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI
    Partial Class WReference
        Inherits Web.UI.Page

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
        Private objBRef As New clsBReference

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            'Call CreateRefTab()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all objects
        Private Sub Initialize()
            ' Init objBRef object
            objBRef.DBServer = Session("DBServer")
            objBRef.InterfaceLanguage = Session("InterfaceLanguage")
            objBRef.ConnectionString = Session("ConnectionString")
            Call objBRef.Initialize()
        End Sub

        ' Method: CreateRefTab
        Private Sub CreateRefTab()
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lnkShortcut As HyperLink
            Dim tblData As New DataTable
            Dim intCount As Integer
            Dim intModuleID As Byte
            Dim intUserID As Integer = 0

            If IsNumeric(Session("UserID") & "") Then
                intUserID = CInt(Session("UserID"))
            End If
            objBRef.UserID = intUserID

            If IsNumeric(Session("ModuleID") & "") Then
                intModuleID = CInt(Session("ModuleID"))
            End If
            objBRef.ModuleID = intModuleID

            objBRef.ID = 0
            tblData = objBRef.GetReference

            ' Check error
            ' Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRef.ErrorMsg, ddlLabel.Items(0).Text, objBRef.ErrorCode)

            Try
                tblData.DefaultView.RowFilter = "IsRef=1"
                For intCount = 0 To tblData.DefaultView.Count - 1
                    tblRow = New TableRow
                    tblRow.VerticalAlign = VerticalAlign.Top
                    tblCell = New TableCell

                    ' create image icon with URL
                    lnkShortcut = New HyperLink
                    lnkShortcut.Text = Trim(tblData.DefaultView(intCount).Item("Name") & "")
                    If Trim(tblData.DefaultView(intCount).Item("Icon") & "") = "" Or IsDBNull(tblData.DefaultView(intCount).Item("Icon")) Then
                        lnkShortcut.ImageUrl = "../images/unknown.gif"
                        lnkShortcut.NavigateUrl = "#"
                    Else
                        lnkShortcut.ImageUrl = "../" & Trim(tblData.DefaultView(intCount).Item("Icon") & "")
                        lnkShortcut.NavigateUrl = "#"
                    End If
                    Select Case intModuleID
                        Case 1 'CATALOG
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Workform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';parent.document.getElementById('frmMain').setAttribute('rows','*,0');")
                            ElseIf Not tblData.DefaultView(intCount).Item("SentURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Sentform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("SentURL") & "';")
                            End If
                        Case 2 'PATRON
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Workform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';")
                            End If
                        Case 3 'CIRCULATION
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Workform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';")
                            End If
                        Case 4 'ACQUISITION
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.mainacq.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';")
                            End If
                        Case 5 'SERIAL 
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Workform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';")
                            End If
                        Case 6 ' ADMIN
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Workform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';")
                            End If
                        Case 7 'OPAC
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                ' lnkShortcut.Attributes.Add("OnClick", "parent.mainacq.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';")
                            End If
                        Case 8 'ILL
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Workform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';parent.document.getElementById('frmSubMain').setAttribute('rows',rows='*,0');")
                            ElseIf Not tblData.DefaultView(intCount).Item("SentURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Sentform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("SentURL") & "';")
                            End If
                        Case 9 'E-DELIVERY
                            If Not tblData.DefaultView(intCount).Item("WorkURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Workform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("WorkURL") & "';parent.document.getElementById('frmMain').setAttribute('rows',rows='*,0');")
                            ElseIf Not tblData.DefaultView(intCount).Item("SentURL").ToString = "" Then
                                lnkShortcut.Attributes.Add("OnClick", "parent.Sentform.location.href='" & Request.ApplicationPath & "/" & tblData.DefaultView(intCount).Item("SentURL") & "';")
                            End If
                    End Select
                    tblCell.Controls.Add(lnkShortcut)
                    tblRow.Controls.Add(tblCell)
                    tblRef.Rows.Add(tblRow)
                Next
            Catch ex As Exception
            End Try
        End Sub
        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRef Is Nothing Then
                    objBRef.Dispose(True)
                    objBRef = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace