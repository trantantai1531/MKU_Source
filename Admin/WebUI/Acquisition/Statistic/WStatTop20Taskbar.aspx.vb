' Class: WStatTop20
' Puspose: Create statistic top 20 items
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review 

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatTop20Taskbar
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
        Private objBCDL As New clsBCatDicList
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call binddata()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            ' Initialize objBCDL object
            objBCDL.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDL.DBServer = Session("DBServer")
            objBCDL.ConnectionString = Session("ConnectionString")
            Call objBCDL.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindScript()
            btnClose.Attributes.Add("onclick", "javascript:parent.location.href='WStatIndex.aspx';return false;")

            btnStatistic.Attributes.Add("OnClick", "javascript:parent.Display.location.href='WStatTop20.aspx?ID=' + document.forms[0].ddlTop20.options[document.forms[0].ddlTop20.options.selectedIndex].value + '&text=' + document.forms[0].ddlTop20.options[document.forms[0].ddlTop20.options.selectedIndex].text;return false;")
            btnExport.Attributes.Add("OnClick", "javascript:parent.Display.location.href='WStatTop20.aspx?export=true&ID=' + document.forms[0].ddlTop20.options[document.forms[0].ddlTop20.options.selectedIndex].value + '&text=' + document.forms[0].ddlTop20.options[document.forms[0].ddlTop20.options.selectedIndex].text;return false;")
        End Sub

        ' Method: GenChart
        ' Purpose: generate suite charts now
        Private Sub BindData()
            Dim tblCatDicList As New DataTable
            Dim listItem As New listItem

            Try
                tblCatDicList = objBCDL.GetCatDicList(0)
                If Not tblCatDicList Is Nothing Then
                    If tblCatDicList.Rows.Count > 0 Then
                        ddlTop20.DataSource = objBCDBS.InsertOneRow(tblCatDicList, lblSelectStat.Text)
                        ddlTop20.DataValueField = "ID"
                        ddlTop20.DataTextField = "Name"
                        ddlTop20.DataBind()
                    End If
                Else
                    listItem.Value = "0"
                    listItem.Text = lblSelectStat.Text
                    ddlTop20.Items.Add(listItem)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCDL Is Nothing Then
                objBCDL.Dispose(True)
                objBCDL = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
    End Class
End Namespace