' Class: WDicClassification
' Propose: 
' CreatedDate: 19/04/2004
' Creator: Sondp.
'  Modification history 
'    - 02/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDicClassification
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

        Private objBCatDiclist As New clsBCatDicList
        Private objBDicSelfMade As New clsBDictionarySelfMade

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            If Not Page.IsPostBack Then
                Call BindDicData()
            End If
            Call BindJavascript()
        End Sub

        ' Methord: BindJavascript
        ' Popurse: Bind javascript for all control need
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicClassification.js'></script>")
        End Sub

        ' Methord: Initialze
        ' Popurse: init all object use in form
        Private Sub Initialze()
            ' Object objBCatDiclist
            objBCatDiclist.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDiclist.DBServer = Session("DbServer")
            objBCatDiclist.ConnectionString = Session("ConnectionString")
            objBCatDiclist.Initialize()

            ' Object objBDicSelfMade
            objBDicSelfMade.InterfaceLanguage = Session("InterfaceLanguage")
            objBDicSelfMade.DBServer = Session("DbServer")
            objBDicSelfMade.ConnectionString = Session("ConnectionString")
            objBDicSelfMade.Initialize()

            DtgDictionary.HeaderStyle.CssClass = "lbGridHeader"
            DtgDictionary.PagerStyle.CssClass = "lbGridPager"
            DtgDictionary.AlternatingItemStyle.CssClass = "lbGridAlterCell"
            DtgDictionary.ItemStyle.CssClass = "lbGridCell"
            DtgDictionary.EditItemStyle.CssClass = "lbGridEdit"
        End Sub

        ' Methord: BindDicData
        Private Sub BindDicData(Optional ByVal intPage As Integer = 0)
            objBCatDiclist.IsClassifiCation = 1
            objBCatDiclist.IsAuthority = 1
            objBCatDiclist.SystemDic = 1
            DtgDictionary.DataSource = objBCatDiclist.Retrieve()
            DtgDictionary.CurrentPageIndex = intPage
            DtgDictionary.DataBind()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
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
                Me.Dispose()
            End Try
        End Sub

        Private Sub DtgDictionary_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DtgDictionary.PageIndexChanged
            Call Me.BindDicData(e.NewPageIndex)
        End Sub

    End Class
End Namespace