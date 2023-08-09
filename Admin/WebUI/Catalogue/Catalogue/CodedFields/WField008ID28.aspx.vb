Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WField008ID28
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel20 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBDictionary As New clsBDictionary

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
            Call BindJS()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBDictionary object
            objBDictionary.InterfaceLanguage = Session("InterfaceLanguage")
            objBDictionary.DBServer = Session("DBServer")
            objBDictionary.ConnectionString = Session("ConnectionString")
            Call objBDictionary.Initialize()
        End Sub

        ' BindData method
        ' Purpose: load data into ddlCountryCode & ddlLanguageCode
        Private Sub BindData()
            Dim tblTemp As DataTable

            ' Get Country
            objBDictionary.TableDicName = "Cat_tblDic_Country"
            tblTemp = objBDictionary.RetrieveDicIndex

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBDictionary.ErrorMsg, ddlLabel.Items(0).Text, objBDictionary.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlCountryCode.DataSource = tblTemp
                ddlCountryCode.DataTextField = "Code"
                ddlCountryCode.DataValueField = "ISOCode"
                ddlCountryCode.DataBind()
                tblTemp.Clear()
            End If

            ' Get Language
            objBDictionary.TableDicName = "Cat_tblDic_Language"
            tblTemp = objBDictionary.RetrieveDicIndex

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBDictionary.ErrorMsg, ddlLabel.Items(0).Text, objBDictionary.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLanguage.DataSource = tblTemp
                ddlLanguage.DataTextField = "Code"
                ddlLanguage.DataValueField = "ISOCode"
                ddlLanguage.DataBind()
                tblTemp = Nothing
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Dim strWorkField As String = Request("WorkField")
            Dim strSendField As String = Request("SendField")
            Dim strJS As String = ""

            strJS = strJS & "var intFileID = 28;" & Chr(13)
            strJS = strJS & "var strSendField = '" & strSendField & "';" & Chr(13)
            strJS = strJS & "var strWorkField = '" & strWorkField & "';" & Chr(13)
            strJS = strJS & "var strFieldIDs = ',1,3,4,5,6,7,8,10,13,15,16,17,';" & Chr(13)

            Page.RegisterClientScriptBlock("RegvarJs", "<script language = 'javascript'>" & strJS & "</script>")
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WCodedFieldHelpJs", "<script language = 'javascript' src = '../../Js/Catalogue/CodedFields/WCodedFieldHelp.js'></script>")

            btnPreview.Attributes.Add("OnClick", "javascript:PreView(19); return false;")
            btnUpdate.Attributes.Add("OnClick", "javascript:Update(19)")
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); return false")
            btnClose.Attributes.Add("OnClick", "self.close();")

            ddlTemp3.Attributes.Add("OnChange", "javascript: LoadTextData('ddlTemp3','txtField3');")
            ddlTemp4.Attributes.Add("OnChange", "javascript: LoadTextData('ddlTemp4','txtField4');")
            ddlTemp6.Attributes.Add("OnChange", "javascript: LoadTextData('ddlTemp6','txtField6');")
            ddlField7.Attributes.Add("OnChange", "javascript: LoadTextData('ddlField7','txtField7');")
            ddlTemp16.Attributes.Add("OnChange", "javascript: LoadTextData('ddlTemp16','txtField16');")
            ddlLanguage.Attributes.Add("OnChange", "javascript: LoadTextData('ddlLanguage','txtField17');")
            ddlCountryCode.Attributes.Add("OnChange", "javascript: LoadTextData('ddlCountryCode','txtField5');")
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace