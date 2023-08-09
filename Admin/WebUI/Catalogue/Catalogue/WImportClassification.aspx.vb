Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WImportClassification
        Inherits clsWBase

        ' Declare class variables
        Private objBCDS As New clsBCommonDBSystem
        Private objBInput As New clsBInput

        ' Declare module variables
        Private strFileName As String
        Private strPath As String
        Private strFileNameTemp As String
        Private strImport As String  ' Imported string 

        ' Arrays
        Private arrForms()
        Private arrArray()
        Private arrPartForms()
        Private arrPrgBar()
        Private arrFieldName()
        Private arrFieldValue()
        Private intFormID As Integer

        ' Integer
        Private intImportCount As Integer

        ' JAVASCRIPT string
        Private strJS As String

        Private strItemCode As String
        Private strDisPlayEntry As String
        Private strCaption As String
        Private strType As String
        Private strVersion As String
        Private strDescription As String
        Private objBImportRecord As New clsBImportRecord
        Private strItemLeader As String = "00025nam a2200024 a 4500" ' Default strLeader value
        Private objDataSetImport As New DataTable

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblMain As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call CheckFormPemission()
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBCDS object
            objBCDS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDS.DBServer = Session("DBServer")
            objBCDS.ConnectionString = Session("ConnectionString")
            Call objBCDS.Initialize()

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            'objBImportRecord
            objBImportRecord.InterfaceLanguage = Session("InterfaceLanguage")
            objBImportRecord.DBServer = Session("DBServer")
            objBImportRecord.ConnectionString = Session("ConnectionString")
            Call objBImportRecord.Initialize()
        End Sub

        ' Method: CheckFormPemission
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(222) Then
                btnImport.Enabled = False
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: Get the javascripts
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Catalogue/WImportFromFile.js'></script>")

            strJS = "javascript: if(!CheckInput('" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(2).Text & "')) return false;"
            'strJS = strJS & "if (document.forms[0].filAttach.value.substring(document.forms[0].filAttach.value.lenght - 3, document.forms[0].filAttach.value).toLowerCase != 'iso') {alert('" & ddlLabel.Items(5).Text.Trim & "'); return false;}"
            btnImport.Attributes.Add("Onclick", strJS)

            filAttach.Attributes.Add("onKeyDown", "javascript:if(event.keyCode ) {document.forms(0).filAttach.value='';keyCode=27;return false;}")
            Me.SetCheckNumber(txtLRange, ddlLabel.Items(1).Text, "")
            Me.SetCheckNumber(txtRRange, ddlLabel.Items(1).Text, "")
        End Sub


        ' btnImport_Click action
        ' Purpose: Import the ISO file to the system
        Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click

            Dim tblTemp As DataTable  ' Datatable variable
            Dim intIndex As Integer  ' Index of the string character
            Dim strFieldName As String  ' String of the Field Names part in the iso file (separate with other part by "#")
            Dim intArrIndex As Integer  ' Array index
            Dim intFieldIndex As Integer  ' Field index
            Dim strFieldNum As String  ' String of each field (001, 005...)
            Dim strFieldVal As String  ' Value of each field (001, 005...)
            Dim intLRange As Integer   ' First value of imported records (User defined)
            Dim intRRange As Integer   ' Last value of imported records (User defined)
            Dim TotalLen As Integer
            Dim TotalVal As Integer
            Dim Ext As String = ""
            Dim strTemp As String

            ' File to read to display the progress bar

            ' Get the path file in the server for uploading
            strTemp = filAttach.Name
            If InStr(strTemp, ".") <= 0 Then
                Page.RegisterClientScriptBlock("JSInvalid", "<script language = 'javascript'> alert('" & ddlLabel.Items(5).Text & "'); </script>")
                Exit Sub
            Else
                Ext = strTemp.Substring(InStr(strTemp, "."))
                If Ext.ToLower <> "iso" Then
                    Page.RegisterClientScriptBlock("JS", "<script language = 'javascript'> alert('" & ddlLabel.Items(5).Text & "'); </script>")
                    Exit Sub
                End If
            End If
            tblTemp = objBCDS.GetTempFilePath(1)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strPath = Server.MapPath("../..") & CStr(tblTemp.Rows(0).Item("TempFilePath"))
            End If

            objBCDS.Extension = "iso"
            strFileNameTemp = objBCDS.GenRandomFile()

            ' Upload file
            strFileName = UpLoadFiles(filAttach, strPath, strFileNameTemp)

            ' Read from file and get the import string
            strImport = ReadFromFile(strPath & "\" & strFileNameTemp)

            ' Transfer the value for the InterfaceLanguage in objBInput
            If ddlEncode.SelectedIndex <> 0 Then
                objBInput.InterfaceLanguage = ddlEncode.SelectedValue
            End If

            ' BEGIN IMPORT 
            ReDim arrFieldName(0)
            ReDim arrFieldValue(0)
            If ddlPattern.SelectedValue = 1 Then ' raw
                If InStr(strImport, txtRecTer.Text & txtRecTer.Text) = 0 Or strImport = "" Or InStr(strImport, txtFieldTer.Text) = 0 Then
                    Page.RegisterClientScriptBlock("JSInvalidDataraw", "<script language = 'javascript'> alert('" & ddlLabel.Items(5).Text & "'); </script>")
                Else
                    ' Divide the import string to the parts to recieve the records
                    arrForms = Split(Trim(strImport), txtRecTer.Text & txtRecTer.Text)
                End If
            Else ' tagged
                If InStr(strImport, Chr(29)) = 0 Or strImport = "" Or InStr(strImport, Chr(30)) = 0 Then
                    Page.RegisterClientScriptBlock("JSInvalidDatatagged", "<script language = 'javascript'> alert('" & ddlLabel.Items(5).Text & "'); </script>")
                Else
                    ' Divide the import string to the parts to recieve the records
                    arrForms = Split(Trim(strImport), Chr(29))
                End If
            End If
            If Not arrForms Is Nothing AndAlso arrForms.Length > 0 Then
                ' Get the coordinate of records (FROM...TO)
                If Trim(txtLRange.Text) <> "" Then
                    intLRange = CInt(Trim(txtLRange.Text))
                Else
                    intLRange = LBound(arrForms) + 1
                End If

                If Trim(txtRRange.Text) <> "" Then
                    intRRange = CInt(Trim(txtRRange.Text))
                Else
                    intRRange = UBound(arrForms)
                End If

                ' If the range is valid strContent = Replace(strContent, Chr(10), "")
                If intLRange > 0 And intRRange <= UBound(arrForms) And intLRange <= intRRange Then

                    intImportCount = 0
                    Response.Write("<SPAN class='lbLabel' style='position:absolute;top:200;left: 20px'>")
                    Response.Write(ddlLabel.Items(6).Text & "<span id='pgbMain_label'>0%</span><br>")
                    Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=#669999><tr style='HEIGHT: 18px'><td></td></tr></table>")

                    ' Begin to import
                    For intArrIndex = intLRange - 1 To intRRange - 1
                        If arrForms(intArrIndex) <> "" Then
                            objBInput.ParseISORecCfs(arrForms(intArrIndex), arrFieldName, arrFieldValue)
                            objBInput.FieldName = arrFieldName
                            objBInput.FieldValue = arrFieldValue

                            Call BindPrg(intArrIndex, intRRange)   ' Display the progress bar

                            If CheckFieldClassification(arrFieldValue, arrFieldName, TotalLen, TotalVal) = True Then
                                objBImportRecord.ItemCode = strItemCode
                                objBImportRecord.ItemLeader = strItemLeader
                                objBImportRecord.DisplayEntry = strDisPlayEntry
                                objBImportRecord.Caption = strCaption
                                objBImportRecord.Type = strType
                                objBImportRecord.Version = strVersion
                                objBImportRecord.Description = strDescription
                                If objBImportRecord.ImportClassfication() = 0 Then
                                    intImportCount = intImportCount + 1
                                End If
                            End If
                        End If
                    Next
                    Response.Write("</SPAN>")

                    If intImportCount <> 0 Then
                        lblSuccess.Visible = True
                        lblFail.Visible = False
                        lblTotal.Visible = True
                        lblCount.Visible = True
                        lblCount.Text = " " & intImportCount
                        Call WriteLog(9, ddlLabel.Items(9).Text & lblTotal.Text & " " & intImportCount, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Else
                        ' If no records imported
                        lblSuccess.Visible = False
                        lblFail.Visible = True
                        If objBImportRecord.ErrorCode <> 0 And objBImportRecord.ErrorMsg <> "" Then ' error
                            lblFail.Text &= " " & ddlLabel.Items(12).Text
                        Else
                            lblFail.Text &= " " & ddlLabel.Items(11).Text
                        End If
                        lblTotal.Visible = True
                        lblCount.Visible = True
                        lblCount.Text = " " & intImportCount
                    End If
                Else
                    ' Invalid range
                    Page.RegisterClientScriptBlock("InvalidRange", "<script language='JavaScript'>alert('" & ddlLabel.Items(3).Text & "')</script>")
                    lblSuccess.Visible = False
                    lblTotal.Visible = False
                    lblCount.Visible = False
                    lblFail.Visible = True
                End If
            End If

            ' Reset the value for the controls
            txtLRange.Text = ""
            txtRRange.Text = ""
            ddlEncode.SelectedIndex = 0
            ' Delete the uploaded file
            Dim filUpload As File
            filUpload.Delete(strPath & "\" & strFileNameTemp)
            'If InStr(strImport, "##") = 0 Or strImport = "" Or InStr(strImport, "#") = 0 Then
            '    Page.RegisterClientScriptBlock("JSInvalidData", "<script language = 'javascript'> alert('" & ddlLabel.Items(5).Text & "'); </script>")
            'Else
            '    ' Divide the import string to the parts to recieve the records
            '    arrForms = Split(Trim(strImport), "##")

            '    ' FormID
            '    'intFormID = CInt(ddlForm.SelectedValue)

            '    ' Get the coordinate of records (FROM...TO)
            '    If Trim(txtLRange.Text) <> "" Then
            '        intLRange = CInt(Trim(txtLRange.Text))
            '    Else
            '        intLRange = LBound(arrForms) + 1
            '    End If

            '    If Trim(txtRRange.Text) <> "" Then
            '        intRRange = CInt(Trim(txtRRange.Text))
            '    Else
            '        intRRange = UBound(arrForms)
            '    End If

            '    ' If the range is valid strContent = Replace(strContent, Chr(10), "")
            '    If intLRange > 0 And intRRange <= UBound(arrForms) And intLRange <= intRRange Then
            '        intImportCount = 0

            '        Response.Write("<SPAN class='lbLabel' style='position:absolute;top:200;left: 20px'>")
            '        Response.Write(ddlLabel.Items(6).Text & "<span id='pgbMain_label'>0%</span><br>")
            '        Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=#669999><tr style='HEIGHT: 18px'><td></td></tr></table>")

            '        ' Begin to import
            '        For intArrIndex = intLRange - 1 To intRRange - 1
            '            objBInput.ParseISORecCfs(arrForms(intArrIndex), arrFieldName, arrFieldValue)
            '            objBInput.FieldName = arrFieldName
            '            objBInput.FieldValue = arrFieldValue

            '            Call BindPrg(intArrIndex, intRRange)   ' Display the progress bar

            '            If CheckFieldClassification(arrFieldValue, arrFieldName, TotalLen, TotalVal) = True Then
            '                objBImportRecord.ItemCode = strItemCode
            '                objBImportRecord.ItemLeader = strItemLeader
            '                objBImportRecord.DisplayEntry = strDisPlayEntry
            '                objBImportRecord.Caption = strCaption
            '                objBImportRecord.Type = strType
            '                objBImportRecord.Version = strVersion
            '                objBImportRecord.Description = strDescription
            '                If objBImportRecord.ImportClassfication() = 0 Then
            '                    intImportCount = intImportCount + 1
            '                End If
            '            End If
            '        Next
            '        Response.Write("</SPAN>")

            '        If intImportCount <> 0 Then
            '            lblSuccess.Visible = True
            '            lblFail.Visible = False
            '            lblTotal.Visible = True
            '            lblCount.Visible = True
            '            lblCount.Text = " " & intImportCount
            '            Call WriteLog(9, ddlLabel.Items(9).Text & lblTotal.Text & " " & intImportCount, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            '        Else
            '            ' If no records imported
            '            lblSuccess.Visible = False
            '            lblFail.Visible = True
            '            If objBImportRecord.ErrorCode <> 0 And objBImportRecord.ErrorMsg <> "" Then ' error
            '                lblFail.Text &= " " & ddlLabel.Items(12).Text
            '            Else
            '                lblFail.Text &= " " & ddlLabel.Items(11).Text
            '            End If
            '            lblTotal.Visible = True
            '            lblCount.Visible = True
            '            lblCount.Text = " " & intImportCount
            '        End If
            '    Else
            '        ' Invalid range
            '        Page.RegisterClientScriptBlock("InvalidRange", "<script language='JavaScript'>alert('" & ddlLabel.Items(3).Text & "')</script>")
            '        lblSuccess.Visible = False
            '        lblTotal.Visible = False
            '        lblCount.Visible = False
            '        lblFail.Visible = True
            '    End If
            'End If

            '' Reset the value for the controls
            'txtLRange.Text = ""
            'txtRRange.Text = ""
            'ddlEncode.SelectedIndex = 0
            '' Delete the uploaded file
            'Dim filUpload As File
            'filUpload.Delete(strPath & "\" & strFileNameTemp)
        End Sub

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            If intCurrentPercent Mod 10 = 0 Then
                System.Threading.Thread.Sleep(500 / intSum)
                Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
                Response.Flush()
            End If
        End Sub

        ' Check Field in Classification
        Function CheckFieldClassification(ByVal strFieldValueCheck As Object, ByVal strFieldNameCheck As Object, ByVal TotalLen As Integer, ByVal TotalVal As Integer) As Boolean
            Dim i As Integer
            Dim bolCheck001 As Boolean
            TotalLen = 0
            TotalVal = 0
            bolCheck001 = False
            CheckFieldClassification = False
            strItemCode = ""
            strItemLeader = ""
            strDisPlayEntry = ""
            strCaption = ""
            strType = ""
            strVersion = ""
            strDescription = ""
            strItemCode = ""
            For i = 0 To UBound(strFieldNameCheck)
                If strFieldNameCheck(i) = "153" Then
                    Dim arr
                    arr = Split(strFieldValueCheck(i), "$")
                    Dim j As Integer
                    For j = 0 To UBound(arr)
                        If Left(arr(j), 1) = "a" Then
                            Me.strDisPlayEntry = Right(arr(j), arr(j).ToString.Length - 1)
                        End If
                        If Left(arr(j), 1) = "j" Then
                            Me.strCaption = Right(arr(j), arr(j).ToString.Length - 1)
                        End If
                    Next
                    CheckFieldClassification = True
                End If

                If strFieldNameCheck(i) = "084" Then
                    Dim arr
                    arr = Split(strFieldValueCheck(i), "$")
                    Dim j As Integer
                    For j = 0 To UBound(arr)
                        If Left(arr(j), 1) = "a" Then
                            strType = Right(arr(j), arr(j).ToString.Length - 1)
                        End If
                        If Left(arr(j), 1) = "c" Then
                            strVersion = Right(arr(j), arr(j).ToString.Length - 1)
                        End If
                        If Left(arr(j), 1) = "h" Then
                            strDescription = Right(arr(j), arr(j).ToString.Length - 1)
                        End If
                    Next
                    CheckFieldClassification = True
                End If

                If strFieldNameCheck(i) = "001" Then
                    strItemCode = strFieldValueCheck(i).Trim
                    CheckFieldClassification = True
                    bolCheck001 = True
                End If

                If strFieldNameCheck(i) = "000" Then
                    strItemLeader = strFieldValueCheck(i).Trim
                    CheckFieldClassification = True
                End If
            Next

            If bolCheck001 = False And CheckFieldClassification = True Then
                strItemCode = objBImportRecord.Gen001
            End If
        End Function

        ' InsertValue method
        Sub InsertValue()
            objBImportRecord.ItemLeader = strItemLeader
            objBImportRecord.DisplayEntry = strDisPlayEntry
            objBImportRecord.Caption = strCaption
            objBImportRecord.Type = strType
            objBImportRecord.Version = strVersion
            objBImportRecord.Description = strDescription

            Call objBImportRecord.ImportClassfication()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDS Is Nothing Then
                    objBCDS.Dispose(True)
                    objBCDS = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBImportRecord Is Nothing Then
                    objBImportRecord.Dispose(True)
                    objBImportRecord = Nothing
                End If
            Finally
                MyBase.Dispose()
                Dispose()
            End Try
        End Sub
    End Class
End Namespace