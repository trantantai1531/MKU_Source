' class WHoldingLocRemoved
' Puspose: print information liquidate process
' Creator: Lent
' CreatedDate: 3-3-2005
' Modification History:

Imports System
Imports System.IO
Imports System.IO.File
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WHoldingLocRemoved
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
        Private objBHoldingRemove As New clsBHoldingRemove

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If

        End Sub
        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBHoldingRemove object
            objBHoldingRemove.DBServer = Session("DBServer")
            objBHoldingRemove.ConnectionString = Session("ConnectionString")
            objBHoldingRemove.InterfaceLanguage = Session("InterfaceLanguage")
            objBHoldingRemove.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WHoldingLocRemove.js'></script>")
        End Sub

        Private Sub BindData()
            Dim strPath As String
            Dim strListCopyNum As String = ""
            Dim strArrCopyNum() As String
            Dim strArrCopyNums() As String
            Dim inti As Integer
            Dim intk As Integer = 0
            Dim intLengCopyNum = 50 'number of copynumber for update
            Dim strItemCode As String = ""
            Dim strFileName As String = ""
            Dim intTotalItem As Integer = 0
            Dim intOnLoan As Integer = 0
            Dim intReasonID As Integer = 0
            Dim strRemovedDate As String = ""

            'Get infomation from form submit
            If Request("rdbGroupName") & "" = "rdbCodeDoc" Then
                strItemCode = Trim(Request("txtCodeDoc"))
            Else
                If Request("rdbGroupNameCN") & "" = "rdbCopyNumFile" Then
                    'get from file
                    strPath = Server.MapPath("")
                    strListCopyNum = Trim(ReadFromFile(strPath & "\tmp.txt"))
                Else
                    strListCopyNum = Trim(Request("txtCopyNumManual"))
                End If
            End If
            intReasonID = CInt(Request("ddlReason"))
            strRemovedDate = Trim(Request("txtDateRemove"))

            'binddata to result form
            lblLibName.Text = lblLibName.Text & Request("hidLibName")
            lblLocName.Text = lblLocName.Text & Request("hidLocName")

            If strFileName <> "" Then
                'get from file
                strPath = Server.MapPath("")
                strListCopyNum = Trim(ReadFromFile(strPath & "\tmp.txt"))
            End If
            'repair strListCopyNum
            If strListCopyNum <> "" Then
                strListCopyNum = strListCopyNum.Replace(Chr(10), "")
                strListCopyNum = strListCopyNum.Replace(Chr(13), ",")
                strListCopyNum = strListCopyNum.Replace(Chr(9), ",")
                strListCopyNum = strListCopyNum.Replace(";", ",")
                If Right(strListCopyNum, 1) = "," Then
                    strListCopyNum = Left(strListCopyNum, Len(strListCopyNum) - 1)
                End If
                strArrCopyNum = Split(strListCopyNum, ",")
                strListCopyNum = ""

                'gen strArrCopyNums
                intTotalItem = strArrCopyNum.Length
                For inti = 0 To strArrCopyNum.Length - 1
                    strListCopyNum = strListCopyNum & "'" & strArrCopyNum(inti) & "',"
                    If inti + 1 >= (intk + 1) * intLengCopyNum Then
                        ReDim Preserve strArrCopyNums(intk)
                        strListCopyNum = Left(strListCopyNum, strListCopyNum.Length - 1)
                        strArrCopyNums(intk) = strListCopyNum
                        intk = intk + 1
                        strListCopyNum = ""
                    End If
                Next
                If inti > intk * intLengCopyNum Then
                    If (2 * (inti - intk * intLengCopyNum) >= intLengCopyNum) Or (intk = 0) Then
                        ReDim Preserve strArrCopyNums(intk)
                        strListCopyNum = Left(strListCopyNum, strListCopyNum.Length - 1)
                        strArrCopyNums(intk) = strListCopyNum
                    Else
                        strArrCopyNums(intk - 1) = strArrCopyNums(intk - 1) & "," & strListCopyNum
                    End If
                End If
            End If

            For inti = 0 To strArrCopyNums.Length - 1
                objBHoldingRemove.CopyNumbers = strArrCopyNums(inti)
                objBHoldingRemove.ItemCode = strItemCode
                objBHoldingRemove.ReasonID = intReasonID
                objBHoldingRemove.RemovedDate = strRemovedDate
                Call objBHoldingRemove.Liquidate()
                If strItemCode <> "" Then
                    intTotalItem = intTotalItem + objBHoldingRemove.TotalItem
                End If
                intOnLoan = intOnLoan + objBHoldingRemove.OnLoan
            Next
            lblTotalRemove.Text = lblTotalRemove.Text & CStr(intTotalItem)
            lblNumRemove.Text = lblNumRemove.Text & CStr(intTotalItem - intOnLoan)
            lblNumNoRemove.Text = lblNumNoRemove.Text & CStr(intOnLoan)
        End Sub
        '' Function Read File
        'Private Function ReadFromFile(ByVal filename As String) As String
        '    Dim FCoyNumber As File
        '    Dim FSCN As FileStream = FCoyNumber.OpenRead(filename)
        '    Dim SRCN As StreamReader = New StreamReader(FSCN)
        '    ReadFromFile = SRCN.ReadToEnd
        '    SRCN.Close()
        '    FSCN.Close()
        'End Function

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBHoldingRemove Is Nothing Then
                    objBHoldingRemove.Dispose(True)
                    objBHoldingRemove = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
