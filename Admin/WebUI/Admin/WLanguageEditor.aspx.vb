Imports System.IO
Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WLanguageEditor
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
        Private intFileID As Integer
        Private arrAllFile() As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call BindData()
        End Sub
        Private Sub BindData()
            'Dim strPathXML As String = Server.MapPath((Request.ApplicationPath & "/Resources/LabelString")) ' "C:\Inetpub\wwwroot\Libol60\Resources\LabelString"
            Dim strPathXML = Server.MapPath("..") & "/Resources/LabelString"
            Dim tblLabel As DataTable
            Dim tblAllLabel As New DataTable
            Dim rowLabel As DataRow
            Dim i As Integer
            Dim j As Integer
            Dim strLanguage As String = ddlLanguage.SelectedValue
            Dim strFileName As String = ""

            'format collumns
            Dim myColumn1 As DataColumn = New DataColumn
            myColumn1.DataType = System.Type.GetType("System.String")
            myColumn1.ColumnName = "namelabel"
            tblAllLabel.Columns.Add(myColumn1)

            Dim myColumn2 As DataColumn = New DataColumn
            myColumn2.DataType = System.Type.GetType("System.String")
            myColumn2.ColumnName = "vietnamese"
            tblAllLabel.Columns.Add(myColumn2)

            Dim myColumn3 As DataColumn = New DataColumn
            myColumn3.DataType = System.Type.GetType("System.String")
            myColumn3.ColumnName = "LangTran"
            tblAllLabel.Columns.Add(myColumn3)

            Dim myColumn4 As DataColumn = New DataColumn
            myColumn4.DataType = System.Type.GetType("System.String")
            myColumn4.ColumnName = "FilePath"
            tblAllLabel.Columns.Add(myColumn4)


            If Request("FormID") & "" <> "" Then
                strPathXML = Request("FormID")
            End If

            intFileID = 0
            Call GetNameFileXml(strPathXML)
            Dim intDem As Integer = 0
            For i = 0 To arrAllFile.Length - 1
                tblLabel = GetXmlFile(arrAllFile(i))
                If Not tblLabel Is Nothing AndAlso tblLabel.Rows.Count > 0 Then
                    For j = 0 To tblLabel.Rows.Count - 1
                        rowLabel = tblAllLabel.NewRow
                        rowLabel("namelabel") = "<a name='" & CStr(intDem) & "'>" & tblLabel.Rows(j).Item("name") & "</a>"
                        'rowLabel("vietnamese") = CStr(tblLabel.Rows(j).Item("vie")).Replace("<", "&lt;").Replace(">", "&gt;")
                        'rowLabel("LangTran") = CStr(tblLabel.Rows(j).Item(strLanguage)).Replace("<", "&lt;").Replace(">", "&gt;")
                        Try
                            rowLabel("vietnamese") = CStr(tblLabel.Rows(j).Item("vie"))
                        Catch ex As Exception
                            rowLabel("vietnamese") = ""
                        End Try
                        rowLabel("LangTran") = CStr(tblLabel.Rows(j).Item(strLanguage))
                        'rowLabel("FilePath") = arrAllFile(i).Replace(strPathXML, "")
                        strFileName = Right(arrAllFile(i), Len(arrAllFile(i)) - (InStrRev(arrAllFile(i), "\")))
                        rowLabel("FilePath") = "<a href='WInterfaceLangMan.aspx?IndexRow=" & CStr(intDem) & "&Root=" & strPathXML & "&FormID=" & arrAllFile(i) & "'>" & strFileName & "</a>"
                        tblAllLabel.Rows.Add(rowLabel)
                        intDem = intDem + 1
                    Next
                End If
            Next
            ' Bind data for datagrid

            dtgLabel.Columns(2).HeaderText = ddlLanguage.SelectedItem.Text
            dtgLabel.DataSource = tblAllLabel
            Call dtgLabel.DataBind()
            ddlSort.Attributes.Add("onChange", "alert('Bạn phải trả tiền cho chức năng này! :D'); return false;")
            ddlLanguage.Attributes.Add("onChange", "alert('Chức năng này sẽ được hỗ trợ khi bạn phải đảm bảo tất cả các file xml đều có ngôn ngữ mình chọn!'); return false;")
        End Sub
        ' Method: GetFileXml
        Private Sub GetNameFileXml(ByVal strFoder As String)
            Dim objDirInforParent As DirectoryInfo
            Dim objDirInforSub As DirectoryInfo
            Dim objFileInfor As FileInfo

            objDirInforParent = New DirectoryInfo(strFoder)
            If objDirInforParent.GetFiles("*.xml").Length > 0 Then
                For Each objFileInfor In objDirInforParent.GetFiles("*.xml")
                    ReDim Preserve arrAllFile(intFileID)
                    arrAllFile(intFileID) = objFileInfor.FullName
                    intFileID = intFileID + 1
                Next
            End If
            If objDirInforParent.GetDirectories.Length > 0 Then
                For Each objDirInforSub In objDirInforParent.GetDirectories
                    Call GetNameFileXml(objDirInforSub.FullName)
                Next
            End If
        End Sub
        ' Method: GetXmlFile
        ' Purpose: Get content file type .xml return DataTable.
        Public Function GetXmlFile(ByVal strFileNameXml As String) As DataTable
            Dim dsResource As New DataSet
            Try
                dsResource.ReadXml(strFileNameXml)
                If dsResource.Tables.Count > 0 Then
                    GetXmlFile = dsResource.Tables(0)
                    dsResource.Tables.Clear()
                End If
            Catch ex As Exception
            End Try
        End Function

        Private Sub dtgLabel_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgLabel.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim txtTempVie As TextBox
                    Dim txtTempOther As TextBox
                    Dim strLabel As String
                    txtTempVie = CType(e.Item.FindControl("txtdtgVie"), TextBox)
                    txtTempOther = CType(e.Item.FindControl("txtdtgLangTran"), TextBox)
                    strLabel = DataBinder.Eval(e.Item.DataItem, "vietnamese")
                    If strLabel.Length < 40 Then
                        'txtTemp.Height = Unit.Pixel(30)
                        txtTempVie.TextMode = TextBoxMode.SingleLine
                        txtTempOther.TextMode = TextBoxMode.SingleLine
                    End If
                    If strLabel.Length >= 40 And strLabel.Length < 200 Then
                        txtTempVie.Height = Unit.Pixel(strLabel.Length)
                        txtTempOther.Height = Unit.Pixel(strLabel.Length)
                    End If
                    If strLabel.Length >= 200 And strLabel.Length < 300 Then
                        txtTempVie.Height = Unit.Pixel(150)
                        txtTempOther.Height = Unit.Pixel(150)
                    End If
                    If strLabel.Length >= 300 Then
                        txtTempVie.Height = Unit.Pixel(200)
                        txtTempOther.Height = Unit.Pixel(200)
                    End If
            End Select
        End Sub
    End Class
End Namespace