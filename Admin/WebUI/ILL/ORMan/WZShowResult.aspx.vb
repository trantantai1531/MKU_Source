' Class: WZShowResult
' Puspose: Show ZSearch result
' Creator: Oanhtn
' CreatedDate: 28/03/2004
' Modification history:
' Convert to serial by Tuanhv
'   Date : 28/09/2004.
' Tuanhv,Lent
'   Date : 12/10/2004.
'   Changer: ShowResult

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.ILL
    Public Class WZShowResult
        Inherits clsWBase
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents lblFound As System.Web.UI.WebControls.Label
        Protected WithEvents lblSumrec As System.Web.UI.WebControls.Label
        Protected WithEvents lblRec As System.Web.UI.WebControls.Label
        Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
        Protected WithEvents lblNext As System.Web.UI.WebControls.Label
        Protected WithEvents txtStart As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnView As System.Web.UI.WebControls.Button
        Protected WithEvents dtgShowResult As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ddlFieldName1 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtFieldValue1 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlFieldName2 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtFieldValue2 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlFieldName3 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtFieldValue3 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlOperator2 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlOperator3 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblForm As System.Web.UI.WebControls.Label
        Protected WithEvents ddlForm As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtImportedID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblMainTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblzServer As System.Web.UI.WebControls.Label
        Protected WithEvents txtzServer As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkZServerList As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblZPort As System.Web.UI.WebControls.Label
        Protected WithEvents txtZPort As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblZDatabase As System.Web.UI.WebControls.Label
        Protected WithEvents txtZDatabase As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblName As System.Web.UI.WebControls.Label
        Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblPass As System.Web.UI.WebControls.Label
        Protected WithEvents txtPass As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblComment As System.Web.UI.WebControls.Label
        Protected WithEvents optNotImport As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optOverlay As System.Web.UI.WebControls.RadioButton
        Protected WithEvents lblSubTitle As System.Web.UI.WebControls.Label
        Protected WithEvents chkVietUSMARC As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblDisplay As System.Web.UI.WebControls.Label
        Protected WithEvents optMARC As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optISBN As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optSimple As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optISO As System.Web.UI.WebControls.RadioButton
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnReset As System.Web.UI.WebControls.Button
        Protected WithEvents lblAuthor As System.Web.UI.WebControls.Label
        Protected WithEvents lblOtherInfor As System.Web.UI.WebControls.Label
        Protected WithEvents lblPublisher As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lbImport As System.Web.UI.WebControls.Label

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objWCommon As New clsWCommon
        Private objBZImport As New clsBZ3950
        Private objBInput As New clsBInput
        Private objBCommon As New clsBCommonStringProc

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            Call BindData()
            Call ProcessZQuery()
        End Sub

        ' Initialize method
        ' Purpose: Init all objects
        Private Sub Initialize()
            ' Init objBCommon object 
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.DBServer = Session("DBServer")
            objBCommon.ConnectionString = Session("ConnectionString")
            Call objBCommon.Initialize()

            ' Init objWCommon object
            Call objWCommon.Initalize()
            Request.ContentEncoding = objWCommon.ContentEncoding

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBZImport object
            objBZImport.InterfaceLanguage = Session("InterfaceLanguage")
            objBZImport.DBServer = Session("DBServer")
            objBZImport.ConnectionString = Session("ConnectionString")
            Call objBZImport.Initialize()
        End Sub


        ' BindJavascript method
        ' Include all neccessary javascript function
        Public Sub BindJavascript()
            Page.RegisterClientScriptBlock("WZFindJs", "<script language = 'javascript' src = '../Js/ORMan/WZShowResult.js'></script>")
        End Sub


        ' BindData method
        ' Purpose: create Form dropdownlist
        Public Sub BindData()
            txtImportedID.Value = ""
            Try
                ddlForm.DataSource = objBZImport.GetForms
                ddlForm.DataTextField = "Name"
                ddlForm.DataValueField = "ID"
                ddlForm.DataBind()
            Finally
            End Try
            If Not Page.IsPostBack Then
                If UCase(CStr(Request("chkVietUSMARC") & "")) = "ON" Then
                    Session("VietUSMARC") = True
                Else
                    Session("VietUSMARC") = False
                End If
                If Not Request("txtZServer") = "" Then
                    Session("zServer") = Request("txtZServer")
                End If
                If Not Request("txtzPort") = "" Then
                    Session("zPort") = Request("txtzPort")
                End If
                If Not Request("txtzDatabase") = "" Then
                    Session("zDatabase") = Request("txtzDatabase")
                End If
                If Not Request("ddlFieldName1") = "" Then
                    Session("FieldName1") = Request("ddlFieldName1")
                End If
                If Not Request("ddlFieldName2") = "" Then
                    Session("FieldName2") = Request("ddlFieldName2")
                End If
                If Not Request("ddlFieldName3") = "" Then
                    Session("FieldName3") = Request("ddlFieldName3")
                End If
                If Not Request("txtFieldValue1") = "" Then
                    Session("FieldValue1") = Request("txtFieldValue1")
                End If
                If Not Request("txtFieldValue2") = "" Then
                    Session("FieldValue2") = Request("txtFieldValue2")
                End If
                If Not Request("txtFieldValue3") = "" Then
                    Session("FieldValue3") = Request("txtFieldValue3")
                End If
                If Not Request("ddlOperator2") = "" Then
                    Session("Operator2") = Request("ddlOperator2")
                End If
                If Not Request("ddlOperator3") = "" Then
                    Session("Operator3") = Request("ddlOperator3")
                End If
                If Not Request("optChoice") = "optNotImport" Then
                    Session("Choice") = 0
                Else
                    Session("Choice") = 1
                End If
                Session("Display") = 2
            End If
        End Sub

        ' ProcessZQuery method
        Public Sub ProcessZQuery()
            Dim intStart As Integer
            Dim intImportID As Integer
            Dim blnToCat As Boolean = False
            If Trim(Request("txtStart")) = "" Then
                intStart = 1
            Else
                intStart = CInt(Trim(Request("txtStart")))
            End If
            If Not Trim(Request.QueryString("tocat")) = "" Then
                blnToCat = True
            End If
            objBZImport.zServer = Session("zServer")
            objBZImport.zPort = Session("zPort")
            objBZImport.zDatabase = Session("zDatabase")
            objBZImport.FieldName1 = Session("FieldName1")
            objBZImport.FieldValue1 = Session("FieldValue1")
            objBZImport.FieldName2 = Session("FieldName2")
            objBZImport.FieldValue2 = Session("FieldValue2")
            objBZImport.FieldName3 = Session("FieldName3")
            objBZImport.FieldValue3 = Session("FieldValue3")
            objBZImport.Operator2 = Session("Operator2")
            objBZImport.Operator3 = Session("Operator3")
            objBZImport.VietUSMARC = Session("VietUSMARC")
            objBZImport.Start = intStart
            objBZImport.Howmany = 10
            If Session("Display") = 3 Then
                objBZImport.zFormat = "raw"
            Else
                objBZImport.zFormat = "usmarc"
            End If
            ' Show search result
            Call objBZImport.ProccessQuery()
            Call ShowResult()
        End Sub

        ' ShowResult method 
        ' Purpose: show search result by Title from database of liblary choose
        Public Sub ShowResult()
            ' Declare variables
            Dim strError As String = objBZImport.ZError
            Dim intHits As Integer = objBZImport.Hits
            Dim objResult As Object
            Dim objTagName As Object
            Dim objTagValue As Object
            Dim intCounter As Integer
            Dim intStart As Integer = objBZImport.Start
            Dim intHowmany As Integer = objBZImport.Howmany
            Dim strResult As String
            Dim strQrytocat As String = ""
            Dim arrFN As Object
            Dim arrFV As Object
            Dim strRecord As String

            If Not Trim(Request.QueryString("tocat") & "") = "" Then
                strQrytocat = "&tocat=1"
            End If

            ' Process ....
            lblSumrec.Text = objBZImport.Hits

            If objBZImport.Hits + 1 - intStart > 10 Then
                intHowmany = 10
            Else
                intHowmany = objBZImport.Hits + 1 - intStart
            End If

            If intStart + intHowmany >= objBZImport.Hits Then
                txtStart.Text = intStart
            Else
                txtStart.Text = intStart + intHowmany
            End If

            objResult = objBZImport.Record
            If Not strError = "" Then
            Else
                If intHits = 0 Then
                    ' No data found
                Else
                    ReDim objTagName(0)
                    ReDim objTagValue(0)
                    ReDim arrFN(UBound(objResult))
                    ReDim arrFV(UBound(objResult))

                    For intCounter = LBound(objResult) To UBound(objResult)
                        strRecord = Replace(objResult(intCounter, 0), Chr(10), "##")
                        If Request("txtStart") <> "" Then
                            arrFN(intCounter) = CStr(intCounter + CInt(Request("txtStart")))
                        Else
                            arrFN(intCounter) = CStr(intCounter)
                        End If
                        Call objBZImport.ParseTaggedRecord(strRecord, objTagName, objTagValue, "$")
                        arrFV(intCounter) = GenSimple(objTagName, objTagValue)
                    Next
                    'View result
                    dtgShowResult.DataSource = objWCommon.CreateTable(arrFN, arrFV)
                    dtgShowResult.DataBind()
                End If
            End If
        End Sub

        ' Link form create request with data choose
        Private Sub dtgShowResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgShowResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnk As HyperLink
                    lnk = CType(e.Item.Cells(2).FindControl("lnkReuse"), HyperLink)
                    lnk.NavigateUrl = "javascript:opener.parent.Hiddenbase.location.href='WORCreateHidden.aspx?StartID=" & DataBinder.Eval(e.Item.DataItem, "TextField") & "&ILLNewQuery=0'; self.close();"
            End Select
        End Sub

        ' GenSimple method
        ' Purpose: Genarate Simple format method.
        Public Function GenSimple(ByVal Array1 As Object, ByVal Array2 As Object) As String
            Dim strOut As String = ""
            Dim intIndex As Integer

            intIndex = objBZImport.FindIndex(Array1, "100")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & lblAuthor.Text & ": </B>" & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex))) & "<BR>"
            End If
            intIndex = objBZImport.FindIndex(Array1, "245")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & lblTitle.Text & ": </B>" & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex))) & "<BR>"
            End If
            intIndex = objBZImport.FindIndex(Array1, "260")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & lblPublisher.Text & ": </B>" & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex))) & "<BR>"
            End If
            intIndex = objBZImport.FindIndex(Array1, "300")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & lblOtherInfor.Text & ": </B>" & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex))) & "<BR>"
            End If
            If Not strOut = "" Then
                strOut = Left(strOut, Len(strOut) - 4)
            End If
            GenSimple = strOut
        End Function

        ' GenISBD method
        ' Purpose: Genarate ISBD format method.
        Public Function GenISBD(ByVal Array1, ByVal Array2) As String
            Dim strResult As String
            Dim intIndex As Integer
            strResult = ""
            intIndex = objBZImport.FindIndex(Array1, "100")
            If intIndex >= 0 Then
                strResult = "<B>" & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex))) & ". </B>"
            End If
            intIndex = objBZImport.FindIndex(Array1, "245")
            If intIndex >= 0 Then
                strResult = strResult & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex)))
            End If
            intIndex = objBZImport.FindIndex(Array1, "260")
            If intIndex >= 0 Then
                strResult = strResult & ". - " & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex)))
            End If
            intIndex = objBZImport.FindIndex(Array1, "300")
            If intIndex >= 0 Then
                strResult = strResult & ". - " & Trim(objBCommon.TrimSubFieldCodes(Array2(intIndex)))
            End If
            GenISBD = strResult
        End Function

        ' BreakLine function
        ' Purpose: break input string into multilines
        ' Input: strInput, lngLineLen
        ' Output: string after breakline
        Function BreakLine(ByVal strInput As String, ByVal lngLineLen As Long) As String
            Dim strOutput As String = ""
            Dim strTemp As String = strInput
            strTemp = Replace(strTemp, Chr(31), "$")
            strTemp = Replace(strTemp, Chr(30), "#")
            strTemp = Replace(strTemp, Chr(29), "#")
            While Len(strTemp) > 0
                If Len(strTemp) >= lngLineLen Then
                    strOutput = strOutput & Left(strTemp, lngLineLen) & "<BR>"
                    strTemp = Right(strTemp, Len(strTemp) - lngLineLen)
                Else
                    strOutput = strOutput & strTemp
                    strTemp = ""
                End If
            End While
            BreakLine = strOutput
        End Function


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objWCommon Is Nothing Then
                    objWCommon.Dispose(True)
                    objWCommon = Nothing
                End If
                If Not objBZImport Is Nothing Then
                    objBZImport.Dispose(True)
                    objBZImport = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

