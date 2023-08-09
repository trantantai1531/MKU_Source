Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WAcqRequestHidden
        Inherits clsWBase

        ' Declare varibales
        Private objBItemCollection As New clsBItemCollection
        Private objBCommonStringProc As New clsBCommonStringProc

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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJScript()
            If Not Request("ID") & "" = "" Then
                Call LoadData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBAcqCommon
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()

            ' Init for objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.Initialize()
        End Sub

        ' BindJScript method
        ' Purpose: Bind JavaScript
        Private Sub BindJScript()
            Page.RegisterClientScriptBlock("Common", "<script language = 'Javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("CheckExistItem", "<script language = 'Javascript' src = '../js/po/WAcqRequestHidden.js'></script>")
        End Sub

        ' LoadData method
        ' Purpose: Load data to the main frame
        Private Sub LoadData()
            ' Declare variables
            Dim tblItem As New DataTable
            Dim dtvItem As New DataView
            Dim arrItemVal()
            Dim strISBN As String = ""
            Dim strISSN As String = ""
            Dim strAuthor As String = ""
            Dim strTitle As String = ""
            Dim strEdition As String = ""
            Dim strPublisher As String = ""
            Dim strPubYear As String = ""
            Dim strJS As String = ""
            Dim intIndex As Integer

            ' Get the Item field values
            If Not Request("ID") & "" = "" Then
                objBItemCollection.ItemID = CLng(Request("ID"))
                tblItem = objBItemCollection.GetItemInfor
                Call WriteErrorMssg(objBItemCollection.ErrorCode, objBItemCollection.ErrorMsg)
            End If

            ' Load data
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    For intIndex = 0 To tblItem.Rows.Count - 1
                        If Not IsDBNull(tblItem.Rows(intIndex).Item("FieldCode")) Then
                            Select Case CStr(tblItem.Rows(intIndex).Item("FieldCode"))
                                Case "020" ' ISBN
                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                        If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                            Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                            If Not arrItemVal(0) = "" Then
                                                strISBN = arrItemVal(0)
                                            End If
                                        End If
                                    End If
                                Case "022" ' ISSN
                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                        If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                            Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                            If Not arrItemVal(0) = "" Then
                                                strISSN = arrItemVal(0)
                                            End If
                                        End If
                                    End If
                                Case "100" ' Author
                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                        If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                            Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                            If Not arrItemVal(0) = "" Then
                                                strAuthor = arrItemVal(0)
                                            End If
                                        End If
                                    End If
                                Case "245" ' Title
                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                        If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                            Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                            If Not arrItemVal(0) = "" Then
                                                strTitle = arrItemVal(0)
                                            End If
                                        End If
                                    End If
                                Case "250" ' Edition
                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                        If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                            Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                            If Not arrItemVal(0) = "" Then
                                                strEdition = arrItemVal(0)
                                            End If
                                        End If
                                    End If
                                Case "260" ' Publisher and PubYear
                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                        If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                            Call objBCommonStringProc.ParseField("$b,$c", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                            If Not arrItemVal(0) = "" Then
                                                strPublisher = arrItemVal(0)
                                            End If
                                            If Not arrItemVal(1) = "" Then
                                                strPubYear = arrItemVal(1)
                                            End If
                                        End If
                                    End If
                            End Select
                        End If
                    Next
                End If
            End If

            strJS = "<script language='javascript'>"
            strJS = strJS & "LoadItemInfor('" & strISBN & "','"
            strJS = strJS & strISSN & "','"
            strJS = strJS & strAuthor & "','"
            strJS = strJS & strTitle & "','"
            strJS = strJS & strEdition & "','"
            strJS = strJS & strPublisher & "','"
            strJS = strJS & strPubYear & "');"
            strJS = strJS & "</script>"

            Page.RegisterClientScriptBlock("LoadItemInfor", strJS)
        End Sub

        ' Page_UnLoad event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                ' Call Dispose on your base class.
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace