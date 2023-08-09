Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Common

    <WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
    Public Class AutoComplete
        Inherits System.Web.Services.WebService

        Private objBCatCommon As New clsBCatCommon

        <WebMethod()> _
        Public Function GetNothing(ByVal prefixText As String, ByVal count As Integer) As String()
            Return Nothing
            'Dim items As New List(Of String)
            'Return items.ToArray()
        End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListAll(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_All(prefixText, 10)
        '        Dim Fiels As String = ""
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function


        '    <WebMethod()> _
        'Public Function GetCompletionListRights(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Rights(prefixText, 10)
        '        Dim Fiels As String = "540"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListCoverage(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Coverage(prefixText, 10)
        '        Dim Fiels As String = "500"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListRelation(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Relation(prefixText, 10)
        '        Dim Fiels As String = "787"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListSource(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Source(prefixText, 10)
        '        Dim Fiels As String = "786"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListIdentifier(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Identifier(prefixText, 10)
        '        Dim Fiels As String = "856"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListFormat(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Format(prefixText, 10)
        '        Dim Fiels As String = "300"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListType(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Type(prefixText, 10)
        '        Dim Fiels As String = "655"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListDate(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_date(prefixText, 10)
        '        Dim Fiels As String = "260c"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        ' Public Function GetCompletionListDescription(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_Description(prefixText, 5)
        '        Dim Fiels As String = "520"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        '   Public Function GetCompletionListTitle(ByVal prefixText As String, ByVal count As Integer) As String()
        '        If (count = 0) Then
        '            count = 10
        '        End If
        '        Dim items As New List(Of String)
        '        Dim procs As New BusinessLayer.Acquisition
        '        'Dim _Title As IList = procs.Select_dictionary_title(prefixText, 10)
        '        Dim Fiels As String = "245"
        '        Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '        procs = Nothing
        '        If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '            items.Clear()
        '            Dim _str As String = ""
        '            For Each proc In _Title
        '                _str = clsCommon.CutWords(proc.ToString)
        '                items.Add(_str)
        '            Next
        '        End If
        '        Return items.ToArray()
        '    End Function

        '    <WebMethod()> _
        'Public Function GetCompletionListTag(ByVal prefixText As String, ByVal count As Integer) As String()
        '        Try
        '            If (count = 0) Then
        '                count = 10
        '            End If
        '            Dim items As New List(Of String)
        '            Dim procs As New BusinessLayer.Acquisition
        '            'Dim _Title As IList = procs.Select_dictionary_title(prefixText, 10)
        '            Dim Fiels As String = "920"
        '            Dim _Title As IList = procs.Select_dictionary_Autocomplete(Fiels, prefixText, 10)
        '            procs = Nothing
        '            If Not _Title Is Nothing AndAlso _Title.Count > 0 Then
        '                items.Clear()
        '                Dim _str As String = ""
        '                For Each proc In _Title
        '                    _str = clsCommon.CutWords(proc.ToString)
        '                    items.Add(_str)
        '                Next
        '            End If
        '            Return items.ToArray()
        '        Catch ex As Exception
        '            Stop
        '            Return Nothing
        '        End Try
    '    End Function


    <WebMethod()> _
    Public Function AutocompleteDictionary(ByVal prefixText As String, dicId As Integer) As String()
        Dim items As New List(Of String)
        Try
            Dim tbAuto As DataTable
            Call Initialize()
            With objBCatCommon
                .DicID = dicId
                .MethodSort = "ASC"
                .DicVal = prefixText
                .DicTop = 10
                tbAuto = .getAutocompleteDictionary
            End With
            If Not IsNothing(tbAuto) AndAlso tbAuto.Rows.Count > 0 Then
                Dim strDisplayEntry As String = ""
                Dim strID As String = ""
                items.Clear()
                For i As Integer = 0 To tbAuto.Rows.Count - 1
                    strDisplayEntry = ""
                    If Not IsNothing(tbAuto.Rows(i).Item("DisplayEntry")) Then
                        strDisplayEntry = tbAuto.Rows(i).Item("DisplayEntry").ToString
                    End If
                    strID = ""
                    If Not IsNothing(tbAuto.Rows(i).Item("ID")) Then
                        strID = tbAuto.Rows(i).Item("ID").ToString
                    End If
                    If strDisplayEntry <> "" Then
                        items.Add(String.Format("{0}@@@{1}", strDisplayEntry, strID))
                    End If
                Next
            End If
            Call Dispose(True)
        Catch ex As Exception
        End Try
        Return items.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompletionListAuthor(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim items As New List(Of String)
        Try
            If (count = 0) Then
                count = 10
            End If
            Dim tbAuto As DataTable
            Call Initialize()
            With objBCatCommon
                .DicID = 1
                .MethodSort = "ASC"
                .DicVal = prefixText
                .DicTop = 10
                tbAuto = .getAutocompleteDictionary
            End With
            If Not IsNothing(tbAuto) AndAlso tbAuto.Rows.Count > 0 Then
                Dim _str As String = ""
                items.Clear()
                For i As Integer = 0 To tbAuto.Rows.Count - 1
                    _str = clsWCommon.CutWords(tbAuto.Rows(i).Item("DisplayEntry").ToString)
                    items.Add(_str)
                Next
            End If
            Call Dispose(True)
        Catch ex As Exception
        End Try
        Return items.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCompletionListAuthorTest(ByVal prefixText As String) As String()
        Dim items As New List(Of String)
        Try
            Dim tbAuto As DataTable
            Call Initialize()
            With objBCatCommon
                .DicID = 1
                .MethodSort = "ASC"
                .DicVal = prefixText
                .DicTop = 10
                tbAuto = .getAutocompleteDictionary
            End With
            If Not IsNothing(tbAuto) AndAlso tbAuto.Rows.Count > 0 Then
                Dim _str As String = ""
                items.Clear()
                For i As Integer = 0 To tbAuto.Rows.Count - 1
                    _str = clsWCommon.CutWords(tbAuto.Rows(i).Item("DisplayEntry").ToString)
                    items.Add(String.Format("{0}-{1}", i & ". " & _str, _str))
                    'items.Add(_str)
                Next
            End If
            Call Dispose(True)
        Catch ex As Exception
        End Try
        Return items.ToArray()
    End Function


    <WebMethod()> _
    Public Function autoCompleteGetCompletionListAuthor(context As Telerik.Web.UI.RadAutoCompleteContext) As Telerik.Web.UI.AutoCompleteBoxData
        Dim dropDownData As New Telerik.Web.UI.AutoCompleteBoxData()

        Try
            Dim clientData As String = context("ClientData").ToString()
            Dim tbAuto As DataTable
            Call Initialize()
            With objBCatCommon
                .DicID = 1
                .MethodSort = "ASC"
                .DicVal = context.Text
                .DicTop = 10
                tbAuto = .getAutocompleteDictionary
            End With
            If Not IsNothing(tbAuto) AndAlso tbAuto.Rows.Count > 0 Then
                Dim items = New List(Of Telerik.Web.UI.AutoCompleteBoxItemData)()
                items = New List(Of Telerik.Web.UI.AutoCompleteBoxItemData)()


                For i As Integer = 0 To tbAuto.Rows.Count - 1
                    Dim itemData As New Telerik.Web.UI.AutoCompleteBoxItemData()
                    itemData.Text = clsWCommon.CutWords(tbAuto.Rows(i).Item("DisplayEntry").ToString)
                    itemData.Value = clsWCommon.CutWords(tbAuto.Rows(i).Item("DisplayEntry").ToString)

                    items.Add(itemData)
                Next
                dropDownData.Items = items.ToArray()
            End If
        Catch ex As Exception
        End Try
        Return dropDownData
    End Function

    ' InitializeForCallback method
    ' Purpose: Init all neccessary objects
    Public Sub Initialize()
        ' Init objBCSP object
        objBCatCommon.DBServer = clsWCommon.gAutoDBServer 'Session("DBServer")
        objBCatCommon.ConnectionString = clsWCommon.gAutoConnectionString ' Session("ConnectionString")
        objBCatCommon.InterfaceLanguage = clsWCommon.gInterfaceLanguage 'Session("InterfaceLanguage")
        objBCatCommon.Initialize()
    End Sub

    Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
        Try
            If Not objBCatCommon Is Nothing Then
                objBCatCommon.Dispose(True)
                objBCatCommon = Nothing
            End If
        Finally
            MyBase.Dispose()
            Call Dispose()
        End Try
    End Sub

        '<WebMethod()> _
        'Public Function GetCompletionListKeyword(ByVal prefixText As String, ByVal count As Integer) As String()
        '    If (count = 0) Then
        '        count = 10
        '    End If
        '    Dim items As New List(Of String)
        '    Dim procs As New BusinessLayer.Acquisition
        '    'Dim _Keyword As IList = procs.Select_dictionary_keyword_autocomplete(prefixText, "asc", 10)
        '    Dim _Keyword As IList = procs.Select_dictionary_keyword_autocomplete_contains(prefixText, "asc", 10)
        '    procs = Nothing
        '    If Not _Keyword Is Nothing AndAlso _Keyword.Count > 0 Then
        '        items.Clear()
        '        Dim strTemp As String = ""
        '        For Each proc In _Keyword
        '            If (strTemp <> proc.name.ToString.Trim) Then
        '                items.Add(proc.name.ToString.Trim)
        '            End If
        '            strTemp = proc.name.ToString.Trim
        '        Next
        '    End If
        '    Return items.ToArray()
        'End Function

        '<WebMethod()> _
        'Public Function GetCompletionListLanguage(ByVal prefixText As String, ByVal count As Integer) As String()
        '    If (count = 0) Then
        '        count = 10
        '    End If
        '    Dim items As New List(Of String)
        '    Dim procs As New BusinessLayer.Acquisition
        '    Dim _Language As IList = procs.Select_dictionary_language(prefixText, "asc", 10)
        '    procs = Nothing
        '    If Not _Language Is Nothing AndAlso _Language.Count > 0 Then
        '        items.Clear()
        '        For Each proc In _Language
        '            items.Add(proc.name.ToString)
        '        Next
        '    End If
        '    Return items.ToArray()
        'End Function

        '<WebMethod()> _
        'Public Function GetCompletionListPuslisher(ByVal prefixText As String, ByVal count As Integer) As String()
        '    If (count = 0) Then
        '        count = 10
        '    End If
        '    Dim items As New List(Of String)
        '    Dim procs As New BusinessLayer.Acquisition
        '    Dim _Puslisher As IList = procs.Select_dictionary_publisher(prefixText, "asc", 10)
        '    procs = Nothing
        '    If Not _Puslisher Is Nothing AndAlso _Puslisher.Count > 0 Then
        '        items.Clear()
        '        For Each proc In _Puslisher
        '            items.Add(proc.name.ToString)
        '        Next
        '    End If
        '    Return items.ToArray()
        'End Function

        Public Sub New()
        ' Init objBCatCommon object         
        End Sub
    End Class

