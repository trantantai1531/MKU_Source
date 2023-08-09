' WGenCutter class
' Purpose: Generate cutter
' Creator: Oanhtn
' CreatedDate: 18/05/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update
Imports System.IO
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WGenCutter
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
        Private objBCatalogueForm As New clsBCatalogueForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call GenerateCutter()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBCatalogueForm object
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WGenCutterJS", "<script language = 'javascript' src = '../Js/Catalogue/WGenCutter.js'></script>")
        End Sub

        ' GenerateCutter method
        ' Purpose: generate suite cutter
        Private Sub GenerateCutter()
            Dim strCutter As String
            'Dim strPath As String = Request.ApplicationPath & "/oclccutt/"
            Dim strPath As String = Server.MapPath("../../oclccutt/")
            Dim objDirInfo As DirectoryInfo
            objDirInfo = New DirectoryInfo(strPath)
            If Not objDirInfo.Exists Then
                Call objDirInfo.Create()
            End If
            ' Get cutter
            'objBCatalogueForm.Path = Server.MapPath(strPath)
            Dim pathCode = Server.MapPath(Request.ApplicationPath) & "/Excell" & "/Code.xlsx"
            Dim pathNguyenAm = Server.MapPath(Request.ApplicationPath) & "/Excell" & "/NguyenAm.xlsx"
            Dim pathPhuAm = Server.MapPath(Request.ApplicationPath) & "/Excell" & "/PhuAm.xlsx"
            Dim stringStart As String = "" ' = Request("tag245$a") ' Request("tag245").Remove(0, 2)
            Dim intType As Integer = 0
            If Not IsNothing(Request("intType")) Then
                intType = Request("intType")
            End If
            If intType = 0 Then
                stringStart = Request("tag245$a")
            Else
                stringStart = Request("tag100$a")
            End If

            Dim tableCode = ExcellHelper.GetDataTableFromExcel(pathCode, False)
            Dim tableNguyenAm = ExcellHelper.GetDataTableFromExcel(pathNguyenAm, False)
            Dim tablePhuAm = ExcellHelper.GetDataTableFromExcel(pathPhuAm, False)
            Dim charStart = stringStart.ToCharArray()
            stringStart = ""
            For Each item As Char In charStart
                For Each dtrow As DataRow In tablePhuAm.Rows
                    If dtrow.Item(0).ToString() <> "" Then
                        Dim chartmp = dtrow.Item(0).ToString().ToCharArray()(0)
                        If item = chartmp Then
                            item = dtrow.Item(1).ToString().ToCharArray()(0)
                        End If
                    End If
                Next
                Dim i = Asc(item)
                If item <> "" AndAlso i <> 180 AndAlso i <> 63 AndAlso i <> 96 AndAlso i <> 126 Then
                    stringStart = stringStart + item.ToString()
                End If


            Next

            stringStart = stringStart.ToLower()
            Dim stringFirt = stringStart.Split(" ")(0)
            Dim listString = stringStart.Split(" ")
            Dim charSecond = ""

            If listString.Count() > 1 Then
                Dim secondString = listString(1)
                Dim checkExitNguyenAmSecond = False
                Dim lenght = 0

                For Each dr As DataRow In tableNguyenAm.Rows
                    Dim nguyenAmExcel = dr.Item(0).ToString()
                    If secondString.IndexOf(nguyenAmExcel) = 0 AndAlso nguyenAmExcel <> "" Then

                        If (lenght <= nguyenAmExcel.Length) Then
                            lenght = nguyenAmExcel.Length
                            charSecond = nguyenAmExcel
                        End If
                        checkExitNguyenAmSecond = True
                    End If
                Next
                If checkExitNguyenAmSecond = False Then
                    charSecond = secondString.ToCharArray()(0)
                End If

            End If
            Dim stringb = listString(0).ToLower()
            Dim checkExitNguyenAm = False
            Dim nguyenAm = ""

            For Each dr As DataRow In tableNguyenAm.Rows
                Dim nguyenAmExcel = dr.Item(0).ToString()
                If stringb.IndexOf(nguyenAmExcel) = 0 AndAlso nguyenAmExcel <> "" Then
                    checkExitNguyenAm = True
                    If nguyenAm.Length < nguyenAmExcel.Length Then
                        nguyenAm = nguyenAmExcel
                    End If

                End If
            Next

            If checkExitNguyenAm Then
                For Each drCode As Object In tableCode.Rows
                    Dim phuAmExcel = drCode.Item(0).ToString()
                    Dim code = drCode.Item(1).ToString()
                    Dim tmp = stringFirt.ToLower().Remove(0, nguyenAm.Length)
                    If stringFirt.Contains(phuAmExcel) AndAlso tmp.Length = phuAmExcel.Length Then
                        stringFirt = stringFirt.Replace(stringFirt, code)
                    End If
                Next
            Else
                Dim phuAmDau = stringFirt.ToCharArray()(0)
                For Each drCode As Object In tableCode.Rows
                    Dim phuAmExcel = drCode.Item(0).ToString()
                    If stringb.Contains(phuAmExcel) = 0 AndAlso stringb.Length = phuAmExcel.Length Then
                        stringFirt = phuAmDau & drCode.Item(1).ToString()
                    End If
                Next

            End If
            Dim stringcuoi = (nguyenAm & stringFirt & charSecond).ToString().ToUpper() '"$b" & (nguyenAm & stringFirt & charSecond).ToString().ToUpper()
            ' Load cutter
            Page.RegisterClientScriptBlock("Loadback", "<script language='javascript'>LoadBack('" & stringcuoi & "');</script>")
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCatalogueForm Is Nothing Then
                    objBCatalogueForm.Dispose(True)
                    objBCatalogueForm = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace