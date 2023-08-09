' class WACQForm
' Puspose: Genrerate Acquisition Report
' Creator: Sondp
' CreatedDate: 8/3/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.Math
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTypePrint As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblDataTimeWrongType As System.Web.UI.WebControls.Label
        Protected WithEvents lblPageSizeIsNumeric As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBLoc As New clsBLocation
        Private objBLib As New clsBLibrary
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBT As New clsBTemplate
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBFaculty As New clsBFaculty

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call InitialThreeArrays()
            If Not Page.IsPostBack Then
                Call BindData()
                Call DisposeSession()
            End If
            ' Must put BindJS method here
            Call BindJS()
        End Sub

        ' Method: CheckFormPemission
        ' Purpose: Check permission
        Private Sub CheckFormPemission()
            If Not CheckPemission(105) Then
                btnPreview.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Init objBFaculty object
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.ConnectionString = Session("ConnectionString")
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBFaculty.Initialize()

            ' Initialize objBLoc object
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            Call objBLoc.Initialize()

            ' Initialize objBLib object
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            Call objBLib.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            Call objBT.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WCommonJs", "<script type='text/javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WAcqFormJs", "<script type='text/javascript' src='../Js/ACQ/WAcqForm.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            ddlLibrary.Attributes.Add("OnChange", "javascript:BindStoreData(this.options[this.selectedIndex].value);return(false);")
            ddlStore.Attributes.Add("OnChange", "javascript:document.forms[0].txtStore.value=this.value;return(false);")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfFromDate, txtFromAcquisitionTime, ddlLog.Items(3).Text)
            SetOnclickCalendar(hrfToDate, txtToAcquisitionTime, ddlLog.Items(3).Text)
            Me.SetCheckNumber(txtPage, ddlLog.Items(4).Text, "20")

            btnPreview.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLog.Items(3).Text & "','" & ddlLog.Items(3).Text & "','" & ddlLog.Items(4).Text & "'));")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset();return(false);")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemp As New DataTable
            Dim listItem As New ListItem
            ' Bind Library
            objBLib.LibID = clsSession.GlbSite

            objBLib.UserID = Session("UserID")
            tblTemp = objBLib.GetLibrary

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(tblTemp, ddlLog.Items(5).Text)

                    ' Catch errors
                    Call WriteErrorMssg(ddlLog.Items(0).Text, ErrorMsg, ddlLog.Items(1).Text, ErrorCode)
                    ddlLibrary.DataSource = tblTemp
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataValueField = "ID"
                    ddlLibrary.DataBind()
                Else
                    listItem.Text = ddlLog.Items(5).Text
                    listItem.Value = 0
                    ddlLibrary.Items.Add(listItem)
                End If
            End If
            tblTemp = Nothing

            ' Bind Acqusition Template
            objBT.TemplateID = 0
            objBT.TemplateType = 11
            objBT.LibID = clsSession.GlbSite
            tblTemp = objBT.GetTemplate
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlFormal.DataSource = tblTemp
                ddlFormal.DataValueField = "ID"
                ddlFormal.DataTextField = "Title"
                ddlFormal.DataBind()
                ddlFormal.Items(0).Selected = True
            End If
            tblTemp = Nothing

            ' Language dropdownlist
            tblTemp = objBCommonBusiness.GetLanguages
            If tblTemp IsNot Nothing Then
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            Else
                tblTemp = New DataTable()
                tblTemp.Columns.Add(New DataColumn("ID", GetType(Integer)))
                tblTemp.Columns.Add(New DataColumn("Language"))
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            End If
            ddlLanguage.DataSource = tblTemp
            ddlLanguage.DataTextField = "Language"
            ddlLanguage.DataValueField = "ID"
            ddlLanguage.DataBind()
            ddlLanguage.SelectedIndex = 0
            tblTemp = Nothing

            ' ItemType dropdownlist
            tblTemp = objBCommonBusiness.GetItemTypes
            If tblTemp IsNot Nothing Then
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            Else
                tblTemp = New DataTable()
                tblTemp.Columns.Add(New DataColumn("ID", GetType(Integer)))
                tblTemp.Columns.Add(New DataColumn("Type"))
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            End If
            ddlItemType.DataSource = tblTemp
            ddlItemType.DataTextField = "Type"
            ddlItemType.DataValueField = "ID"
            ddlItemType.DataBind()
            ddlItemType.SelectedIndex = 0
            tblTemp = Nothing

            ' AcqSource ddropdownlist
            tblTemp = objBCommonBusiness.GetAcqSources
            If tblTemp IsNot Nothing Then
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            Else
                tblTemp = New DataTable()
                tblTemp.Columns.Add(New DataColumn("ID", GetType(Integer)))
                tblTemp.Columns.Add(New DataColumn("Source"))
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            End If
            ddlAcqSource.DataSource = tblTemp
            ddlAcqSource.DataTextField = "Source"
            ddlAcqSource.DataValueField = "ID"
            ddlAcqSource.DataBind()
            ddlAcqSource.SelectedIndex = 0
            tblTemp = Nothing

            tblTemp = Nothing
            tblTemp = objBFaculty.GetFaculty
            If tblTemp IsNot Nothing Then
                Dim tmpView = tblTemp.DefaultView()
                tmpView.Sort = "Faculty ASC"
                tblTemp = tmpView.ToTable()
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            Else
                tblTemp = New DataTable()
                tblTemp.Columns.Add(New DataColumn("ID", GetType(Integer)))
                tblTemp.Columns.Add(New DataColumn("Faculty"))
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
            End If
            ddlFaculty.DataSource = tblTemp
            ddlFaculty.DataTextField = "Faculty"
            ddlFaculty.DataValueField = "ID"
            ddlFaculty.DataBind()
            ddlFaculty.SelectedIndex = 0
            tblTemp = Nothing

        End Sub

        ' Initial 3 java script arrays use for load location method
        Public Sub InitialThreeArrays()
            Dim strScript As String = ""
            Dim tblLoc As DataTable
            Dim inti As Integer

            ' Select all locations
            objBLoc.LibID = clsSession.GlbSite
            objBLoc.UserID = Session("UserID")
            tblLoc = objBLoc.GetLocation()

            If Not tblLoc Is Nothing AndAlso tblLoc.Rows.Count > 0 Then
                ' Init three arrays content ID, Symbol, LibID
                strScript = "var ID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                strScript &= "var Symbol=new Array(" & tblLoc.Rows.Count - 1 & ");"
                strScript &= "var LibID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                For inti = 0 To tblLoc.Rows.Count - 1
                    strScript &= "ID[" & inti & "]=" & tblLoc.Rows(inti).Item("ID") & ";"
                    strScript &= "Symbol[" & inti & "]='" & tblLoc.Rows(inti).Item("Symbol") & "';"
                    strScript &= "LibID[" & inti & "]=" & tblLoc.Rows(inti).Item("LibID") & ";"
                Next
            End If
            Page.RegisterClientScriptBlock("InitialThreeArraysJs", "<script type='text/javascript'>" & strScript & "</script>")
        End Sub

        ' Event: btnPreview_Click
        ' Purpose: preview
        Private Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            Dim strAcqSQL As String
            Dim tblData As New DataTable
            Dim collAcq As New Collection
            Dim arrItemIDs() As String
            Dim lngi As Long
            Dim intk As Integer
            intk = 0
            strAcqSQL = ""
            ReDim arrItemIDs(0)

            ' Init properties objBT
            objBT.LibID = ddlLibrary.SelectedValue
            If IsNumeric(txtStore.Value) Then
                objBT.StoreID = txtStore.Value
            Else
                objBT.StoreID = 0
            End If

            objBT.FromDKCB = txtFromDKCB.Text.Trim
            objBT.ToDKCB = txtToDKCB.Text.Trim
            objBT.FromTime = txtFromAcquisitionTime.Text.Trim
            objBT.ToTime = txtToAcquisitionTime.Text.Trim
            objBT.Formal = ddlFormal.SelectedValue
            objBT.Order = ddlOrder.SelectedValue
            objBT.By = ddlBy.SelectedValue
            objBT.DDC = ddlDDC.SelectedValue
            objBT.Cataloguer = txtCataloguer.Text.Trim()
            objBT.Sh = txtSH.Text.Trim()
            objBT.Keyword = txtKeyword.Text.Trim()
            objBT.PONumber = txtPONumber.Text.Trim()
            objBT.ItemTypeID = ddlItemType.SelectedValue
            objBT.AcqSourceID = ddlAcqSource.SelectedValue
            objBT.LanguageID = ddlLanguage.SelectedValue
            objBT.Faculty = ddlFaculty.SelectedValue
            strAcqSQL = objBT.FormmingAcqSQL

            If Not strAcqSQL & "" = "" Then
                objBCDBS.SQLStatement = strAcqSQL
                tblData = objBCDBS.RetrieveItemInfor
                If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                    If ddlOrder.SelectedValue = 1 Then
                        tblData = objBCDBS.SortTable(tblData, "Content", 1 - ddlBy.SelectedValue)
                    End If
                    ReDim arrItemIDs(tblData.Rows.Count - 1)
                    Session("CountIDs") = tblData.Rows.Count - 1
                    For lngi = 0 To tblData.Rows.Count - 1
                        arrItemIDs(lngi) = tblData.Rows(lngi).Item("ID")
                    Next
                End If
            End If
            'If UBound(arrItemIDs) > 0 Then
            If arrItemIDs.Length > 0 Then
                InitCollecData(collAcq)
                collAcq.Add(Math.Ceiling((UBound(arrItemIDs) + 1) / CInt(txtPage.Text.Trim)), "maxpage")
                Session("collAcq") = collAcq
                Session("IDs") = arrItemIDs
                Response.Redirect("WACQFrame.aspx")
            Else
                Page.RegisterClientScriptBlock("NotFoundJs", "<script type='text/javascript'>alert('" & ddlLog.Items(6).Text & "');</script>")
                Call DisposeSession()
            End If
        End Sub

        ' Method: InitCollecData
        ' Purpose: Initialize collection data method
        Private Sub InitCollecData(ByRef collAcq As Collection)
            Dim inti As Integer
            ' For Header, Footer, Collums Title of report
            For inti = 0 To ddlData.Items.Count - 1
                collAcq.Add(ddlData.Items(inti).Text, ddlData.Items(inti).Value)
            Next
            ' For control
            collAcq.Add(ddlFormal.SelectedValue, "formal")
            collAcq.Add(txtPage.Text, "pagesize")
        End Sub

        ' Method: DisposeSession
        ' Purpose: Dispose Session method
        Private Sub DisposeSession()
            If Not Session("IDs") Is Nothing Then
                Session("IDs") = Nothing
            End If
            If Not Session("collAcq") Is Nothing Then
                Session("collAcq") = Nothing
            End If
        End Sub

        ' Method: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBLoc Is Nothing Then
                objBLoc.Dispose(True)
                objBLoc = Nothing
            End If
            If Not objBLib Is Nothing Then
                objBLib.Dispose(True)
                objBLib = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
            If Not objBCSP Is Nothing Then
                objBCSP.Dispose(True)
                objBCSP = Nothing
            End If
        End Sub
    End Class
End Namespace