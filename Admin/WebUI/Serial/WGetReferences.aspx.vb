Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class GetReferences
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
            Call BindJavascript()
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

        End Sub

        ' BindJavascript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WGetReferenceJs", "<script language = 'javascript' src = 'Js/WGetReferences.js'></script>")
            btnClose.Attributes.Add("OnClick", "javascript:Close();")
            If Request("DicID") = 10 Or Request("DicID") = 11 Then
                btnSelect.Attributes.Add("OnClick", "javascript:if(!LoadBackValue()) return false;")
            Else
                btnSelect.Attributes.Add("OnClick", "javascript:if(!LoadBackData()) return false;")
            End If

        End Sub

        ' BindData method
        ' Purpose: Bind reference entries in dropdownlist
        Private Sub BindData()
            ' String
            Dim strDicID As String
            Dim strSearchData As String
            Dim strDicname As String
            Dim strDestField As String
            Dim strDicTableName As String = ""
            Dim strJavaScript As String = ""

            ' DataTable
            Dim tblTemp As DataTable

            If Not Request("DicID") & "" = "" Then
                strDicID = Request("DicID")
            End If

            If Not Request("SearchData") & "" = "" Then
                strSearchData = Request("SearchData")
            End If

            If Not Trim(Request("Frame")) & "" = "" Then
                strDestField = Trim(Request("Frame"))
            End If

            ' get FieldCode
            strJavaScript = strJavaScript & "var strDestField = '" & strDestField & "';" & Chr(13)

            ' If the strDicID is numeric (exist int the database)
            If IsNumeric(strDicID) Then
                objBCatDicList.IsAuthority = 1
                objBCatDicList.IsClassifiCation = 0
                If Trim(strDicID) = "4" Or Trim(strDicID) = "5" Then
                    objBCatDicList.IsClassifiCation = 1
                End If

                objBCatDicList.SystemDic = 1
                objBCatDicList.IDs = strDicID

                tblTemp = objBCatDicList.Retrieve

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCatDicList.ErrorMsg, ddlLabel.Items(1).Text, objBCatDicList.ErrorCode)

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count = 0 Then ' No data or not exist dictionary matched
                        lblMainTitle.Text = strDicname & ddlLabel.Items(4).Text
                        lstEntries.Visible = False
                        btnSelect.Visible = False
                    Else
                        strDicname = tblTemp.Rows(0).Item("Name")
                        ' Get the table dictionary name
                        objBDictionary.TableDicName = UCase(tblTemp.Rows(0).Item("DicTable").ToString)
                        objBDictionary.SearchFields = UCase(tblTemp.Rows(0).Item("SearchFields").ToString)
                        objBDictionary.AccessEntry = strSearchData
                        tblTemp = objBDictionary.RetrieveDicAuthor

                        ' Write Error
                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBDictionary.ErrorMsg, ddlLabel.Items(1).Text, objBDictionary.ErrorCode)

                        If Not tblTemp Is Nothing Then
                            If tblTemp.Rows.Count > 0 Then
                                lblMainTitle.Text = ddlLabel.Items(2).Text & ": " & strDicname
                                lstEntries.DataSource = tblTemp
                                Select Case objBDictionary.TableDicName
                                    Case "Cat_tblDic_ItemType"
                                        lstEntries.DataTextField = "TypeCode"
                                        lstEntries.DataValueField = "ID"
                                    Case "Cat_tblDicMedium"
                                        lstEntries.DataTextField = "Code"
                                        lstEntries.DataValueField = "ID"
                                    Case "Lib_tblHoldingType"
                                        lstEntries.DataTextField = "Code"
                                        lstEntries.DataValueField = "ID"
                                    Case "Cat_tblDic_Country"
                                        lstEntries.DataTextField = "Display"
                                        lstEntries.DataValueField = "IsoCode"
                                    Case "Cat_tblDic_Language"
                                        lstEntries.DataTextField = "Display"
                                        lstEntries.DataValueField = "IsoCode"
                                    Case Else
                                        lstEntries.DataTextField = "DisplayEntry"
                                        lstEntries.DataValueField = "ID"
                                End Select
                                lstEntries.DataBind()
                            Else
                                lblMainTitle.Text = strDicname & ": " & ddlLabel.Items(3).Text
                                lstEntries.Visible = False
                                btnSelect.Visible = False
                            End If
                        Else
                            lblMainTitle.Text = strDicname & ": " & ddlLabel.Items(3).Text
                            lstEntries.Visible = False
                            btnSelect.Visible = False
                        End If
                    End If
                Else
                    lblMainTitle.Text = ddlLabel.Items(4).Text
                    lstEntries.Visible = False
                    btnSelect.Visible = False
                End If
            Else
                lblMainTitle.Text = ddlLabel.Items(4).Text
                lstEntries.Visible = False
                btnSelect.Visible = False
            End If
            Page.RegisterClientScriptBlock("InitVariables", "<script language = 'javascript'>" & strJavaScript & "</script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release the methods
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
    End Class
End Namespace
