Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WCustomerLoadInfor
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

        ' Declare Variables
        Private objBECustomer As New clsBECustomer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Initialize()
            BindScript()
            CheckPatronInfor()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Customer/WCustomerLoadInfor.js'></script>")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBECustomer
            objBECustomer.InterfaceLanguage = Session("InterfaceLanguage")
            objBECustomer.DBServer = Session("DBServer")
            objBECustomer.ConnectionString = Session("ConnectionString")
            objBECustomer.Initialize()
        End Sub

        ' CheckPatronInfor method
        ' Purpose: Check the valid of patron card and password then display the result
        Private Sub CheckPatronInfor()
            ' Declare variables
            Dim intCustomerID As Integer = 0
            Dim strPassword As String = ""
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
            Dim strApproved As String = ""
            Dim intSecretLevel As Integer = 0

            ' Check the user
            intCustomerID = CInt(Trim(Request("CustomerID")))
            objBECustomer.CustomerID = intCustomerID
            tblCustomer = objBECustomer.GetCustomerInfor
            Call WriteErrorMssg(objBECustomer.ErrorCode, objBECustomer.ErrorMsg)

            If Not tblCustomer Is Nothing Then
                If tblCustomer.Rows.Count > 0 Then
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Name")) Then
                        strFullName = Trim(CStr(tblCustomer.Rows(0).Item("Name"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("ContactPerson")) Then
                        strContactName = Trim(CStr(tblCustomer.Rows(0).Item("ContactPerson"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("EmailAddress")) Then
                        strEmail = Trim(CStr(tblCustomer.Rows(0).Item("EmailAddress"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Telephone")) Then
                        strTelephone = Trim(CStr(tblCustomer.Rows(0).Item("Telephone"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Fax")) Then
                        strFax = Trim(CStr(tblCustomer.Rows(0).Item("Fax"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Note")) Then
                        strNote = Trim(CStr(tblCustomer.Rows(0).Item("Note"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("UserName")) Then
                        strUserName = Trim(CStr(tblCustomer.Rows(0).Item("UserName"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Password")) Then
                        strPassword = Trim(CStr(tblCustomer.Rows(0).Item("Password"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivName")) Then
                        strDelivName = Trim(CStr(tblCustomer.Rows(0).Item("DelivName"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivXAddr")) Then
                        strDelivXAddr = Trim(CStr(tblCustomer.Rows(0).Item("DelivXAddr"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivStreet")) Then
                        strDelivStreet = Trim(CStr(tblCustomer.Rows(0).Item("DelivStreet"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivBox")) Then
                        strDelivBox = Trim(CStr(tblCustomer.Rows(0).Item("DelivBox"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivCity")) Then
                        strDelivCity = Trim(CStr(tblCustomer.Rows(0).Item("DelivCity"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivRegion")) Then
                        strDelivRegion = Trim(CStr(tblCustomer.Rows(0).Item("DelivRegion"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivCountry")) Then
                        strDelivCountry = Trim(CStr(tblCustomer.Rows(0).Item("DelivCountry"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("DelivCode")) Then
                        strDelivCode = Trim(CStr(tblCustomer.Rows(0).Item("DelivCode"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Debt")) Then
                        strDebt = Trim(CStr(tblCustomer.Rows(0).Item("Debt"))).Replace("'", "\'")
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("Approved")) Then
                        strApproved = Trim(CStr(tblCustomer.Rows(0).Item("Approved")))
                    End If
                    If CBool(strApproved) = False Then
                        strApproved = "False"
                    Else
                        strApproved = "True"
                    End If
                    If Not IsDBNull(tblCustomer.Rows(0).Item("SecretLevel")) Then
                        intSecretLevel = tblCustomer.Rows(0).Item("SecretLevel")
                    End If
                    Page.RegisterClientScriptBlock("LoadPatron", "<script language='javascript'>LoadPatronInfor('" & strFullName & _
                        "','" & strContactName & "','" & strEmail & "','" & strTelephone & "','" & _
                        strFax & "','" & strNote & "','" & strUserName & "','" & strPassword & _
                        "','" & strDelivName & "','" & strDelivXAddr & "','" & strDelivStreet & _
                        "','" & strDelivBox & "','" & strDelivCity & "','" & strDelivRegion & "','" & _
                        strDelivCountry & "','" & strDelivCode & "','" & strDebt & "','" & _
                        strApproved & "','" & intSecretLevel & "');</script>")
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
