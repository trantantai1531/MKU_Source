Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataViewHidden
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

        Private strSeparate As String = ":::"
        Private strJS As String
        Private strFieldCode As String
        Private strInd As String
        Private strFieldVal As String
        Private strIDs As String
        Private strTmpFieldCode As String
        Private strTmpIndicator As String
        Private strTmpFieldValue As String
        Dim strPrefix As String = ""
        Dim tblTable As DataTable
        Private objBValidate As New clsBValidate
        Private objBField As New clsBField

        ' Initialize Method
        ' Popurse: Init all object using in form
        Private Sub Initialize()
            If Session("IsAuthority") = 1 Then
                strPrefix = "a"
            End If

            ' Init objBValidate object
            objBValidate.IsAuthority = Session("IsAuthority")
            objBValidate.ConnectionString = Session("ConnectionString")
            objBValidate.InterfaceLanguage = Session("InterfaceLanguage")
            objBValidate.DBServer = Session("DBServer")
            objBValidate.Separate = strSeparate
            objBValidate.Initialize()

            ' Init objBField object
            objBField.IsAuthority = Session("IsAuthority")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.Initialize()
        End Sub

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
        End Sub

        ' BindData method   
        Private Sub BindData()
            Dim strFieldValOld As String

            strFieldCode = Request("FieldCode")
            strInd = Request("Indicator")
            strFieldVal = Request("FieldValue")


            If Len(strInd) > 2 Then
                strInd = Left(strInd, 2)
            End If

            strInd = Replace(strInd, "a", "#")

            strJS = "alert('" & ddlLabel.Items(4).Text & ":\n" & strFieldCode & ": " & strInd & strFieldVal & "');"
            Page.RegisterClientScriptBlock("JSPostItemID", "<script language='javascript'>" & strJS & "</script>")

            'DoAction(strFieldCode, strInd, strFieldVal, "ADD")
            Call InsertSession()
        End Sub

        ' InsertSession method
        ' Purpose: Get content for field name, field value
        Sub InsertSession()
            Dim intRepeatable As Integer
            Dim tblFields As DataTable

            If Not strFieldCode = "" Then
                objBField.FieldCode = strFieldCode
                tblFields = objBField.GetProperties()
                Call WriteErrorMssg(objBField.ErrorCode, objBField.ErrorMsg)

                If Not tblFields Is Nothing Then
                    If tblFields.Rows.Count > 0 Then
                        If tblFields.Rows(0).Item("Repeatable") Or tblFields.Rows(0).Item("Repeatable") = "1" Then
                            intRepeatable = 1
                        Else
                            intRepeatable = 0
                        End If
                        If Not Session(strPrefix & "AllFields") Is Nothing Then
                            If Not InStr("," & Session(strPrefix & "AllFields") + ",", "," & Trim(strFieldCode) & ",") > 0 Then
                                Session(strPrefix & "AllFields") = Session(strPrefix & "AllFields") & Trim(strFieldCode) & ","
                                If Not IsDBNull(tblFields.Rows(0).Item("Indicators")) Or Not IsDBNull(tblFields.Rows(0).Item("VietIndicators")) Then
                                    Session(strPrefix & Trim(strFieldCode)) = strInd & "::" & strFieldVal
                                Else
                                    Session(strPrefix & Trim(strFieldCode)) = strFieldVal
                                End If
                            Else
                                If intRepeatable = 0 Then
                                    If Not IsDBNull(tblFields.Rows(0).Item("Indicators")) Or Not IsDBNull(tblFields.Rows(0).Item("VietIndicators")) Then
                                        Session(strPrefix & Trim(strFieldCode)) = strInd & "::" & strFieldVal
                                    Else
                                        Session(strPrefix & Trim(strFieldCode)) = strFieldVal
                                    End If
                                Else
                                    If Not IsDBNull(tblFields.Rows(0).Item("Indicators")) Or Not IsDBNull(tblFields.Rows(0).Item("VietIndicators")) Then
                                        Session(strPrefix & Trim(strFieldCode)) = Session(strPrefix & Trim(strFieldCode)) & "$&" & strInd & "::" & strFieldVal
                                    Else
                                        Session(strPrefix & Trim(strFieldCode)) = Session(strPrefix & Trim(strFieldCode)) & "$&" & strFieldVal
                                    End If
                                End If
                            End If
                        Else
                            If intRepeatable = 0 Then
                                If Not IsDBNull(tblFields.Rows(0).Item("Indicators")) Or Not IsDBNull(tblFields.Rows(0).Item("VietIndicators")) Then
                                    Session(strPrefix & Trim(strFieldCode)) = strInd & "::" & strFieldVal
                                Else
                                    Session(strPrefix & Trim(strFieldCode)) = strFieldVal
                                End If
                            Else
                                If Not IsDBNull(tblFields.Rows(0).Item("Indicators")) Or Not IsDBNull(tblFields.Rows(0).Item("VietIndicators")) Then
                                    Session(strPrefix & Trim(strFieldCode)) = Session(strPrefix & Trim(strFieldCode)) & "$&" & strInd & "::" & strFieldVal
                                Else
                                    Session(strPrefix & Trim(strFieldCode)) = Session(strPrefix & Trim(strFieldCode)) & "$&" & strFieldVal
                                End If
                            End If
                            Session(strPrefix & "AllFields") = Trim(strFieldCode) & ","
                        End If
                    End If
                End If
            End If

            ' Assign value from Sessions to variables
            strIDs = ""
            objBValidate.FieldCode = strFieldCode
            objBValidate.Indicator = strInd
            objBValidate.FieldValue = strFieldVal

            objBValidate.Repeat = intRepeatable
            objBValidate.Separate = strSeparate
            objBValidate.Action = "ADD"

            tblTable = objBValidate.MakeDataTable(strTmpFieldCode, strTmpIndicator, strTmpFieldValue, strIDs)

            ' Get value form variables to Sessions
            Session(strPrefix & "IDs") = strIDs
            Session(strPrefix & "FieldCode") = strTmpFieldCode
            Session(strPrefix & "Indicator") = strTmpIndicator
            Session(strPrefix & "FieldValue") = strTmpFieldValue
        End Sub

        ' DoAction method
        Private Function DoAction(ByVal strFieldCode As String, ByVal strIndicator As String, ByVal strFieldVal As String, ByVal strAction As String) As Integer
            Dim strJs As String = ""

            DoAction = 0

            objBValidate.FieldCode = strFieldCode
            objBValidate.Indicator = strIndicator
            objBValidate.FieldValue = strFieldVal

            ' Check field's indicator
            If objBValidate.CheckIndicators(strIndicator) > 0 Then
                Select Case objBValidate.CheckIndicators(strIndicator)
                    Case 1
                        strJs = ddlLabel.Items(0).Text
                    Case 2
                        strJs = ddlLabel.Items(1).Text
                    Case 3
                        strJs = ddlLabel.Items(2).Text
                End Select
                Page.RegisterClientScriptBlock("CheckIndicator", "<script language='javascript'>alert('" & strJs & "');</script>")
                DoAction = 1

                Exit Function
            End If

            ' Check field's value
            strJs = ""
            strJs = objBValidate.CheckTag(ddlLabel.Items(3).Text)

            If (Len(Trim(strJs)) > 0) Then
                Page.RegisterClientScriptBlock("CheckValue", "<script language='javascript'>alert('" & strJs & "');</script>")
                DoAction = 1

                Exit Function
            End If
        End Function

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBValidate Is Nothing Then
                    objBValidate.Dispose(True)
                    objBValidate = Nothing
                End If
                If Not objBField Is Nothing Then
                    objBField.Dispose(True)
                    objBField = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace