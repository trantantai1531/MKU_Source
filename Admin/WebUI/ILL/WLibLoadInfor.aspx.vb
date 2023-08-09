Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WLibLoadInfor
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
        Private objBILLLibrary As New clsBILLLibrary

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call LoadLibraryInfor()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init for objBILLLibrary
            objBILLLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLLibrary.DBServer = Session("DBServer")
            objBILLLibrary.ConnectionString = Session("ConnectionString")
            Call objBILLLibrary.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WLibLoadInfor.js'></script>")
        End Sub

        ' Method: LoadLibraryInfor
        Private Sub LoadLibraryInfor()
            ' Declare variables
            Dim tblLibrary As DataTable
            Dim intIllLibID As Integer
            Dim strLibrarySymbol As String
            Dim strName As String
            Dim strEmail As String
            Dim strPhone As String
            Dim strCode As String
            Dim strNote As String
            Dim strEDelivMode As String
            Dim strEDelivTSAddr As String
            Dim strPostDelivName As String
            Dim strPostDelivXAddr As String
            Dim strPostDelivStreet As String
            Dim strPostDelivBox As String
            Dim strPostDelivCity As String
            Dim strPostDelivRegion As String
            Dim strPostDelivCountry As String
            Dim strPostDelivCode As String
            Dim strBillEDelivMode As String
            Dim strBillDelivName As String
            Dim strBillDelivXAddr As String
            Dim strBillDelivStreet As String
            Dim strBillDelivBox As String
            Dim strBillDelivCity As String
            Dim strBillDelivRegion As String
            Dim strBillDelivCountry As String
            Dim strBillDelivCode As String
            Dim strEncodingScheme As String

            ' Check the library
            If IsNumeric(Request("LibID")) Then
                intIllLibID = CInt(Request("LibID"))
                objBILLLibrary.IllLibID = intIllLibID
                tblLibrary = objBILLLibrary.GetLib(-1)

                ' Check error
                Call WriteErrorMssg(objBILLLibrary.ErrorCode, objBILLLibrary.ErrorMsg)

                ' Get the data
                If Not tblLibrary Is Nothing Then
                    If tblLibrary.Rows.Count > 0 Then
                        ' Library Symbol
                        strLibrarySymbol = tblLibrary.Rows(0).Item("LibrarySymbol").ToString.Replace("'", "\'")
                        ' Library Name
                        strName = tblLibrary.Rows(0).Item("LibraryName").ToString.Replace("'", "\'")
                        ' Email Reply address
                        strEmail = tblLibrary.Rows(0).Item("EmailReplyAddress").ToString.Replace("'", "\'")
                        ' Telephone
                        strPhone = tblLibrary.Rows(0).Item("Telephone").ToString.Replace("'", "\'")
                        ' Code
                        strCode = tblLibrary.Rows(0).Item("Code").ToString.Replace("'", "\'")
                        ' Note
                        strNote = tblLibrary.Rows(0).Item("Note").ToString.Replace("'", "\'")
                        ' Edeliv mode
                        strEDelivMode = tblLibrary.Rows(0).Item("EDelivMode").ToString.Replace("'", "\'")
                        ' Edeliv TS Address
                        strEDelivTSAddr = tblLibrary.Rows(0).Item("EDelivTSAddr").ToString.Replace("'", "\'")
                        ' Post Deliv Name
                        strPostDelivName = tblLibrary.Rows(0).Item("PostDelivName").ToString.Replace("'", "\'")
                        ' Post Deliv X Address
                        strPostDelivXAddr = tblLibrary.Rows(0).Item("PostDelivXAddr").ToString.Replace("'", "\'")
                        ' Post Deliv Street
                        strPostDelivStreet = tblLibrary.Rows(0).Item("PostDelivStreet").ToString.Replace("'", "\'")
                        ' Post Deliv Box
                        strPostDelivBox = tblLibrary.Rows(0).Item("PostDelivBox").ToString.Replace("'", "\'")
                        ' Post Deliv City
                        strPostDelivCity = tblLibrary.Rows(0).Item("PostDelivCity").ToString.Replace("'", "\'")
                        ' Post Deliv Region
                        strPostDelivRegion = tblLibrary.Rows(0).Item("PostDelivRegion").ToString.Replace("'", "\'")
                        ' Post Deliv Country
                        strPostDelivCountry = tblLibrary.Rows(0).Item("PostDelivCountry").ToString.Replace("'", "\'")
                        ' Post Deliv Code
                        strPostDelivCode = tblLibrary.Rows(0).Item("PostDelivCode").ToString.Replace("'", "\'")
                        ' Bill Deliv Name
                        strBillDelivName = tblLibrary.Rows(0).Item("BillDelivName").ToString.Replace("'", "\'")
                        ' Bill Deliv XAddr
                        strBillDelivXAddr = tblLibrary.Rows(0).Item("BillDelivXAddr").ToString.Replace("'", "\'")
                        ' Bill Deliv Street
                        strBillDelivStreet = tblLibrary.Rows(0).Item("BillDelivStreet").ToString.Replace("'", "\'")
                        ' Bill Deliv Box
                        strBillDelivBox = tblLibrary.Rows(0).Item("BillDelivBox").ToString.Replace("'", "\'")
                        ' Bill Deliv City
                        strBillDelivCity = tblLibrary.Rows(0).Item("BillDelivCity").ToString.Replace("'", "\'")
                        ' Bill Deliv Region
                        strBillDelivRegion = tblLibrary.Rows(0).Item("BillDelivRegion").ToString.Replace("'", "\'")
                        ' Bill Deliv Country
                        strBillDelivCountry = tblLibrary.Rows(0).Item("BillDelivCountry").ToString.Replace("'", "\'")
                        ' Bill Deliv Code
                        strBillDelivCode = tblLibrary.Rows(0).Item("BillDelivCode").ToString.Replace("'", "\'")
                        ' Encoding Scheme
                        strEncodingScheme = tblLibrary.Rows(0).Item("EncodingScheme").ToString.Replace("'", "\'")
                        ' Load the library infor to the main frame

                        Page.RegisterClientScriptBlock("LoadLibrary", "<script language='javascript'>LoadPatronInfor('" & strLibrarySymbol & _
                        "','" & strName & "','" & strEmail & "','" & strPhone & "','" & strCode & "','" & strNote & _
                        "','" & strEDelivMode & "','" & strEDelivTSAddr & "','" & strPostDelivName & "','" & _
                        strPostDelivXAddr & "','" & strPostDelivStreet & "','" & strPostDelivBox & "','" & _
                        strPostDelivCity & "','" & strPostDelivRegion & "','" & strPostDelivCountry & "','" & _
                        strPostDelivCode & "','" & strBillDelivName & "','" & strBillDelivXAddr & "','" & _
                        strBillDelivStreet & "','" & strBillDelivBox & "','" & strBillDelivCity & "','" & _
                        strBillDelivRegion & "','" & strBillDelivCountry & "','" & _
                        strBillDelivCode & "','" & strEncodingScheme & "'," & CInt(tblLibrary.Rows(0).Item("LocalLib")) & "," & CInt(Request("Del")) & ");</script>")
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
                If Not objBILLLibrary Is Nothing Then
                    objBILLLibrary.Dispose(True)
                    objBILLLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
