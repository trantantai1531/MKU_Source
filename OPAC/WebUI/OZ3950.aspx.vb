Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OZ3950
        Inherits clsWBaseJqueryUI

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            'Call Initialize()
            Call BindJavascript()
            Call BindControl()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Session("zServer") = "" Then
                Session("zServer") = "z3950.loc.gov"
                Session("zPort") = "7090"
                Session("zDatabase") = "voyager"
            End If
        End Sub
        ' BindJavascript method
        ' Purpose: Include all neccessary javascript function
        Private Sub BindJavascript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'Common/eMicLibCommon.js'></script>")
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'JS/Z3950/OZ3950.js'></script>")
            'btnSearch.Attributes.Add("OnClick", "return(CheckForSubmit('" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(1).Text & "'));")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            lnkOServerList.NavigateUrl = "javascript:fnShowServerList();"
        End Sub
        ' BindControl method
        Private Sub BindControl()
            txtzServer.Value = Session("zServer")
            txtZPort.Value = Session("zPort")
            txtZDatabase.Value = Session("zDatabase")
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Try
                Dim colData As New Collection
                With colData
                    .Add(Request("txtzServer"), "txtzServer")
                    .Add(Request("txtZPort"), "txtZPort")
                    .Add(Request("txtZDatabase"), "txtZDatabase")
                    .Add(ddlFieldName1.SelectedValue, "ddlFieldName1")
                    .Add(ddlFieldName2.SelectedValue, "ddlFieldName2")
                    .Add(ddlFieldName3.SelectedValue, "ddlFieldName3")
                    .Add(txtFieldValue1.Value, "txtFieldValue1")
                    .Add(txtFieldValue2.Value, "txtFieldValue2")
                    .Add(txtFieldValue3.Value, "txtFieldValue3")
                    .Add(ddlOperator2.SelectedValue, "ddlOperator2")
                    .Add(ddlOperator3.SelectedValue, "ddlOperator3")
                    .Add(ddlLimit.SelectedValue, "ddlLimit")
                    Dim strDisplay As String = ""
                    If optMARC.Checked Then
                        strDisplay = optMARC.Value
                    ElseIf optISBD.Checked Then
                        strDisplay = optISBD.Value
                    Else
                        strDisplay = optSimple.Value
                    End If
                    .Add(strDisplay, "Display")
                End With
                Session("z3950Data") = colData
                Response.Redirect("OZ3950Show.aspx", False)
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace
