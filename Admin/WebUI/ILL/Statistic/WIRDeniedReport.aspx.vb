' class WIRDeniedReport.aspx
' Puspose: show denied incoming request report
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   + 08/12/2004 by Lenta: write methods
'   + 13/12/2004 by Oanhtn: review code

Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WIRDeniedReport
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

        ' Declare variabels
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
            'Init objBILLInRCollection object
            objBILLInRCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInRCollection.DBServer = Session("DBServer")
            objBILLInRCollection.ConnectionString = Session("ConnectionString")
            Call objBILLInRCollection.Initialize()
        End Sub

        ' Method: ShowReport
        ' Purpose: show report 
        Private Sub ShowReport()
            Dim tblResult As DataTable
            Dim intIndex As Integer

            ' Get data for showing
            objBILLInRCollection.LibID = clsSession.GlbSite
            tblResult = objBILLInRCollection.CreateDeniedIRReport

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLInRCollection.ErrorMsg, ddlLabel.Items(0).Text, objBILLInRCollection.ErrorCode)

            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                For intIndex = 0 To tblResult.Columns.Count - 1
                    If intIndex = 0 Then
                        dtgIRReport.Columns.Add(CreateBoundColumn(tblResult.Columns(intIndex).ColumnName, " "))
                    Else
                        dtgIRReport.Columns.Add(CreateBoundColumn(tblResult.Columns(intIndex).ColumnName, tblResult.Columns(intIndex).ColumnName))
                    End If
                Next
                dtgIRReport.DataSource = tblResult
                dtgIRReport.DataBind()

                ' Release object
                tblResult.Dispose()
                tblResult = Nothing
            End If
        End Sub

        ' Method: CreateBoundColumn
        Function CreateBoundColumn(ByVal DataFieldValue As String, ByVal HeaderTextValue As String) As BoundColumn
            Dim column As BoundColumn = New BoundColumn

            column.DataField = DataFieldValue
            column.HeaderText = HeaderTextValue
            column.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            Return column
        End Function

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