Imports eMicLibAdmin.BusinessRules.Catalogue
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDicAuthority
        Inherits clsWBase
        Implements IUCNumberOfRecord
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitleLetf As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsgDEL As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsgINS As System.Web.UI.WebControls.Label
        Protected WithEvents lblSuccess As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsgExist As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel0 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCatDiclist As New clsBCatDicList
        Private objBDicSelfMade As New clsBDictionarySelfMade

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindDicData()
            End If
        End Sub

        ' Method: BindJavascript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicAuthority.js'></script>")
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            ' Duyet xem tu dien
            If Not CheckPemission(8) Then
                DtgDictionary.Columns(1).Visible = False
            End If
            ' Quan ly chi so phan loai
            If Not CheckPemission(224) Then
                DtgDictionary.Columns(2).Visible = False
            End If
        End Sub

        ' Method: Initialze
        ' Purpose: Init all object use in form
        Private Sub Initialze()
            ' Init objBCatDiclist object
            objBCatDiclist.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDiclist.DBServer = Session("DbServer")
            objBCatDiclist.ConnectionString = Session("ConnectionString")
            Call objBCatDiclist.Initialize()

            ' Init objBDicSelfMade object
            objBDicSelfMade.InterfaceLanguage = Session("InterfaceLanguage")
            objBDicSelfMade.DBServer = Session("DbServer")
            objBDicSelfMade.ConnectionString = Session("ConnectionString")
            Call objBDicSelfMade.Initialize()
        End Sub

        ' Method: BindDicData
        Private Sub BindDicData()
            Dim tblResult As DataTable
            Dim intCount As Integer

            objBCatDiclist.SystemDic = 1
            objBCatDiclist.IsAuthority = -1
            objBCatDiclist.IsClassifiCation = -1
            tblResult = objBCatDiclist.Retrieve()
            ' Show list of sys dictionary
            DtgDictionary.Visible = False
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                intCount = Math.Ceiling(tblResult.Rows.Count / DtgDictionary.PageSize)
                If DtgDictionary.CurrentPageIndex >= intCount Then
                    DtgDictionary.CurrentPageIndex = DtgDictionary.CurrentPageIndex - 1
                End If
                DtgDictionary.DataSource = tblResult
                'DtgDictionary.DataBind()
                DtgDictionary.Visible = True
            End If
        End Sub

       
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCatDiclist Is Nothing Then
                        objBCatDiclist.Dispose(True)
                        objBCatDiclist = Nothing
                    End If
                    If Not objBDicSelfMade Is Nothing Then
                        objBDicSelfMade.Dispose(True)
                        objBDicSelfMade = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Dispose()
            End Try
        End Sub

        Protected Sub DtgDictionary_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles DtgDictionary.NeedDataSource
           
            BindDicData()
        End Sub

        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

    End Class
End Namespace