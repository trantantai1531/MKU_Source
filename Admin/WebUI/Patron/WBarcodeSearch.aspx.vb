' Class: WBarcodeSearch
' Puspose: Show print barcode form
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WBarcodeSearch
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtCell As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPC As New clsBPatronCollection
        Private objBP As New clsBPatron
        Private objBCChart As New clsBCommonChart

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize  objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()

            ' Initialize objBP object
            objBP.DBServer = Session("DBServer")
            objBP.ConnectionString = Session("ConnectionString")
            objBP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBP.Initialize()

            ' Initialize objBCChart object
            objBCChart.DBServer = Session("DBServer")
            objBCChart.ConnectionString = Session("ConnectionString")
            objBCChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCChart.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(53) Then
                btnBarCode.Enabled = False
            End If
        End Sub

        ' Method: BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WBarcodeSearchJs", "<script language='javascript' src='js/WBarcodeSearch.js'></script>")



            SetCheckNumber(txtWidth, ddlLabel.Items(5).Text, "1")
            SetCheckNumber(txtHeight, ddlLabel.Items(5).Text, "70")
            SetCheckNumber(txtCol, ddlLabel.Items(5).Text, "5")
            SetCheckNumber(txtOnPage, ddlLabel.Items(5).Text, "20")

            optIDs.Attributes.Add("OnClick", "document.forms[0].txtFromIDs.focus();document.forms[0].txtFromDate.value='';document.forms[0].txtToDate.value='';document.forms[0].txtID.value='';")
            optDate.Attributes.Add("OnClick", "document.Form1.txtFromDate.focus();document.forms[0].txtFromIDs.value='';document.forms[0].txtToIDs.value='';document.forms[0].txtID.value='';")
            optID.Attributes.Add("OnClick", "document.Form1.txtID.focus();document.forms[0].txtFromDate.value='';document.forms[0].txtToDate.value='';document.forms[0].txtToIDs.value='';document.forms[0].txtFromIDs.value='';")
            Me.RegisterCalendar("..")
            SetOnclickCalendar(hrfFromDate, txtFromDate, ddlLabel.Items(3).Text)
            SetOnclickCalendar(hrfToDate, txtToDate, ddlLabel.Items(3).Text)
            hrfCardPrint.NavigateUrl = "javascript:parent.Workform.location.href='WCards.aspx';"

            btnBarCode.Attributes.Add("Onlick", " if(!ValidData('" & ddlLabel.Items(4).Text & "')){return false;}")
            btnReset.Attributes.Add("OnClick", "ClearAll(); return false;")
        End Sub

        ' Gen barcode image
        Private Sub btnBarCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBarCode.Click
            Dim ArrID As Object
            Dim strIDs As String
            Dim inti As Integer
            Dim ArrCode() As String
            Dim strOrder As String = ""
            ReDim ArrCode(-1)

            objBPC.TypeSearch = "Simple"
            objBPC.SelectTop = ddlBoundResult.SelectedValue
            objBPC.OrderBy = ddlOrderBy.SelectedValue
            Select Case ddlOrderBy.SelectedValue
                Case 1 ' Ngay cap the
                    strOrder = " ORDER BY ValidDate"
                Case 2 ' Ngay het han the
                    strOrder = " ORDER BY ExpiredDate"
                Case 3 ' Ngay sinh
                    strOrder = " ORDER BY DOB"
                Case 4 ' So the
                    strOrder = " ORDER BY Code"
                Case 5 'First Name
                    strOrder = " ORDER BY FirstName"
                Case 6 'Last Name
                    strOrder = " ORDER BY LastName"
            End Select
            If optIDs.Checked Then
                If Trim(txtFromIDs.Text) <> "" Then
                    objBPC.FromCode = txtFromIDs.Text
                Else
                    objBPC.FromCode = ""
                End If
                If Trim(txtToIDs.Text) <> "" Then
                    objBPC.ToCode = txtToIDs.Text
                Else
                    objBPC.ToCode = ""
                End If
            End If
            If optDate.Checked Then
                objBPC.FromValidDate = txtFromDate.Text
                objBPC.ToValidDate = txtToDate.Text
            End If
            If optID.Checked = True Then ' User input data
                If Right(Len(txtID.Text) - 1, Len(txtID.Text)) = ";" Then
                    txtID.Text = Left(txtID.Text, Len(txtID.Text) - 1)
                End If
                If InStr(txtID.Text, ";") > 0 Then
                    ReDim ArrCode(UBound(Split(txtID.Text, ";")))
                    ArrCode = Split(txtID.Text, ";")
                Else
                    ReDim ArrCode(0)
                    ArrCode(0) = txtID.Text
                End If
            Else
                ArrID = objBPC.Search()
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

                If Not (ArrID Is Nothing) Then
                    For inti = 0 To UBound(ArrID)
                        strIDs = strIDs & CStr(ArrID(inti)) & ","
                    Next
                    strIDs = Left(strIDs, Len(strIDs) - 1)
                End If
                Dim tblCode As New DataTable
                objBP.Fields = " A.Code "
                objBP.PatronIDs = strIDs


                Dim dataTemp As DataTable = objBP.GetPatron(strOrder)
                Dim view As DataView = dataTemp.DefaultView
                view.Sort = "Code ASC"
                Dim dataOrderByPatronCode As DataTable = view.ToTable()

                tblCode = dataOrderByPatronCode
                If Not tblCode Is Nothing Then
                    ReDim ArrCode(tblCode.Rows.Count - 1)
                    For inti = 0 To tblCode.Rows.Count - 1
                        ArrCode(inti) = CStr(tblCode.Rows(inti).Item(1))
                    Next
                End If
            End If
            If Not ArrCode Is Nothing Then
                If UBound(ArrCode) >= 0 Then
                    objBCChart.MakeImgBarcode(ArrCode, ddlImgType.SelectedItem.Value, CInt(txtWidth.Text), CInt(txtHeight.Text), ddlType.SelectedItem.Value, "", "", "", ddlRotate.SelectedItem.Value, , True)
                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCChart.ErrorMsg, ddlLabel.Items(1).Text, objBCChart.ErrorCode)

                    If Not objBCChart.BarCodeImg Is Nothing Then
                        If UBound(objBCChart.BarCodeImg) >= 0 Then
                            Session("BarCode") = Nothing
                            Session("Type") = Nothing
                            Session("ImgType") = Nothing
                            Session("Col") = Nothing
                            Session("OnPage") = Nothing
                            Session("NumPage") = Nothing
                            Session("Rotate") = Nothing
                            Session("BarCode") = objBCChart.BarCodeImg
                            Session("Type") = CInt(ddlType.SelectedItem.Value)
                            Session("ImgType") = CInt(ddlImgType.SelectedItem.Value)
                            Session("Col") = CInt(txtCol.Text)
                            If txtOnPage.Text <> "" And IsNumeric(txtOnPage.Text) Then
                                Session("OnPage") = CInt(txtOnPage.Text)
                            Else
                                Session("OnPage") = 20
                            End If
                            Session("NumPage") = 1
                            Session("Rotate") = CInt(ddlRotate.SelectedItem.Value)
                            Response.Redirect("WBarcodesFrame.aspx")
                        End If
                    End If
                End If
            End If
        End Sub

        ' Page_Unloade method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBP Is Nothing Then
                objBP.Dispose(True)
                objBP = Nothing
            End If
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
            If Not objBCChart Is Nothing Then
                objBCChart.Dispose(True)
                objBCChart = Nothing
            End If
        End Sub
    End Class
End Namespace