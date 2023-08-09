' Class: WShowSchema
' Puspose: process location
' Creator: lent
' CreatedDate: 17-2-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WShowShelfSchema
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
        Private objBLocation As New clsBLocation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Dim strTop As String = "0"
            Dim strLeft As String = "0"
            Dim strIndex As String = ""

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WShelfPos.js'></script>")

            btnClose.Attributes.Add("Onclick", "javascript:self.close();")
            btnAccept.Attributes.Add("Onclick", "javascript:return(CalLeftTop('" & ddlLabelNote.Items(0).Text & "','" & ddlLabelNote.Items(1).Text & "'));")

            If Request("imgShelfSchema.x") & "" <> "" Then
                strLeft = Request("imgShelfSchema.x")
                strTop = Request("imgShelfSchema.y")
                txtLeftCoor.Text = strLeft
                txtTopCoor.Text = strTop
                Page.RegisterClientScriptBlock("SetLeftTop", "<script language='javascript'>SetLeftTopCoor(" & strTop & "," & strLeft & ");self.close();</script>")
            End If
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim intLocID As Integer = 0
            Dim tblResult As DataTable

            If Request("LocID") & "" <> "" Then
                intLocID = CInt(Request("LocID"))
            End If
            objBLocation.LibID = 0
            objBLocation.LocID = intLocID
            objBLocation.UserID = Session("UserID")
            tblResult = objBLocation.GetHoldingLocSchema("")
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                If Not IsDBNull(tblResult.Rows(0).Item("LocID")) Then
                    hidImgWidth.Value = CInt(tblResult.Rows(0).Item("ImgWidth"))
                    hidImgHeight.Value = CInt(tblResult.Rows(0).Item("ImgHeight"))
                    hidTopCoor.Value = CInt(tblResult.Rows(0).Item("TopCoor"))
                    hidLeftCoor.Value = CInt(tblResult.Rows(0).Item("LeftCoor"))
                    hidImgHeightMetter.Value = CDbl(tblResult.Rows(0).Item("ImgHeightMetter"))
                    hidImgWidthMetter.Value = CDbl(tblResult.Rows(0).Item("ImgWidthMetter"))

                    imgShelfSchema.Src = "WShowLoc.aspx?LocID=" & CStr(intLocID) & "&x=" & GenRandomNumber(10)
                Else
                    lblNoSchema.Visible = True
                    imgShelfSchema.Visible = False
                End If
            Else
                lblNoSchema.Visible = True
                imgShelfSchema.Visible = False
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace