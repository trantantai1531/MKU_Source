Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckItemTitle
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
        Private objBItemCollection As New clsBItemCollection
        Private objBFormingSQL As New clsBFormingSQL
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            Call CheckTitle()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()

            'Init objBFormingSQL object
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            'Init objBItemCollection object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            'Init objBItemCollection object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' CheckTitle method
        ' Purpose: Check existing item depending on it's title 
        Private Sub CheckTitle()
            Dim BoolArr()
            Dim FieldArr()
            Dim ValArr()
            Dim dtvItem As DataView
            Dim intk As Integer = 0
            Dim strTitle As String
            Dim strJavascripts As String = ""
            Dim strTitles As String = ""
            Dim strItemIDs As String = ""
            Dim strSQL As String
            Dim tblItem As DataTable
            Dim intCountItem As Integer
            Dim intCount As Integer
            Dim intIndex As Integer
            Dim arrItemVal()
            Dim strLabel1 As String = ddlLabel.Items(2).Text
            Dim strLabel2 As String = ddlLabel.Items(3).Text

            ' Title
            strTitle = Request("Value")
            If strTitle <> "" Then
                ReDim Preserve BoolArr(intk)
                ReDim Preserve FieldArr(intk)
                ReDim Preserve ValArr(intk)
                BoolArr(intk) = "AND"
                FieldArr(intk) = "TI"
                ValArr(intk) = strTitle
                intk = intk + 1
            End If

            ' Form the sql string and get Items
            objBFormingSQL.BoolArr = BoolArr
            objBFormingSQL.FieldArr = FieldArr
            objBFormingSQL.ValArr = ValArr
            strSQL = objBFormingSQL.FormingASQL()
            objBCDBS.SQLStatement = strSQL
            tblItem = objBCDBS.RetrieveItemInfor()
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCDBS.ErrorMsg, ddlLabel.Items(1).Text, objBCDBS.ErrorCode)

            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    ' Candidate the range of item (100)
                    If tblItem.Rows.Count > 100 Then
                        intCountItem = 99
                    Else
                        intCountItem = tblItem.Rows.Count - 1
                    End If

                    ' Get the item ID string and each item id to add to the Item ID array
                    For intCount = 0 To intCountItem
                        strItemIDs = strItemIDs & tblItem.Rows(intCount).Item("ID") & ", "
                    Next

                    If Len(strItemIDs) > 2 Then
                        strItemIDs = Left(strItemIDs, Len(strItemIDs) - 2)
                    End If

                    ' Get the details information of items
                    objBItemCollection.ItemIDs = strItemIDs
                    tblItem = objBItemCollection.GetAvailableItems

                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

                    ' get titles
                    If Not tblItem Is Nothing Then
                        If tblItem.Rows.Count > 0 Then
                            dtvItem = tblItem.DefaultView
                            dtvItem.RowFilter = "FieldCode = 245"
                            If dtvItem.Count > 0 Then
                                For intIndex = 0 To dtvItem.Count - 1
                                    If Not IsDBNull(dtvItem.Item(intIndex).Item("Content")) Then
                                        Call objBCSP.ParseField("$a", Replace(dtvItem.Item(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)

                                        ' Write error
                                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCSP.ErrorMsg, ddlLabel.Items(1).Text, objBCSP.ErrorCode)

                                        If Not arrItemVal(0) = "" Then
                                            strTitles = strTitles & "- " & arrItemVal(0) & "\n"
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If

                    strTitles = Replace(strTitles, """", "\""")
                    strJavascripts = strJavascripts & "if (confirm('" & strLabel1 & "\n\n" & strTitles & "\n" & strLabel2 & "')) {"
                    strJavascripts = strJavascripts & "OpenWindow('WCheckItemResult.aspx?FieldCode=245&ItemIDs=" & strItemIDs & "','WChekItemTitleWin',620,400,100,100);}"
                    Page.RegisterClientScriptBlock("Confirm", "<script language = 'javascript'>" & strJavascripts & "</script>")
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
    