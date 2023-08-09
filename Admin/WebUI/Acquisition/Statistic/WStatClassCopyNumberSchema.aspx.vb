' Class: WStatClassCopyNumberSchema
' Puspose: Stastic class copynumber
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatClassCopyNumberSchema
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Public variable
        Private objBS As New clsBStatistic
        Private objBCC As New clsBCommonChart
        Private objBCDBS As New clsBCommonDBSystem

        Dim strClassTab As String
        Dim bytMaxBranch, bytUtf As Byte
        Dim strBranch As String
        Dim strTree As String
        Dim strTrees() As String

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
                If Request("xLabel") & "" = "" Then ' Gen Root Chart
                    GenChart(True)
                Else ' Gen Branch Chart
                    GenChart(False)
                End If
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all need objects
        Private Sub Initialize()
            ' Initialize objBS object
            objBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBS.DBServer = Session("DBServer")
            objBS.ConnectionString = Session("ConnectionString")
            Call objBS.Initialize()

            ' Initialize objBCC object
            objBCC.InterfaceLanguage = Session("InterfaceLanguage")
            objBCC.DBServer = Session("DBServer")
            objBCC.ConnectionString = Session("ConnectionString")
            Call objBCC.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Set Utf 
            Select Case UCase(Session("InterfaceLanguage"))
                Case "TCVN"
                    bytUtf = 0
                Case "VNI"
                    bytUtf = 0
                Case Else
                    bytUtf = 1
            End Select
        End Sub

        ' BindScript method
        ' Purpose: include need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatIndex.js'></script>")
            Page.RegisterClientScriptBlock("WStatClassCopyNumberSchemaJs", "<script language='javascript' src='../Js/Statistic/WStatClassCopyNumberSchema.js'></script>")
            Page.RegisterClientScriptBlock("WStatClassCopyNumberJs", "<script language='javascript' src='../Js/Statistic/WStatClassCopyNumber.js'></script>")
            Page.RegisterClientScriptBlock("WCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim strName(0) As String
            strName(0) = "USED_CLASSIFICATION"
            Try
                If CByte(objBCDBS.GetSystemParameters(strName)(0)) = 1 Then
                    strClassTab = "DDC"
                    objBS.Index = "DDC"
                    bytMaxBranch = 10
                Else
                    strClassTab = "BBK"
                    objBS.Index = "BBK"
                    bytMaxBranch = 2
                End If
                objBS.Where = CStr(Session("Where"))
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        ' Method: GenChart
        ' Purpose: generate charts now
        Private Sub GenChart(ByVal boolRoot As Boolean)
            Dim strHTitle, strVTitle, strTitle, strImg, strTemp As String
            Dim ArrData(), ArrLabel() As String
            Dim inti, intj As Integer
            Dim strURL As String
            strImg = Server.MapPath("..\..\Images\bground.gif")
            strVTitle = lblVTitle.Text
            strHTitle = lblHTitle.Text & strClassTab
            strTitle = lblTitle.Text & strClassTab
            objBS.Where = CStr(Session("Where"))
            If boolRoot = True Then ' Gen Root Chart
                Try
                    If Request("Tree") & "" = "" Then
                        Session("Tree") = ""
                    Else
                        Session("Tree") = Session("Tree") & Request("Tree") & ";"
                    End If
                    If Request("Branch") & "" = "" Then
                        strBranch = ""
                    Else
                        strBranch = Request("Branch")
                    End If
                    objBS.Index = strClassTab
                    objBS.Branch = strBranch
                    objBS.StatClassCopyNumber()
                    ArrData = objBS.ArrDataChart
                    ArrLabel = objBS.ArrLabelChart
                    If ArrLabel(0) = "NOT FOUND" Then
                        Response.Redirect("WStatEmty.aspx")
                    Else
                        objBCC.Makebarchart(ArrData, ArrLabel, strVTitle, strHTitle, 0, strImg, "WStatClassCopyNumberSchema.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCC.OutPutStream
                        objBCC.Makepiechart(ArrData, ArrLabel, strTitle, strImg)
                        Response.Write("<MAP NAME=""map1"">" & objBCC.OutMapImg & "</MAP>")
                        Session("chart2") = Nothing
                        Session("chart2") = objBCC.OutPutStream
                    End If
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            Else ' Gen Branch Chart
                Try
                    If Request("Tree") & "" = "" Then
                        If InStr(Session("Tree"), Request("xLabel")) = 0 Then
                            Session("Tree") = Session("Tree") & Request("xLabel") & ";"
                        End If
                    Else
                        Session("Tree") = Request("Tree")
                    End If
                    strBranch = Request.QueryString("xLabel")
                    ' Tree Root
                    strURL = "<B><A HREF=javascript:GoPreviousPage('','','" & bytUtf & "','');>Root</A>--"
                    If Len(strBranch) > 0 Then ' Gen chart dependon xLabel ( selected from MAP Chart ) 
                        If Len(CStr(Session("Tree"))) > 0 Then
                            strTrees = Split(CStr(Session("Tree")), ";")
                            If UBound(strTrees) > 0 Then
                                strTemp = ""
                                For inti = LBound(strTrees) To UBound(strTrees)
                                    strTemp &= strTrees(inti) & ";"
                                    strURL &= "<A HREF=javascript:GoPreviousPage('" & strTemp & "','" & strTrees(inti) & "','" & bytUtf & "','" & strTrees(inti) & "');>" & strTrees(inti) & "</A>-- " ' Tree branchs
                                Next
                            End If
                        End If
                    End If
                    strURL &= "</B>"
                    lblMainTitle.Text = strURL
                    If strBranch <> "" Then ' Gen Branch Chart
                        objBS.Branch = strBranch
                    Else ' Gen Root Chart
                        objBS.Branch = ""
                    End If
                    objBS.Branch = strBranch
                    objBS.StatClassCopyNumber()
                    ArrData = objBS.ArrDataChart
                    ArrLabel = objBS.ArrLabelChart
                    If Not ArrLabel(0) = "NOT FOUND" Then
                        objBCC.Makebarchart(ArrData, ArrLabel, strVTitle, strHTitle, 0, strImg, "WStatClassCopyNumberSchema.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCC.OutPutStream
                        objBCC.Makepiechart(ArrData, ArrLabel, strTitle, strImg)
                        If strBranch.Length <= bytMaxBranch Then
                            Response.Write("<MAP NAME=""map1"">" & objBCC.OutMapImg & "</MAP>")
                        End If
                        Session("chart2") = Nothing
                        Session("chart2") = objBCC.OutPutStream
                    Else ' Never happen
                        Response.Redirect("WStatEmty.aspx")
                    End If
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBS Is Nothing Then
                objBS.Dispose(True)
                objBS = Nothing
            End If
            If Not objBCC Is Nothing Then
                objBCC.Dispose(True)
                objBCC = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
    End Class
End Namespace