Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class TypeWebUseful
        Inherits System.Web.UI.Page
        Private objBWebsite As New clsBCAT_WebsiteUseful
        Private objBType As New clsBCAT_Type

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call PhanLoai()
                Call BindData()
            End If
        End Sub

        Private Sub Initialize()
            ' init OPACItem object
            objBWebsite.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBWebsite.DBServer = Session("DBServer")
            objBWebsite.ConnectionString = Session("ConnectionString")
            objBWebsite.Initialize()

            objBType.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBType.DBServer = Session("DBServer")
            objBType.ConnectionString = Session("ConnectionString")
            objBType.Initialize()
        End Sub

        Public Sub BindData()
            Try
                Dim tblType As DataTable
                objBWebsite.id_L = DropDownList1.SelectedValue
                objBWebsite.NN = "vn"
                tblType = objBWebsite.CAT_WebsiteUseful_sl

                GridView1.DataSource = tblType
                GridView1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Public Sub PhanLoai()
            Try
                Dim tbType As DataTable
                objBType.NN = "vn"
                objBType.id_L = Request.QueryString.Get("id")
                tbType = objBType.CAT_Type_sl()

                DropDownList1.DataSource = tbType
                DropDownList1.DataTextField = "Loai"
                DropDownList1.DataValueField = "id"
                DropDownList1.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Public Sub Thong_bao(ByVal TB As String)
            Page.RegisterStartupScript("", "<script> alert('" & TB & "');  </script>")
        End Sub


        Public Shared Function Hot(ByVal TinhTrang As String) As String
            If Boolean.Parse(TinhTrang.ToString()) = True Then
                Return "<span style=""color: red""><strong>Hot</strong></span>"
            Else
                Return ""
            End If
        End Function

        Public Shared Function Status1(ByVal TinhTrang As Integer) As String
            If TinhTrang = 1 Then
                Return "<div class='smallButton tipS' original-title='Items đã hiện'><img src='images/tick.png' /></div>"
            Else
                Return "<div class='smallButton tipS' original-title='Items đã ẩn'><img src='images/hide.png' alt=''></div>"
            End If
        End Function

        Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged
            Call BindData()
        End Sub


        Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Dim lbID As String = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBWebsite.id = lbID
                        objBWebsite.CAT_WebsiteUseful_update_Status(0)
                        Call BindData()
                    End If
                Next
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Dim lbID As String = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBWebsite.CAT_WebsiteUseful_de(lbID.ToString())
                        Call BindData()
                    End If
                Next
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
            Dim lbID As String = ""
            Try
                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As HtmlInputCheckBox = DirectCast(row.FindControl("contract"), HtmlInputCheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        lbID = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBWebsite.id = lbID
                        objBWebsite.CAT_WebsiteUsefulupdate_Hot(0)
                    End If
                Next
                Call BindData()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
            Try
                For Each row As GridViewRow In GridView1.Rows
                    If row.RowIndex = e.RowIndex Then
                        Dim id As String = DirectCast(row.FindControl("lbl_id"), Label).Text
                        objBWebsite.CAT_WebsiteUseful_de(id.Trim())
                        Call BindData()
                    End If
                Next
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating

        End Sub
    End Class
End Namespace
