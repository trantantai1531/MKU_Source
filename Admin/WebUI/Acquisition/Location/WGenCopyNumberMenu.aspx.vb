' Class: WGenCopyNumListF
' Puspose: process generation list copynumber
' Creator: lent
' CreatedDate: 21-2-2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WGenCopyNumberMenu
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
        Private objBCopyNumber As New clsBCopyNumber
        Private intCountPage As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call BindJS()
        End Sub

        ' Method: CheckPermission 
        ' Purpose: Check permission 
        Private Sub CheckPermission()
            If Not CheckPemission(120) Then
                Call WriteErrorMssg(ddlLabelNote.Items(2).Text)
            End If
        End Sub

        ' Method: Initialize 
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBCopyNumber object
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCopyNumber.Initialize()
        End Sub

        ' Method: BindJS 
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WGenCopyNumber.js'></script>")

            btnLastPage.Attributes.Add("onClick", "javascript:return(Prev('" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'))")
            btnNextPage.Attributes.Add("onClick", "javascript:return(Next(" & CStr(intCountPage) & ",'" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'))")

            ddlOrderBy.Attributes.Add("OnChange", "javascript:document.forms[0].hidOrderBy.value=this.value; GotoSubmit();")
        End Sub

        ' Method: BindData 
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intCopyNum1Page As Integer
            Dim strInforListCopyNum As String
            Dim arrInforListCopyNum() As String

            Try
                strInforListCopyNum = Session("InforListCopyNum")
                arrInforListCopyNum = strInforListCopyNum.Split(",")
                Session("InforListCopyNum") = Nothing

                ddlLibrary.Value = arrInforListCopyNum(0)
                ddlLocation.Value = arrInforListCopyNum(1)
                txtShelf.Value = arrInforListCopyNum(2)
                txttoCopyNum.Value = arrInforListCopyNum(3)
                txtfromCopyNum.Value = arrInforListCopyNum(4)
                txtCopyNum1Page.Value = arrInforListCopyNum(5)
                hidNameLocation.Value = arrInforListCopyNum(6)
                intCopyNum1Page = CInt(txtCopyNum1Page.Value)

                ' Get list of copynumbers
                If ddlLibrary.Value = "" Then
                    objBCopyNumber.LibID = 0
                Else
                    objBCopyNumber.LibID = ddlLibrary.Value
                End If
                If ddlLocation.Value = "" Then
                    objBCopyNumber.LocID = 0
                Else
                    objBCopyNumber.LocID = ddlLocation.Value
                End If
                objBCopyNumber.Shelf = txtShelf.Value
                objBCopyNumber.ToCopyNum = txttoCopyNum.Value
                objBCopyNumber.FromCopyNum = txtfromCopyNum.Value
                objBCopyNumber.Orderby = 0
                objBCopyNumber.OrderByDesc = 0
                tblResult = objBCopyNumber.GenListCopyNumber
                Session("tblListCopynumber") = tblResult
                'Write error
                Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBCopyNumber.ErrorMsg, ddlLabelNote.Items(1).Text, objBCopyNumber.ErrorCode)

                If Not tblResult Is Nothing Then
                    intCountPage = CInt(tblResult.Rows.Count / intCopyNum1Page)
                    If intCountPage * intCopyNum1Page < tblResult.Rows.Count Then
                        intCountPage = intCountPage + 1
                    End If
                End If
                lblIndexPage1.Text = lblIndexPage1.Text & " " & CStr(intCountPage)
            Catch ex As Exception ' error occured
                Call WriteErrorMssg(ddlLabelNote.Items(0).Text, ex.Message.Trim, ddlLabelNote.Items(1).Text, 0)
            End Try
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose 
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace