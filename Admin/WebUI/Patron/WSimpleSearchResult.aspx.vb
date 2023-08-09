Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WSimpleSearchResult
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
        Private objBPatron As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize  objBPatron  object
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatron.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim intID As Integer
            Dim tblData As New DataTable
            Dim arrData()
            arrData = Session("PatronIDs")
            If Request.QueryString("IndexID") & "" <> "" Then
                intID = arrData(CInt(Request.QueryString("IndexID")))
            Else
                If Not (arrData Is Nothing) Then
                    If UBound(arrData) > -1 Then
                        intID = CInt(arrData(0))
                    Else
                        intID = -1
                    End If
                Else
                    intID = -1
                End If
            End If
            If intID > -1 Then
                Try
                    objBPatron.PatronIDs = CStr(intID)
                    tblData = objBPatron.GetPatron

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)

                    If Not tblData Is Nothing And tblData.Rows.Count > 0 Then
                        '   If tblData.Rows.Count > 0 Then
                        lblFullName.Text = tblData.Rows(0).Item("FirstName").ToString.Trim & " " & tblData.Rows(0).Item("MiddleName").ToString.Trim & " " & tblData.Rows(0).Item("LastName").ToString.Trim
                        lblEthnic.Text = tblData.Rows(0).Item("Ethnic").ToString.Trim
                        lblDOB.Text = tblData.Rows(0).Item("DOB").ToString.Trim
                        If tblData.Rows(0).Item("sex") = 1 Then
                            lblSex.Text = ddlLabel.Items(2).Text
                        Else
                            lblSex.Text = ddlLabel.Items(3).Text
                        End If
                        lblEducation.Text = tblData.Rows(0).Item("EducationLevel").ToString.Trim
                        lblCode.Text = tblData.Rows(0).Item("Code").ToString.Trim
                        lblValidDate.Text = tblData.Rows(0).Item("LASTISSUEDDATE").ToString.Trim
                        lblExipredDate.Text = tblData.Rows(0).Item("EXPIREDDATE").ToString.Trim
                        lblGroup.Text = tblData.Rows(0).Item("Name").ToString.Trim
                        lblNote.Text = tblData.Rows(0).Item("Note").ToString.Trim
                        lblCollege.Text = tblData.Rows(0).Item("College").ToString.Trim
                        lblFaculty.Text = tblData.Rows(0).Item("Faculty").ToString.Trim
                        lblGrade.Text = tblData.Rows(0).Item("Grade").ToString.Trim
                        lblClass.Text = tblData.Rows(0).Item("Class").ToString.Trim
                        lblOccupation.Text = tblData.Rows(0).Item("Occupation").ToString.Trim
                        ''Email
                        lblEmail.Text = tblData.Rows(0).Item("Email").ToString.Trim
                        ''Facebook
                        lblFaceBook.Text = tblData.Rows(0).Item("Facebook").ToString.Trim
                        '' address
                        Dim strAddress As String = ""
                        Dim strCity As String = ""
                        Dim strAddressFull As String = ""
                        strAddress = tblData.Rows(0).Item("Address").ToString.Trim
                        strCity = tblData.Rows(0).Item("City").ToString.Trim
                        If strAddress <> "" Then
                            strAddressFull = strAddress
                            If strCity <> "" Then
                                strAddressFull = strAddressFull + ", " + strCity
                            End If
                        Else
                            If strCity <> "" Then
                                strAddressFull = strCity
                            End If
                        End If
                        'lblOtherAddress.Text = tblData.Rows(0).Item("Address").ToString.Trim
                        lblOtherAddress.Text = strAddressFull
                        lblTel.Text = tblData.Rows(0).Item("Telephone").ToString.Trim
                        'lblMobile.Text = tblData.Rows(0).Item("Mobile").ToString.Trim
                        lblIDCard.Text = tblData.Rows(0).Item("IDCard").ToString.Trim
                        If Not tblData.Rows(0).Item("Portrait").ToString.Trim = "" Then
                            Dim strURL As String = "../Images/Card/" & tblData.Rows(0).Item("Portrait").ToString.Trim()
                            imgPortrait.Src = strURL
                            imgPortrait.Width = 120
                            imgPortrait.Height = 160
                            'imgPortrait.Src = "../Common/ShowPic.aspx?intw=120&inth=160&Url=" & strURL
                        End If
                    Else
                        EmptyText()
                    End If
                Catch ex As Exception
                    EmptyText()
                Finally

                    tblData = Nothing
                End Try
                'Chinhnh modify 20080820
            Else
                EmptyText()
                'Het modify
            End If
        End Sub
        Sub EmptyText()
            lblFullName.Text = ""
            lblEthnic.Text = ""
            lblDOB.Text = ""
            lblSex.Text = ""
            lblEducation.Text = ""
            lblCode.Text = ""
            lblValidDate.Text = ""
            lblExipredDate.Text = ""
            lblGroup.Text = ""
            lblNote.Text = ""
            lblCollege.Text = ""
            lblFaculty.Text = ""
            lblGrade.Text = ""
            lblClass.Text = ""
            lblOccupation.Text = ""
            lblOtherAddress.Text = ""
            lblTel.Text = ""
            'lblMobile.Text = ""
            lblIDCard.Text = ""
            imgPortrait.Src = "../Images/Card/Empty.gif"
        End Sub
        ' Event: Page_Unload
        ' Purpose: Release all objects
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPatron Is Nothing Then
                objBPatron.Dispose(True)
                objBPatron = Nothing
            End If
        End Sub
    End Class
End Namespace