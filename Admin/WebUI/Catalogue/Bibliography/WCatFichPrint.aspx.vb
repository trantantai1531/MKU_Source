' Propose: Create fich pattern
' Class: WCatPichPrint
' CreatedDate: 28/4/2004
' Creator: Sondp.
'  Modification history 
'    - 25/02/2005 by Tuanhv: Review

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPichPrint
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
        Private objBCB As New clsBCommonBusiness
        Private objBCommonTemplate As New clsBCommonTemplate
        Private objBLocation As New clsBLocation
        Private objBLibrary As New clsBLibrary

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
                Call InitialThreeArrays()
            End If

        End Sub

        ' Method: Initialize
        ' Purpose: Init all object use form
        Public Sub Initialize()
            ' Init objBCommonTemplate object
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonTemplate.Initialize()

            ' Init objBCommonTemplate object
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.DBServer = Session("DBServer")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()

            ' Init objBCommonTemplate object
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Init objBCommonTemplate object
            objBCB.ConnectionString = Session("ConnectionString")
            objBCB.DBServer = Session("DBServer")
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCB.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As DataTable = Nothing
            Dim lsItem As New ListItem
            Dim blnFound As Boolean = False

            ' Get libraries
            objBLibrary.LibID = 0
            tblTemp = objBLibrary.GetLibrary
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLibrary.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataValueField = "LocID"
                    ddlLibrary.DataBind()
                    blnFound = True
                End If
                tblTemp = Nothing
            End If
            If Not blnFound Then
                lsItem.Value = 0
                lsItem.Text = ddlLabel.Items(2).Text
                ddlLibrary.Items.Add(lsItem)
            End If
            blnFound = False

            ' Get template
            objBCommonTemplate.TemplateType = 15
            tblTemp = objBCommonTemplate.GetTemplate()
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlFicheTemplate.DataSource = tblTemp
                    ddlFicheTemplate.DataTextField = "Title"
                    ddlFicheTemplate.DataValueField = "LocID"
                    ddlFicheTemplate.DataBind()
                    ddlFicheTemplate.Items(0).Selected = True
                End If
                tblTemp = Nothing
            End If

            ' Get ItemType
            tblTemp = objBCB.GetItemTypes

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                    ddlItemType.DataSource = tblTemp
                    ddlItemType.DataTextField = "Typecode"
                    ddlItemType.DataValueField = "LocID"
                    ddlItemType.DataBind()
                    blnFound = True
                End If
                tblTemp = Nothing
            End If

            If Not blnFound Then
                lsItem.Text = ""
                lsItem.Value = 0
                ddlItemType.Items.Add(lsItem)
            End If

            ' Clear form
            txtLocation.Value = ""
            txtFrom.Text = ""
            txtTo.Text = ""
            txtFromCopyNumber.Text = ""
            txtToCopyNumber.Text = ""
            txtCollum.Text = "1"
            txtSpace.Text = "0"
            txtFiche.Text = "10"
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJS", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language='javascript' src='../JS/Bibliography/WCatFichPrint.js'></script>")

            ddlLibrary.Attributes.Add("onchange", "FilterLocation()")
            ddlLocation.Attributes.Add("onchange", "if(this.options.length) {document.forms[0].txtLocation.value=this.value} else {document.forms[0].txtLocation.value='';}")
            btnMakeFiche.Attributes.Add("onclick", "javascript: return CheckAll('" & ddlLabel.Items(3).Text & "');")
        End Sub

        ' Method: InitialThreeArrays
        ' Purpose: Initial 3 java script arrays to suport: when user click on Library so depend on LibraryID program  will select Location(Store) in this Library to display in dropdownlist dllLoc
        Private Sub InitialThreeArrays()
            Dim strScript As String = ""
            Dim tblLoc As DataTable = Nothing
            Dim inti As Integer

            objBLocation.UserID = CInt(Session("UserID"))
            tblLoc = objBLocation.GetLocation
            If Not tblLoc Is Nothing Then
                If tblLoc.Rows.Count > 0 Then
                    'intitialize 3 arrays content LocID, Location, LibraryID
                    strScript = "LocID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "Location=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "LibID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    For inti = 0 To tblLoc.Rows.Count - 1
                        strScript &= "LocID[" & inti & "]=" & tblLoc.Rows(inti).Item("LocID") & ";"
                        strScript &= "Location[" & inti & "]='" & tblLoc.Rows(inti).Item("Symbol") & "';"
                        strScript &= "LibID[" & inti & "]=" & tblLoc.Rows(inti).Item("LibID") & ";"
                    Next
                Else 'intitialize 3 emty arrays
                    strScript = "LocID=new Array(0);"
                    strScript &= "Location=new Array(0);"
                    strScript &= "LibID=new Array(0);"
                End If
            Else 'intitialize 3 emty arrays
                strScript = "LocID=new Array(0);"
                strScript &= "Location=new Array(0);"
                strScript &= "LibID=new Array(0);"
            End If

            Page.RegisterClientScriptBlock("InitialThreeArraysJs", "<script language='javascript'>" & strScript & "</script>")
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
                If Not objBCommonTemplate Is Nothing Then
                    objBCommonTemplate.Dispose(True)
                    objBCommonTemplate = Nothing
                End If
                If Not objBCB Is Nothing Then
                    objBCB.Dispose(True)
                    objBCB = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace