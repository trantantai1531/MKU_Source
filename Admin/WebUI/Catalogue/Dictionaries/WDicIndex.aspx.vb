' Class: WDicIndex
' Propose: 
' CreatedDate: 19/04/2004
' Creator: Sondp.
'  Modification history 
'    - 02/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDicIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtType As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBCatDiclist As New clsBCatDicList

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            Select Case UCase(Trim(Me.ReadTableDicName))
                Case "Cat_tblDic_ItemType"
                    Response.Redirect("WDicItemType.aspx")
                Case "CAT_DIC_MEDIUM"
                    Response.Redirect("WDicMedium.aspx")
                Case Else
                    Response.Redirect("WDicMedium.aspx")
            End Select
        End Sub

        'Methord: ReadTableDicName
        Private Function ReadTableDicName() As String
            Dim TblDicIndex As New DataTable
            Dim strRet As String
            If IsNumeric(Request.QueryString("ID")) Then
                objBCatDiclist.IDs = Trim(Request.QueryString("ID"))
                TblDicIndex = objBCatDiclist.Retrieve
                If TblDicIndex.Rows.Count > 0 Then
                    strRet = Trim(TblDicIndex.Rows(0).Item("DicTable") & "")
                Else
                    strRet = ""
                End If
            Else
                strRet = ""
            End If
            ReadTableDicName = strRet
        End Function

        ' Methord: Initialze
        Private Sub Initialze()
            objBCatDiclist.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDiclist.DBServer = Session("DbServer")
            objBCatDiclist.ConnectionString = Session("ConnectionString")
            objBCatDiclist.Initialize()
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
                    If Not objBCatDiclist Is Nothing Then
                        objBCatDiclist.Dispose(True)
                        objBCatDiclist = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace