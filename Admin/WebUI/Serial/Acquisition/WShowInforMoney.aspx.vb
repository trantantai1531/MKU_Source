' Class: WShowInforMoney
' Puspose: Show information of money
' Creator: Lenta
' CreatedDate: 20-11-2006
' Modification history:
Imports eMicLibAdmin.BusinessRules.Serial
Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WShowInforMoney
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
        Private objBPeriodical As New clsBPeriodical

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Initialize()
            BindData()
        End Sub
        Private Sub Initialize()
            ' Init for objBPeriodical
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = CInt(Session("ItemID"))
            objBPeriodical.Initialize()
        End Sub

        Private Sub BindData()
            Dim flprice1, flprice2, flprice4, flprice3 As Double
            objBPeriodical.LocationID = Request("LocationID")
            Call objBPeriodical.GetIssuesMoneyByYear(Request("Year"), flprice1, flprice2, flprice3, flprice4)
            lblInfor4Phase1.Text = flprice1 & "&nbsp;(VND)"
            lblInfor4Phase2.Text = flprice2 & "&nbsp;(VND)"
            lblInfor4Phase3.Text = flprice3 & "&nbsp;(VND)"
            lblInfor4Phase4.Text = flprice4 & "&nbsp;(VND)"

            lblInfor2Phase1.Text = CStr(flprice1 + flprice2) & "&nbsp;(VND)"
            lblInfor2Phase2.Text = CStr(flprice3 + flprice4) & "&nbsp;(VND)"

            lblInfor1Phase.Text = CStr(flprice1 + flprice2 + flprice3 + flprice4) & "&nbsp;(VND)"
            btnClose.Attributes.Add("onClick", "self.close();")
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
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