' class  WPatronInLibrary
' Puspose: Tim ban doc dang trong thu vien
' Creator: Tuanhv
' CreatedDate: 20/08/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPatronInLibrary
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents DgdGetPatronInLib As System.Web.UI.WebControls.DataGrid


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
            Call BindScript()
            Call BindDataPatronInLib()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        ' Method: BindDataPatronInLib
        ' Purpose: Bind PatronInLib
        Private Sub BindDataPatronInLib()
            ' Declare variables
            Dim tblPatronInLibrary As DataTable
            Dim intIndex1 As Integer
            Dim intIndex2 As Integer
            Dim strPatronCode As String
            Dim strPatronID As String
            Dim strPatronFullName As String
            Dim strCopyNumber As String
            Dim strNumberItems As String
            Dim intRow As Integer
            Dim tblData As New DataTable
            Dim tblRow As DataRow

            tblData.Columns.Add("ID", Type.GetType("System.String"))
            tblData.Columns.Add("PatronCode", Type.GetType("System.String"))
            tblData.Columns.Add("FullName", Type.GetType("System.String"))
            tblData.Columns.Add("NumberItems", Type.GetType("System.String"))
            tblData.Columns.Add("CopyNumber", Type.GetType("System.String"))

            ' Show datagrid
            tblPatronInLibrary = objBPatron.GetPatronInLib
            If Not tblPatronInLibrary Is Nothing Then
                If tblPatronInLibrary.Rows.Count > 0 Then
                    intIndex1 = 0
                    intIndex2 = 1
                    intRow = 1
                    Dim arrCopy(tblPatronInLibrary.Rows.Count) As String
                    strNumberItems = CStr(intIndex2)
                    strCopyNumber = CStr(tblPatronInLibrary.Rows(intIndex1).Item("CopyNumber"))
                    'Khi so cot chi la mot
                    If tblPatronInLibrary.Rows.Count = 1 Then
                        tblRow = tblData.NewRow
                        tblRow(0) = CStr(intRow)
                        tblRow(1) = CStr(tblPatronInLibrary.Rows(intIndex1).Item("Code"))
                        tblRow(2) = CStr(tblPatronInLibrary.Rows(intIndex1).Item("FullName"))
                        tblRow(3) = strNumberItems
                        tblRow(4) = arrCopy(intRow - 1)
                        intIndex1 = intIndex1 + 1
                        intRow = intRow + 1
                        tblData.Rows.Add(tblRow)
                        dgtResult.DataSource = tblData
                        dgtResult.DataBind()
                    Else
                        While (intIndex1 < tblPatronInLibrary.Rows.Count - 1)
                            strPatronCode = CStr(tblPatronInLibrary.Rows(intIndex1).Item("Code"))
                            strPatronFullName = CStr(tblPatronInLibrary.Rows(intIndex1).Item("FullName"))
                            strNumberItems = CStr(intIndex2)
                            strCopyNumber = CStr(tblPatronInLibrary.Rows(intIndex1).Item("CopyNumber"))
                            If tblPatronInLibrary.Rows(intIndex1).Item("PatronID") = tblPatronInLibrary.Rows(intIndex1 + 1).Item("PatronID") Then
                                intIndex1 = intIndex1 + 1
                                intIndex2 = intIndex2 + 1
                                arrCopy(intRow - 1) = strCopyNumber + "," + arrCopy(intRow - 1)
                            Else
                                arrCopy(intRow - 1) = strCopyNumber + "," + arrCopy(intRow - 1)
                                arrCopy(intRow - 1) = Left(arrCopy(intRow - 1), Len(arrCopy(intRow - 1)) - 1)
                                tblRow = tblData.NewRow
                                tblRow(0) = CStr(intRow)
                                tblRow(1) = CStr(tblPatronInLibrary.Rows(intIndex1).Item("Code"))
                                tblRow(2) = CStr(tblPatronInLibrary.Rows(intIndex1).Item("FullName"))
                                tblRow(3) = strNumberItems
                                intIndex2 = 1
                                tblRow(4) = arrCopy(intRow - 1)
                                intIndex1 = intIndex1 + 1
                                intRow = intRow + 1
                                tblData.Rows.Add(tblRow)
                            End If
                        End While
                    End If

                    intIndex1 = intIndex1 - 1
                    arrCopy(intRow - 1) = CStr(tblPatronInLibrary.Rows(intIndex1).Item("CopyNumber")) + "," + arrCopy(intRow - 1)
                    arrCopy(intRow - 1) = Left(arrCopy(intRow - 1), Len(arrCopy(intRow - 1)) - 1)
                    tblRow = tblData.NewRow
                    tblRow(0) = CStr(intRow)
                    tblRow(1) = CStr(tblPatronInLibrary.Rows(intIndex1).Item("Code"))
                    tblRow(2) = CStr(tblPatronInLibrary.Rows(intIndex1).Item("FullName"))
                    tblRow(3) = strNumberItems
                    intIndex2 = 1
                    tblRow(4) = arrCopy(intRow - 1)
                    intIndex1 = intIndex1 + 1
                    intRow = intRow + 1
                    tblData.Rows.Add(tblRow)

                    dgtResult.DataSource = tblData
                    dgtResult.DataBind()
                End If
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
