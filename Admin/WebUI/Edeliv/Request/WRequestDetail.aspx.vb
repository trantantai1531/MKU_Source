Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestDetail
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

        Dim objBERequestCollection As New clsBERequestCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
            Call LoadData()
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Dim strJS As String
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Request/WRequestDetail.js'></script>")

            txtTotalRec.Attributes.Add("OnChange", "if (CheckNumBer(this, '" & ddlLabel.Items(13).Text & "')) {this.value=1;}")

            btnFirst.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrRec.value) > 1) {document.forms[0].txtCurrRec.value = 1; document.forms[0].submit();} else {return false;}")
            btnPrev.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrRec.value) > 1) {document.forms[0].txtCurrRec.value = parseFloat(document.forms[0].txtCurrRec.value) - 1; document.forms[0].submit();} else {return false;}")
            btnNext.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrRec.value) < parseFloat(document.forms[0].txtTotalRec.value)) {document.forms[0].txtCurrRec.value = parseFloat(document.forms[0].txtCurrRec.value) + 1; document.forms[0].submit();} else {return false;}")
            btnLast.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrRec.value) < parseFloat(document.forms[0].txtTotalRec.value)) {document.forms[0].txtCurrRec.value = document.forms[0].txtTotalRec.value; document.forms[0].submit();} else {return false;}")

            strJS = "<script language='javascript'>" & Chr(10)
            strJS = strJS & "ActID = new Array(10);" & Chr(10)
            strJS = strJS & "ActName = new Array(10);" & Chr(10)
            strJS = strJS & "for (i = 0; i <= 9; i++) {" & Chr(10)
            strJS = strJS & "ActID[i] = i + 1;}" & Chr(10)
            strJS = strJS & "ActName[0] = '" & ddlLabel.Items(1).Text & "'" & Chr(10)
            strJS = strJS & "ActName[1] = '" & ddlLabel.Items(2).Text & "'" & Chr(10)
            strJS = strJS & "ActName[2] = '" & ddlLabel.Items(3).Text & "'" & Chr(10)
            strJS = strJS & "ActName[3] = '" & ddlLabel.Items(4).Text & "'" & Chr(10)
            strJS = strJS & "ActName[4] = '" & ddlLabel.Items(5).Text & "'" & Chr(10)
            strJS = strJS & "ActName[5] = '" & ddlLabel.Items(6).Text & "'" & Chr(10)
            strJS = strJS & "ActName[6] = '" & ddlLabel.Items(7).Text & "'" & Chr(10)
            strJS = strJS & "ActName[7] = '" & ddlLabel.Items(8).Text & "'" & Chr(10)
            strJS = strJS & "ActName[8] = '" & ddlLabel.Items(9).Text & "'" & Chr(10)
            strJS = strJS & "ActName[9] = '" & ddlLabel.Items(10).Text & "'" & Chr(10)
            strJS = strJS & "</script>"
            Page.RegisterClientScriptBlock("LoadArray", strJS)
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBERequestCollection object
            objBERequestCollection.ConnectionString = Session("ConnectionString")
            objBERequestCollection.DBServer = Session("DBServer")
            objBERequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBERequestCollection.Initialize()
        End Sub

        ' LoadData method
        ' Purpose: LoadData
        Private Sub LoadData()
            Dim tblTemp As DataTable
            Dim lngTotalRec As Long = 0
            Dim lngTopNum As Long = 0
            Dim lngCurrentPos As Long = 0
            Dim lngRequestID As Long = 0
            Dim arrRequestID() As String
            Dim inti As Integer = 0

            ' Check Filter or not 
            If Not Session("ERequestIDs") Is Nothing Then
                ' Filter
                arrRequestID = Split(Session("ERequestIDs"), ",")
                If Not Page.IsPostBack Then
                    If Not Request("RequestID") Is Nothing Then
                        For inti = 0 To UBound(arrRequestID)
                            If Request("RequestID") = Trim(arrRequestID(inti)) Then
                                txtCurrRec.Text = inti + 1
                            End If
                        Next
                    End If
                End If
                lngRequestID = arrRequestID(CLng(txtCurrRec.Text) - 1)
                txtTotalRec.Text = UBound(arrRequestID) + 1
                Call BindData(lngRequestID)
            Else ' Not Filter
                If Not Request("RequestID") Is Nothing Then
                    If Not Page.IsPostBack Then
                        objBERequestCollection.RequestID = CLng(Request("RequestID"))
                    End If
                End If
                If CLng(txtCurrRec.Text) > 0 Then
                    lngTopNum = CLng(txtCurrRec.Text)
                End If
                objBERequestCollection.TopNum = lngTopNum
                tblTemp = objBERequestCollection.GetERequestNum(lngTotalRec, lngCurrentPos)
                Call WriteErrorMssg(ddlLabel.Items(12).Text, objBERequestCollection.ErrorMsg, ddlLabel.Items(11).Text, objBERequestCollection.ErrorCode)
                If lngTotalRec > 0 Then
                    If Not Page.IsPostBack Then
                        txtCurrRec.Text = CStr(lngCurrentPos)
                    End If
                    lngRequestID = CLng(tblTemp.Rows(0).Item("MAXID"))
                    txtTotalRec.Text = lngTotalRec
                    tblTemp.Dispose()
                    tblTemp = Nothing
                End If
                Call BindData(lngRequestID)
            End If
        End Sub

        ' BindData method
        ' Purpose: BindData
        Private Sub BindData(ByVal lngRequestID As Long)
            Dim tblTemp As DataTable

            objBERequestCollection.RequestID = lngRequestID
            tblTemp = objBERequestCollection.GetRequestInfor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(12).Text, objBERequestCollection.ErrorMsg, ddlLabel.Items(11).Text, objBERequestCollection.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                Page.RegisterClientScriptBlock("LoadRegID", "<script language='javascript'> LoadToSentForm(" & lngRequestID & "," & tblTemp.Rows(0).Item("StatusID") & ");</script>")

                ' File infor
                lblNameOfFile.Text = tblTemp.Rows(0).Item("FileName").ToString.Trim
                lblPriceOfFile.Text = tblTemp.Rows(0).Item("Price").ToString.Trim & " (" & tblTemp.Rows(0).Item("Currency").ToString.Trim & ")"
                lblSizeOfFile.Text = tblTemp.Rows(0).Item("FileSize").ToString.Trim
                lblURL.Text = tblTemp.Rows(0).Item("URL").ToString.Trim
                lblBook.Text = tblTemp.Rows(0).Item("TITLE").ToString.Trim
                lblStatus.Text = tblTemp.Rows(0).Item("Status").ToString.Trim
                lblNote.Text = tblTemp.Rows(0).Item("Note").ToString.Trim

                ' Customer infor
                lblCustomerName.Text = tblTemp.Rows(0).Item("Name").ToString.Trim
                lblAddress.Text = tblTemp.Rows(0).Item("DelivXAddr").ToString.Trim
                lblPhone.Text = tblTemp.Rows(0).Item("Telephone").ToString.Trim
                lblFAX.Text = tblTemp.Rows(0).Item("FAX").ToString.Trim
                lblEmail.Text = tblTemp.Rows(0).Item("EmailAddress").ToString.Trim
                lblContactorName.Text = tblTemp.Rows(0).Item("ContactPerson").ToString.Trim
                lblDebt.Text = tblTemp.Rows(0).Item("Debt").ToString.Trim
                lblCustomerNote.Text = tblTemp.Rows(0).Item("CustomerNote").ToString.Trim

                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' btnPrev_Click event
        Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
            Call LoadData()
        End Sub

        ' btnFirst_Click event
        Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
            Call LoadData()
        End Sub

        ' btnNext_Click event
        Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
            Call LoadData()
        End Sub

        ' btnLast_Click event
        Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
            Call LoadData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBERequestCollection Is Nothing Then
                    objBERequestCollection.Dispose(True)
                    objBERequestCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace