' Class: WORServReport.aspx
' Puspose: Show report of outgoing services
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORServReport
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
        Private objBILLOutRCollection As New clsBILLOutRequestCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call ShowReport()
        End Sub
        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(157) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBILLOutRCollection object
            objBILLOutRCollection.ConnectionString = Session("ConnectionString")
            objBILLOutRCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRCollection.DBServer = Session("DBServer")
            Call objBILLOutRCollection.Initialize()
        End Sub

        ' Method: ShowReport
        ' Purpose: show report
        Private Sub ShowReport()
            Dim tblTemp As New DataTable

            objBILLOutRCollection.LibID = clsSession.GlbSite
            tblTemp = objBILLOutRCollection.CreateServReport

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLOutRCollection.ErrorMsg, ddlLabel.Items(0).Text, objBILLOutRCollection.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dgrLibName.DataSource = tblTemp
                    dgrLibName.DataBind()
                    dgr1.DataSource = tblTemp
                    dgr1.DataBind()
                    dgr2.DataSource = tblTemp
                    dgr2.DataBind()
                    dgr3.DataSource = tblTemp
                    dgr3.DataBind()
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' Event: Page_UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutRCollection Is Nothing Then
                    objBILLOutRCollection.Dispose(True)
                    objBILLOutRCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace