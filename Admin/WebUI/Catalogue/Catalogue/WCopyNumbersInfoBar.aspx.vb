Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCopyNumbersInfoBar
        Inherits clsWBase

        ' Declare class variables
        Private objBItemCollection As New clsBItemCollection
        Private objBFormingSQL As New clsBFormingSQL
        Private objBCDBS As New clsBCommonDBSystem

        ' Declare module variables
        Private intMinNum As New Integer ' Min ID of item filtered (or not filtered)
        Private intMaxNum As New Integer ' Max ID of item filtered (or not filtered)
        Private intReCordCount As Integer ' Total number of record will be viewed

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call CheckFormPemission()
            Call BindJS()
            ' Warning: Can't change the position of methods sorted 
            If Request("hidUnFilter") = 1 Then
                Session("sqlFilter") = Nothing
                Session("Filter") = Nothing
                Session("arrFilteredItemID") = Nothing
                Session("TotalRecord") = Nothing
                Session("strIDs") = Nothing
            End If

            If Not IsPostBack Then
                SearchItem()
                Call BindData()
                Call BindDataJs()
            End If
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

            ' Init objBFormingSQL object
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            ' Init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
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
            Else 'Tu chuan
                If Not CheckPemission(144) Then
                    If Not CheckPemission(142) Then
                        Call WriteErrorMssg(ddlLabel.Items(9).Text)
                    End If
                End If
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            ' Register the javascript file
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Catalogue/WCopyNumbersInfoBar.js'></script>")
        End Sub

        Private Sub BindDataJs()
            Dim strJVCheckNum As String ' Javascript to check the input is number or not
            ' Check the input is number or not
            strJVCheckNum = "CheckNumBer('document.forms[0].txtReNum','" & ddlLabel.Items(5).Text & "',1); "

            ' The first time loading data
            lblJS.Text = "<Script type='text/javascript'>StartBindData(" & intMinNum & ");</script>"

            ' Add the attributes for the buttons (navigation and create new)
            btnNext.Attributes.Add("OnClick",
                                   "javascript:" & strJVCheckNum & "Next('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "');return false;")
            btnPrev.Attributes.Add("OnClick",
                                   "javascript:" & strJVCheckNum & "Prev('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "');return false;")
            btnFirst.Attributes.Add("Onclick",
                                    "javascript:Home(" & intMinNum & ");return false;")
            btnLast.Attributes.Add("Onclick",
                                   "javascript:End(" & intReCordCount & "," & intMaxNum & ");return false;")
            ' Process the record
            txtReNum.Attributes.Add("OnChange",
                                    "javascript:" & strJVCheckNum & "ChangeRecNum('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "');")
            txtReNum.Attributes.Add("onKeyDown",
                                    "if(event.keyCode == 13 || event.which == 13 ) {ChangeRecNum('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & intReCordCount & "','" & ddlLabel.Items(6).Text & "'); return false;}")
        End Sub

        ' BindData method
        ' Purpose: Bind the data for the first time form loaded
        Private Sub BindData()
            Dim tblItem As DataTable = Session("tblCopyNumberIds")
            If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                txtMaxReNum.Text = tblItem.Rows.Count
                txtReNum.Text = 1
                intReCordCount = CInt(txtMaxReNum.Text)
                intMinNum = 1
                intMaxNum = tblItem.Rows.Count
                ItemID.Value = tblItem.Rows(0).Item(0)
            End If

            If txtMaxReNum.Text = "0" Then
                Call LockControl()
            End If
        End Sub

        ' LockControl method
        Private Sub LockControl()
            txtReNum.Enabled = False
            btnFirst.Enabled = False
            btnNext.Enabled = False
            btnPrev.Enabled = False
            btnLast.Enabled = False
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

        'Filter data and bind it to javascript
        Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
            SearchItem()
            BindData()
            BindDataJs()
        End Sub

        ' SearchItem method. 
        ' Purpose: retrieve the string of IDs after searching for the filterring order
        Private Sub SearchItem()
            Dim arrBool() As String = Nothing
            Dim arrVal() As String = Nothing
            Dim arrField() As String = Nothing
            Dim intk = 0   ' Array index
            Dim sb As New StringBuilder(2048)
            Dim str As String = ""

            If ddlField1.SelectedValue = "BN" Then
                'Try Get Copy Number
                str = Trim(txtField1.Text)
                If str <> "" Then
                    sb.Append("SELECT ID FROM Lib_tblHolding WHERE 1=1 AND CopyNumber LIKE '%").Append(str).Append("%' ")
                Else
                    sb.Append("SELECT ID FROM Lib_tblHolding WHERE 1=1 ")
                End If
            Else
                sb.Append("SELECT ID FROM Lib_tblHolding WHERE 1=1 ")
                If Trim(txtField1.Text) <> "" Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = "AND"
                    arrField(intk) = ddlField1.SelectedValue
                    arrVal(intk) = Trim(txtField1.Text)
                    intk = intk + 1
                End If
                objBFormingSQL.FieldArr = arrField
                objBFormingSQL.ValArr = arrVal
                objBFormingSQL.BoolArr = arrBool
                objBFormingSQL.LibID = clsSession.GlbSite
                str = objBFormingSQL.FormingASQL
                sb.AppendFormat(" AND ItemID IN({0})", If(str = "", " SELECT ID FROM Lib_tblItem ", str))
            End If

            sb.AppendFormat(" AND (LibID={0} OR {0}=0)", clsSession.GlbSite)

            ' Return the sql statement by implement the method FormingASQL
            objBFormingSQL.LibID = clsSession.GlbSite
            objBCDBS.SQLStatement = sb.ToString()
            Session("tblCopyNumberIds") = objBCDBS.RetrieveCopyNumberIds()
        End Sub
    End Class
End Namespace