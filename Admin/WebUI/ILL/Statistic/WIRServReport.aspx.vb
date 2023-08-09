' Class: WIRServReport.aspx
' Puspose: Show incomming requests report
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   13/12/2004 by Oanhtn: review code

Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WIRServReport
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
        Private objBILLInRCollection As New clsBILLInRequestCollection

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
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBILLInRCollection object
            objBILLInRCollection.ConnectionString = Session("ConnectionString")
            objBILLInRCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInRCollection.DBServer = Session("DBServer")
            Call objBILLInRCollection.Initialize()
        End Sub

        ' Method: ShowReport
        ' Purpose: show report
        Private Sub ShowReport()
            Dim tblTemp As New DataTable

            ' Get data
            objBILLInRCollection.LibID = clsSession.GlbSite
            tblTemp = objBILLInRCollection.CreateServReport

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLInRCollection.ErrorMsg, ddlLabel.Items(0).Text, objBILLInRCollection.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dgrLibName.DataSource = tblTemp
                    dgrLibName.DataBind()
                    dgr1.DataSource = tblTemp
                    dgr1.DataBind()
                    'tblTemp.Clear()
                    dgr2.DataSource = tblTemp
                    dgr2.DataBind()
                    'stblTemp.Clear()
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
                If Not objBILLInRCollection Is Nothing Then
                    objBILLInRCollection.Dispose(True)
                    objBILLInRCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace