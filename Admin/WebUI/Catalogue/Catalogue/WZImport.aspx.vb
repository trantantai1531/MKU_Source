' WZImport class
' Purpose: import data from z3950
' Creator: Oanhtn
' CreatedDate: 12/08/2004
' Modification history:
'    - 03/03/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WZImport
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
        Private objBZ3950 As New clsBZ3950
        Private objBInput As New clsBInput
        Private objBItem As New clsBItem
        Private objBCSP As New clsBCommonStringProc
        Dim intStart As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call ProcessZQuery()
            End If
        End Sub

        ' This method used to init all objects
        Private Sub Initialize()
            ' Init objBZ3950 object
            objBZ3950.InterfaceLanguage = Session("InterfaceLanguage")
            objBZ3950.DBServer = Session("DBServer")
            objBZ3950.ConnectionString = Session("ConnectionString")
            Call objBZ3950.Initialize()

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBItem object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()
        End Sub

        ' ProcessZQuery method
        Public Sub ProcessZQuery()
            'If Trim(Request("txtStart")) = "" Then
            '    intStart = 1
            'Else
            '    intStart = CInt(Trim(Request("txtStart")))
            '    If intStart > 10 Then
            '        'intStart = intStart - 9
            '        intStart = intStart - 10
            '    Else
            '        intStart = 1
            '    End If
            'End If
            'If intStart = 0 Then
            '    intStart = 1
            'End If
            'objBZ3950.zServer = Session("zServer")
            'objBZ3950.zPort = Session("zPort")
            'objBZ3950.zDatabase = Session("zDatabase")
            'objBZ3950.FieldName1 = Session("FieldName1")
            'objBZ3950.FieldValue1 = Session("FieldValue1")
            'objBZ3950.FieldName2 = Session("FieldName2")
            'objBZ3950.FieldValue2 = Session("FieldValue2")
            'objBZ3950.FieldName3 = Session("FieldName3")
            'objBZ3950.FieldValue3 = Session("FieldValue3")
            'objBZ3950.Operator2 = Session("Operator2")
            'objBZ3950.Operator3 = Session("Operator3")
            'objBZ3950.VietUSMARC = Session("VietUSMARC")
            'objBZ3950.Start = intStart
            'objBZ3950.Howmany = 10

            ' Import selected record or show search result
            If Not Trim(Request("txtImportedID")) = "" Then
                ' Import selected record
                'objBZ3950.zFormat = "raw"
                'Call objBZ3950.ProccessQuery()

                Call Import()
            End If
        End Sub

        ' Import method
        ' Purpose: Import selected record
        Public Sub Import()
            ' Declare variables
            Dim objResult() As String
            Dim intIndex As Integer
            Dim strResult As String = ""
            Dim strRecordContent As String = ""
            Dim strFieldValue As String = ""
            Dim strCheckCode As String = ""
            Dim arrFieldName() As Object
            Dim arrFieldValue() As Object
            ReDim arrFieldName(0)
            ReDim arrFieldValue(0)
            Dim arrSubRecs() As Object = Nothing

            Dim strDupeRecs As String = ""
            Dim intTotalRec As Integer = 0
            Dim intImportedRec As Integer = 0
            Dim intErrorRec As Integer = 0
            Dim intNoDupeRecs As Integer = 0
            Dim lngItemID As Long = 0
            Dim intStatus As Integer = 0
            Dim intFormID As Integer = 0
            Dim intDedupeMode As Integer = 0
            Dim strImportedIDs As String
            Dim intFieldIndex As Integer = -1
            Dim blnExist As Boolean = False
            Dim strNewNumber As String = ""
            Dim strCheckNumber As String = ""
            Dim strHtml As String = ""
            Dim intTotal As Integer = 0

            If Not IsNumeric(Session("Choice")) Then Session("Choice") = 0
            intDedupeMode = CInt(Session("Choice"))

            ' Process
            objResult = Session("objBZ3950Record") 'objBZ3950.Record
            strImportedIDs = "," & Request("txtImportedID") & ","

            ' Display the progress bar

            strHtml = "<span id='spnMain' style='LEFT: 100px; WIDTH: 600px; COLOR: #3333ff; POSITION: absolute; TOP: 10px'	class='lblLabel'>"
            strHtml = strHtml & "<span id='spnPecent' style='LEFT: 300px; COLOR: #FFFFFF; POSITION: absolute; TOP: 17px;FONT-WEIGHT: bold;'>0%</span>"
            strHtml = strHtml & "<span id='spnlbProcessing' style='LEFT: 250px; POSITION: absolute; TOP: 50px;TEXT-ALIGN: center;'>" & ddlLabel.Items(3).Text & "</span>"
            strHtml = strHtml & "<table height=10px cellspacing=0 cellpadding=0><tr><td></td><tr></table>"
            strHtml = strHtml & "<table width=100% border=1 bgcolor=#999966 height=30px cellspacing=0 cellpadding=0><tr><td>"
            strHtml = strHtml & "<table id='spnProgess' width=0% border=0 bgcolor=#006291 height=100%><tr><td></td></tr></table></td></tr></table></span>"

            Response.Write(strHtml)

            For intIndex = LBound(objResult) To UBound(objResult)
                If InStr(strImportedIDs, "," & intIndex & ",") > 0 Then
                    intTotal += 1
                End If
            Next
            Dim intRecordCurrent As Integer = 0
            For intIndex = LBound(objResult) To UBound(objResult)
                If InStr(strImportedIDs, "," & intIndex & ",") > 0 Then
                    intRecordCurrent += 1
                    strRecordContent = objResult(intIndex)

                    'Replace some control charaters
                    'strRecordContent = Replace(strRecordContent, Chr(31), "$")
                    'strRecordContent = Replace(strRecordContent, Chr(30), "#")
                    'strRecordContent = Replace(strRecordContent, Chr(29), "#")

                    '' Parse string input into 2 array (fieldname & fieldvalue)
                    'Call objBInput.ParseISORec(strRecordContent, arrFieldName, arrFieldValue)

                    Call objBInput.ParseISORec(strRecordContent, arrFieldName, arrFieldValue)

                    intFieldIndex = -1
                    blnExist = False
                    strCheckNumber = ""
                    lngItemID = 0

                    '' Search by ISBN
                    'intFieldIndex = objBZ3950.FindIndex(arrFieldName, "020")
                    'If intFieldIndex >= 0 Then
                    '    strCheckNumber = "ISBN"
                    '    lngItemID = CheckExistItemByNumber(arrFieldValue(intFieldIndex), "020", strNewNumber)
                    'End If

                    'If lngItemID = 0 Then
                    '    ' Search by ISSN
                    '    intFieldIndex = objBZ3950.FindIndex(arrFieldName, "022")
                    '    strCheckNumber = "ISSN"
                    '    If intFieldIndex > 0 Then
                    '        lngItemID = CheckExistItemByNumber(arrFieldValue(intFieldIndex), "022", strNewNumber)
                    '    End If
                    'End If
                    Dim strTemp As String = ""
                    strTemp = objBZ3950.FindFieldByObject(arrFieldName, arrFieldValue, "020")
                    If strTemp <> "" Then
                        Call objBCSP.ParseField("$a", strTemp, "nc;", arrSubRecs)
                        If Not arrSubRecs(0) = "" Then
                            strCheckNumber = "ISBN"
                            lngItemID = CheckExistItemByNumber(arrSubRecs(0), "020", strNewNumber)
                        End If
                    End If

                    'ISSN
                    strTemp = objBZ3950.FindFieldByObject(arrFieldName, arrFieldValue, "022")
                    If strTemp <> "" Then
                        Call objBCSP.ParseField("$a", strTemp, "nc;", arrSubRecs)
                        If Not arrSubRecs(0) = "" Then
                            strCheckNumber = "ISSN"
                            lngItemID = CheckExistItemByNumber(arrSubRecs(0), "022", strNewNumber)
                        End If
                    End If

                    ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                    ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)

                    arrFieldName(UBound(arrFieldName)) = "911"
                    arrFieldValue(UBound(arrFieldValue)) = clsSession.GlbUserFullName

                    If lngItemID > 0 Then ' Exist item
                        strDupeRecs = strDupeRecs & strNewNumber & "<BR>"
                        intNoDupeRecs = intNoDupeRecs + 1
                        If intDedupeMode > 0 Then
                            objBInput.FieldName = arrFieldName
                            objBInput.FieldValue = arrFieldValue
                            objBInput.RecID = lngItemID

                            ' intFormID
                            intStatus = objBInput.Update(CInt(Request("ddlForm")), 1)
                            If intStatus = 0 Then
                                intErrorRec = intErrorRec + 1
                                objBInput.ErrorCode = 0
                                objBInput.ErrorMsg = ""
                            Else
                                intImportedRec = intImportedRec + 1
                            End If
                        End If
                    Else
                        objBInput.FieldName = arrFieldName
                        objBInput.FieldValue = arrFieldValue
                        intStatus = objBInput.Update(CInt(Request("ddlForm")), 1)
                        If intStatus = 0 Then
                            intErrorRec = intErrorRec + 1
                        Else
                            intImportedRec = intImportedRec + 1
                        End If
                    End If
                    ' Display the progress bar
                    If intTotal > 0 Then
                        Call BindPrg(intRecordCurrent - 1, intTotal)
                    End If
                End If
            Next

            Response.Write("<script language='javascript'>spnlbProcessing.innerHTML ='" & ddlLabel.Items(4).Text & "';</script>")

            ' Show Result
            lblTotalRec.Text = UBound(Split("," & Request("txtImportedID"), ","))
            lblTotalImported.Text = intImportedRec
            lblTotalError.Text = intErrorRec
            lblTotalDoub.Text = intNoDupeRecs
            If Not strDupeRecs = "" Then
                lblLabel5.Visible = True
                lblDetail.Visible = True
                lblDetail.Text = strCheckNumber & ": " & strDupeRecs
            End If
            If intImportedRec > 0 Then
                Call WriteLog(87, ddlLabel.Items(2).Text & ": " & intImportedRec, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
        End Sub

        ' CheckExistItemByNumber method
        ' Purpose: Check exist item by ISBN or ISSN
        ' Input: FieldValue & FieldCode to check
        ' Output: long value
        Public Function CheckExistItemByNumber(ByVal strFieldValue As String, ByVal strCheckCode As String, ByRef strNewValue As String) As Long
            Dim arrRecs()
            Dim arrSubRecs()
            Dim intCount As Integer
            Dim strTagValue As String
            Dim intConlonIndex As Integer

            Try
                Call objBInput.ParseFieldValue(strFieldValue, "$&", arrRecs)
                For intCount = LBound(arrRecs) To UBound(arrRecs)
                    If Not arrRecs(intCount) = "" Then
                        strTagValue = arrRecs(intCount)
                        intConlonIndex = InStr(strTagValue, "::")
                        If intConlonIndex > 0 And intConlonIndex <= 3 Then
                            strTagValue = Right(strTagValue, Len(strTagValue) - intConlonIndex - 1)
                        End If
                        intConlonIndex = InStr(strTagValue, "(") ' Cut commentation
                        If intConlonIndex > 0 Then
                            strTagValue = Trim(Left(strTagValue, intConlonIndex - 1))
                        End If
                        Call objBInput.ParseField("$a", strTagValue, "", arrSubRecs)
                        If Not arrSubRecs(0) = "" Then
                            strNewValue = arrSubRecs(0).ToString.Trim
                            Dim strLastChar As String = Right(strNewValue, 1)
                            If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = "." Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                                strNewValue = Left(strNewValue, Len(strNewValue) - 1).Trim
                            End If
                            CheckExistItemByNumber = objBItem.CheckExistItemByNumber(strNewValue, strCheckCode)
                            strErrorMsg = objBItem.ErrorMsg
                            intErrorCode = objBItem.ErrorCode
                            Exit Function
                        End If
                    End If
                Next
                strErrorMsg = objBInput.ErrorMsg
                intErrorCode = objBInput.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
            Return 0
        End Function

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            System.Threading.Thread.Sleep(50 / intSum)
            Response.Write("<script language='javascript'>spnProgess.width =" & intCurrentPercent & " + '%'; spnPecent.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub


        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBZ3950 Is Nothing Then
                    objBZ3950.Dispose(True)
                    objBZ3950 = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace