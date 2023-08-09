' Class: WSetFieldShow
' Puspose: Set field to show in table mode
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WSetFieldShow
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSOpener", "<script language = 'javascript'>setOpener();</script>")
            Page.RegisterClientScriptBlock("WSetFieldShowJs", "<script language = 'javascript' src = 'js/WSetFieldShow.js'></script>")

            txtPageSize.Attributes.Add("OnChange", "if(!CheckInt(this,'" & ddlLabel.Items(3).Text & "')){this.focus();this.value='';}")

            btnSet.Attributes.Add("OnClick", "SetValueFieldShow('" & ddlLabel.Items(3).Text & "'); return false;")
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            If Request.QueryString("show") <> "" Then
                Dim arrData
                Dim item As ListItem
                Dim byti As Byte
                Dim blnexit As Boolean

                arrData = Split(Request.QueryString("show"), ",")
                For Each item In lstFieldShow.Items
                    byti = 0
                    blnexit = False
                    While (byti <= UBound(arrData) And (Not blnexit))
                        If item.Value.ToString = arrData(byti) Then
                            blnexit = True
                        Else
                            byti = byti + 1
                        End If
                    End While
                    If blnexit Then
                        item.Selected = True
                    End If
                Next
            End If
            txtPageSize.Text = Request.QueryString("pgsize")
        End Sub
    End Class
End Namespace