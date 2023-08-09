' Class: WWorkingUpdate
' Puspose: Update working hours
' Creator: Kiemdv
' CreatedDate: 19/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WWorkingUpdate
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblWorkingSchedue As System.Web.UI.WebControls.Label
        Protected WithEvents lblViewSchedue As System.Web.UI.WebControls.Label



        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBSchedule As New clsBSchedule
        Private objBUserLocation As New clsBUserLocation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not IsPostBack Then
                Call BindData()
            End If
            Call BindJS()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(191) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBUserLocation object
            objBUserLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBUserLocation.ConnectionString = Session("ConnectionString")
            objBUserLocation.DBServer = Session("DBServer")
            objBUserLocation.UserID = Session("UserID")
            Call objBUserLocation.Initialize()

            ' Init objBSchedule object
            objBSchedule.InterfaceLanguage = Session("InterfaceLanguage")
            objBSchedule.ConnectionString = Session("ConnectionString")
            objBSchedule.DBServer = Session("DBServer")
            Call objBSchedule.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("Common", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("Private", "<script language = 'javascript' src = '../Js/Policy/WWorkingUpdate.js'></script>")

            txtFromAMH1.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromAMH1','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH1','document.Form1.txtFromAMH1')) { return false; }}")
            txtFromAMH2.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromAMH2','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH2','document.Form1.txtFromAMH2')) { return false; }}")
            txtFromAMH3.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromAMH3','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH3','document.Form1.txtFromAMH3')) { return false; }}")
            txtFromAMH4.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromAMH4','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH4','document.Form1.txtFromAMH4')) { return false; }}")
            txtFromAMH5.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromAMH5','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH5','document.Form1.txtFromAMH5')) { return false; }}")
            txtFromAMH6.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromAMH6','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH6','document.Form1.txtFromAMH6')) { return false; }}")
            txtFromAMH7.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromAMH7','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH7','document.Form1.txtFromAMH7')) { return false; }}")

            txtFromAMM1.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromAMM1','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromAMM2.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromAMM2','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromAMM3.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromAMM3','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromAMM4.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromAMM4','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromAMM5.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromAMM5','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromAMM6.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromAMM6','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromAMM7.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromAMM7','" & ddlLabel.Items(4).Text & "')) return false;")

            txtToAMH1.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToAMH1','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH1','document.Form1.txtFromAMH1')) { return false; }}")
            txtToAMH2.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToAMH2','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH2','document.Form1.txtFromAMH2')) { return false; }}")
            txtToAMH3.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToAMH3','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH3','document.Form1.txtFromAMH3')) { return false; }}")
            txtToAMH4.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToAMH4','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH4','document.Form1.txtFromAMH4')) { return false; }}")
            txtToAMH5.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToAMH5','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH5','document.Form1.txtFromAMH5')) { return false; }}")
            txtToAMH6.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToAMH6','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH6','document.Form1.txtFromAMH6')) { return false; }}")
            txtToAMH7.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToAMH7','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToAMH7','document.Form1.txtFromAMH7')) { return false; }}")

            txtToAMM1.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToAMM1','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToAMM2.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToAMM2','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToAMM3.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToAMM3','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToAMM4.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToAMM4','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToAMM5.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToAMM5','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToAMM6.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToAMM6','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToAMM7.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToAMM7','" & ddlLabel.Items(4).Text & "')) return false;")

            txtFromPMH1.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromPMH1','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (this.value < 13){this.value=13;  if (!Compare('document.Form1.txtToPMH1','document.Form1.txtFromPMH1')) { return false; }}}")
            txtFromPMH2.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromPMH2','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (this.value < 13){this.value=13;  if (!Compare('document.Form1.txtToPMH2','document.Form1.txtFromPMH2')) { return false; }}}")
            txtFromPMH3.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromPMH3','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (this.value < 13){this.value=13;  if (!Compare('document.Form1.txtToPMH3','document.Form1.txtFromPMH3')) { return false; }}}")
            txtFromPMH4.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromPMH4','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (this.value < 13){this.value=13;  if (!Compare('document.Form1.txtToPMH4','document.Form1.txtFromPMH4')) { return false; }}}")
            txtFromPMH5.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromPMH5','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (this.value < 13){this.value=13;  if (!Compare('document.Form1.txtToPMH5','document.Form1.txtFromPMH5')) { return false; }}}")
            txtFromPMH6.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromPMH6','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (this.value < 13){this.value=13;  if (!Compare('document.Form1.txtToPMH6','document.Form1.txtFromPMH6')) { return false; }}}")
            txtFromPMH7.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtFromPMH7','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (this.value < 13){this.value=13;  if (!Compare('document.Form1.txtToPMH7','document.Form1.txtFromPMH7')) { return false; }}}")

            txtFromPMM1.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromPMM1','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromPMM2.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromPMM2','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromPMM3.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromPMM3','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromPMM4.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromPMM4','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromPMM5.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromPMM5','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromPMM6.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromPMM6','" & ddlLabel.Items(4).Text & "')) return false;")
            txtFromPMM7.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtFromPMM7','" & ddlLabel.Items(4).Text & "')) return false;")

            txtToPMH1.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToPMH1','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToPMH1','document.Form1.txtFromPMH1')) { return false; }}")
            txtToPMH2.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToPMH2','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToPMH2','document.Form1.txtFromPMH2')) { return false; }}")
            txtToPMH3.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToPMH3','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToPMH3','document.Form1.txtFromPMH3')) { return false; }}")
            txtToPMH4.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToPMH4','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToPMH4','document.Form1.txtFromPMH4')) { return false; }}")
            txtToPMH5.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToPMH5','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToPMH5','document.Form1.txtFromPMH5')) { return false; }}")
            txtToPMH6.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToPMH6','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToPMH6','document.Form1.txtFromPMH6')) { return false; }}")
            txtToPMH7.Attributes.Add("OnChange", "if (!CheckHour('document.Form1.txtToPMH7','" & ddlLabel.Items(3).Text & "')) { return false; } else { if (!Compare('document.Form1.txtToPMH7','document.Form1.txtFromPMH7')) { return false; }}")

            txtToPMM1.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToPMM1','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToPMM2.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToPMM2','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToPMM3.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToPMM3','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToPMM4.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToPMM4','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToPMM5.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToPMM5','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToPMM6.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToPMM6','" & ddlLabel.Items(4).Text & "')) return false;")
            txtToPMM7.Attributes.Add("OnChange", "if (!CheckMinus('document.Form1.txtToPMM7','" & ddlLabel.Items(4).Text & "')) return false;")

            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
        End Sub

        ' Method: BindData
        ' Purpose: Get list of locations
        Private Sub BindData()
            Dim tblLocation As DataTable

            tblLocation = objBUserLocation.GetUserLocations(2)
            If Not tblLocation Is Nothing AndAlso tblLocation.Rows.Count > 0 Then
                ddlLocation.DataSource = InsertOneRow(tblLocation, ddlLabel.Items(2).Text)

                ddlLocation.DataTextField = "LOCNAME"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
                tblLocation = Nothing
            End If
        End Sub

        ' Event: LoadData
        Private Sub LoadData()
            If ddlLocation.SelectedIndex > 0 Then
                txtFromAMH1.Text = ""
                txtFromAMH2.Text = "07"
                txtFromAMH3.Text = "07"
                txtFromAMH4.Text = "07"
                txtFromAMH5.Text = "07"
                txtFromAMH6.Text = "07"
                txtFromAMH7.Text = "07"

                txtFromAMM1.Text = ""
                txtFromAMM2.Text = "00"
                txtFromAMM3.Text = "00"
                txtFromAMM4.Text = "00"
                txtFromAMM5.Text = "00"
                txtFromAMM6.Text = "00"
                txtFromAMM7.Text = "00"

                txtToAMH1.Text = ""
                txtToAMH2.Text = "11"
                txtToAMH3.Text = "11"
                txtToAMH4.Text = "11"
                txtToAMH5.Text = "11"
                txtToAMH6.Text = "11"
                txtToAMH7.Text = "11"

                txtToAMM1.Text = ""
                txtToAMM2.Text = "00"
                txtToAMM3.Text = "00"
                txtToAMM4.Text = "00"
                txtToAMM5.Text = "00"
                txtToAMM6.Text = "00"
                txtToAMM7.Text = "00"

                txtFromPMH1.Text = ""
                txtFromPMH2.Text = "13"
                txtFromPMH3.Text = "13"
                txtFromPMH4.Text = "13"
                txtFromPMH5.Text = "13"
                txtFromPMH6.Text = "13"
                txtFromPMH7.Text = "13"

                txtFromPMM1.Text = ""
                txtFromPMM2.Text = "00"
                txtFromPMM3.Text = "00"
                txtFromPMM4.Text = "00"
                txtFromPMM5.Text = "00"
                txtFromPMM6.Text = "00"
                txtFromPMM7.Text = "00"

                txtToPMH1.Text = ""
                txtToPMH2.Text = "17"
                txtToPMH3.Text = "17"
                txtToPMH4.Text = "17"
                txtToPMH5.Text = "17"
                txtToPMH6.Text = "17"
                txtToPMH7.Text = "17"

                txtToPMM1.Text = ""
                txtToPMM2.Text = "00"
                txtToPMM3.Text = "00"
                txtToPMM4.Text = "00"
                txtToPMM5.Text = "00"
                txtToPMM6.Text = "00"
                txtToPMM7.Text = "00"

                Dim intCount As Integer
                Dim tblTemp As DataTable

                tblTemp = objBUserLocation.GetUserLocations(2)
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    lstLocation.DataSource = tblTemp

                    lstLocation.DataTextField = "LOCNAME"
                    lstLocation.DataValueField = "ID"
                    lstLocation.DataBind()
                    For intCount = 0 To lstLocation.Items.Count - 1
                        If ddlLocation.SelectedValue = lstLocation.Items(intCount).Value Then
                            lstLocation.Items.RemoveAt(intCount)
                            Exit For
                        End If
                    Next
                    tblTemp = Nothing
                End If
            Else
                Dim ctlItem, ctl As Control
                Dim intCount As Integer
                lstLocation.Items.Clear()

                For intCount = 1 To 7
                    For Each ctlItem In Page.Controls
                        If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                            ' Find each controls in the Form posited on Webpages     
                            For Each ctl In ctlItem.Controls
                                If TypeOf (ctl) Is WebControl Then
                                    If ctl.ID <> "" And ctl.GetType.ToString = "System.Web.UI.WebControls.TextBox" Then
                                        If CType(ctl, TextBox).ID.ToString = "txtFromAMH" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                        If CType(ctl, TextBox).ID.ToString = "txtFromAMM" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                        If CType(ctl, TextBox).ID.ToString = "txtToAMH" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                        If CType(ctl, TextBox).ID.ToString = "txtToAMM" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                        If CType(ctl, TextBox).ID.ToString = "txtFromPMH" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                        If CType(ctl, TextBox).ID.ToString = "txtFromPMM" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                        If CType(ctl, TextBox).ID.ToString = "txtToPMH" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                        If CType(ctl, TextBox).ID.ToString = "txtToPMM" & intCount Then
                                            CType(ctl, TextBox).Text = ""
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next
            End If
        End Sub

        ' Event: ddlLocation_SelectedIndexChanged
        Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
            Dim dtbWorkingTime As New DataTable
            Dim dtrWorkingTime() As DataRow
            Dim tblTemp As DataTable
            Dim intCount, intLstCount As Integer
            Dim ctlItem, ctl As Control

            Call LoadData()
            objBSchedule.LocationID = ddlLocation.SelectedValue
            tblTemp = objBSchedule.GetWorkingTime()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                dtbWorkingTime = tblTemp

                For intCount = 1 To 7
                    dtrWorkingTime = dtbWorkingTime.Select(" WeekDay = " & CStr(intCount))
                    If dtrWorkingTime.Length > 0 Then
                        For Each ctlItem In Page.Controls
                            If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                                ' Find each controls in the Form posited on Webpages     
                                For Each ctl In ctlItem.Controls
                                    If TypeOf (ctl) Is WebControl Then
                                        If ctl.ID <> "" And ctl.GetType.ToString = "System.Web.UI.WebControls.TextBox" Then
                                            If CType(ctl, TextBox).ID.ToString = "txtFromAMH" & intCount Then
                                                CType(ctl, TextBox).Text = Left(dtrWorkingTime(0).Item("Open1"), 2)
                                            End If
                                            If CType(ctl, TextBox).ID.ToString = "txtFromAMM" & intCount Then
                                                CType(ctl, TextBox).Text = Right(dtrWorkingTime(0).Item("Open1"), 2)
                                            End If
                                            If CType(ctl, TextBox).ID.ToString = "txtToAMH" & intCount Then
                                                CType(ctl, TextBox).Text = Left(dtrWorkingTime(0).Item("Close1"), 2)
                                            End If
                                            If CType(ctl, TextBox).ID.ToString = "txtToAMM" & intCount Then
                                                CType(ctl, TextBox).Text = Right(dtrWorkingTime(0).Item("Close1"), 2)
                                            End If
                                            If CType(ctl, TextBox).ID.ToString = "txtFromPMH" & intCount Then
                                                CType(ctl, TextBox).Text = Left(dtrWorkingTime(0).Item("Open2"), 2)
                                            End If
                                            If CType(ctl, TextBox).ID.ToString = "txtFromPMM" & intCount Then
                                                CType(ctl, TextBox).Text = Right(dtrWorkingTime(0).Item("Open2"), 2)
                                            End If
                                            If CType(ctl, TextBox).ID.ToString = "txtToPMH" & intCount Then
                                                CType(ctl, TextBox).Text = Left(dtrWorkingTime(0).Item("Close2"), 2)
                                            End If
                                            If CType(ctl, TextBox).ID.ToString = "txtToPMM" & intCount Then
                                                CType(ctl, TextBox).Text = Right(dtrWorkingTime(0).Item("Close2"), 2)
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                    dtbWorkingTime.Select()
                Next
            End If
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intCount, intLstCount As Integer
            Dim ctlItem, ctl As Control
            Dim strOpen1, strClose1, strOpen2, strClose2 As String

            For intCount = 1 To 7
                strOpen1 = ""
                strClose1 = ""
                strOpen2 = ""
                strClose2 = ""
                For Each ctlItem In Page.Controls
                    If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                        ' Find each controls in the Form posited on Webpages     
                        For Each ctl In ctlItem.Controls
                            If TypeOf (ctl) Is WebControl Then
                                If ctl.ID <> "" And ctl.GetType.ToString = "System.Web.UI.WebControls.TextBox" Then
                                    If CType(ctl, TextBox).ID.ToString = "txtFromAMH" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            strOpen1 = StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                        End If
                                    End If
                                    If CType(ctl, TextBox).ID.ToString = "txtFromAMM" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            If strOpen1 <> "" Then
                                                strOpen1 = strOpen1 & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            Else
                                                strOpen1 = "  " & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            End If
                                        End If
                                    End If
                                    If CType(ctl, TextBox).ID.ToString = "txtToAMH" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            strClose1 = StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                        End If
                                    End If
                                    If CType(ctl, TextBox).ID.ToString = "txtToAMM" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            If strClose1 <> "" Then
                                                strClose1 = strClose1 & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            Else
                                                strClose1 = "  " & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            End If
                                        End If
                                    End If
                                    If CType(ctl, TextBox).ID.ToString = "txtFromPMH" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            strOpen2 = StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                        End If
                                    End If
                                    If CType(ctl, TextBox).ID.ToString = "txtFromPMM" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            If strOpen2 <> "" Then
                                                strOpen2 = strOpen2 & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            Else
                                                strOpen2 = "  " & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            End If
                                        End If
                                    End If
                                    If CType(ctl, TextBox).ID.ToString = "txtToPMH" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            strClose2 = StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                        End If
                                    End If
                                    If CType(ctl, TextBox).ID.ToString = "txtToPMM" & intCount Then
                                        If CType(ctl, TextBox).Text <> "" Then
                                            If strClose2 <> "" Then
                                                strClose2 = strClose2 & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            Else
                                                strClose2 = "  " & StrDup(2 - Len(CType(ctl, TextBox).Text), "0") & CType(ctl, TextBox).Text
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                objBSchedule.LocationID = ddlLocation.SelectedValue
                objBSchedule.WeekDay = intCount
                objBSchedule.Open1 = strOpen1
                objBSchedule.Close1 = strClose1
                objBSchedule.Open2 = strOpen2
                objBSchedule.Close2 = strClose2
                objBSchedule.UpdateWorkingTime()

                For intLstCount = 0 To lstLocation.Items.Count - 1
                    If InStr("," & Request.Form("lstLocation") & ",", "," & lstLocation.Items(intLstCount).Value & ",") > 0 Then
                        objBSchedule.LocationID = lstLocation.Items(intLstCount).Value
                        objBSchedule.WeekDay = intCount
                        objBSchedule.Open1 = strOpen1
                        objBSchedule.Close1 = strClose1
                        objBSchedule.Open2 = strOpen2
                        objBSchedule.Close2 = strClose2
                        objBSchedule.UpdateWorkingTime()
                    End If
                Next
            Next
            ' WriteLog
            Call WriteLog(50, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBSchedule Is Nothing Then
                    objBSchedule.Dispose(True)
                    objBSchedule = Nothing
                End If
                If Not objBUserLocation Is Nothing Then
                    objBUserLocation.Dispose(True)
                    objBUserLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace