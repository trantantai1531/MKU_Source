' Class: WStatLocationTaskbar
' Puspose: Create statistic by location
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review 

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatLocationTaskbar
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
        Private objBLib As New clsBLibrary

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Intialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all need objects
        Private Sub Intialize()
            ' Intialize objBLib object
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.ConnectionString = Session("ConnectionString")
            objBLib.DBServer = Session("DBServer")
            Call objBLib.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatLocationJs", "<script language='javascript' src='../Js/Statistic/WStatLocation.js'></script>")

            btnBack.Attributes.Add("OnClick", "BackToStat();return(false);")
            btnStatistic.Attributes.Add("OnClick", "SendLibrary();return(false);")
        End Sub

        ' Method: BindData
        ' Purpose: get list of library
        Private Sub BindData()
            Dim tblLib As New DataTable
            Dim listItem As New listItem
            objBLib.LibID = 0
            tblLib = objBLib.GetLibrary
            If Not tblLib Is Nothing Then
                If tblLib.Rows.Count > 0 Then
                    ddlLocation.DataSource = InsertOneRow(tblLib, ddlLabel.Items(2).Text)
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataTextField = "Code"
                    ddlLocation.DataBind()
                Else
                    listItem.Text = ddlLabel.Items(3).Text
                    listItem.Value = 0
                    ddlLocation.Items.Add(listItem)
                End If
            Else
                listItem.Text = ddlLabel.Items(3).Text
                listItem.Value = 0
                ddlLocation.Items.Add(listItem)
            End If
            tblLib = Nothing
        End Sub

        ' Event: Page_Unload
        ' Purpose: release all objects
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBLib Is Nothing Then
                objBLib.Dispose(True)
                objBLib = Nothing
            End If
        End Sub
    End Class
End Namespace