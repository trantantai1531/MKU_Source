' Class: WStatClassCopyNumber
' Puspose: Statistic class copynumber
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   09/06/2005 by Oanhtn: fix errors

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatClassCopyNumber
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

        ' Public variable
        Private objBS As New clsBStatistic
        Private objBCC As New clsBCommonChart
        Private objBCDBS As New clsBCommonDBSystem

        Dim strClassTab As String
        Dim bytMaxBranch As Byte
        Dim strBranch As String
        Dim strTree As String

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                ' WriteLog
                Call WriteLog(42, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call BindData()
            End If
            If (Not IsNothing(Request.QueryString("export"))) Then
                Dim strName(0) As String
                strName(0) = "USED_CLASSIFICATION"
                If CByte(objBCDBS.GetSystemParameters(strName)(0)) = 1 Then
                    strClassTab = "DDC"
                    bytMaxBranch = 10
                Else
                    strClassTab = "BBK"
                    bytMaxBranch = 2
                End If

                objBS.Index = strClassTab
                objBS.Where = CStr(Session("Where"))
                objBS.Branch = ""
                objBS.StatClassCopyNumber()

                If objBS.ArrLabelChart(0) <> "NOT FOUND" Then

                    Dim objData() As String = CType(objBS.ArrDataChart, String())
                    Dim objLabel() As Integer = CType(objBS.ArrLabelChart, Integer())

                    Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, lblHTitle.Text & strClassTab)

                    clsExport.StringBuilderToExcel(sBuilder1)
                End If
            End If
            If Request("xLabel") & "" = "" Then ' Gen Root Chart ( for first time )
                Call GenRootChart()
            Else ' MAP selected
                strTree = Request("xLabel") & ";"
                strBranch = Request("xLabel")
                Session("Tree") = strTree
                Page.RegisterClientScriptBlock("TransferDataJs", "<script language='javascript'>self.location.href='WStatClassCopyNumberSchema.aspx?Tree=" & strTree & "&Branch=" & strBranch & "&xLabel=" & strBranch & "';</script>")
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
        End Sub

        ' BindScript method
        ' Purpose: include need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatIndex.js'></script>")
            Page.RegisterClientScriptBlock("WStatClassCopyNumberJs", "<script language='javascript' src='../Js/Statistic/WStatClassCopyNumber.js'></script>")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim strWhere As String
            Dim strName(0) As String
            strName(0) = "USED_CLASSIFICATION"

            'If Not Request.QueryString("TimeFrom") = "" Then
            hdTimeFrom.Value = Request.QueryString("TimeFrom").Trim
            hdTimeTo.Value = Request.QueryString("TimeTo").Trim
            hdItemType.Value = Request.QueryString("ItemTypeID").Trim
            'End If

            ' => BusinessRule layer
            Try

                ' Get BBK or DDC from Sys_tblParameter table
                If CByte(objBCDBS.GetSystemParameters(strName)(0)) = 1 Then
                    strClassTab = "DDC"
                    bytMaxBranch = 10
                Else
                    strClassTab = "BBK"
                    bytMaxBranch = 2
                End If

                If hdItemType.Value = "" Then hdItemType.Value = 0

                ' Get codination select 
                If CInt(hdItemType.Value) > 0 Then   ' Have ItemType
                    strWhere &= "  AND Lib_tblHolding.ItemID IN (SELECT ID FROM Lib_tblItem WHERE TypeID=" & hdItemType.Value & " and (Lib_tblItem.libid = " + clsSession.GlbSite + " or " + clsSession.GlbSite + " = 0)  )"
                Else ' All ItemType
                    strWhere &= " AND Lib_tblHolding.ItemID IN (SELECT ID FROM Lib_tblItem WHERE (Lib_tblItem.libid = " + clsSession.GlbSite.ToString() + " or " + clsSession.GlbSite.ToString() + " = 0)  )"
                End If

                If Not hdTimeFrom.Value = "" Then  ' From Time
                    If Not Session("DBServer") = "ORACLE" Then
                        strWhere &= " AND AcquiredDate >= CONVERT(DATETIME, '" & hdTimeFrom.Value & "', 103)"
                    Else
                        strWhere &= " AND AcquiredDate >= TO_DATE('" & hdTimeFrom.Value & "', 'dd/mm/yyyy')"
                    End If
                End If
                If Not hdTimeTo.Value = "" Then ' To Time
                    If Not Session("DBServer") = "ORACLE" Then
                        strWhere &= " AND AcquiredDate <= CONVERT(DATETIME, '" & hdTimeTo.Value & " 23:59:59', 103)"
                    Else
                        strWhere &= " AND AcquiredDate >= TO_DATE('" & hdTimeTo.Value & " 23:59:59', 'dd/mm/yyyy hh24:mi:ss')"
                    End If
                End If
                ' Clear Session
                If Not Session("Tree") Is Nothing Then
                    Session("Tree") = Nothing
                End If
                Session("Where") = Nothing
                Session("Where") = strWhere ' Used when MAP selected               
            Catch ex As Exception
                Call WriteErrorMssg(ddlLog.Items(1).Text, ex.Message.Trim, ddlLog.Items(2).Text, 0)
            End Try
        End Sub

        ' Method: GenRootChart
        ' Purpose: generate charts now
        Private Sub GenRootChart()
            Dim ArrData() As String
            Dim ArrLabel() As String
            Dim strVTitle As String
            Dim strHTitle As String
            Dim strTitle As String
            Dim strImg As String

            Try
                strImg = Server.MapPath("..\..\Images\bground.gif")
                strVTitle = lblVTitle.Text
                strHTitle = lblHTitle.Text & strClassTab
                strTitle = lblTitle.Text & strClassTab
                objBS.Index = strClassTab
                objBS.Where = CStr(Session("Where"))
                objBS.Branch = ""
                objBS.StatClassCopyNumber()

                ArrData = objBS.ArrDataChart
                ArrLabel = objBS.ArrLabelChart
                If ArrLabel(0) = "NOT FOUND" Then
                    Response.Redirect("WStatEmty.aspx")
                Else
                    'objBCC.Makebarchart(ArrData, ArrLabel, strVTitle, strHTitle, 0, strImg, "WStatClassCopyNumber.aspx")
                    objBCC.Makebarchart(ArrData, ArrLabel, strVTitle, strHTitle, 0, strImg, "WStatClassCopyNumber.aspx?ItemTypeID=" & hdItemType.Value & "&TimeFrom=" & hdTimeFrom.Value & "&TimeTo=" & hdTimeTo.Value & "")

                    Session("chart1") = Nothing
                    Session("chart1") = objBCC.OutPutStream
                    objBCC.Makepiechart(ArrData, ArrLabel, strTitle, strImg)
                    Response.Write("<MAP NAME=""map1"">" & objBCC.OutMapImg & "</MAP>")
                    Session("chart2") = Nothing
                    Session("chart2") = objBCC.OutPutStream
                End If
            Catch ex As Exception
            End Try
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