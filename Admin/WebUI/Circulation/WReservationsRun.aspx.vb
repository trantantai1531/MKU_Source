Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Logical

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WReservationsRun
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
        Private objBRT As New clsBReservationTransaction
        Private objBReserve As New clsBReserve

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            If Not Page.IsPostBack Then
                Call GetReservList()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init objBRT object
            objBRT.ConnectionString = Session("ConnectionString")
            objBRT.DBServer = Session("DBServer")
            objBRT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRT.Initialize()
            ' Init objBReserve object
            objBReserve.ConnectionString = Session("ConnectionString")
            objBReserve.DBServer = Session("DBServer")
            objBReserve.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBReserve.Initialize()
        End Sub
        'Method: GetReservList
        'Purpose: Get the Reservations Information 
        Sub GetReservList()
            Dim tblReservList As DataTable
            Dim tblReserveRequestList As DataTable
            Dim tblGetRstCopyNumber As DataTable
            Dim tblRowRstInfor() As DataRow
            Dim tblRowRstCopynumber() As DataRow
            Dim intCountInfor As Integer
            Dim intIndex As Integer
            Dim arrIndex()
            Dim tblRowCopyNumber() As DataRow
            Dim tblRow As DataRow
            Dim strRowReserveRequest As String = ""
            Dim strRowReserve As String = ""

            objBRT.UserID = Session("UserID")
            'tblReservList = objBRT.GetResereAll(1)
            tblReserveRequestList = objBRT.GetReservationPatronInfor()
            tblReservList = objBReserve.FillReserve(0, 0, "", "", "")

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRT.ErrorMsg, ddlLabel.Items(0).Text, objBRT.ErrorCode)
            If Not tblReserveRequestList Is Nothing AndAlso tblReserveRequestList.Rows.Count > 0 Then
                If tblReserveRequestList.DefaultView.Count > 0 Then
                    tblGetRstCopyNumber = objBRT.GetReservationInfor()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRT.ErrorMsg, ddlLabel.Items(0).Text, objBRT.ErrorCode)

                    If Not tblReserveRequestList Is Nothing And Not tblGetRstCopyNumber Is Nothing AndAlso tblReserveRequestList.DefaultView.Count > 0 Then

                        intCountInfor = tblReserveRequestList.DefaultView.Count - 1

                        ReDim arrIndex(intCountInfor + 1)
                        For intIndex = 0 To intCountInfor
                            arrIndex(intIndex) = ""

                            If tblReserveRequestList.DefaultView.Item(intIndex).Item("COPYNUMBER") <> "" Then
                                tblRowCopyNumber = tblGetRstCopyNumber.Select("CRR_ID=" & tblReserveRequestList.DefaultView.Item(intIndex).Item("CRR_ID") & " AND CopyNumber= '" & tblReserveRequestList.DefaultView.Item(intIndex).Item("COPYNUMBER") & "'")
                            Else
                                tblRowCopyNumber = tblGetRstCopyNumber.Select("CRR_ID=" & tblReserveRequestList.DefaultView.Item(intIndex).Item("CRR_ID"))
                            End If
                            tblGetRstCopyNumber.Select()

                            If tblRowCopyNumber.Length > 0 Then
                                arrIndex(intIndex) = " - <B>" & ddlLabel.Items(2).Text & "</B>"
                                For Each tblRow In tblRowCopyNumber
                                    arrIndex(intIndex) = arrIndex(intIndex) & ": <I>" & tblRow.Item("COPYNUMBER") & "( " & tblRow.Item("Symbol") & " @ " & tblRow.Item("Shelf") & " ) " & "</I>"
                                Next
                            Else
                                arrIndex(intIndex) = arrIndex(intIndex) & ": <I>" & ddlLabel.Items(3).Text & "</I>"
                            End If
                            strRowReserveRequest = strRowReserveRequest & "<U>" & CStr(intIndex + 1) & ">" & ddlLabel.Items(6).Text & "</U>" & tblReserveRequestList.DefaultView.Item(intIndex).Item("MAINITEM") & CStr(arrIndex(intIndex)) & " " & ddlLabel.Items(7).Text & " " & tblReserveRequestList.DefaultView.Item(intIndex).Item("FULLNAME") & "(" & tblReserveRequestList.DefaultView.Item(intIndex).Item("CODE") & ") " & ddlLabel.Items(8).Text & " " & tblReserveRequestList.DefaultView.Item(intIndex).Item("CREATEDDATE") & ".   "
                        Next
                    End If
                End If


                'If tblReservList.DefaultView.Count > 0 Then
                '    intIndex = 0
                '    For Each row As DataRowView In tblReservList.DefaultView
                '        strRowReserve = strRowReserve & "<U>" & CStr(intIndex + 1) & ">" & ddlLabel.Items(6).Text & "</U>" & row.Item("MAINITEM") & " " & ddlLabel.Items(7).Text & " " & row.Item("FULLNAME") & "(" & row.Item("CODE") & ") " & lblReserveCreate.Text & " " & row.Item("CREATEDDATE") & ".   "
                '        intIndex = intIndex + 1
                '    Next
                'End If

                'lblReserve.Text = lblReserve.Text & strRowReserve
                lblReserveRequest.Text = lblReservation.Text & strRowReserveRequest
            Else
                'lblReserve.Text = lblReserve.Text & lblReserveNull.Text
                lblReserveRequest.Text = lblReserveRequest.Text & ddlLabel.Items(9).Text
            End If
            '' Load danh sach dang ky dat cho
            If Not tblReservList Is Nothing AndAlso tblReservList.Rows.Count > 0 Then

                If tblReservList.DefaultView.Count > 0 Then
                    Dim intRowIndex As Integer = 0
                    For Each Rows As DataRowView In tblReservList.DefaultView
                        strRowReserve = strRowReserve & "<U>" & CStr(intRowIndex + 1) & ">" & ddlLabel.Items(6).Text & "</U>" & Rows.Item("CONTENT") & " " & ddlLabel.Items(7).Text & " " & Rows.Item("FULLNAME") & "(" & Rows.Item("PATRONCODE") & ") " & lblReserveCreate.Text & " " & Rows.Item("DATECREATE") & ".   "
                        intRowIndex = intRowIndex + 1
                    Next
                End If
                lblReserve.Text = lblReservationHolding.Text & strRowReserve
            Else
                lblReserve.Text = lblReserve.Text & lblReserveNull.Text
            End If
        End Sub
        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Realease the objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRT Is Nothing Then
                    objBRT.Dispose(True)
                    objBRT = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
