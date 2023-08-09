Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WReUseRec
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
        Private objBIC As New clsBItemCollection
        Private objBCSP As New clsBCommonStringProc

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call LoadToCataForm()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBIC object
            objBIC.DBServer = Session("DBServer")
            objBIC.ConnectionString = Session("ConnectionString")
            objBIC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBIC.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCSP.Initialize()
        End Sub

        ' Method: BindJavascript
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ReUseRecJs", "<script language='javascript' src='../Js/ACQ/WReUseRec.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Method: LoadToCataForm
        ' Purpose: reload data to opener form
        Sub LoadToCataForm()
            Dim tblItems As New DataTable
            Dim strTitle As String = ""
            Dim strAuthor As String = ""
            Dim strAuthorcollective As String = ""
            Dim strPublisher As String = ""
            Dim strPublishYear As String = ""
            Dim strPublishWhere As String = ""
            Dim strPublishOrder As String = ""
            Dim strISSN As String = ""
            Dim strISBN As String = ""
            Dim strLangauge As String = ""
            Dim strDDC As String = ""
            Dim strSumPage As String = ""
            Dim objRec As Object
            Dim strJS As String = ""
            Dim str245 As String = ""
            Dim str245_b As String = ""
            Dim str245_b_ss As String = ""
            Dim str245_b_pd As String = ""
            Dim str245_n As String = ""
            Dim str245_p As String = ""
            Dim str245_c As String = ""
            Dim str300_a As String = ""
            Dim str300_b As String = ""
            Dim str300_c As String = ""
            Dim str300_e As String = ""
            Dim intAcqSourceID As Integer = 0
            Dim intLoanTypeID As Integer = 0
            Dim strAdditionalBy As String = ""
            Dim strItemTypeID As String = ""

            If Trim(Request.QueryString("ItemID") & "") <> "" Then
                objBIC.ItemIDs = Trim(Request.QueryString("ItemID"))
                tblItems = objBIC.GetItemDetailInfor()
                If Not tblItems Is Nothing AndAlso tblItems.Rows.Count > 0 Then
                    ' Title
                    tblItems.DefaultView.RowFilter = "FieldCode ='245'"
                    If tblItems.DefaultView.Count > 0 Then

                        objBCSP.ParseField("$a,$b,$c,$n,$p", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strTitle = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                        If objRec(1) & "" <> "" Then
                            str245_b = objBCSP.GEntryTrim(Replace(objRec(1), "'", "\'"))
                            If str245_b.IndexOf(":") > 0 Then
                                str245_b_ss = Left(str245_b, str245_b.IndexOf(":") - 1)
                                str245_b_pd = Right(str245_b, Len(str245_b) - str245_b.IndexOf(":") - 1)
                            Else
                                str245 = tblItems.DefaultView(0).Item("Content")
                                If str245.IndexOf("=$b") > 0 Then
                                    str245_b_ss = str245_b
                                Else
                                    str245_b_pd = str245_b
                                End If
                            End If
                        End If
                        If objRec(2) & "" <> "" Then
                            str245_c = objBCSP.GEntryTrim(Replace(objRec(2), "'", "\'"))
                        End If
                        If objRec(3) & "" <> "" Then
                            str245_n = objBCSP.GEntryTrim(Replace(objRec(3), "'", "\'"))
                        End If
                        If objRec(4) & "" <> "" Then
                            str245_p = objBCSP.GEntryTrim(Replace(objRec(4), "'", "\'"))
                        End If
                    End If

                    ' Author
                    tblItems.DefaultView.RowFilter = "FieldCode ='100'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strAuthor = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                    End If

                    ' Author collective
                    tblItems.DefaultView.RowFilter = "FieldCode ='110'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strAuthorcollective = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                    End If

                    ' ISSN
                    tblItems.DefaultView.RowFilter = "FieldCode ='022'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strISSN = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                    End If

                    ' ISBN
                    tblItems.DefaultView.RowFilter = "FieldCode ='020'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strISBN = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                    End If

                    ' DDC
                    tblItems.DefaultView.RowFilter = "FieldCode ='082'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strDDC = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                    End If

                    ' Langauge
                    tblItems.DefaultView.RowFilter = "FieldCode ='041'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strLangauge = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                    End If

                    ' Publisher,Year,Where
                    tblItems.DefaultView.RowFilter = "FieldCode ='260'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a,$b,$c", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            strPublishWhere = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                        End If
                        If objRec(1) & "" <> "" Then
                            strPublisher = objBCSP.GEntryTrim(Replace(objRec(1), "'", "\'"))
                        End If
                        If objRec(2) & "" <> "" Then
                            strPublishYear = objBCSP.GEntryTrim(Replace(objRec(2), "'", "\'"))
                        End If
                    End If

                    ' PublisherOrder
                    tblItems.DefaultView.RowFilter = "FieldCode ='250'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If Not IsDBNull(objRec(0)) Then
                            strPublishOrder = Replace(objRec(0), "'", "\'")
                        End If
                    End If
                    '300
                    tblItems.DefaultView.RowFilter = "FieldCode ='300'"
                    If tblItems.DefaultView.Count > 0 Then
                        objBCSP.ParseField("$a,$b,$c,$e", tblItems.DefaultView(0).Item("Content"), "nc", objRec)
                        If objRec(0) & "" <> "" Then
                            str300_a = Replace(objRec(0), "'", "\'")
                            str300_a = Left(str300_a, Len(str300_a) - 1)
                        End If
                        If objRec(1) & "" <> "" Then
                            str300_b = Replace(objRec(1), "'", "\'")
                            str300_b = Left(str300_b, Len(str300_b) - 1)
                        End If
                        If objRec(2) & "" <> "" Then
                            str300_c = Replace(objRec(2), "'", "\'")
                            str300_c = Left(str300_c, Len(str300_c) - 1)
                        End If
                        If objRec(3) & "" <> "" Then
                            str300_e = Replace(objRec(3), "'", "\'")
                        End If
                    End If
                    ' AcqSourceID
                    tblItems.DefaultView.RowFilter = "FieldCode ='AcqSourceID'"
                    If tblItems.DefaultView.Count > 0 Then
                        intAcqSourceID = tblItems.DefaultView(0).Item("Content") & ""
                    End If
                    ' LoanTypeID
                    tblItems.DefaultView.RowFilter = "FieldCode ='LoanTypeID'"
                    If tblItems.DefaultView.Count > 0 Then
                        intLoanTypeID = tblItems.DefaultView(0).Item("Content") & ""
                    End If
                    ' AdditionalBy
                    tblItems.DefaultView.RowFilter = "FieldCode ='AdditionalBy'"
                    If tblItems.DefaultView.Count > 0 Then
                        strAdditionalBy = tblItems.DefaultView(0).Item("Content") & ""
                    End If
                    ' ItemTypeID
                    tblItems.DefaultView.RowFilter = "FieldCode ='ItemTypeID'"
                    If tblItems.DefaultView.Count > 0 Then
                        strItemTypeID = tblItems.DefaultView(0).Item("Content") & ""
                    End If

                    ' Title
                    strJS = "parent.mainacq.document.forms[0].txt245_a.value='" & strTitle & "';"
                    ' Author
                    strJS = strJS & "parent.mainacq.document.forms[0].txt100_a.value='" & strAuthor & "';"
                    ' Author collective
                    strJS = strJS & "parent.mainacq.document.forms[0].txt110_a.value='" & strAuthorcollective & "';"
                    ' ISBN
                    strJS = strJS & "parent.mainacq.document.forms[0].txt020_a.value='" & strISBN & "';"
                    'ISSN
                    strJS = strJS & "parent.mainacq.document.forms[0].txt022_a.value='" & strISSN & "';"
                    'DDC
                    strJS = strJS & "parent.mainacq.document.forms[0].txt082_a.value='" & strDDC & "';"
                    'Langauge
                    strJS = strJS & "parent.mainacq.document.forms[0].txt041_a.value='" & strLangauge & "';"
                    'Publisher
                    strJS = strJS & "parent.mainacq.document.forms[0].txt260_b.value='" & strPublisher & "';"
                    'PublishYear
                    strJS = strJS & "parent.mainacq.document.forms[0].txt260_c.value='" & strPublishYear & "';"
                    'PublishOrder
                    strJS = strJS & "parent.mainacq.document.forms[0].txt250_a.value='" & strPublishOrder & "';"
                    'PublishWhere
                    strJS = strJS & "parent.mainacq.document.forms[0].txt260_a.value='" & strPublishWhere & "';"
                    '245_b_ss
                    strJS = strJS & "parent.mainacq.document.forms[0].txt245_b_ss.value='" & str245_b_ss & "';"
                    '245_b_pd
                    strJS = strJS & "parent.mainacq.document.forms[0].txt245_b_pd.value='" & str245_b_pd & "';"
                    '245_c
                    strJS = strJS & "parent.mainacq.document.forms[0].txt245_c.value='" & str245_c & "';"
                    '245_n
                    strJS = strJS & "parent.mainacq.document.forms[0].txt245_n.value='" & str245_n & "';"
                    '245_p
                    strJS = strJS & "parent.mainacq.document.forms[0].txt245_p.value='" & str245_p & "';"
                    '300_a
                    strJS = strJS & "parent.mainacq.document.forms[0].txt300_a.value='" & str300_a & "';"
                    '300_b
                    strJS = strJS & "parent.mainacq.document.forms[0].txt300_b.value='" & str300_b & "';"
                    '300_c
                    strJS = strJS & "parent.mainacq.document.forms[0].txt300_c.value='" & str300_c & "';"
                    '300_e
                    strJS = strJS & "parent.mainacq.document.forms[0].txt300_e.value='" & str300_e & "';"
                    'ddlItemType
                    strJS = strJS & "UpgradeDDL(parent.mainacq.document.forms[0].ddlItemType,'" & strItemTypeID & "');"
                    'ddlLoanType
                    strJS = strJS & "UpgradeDDL(parent.mainacq.document.forms[0].ddlLoanType," & intLoanTypeID & ");"
                    'ddlAcqSource
                    strJS = strJS & "UpgradeDDL(parent.mainacq.document.forms[0].ddlAcqSource," & intAcqSourceID & ");"
                    'AdditionalBy
                    strJS = strJS & "parent.mainacq.document.forms[0].txtAdditionalBy.value='" & strAdditionalBy & "';"

                    ' Reload opener
                    Page.RegisterClientScriptBlock("LoadBackJs", "<script language='javascript'>" & strJS & "</script>")
                End If
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBIC Is Nothing Then
                    objBIC.Dispose(True)
                    objBIC = Nothing
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