' class WACQResult
' Puspose: Diplay Acqreport
' Creator: Sondp
' CreatedDate: 
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQResult
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

        Private objBT As New clsBTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()

            If Not Page.IsPostBack Then
                If Not Session("IDs") Is Nothing Then
                    Dim lngStartID, lngStopID, lngi As Long
                    Dim collAcq As New Collection
                    Dim strIDs As String = ""
                    Dim arrIDs() As String
                    collAcq = Session("collAcq")
                    arrIDs = Session("IDs")
                    If Not Request.QueryString("CurrentPage") & "" = "" Then
                        lngStartID = (CLng(Request.QueryString("CurrentPage")) - 1) * CLng(collAcq.Item("pagesize"))
                        lngStopID = CLng(Request.QueryString("CurrentPage")) * CLng(collAcq.Item("pagesize")) - 1
                    Else
                        lngStartID = 0
                        lngStopID = CLng(collAcq.Item("pagesize")) - 1
                    End If
                    If arrIDs IsNot Nothing Then
                        If UBound(arrIDs) < lngStopID Then
                            lngStopID = UBound(arrIDs)
                        End If
                        For lngi = lngStartID To lngStopID
                            strIDs &= arrIDs(lngi) & ", "
                        Next
                    End If
                    If Not strIDs & "" = "" Then
                        strIDs = Left(strIDs, strIDs.Length - 2)
                        lblOutMsg.Text = objBT.GenACQReport(collAcq.Item("formal"), lngStartID, lngStopID, strIDs, collAcq)
                        lblPageHeader.Text = objBT.PageHeader
                        lblPageFooter.Text = objBT.PageFooter

                        ' WriteLog
                        Call WriteLog(39, ddlLog.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    End If
                End If
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            Call objBT.Initialize()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
        End Sub
    End Class
End Namespace