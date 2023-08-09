' class WCopyNumberRemF
' Puspose: Generate copynumber removed
' Creator: Sondp
' CreatedDate: 08/03/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCopyNumRemF
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
        Private objBLoc As New clsBLocation
        Private objBLib As New clsBLibrary
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBT As New clsBTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call InitialThreeArrays()
            If Not Page.IsPostBack Then
                Call BindData()
                Call DisposeSession()
            End If
            ' Must put BindJS method here
            Call BindJS()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(106) Then
                btnPreview.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all need object
        Private Sub Initialize()
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

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            Call objBT.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WAcqFormJs", "<script language='javascript' src='../Js/ACQ/WCopyNumRem.js'></script>")

            ddlLibrary.Attributes.Add("OnChange", "javascript:BindStoreData(this.options[this.selectedIndex].value);return(false);") ' Load Store(s) in this Library in dropdownlist ddlLoc
            ddlStore.Attributes.Add("OnChange", "javascript:document.forms[0].txtStore.value=this.options[this.options.selectedIndex].value;return false;") ' Save LocationID in txtStore 

            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset();return(false);")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfFromDate, txtFromAcquisitionTime, ddlLabel.Items(4).Text)
            SetOnclickCalendar(hrfToDate, txtToAcquisitionTime, ddlLabel.Items(4).Text)
            Me.SetCheckNumber(txtPage, ddlLabel.Items(5).Text, "20")
        End Sub

        ' Method: InitialThreeArrays
        ' Purpose: Initial 3 java script arrays use for load location method
        Public Sub InitialThreeArrays()
            Dim strScript As String
            Dim tblLoc As DataTable
            Dim inti As Integer
            ' Select all locations
            objBLoc.LibID = 0
            objBLib.UserID = Session("UserID")
            tblLoc = objBLoc.GetLocation()

            If Not tblLoc Is Nothing Then
                If tblLoc.Rows.Count > 0 Then
                    ' Init three arrays content ID, Symbol, LibID
                    strScript = "ID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "Symbol=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "LibID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    For inti = 0 To tblLoc.Rows.Count - 1
                        strScript &= "ID[" & inti & "]=" & tblLoc.Rows(inti).Item("ID") & ";"
                        strScript &= "Symbol[" & inti & "]='" & tblLoc.Rows(inti).Item("Symbol") & "';"
                        strScript &= "LibID[" & inti & "]=" & tblLoc.Rows(inti).Item("LibID") & ";"
                    Next
                End If
            End If
            Page.RegisterClientScriptBlock("InitialThreeArraysJs", "<script language='javascript'>" & strScript & "</script>")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTem As New DataTable
            Dim listItem As New listItem
            ' Bind Library
            objBLib.LibID = 0
            objBLib.UserID = Session("UserID")
            tblTem = objBLib.GetLibrary

            If Not tblTem Is Nothing Then
                If tblTem.Rows.Count > 0 Then
                    ddlLibrary.DataSource = InsertOneRow(tblTem, ddlLabel.Items(3).Text)
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataValueField = "ID"
                    ddlLibrary.DataBind()
                Else
                    listItem.Text = ddlLabel.Items(3).Text
                    listItem.Value = 0
                    ddlLibrary.Items.Add(listItem)
                End If
            End If
            tblTem = Nothing
        End Sub

        ' Event: btnPreview_Click
        Private Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            Dim arrTitle(), arrIDs(), strAcqSQL, strIDs As String
            Dim tblIDs As New DataTable
            Dim lngi As Long

            If Not IsNumeric(txtPage.Text) And CInt(txtPage.Text) <= 0 Then
                txtPage.Text = 20
            End If
            objBT.LibID = ddlLibrary.SelectedValue
            If IsNumeric(txtStore.Value) And Not txtStore.Value = 0 Then
                objBT.StoreID = txtStore.Value
            Else
                objBT.StoreID = 0
            End If
            objBT.FromTime = txtFromAcquisitionTime.Text
            objBT.ToTime = txtToAcquisitionTime.Text
            objBT.Order = ddlOrder.SelectedValue
            objBT.By = ddlBy.SelectedValue
            objBT.LiquidCode = txtLiquidCode.Text.Trim
            strAcqSQL = objBT.FormingCopyNumRemSQL

            If Not strAcqSQL & "" = "" Then
                objBCDBS.SQLStatement = strAcqSQL
                tblIDs = objBCDBS.RetrieveItemInfor
                If Not tblIDs Is Nothing Then
                    If tblIDs.Rows.Count > 0 Then
                        ReDim arrIDs(tblIDs.Rows.Count - 1)
                        If CInt(ddlOrder.SelectedValue) = 1 Then
                            ReDim arrTitle(tblIDs.Rows.Count - 1)
                        End If
                        For lngi = 0 To tblIDs.Rows.Count - 1
                            arrIDs(lngi) = tblIDs.Rows(lngi).Item("ID")
                            If CInt(ddlOrder.SelectedValue) = 1 Then
                                arrTitle(lngi) = objBCSP.TheSortOne(objBCSP.TrimSubFieldCodes(tblIDs.Rows(lngi).Item("Content")))
                            End If
                        Next
                        ' Sort Title
                        If CInt(ddlOrder.SelectedValue) = 1 Then
                            objBT.SortData(arrIDs, arrTitle, ddlBy.SelectedValue)
                        End If
                        For lngi = LBound(arrIDs) To UBound(arrIDs)
                            strIDs = strIDs & arrIDs(lngi) & ", "
                        Next
                        If strIDs.Length > 1 Then
                            strIDs = Left(strIDs, Len(strIDs) - 2)
                        End If
                    End If
                End If
                If Not strIDs & "" = "" Then
                    Session("IDs") = strIDs
                    Response.Redirect("WCopyNumRemR.aspx?pagesize=" & txtPage.Text & "&LiquidCode='" & txtLiquidCode.Text & "'")
                Else
                    Call DisposeSession()
                    Call InitialThreeArrays()
                    Page.RegisterClientScriptBlock("NotFoundData1", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                End If
            Else
                Call DisposeSession()
                Call InitialThreeArrays()
                Page.RegisterClientScriptBlock("NotFoundData2", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
            End If
        End Sub

        ' Method: DisposeSession
        ' Purpose: Dispose Session method
        Private Sub DisposeSession()
            If Not Session("IDs") Is Nothing Then
                Session("IDs") = Nothing
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