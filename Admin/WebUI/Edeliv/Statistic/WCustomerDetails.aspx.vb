Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WCustomerDetails
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlabel As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare Variables
        Private objBECustomer As New clsBECustomer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Initialize()
            BindScript()
            If Not Request("CustomerCode") Is Nothing Then
                GetCustomerInfor(Request("CustomerCode"))
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(163) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            btnClose.Attributes.Add("Onclick", "javascript:self.close();")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBECustomer
            objBECustomer.InterfaceLanguage = Session("InterfaceLanguage")
            objBECustomer.DBServer = Session("DBServer")
            objBECustomer.ConnectionString = Session("ConnectionString")
            objBECustomer.Initialize()
        End Sub

        ' GetCustomerInfor method
        ' Purpose: Get the customerinfor
        Private Sub GetCustomerInfor(ByVal strCustomerCode As String)
            ' Declare variables
            Dim tblCustomer As DataTable
            Dim strFullName As String = ""
            Dim strContactName As String = ""
            Dim strEmail As String = ""
            Dim strTelephonePhone As String = ""
            Dim strFax As String = ""
            Dim strNote As String = ""
            Dim strTelephone As String = ""
            Dim strUserName As String = ""
            Dim strDelivName As String = ""
            Dim strDelivXAddr As String = ""
            Dim strDelivStreet As String = ""
            Dim strDelivBox As String = ""
            Dim strDelivCity As String = ""
            Dim strDelivRegion As String = ""
            Dim strDelivCountry As String = ""
            Dim strDelivCode As String = ""
            Dim strDebt As String = ""

            ' Check the user

            tblCustomer = objBECustomer.GetCustomerInforByCode(strCustomerCode)
            Call WriteErrorMssg(ddlLabel.Items(2).text, objBECustomer.ErrorMsg, ddlLabel.Items(1).text, objBECustomer.ErrorCode)

            If Not tblCustomer Is Nothing Then
                If tblCustomer.Rows.Count > 0 Then
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Name")) Then
                        strFullName = Trim(CStr(tblCustomer.Rows(0).Item("Name")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("ContactPerson")) Then
                        strContactName = Trim(CStr(tblCustomer.Rows(0).Item("ContactPerson")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("EmailAddress")) Then
                        strEmail = Trim(CStr(tblCustomer.Rows(0).Item("EmailAddress")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Telephone")) Then
                        strTelephone = Trim(CStr(tblCustomer.Rows(0).Item("Telephone")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Fax")) Then
                        strFax = Trim(CStr(tblCustomer.Rows(0).Item("Fax")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Note")) Then
                        strNote = Trim(CStr(tblCustomer.Rows(0).Item("Note")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("UserName")) Then
                        strUserName = Trim(CStr(tblCustomer.Rows(0).Item("UserName")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivName")) Then
                        strDelivName = Trim(CStr(tblCustomer.Rows(0).Item("DelivName")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivXAddr")) Then
                        strDelivXAddr = Trim(CStr(tblCustomer.Rows(0).Item("DelivXAddr")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivStreet")) Then
                        strDelivStreet = Trim(CStr(tblCustomer.Rows(0).Item("DelivStreet")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivBox")) Then
                        strDelivBox = Trim(CStr(tblCustomer.Rows(0).Item("DelivBox")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivCity")) Then
                        strDelivCity = Trim(CStr(tblCustomer.Rows(0).Item("DelivCity")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivRegion")) Then
                        strDelivRegion = Trim(CStr(tblCustomer.Rows(0).Item("DelivRegion")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Country")) Then
                        strDelivCountry = Trim(CStr(tblCustomer.Rows(0).Item("Country")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivCode")) Then
                        strDelivCode = Trim(CStr(tblCustomer.Rows(0).Item("DelivCode")))
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Debt")) Then
                        strDebt = Trim(CStr(tblCustomer.Rows(0).Item("Debt")))
                    End If
                    lblField1.Text = strFullName
                    lblField2.Text = strContactName
                    lblField3.Text = strEmail
                    lblField4.Text = strTelephone
                    lblField5.Text = strFax
                    lblField6.Text = strNote
                    lblField7.Text = strUserName
                    lblField8.Text = strDebt
                    lblField9.Text = strDelivName
                    lblField10.Text = strDelivXAddr
                    lblField11.Text = strDelivStreet
                    lblField12.Text = strDelivBox
                    lblField13.Text = strDelivCity
                    lblField14.Text = strDelivRegion
                    lblField15.Text = strDelivCountry
                    lblField16.Text = strDelivCode
                    lblTitle.Text = strUserName
                End If
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBECustomer Is Nothing Then
                    objBECustomer.Dispose(True)
                    objBECustomer = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace



