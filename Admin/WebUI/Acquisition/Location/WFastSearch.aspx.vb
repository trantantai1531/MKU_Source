' class WFastSearch
' Puspose: fast search document code apply to move and 
' Creator: Lent
' CreatedDate: 23-2-2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WFastSearch
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
        'Private 'objBItemQueue As New clsBItemQueue

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            MyBase.Dispose()
            Me.Dispose()

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim intmax As Integer = 100
            Dim inti As Integer = 0
            Dim strHtml As String = ""
            strHtml = "<span id='spnMain' style='LEFT: 104px; WIDTH: 600px; COLOR: #3333ff; POSITION: absolute; TOP: 40px'	class='lblLabel'>"
            strHtml = strHtml & "<span id='spnPecent' style='LEFT: 300px; COLOR: #FFFFFF; POSITION: absolute; TOP: 10px;FONT-WEIGHT: bold;'>0%</span>"
            'strHtml = strHtml & "<span id='spnProgess' style='LEFT: 0%; WIDTH: 0px; POSITION: absolute; TOP: 0px; HEIGHT: 30px; BACKGROUND-COLOR: #0000cc'></span></span>"

            'strHtml = "<div id='divLabel'>0</div>"
            strHtml = strHtml & "<table width=100% border=1 bgcolor=#999966 height=30px cellspacing=0 cellpadding=0><tr><td>"
            strHtml = strHtml & "<table id='spnProgess' width=0% border=0 bgcolor=#006291 height=100%><tr><td></td></tr></table></td></tr></table>"
            Response.Write(strHtml)
            For inti = 0 To intmax - 1
                Call BindPrg(inti, intmax)
            Next
        End Sub
        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            System.Threading.Thread.Sleep(500 / intSum)
            Response.Write("<script>spnProgess.width =" & intCurrentPercent & " + '%'; spnPecent.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

    End Class
End Namespace
