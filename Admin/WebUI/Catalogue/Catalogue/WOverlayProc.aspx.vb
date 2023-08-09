' WOverlayProc class
' Purpose: overlay content of the current item
' Creator: Oanhtn
' CreatedDate: 07/07/2004
' Modification history:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WOverlayProc
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

        ' Private objects
        Private objBInput As New clsBInput
        Private objBItem As New clsBItemCollection

        ' Page_Load event
        ' Purpose: call all method here
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call ImportRecord()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBItem
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()
        End Sub

        ' ImportRecord method
        ' Purpose: overlay content of the selected record
        Private Sub ImportRecord()
            Dim arrFieldName() As Object ' array value of FieldName
            Dim arrFieldValue() As Object ' array value of FieldValue
            Dim arrLabelStr() As Object
            Dim strJS As String = ""

            ' Set array of LabelString
            ReDim arrLabelStr(9)
            arrLabelStr(0) = lblLabel1.Text  '13
            arrLabelStr(1) = lblLabel2.Text '1
            arrLabelStr(2) = lblLabel3.Text '4
            arrLabelStr(3) = lblLabel4.Text '14
            arrLabelStr(4) = lblLabel5.Text '6
            arrLabelStr(5) = lblLabel6.Text '7
            arrLabelStr(6) = lblLabel7.Text '8
            arrLabelStr(7) = lblLabel8.Text '9
            arrLabelStr(8) = lblLabel9.Text '10

            Dim strLabel5 As String = lblLabel10.Text

            ' Import data
            Dim strDeliminator As String = Trim(Request("txtDeliminator"))
            Dim strDesignator As String = Trim(Request("txtDesignator"))
            Dim strExcludeFields As String = Trim(Request("txtExcludeFields"))
            Dim lngItemID As Long = CLng(Request("hidItemID"))
            Dim strItemCode As String = Request("txtItemCode")
            Dim strContent As String = Trim(Request("txtContent"))
            Dim intFormID As Integer = CInt(Request("hidFormID"))
            Dim lngCurrentID As Long = Request("hidCurrentID")
            Dim intCount As Integer = 0
            Dim intMaxNum As Integer

            objBInput.ItemCode = strItemCode
            strContent = Replace(strContent, Chr(10), "")
            If LCase(Request("Format")) = "tag" Then
                ' TaggedFormat
                If strDeliminator = "" Then
                    strDeliminator = " "
                End If
                Call objBInput.ParseTaggedRecord(Chr(13), strDeliminator, strContent, arrFieldName, arrFieldValue, strDesignator, False)
                ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
                arrFieldName(UBound(arrFieldName)) = "000"
                arrFieldValue(UBound(arrFieldValue)) = Request("txtLeader")
            Else
                ' Iso2709Format
                strContent = Replace(strContent, Chr(13), "")
                Call objBInput.ParseISORec(strContent, arrFieldName, arrFieldValue)
            End If
            If Not strExcludeFields = "" Then
                strExcludeFields = "," & Replace(strExcludeFields, " ", "") & ","
                intMaxNum = LBound(arrFieldName)
                For intCount = LBound(arrFieldName) To UBound(arrFieldName)
                    If InStr(strExcludeFields, "," & arrFieldName(intCount) & ",") = 0 Then
                        arrFieldName(intMaxNum) = arrFieldName(intCount)
                        arrFieldValue(intMaxNum) = arrFieldValue(intCount)
                        intMaxNum = intMaxNum + 1
                    End If
                Next
                ReDim Preserve arrFieldName(intMaxNum - 1)
                ReDim Preserve arrFieldValue(intMaxNum - 1)
            End If

            ' Overlay data
            objBInput.LabelStr = arrLabelStr
            objBInput.FieldName = arrFieldName
            objBInput.FieldValue = arrFieldValue
            If objBInput.Update(intFormID, 1) = 0 Then
                Response.Write(objBInput.ErrorMsg)
            Else
                ' Update Opac
                strItemCode = objBInput.CodeOut
                objBItem.Code = strItemCode
                objBItem.Field912Value = 0
                objBItem.UpdateOpacItem()
                strJS = strJS & "alert('" & strLabel5 & "');" & Chr(13)

                Call WriteLog(86, lblLabel11.Text & ": " & strItemCode, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Reload opener form
                If LCase(Request("hidStage")) = "view" Then
                    strJS = strJS & "parent.Sentform.document.forms[0].submit();" & Chr(13)
                ElseIf LCase(Request("hidStage")) = "modify" Then
                    strJS = strJS & "opener.top.main.Sentform.location.href=""WCataModify.aspx?ItemID=" & lngItemID & "&CurrentID=" & lngCurrentID & """;" & Chr(13)
                    strJS = strJS & "self.close();" & Chr(13)
                Else
                    strJS = strJS & "self.location.href = ""WOverlayForm.aspx"";" & Chr(13)
                End If
                Page.RegisterClientScriptBlock("LoadJS", "<script language = 'javascript'>" & strJS & "</script>")
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBInput Is Nothing Then
                        objBInput.Dispose(True)
                        objBInput = Nothing
                    End If
                    If Not objBItem Is Nothing Then
                        objBItem.Dispose(True)
                        objBItem = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace