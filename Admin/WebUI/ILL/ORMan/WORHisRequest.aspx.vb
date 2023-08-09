Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORHisRequest
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
        Dim objBILLOutRequest As New clsBILLOutRequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindData()
            Call BindScript()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(30).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLInRequest
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            objBILLOutRequest.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            If Request("HasMail") & "" <> "" Then
                btnClose.Attributes.Add("OnClick", "opener.top.main.Workform.location.href='WORMan.aspx';self.close();")
            Else
                btnClose.Attributes.Add("OnClick", "self.close();")
            End If
        End Sub

        ' BindData method
        ' Purpose: Get the request history
        Private Sub BindData()
            ' Declare variables
            Dim tblRequestHistory As DataTable
            Dim intAPDUType As Integer = 0
            Dim intAlert As Integer = 0
            Dim strTransactionDate As String = ""
            Dim strColor As String = ""
            Dim intIndex As Integer
            Dim blnValid As Boolean = True
            Dim strContentHis As String = ""

            If IsNumeric(Request.QueryString("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request.QueryString("ILLID"))
                If Request("HasMail") & "" <> "" Then
                    tblRequestHistory = objBILLOutRequest.GetORHistoryInfor(True)
                Else
                    tblRequestHistory = objBILLOutRequest.GetORHistoryInfor
                End If

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

                If Not tblRequestHistory Is Nothing Then
                    If tblRequestHistory.Rows.Count > 0 Then
                        For intIndex = 0 To tblRequestHistory.Rows.Count - 1
                            ' Alert
                            If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Alert")) Then
                                intAlert = CInt(tblRequestHistory.Rows(intIndex).Item("Alert"))
                            End If
                            ' APDUType
                            If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("APDUType")) Then
                                intAPDUType = CInt(tblRequestHistory.Rows(intIndex).Item("APDUType"))
                            End If
                            ' Set color
                            Select Case intAPDUType
                                Case 1, 5, 6, 8, 10, 13
                                    strColor = "990000"
                                Case 3, 4, 7, 9, 11, 12, 14
                                    strColor = "000099"
                                Case Else
                                    strColor = "000000"
                            End Select
                            ' Set images
                            If Not intAlert = 0 Then
                                strContentHis = strContentHis & "<DL><DT><IMG SRC=""../images/alert.gif"" WIDTH=12 HEIGHT=31 BORDER=0 ALT=""Alert"">"
                            Else
                                strContentHis = strContentHis & "<DL><DT><IMG SRC=""../images/spacer.gif"" WIDTH=12 HEIGHT=31 BORDER=0 ALT=""Alert"">"
                            End If
                            ' Bind Data
                            If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("TRANSACTIONDATE")) And Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("APDUDisplay")) Then
                                strContentHis = strContentHis & "<B><FONT COLOR=" & strColor & ">" & tblRequestHistory.Rows(intIndex).Item("TRANSACTIONDATE") & "&nbsp; &nbsp; ** " & tblRequestHistory.Rows(intIndex).Item("APDUDisplay") & " **</font></B><BR>"
                            End If
                            Select Case intAPDUType
                                Case 1
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("LibrarySymbol")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(1).Text & ": " & tblRequestHistory.Rows(intIndex).Item("LibrarySymbol") & "<BR>"
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")) Then
                                        strContentHis = strContentHis & ddlLabel.Items(2).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE") & "<BR>"
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MDUEDATE")) Then
                                        strContentHis = strContentHis & ddlLabel.Items(3).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MDUEDATE") & "<BR>"
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("STD")) Then
                                        strContentHis = strContentHis & ddlLabel.Items(4).Text & ": " & tblRequestHistory.Rows(intIndex).Item("STD") & "<BR>"
                                    End If
                                Case 3
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(5).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE") & "<BR>"
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("STD")) Then
                                        strContentHis = strContentHis & ddlLabel.Items(6).Text & ": " & tblRequestHistory.Rows(intIndex).Item("STD") & "<BR>"
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MDUEDATE")) Then
                                        strContentHis = strContentHis & ddlLabel.Items(7).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MDUEDATE") & "<BR>"
                                    End If
                                    strContentHis = strContentHis & "&nbsp; &nbsp; &nbsp;" & ddlLabel.Items(8).Text
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Renewable")) Then
                                        If Not CInt(tblRequestHistory.Rows(intIndex).Item("Renewable")) = 0 Then
                                            strContentHis = strContentHis & ": " & ddlLabel.Items(20).Text
                                        Else
                                            strContentHis = strContentHis & ": " & ddlLabel.Items(21).Text
                                        End If
                                    End If
                                Case 4
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("TRE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(9).Text & ": "
                                        Select Case CInt(tblRequestHistory.Rows(intIndex).Item("TRE"))
                                            Case 1
                                                strContentHis = strContentHis & ddlLabel.Items(10).Text
                                            Case 2
                                                strContentHis = strContentHis & ddlLabel.Items(11).Text
                                            Case 3
                                                strContentHis = strContentHis & ddlLabel.Items(12).Text
                                            Case 4
                                                strContentHis = strContentHis & ddlLabel.Items(13).Text
                                            Case 5
                                                strContentHis = strContentHis & ddlLabel.Items(14).Text
                                            Case 6
                                                strContentHis = strContentHis & ddlLabel.Items(15).Text
                                            Case 7
                                                strContentHis = strContentHis & ddlLabel.Items(16).Text
                                        End Select
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("ReasonCode")) Then
                                        strContentHis = strContentHis & ddlLabel.Items(17).Text & ": " & tblRequestHistory.Rows(intIndex).Item("ReasonCode")
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Reason_Eng")) Then
                                        strContentHis = strContentHis & " -- " & tblRequestHistory.Rows(intIndex).Item("Reason_Eng")
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Reason_Viet")) Then
                                        strContentHis = strContentHis & " (" & tblRequestHistory.Rows(intIndex).Item("Reason_Viet") & ")"
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")) Then
                                        strContentHis = strContentHis & ddlLabel.Items(18).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")
                                        strContentHis = strContentHis & "<BR>"
                                    End If
                                Case 5
                                    strContentHis = strContentHis & "<DD>" & ddlLabel.Items(23).Text & ": "
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Answer")) Then
                                        If Not CInt(tblRequestHistory.Rows(intIndex).Item("Answer")) = 0 Then
                                            strContentHis = strContentHis & ddlLabel.Items(19).Text
                                        Else
                                            strContentHis = strContentHis & ddlLabel.Items(20).Text
                                        End If
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 6
                                    ' Do Nothing
                                Case 7
                                    strContentHis = strContentHis & "<DD>" & ddlLabel.Items(22).Text & ": "
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Answer")) Then
                                        If Not CInt(tblRequestHistory.Rows(intIndex).Item("Answer")) = 0 Then
                                            strContentHis = strContentHis & ddlLabel.Items(20).Text
                                        Else
                                            strContentHis = strContentHis & ddlLabel.Items(19).Text
                                        End If
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 8
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(24).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 9
                                    ' Do Nothing
                                Case 10
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(25).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 11
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(26).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MPROVIDEDDATE")
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 12
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MDUEDATE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(7).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MDUEDATE")
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Renewable")) Then
                                        strContentHis = strContentHis & "<br>" & ddlLabel.Items(8).Text & ": "
                                        If Not CInt(tblRequestHistory.Rows(intIndex).Item("Renewable")) = 0 Then
                                            strContentHis = strContentHis & ddlLabel.Items(20).Text
                                        Else
                                            strContentHis = strContentHis & ddlLabel.Items(21).Text
                                        End If
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 13
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MDUEDATE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(27).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MDUEDATE")
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 14
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("MDUEDATE")) Then
                                        strContentHis = strContentHis & "<DD>" & ddlLabel.Items(7).Text & ": " & tblRequestHistory.Rows(intIndex).Item("MDUEDATE")
                                    End If
                                    If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Renewable")) Then
                                        strContentHis = strContentHis & "<br>" & ddlLabel.Items(8).Text & ": "
                                        If Not CInt(tblRequestHistory.Rows(intIndex).Item("Renewable")) = 0 Then
                                            strContentHis = strContentHis & ddlLabel.Items(20).Text
                                        Else
                                            strContentHis = strContentHis & ddlLabel.Items(21).Text
                                        End If
                                    End If
                                    strContentHis = strContentHis & "<BR>"
                                Case 15, 16, 17, 18, 19, 20
                                    ' Do nothing

                            End Select
                            If Not IsDBNull(tblRequestHistory.Rows(intIndex).Item("Note")) Then
                                If Not Trim(tblRequestHistory.Rows(intIndex).Item("Note")) = "" Then
                                    strContentHis = strContentHis & "<DD>" & ddlLabel.Items(19).Text & ": " & tblRequestHistory.Rows(intIndex).Item("Note") & "<BR>"
                                End If
                            End If
                            strContentHis = strContentHis & "</DL>"
                        Next
                        lblContent.Text = strContentHis
                    Else
                        blnValid = False
                    End If
                Else
                    blnValid = False
                End If
            Else
                blnValid = False
            End If

            ' Error
            If blnValid = False Then
                Page.RegisterClientScriptBlock("Error1", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "')</script>")
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
                If Not objBILLOutRequest Is Nothing Then
                    objBILLOutRequest.Dispose(True)
                    objBILLOutRequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
