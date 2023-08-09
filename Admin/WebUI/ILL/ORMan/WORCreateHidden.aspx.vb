Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORCreateHidden
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
        Private objBPhyDelAddr As New clsBPhyDelAddress
        Private objBCDBS As New clsBCommonDBSystem
        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadLibraryInfor()
            Call LoadAddressInfor()
            Call LoadPatronInfor()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            If Request("ILLLibID") & "" <> "" Then
                ' Init for objBILLLibrary
                objBILLLibrary.InterfaceLanguage = Session("InterfaceLanguage")
                objBILLLibrary.DBServer = Session("DBServer")
                objBILLLibrary.ConnectionString = Session("ConnectionString")
                Call objBILLLibrary.Initialize()
            End If
            If Request("DelivModeID") & "" <> "" Or Request("BillDelivNameID") & "" <> "" Then
                ' Init for objBPhyDelAddr
                objBPhyDelAddr.InterfaceLanguage = Session("InterfaceLanguage")
                objBPhyDelAddr.DBServer = Session("DBServer")
                objBPhyDelAddr.ConnectionString = Session("ConnectionString")
                Call objBPhyDelAddr.Initialize()
            End If
            If Request("PatronCode") & "" <> "" Then
                ' Init for objBCDBS
                objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
                objBCDBS.DBServer = Session("DBServer")
                objBCDBS.ConnectionString = Session("ConnectionString")
                Call objBCDBS.Initialize()
            End If

        End Sub

        ' Method: LoadLibraryInfor
        Private Sub LoadLibraryInfor()
            If Request("ILLLibID") & "" = "" Then
                Exit Sub
            End If
            ' Declare variables
            Dim tblLibrary As DataTable
            Dim intLibID As Integer
            Dim strName As String = ""
            Dim strEmail As String = ""

            ' Check the library
            If IsNumeric(Request("ILLLibID")) Then
                intLibID = CInt(Request("ILLLibID"))
                objBILLLibrary.LibID = intLibID
                tblLibrary = objBILLLibrary.GetLib

                ' Check error
                Call WriteErrorMssg(objBILLLibrary.ErrorCode, objBILLLibrary.ErrorMsg)

                ' Get the data
                If Not tblLibrary Is Nothing Then
                    If tblLibrary.Rows.Count > 0 Then
                        ' Library Name
                        strName = tblLibrary.Rows(0).Item("LibraryName").ToString
                        ' Email Reply address
                        strEmail = tblLibrary.Rows(0).Item("EmailReplyAddress").ToString

                        Page.RegisterClientScriptBlock("LoadLibrary", "<script language='javascript'>parent.Workform.document.forms[0].txtLibName.value = '" & strName & "';parent.Workform.document.forms[0].txtEmailIP.value='" & strEmail & "';</script>")
                    End If
                End If
            End If
        End Sub

        ' Method: LoadAddress
        Private Sub LoadAddressInfor()
            ' Check the library
            Dim intLocID As Integer = 0
            Dim strJS As String = ""

            If Request("DelivModeID") & "" <> "" Then
                intLocID = Request("DelivModeID")
                Dim tblTemp As DataTable
                objBPhyDelAddr.ID = intLocID
                tblTemp = objBPhyDelAddr.GetPhyDelAddr()
                ' Get the data
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    If Not IsDBNull(tblTemp.Rows(0).Item("Address")) Then
                        strJS = "parent.Workform.document.forms[0].txtPostDelivName.value = '" & Replace(tblTemp.Rows(0).Item("Address"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("XAddress")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtPostDelivAddr.value = '" & Replace(tblTemp.Rows(0).Item("XAddress"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Street")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtPostDelivStreet.value = '" & Replace(tblTemp.Rows(0).Item("Street"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("POBox")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtPostDelivBox.value = '" & Replace(tblTemp.Rows(0).Item("POBox"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("City")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtPostDelivCity.value = '" & Replace(tblTemp.Rows(0).Item("City"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Region")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtPostDelivRegion.value = '" & Replace(tblTemp.Rows(0).Item("Region"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("CountryID")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].ddlDelivCountry.options.selectedIndex = 0;"
                        strJS = strJS & "for(i = 0; i < parent.Workform.document.forms[0].ddlDelivCountry.options.length; i++) {"
                        strJS = strJS & "   if (parent.Workform.document.forms[0].ddlDelivCountry.options[i].value == " & tblTemp.Rows(0).Item("CountryID") & ") {"
                        strJS = strJS & "      parent.Workform.document.forms[0].ddlDelivCountry.options.selectedIndex = i;"
                        strJS = strJS & "	   break;}}"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("PostCode")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtPostDelivCode.value = '" & Replace(tblTemp.Rows(0).Item("PostCode"), "'", "\'") & "';"
                    End If
                    Page.RegisterClientScriptBlock("LoadJSAddress", "<script language='javascript'>" & strJS & "</script>")
                End If
            End If

            If Request("BillDelivNameID") & "" <> "" Then
                intLocID = Request("BillDelivNameID")
                Dim tblTemp As DataTable
                objBPhyDelAddr.ID = intLocID
                tblTemp = objBPhyDelAddr.GetPhyDelAddr()
                ' Get the data
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    If Not IsDBNull(tblTemp.Rows(0).Item("XAddress")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtBillDelivAddr.value = '" & Replace(tblTemp.Rows(0).Item("XAddress"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Street")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtBillDelivStreet.value = '" & Replace(tblTemp.Rows(0).Item("Street"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("POBox")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtBillDelivBox.value = '" & Replace(tblTemp.Rows(0).Item("POBox"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("City")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtBillDelivCity.value = '" & Replace(tblTemp.Rows(0).Item("City"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Region")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtBillDelivRegion.value = '" & Replace(tblTemp.Rows(0).Item("Region"), "'", "\'") & "';"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("CountryID")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].ddlBillDelivCountry.options.selectedIndex = 0;"
                        strJS = strJS & "for(i = 0; i < parent.Workform.document.forms[0].ddlBillDelivCountry.options.length; i++) {"
                        strJS = strJS & "   if (parent.Workform.document.forms[0].ddlBillDelivCountry.options[i].value == " & tblTemp.Rows(0).Item("CountryID") & ") {"
                        strJS = strJS & "      parent.Workform.document.forms[0].ddlBillDelivCountry.options.selectedIndex = i;"
                        strJS = strJS & "	   break;}}"
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("PostCode")) Then
                        strJS = strJS & "parent.Workform.document.forms[0].txtBillDelivCode.value = '" & Replace(tblTemp.Rows(0).Item("PostCode"), "'", "\'") & "';"
                    End If
                    Page.RegisterClientScriptBlock("LoadJSAddress", "<script language='javascript'>" & strJS & "</script>")
                End If

            End If
        End Sub
        Private Sub LoadPatronInfor()
            If Request("PatronCode") & "" <> "" Then
                Dim strJS As String = "<script language='javascript'>"
                Dim tblTemp As DataTable
                If Session("DBServer") = "ORACLE" Then
                    objBCDBS.SQLStatement = "Select nvl(FirstName || ' ','') || nvl(MiddleName || ' ','') || nvl(LastName,'')  AS FullName,PatronGroupID AS PATGROUPID from Cir_tblPatron where upper(code)='" & Trim(Request("PatronCode")).ToUpper & "'"
                Else
                    objBCDBS.SQLStatement = "Select isnull(FirstName+' ','') + isnull(MiddleName+' ','') + isnull(LastName,'')  AS FullName,PatronGroupID AS PATGROUPID from Cir_tblPatron where code='" & Trim(Request("PatronCode")) & "'"
                End If
                tblTemp = objBCDBS.RetrieveItemInfor
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    strJS = strJS & "parent.Workform.document.forms[0].txtPatronName.value = '" & tblTemp.Rows(0).Item("FullName") & "';"
                    strJS = strJS & "parent.Workform.document.forms[0].ddlPatronGroup.options.selectedIndex = 0;"
                    strJS = strJS & "for(i = 0; i < parent.Workform.document.forms[0].ddlPatronGroup.options.length; i++) {"
                    strJS = strJS & "   if (parent.Workform.document.forms[0].ddlPatronGroup.options[i].value == " & tblTemp.Rows(0).Item("PATGROUPID") & ") {"
                    strJS = strJS & "      parent.Workform.document.forms[0].ddlPatronGroup.options.selectedIndex = i;"
                    strJS = strJS & "	   break;}}"
                Else
                    strJS &= "alert('" & ddlLabel.Items(0).Text & "');"
                    strJS &= "parent.Workform.document.forms[0].txtPatronCode.value = '';"
                    strJS &= "parent.Workform.document.forms[0].txtPatronCode.focus()"
                End If
                Page.RegisterClientScriptBlock("LoadJSPatronInfo", strJS & "</script>")
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
                If Not objBPhyDelAddr Is Nothing Then
                    objBPhyDelAddr.Dispose(True)
                    objBPhyDelAddr = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
