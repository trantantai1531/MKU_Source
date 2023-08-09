' WMarcValid class
' Purpose: ValidateData fields's data
' Creator: Khoana
' CreatedDate: 25/05/2004
' Modification history:
'   - 15/06/2004 by Oanhtn
'   - 03/03/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcValid
        Inherits clsWBase

        Private objBValidate As New clsBValidate
        Private objBCSP As New clsBCommonStringProc

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call ValidateData()
        End Sub

        Private Sub Initialize()
            ' Init objBCatalogueForm object
            objBValidate.IsAuthority = Session("IsAuthority")
            objBValidate.InterfaceLanguage = Session("InterfaceLanguage")
            objBValidate.DBServer = Session("DBServer")
            objBValidate.ConnectionString = Session("ConnectionString")
            Call objBValidate.Initialize()

            ' Init objBCSP
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        Private Sub InitializeArrayLabelError(ByRef arrLabelStr() As String)
            ReDim arrLabelStr(21)
            arrLabelStr(0) = ddlLabel.Items(0).Text
            arrLabelStr(1) = ddlLabel.Items(1).Text
            arrLabelStr(2) = ddlLabel.Items(2).Text
            arrLabelStr(3) = ddlLabel.Items(3).Text
            arrLabelStr(4) = ddlLabel.Items(4).Text
            arrLabelStr(5) = ddlLabel.Items(5).Text
            arrLabelStr(6) = ddlLabel.Items(6).Text
            arrLabelStr(7) = ddlLabel.Items(7).Text
            arrLabelStr(8) = ddlLabel.Items(8).Text
            arrLabelStr(9) = ddlLabel.Items(9).Text
            arrLabelStr(10) = ddlLabel.Items(10).Text
            arrLabelStr(11) = ddlLabel.Items(11).Text
            arrLabelStr(12) = ddlLabel.Items(12).Text
            arrLabelStr(13) = ddlLabel.Items(16).Text
            arrLabelStr(14) = ddlLabel.Items(17).Text
            arrLabelStr(15) = ddlLabel.Items(18).Text
            arrLabelStr(16) = ddlLabel.Items(19).Text
            arrLabelStr(17) = ddlLabel.Items(20).Text
            arrLabelStr(18) = ddlLabel.Items(21).Text
            arrLabelStr(19) = ddlLabel.Items(22).Text
            arrLabelStr(20) = ddlLabel.Items(23).Text
            arrLabelStr(21) = ddlLabel.Items(24).Text
        End Sub

        ' ValidateData method
        Private Sub ValidateData()
            Dim strMessage As String = ""
            Dim objElement As Object
            Dim arrLabelStr() As String = Nothing
            Dim blnUpdateOK As Boolean = False
            Dim strJSWaiting As String
            Dim strLeader As String = ""
            Dim strField008Value As String = "", strField006Value As String = "", strField007Value As String = ""

            InitializeArrayLabelError(arrLabelStr)

            objBValidate.LabelStr = arrLabelStr
            Try
                Dim strFieldCodeTemp As String = "" 'Hold temporary fieldcode throught processing (concat subfield-code value purpose)
                Dim strFieldValueTemp As String = "" 'Holding temporary subfield-code value.
                For Each objElement In Request.Form
                    Dim element As String = CStr(objElement).ToLower().Trim()
                    Dim elementValue As String = Request(objElement).Trim()

                    If Not element.Equals("tags") Then
                        If element.Equals("txtLeader") Then
                            strLeader = elementValue
                        End If
                        If Left(element, 3).Equals("tag") Then
                            Dim subFieldCode As String = Right(element, Len(element) - 3) 'Sub field code is field code include it subfield. ex: 100$a
                            Select Case subFieldCode
                                Case "006"
                                    strField006Value = elementValue
                                Case "007"
                                    strField007Value = elementValue
                                Case "008"
                                    strField008Value = elementValue
                                Case Else
                                    'Only subfield code is using in here to contruct the content validation.(not parent field code)
                                    If element.Length >= 6 Then
                                        Dim fieldCode As String = element.Substring(3, 3)
                                        If Not strFieldCodeTemp.Equals(fieldCode) Then
                                            If strFieldValueTemp <> "" Then
                                                objBValidate.FieldCode = strFieldCodeTemp
                                                objBValidate.FieldValue = objBCSP.parseValueField(strFieldCodeTemp, strFieldValueTemp)
                                                strMessage = strMessage & objBValidate.CheckAllTags
                                                If strFieldCodeTemp = "245" Then
                                                    strMessage = ""
                                                End If
                                            End If
                                            strFieldValueTemp = ""
                                            strFieldCodeTemp = fieldCode
                                        End If
                                        Call objBCSP.concatValueSubFields(element.Substring(3), elementValue, strFieldValueTemp)
                                    End If
                            End Select
                        End If
                    End If
                Next

                ' Check 006
                objBValidate.FieldCode = "006"
                objBValidate.FieldValue = strField006Value
                strMessage = strMessage & objBValidate.CheckAllTags(strLeader)
                ' Check 007
                objBValidate.FieldCode = "007"
                objBValidate.FieldValue = strField007Value
                strMessage = strMessage & objBValidate.CheckAllTags(strLeader)
                ' Check 008
                objBValidate.FieldCode = "008"
                objBValidate.FieldValue = strField008Value
                strMessage = strMessage & objBValidate.CheckAllTags(strLeader)

                If Not Trim(strMessage) = "" Then
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "UnValidate", "alert('" & arrLabelStr(2) & "\n" & strMessage & "'); parent.Workform.focus();", True)
                Else
                    If CInt(Request("txtUpdateNow")) = 1 Then
                        strJSWaiting = "parent.document.getElementById('frmMain').setAttribute('rows','*,0');"
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), "ValidateData", strJSWaiting & ";parent.Sentform.document.forms[0].submit();", True)
                    Else
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), "ValidateData", "parent.Sentform.document.forms[0].txtUpdateNow.value == '0'; alert('" & arrLabelStr(1) & "'); parent.Workform.focus();", True)
                    End If
                End If
            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "UnValidate", "alert('" & ddlLabel.Items(15).Text & "'); parent.Workform.focus();", True)
            End Try
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBValidate Is Nothing Then
                    objBValidate.Dispose(True)
                    objBValidate = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace