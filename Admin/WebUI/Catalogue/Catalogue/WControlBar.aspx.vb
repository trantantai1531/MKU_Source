Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WControlBar
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtMinNum As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare class variables
        Private objBItemCollection As New clsBItemCollection

        ' Declare module variables
        Private intMinNum As New Integer ' Min ID of item filtered (or not filtered)
        Private intMaxNum As New Integer ' Max ID of item filtered (or not filtered)
        Private intReCordCount As Integer ' Total number of record will be viewed
        Private tblItemID As New DataTable ' DataTable variable

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Warning: Can't change the position of methods sorted 
            If Request("hidUnFilter") = 1 Then
                Session("sqlFilter") = Nothing
                Session("Filter") = Nothing
                Session("arrFilteredItemID") = Nothing
                Session("TotalRecord") = Nothing
                Session("strIDs") = Nothing
            End If
            Call Initialize()
            Call CheckFormPemission()
            Call BindDropDownList()
            Call BindData()
            Call BindJS()
        End Sub

        ' Initialize method
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            If IsNumeric(Request("Authority")) Then
                Session("IsAuthority") = CInt(Request("Authority"))
            Else
                If Not IsNumeric(Session("IsAuthority")) Then
                    Session("IsAuthority") = 0
                End If
            End If

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Session("IsAuthority") = 0 Then 'Thu muc
                If Not CheckPemission(5) Then
                    If Not CheckPemission(3) Then
                        Call WriteErrorMssg(ddlLabel.Items(9).Text)
                    End If
                End If
                If Not CheckPemission(3) Then
                    btnModify.Enabled = False
                End If
                If Not CheckPemission(2) Then
                    btnReuse.Enabled = False
                End If
                If Not CheckPemission(4) Then
                    btnDelete.Enabled = False
                End If
            Else 'Tu chuan
                If Not CheckPemission(144) Then
                    If Not CheckPemission(142) Then
                        Call WriteErrorMssg(ddlLabel.Items(9).Text)
                    End If
                End If
                If Not CheckPemission(142) Then
                    btnModify.Enabled = False
                End If
                If Not CheckPemission(141) Then
                    btnReuse.Enabled = False
                End If
                If Not CheckPemission(143) Then
                    btnDelete.Enabled = False
                End If
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Dim strJVCheckNum As String ' Javascript to check the input is number or not

            ' Register the javascript file
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Catalogue/WControlBar.js'></script>")

            ' Check the input is number or not
            strJVCheckNum = "CheckNumBer('document.forms[0].txtReNum','" & ddlLabel.Items(5).Text & "',1); "

            ' The first time loading data
            If Not Request("ID") & "" = "" Then
                intMinNum = CInt(Request("ID"))
                lblJS.Text = "<Script language='JavaScript'>StartBindData(" & intMinNum & ");</script>"
            Else
                If Not Request("CurrentRec") & "" = "" Then
                    lblJS.Text = "<Script language='JavaScript'>StartBindData(" & Request("CurrentRec") & ");</script>"
                Else
                    lblJS.Text = "<Script language='JavaScript'>StartBindData(" & intMinNum & ");</script>"
                End If
            End If
            ' Page.RegisterClientScriptBlock("OpenPage", "<Script language='JavaScript'>StartBindData(" & intMinNum & ");</script>")


            ' Add the attributes for the buttons (navigation and create new)
            btnNext.Attributes.Add("OnClick", "javascript:" & strJVCheckNum & "Next('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "');return false;")
            btnPrev.Attributes.Add("OnClick", "javascript:" & strJVCheckNum & "Prev('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "');return false;")
            btnFirst.Attributes.Add("Onclick", "javascript:Home(" & intMinNum & ");return false;")
            btnLast.Attributes.Add("Onclick", "javascript:End(" & intReCordCount & "," & intMaxNum & ");return false;")
            btnDelete.Attributes.Add("OnClick", "javascript:DeleteRecord(); return false;")
            btnCreateNew.Attributes.Add("OnClick", "javascript:OpenCreateNewForm(); return false;")

            ' Filter the records
            If Session("IsAuthority") = 0 Then
                btnFilter.Attributes.Add("Onclick", "javascript:parent.Workform.location.href = 'WUnifilter.aspx?strFilterView=Single'; return false;")
            Else
                btnFilter.Attributes.Add("Onclick", "javascript:parent.Workform.location.href = 'WFilterAuthority.aspx'; return false;")
            End If

            ' Process the record
            btnModify.Attributes.Add("OnClick", "javascript:ChangeToModifyPage(); return false;")
            btnReuse.Attributes.Add("OnClick", "javascript:ChangeToReusePage(); return false;")
            btnDelete.Attributes.Add("OnClick", "javascript:DeleteRecord(); return false;")
            txtReNum.Attributes.Add("OnChange", "javascript:" & strJVCheckNum & "ChangeRecNum('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "');")
            txtReNum.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) {ChangeRecNum('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "'); return false;}")
            ddlView.Attributes.Add("OnChange", "javascript:ChangeRecordView(); return false;")
            btnCancelFil.Attributes.Add("OnClick", "javascript:document.forms[0].hidUnFilter.value='1'; document.forms[0].submit();")
        End Sub

        ' BindData method
        ' Purpose: Bind the data for the first time form loaded
        Private Sub BindData()
            Dim intTemp As Integer
            Dim tblItem As New DataTable

            hidIDs.Value = ""

            If Not Request("CurrentRec") = "" Then
                txtReNum.Text = CInt(Request("CurrentRec"))
            Else
                txtReNum.Text = 1
            End If

            ' Not filter
            ' Modify by lent 9-2-2007
            If Session("Filter") <> 1 Then
                objBItemCollection.TypeItem = 0
                objBItemCollection.LibID = clsSession.GlbSite
                tblItemID = objBItemCollection.GetRangeItemID
                Call WriteErrorMssg(ddlLabel.Items(8).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(7).Text, objBItemCollection.ErrorCode)

                If Not tblItemID Is Nothing AndAlso tblItemID.Rows.Count > 0 Then
                    txtMaxReNum.Text = tblItemID.Rows(0).Item("Total")
                    Page.RegisterClientScriptBlock("LoadTotal", "<script language='javascript'>parent.Menu.document.forms[0].txtTotalItem.value=" & tblItemID.Rows(0).Item("Total") & "</script>")
                    intReCordCount = CInt(txtMaxReNum.Text)
                    intMinNum = 1
                    intMaxNum = tblItemID.Rows(0).Item("Total")
                    ItemID.Value = tblItemID.Rows(0).Item("MinID")
                End If
            Else   ' Filtered

                intReCordCount = Session("TotalRecord")
                If intReCordCount <= 5000 Then
                    hidIDs.Value = Session("strIDs")
                End If
                txtMaxReNum.Text = Session("TotalRecord")
                intMinNum = 1
                intMaxNum = Session("TotalRecord")
                ItemID.Value = 1
                'End If
            End If
            If txtMaxReNum.Text = "0" Then
                Call LockControl()
            End If
        End Sub

        ' LockControl method
        Private Sub LockControl()
            txtReNum.Enabled = False
            btnCancelFil.Visible = False
            btnFilter.Enabled = False
            btnCreateNew.Enabled = False
            btnDelete.Visible = False
            btnFirst.Enabled = False
            btnNext.Enabled = False
            btnPrev.Enabled = False
            btnLast.Enabled = False
            btnModify.Enabled = False
            btnReuse.Enabled = False
            ddlView.Enabled = False
        End Sub

        ' BindDropDownList method
        ' Purpose: Add new items for the drop down list if data is non - Authority
        Private Sub BindDropDownList()
            ' Add new items for the drop down list(Non_authority data)
            If Session("IsAuthority") = 0 Then
                If Not Page.IsPostBack Then
                    ddlView.Items.Add("XML (tagged)")
                    ddlView.Items.Add("XML (DCMI)")
                    ddlView.Items.Add("ISBD")
                    ddlView.Items.Add("Catalog Card")
                End If
            End If
        End Sub

        ' Page_Unload event: Unload the page and release the methods
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release the methods
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace