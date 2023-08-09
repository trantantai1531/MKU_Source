Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WFichePrint
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

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            Call BindJS()
            Call WriteFiche()
        End Sub

        ' Method: Initialze
        Private Sub Initialze()
            objBFiche.InterfaceLanguage = Session("InterfaceLanguage")
            objBFiche.DBServer = Session("DbServer")
            objBFiche.ConnectionString = Session("ConnectionString")
            Call objBFiche.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Bind Javascript for all control need
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WFichePrint.js'></script>")
        End Sub

        ' Method: WriteFiche
        ' Purpose: Print fich
        Private Sub WriteFiche()
            Dim arrID()
            Dim colPara As New Collection
            colPara = Session("colPara")

            If Not Session("FicheID") Is Nothing Then
                arrID = Session("FicheID")

                objBFiche.ItemCodeFrom = colPara.Item("ItemCodeFrom")
                objBFiche.ItemCodeTo = colPara.Item("ItemCodeTo")
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

                Dim intPage As Integer
                If IsNumeric(Request.QueryString("intPage") & "") Then
                    intPage = CInt(Request.QueryString("intPage"))
                Else
                    intPage = 1
                End If

                Dim resultContentTemplate() As String = objBFiche.Generate_Fiche_ToList(intPage, arrID)
                Response.Write("<div style='width:100%; padding-top:25px; margin-left:0px;'>")
                Dim inti As Integer = 0
                For Each strContent As String In resultContentTemplate
                    'Dim resultContent As String = ""
                    'Dim splitContent() As String = strContent.Replace("<HR WIDTH=60 NOSHADE COLOR=000000 SIZE=1>", "/").Split("/")
                    'For Each strResultSplit As String In splitContent
                    '    If (Not IsNothing(strResultSplit)) AndAlso (strResultSplit.Trim.Length > 8) Then
                    '        resultContent = strResultSplit
                    '    End If
                    'Next

                    If (inti Mod 2 = 0) Then
                        Response.Write("<div style='width:50%; float:left;'>")
                        Response.Write("<div style='width:100%; text-align:left;'>")
                        Response.Write(strContent.Replace("<HR WIDTH=60 NOSHADE COLOR=000000 SIZE=1>", "/"))
                        Response.Write("</div>")
                        Response.Write("</div>")
                    Else
                        Response.Write("<div style='width:50%; float:left;'>")
                        Response.Write("<div style='width:100%; text-align:right;'>")
                        Response.Write(strContent.Replace("<HR WIDTH=60 NOSHADE COLOR=000000 SIZE=1>", "/"))
                        Response.Write("</div>")

                        Response.Write("</div>")
                    End If
                    inti = inti + 1
                Next
                Response.Write("</div>")
                'Response.Write(objBFiche.Generate_Fiche_ToList(intPage, arrID))
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