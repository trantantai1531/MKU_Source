' WCataAttachFile class
' Purpose: update contents of this item
' Creator: Khoana
' CreatedDate: 05/05/2004
' Modification history:
'   - 28/05/2004 by Oanhtn: review & complete
'   - 03/03/2005 by Oanhtn: review & update
Imports System.IO
Imports System.IO.Path
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataPut
        Inherits clsWBase

        Private objBEData As New clsBEData

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

        ' Private objects
        Private objBInput As New clsBInput
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBItemCollection As New clsBItemCollection
        Private objBCSP As New clsBCommonStringProc

        ' Page_Load event
        ' Purpose: call all method here
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.ShowWaitingOnPage(ddlLabel.Items(12).Text, "../..", False, True)
            Call Initialize()
            Call Update()
            ShowWaitingOnPage("", "", True)
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBCatalogueForm
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()

            ' Init objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()


            ' Init objBEData object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()

            ' Init objBCSP
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        ' Update method
        ' Purpose: update content of this item
        Private Sub Update()
            Dim arrFieldName() As Object
            Dim arrFieldValue() As Object
            Dim arrLabelStr() As Object
            Dim blnModifyHoldings As Boolean = False
            Dim strJS As String = ""

            Dim intCounter As Integer = 1
            Dim strControlName As String
            Dim intValue900 As Integer = 0
            Dim intField911Value As Integer = 0
            Dim intField912Value As Integer = 0
            Dim intFormID = CInt(Request.Form("txtFormID"))
            Dim intItemID As Integer = 0

            ' Set array of LabelString
            ReDim arrLabelStr(9)
            arrLabelStr(0) = ddlLabel.Items(0).Text
            arrLabelStr(1) = ddlLabel.Items(1).Text
            arrLabelStr(2) = ddlLabel.Items(2).Text
            arrLabelStr(3) = ddlLabel.Items(3).Text
            arrLabelStr(4) = ddlLabel.Items(4).Text
            arrLabelStr(5) = ddlLabel.Items(5).Text
            arrLabelStr(6) = ddlLabel.Items(6).Text
            arrLabelStr(7) = ddlLabel.Items(7).Text
            arrLabelStr(8) = ddlLabel.Items(8).Text

            Dim strLabel5 As String = ddlLabel.Items(10).Text
            Dim strLabel15 As String = ddlLabel.Items(11).Text

            ReDim arrFieldName(0)
            ReDim arrFieldValue(0)
            arrFieldName(0) = "000"
            arrFieldValue(0) = Request("txtLeader")

            Dim strFieldCodeTemp As String = ""
            Dim strFieldValueTemp As String = ""
            Dim bolTemp As Boolean = False

            For Each strControlName In Request.Form
                If Left(strControlName, 3) = "tag" And Not Trim(Request.Form(strControlName)) = "" Then
                    If strControlName.ToString.Trim.Length >= 6 Then
                        If strFieldCodeTemp <> strControlName.ToString.Trim.Substring(3, 3) Then
                            If strFieldValueTemp <> "" Then
                                bolTemp = True
                                ReDim Preserve arrFieldName(intCounter)
                                ReDim Preserve arrFieldValue(intCounter)
                                arrFieldName(intCounter) = strFieldCodeTemp
                                arrFieldValue(intCounter) = objBCSP.parseValueFieldOther(strFieldCodeTemp, strFieldValueTemp)
                                arrFieldValue(intCounter) = arrFieldValue(intCounter).ToString().Replace(" ..", " .")
                                arrFieldValue(intCounter) = arrFieldValue(intCounter).ToString().Replace("'", "''")
                                If strFieldCodeTemp = "245" Then
                                    arrFieldValue(intCounter) = parseValueField245(arrFieldValue(intCounter))
                                Else
                                    If arrFieldValue(intCounter).Contains("$&") Then
                                        arrFieldValue(intCounter) = parseValueField(arrFieldValue(intCounter))
                                    End If
                                End If

                                intCounter = intCounter + 1
                                If Right(strControlName, Len(strControlName) - 3) = "911" Then
                                    intField911Value = 1
                                End If
                                If Right(strControlName, Len(strControlName) - 3) = "912" Then
                                    intField912Value = 1
                                End If
                                If Right(strControlName, Len(strControlName) - 3) = "900" Then
                                    If Request("tag900") <> "" Then
                                        intValue900 = CInt(Request("tag900"))
                                    End If
                                End If
                            End If
                            strFieldValueTemp = ""
                            strFieldCodeTemp = strControlName.ToString.Trim.Substring(3, 3)
                        End If
                        Call objBCSP.concatValueSubFields(strControlName.ToString.Trim.Substring(3), Request.Form(strControlName), strFieldValueTemp)
                    End If
                End If
                '2016.04.15 E1
            Next

            '2016.04.15 B2
            If bolTemp Then
                ReDim Preserve arrFieldName(intCounter)
                ReDim Preserve arrFieldValue(intCounter)
                arrFieldName(intCounter) = strFieldCodeTemp
                arrFieldValue(intCounter) = objBCSP.parseValueField(strFieldCodeTemp, strFieldValueTemp)
            End If
            '2016.04.15 E2

            ' Add cataloguer
            If intField911Value = 0 Then
                ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
                arrFieldName(UBound(arrFieldName)) = "911"
                arrFieldValue(UBound(arrFieldValue)) = clsSession.GlbUserFullName
            End If
            objBInput.FieldName = arrFieldName
            objBInput.FieldValue = arrFieldValue
            objBInput.LibID = clsSession.GlbSite

            objBInput.WorkID = 0

            'While objBInput.WorkID <> 0
            If Session("IsAuthority") = 1 Then
                    If objBInput.UpdateAuthority(Request("txtFormID"), 1) = 0 Then
                    End If
                Else
                    If objBInput.Update(Request("txtFormID"), 0) = 0 Then
                    End If
                End If
            'End While


            ' Update OPAC value depending on OPAC_LEVEL parameter
            objBItemCollection.LibID = clsSession.GlbSite
            objBItemCollection.ItemID = objBInput.WorkID
            objBItemCollection.Field912Value = intField912Value
            objBItemCollection.UpdateOpacItem(1)
            ' Write log
            Call WriteLog(10, ddlLabel.Items(10).Text & ": " & objBInput.CodeOut, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Ke^'t thu'c kie^?m tra
            If Request("Module") = "Serial" Then
                objBItemCollection.TypeItem = 9
            Else
                objBItemCollection.TypeItem = 0
            End If

            'Cap Nhat tai lieu dien tu
            Call updateEData(objBInput.WorkID)

            ' ModifyHoding from this module
            blnModifyHoldings = objBCatalogueForm.IsModifyHoldings

            ' Cataloged only
            'If Not blnModifyHoldings Or intValue900 = 1 Then
            If Not blnModifyHoldings Then
                strJS = strJS & " alert('" & strLabel5 & "');" & Chr(13)
                strJS = strJS & "parent.Sentform.location.href = ""WCataSent.aspx?FormID=" & intFormID & "&ItemID=" & objBInput.WorkID & """;" & Chr(13)
            Else
                If Session("IsAuthority") = 1 Then ' IsAuthority not update holding informations
                    strJS = strJS & " alert('" & strLabel5 & "');" & Chr(13)
                    strJS = strJS & "parent.Sentform.location.href=""WCataSent.aspx?FormID=" & intFormID & "&ItemID=" & objBInput.WorkID & """;" & Chr(13)
                Else
                    Session("Holdings") = 1
                    Session("HoldingsInCatalogNew") = 1
                    strJS = strJS & "if (confirm(""" & strLabel15 & """)) {" & Chr(13)
                    strJS = strJS & "parent.Sentform.location.href=""WCataModify.aspx?FormID=" & intFormID & "&Module=Catalog&ItemID=" & objBInput.WorkID & "&CodeCatalog=" & objBInput.CodeOut & "&Holdings=1""; console.log('WCataModify')" & Chr(13)
                    strJS = strJS & "} else {" & Chr(13)
                    strJS = strJS & "parent.Sentform.location.href=""WCataSent.aspx?FormID=" & intFormID & "&ItemID=" & objBInput.WorkID & """;console.log('WCataSent')" & Chr(13)
                    strJS = strJS & "}" & Chr(13)
                End If
            End If
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "LoadJS", strJS, True)
        End Sub


        Private Sub updateEData(ByVal intItemID As Integer)
            Try
                If Not IsNothing(Session("uploadFiles")) Then
                    Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2)
                    For _icount As Integer = _icountArr To 0 Step -1
                        If System.IO.File.Exists(System.IO.Path.Combine(Session("uploadFiles")(0, _icount), Session("uploadFiles")(1, _icount))) Then
                            Dim _fileInfo As New System.IO.FileInfo(System.IO.Path.Combine(Session("uploadFiles")(0, _icount), Session("uploadFiles")(1, _icount)))
                            With objBEData
                                .ItemID = intItemID
                                .FileName = _fileInfo.Name
                                .MediaType = clsWCommon.GetExtensionFileType(_fileInfo.Extension)
                                .FileSize = _fileInfo.Length
                                .Existed = 1
                                .FileLocation = _fileInfo.FullName
                                .DownloadTimes = 0
                                .UploadedDate = Format(Now.Date, "dd/MM/yyyy")
                                .FileFormat = _fileInfo.Extension
                                Dim intFileId As Integer = .insertItemFile()
                            End With
                        End If
                    Next
                    Session("uploadFiles") = Nothing
                End If
                If Not IsNothing(Session("imageCover")) Then
                    Dim strImage As String = Session("imageCover")
                    Dim fileName As String = Path.GetFileName(strImage)
                    Dim strPath As String = Me.getPhysicalPath & "\ImageCover\" & Now.Year.ToString & "\" & Now.Month.ToString & "\" & Now.Day.ToString  'Format(Now, "yyyyMMdd")
                    If Not Directory.Exists(strPath) Then
                        Directory.CreateDirectory(strPath)
                    End If
                    If strPath.EndsWith("\") = False Then
                        strPath &= "\"
                    End If
                    strPath &= fileName
                    If Not File.Exists(strPath) Then
                        File.Copy(strImage, strPath)
                    End If
                    Dim strCoverPicture As String = changeCoverPath(strPath)
                    With objBEData
                        .ItemID = intItemID
                        .CoverPicture = strCoverPicture
                        Dim intResult As Integer = .updateCoverItem()
                    End With
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function changeCoverPath(ByVal strCover As String) As String
            Dim strResult As String = ""
            Try
                strResult = Replace(strCover, Me.getPhysicalPath, "")
                strResult = Replace(strResult, "\", "/")
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBInput Is Nothing Then
                        objBInput.Dispose(True)
                        objBInput = Nothing
                    End If
                    If Not objBCatalogueForm Is Nothing Then
                        objBCatalogueForm.Dispose(True)
                        objBCatalogueForm = Nothing
                    End If
                    If Not objBItemCollection Is Nothing Then
                        objBItemCollection.Dispose(True)
                        objBItemCollection = Nothing
                    End If
                    If Not objBEData Is Nothing Then
                        objBEData.Dispose(True)
                        objBEData = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Function parseValueField245(ByVal str As String) As String
            str = If(str, "")
            Return str.Replace("$&", "")
        End Function

        Private Function parseValueField(ByVal str As String) As String
            str = If(str, "")
            Dim arrs() As String = str.Split(New String() {"$&"}, StringSplitOptions.None)
            Dim level As New List(Of String)
            Dim data As New List(Of String)
            Dim idx As Integer = 0
            For Each s As String In arrs
                If s <> "" AndAlso s <> " " Then
                    idx = s.IndexOf("$")
                    If idx >= 0 Then
                        Dim dollar As String = s.Substring(idx, 2)
                        Dim dataLevel = 1
                        If level.Count > 0 Then
                            For i As Integer = 0 To level.Count - 1
                                If Not level(i).Contains(dollar) Then
                                    Exit For
                                End If
                                dataLevel += 1
                            Next
                            If dataLevel > level.Count Then
                                level.Add(dollar)
                                data.Add(s)
                            Else
                                Dim tmp As String = level(dataLevel - 1)
                                level(dataLevel - 1) = tmp + "," + dollar
                                tmp = data(dataLevel - 1)
                                data(dataLevel - 1) = tmp + "" + s
                            End If
                        Else
                            level.Add(dollar)
                            data.Add(s)
                        End If
                    End If
                End If
            Next
            str = ""
            For Each s As String In data
                str &= s + "$&"
            Next
            Return str
        End Function
    End Class
End Namespace