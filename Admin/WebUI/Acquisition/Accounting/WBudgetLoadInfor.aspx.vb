Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBudgetLoadInfor
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
        Private objBBudget As New clsBBudget

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call LoadData()
        End Sub

        ' Initialize method
        ' Purpose: Init all object
        Private Sub Initialize()
            ' Init for objBBudget
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            objBBudget.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Accounting/WBudgetLoadInfor.js'></script>")
        End Sub

        ' LoadData method
        ' Purpose: Load budget information to the Work form
        Private Sub LoadData()
            Dim strBudgetName As String = ""
            Dim strBudgetCode As String = ""
            Dim strPurpose As String = ""
            Dim strAmount As String = ""
            Dim strCurrency As String = ""
            Dim strStatus As String = ""
            Dim intBudgetId As Integer = 0
            Dim tblBudget As New DataTable
            Dim strJS As String

            ' Get the BudgetID
            If Not Request("intBudgetID") & "" = "" Then
                intBudgetId = CInt(Request("intBudgetID"))
                objBBudget.BudID = intBudgetId
                tblBudget = objBBudget.GetBudget
            End If

            If Not tblBudget Is Nothing Then
                If tblBudget.Rows.Count > 0 Then
                    If Not IsDBNull(tblBudget.Rows(0).Item("BudgetName")) Then
                        strBudgetName = tblBudget.Rows(0).Item("BudgetName")
                    End If
                    If Not IsDBNull(tblBudget.Rows(0).Item("BudgetCode")) Then
                        strBudgetCode = tblBudget.Rows(0).Item("BudgetCode")
                    End If
                    If Not IsDBNull(tblBudget.Rows(0).Item("Purpose")) Then
                        strPurpose = tblBudget.Rows(0).Item("Purpose")
                    End If
                    If Not IsDBNull(tblBudget.Rows(0).Item("Balance")) Then
                        strAmount = tblBudget.Rows(0).Item("RealBalance")
                        'strAmount = strAmount.ToString().Replace(",0000", "")
                        strAmount = If(Not (strAmount = "0"), CDbl(strAmount).ToString("#,##"), "0")
                    End If
                    If Not IsDBNull(tblBudget.Rows(0).Item("Currency")) Then
                        strCurrency = tblBudget.Rows(0).Item("Currency")
                    End If
                    If Not IsDBNull(tblBudget.Rows(0).Item("Status")) Then
                        strStatus = Trim(CStr(tblBudget.Rows(0).Item("Status")))
                    End If
                End If
            End If

            strJS = "<script language='javascript'>"
            strJS = strJS & "LoadBudgetInfor('" & strBudgetName & "','"
            strJS = strJS & strBudgetCode & "','"
            strJS = strJS & strPurpose & "','"
            strJS = strJS & strAmount & "','"
            strJS = strJS & strCurrency & "',"
            strJS = strJS & strStatus & ");"
            strJS = strJS & "</script>"

            Page.RegisterClientScriptBlock("LoadBudgetInfor", strJS)
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBBudget Is Nothing Then
                    objBBudget.Dispose(True)
                    objBBudget = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class

End Namespace
