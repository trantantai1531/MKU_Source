' Class: WLoanDetail
' Puspose: Show detail loan informations of the selected patron
' Creator: Oanhtn
' CreatedDate: 27/08/2004
' Modification History:
'   17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WLoanDetail
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
        Private objBLoanTransaction As New clsBLoanTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBLoanTransaction object
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            Call objBLoanTransaction.Initialize()

            ' Close window
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        ' Method: BindData
        ' Purpose: Bind form data
        Private Sub BindData()
            Dim tblLoanDataInfor As DataTable

            objBLoanTransaction.PatronCode = Request("PatronCode")
            objBLoanTransaction.LoanMode = CInt(Request("LoanMode"))
            tblLoanDataInfor = objBLoanTransaction.GetLoanDetailInfor(CInt(Request("Mode")))

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLoanTransaction.ErrorMsg, ddlLabel.Items(0).Text, objBLoanTransaction.ErrorCode)

            If Not tblLoanDataInfor Is Nothing Then
                If tblLoanDataInfor.Rows.Count > 0 Then


                    Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    newColumn.DefaultValue = "1"
                    tblLoanDataInfor.Columns.Add(newColumn)
                    Dim indexRows As Integer = 1
                    For Each rows As DataRow In tblLoanDataInfor.Rows
                        rows.Item("STT") = indexRows.ToString()
                        indexRows = indexRows + 1
                    Next

                    dtgResult.DataSource = tblLoanDataInfor
                    dtgResult.DataBind()
                    dtgResult.Visible = True
                    If CInt(Request("LoanMode")) = 1 Then
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(2).Text
                    ElseIf CInt(Request("LoanMode")) = 2 Then
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(3).Text
                    Else
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(4).Text
                    End If
                End If
                tblLoanDataInfor = Nothing
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
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace