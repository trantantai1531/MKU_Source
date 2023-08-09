' WGetReference class
' Purpose: get reference entries
' Creator: Oanhtn
' CreatedDate: 23/05/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WGetReference
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
        Private objBDictionary As New clsBDictionary
        Private objBCatDicList As New clsBCatDicList
        Private objBDB As New clsBCommonDBSystem


        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBDictionary object
            objBDictionary.InterfaceLanguage = Session("InterfaceLanguage")
            objBDictionary.DBServer = Session("DBServer")
            objBDictionary.ConnectionString = Session("ConnectionString")
            Call objBDictionary.Initialize()

            ' Init objBCatDicList object
            objBCatDicList.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDicList.DBServer = Session("DBServer")
            objBCatDicList.ConnectionString = Session("ConnectionString")
            Call objBCatDicList.Initialize()

            ' Init objBDB object
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()
        End Sub

        ' BindData method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WGetReferenceJs", "<script language = 'javascript' src = '../Js/Catalogue/WGetReference.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:return(Close());")
            btnSelect.Attributes.Add("OnClick", "javascript:return(LoadBackData());")
        End Sub

        ' BindData method
        ' Purpose: Bind reference entries in dropdownlist
        Private Sub BindData()
            Dim intRepeatable As Integer = Request("Repeatable")
            Dim strDestField As String = Trim(Request("Frame"))
            Dim strStoreField As String = Trim(Request("storeframe"))
            Dim strPattern As String = Trim(Request("Keyword"))
            Dim strParentFieldCode As String = ""
            Dim strSubFieldCode As String = ""
            Dim strFieldCode As String = ""
            Dim strHeader As String = ""
            Dim intPosition As Integer
            Dim tblTemp As DataTable
            Dim strDicTableName As String = ""
            Dim strJavaScript As String = ""
            Dim strPattern1 As String = ""

            ' Get variables
            intPosition = InStrRev(strPattern, "$")
            strPattern1 = Right(strPattern, Len(strPattern) - intPosition)
            strPattern1 = strPattern1.Replace("$", "")
            If Len(Trim(strPattern1)) = 0 Then
                intPosition = 0
            End If
            If intPosition > 0 Then
                strSubFieldCode = Mid(strPattern, intPosition, 2)
                strHeader = Trim(Left(strPattern, intPosition - 1).Replace("$", ""))
                strPattern = Right(strPattern, Len(strPattern) - intPosition - 1)
            End If
            ' get FieldCode
            If InStr(Request("tag"), "$") = 0 Then
                strFieldCode = Request("tag") + strSubFieldCode
            Else
                strFieldCode = Request("tag")
            End If
            If Left(strFieldCode, 3) = "tag" Then
                strFieldCode = Right(strFieldCode, Len(strFieldCode) - 3)
            End If

            strParentFieldCode = strFieldCode 'Left(strFieldCode, 3)

            strJavaScript = strJavaScript & "var strDestField = '" & strDestField & "';" & Chr(13)
            strJavaScript = strJavaScript & "var strStoreField = '" & strStoreField & "';" & Chr(13)
            strJavaScript = strJavaScript & "var strHeader = '" & strHeader & "';" & Chr(13)
            strJavaScript = strJavaScript & "var intRepeatable = " & intRepeatable & ";" & Chr(13)
            strJavaScript = strJavaScript & "var strFieldCode = '" & strFieldCode & "';" & Chr(13)
            strJavaScript = strJavaScript & "var strParentFieldCode = '" & strParentFieldCode & "';" & Chr(13)
            strJavaScript = strJavaScript & "var strSubFieldCode = '" & strSubFieldCode & "';" & Chr(13)

            ' tblTemp
            objBCatDicList.FieldCode = strFieldCode
            tblTemp = objBCatDicList.GetReferenceByFieldCode

            If tblTemp.Rows.Count = 0 Then ' not used index
                lblMainTitle.Text = strFieldCode & ": " & ddlLabel.Items(3).Text
                lstEntries.Visible = False
                btnSelect.Visible = False
            Else
                lblMainTitle.Text = tblTemp.Rows(0).Item("Name")
                objBDictionary.TopNumber = 100
                objBDictionary.AccessEntry = strPattern
                objBDictionary.TableDicName = UCase(tblTemp.Rows(0).Item("DicTable").ToString)
                objBDictionary.SearchFields = UCase(tblTemp.Rows(0).Item("SearchFields").ToString)
                'tblTemp = objBDictionary.RetrieveDicIndex
                tblTemp = objBDictionary.RetrieveDicAuthor

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        lstEntries.DataSource = tblTemp
                        'Select Case objBDictionary.TableDicName
                        '    Case "CAT_DIC_ITEM_TYPE"
                        '        lstEntries.DataTextField = "TypeCode"
                        '        lstEntries.DataValueField = "ID"
                        '    Case "CAT_DIC_MEDIUM"
                        '        lstEntries.DataTextField = "Code"
                        '        lstEntries.DataValueField = "ID"
                        '    Case Else
                        '        lstEntries.DataTextField = "DisplayEntry"
                        '        lstEntries.DataValueField = "ID"
                        'End Select
                        Select Case objBDictionary.TableDicName
                            Case UCase("Cat_tblDic_ItemType")
                                tblTemp.Columns.Add("TypeCodeAndName", GetType(String), "TypeCode + ' ' + TypeName")
                                lstEntries.DataSource = tblTemp
                                lstEntries.DataTextField = "TypeCodeAndName"
                                lstEntries.DataValueField = "TypeCode"
                            Case UCase("Cat_tblDicMedium")
                                tblTemp.Columns.Add("TypeCodeAndName", GetType(String), "Code + ' ' + Description")
                                lstEntries.DataSource = tblTemp
                                'lstEntries.DataTextField = "Code"
                                'lstEntries.DataValueField = "ID"
                                lstEntries.DataTextField = "TypeCodeAndName"
                                lstEntries.DataValueField = "Code"
                            Case UCase("Lib_tblHoldingType")
                                lstEntries.DataTextField = "Code"
                                lstEntries.DataValueField = "ID"
                            Case UCase("Cat_tblDic_Country")
                                lstEntries.DataTextField = "Display"
                                lstEntries.DataValueField = "IsoCode"
                            Case UCase("Cat_tblDic_Language")
                                lstEntries.DataTextField = "Display"
                                lstEntries.DataValueField = "IsoCode"
                            Case UCase("Cat_tblDic_ClassDdc") '2016.05.11 
                                tblTemp.Columns.Add("TypeCodeAndName", GetType(String), "Code + ' : ' + CodeConcat")
                                lstEntries.DataSource = tblTemp
                                lstEntries.DataTextField = "TypeCodeAndName"
                                lstEntries.DataValueField = "Code"
                            Case UCase("Cir_tblDicFaculty") '2016.05.11 
                                lstEntries.DataTextField = "Faculty"
                                lstEntries.DataValueField = "ID"
                            Case Else
                                If InStr(objBDictionary.TableDicName, "DICTIONARY") > 0 Then
                                    lstEntries.DataTextField = "DICTIONARY"
                                    lstEntries.DataValueField = "ID"
                                Else
                                    lstEntries.DataTextField = "DisplayEntry"
                                    lstEntries.DataValueField = "ID"
                                End If
                        End Select
                        lstEntries.DataBind()
                    End If
                End If
            End If
            Page.RegisterClientScriptBlock("InitVariables", "<script language = 'javascript'>" & strJavaScript & "</script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBDictionary Is Nothing Then
                    objBDictionary.Dispose(True)
                    objBDictionary = Nothing
                End If
                If Not objBCatDicList Is Nothing Then
                    objBCatDicList.Dispose(True)
                    objBCatDicList = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
            Dim intID As Integer
            Dim tblResult As DataTable

            If Not lstEntries.SelectedValue = "" Then
                intID = CInt(lstEntries.SelectedValue)
            End If
            objBDB.SQLStatement = ""
        End Sub
    End Class
End Namespace