Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WReferenceToFilter
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg3 As System.Web.UI.WebControls.Label


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
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WGetReferenceJs", "<script language = 'javascript' src = '../Js/Catalogue/WReferenceTofilter.js'></script>")
            btnClose.Attributes.Add("OnClick", "javascript:Close();")
            If IsNumeric(Request("DicID")) Then
                If Request("DicID") = 10 Or Request("DicID") = 11 Then
                    btnSelect.Attributes.Add("OnClick", "javascript:if(!LoadBackValue()) return false;")
                Else
                    btnSelect.Attributes.Add("OnClick", "javascript:if(!LoadBackData()) return false;")
                End If
            End If
        End Sub

        ' BindData method
        ' Purpose: Bind reference entries in dropdownlist
        Private Sub BindData()
            ' String
            Dim strDicID As String = Request("DicID")
            Dim strSearchData As String = Trim(Request("SearchData"))
            Dim strDicname As String
            Dim strDestField As String = Trim(Request("Frame"))
            Dim strDicTableName As String = ""
            Dim strJavaScript As String = ""
            ' Label
            Dim strLabel1 As String = ddlLabel.items(0).Text
            Dim strLabel2 As String = ddlLabel.items(1).Text
            Dim strLabel3 As String = ddlLabel.items(2).Text
            ' DataTable
            Dim tblTemp As DataTable

            ' get FieldCode
            strJavaScript = strJavaScript & "var strDestField = '" & strDestField & "';" & Chr(13)

            ' If the strDicID is numeric (exist int the database)
            If IsNumeric(strDicID) Then
                objBCatDicList.IsAuthority = -1 '1
                objBCatDicList.IsClassifiCation = -1 '0
                If Trim(strDicID) = "4" Or Trim(strDicID) = "5" Then
                    objBCatDicList.IsClassifiCation = -1 '1
                End If
                objBCatDicList.SystemDic = 2 '1
                objBCatDicList.IDs = strDicID
                objBCatDicList.LibID = clsSession.GlbSite
                tblTemp = objBCatDicList.Retrieve

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count = 0 Then ' No data or not exist dictionary matched
                        lblMainTitle.Text = strDicname & strLabel3
                        lstEntries.Visible = False
                        btnSelect.Visible = False
                    Else
                        strDicname = tblTemp.Rows(0).Item("Name")
                        ' Get the table dictionary name
                        objBDictionary.TableDicName = UCase(tblTemp.Rows(0).Item("DicTable").ToString)
                        objBDictionary.SearchFields = UCase(tblTemp.Rows(0).Item("SearchFields").ToString)
                        objBDictionary.AccessEntry = strSearchData
                        objBDictionary.LibID = clsSession.GlbSite
                        tblTemp = objBDictionary.RetrieveDicAuthor
                        If tblTemp.Rows.Count <> 0 Then
                            lblMainTitle.Text = strLabel1 & ": " & strDicname
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
                                    If InStr(objBDictionary.TableDicName, "DICTIONARY") > 0 Then
                                        lstEntries.DataTextField = "DICTIONARY"
                                        lstEntries.DataValueField = "ID"
                                    Else
                                        lstEntries.DataTextField = "DisplayEntry"
                                        lstEntries.DataValueField = "ID"
                                    End If
                            End Select
                            lstEntries.DataBind()
                        Else
                            lblMainTitle.Text = strDicname & ": " & strLabel2
                            lstEntries.Visible = False
                            btnSelect.Visible = False
                        End If
                    End If
                Else
                    lblMainTitle.Text = strLabel3
                    lstEntries.Visible = False
                    btnSelect.Visible = False
                End If
            Else
                lblMainTitle.Text = strLabel3
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
