' Purpose: process form
' Creator: Oanhtn
' Created Date: 26/04/2004
' Modification history:
'   - 07/05/04 by Oanhtn: merger two marcform
'       + Add two properties: intSouFormID, intDesFormID
'       + Add method: MergerForms to merger two marcform
'   - 03/06/2004 by Oanhtn: support authority data
'       + Modify all function to support authority data
'   - 12/07/2004 by Oanhtn: set textbox fields
'       + Add new property: strTextBoxFields
'       + Update two method: Create & Modify to resolve problem abowe
'   - 14/07/2004 by Oanhtn
'       + Add new method: GetTextAreaFields to get all textarea fields
'   - 27/07/2004 by Oanhtn: set default value (include indicator value)
'       + Modify two method: Create & Modify

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBForm
        Inherits clsBField

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Protected intFormID As Integer = 0
        Private strFormName As String = ""
        Private strCreator As String = ""
        Private strNote As String = ""
        Private strCreatedDate As String
        Private strLastModifiedDate As String
        Protected strFieldCodes As String = ""
        Private strFieldDefaultValues As String = ""
        Private strFieldIndicatorValues As String = ""
        Private strTextBoxFields As String = ""
        Private intSouFormID As Integer = 0
        Private intDesFormID As Integer = 0

        Private objDForm As New clsDForm
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' FormID property
        Public Property FormID() As Integer
            Get
                Return intFormID
            End Get
            Set(ByVal Value As Integer)
                intFormID = Value
            End Set
        End Property

        ' FormName property
        Public Property FormName() As String
            Get
                Return strFormName
            End Get
            Set(ByVal Value As String)
                strFormName = Value
            End Set
        End Property

        ' Creator property
        Public Property Creator() As String
            Get
                Return strCreator
            End Get
            Set(ByVal Value As String)
                strCreator = Value
            End Set
        End Property

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' LastModifiedDate property
        Public Property LastModifiedDate() As String
            Get
                Return strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property

        ' FieldCodes property
        Public Property FieldCodes() As String
            Get
                Return strFieldCodes
            End Get
            Set(ByVal Value As String)
                strFieldCodes = Value
            End Set
        End Property

        ' FieldDefaultValues property
        Public Property FieldDefaultValues() As String
            Get
                Return strFieldDefaultValues
            End Get
            Set(ByVal Value As String)
                strFieldDefaultValues = Value
            End Set
        End Property

        ' FieldIndicatorValues property
        Public Property FieldIndicatorValues() As String
            Get
                Return strFieldIndicatorValues
            End Get
            Set(ByVal Value As String)
                strFieldIndicatorValues = Value
            End Set
        End Property

        ' TextBoxFields property
        Public Property TextBoxFields() As String
            Get
                Return strTextBoxFields
            End Get
            Set(ByVal Value As String)
                strTextBoxFields = Value
            End Set
        End Property

        ' SouFormID property
        Public Property SouFormID() As Integer
            Get
                Return intSouFormID
            End Get
            Set(ByVal Value As Integer)
                intSouFormID = Value
            End Set
        End Property

        ' DesFormID property
        Public Property DesFormID() As Integer
            Get
                Return intDesFormID
            End Get
            Set(ByVal Value As Integer)
                intDesFormID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Overloads Sub Initialize()
            ' Init objDForm
            objDForm.DBServer = strDBserver
            objDForm.ConnectionString = strConnectionString
            Call objDForm.Initialize()

            ' Init objBField
            MyBase.DBServer = strDBserver
            MyBase.ConnectionString = strConnectionString
            Call MyBase.Initialize()

            ' Init objBCDBS
            objBCDBS.DBServer = strDBServer
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.ConnectionString = strConnectionString
            Call objBCSP.Initialize()
        End Sub

        ' Create method
        ' Purpose: Create new catalogue form
        ' Input: 
        Public Overloads Function Create() As Integer
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.FormName = objBCSP.ConvertItBack(strFormName)
                objDForm.Creator = objBCSP.ConvertItBack(strCreator)
                objDForm.Note = objBCSP.ConvertItBack(strNote)
                objDForm.FieldCodes = strFieldCodes
                objDForm.MandatoryFieldCodes = strMandatoryFieldCodes
                objDForm.FieldDefaultValues = objBCSP.ConvertItBack(strFieldDefaultValues)
                objDForm.TextBoxFields = strTextBoxFields
                objDForm.FieldIndicatorValues = strFieldIndicatorValues
                Call objDForm.Create()
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Modify method
        ' Purpose: Modify the selected catalogue form
        Public Overloads Sub Modify()
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.FormID = intFormID
                objDForm.FormName = Trim(objBCSP.ConvertItBack(strFormName))
                objDForm.Note = objBCSP.ConvertItBack(strNote)
                objDForm.FieldCodes = strFieldCodes
                objDForm.MandatoryFieldCodes = strMandatoryFieldCodes
                objDForm.TextBoxFields = strTextBoxFields
                objDForm.FieldDefaultValues = Trim(objBCSP.ConvertItBack(strFieldDefaultValues))
                objDForm.FieldIndicatorValues = strFieldIndicatorValues
                Call objDForm.Modify()
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Delete method
        ' Purpose: Delete the selected catalogue form
        Public Overloads Sub Delete()
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.FormID = intFormID
                Call objDForm.Delete()
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetFields method
        ' Purpose: Get all fields of the selected catalogue form
        Public Function GetFields() As DataTable
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.FormID = intFormID
                objDForm.Creator = objBCSP.ConvertItBack(strCreator)
                GetFields = objBCDBS.ConvertTable(objDForm.GetFields)
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetForms method
        ' Purpose: Get information of all catalogue forms
        ' Input: int value of FormID (if need)
        ' Output: datatable
        Public Function GetForms() As DataTable
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.FormID = intFormID
                GetForms = objBCDBS.ConvertTable(objDForm.GetForms)
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetForms method
        ' Purpose: merger some catalogue forms
        ' Input: two int value of sourceFormID, destinationFormID
        Public Sub MergerForms()
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.SouFormID = intSouFormID
                objDForm.DesFormID = intDesFormID
                Call objDForm.MergerForms()
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetFields method
        ' Purpose: Get all fields of the selected catalogue form
        Public Function GetFieldsToView() As DataTable
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.FCURL1 = strFCURL1
                objDForm.FCURL2 = strFCURL2
                objDForm.FCURL3 = strFCURL3
                objDForm.FCURL4 = strFCURL4
                objDForm.FCURL5 = strFCURL5
                objDForm.FCURL6 = strFCURL6
                objDForm.PickedFieldCodes = strPickedFieldCodes
                objDForm.MandatoryFieldCodes = strMandatoryFieldCodes
                objDForm.FormID = intFormID
                GetFieldsToView = objBCDBS.ConvertTable(objDForm.GetFieldsToView)
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetFieldsToView method
        ' Purpose: Get properties of all current picked fields
        ' Input: intIsAuthority, intFormID
        ' Creator: Sondp
        ' Output: Datatable result
        Public Function GetPickedFieldView() As DataTable
            Dim inti, intj As Integer
            Dim tblPickedField As DataTable
            Dim strFieldCode As String
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.PickedFieldCodes = strPickedFieldCodes
                objDForm.FormID = intFormID
                tblPickedField = objBCDBS.ConvertTable(objDForm.GetPickedFieldView)
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg
                If Not tblPickedField Is Nothing AndAlso tblPickedField.Rows.Count > 0 Then
                    For inti = 0 To tblPickedField.Rows.Count - 1
                        strFieldCode = tblPickedField.Rows(inti).Item("FieldCode")
                        If Len(strFieldCode) = 3 Then
                            tblPickedField.Rows(inti).Item("FCURL1") = "javascript:OpenWindow('WMarcFieldProperties.aspx?FieldCode=" & strFieldCode & "','WMarcFieldProperties',700,360,50,100);"
                            tblPickedField.Rows(inti).Item("txtIndicatorValue") = "<input type=""Text"" id=""txtFieldIndicators"" name=""txtFieldIndicators"" size=""7"" maxlength=""2"" value=""" & tblPickedField.Rows(inti).Item("txtIndicatorValue") & """>"
                            tblPickedField.Rows(inti).Item("txtFieldDefaultValue") = "<input type=""Text"" id=""txtFieldDefault"" name=""txtFieldDefault"" value=""" & tblPickedField.Rows(inti).Item("txtFieldDefaultValue") & """>"
                            If Not IsDBNull(tblPickedField.Rows(inti).Item("IsTextBox")) AndAlso CBool(tblPickedField.Rows(inti).Item("IsTextBox")) Then
                                tblPickedField.Rows(inti).Item("chkIsTextBox") = "<input type=""checkbox"" name=""chkIsTextBox"" id=""chkIsTextBox"" value=""" & strFieldCode & """ checked>"
                            Else
                                tblPickedField.Rows(inti).Item("chkIsTextBox") = "<input type=""checkbox"" name=""chkIsTextBox"" id=""chkIsTextBox"" value=""" & strFieldCode & """>"
                            End If
                            If Not IsDBNull(tblPickedField.Rows(inti).Item("Mandatory")) AndAlso CBool(tblPickedField.Rows(inti).Item("Mandatory")) Then
                                If CBool(tblPickedField.Rows(inti).Item("NotDelete")) Then
                                    tblPickedField.Rows(inti).Item("chkMandatoryField") = "<input type=""checkbox"" name=""chkMandatoryFieldCode"" id=""chkMandatoryFieldCode"" value=""" & strFieldCode & """ checked disabled=true>"
                                Else
                                    tblPickedField.Rows(inti).Item("chkMandatoryField") = "<input type=""checkbox"" name=""chkMandatoryFieldCode"" id=""chkMandatoryFieldCode"" value=""" & strFieldCode & """ checked>"
                                End If
                            Else
                                tblPickedField.Rows(inti).Item("chkMandatoryField") = "<input type=""checkbox"" name=""chkMandatoryFieldCode"" id=""chkMandatoryFieldCode"" value=""" & strFieldCode & """>"
                            End If
                            If CBool(tblPickedField.Rows(inti).Item("NotDelete")) Then
                                tblPickedField.Rows(inti).Item("chkPickedField") = "<input type=""checkbox"" name=""chkPickedFieldCode"" id=""chkPickedFieldCode"" value=""" & strFieldCode & """ disabled=true>"
                            Else
                                tblPickedField.Rows(inti).Item("chkPickedField") = "<input type=""checkbox"" name=""chkPickedFieldCode"" id=""chkPickedFieldCode"" value=""" & strFieldCode & """ onClick='OnCheckParent(this.value,this.checked);'>"
                            End If
                        Else
                            If tblPickedField.Rows(inti).Item("FieldCode") = "245$a" Then
                                tblPickedField.Rows(inti).Item("chkPickedField") = "<input type=""checkbox"" name=""chkPickedFieldCode"" id=""chkPickedFieldCode"" value=""" & strFieldCode & """ disabled=true>"
                            Else
                                tblPickedField.Rows(inti).Item("chkPickedField") = "<input type=""checkbox"" name=""chkPickedFieldCode"" id=""chkPickedFieldCode"" value=""" & strFieldCode & """>"
                            End If
                            strFieldCode = "&nbsp;&nbsp;&nbsp;&nbsp;" & strFieldCode
                            tblPickedField.Rows(inti).Item("FieldCode") = strFieldCode
                        End If
                    Next
                End If
                GetPickedFieldView = tblPickedField
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        ' GetTextAreaFields method
        ' Purpose: Get all textarea fields
        ' Input: intIsAuthority, intFormID
        ' Output: Datatable result
        Public Function GetTextAreaFields() As DataTable
            Try
                objDForm.IsAuthority = intIsAuthority
                objDForm.FormID = intFormID
                GetTextAreaFields = objDForm.GetTextAreaFields
                intErrorCode = objDForm.ErrorCode
                strErrorMsg = objDForm.ErrorMsg
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDForm Is Nothing Then
                        objDForm.Dispose(True)
                        objDForm = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace