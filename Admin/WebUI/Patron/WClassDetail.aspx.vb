Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WClassDetail
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

        Private objBPC As New clsBPatronCollection
        Private objBP As New clsBPatron
        Dim intMax As Integer
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here.
            Call Initialize()
            Dim Arr()
            Dim tblPatronResult As New DataTable
            btnSelect.Visible = False
            lnkCheckAll.Visible = False
            dgrPatron.Visible = False
            If Trim(Request.QueryString("cls")) <> "" Then
                objBPC.Classs = Trim(Request.QueryString("cls"))
            Else
                objBPC.ToID = -1
                lnkCheckAll.Visible = False
                btnSelect.Visible = False
            End If
            Arr = objBPC.Search
            intMax = 0
            If Not (Arr Is Nothing) Then
                intMax = UBound(Arr)
                Dim str As String
                Dim inti As Integer
                str = ""
                For inti = 0 To UBound(Arr)
                    str = str & Arr(inti) & ","
                Next
                If str <> "" Then
                    str = Left(str, Len(str) - 1)
                    objBP.PatronIDs = str
                End If
            End If
            Select Case objBP.DBServer
                Case "SQLSERVER"
                    objBP.Fields = " A.Code, IsNull(A.FirstName,'') + ' ' + IsNull(A.MiddleName,'') + ' ' + IsNull(A.LastName,'') AS FullName, A.DOB "
                Case Else
                    objBP.Fields = " A.Code, A.FirstName || ' ' || A.MiddleName || ' ' || A.LastName AS FullName, A.DOB "
            End Select
            tblPatronResult = objBP.GetPatron
            If Not tblPatronResult Is Nothing Then
                If tblPatronResult.Rows.Count > 0 Then
                    btnSelect.Visible = True
                    lnkCheckAll.Visible = True
                    dgrPatron.Visible = True
                    dgrPatron.DataSource = tblPatronResult
                    dgrPatron.DataBind()
                End If
            End If
            Call BindScript()
        End Sub

        Public Sub Initialize()
            ' Initialize objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.DBServer = Session("DBServer")
            objBPC.initialize()
            ' Initialize objBP object
            objBP.InterfaceLanguage = Session("InterfaceLanguage")
            objBP.ConnectionString = Session("ConnectionString")
            objBP.DBServer = Session("DBServer")
            objBP.initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WClassDetailJs", "<script language = 'javascript' src = 'js/WClassDetail.js'></script>")
            lnkCheckAll.NavigateUrl = "javascript:SelectAll(2,'dgrPatron','chkSelectedCode'," & intMax & ")"
            btnSelect.Attributes.Add("OnClick", "CloseForm(2,'dgrPatron','chkSelectedCode'," & intMax & ");return false;")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return(false);")
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBP Is Nothing Then
                objBP.Dispose(True)
                objBP = Nothing
            End If
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
        End Sub
    End Class
End Namespace