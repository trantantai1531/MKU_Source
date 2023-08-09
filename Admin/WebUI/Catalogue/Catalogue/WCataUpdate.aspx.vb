' WCataUpdate class
' Purpose: update contents of the current item
' Creator: Oanhtn
' CreatedDate: 06/07/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update
Imports System.IO
Imports System.IO.Path
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataUpdate
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

        ' Private objects
        Private objBInput As New clsBInput
        Private objBItemCollection As New clsBItemCollection
        Private objBCSP As New clsBCommonStringProc
        Private objBEData As New clsBEData

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
            Dim arrFieldName() As Object ' array value of FieldName
            Dim arrFieldValue() As Object ' array value of FieldValue
            Dim arrLabelStr() As Object
            Dim strJS As String = ""
            'Dim strItemCode As String = Request("tag001")
            Dim strItemCode As String = ""
            Dim lngItemID As Long = CLng(Request("txtItemID"))

            Dim intCounter As Integer = 0
            Dim strControlName As String ' string value of controlname
            Dim intField912Value As Integer = 0 ' Check value of Reviewer
            ' Set array of LabelString
            ReDim arrLabelStr(9)
            arrLabelStr(0) = ddlLabel.Items(1).Text
            arrLabelStr(1) = ddlLabel.Items(2).Text
            arrLabelStr(2) = ddlLabel.Items(3).Text
            arrLabelStr(3) = ddlLabel.Items(4).Text
            arrLabelStr(4) = ddlLabel.Items(5).Text
            arrLabelStr(5) = ddlLabel.Items(6).Text
            arrLabelStr(6) = ddlLabel.Items(7).Text
            arrLabelStr(7) = ddlLabel.Items(8).Text
            arrLabelStr(8) = ddlLabel.Items(9).Text

            ReDim arrFieldName(0)
            ReDim arrFieldValue(0)
            arrFieldName(0) = "000"
            arrFieldValue(0) = Request("txtLeader")

            '2016.04.21 B0
            Dim strFieldCodeTemp As String = ""
            Dim strFieldValueTemp As String = ""
            'Dim bolTemp As Boolean = False
            '2016.04.21 E0

            For Each strControlName In Request.Form
                If Left(strControlName, 3) = "tag" Then
                    If strControlName.ToString.Trim.Length >= 6 Then
                        If strFieldCodeTemp <> strControlName.ToString.Trim.Substring(3, 3) Then
                            ReDim Preserve arrFieldName(intCounter)
                            ReDim Preserve arrFieldValue(intCounter)
                            arrFieldName(intCounter) = strFieldCodeTemp
                            arrFieldValue(intCounter) = objBCSP.parseValueFieldOther(strFieldCodeTemp, strFieldValueTemp)
                            arrFieldValue(intCounter) = arrFieldValue(intCounter).ToString().Replace(" ..", " .")
                            arrFieldValue(intCounter) = arrFieldValue(intCounter).ToString().Replace("'", "''")
                            If arrFieldName(intCounter) = "912" And Not Trim(arrFieldValue(intCounter)) = "" Then
                                intField912Value = 1
                            End If
                            If strFieldCodeTemp = "245" Then
                                arrFieldValue(intCounter) = parseValueField245(arrFieldValue(intCounter))
                            Else
                                If arrFieldValue(intCounter).Contains("$&") Then
                                    arrFieldValue(intCounter) = parseValueField(arrFieldValue(intCounter))
                                End If
                            End If
                            intCounter = intCounter + 1
                            'End If
                            strFieldValueTemp = ""
                            strFieldCodeTemp = strControlName.ToString.Trim.Substring(3, 3)
                        End If
                        Call objBCSP.concatValueSubFields(strControlName.ToString.Trim.Substring(3), Request.Form(strControlName), strFieldValueTemp)
                    End If
                End If
            Next
            objBInput.ItemCode = strItemCode
            objBInput.RecID = lngItemID
            objBInput.FieldName = arrFieldName
            objBInput.FieldValue = arrFieldValue

            If Session("IsAuthority") = "1" Then
                Dim intResue As Integer = Session("Reuse")
                If Session("Reuse") = 1 Then
                    intResue = Session("Reuse")
                    Session("Reuse") = 0
                End If
                objBInput.Reuse = intResue
                If objBInput.UpdateAuthority(Request("txtFormID"), 1) = 0 Then
                    Response.Write(objBInput.ErrorMsg)
                    btnBack.Visible = True
                    btnBack.Attributes.Add("OnClick", "javascript:history.back();")
                Else
                    'Cap Nhat tai lieu dien tu
                    Call updateEData(objBInput.RecID)

                    strJS = strJS & "alert('" & ddlLabel.Items(10).Text & "');" & Chr(13)
                    If Not Request("txtCataDetail") = "1" Then
                        If Not Request("txtCurFilteredID") = "" Then
                            strJS = strJS & "parent.Sentform.location.href = ""WCataModify.aspx?ItemID=" & Request("txtCurFilteredID") & """;" & Chr(13)
                        Else
                            strJS = strJS & "parent.Sentform.location.href = ""WCataModify.aspx?ItemID=" & Request("txtItemID") & "&CurrentID=" & Request("txtCurrentRec") & """;" & Chr(13)
                        End If
                    Else
                        strJS = strJS & "parent.Sentform.location.href=""../WNothing.htm"";" & Chr(13)
                        strJS = strJS & "self.location.href=""WCataDetail.aspx?NewRequest=1"";" & Chr(13)
                    End If
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "LoadJS", strJS, True)
                End If
            Else
                Dim intResue As Integer = Session("Reuse")
                If Session("Reuse") = 1 Then
                    intResue = Session("Reuse")
                    Session("Reuse") = 0
                End If
                objBInput.Reuse = intResue
                If objBInput.Update(Request("txtFormID"), 0) = 0 Then
                    Response.Write(objBInput.ErrorMsg)
                    btnBack.Attributes.Add("OnClick", "javascript:history.back();")
                Else
                    strItemCode = objBInput.CodeOut
                    objBItemCollection.Code = strItemCode
                    objBItemCollection.ItemID = objBInput.RecID
                    objBItemCollection.Field912Value = intField912Value
                    objBItemCollection.UpdateOpacItem(2)

                    'Cap Nhat tai lieu dien tu
                    Call updateEData(objBInput.RecID)

                    Call WriteLog(11, ddlLabel.Items(0).Text & ": " & strItemCode, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    Dim IsCopy = Request("IsCopy")
                    If IsCopy = "1" Then
                        Dim intFormID = Request("txtFormID")
                        Session("Holdings") = 1
                        Session("HoldingsInCatalogNew") = 1
                        strJS = strJS & "if (confirm('Bạn có muốn xếp giá cho ấn phẩm vừa biên mục không?')) {" & Chr(13)
                        strJS = strJS & "parent.Sentform.location.href=""WCataModify.aspx?FormID=" & intFormID & "&Module=Catalog&ItemID=" & objBInput.WorkID & "&CodeCatalog=" & objBInput.CodeOut & "&Holdings=1""; console.log('WCataModify')" & Chr(13)
                        strJS = strJS & "} else {" & Chr(13)
                        strJS = strJS & "parent.Sentform.location.href=""WCataSent.aspx?FormID=" & intFormID & "&ItemID=" & objBInput.WorkID & """;console.log('WCataSent')" & Chr(13)
                        strJS = strJS & "}" & Chr(13)
                    Else
                        strJS = strJS & "alert('" & ddlLabel.Items(10).Text & "');" & Chr(13)
                        If Not Request("txtCataDetail") = "1" Then
                            If Not Request("txtCurFilteredID") = "" Then
                                strJS = strJS & "parent.Sentform.location.href = ""WCataModify.aspx?ItemID=" & Request("txtCurFilteredID") & """;" & Chr(13)
                            Else
                                strJS = strJS & "parent.Sentform.location.href = ""WCataModify.aspx?ItemID=" & Request("txtItemID") & "&CurrentID=" & Request("txtCurrentRec") & """;" & Chr(13)
                            End If
                        Else
                            strJS = strJS & "parent.Sentform.location.href=""../WNothing.htm"";" & Chr(13)
                            strJS = strJS & "self.location.href=""WCataDetail.aspx?NewRequest=1"";" & Chr(13)
                        End If
                    End If
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "LoadJS", strJS, True)
                End If
            End If
        End Sub

        Private Sub updateEData(ByVal intItemID As Integer)
            Try
                If Not IsNothing(Session("uploadFiles")) Then
                    With objBEData
                        .ItemID = intItemID
                        .DeleteFiles()
                    End With
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
                        Else
                            Dim _fileInfo As New System.IO.FileInfo(System.IO.Path.Combine(Session("uploadFiles")(0, _icount), Session("uploadFiles")(1, _icount)))
                            With objBEData
                                .ItemID = intItemID
                                .FileLocation = _fileInfo.FullName
                                Dim intFileId As Integer = .deleteItemFile
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
                    Else
                        File.Delete(strPath)
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