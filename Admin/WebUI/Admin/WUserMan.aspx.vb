Imports eMicLibAdmin.BusinessRules.Admin

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WUserMan
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

        Private objBUser As New clsBUser
        Private objBRole As New clsBRole

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call LoadUserInfor()
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBUser object
            objBUser.ConnectionString = Session("ConnectionString")
            objBUser.DBServer = Session("DBServer")
            objBUser.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBUser.Initialize()

            ' Init objBRole object
            objBRole.ConnectionString = Session("ConnectionString")
            objBRole.DBServer = Session("DBServer")
            objBRole.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRole.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WUserMan.js'></script>")
        End Sub

        ' LoadUserInfor method
        ' Purpose: get user information for showing
        Private Sub LoadUserInfor()
            Dim tblUser As DataTable
            Dim tblRights As DataTable
            Dim intUserID As Integer = 0
            Dim strName As String = ""
            Dim strUserName As String = ""
            Dim strSSCID As String = ""
            Dim strAcqModule As String = ""
            Dim strSerModule As String = ""
            Dim strCirModule As String = ""
            Dim strPatModule As String = ""
            Dim strCatModule As String = ""
            Dim strILLModule As String = ""
            Dim strDelModule As String = ""
            Dim strAdmModule As String = ""
            Dim strJS As String
            Dim strCirLocs As String = ""
            Dim strAcqLocs As String = ""
            Dim strSerLocs As String = ""
            Dim strRights As String = ""
            Dim strParentID As String = ""
            Dim intIndex As Integer = 0

            If Not Request.QueryString("UserID") Is Nothing Then
                intUserID = CInt(Request.QueryString("UserID"))
            End If

            If intUserID > 0 Then
                objBUser.UID = intUserID
                objBRole.ModuleID = 0
                objBRole.UID = intUserID
                tblUser = objBUser.GetUsers
                tblRights = objBRole.GetRights
                If Not tblUser Is Nothing Then
                    If tblUser.Rows.Count > 0 Then
                        objBUser.GetLocationInfor(strCirLocs, strSerLocs, strAcqLocs)
                        If Not tblRights Is Nothing Then
                            If tblRights.Rows.Count > 0 Then
                                For intIndex = 0 To tblRights.Rows.Count - 1
                                    strRights = strRights & tblRights.Rows(intIndex).Item(0) & ","
                                Next
                            End If
                        End If

                        ' Full Name
                        strName = tblUser.Rows(0).Item("Name").ToString.Replace("'", "\'")
                        ' User Name
                        strUserName = tblUser.Rows(0).Item("UserName").ToString.Replace("'", "\'")
                        ' ParentID
                        strParentID = tblUser.Rows(0).Item("ParentID").ToString
                        ' SSCID
                        strSSCID = tblUser.Rows(0).Item("SSCID").ToString

                        ' Acquisition rights
                        If CInt(tblUser.Rows(0).Item("AcqModule")) <> 0 Then
                            strAcqModule = "1"
                        Else
                            strAcqModule = "0"
                        End If

                        ' Serial rights
                        If CInt(tblUser.Rows(0).Item("SerModule")) <> 0 Then
                            strSerModule = "1"
                        Else
                            strSerModule = "0"
                        End If

                        ' Circulation rights
                        If CInt(tblUser.Rows(0).Item("CirModule")) <> 0 Then
                            strCirModule = "1"
                        Else
                            strCirModule = "0"
                        End If


                        ' Patron rights
                        If CInt(tblUser.Rows(0).Item("PatModule")) <> 0 Then
                            strPatModule = "1"
                        Else
                            strPatModule = "0"
                        End If

                        ' Catalogue rights
                        strCatModule = tblUser.Rows(0).Item("Priority").ToString

                        ' ILL rights
                        If CInt(tblUser.Rows(0).Item("ILLModule")) <> 0 Then
                            strILLModule = "1"
                        Else
                            strILLModule = "0"
                        End If

                        ' Delivery rights
                        If CInt(tblUser.Rows(0).Item("DELModule")) <> 0 Then
                            strDelModule = "1"
                        Else
                            strDelModule = "0"
                        End If

                        ' Admin rights
                        If CInt(tblUser.Rows(0).Item("AdmModule")) <> 0 Then
                            strAdmModule = "1"
                        Else
                            strAdmModule = "0"
                        End If


                        strJS = "<script language='javascript'>LoadUserInfor('" & intUserID & "','"
                        strJS = strJS & strName & "','" & strUserName & "','" & strParentID & "','" & strSSCID & "'," & _
                        strAcqModule & "," & strSerModule & "," & strCirModule & "," & strPatModule & "," & _
                        strCatModule & "," & strILLModule & "," & strDelModule & "," & strAdmModule & ",'" _
                        & strCirLocs & "','" & strAcqLocs & "','" & strSerLocs & "','" & strRights & "');</script>"
                        Page.RegisterClientScriptBlock("LoadUserInfor", strJS)
                    End If
                End If
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRole Is Nothing Then
                    objBRole.Dispose(True)
                    objBRole = Nothing
                End If
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace