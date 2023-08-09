
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WGet915
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
        Private objBDictionary As New clsBDictionary
        Private objBCatDicList As New clsBCatDicList
        Private objBCDB As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
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


            objBCDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDB.DBServer = Session("DBServer")
            objBCDB.ConnectionString = Session("ConnectionString")
            Call objBCDB.Initialize()

            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub
        ' BindData method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WGetReferenceJs", "<script language = 'javascript' src = '../Js/Catalogue/WGetReference.js'></script>")

            btnClose.Attributes.Add("OnClick", "self.close();")
            btnSelect.Attributes.Add("OnClick", "javascript:return(LoadBackData915());")
        End Sub
        Private Sub BindData()
            Dim strSQL As String = ""
            Dim tblTemp As DataTable
            strSQL = "SELECT ID,DisplayEntry,Name FROM Cat_tblDicThesisSubject"
            objBCDB.SQLStatement = strSQL
            tblTemp = objBCDB.RetrieveItemInfor()
            lstEntries.DataSource = tblTemp
            lstEntries.DataTextField = "DisplayEntry"
            lstEntries.DataValueField = "Name"
            lstEntries.DataBind()
        End Sub

        Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
            Dim strSQL As String = ""
            Dim strMuctu As String = ""
            Dim strTenCN As String = ""
            Dim tblTemp As DataTable
            strSQL = "SELECT ID,DisplayEntry,Name FROM Cat_tblDicThesisSubject WHERE "
            If txtMuctu.Text <> "" Then
                strMuctu = objBCSP.ProcessVal(objBCSP.ConvertItBack(txtMuctu.Text))
                strSQL &= " ACCESSENTRY LIKE '" & strMuctu & "' AND "
            End If
            If txtTenCN.Text <> "" Then
                strTenCN = objBCSP.ConvertItBack(txtTenCN.Text)
                strSQL &= " NAME ='" & strTenCN & "'"
            Else
                strSQL &= " 1=1 "
            End If
            strSQL &= " ORDER BY DisplayEntry"
            objBCDB.SQLStatement = strSQL
            tblTemp = objBCDB.RetrieveItemInfor
            lstEntries.DataSource = tblTemp
            lstEntries.DataTextField = "DisplayEntry"
            lstEntries.DataValueField = "Name"
            lstEntries.DataBind()
        End Sub
    End Class
End Namespace
