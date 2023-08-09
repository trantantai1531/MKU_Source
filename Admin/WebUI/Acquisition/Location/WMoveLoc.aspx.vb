' class WMoveLoc
' Puspose: move a location to another
' Creator: Lent
' CreatedDate: 23-2-2005
' Modification History:

Imports System.IO
Imports System.IO.File
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WMoveLoc
        Inherits clsWBase


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidNoSelectLib As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variable
        Private objBLibrary As New clsBLibrary
        Private objBLocation As New clsBLocation
        Private objBCopyNumber As New clsBCopyNumber
        Private intUserID As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
                Call BindDataSource()
                Call BindDataDestination()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(126) Then
                btnMoveLocation.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Initialize objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()

            ' Initialize objBCopyNumber object
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCopyNumber.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WMoveLoc.js'></script>")

            btnMoveLocation.Attributes.Add("Onclick", "javascript:return(CheckMoveLocation('" & ddlLabelNote.Items(0).Text & "','" & ddlLabelNote.Items(9).Text & "'))")
            rdbCodeDoc.Attributes.Add("Onclick", "javascript:ShowHideTable(0);")
            rdbCopyNum.Attributes.Add("Onclick", "javascript:ShowHideTable(1);")
            rdbCopyNumFile.Attributes.Add("OnClick", "javascript:SwitchEnable(0);")
            rdbCopyNumManual.Attributes.Add("OnClick", "javascript:SwitchEnable(1);")
            ddlLibSource.Attributes.Add("OnChange", "javascript:return(LoadLocation(0));")
            ddlLibDestination.Attributes.Add("OnChange", "javascript:return(LoadLocation(1));")
            btnCodeDoc.Attributes.Add("OnClick", "javascript:return(OpenSearchForm());")
            lnkShowCopyNum.Attributes.Add("Onclick", "javascript:return(ShowCopyNumber('" & ddlLabelNote.Items(4).Text & "'));")
            lnkShowCopyNum.NavigateUrl = "#"
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblResult As New DataTable
            Dim listItem As New ListItem

            intUserID = Session("UserID")
            objBLibrary.UserID = Session("UserID")
            objBLibrary.LibID = clsSession.GlbSite
            tblResult = objBLibrary.GetLibrary(1)
            ' Bind data for dropdownlist library
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                ddlLibDestination.DataSource = tblResult
                ddlLibDestination.DataTextField = "FullName"
                ddlLibDestination.DataValueField = "ID"
                ddlLibDestination.DataBind()
                ddlLibDestination.SelectedIndex = 0

                ddlLibSource.DataSource = InsertOneRow(tblResult, ddlLabelNote.Items(3).Text)
                ddlLibSource.DataTextField = "FullName"
                ddlLibSource.DataValueField = "ID"
                ddlLibSource.DataBind()
            Else
                listItem.Text = ddlLabelNote.Items(3).Text
                listItem.Value = 0
                ddlLibSource.Items.Add(listItem)
                ddlLibDestination.Items.Add(listItem)
                btnCodeDoc.Enabled = False
                btnMoveLocation.Enabled = False
            End If
            ddlLibSource.SelectedIndex = 0
            ddlLibDestination.SelectedIndex = 0
            tblResult = Nothing
        End Sub

        ' Method: BindDataSource
        ' Purpose: Load data
        Private Sub BindDataSource()
            Dim tblTemp As DataTable
            Dim lstItem As ListItem

            If ddlLibSource.SelectedValue > 0 Then
                intUserID = Session("UserID")
                objBLocation.UserID = intUserID
                objBLocation.LibID = ddlLibSource.SelectedValue
                objBLocation.LocID = 0
                objBLocation.Status = -1
                tblTemp = objBLocation.GetLocation
                ' Bind data for dropdownlist
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    ddlLocSource.DataSource = tblTemp
                    ddlLocSource.DataTextField = "Symbol"
                    ddlLocSource.DataValueField = "ID"
                    ddlLocSource.DataBind()
                    ddlLocSource.SelectedIndex = 0
                Else
                    ddlLocSource.Items.Add(" ")
                    ddlLocSource.SelectedIndex = 0
                    ddlLocSource.SelectedItem.Value = 0
                End If
            End If
        End Sub

        ' Method: BindDataSource
        ' Purpose: Load data
        Private Sub BindDataDestination()
            Dim tblTemp As DataTable

            intUserID = Session("UserID")
            objBLocation.UserID = intUserID
            objBLocation.LibID = ddlLibDestination.SelectedValue
            objBLocation.LocID = 0
            objBLocation.Status = -1
            tblTemp = objBLocation.GetLocation
            ' Bind data for dropdownlist
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLocDestination.DataSource = tblTemp
                ddlLocDestination.DataTextField = "Symbol"
                ddlLocDestination.DataValueField = "ID"
                ddlLocDestination.DataBind()
                ddlLocDestination.SelectedIndex = 0
            End If
        End Sub

        ' Event: btnMoveLocation_Click
        Private Sub btnMoveLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLocation.Click
            Dim strerror As String
            Dim strPath As String
            Dim strListCopyNum As String = ""
            Dim arrCopyNum() As String
            Dim arrCopyNums() As String
            Dim inti As Integer
            Dim intk As Integer = 0
            Dim intLengCopyNum = 100 ' Number of copynumber for update
            Dim intLibID2 As Integer = 0
            Dim intLocID2 As Integer = 0
            Dim strShelf2 As String = ""

            If ddlLibSource.SelectedValue > 0 Then
                objBCopyNumber.LibID = ddlLibSource.SelectedValue
            End If

            If Not hidLocSourceID.Value = "0" Then
                objBCopyNumber.LocID = hidLocSourceID.Value
            End If

            intLibID2 = ddlLibDestination.SelectedValue
            intLocID2 = hidLocDesID.Value
            objBCopyNumber.Shelf = txtShelfSource.Text
            strShelf2 = txtShelfDestination.Text
            objBCopyNumber.UserID = Session("UserID")

            If rdbCodeDoc.Checked Then
                objBCopyNumber.Code = txtCodeDoc.Text.Trim
                ' Move copynumbers by itemcode
                strerror = objBCopyNumber.MoveLocation(intLibID2, intLocID2, strShelf2)
            Else
                objBCopyNumber.Code = ""

                'get list copynumber
                If rdbCopyNumFile.Checked Then
                    'get from file
                    strPath = Server.MapPath("")
                    UpLoadFiles(FileCopyNum, strPath, "tmp")
                    If Not FileCopyNum.Value = "" Then
                        strListCopyNum = Trim(ReadFromFile(strPath & "\tmp.txt"))
                    End If
                Else
                    'get list form
                    strListCopyNum = Trim(txtCopyNumManual.Text)
                End If
                ' repair strListCopyNum
                If strListCopyNum <> "" Then
                    strListCopyNum = strListCopyNum.Replace(Chr(10), "")
                    strListCopyNum = strListCopyNum.Replace(Chr(13), ",")
                    strListCopyNum = strListCopyNum.Replace(Chr(9), ",")
                    strListCopyNum = strListCopyNum.Replace(";", ",")
                    If Right(strListCopyNum, 1) = "," Then
                        strListCopyNum = Left(strListCopyNum, Len(strListCopyNum) - 1)
                    End If
                    arrCopyNum = Split(strListCopyNum, ",")
                    strListCopyNum = ""

                    ' gen arrCopyNum
                    For inti = 0 To arrCopyNum.Length - 1
                        strListCopyNum = strListCopyNum & arrCopyNum(inti) & ","

                        If inti + 1 >= (intk + 1) * intLengCopyNum Then
                            ReDim Preserve arrCopyNums(intk)
                            strListCopyNum = Left(strListCopyNum, strListCopyNum.Length - 1)
                            arrCopyNums(intk) = strListCopyNum
                            intk = intk + 1
                            strListCopyNum = ""
                        End If
                    Next
                    If inti > intk * intLengCopyNum Then
                        If (2 * (inti - intk * intLengCopyNum) >= intLengCopyNum) Or (intk = 0) Then
                            ReDim Preserve arrCopyNums(intk)
                            strListCopyNum = Left(strListCopyNum, strListCopyNum.Length - 1)
                            arrCopyNums(intk) = strListCopyNum
                        Else
                            arrCopyNums(intk - 1) = arrCopyNums(intk - 1) & "," & strListCopyNum
                        End If
                    End If
                End If
                For inti = 0 To arrCopyNums.Length - 1
                    objBCopyNumber.CopyNumber = arrCopyNums(inti)
                    strerror = objBCopyNumber.MoveLocation(intLibID2, intLocID2, strShelf2)
                Next
            End If

            If strerror <> "" Then ' Writelog
                Call WriteLog(93, ddlLabelNote.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                lblErrorReports.Text = ddlLabelNote.Items(10).Text & "<font color='red'>" & strerror & "</font>"
                If strerror <> 0 Then
                    Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('Chuyển kho thành công');</script>")
                End If


            Else
                lblErrorReports.Text = ""
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(2).Text & "');</script>")
            End If
            Call BindDataSource()
            Call BindDataDestination()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace