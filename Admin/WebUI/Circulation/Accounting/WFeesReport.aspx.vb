Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Imports System.Globalization


Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WFeesReport
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

        Private objBAccountTrans As New clsBAccountTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBAccountTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccountTrans.DBServer = Session("DBServer")
            objBAccountTrans.ConnectionString = Session("ConnectionString")
            objBAccountTrans.Initialize()

        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim strYear As String
            Dim strMonth As String
            Dim strPatronCode As String
            Dim tblAccount As DataTable
            Dim intDisplay As Integer

            ' Get the patron code
            If Trim(Request("PatronCode")) = "0" Or Trim(Request("PatronCode")) = Nothing Then
                strPatronCode = ""
            Else
                strPatronCode = Trim(Request("PatronCode"))
            End If

            ' Get the month value
            If Trim(Request("Month")) = "0" Or Trim(Request("Month")) = Nothing Then
                strMonth = "0"
            Else
                strMonth = Trim(Request("Month"))
            End If

            ' Get the month value
            If Trim(Request("Year")) = "0" Or Trim(Request("Year")) = Nothing Then
                strYear = "0"
            Else
                strYear = Trim(Request("Year"))
            End If


            ' Get the type of display mode (seetled, unseetled report)
            If Trim(Request("Display")) = "1" Then
                objBAccountTrans.Type = 1
                intDisplay = 1
                lblSettledTitle.Visible = True
                lblUnsettledTitle.Visible = False
            ElseIf Trim(Request("Display")) = "2" Then
                objBAccountTrans.Type = 2
                intDisplay = 2
                lblSettledTitle.Visible = False
                lblUnsettledTitle.Visible = True
            End If

            ' Get the SubTitle
            If strPatronCode <> "" Then
                lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(2).Text & " " & strPatronCode
                If strMonth <> "0" Then
                    lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(4).Text & " " & strMonth
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(6).Text & " " & strYear
                    End If
                Else
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(6).Text & " " & strYear
                    End If
                End If
            Else
                If strMonth <> "0" Then
                    lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(3).Text & " " & strMonth
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(6).Text & " " & strYear
                    End If
                Else
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(5).Text & " " & strYear
                    End If
                End If
            End If

            If Trim(lblSubTitle.Text) <> "" Then
                lblSubTitle.Visible = True
            Else
                lblSubTitle.Visible = False
            End If

            ' Transfer the properties for class B
            objBAccountTrans.Year = CInt(strYear)
            objBAccountTrans.PatronCode = strPatronCode
            objBAccountTrans.Month = CInt(strMonth)
            objBAccountTrans.LibID = clsSession.GlbSite
            tblAccount = objBAccountTrans.GetAccountInfor ' Get the data

            ' Display the sum of seetled, unseetled and remain amount
            If Not tblAccount Is Nothing Then
                Select Case intDisplay
                    Case 1
                        lblSumary.Text = formatCurrency(objBAccountTrans.Settled.ToString())
                        If tblAccount.Rows.Count > 0 Then
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                    Case 2
                        lblSumary.Text = formatCurrency(objBAccountTrans.UnSettled.ToString())
                        If tblAccount.Rows.Count > 0 Then
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                End Select

            End If

            ' Display the result (For each display mode)
            If intDisplay = 1 Or intDisplay = 2 Then
                dgtResult.DataSource = tblAccount
                dgtResult.DataBind()
            End If


        End Sub

        ' fCurrency method
        Public Function fCurrency(ByVal strfCurrency) As String
            Dim strfCurrency2 As String
            Dim blnMinusNum As Boolean
            Dim intDecimalpoint As Integer

            strfCurrency2 = ""
            If Trim(strfCurrency) = "" Or Not IsNumeric(strfCurrency) Then
                fCurrency = strfCurrency
            Else
                blnMinusNum = False
                If CDbl(strfCurrency) < 0 Then
                    blnMinusNum = True
                    strfCurrency = -1 * CDbl(strfCurrency)
                End If
                intDecimalpoint = InStr(strfCurrency, ".")
                If intDecimalpoint > 0 Then
                    strfCurrency2 = Right(strfCurrency, Len(strfCurrency) - intDecimalpoint + 1)
                    strfCurrency = Left(strfCurrency, intDecimalpoint - 1)
                Else
                    strfCurrency2 = ".00"
                End If
                While Len(strfCurrency) > 3
                    strfCurrency2 = "," & Right(strfCurrency, 3) & strfCurrency2
                    strfCurrency = Left(strfCurrency, Len(strfCurrency) - 3)
                End While
                strfCurrency2 = strfCurrency & strfCurrency2
                If blnMinusNum Then
                    fCurrency = "-" & strfCurrency2
                Else
                    fCurrency = strfCurrency2
                End If
            End If
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBAccountTrans Is Nothing Then
                    objBAccountTrans.Dispose(True)
                    objBAccountTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Public Function formatCurrency(ByVal str As String) As String
            Return Double.Parse(str).ToString("N0", CultureInfo.InvariantCulture)
        End Function
        Protected Sub dgtResult_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgtResult.ItemDataBound
            If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                'If the first column is a date
                Dim lblTemp As Label = e.Item.FindControl("lblAmountDisplay")
                lblTemp.Text = formatCurrency(lblTemp.Text)
                Dim lblAmountDisplay As Label = e.Item.FindControl("lblTotal")
                lblAmountDisplay.Text = formatCurrency(lblAmountDisplay.Text)
            End If
        End Sub
    End Class
End Namespace