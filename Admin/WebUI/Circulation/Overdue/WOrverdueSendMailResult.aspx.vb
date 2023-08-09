' Class: WOverdueSendMailResult
' Puspose: Send Mail to Overdue Patron
' Creator: Sondp
' CreatedDate: 31/08/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOrverdueSendMailResult
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
        Private objBOverdueTransaction As New clsBOverdueTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Dim strPatronName As String = ""
            If Not Page.IsPostBack Then
                If Not Request("ddlOverdueTemplate") Is Nothing And CInt(Request("ddlOverdueTemplate")) > 0 Then
                    Call BindData()
                    If Not Request("txtOverduePatron") = "" Then
                        objBOverdueTransaction.DueTime = CInt(Request("txtOverduePatron"))
                    Else
                        objBOverdueTransaction.DueTime = 1  ' Default
                    End If

                    Dim strPickPatronIDs As String = Request("txtPickPatron")
                    Dim strOverduePatron As String = Request("ddlOverduePatron")
                    Dim intOverduePrintMode As Integer = CInt(Request("txtOverduePrintMode"))

                    If intOverduePrintMode = 3 Then
                        intOverduePrintMode = 2

                        Dim valuePatronGroup As String = Request("hidCheckedPatronGroup")

                        objBOverdueTransaction.SelectMode = "ALL"
                        objBOverdueTransaction.Logic = ""
                        objBOverdueTransaction.DueTime = 0
                        objBOverdueTransaction.PatronIDs = ""
                        Dim tblOverduePatrons As DataTable = objBOverdueTransaction.GetOverduePatron("", 0)
                        strPickPatronIDs = ""
                        strOverduePatron = ""

                        If Not tblOverduePatrons Is Nothing Then
                            If tblOverduePatrons.Rows.Count > 0 Then
                                Dim dvOverduePatron As DataView = tblOverduePatrons.DefaultView
                                dvOverduePatron.RowFilter = "Email LIKE '%@%' AND PatronGroupID IN (" & valuePatronGroup & ")"
                                Dim tmpTable As DataTable = dvOverduePatron.ToTable
                                If Not tmpTable Is Nothing Then
                                    If tmpTable.Rows.Count > 0 Then
                                        For Each row As DataRow In tmpTable.Rows
                                            If strPickPatronIDs = "" Then
                                                strPickPatronIDs = row.Item("ID") & ""
                                            Else
                                                strPickPatronIDs = strPickPatronIDs & "," & row.Item("ID") & ""
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                        End If
                    End If


                    objBOverdueTransaction.OverduePrintMode = CShort(intOverduePrintMode)
                    objBOverdueTransaction.Logic = Request("ddlOverduePatron")
                    objBOverdueTransaction.PickPatronIDs = strPickPatronIDs
                    objBOverdueTransaction.LibID = clsSession.GlbSite
                 
                    strPatronName = SendEmailToOverduePatron(objBOverdueTransaction.GetOverduePatronSendMail)
                    ' WriteLog
                    Call WriteLog(108, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    If Not strPatronName = "" Then
                        lblPrintLetter.Text = lblSendMailSuccessful.Text & strPatronName
                    End If
                End If
                If strPatronName = "" Then
                    Page.RegisterClientScriptBlock("NotFoundJs", "<script language='javascript'>alert('" & lblError.Text & "');window.location.href='WOrverdueSendMail.aspx';</script>")
                End If
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            ' Init objBOverdueTransaction object
            objBOverdueTransaction.ConnectionString = Session("ConnectionString")
            objBOverdueTransaction.DBServer = Session("DBServer")
            objBOverdueTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTransaction.Initialize()
        End Sub

        ' Method: BindData
        ' Purpose: BindData
        Private Sub BindData()
            objBOverdueTransaction.MainRowTitle.Add(lblItemCode.Text, "ITEMCODE")
            objBOverdueTransaction.MainRowTitle.Add(lblCopyNumber.Text, "COPYNUMBER")
            objBOverdueTransaction.MainRowTitle.Add(lblItemTitle.Text, "ITEMTITLE")
            objBOverdueTransaction.MainRowTitle.Add(lblCheckOutDate.Text, "CHECKOUTDATE")
            objBOverdueTransaction.MainRowTitle.Add(lblCheckInDate.Text, "CHECKINDATE")
            objBOverdueTransaction.MainRowTitle.Add(lblOverDueDate.Text, "OVERDUEDATE")
            objBOverdueTransaction.MainRowTitle.Add(lblPenati.Text, "PENATI")
            objBOverdueTransaction.MainRowTitle.Add(lblSequency.Text, "SEQUENCY")
            objBOverdueTransaction.MainRowTitle.Add(lbLIBRARY.Text, "LIBRARY")
            objBOverdueTransaction.MainRowTitle.Add(lbSTORE.Text, "STORE")
            objBOverdueTransaction.MainRowTitle.Add(lbNOTE.Text, "NOTE")
        End Sub

        ' Purpose: Send mail to Overdue patron method
        ' In: DataView
        ' Out: Successful patron(s)
        Private Function SendEmailToOverduePatron(ByVal dvOverduePatron As DataView) As String
            Dim strPatronName As String = ""
            Dim strEmailTo As String
            Dim arrOverduePatronInfo() As String
            Dim inti As Integer
            Dim intSendSuccess As Integer
            Dim tblOverduePatron As New DataTable

            If dvOverduePatron.Count > 0 Then
                dvOverduePatron.RowFilter = "Email LIKE '%@%'"
                tblOverduePatron = dvOverduePatron.Table
                objBOverdueTransaction.UserID = Session("UserID")
                If Request("ddlOverduePatron") & "" <> "" Then
                    arrOverduePatronInfo = objBOverdueTransaction.GenOverdueInfor(tblOverduePatron, CInt(Request("ddlOverdueTemplate")), Request("ddlOverduePatron") & Request("txtOverduePatron"))
                Else
                    arrOverduePatronInfo = objBOverdueTransaction.GenOverdueInfor(tblOverduePatron, CInt(Request("ddlOverdueTemplate")), "")
                End If

                For inti = 0 To tblOverduePatron.Rows.Count - 1
                    If Not IsDBNull(tblOverduePatron.Rows(inti).Item("Email")) Then
                        strEmailTo = tblOverduePatron.Rows(inti).Item("Email")
                        intSendSuccess = SendMail(lblOverdueMessage.Text, arrOverduePatronInfo(inti), strEmailTo, True)
                        If intSendSuccess = 1 Then
                            strPatronName &= tblOverduePatron.Rows(inti).Item("Name") & ","
                        Else
                            strPatronName &= " - Lỗi gửi mail đến : " & tblOverduePatron.Rows(inti).Item("Name") & ","
                        End If
                    End If
                Next
                If Not strPatronName = "" Then
                    Return (Left(strPatronName, Len(strPatronName) - 1))
                Else
                    Return ("")
                End If
            End If
        End Function
        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOverdueTransaction Is Nothing Then
                    objBOverdueTransaction.Dispose(True)
                    objBOverdueTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace