Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQRefercence
        Inherits System.Web.UI.Page

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

        Private objBRef As New clsBReference

        ' init all object
        Private Sub Initialize()
            ' init objBRef object
            objBRef.DBServer = Session("DBServer")
            objBRef.InterfaceLanguage = Session("InterfaceLanguage")
            objBRef.ConnectionString = Session("ConnectionString")
            objBRef.Initialize()
        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call CreateRefTab()
        End Sub

        Private Sub CreateRefTab()
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lnkShortcut As HyperLink
            Dim tblData As New DataTable
            Dim intCount As Integer

            objBRef.UserID = Session("UserID")
            objBRef.ModuleID = 4 ' ACQ Module
            objBRef.ID = 0
            tblData = objBRef.GetReference
            tblData.DefaultView.RowFilter = "IsRef=1"
            For intCount = 0 To tblData.DefaultView.Count - 1
                tblRow = New TableRow
                tblRow.VerticalAlign = VerticalAlign.Top
                tblCell = New TableCell

                ' create image icon with URL
                lnkShortcut = New HyperLink
                lnkShortcut.Text = Trim(tblData.DefaultView(intCount).Item("Right") & "")
                If Trim(tblData.DefaultView(intCount).Item("Icon") & "") = "" Or IsDBNull(tblData.DefaultView(intCount).Item("Icon")) Then
                    lnkShortcut.ImageUrl = "../images/unknown.gif"
                Else
                    lnkShortcut.ImageUrl = Trim(tblData.DefaultView(intCount).Item("Icon") & "")
                End If
                lnkShortcut.NavigateUrl = "javascript:parent.mainacq.location.href='" & tblData.DefaultView(intCount).Item("URL") & "';self.location.href='WACQRefercence.aspx';"
                tblCell.Controls.Add(lnkShortcut)
                tblRow.Controls.Add(tblCell)
                tblRef.Rows.Add(tblRow)
            Next
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