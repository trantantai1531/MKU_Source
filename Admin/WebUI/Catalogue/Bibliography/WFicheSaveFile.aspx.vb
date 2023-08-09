Imports System
Imports System.IO
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WFicheSaveFile
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

        Private objBFiche As New clsBFiche

        'Event Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Init all object use in form
            Call Initialize()
            'Bind javascript for all control need
            Call BindJavascript()
            'Save data to file
            Call WriteFicheToFile()
        End Sub

        'Methord: BindJavascript
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WIDXViewForm.js'></script>")
        End Sub

        'Nethord: Initialize
        Private Sub Initialize()
            objBFiche.InterfaceLanguage = Session("InterfaceLanguage")
            objBFiche.DBServer = Session("DbServer")
            objBFiche.ConnectionString = Session("ConnectionString")
            objBFiche.Initialize()
        End Sub

        'Methord: WriteFicheToFile
        'Popurse: Save data to file
        Private Sub WriteFicheToFile()
            Dim arrID()
            Dim colPara As New Collection
            Dim strContent As String = ""
            Dim strFileName As String = ""
            Dim intTotalPage As Integer
            Dim intCount As Integer
            Dim inti As Integer
            Dim objDirInfor As DirectoryInfo
            Dim strPath As String

            lnkLink.Visible = False
            colPara = Session("colPara")
            If Not Session("FicheID") Is Nothing Then
                arrID = Session("FicheID")
                objBFiche.ItemIDFrom = colPara.Item("ItemIDFrom")
                objBFiche.ItemIDTo = colPara.Item("ItemIDTo")
                objBFiche.IDTempate = colPara.Item("IDTemplate")
                objBFiche.TagSort = colPara.Item("TagSort")
                objBFiche.CopyNumFrom = colPara.Item("CopyNumFrom")
                objBFiche.CopyNumTo = colPara.Item("CopyNumTo")
                objBFiche.ItemType = colPara.Item("ItemType")
                objBFiche.LibID = colPara.Item("LibID")
                objBFiche.LocID = colPara.Item("LocID")
                objBFiche.MultiFiche = colPara.Item("MultiFiche")
                objBFiche.NewItemOnly = colPara.Item("NewItemOnly")
                objBFiche.UserID = Session("UserID")
                objBFiche.PageSize = colPara.Item("PageSize")
                intTotalPage = Math.Ceiling(UBound(Session("FicheID")) / colPara.Item("PageSize"))

                strContent = strContent & "<html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""><BODY>"
                If intTotalPage = 0 Then
                    intTotalPage = 1
                End If
                For intCount = 1 To intTotalPage
                    strContent = strContent & objBFiche.Generate_Fiche(intCount, arrID)
                Next

                strContent = Replace(Replace(Replace(strContent, "<TABLE CELLPADDING=3 BORDER = 0>", ""), "</TR>", "<BR>"), "<HR>", "<BR>")
                strPath = Server.MapPath("../../Catalogue/Attach") & ""
                objDirInfor = New DirectoryInfo(strPath)
                If Not objDirInfor.Exists Then
                    Call objDirInfor.Create()
                End If
                strFileName = objBFiche.SaveFileAspose(strContent, Server.MapPath("../../"))
                lnkLink.Visible = True
                lnkLink.NavigateUrl = "#"
                If objBFiche.ErrorMsg = "Error opening conversion file" Then
                    Page.RegisterClientScriptBlock("AlertJs1", "<script language ='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                    lnkLink.Attributes.Add("OnClick", "javascript:self.location.href='../Attach/" & strFileName & "';")
                Else
                    lnkLink.Target = "Hiddenbase"
                    lnkLink.Attributes.Add("OnClick", "javascript:parent.Hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=" & strFileName & "';")
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
                If isDisposing Then
                    If Not objBFiche Is Nothing Then
                        objBFiche.Dispose(True)
                        objBFiche = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace