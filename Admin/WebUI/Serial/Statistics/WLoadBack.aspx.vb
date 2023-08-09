' Class: WLoadBack
' Puspose: Load back data
' Creator: oanhtn
' CreatedDate: 22/04/205
' Modification history:

Imports eMicLibAdmin.BusinessRules.Serial

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WLoadBack
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
        Private objBPeriodical As New clsBPeriodical

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadBackData()
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBPeriodical object
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPeriodical.Initialize()
        End Sub

        ' Method: LoadBackdata
        Private Sub LoadBackData()
            Dim tblData As DataTable

            If IsNumeric(Request("ItemID")) Then
                objBPeriodical.ItemID = CLng(Request("ItemID"))
                tblData = objBPeriodical.GetPeriodicalInfor

                ' Check error
                Call WriteErrorMssg(objBPeriodical.ErrorCode, objBPeriodical.ErrorMsg)

                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        Session("ItemID") = CLng(Request("ItemID"))
                        Session("Title") = tblData.Rows(0).Item("Content")
                    End If
                End If

                Page.RegisterClientScriptBlock("LoadBackJs", "<script language = 'javascript'>parent.Workform.location.href=""../Acquisition/WAcquire.aspx""</script>")
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace