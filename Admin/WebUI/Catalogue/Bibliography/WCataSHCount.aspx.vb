Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Cataloguer
    Partial Class WCataSHCount
        Inherits clsWBase 'Web.UI.Page 'clsWBase

        Private objBLoanType As New clsBLoanType
        Private objBSH As New clsBCatDicSH
        Private objBItemType As New clsBCatDicItemType
        Private objBItem As New clsBItem
        Private objBCB As New clsBCommonBusiness
        Private objBUserLocation As New clsBUserLocation
        Private objBCDBS As New clsBCommonDBSystem
        Private objBFaculty As New clsBFaculty

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                rdTextSH.Checked = True
                rdDDLSH.Checked = False

                txtSH.CssClass = "lbTextBox enable-block"
                txtSH.Enabled = True

                ddlSH.CssClass = "disable-block"
                ddlSH.Enabled = False

                PanelDDLSH.Attributes.Add("style", "display:none")
                PanelTextSH.Attributes.Remove("style")

                Call BinDDl()
                Session("pageIndex") = 0
            End If
        End Sub
        Private Sub BindJS()
            btnAddSH.Attributes.Add("onclick", "OpenWindow('WAddKeyword.aspx', 'WAddKeyword',800,600,200,100)")
            rdTextSH.Attributes.Add("onclick", "Choise(1)")
            rdDDLSH.Attributes.Add("onclick", "Choise(2)")

            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabel.Items(2).Text)
        End Sub
        Private Sub Initialze()
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()

            objBSH.InterfaceLanguage = Session("InterfaceLanguage")
            objBSH.DBServer = Session("DBServer")
            objBSH.ConnectionString = Session("ConnectionString")
            Call objBSH.Initialize()

            objBItemType.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemType.DBServer = Session("DBServer")
            objBItemType.ConnectionString = Session("ConnectionString")
            Call objBItemType.Initialize()

            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()

            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            objBUserLocation.ConnectionString = Session("ConnectionString")
            objBUserLocation.DBServer = Session("DBServer")
            objBUserLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBUserLocation.Initialize()

            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()

            objBFaculty.ConnectionString = Session("ConnectionString")
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBFaculty.Initialize()
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
                If Not objBSH Is Nothing Then
                    objBSH.Dispose(True)
                    objBSH = Nothing
                End If
                If Not objBItemType Is Nothing Then
                    objBItemType.Dispose(True)
                    objBItemType = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBCB Is Nothing Then
                    objBCB.Dispose(True)
                    objBCB = Nothing
                End If
                If Not objBUserLocation Is Nothing Then
                    objBUserLocation.Dispose(True)
                    objBUserLocation = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBFaculty Is Nothing Then
                    objBFaculty.Dispose(True)
                    objBFaculty = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        Private Sub BinDDl()
            'keyword
            Dim tblKeyword As DataTable = objBSH.GetAllSHBibliography()
            'ddlKeyword.DataSource = tblKeyword
            'ddlKeyword.DataTextField = "DisplayEntry"
            'ddlKeyword.DataValueField = "ID"
            'ddlKeyword.DataBind()
            ddlSH.Items.Clear()
            ddlSH.Items.Add(New ListItem("Toàn bộ", "0"))
            If tblKeyword IsNot Nothing AndAlso tblKeyword.Rows.Count > 0 Then
                For Each row As DataRow In tblKeyword.Rows
                    ddlSH.Items.Add(New ListItem(row.Item("DisplayEntry").ToString(), row.Item("ID").ToString()))
                Next
            End If

            ddlSH.DataBind()

            'loantype
            Dim tblLoanType As DataTable = objBLoanType.GetLoanTypes()
            ddlLoanType.Items.Clear()
            ddlLoanType.Items.Add(New ListItem("Toàn bộ", "0"))
            If tblLoanType IsNot Nothing AndAlso tblLoanType.Rows.Count > 0 Then
                For Each row As DataRow In tblLoanType.Rows
                    ddlLoanType.Items.Add(New ListItem(row.Item("LoanType").ToString(), row.Item("ID").ToString()))
                Next
            End If
            ddlLoanType.DataBind()

            ddlItemType.Items.Clear()
            ddlItemType.Items.Add(New ListItem("Toàn bộ", "0"))

            'ItemType
            Dim tblItemType As DataTable = objBItemType.Retrieve()
            If tblItemType IsNot Nothing AndAlso tblItemType.Rows.Count > 0 Then
                Dim dataView As DataView = tblItemType.DefaultView()
                'dataView.RowFilter = "(TypeName <> '' OR TypeName <> NULL) AND (ID=1 OR ID=3 OR ID=9 OR ID=23 OR ID=32)"
                dataView.RowFilter = "(TypeName <> '' OR TypeName <> NULL)"
                tblItemType = dataView.ToTable()
                If tblItemType IsNot Nothing AndAlso tblItemType.Rows.Count > 0 Then
                    For Each row As DataRow In tblItemType.Rows
                        ddlItemType.Items.Add(New ListItem(row.Item("TypeName").ToString(), row.Item("ID").ToString()))
                    Next
                End If
            End If
            ddlItemType.DataBind()

            'AcqSource
            Dim tblAcqSource As DataTable = objBCB.GetAcqSources
            ddlAcqSource.Items.Clear()
            ddlAcqSource.Items.Add(New ListItem("Toàn bộ", "0"))
            If tblAcqSource IsNot Nothing AndAlso tblAcqSource.Rows.Count > 0 Then
                For Each row As DataRow In tblAcqSource.Rows
                    ddlAcqSource.Items.Add(New ListItem(row.Item("Source").ToString(), row.Item("ID").ToString()))
                Next
            End If
            ddlAcqSource.DataBind()

            Dim tblUserLocations As DataTable
            objBUserLocation.UserID = Session("UserID")
            tblUserLocations = objBUserLocation.GetUserLocations(2)
            ddlLocation.Items.Clear()
            ddlLocation.Items.Add(New ListItem("Toàn bộ", "0"))

            If Not tblUserLocations Is Nothing AndAlso tblUserLocations.Rows.Count > 0 Then
                For Each row As DataRow In tblUserLocations.Rows
                    ddlLocation.Items.Add(New ListItem(row.Item("LOCNAME").ToString(), row.Item("ID").ToString()))
                Next
                ddlLocation.DataBind()
            End If

            'Faculty
            Dim tblFaculty As DataTable = objBFaculty.GetFaculty
            ddlFaculty.Items.Clear()
            ddlFaculty.Items.Add(New ListItem("Toàn bộ", ""))
            If tblFaculty IsNot Nothing AndAlso tblFaculty.Rows.Count > 0 Then
                For Each row As DataRow In tblFaculty.Rows
                    ddlFaculty.Items.Add(New ListItem(row.Item("Faculty").ToString(), row.Item("Faculty").ToString()))
                Next
            End If
            ddlFaculty.DataBind()
        End Sub
        Private Sub ResultSearch(ByVal tblResult As DataTable, ByRef totalRecord As Integer, ByRef totalCopyNumber As Integer)
            Try
                Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                newColumn.DefaultValue = "1"
                tblResult.Columns.Add(newColumn)
                Dim indexRows As Integer = 1
                For Each rows As DataRow In tblResult.Rows
                    If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                        rows.Item("STT") = indexRows.ToString()
                        indexRows = indexRows + 1
                    End If
                Next

                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblResult, tblConvert, totalRecord, totalCopyNumber)

                dtgPolicy.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                dtgPolicy.DataSource = tblConvert
                dtgPolicy.DataBind()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable, ByRef totalRecord As Integer, ByRef totalCopyNumber As Integer)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then

                totalRecord = tblResult.Rows.Count

                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                'tblConvert.Columns.Add("CopyNumber")
                'tblConvert.Columns.Add("BarCode")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("NXB")
                tblConvert.Columns.Add("Publisher")
                tblConvert.Columns.Add("PublishYear")
                tblConvert.Columns.Add("Classification")
                tblConvert.Columns.Add("Specialized")
                tblConvert.Columns.Add("CountCopyNumber")
                tblConvert.Columns.Add("ItemType")
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim content245 As String = rows.Item("Content245").ToString()
                    Dim content082 As String = rows.Item("Content082").ToString()
                    Dim content260 As String = rows.Item("Content260").ToString()
                    Dim content691 As String = rows.Item("Content691").ToString()

                    Dim title As String = ""
                    Dim author As String = ""
                    Dim publisher As String = ""
                    Dim publishyear As String = ""
                    Dim classification As String = ""
                    Dim nxb As String = ""
                    Dim specialized As String = ""

                    Dim titleP As String = ""
                    Dim titleN As String = ""

                    If content245.Contains("$a") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                If split.Length >= 3 Then 'co $c hoac $n
                                    title = iSplit.Substring(1, iSplit.Length - 2).Trim()
                                Else 'chi co $a
                                    title = iSplit.Substring(1, iSplit.Length - 1).Trim()
                                End If
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$c") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "c" Then
                                author = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$b") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "b" Then
                                title = title & " : " & iSplit.Substring(1).Replace("/", "").Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$n") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "n" Then
                                title = title & " . " & iSplit.Substring(1).Replace("/", "").Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$p") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "p" Then
                                title = title & " , " & iSplit.Substring(1).Replace("/", "").Trim()
                                Exit For
                            End If
                        Next
                    End If

                    title = title.Replace(" . . ", " . ")
                    title = title.Replace(" , , ", " , ")

                    If content260.Contains("$c") Then
                        Dim split() As String = content260.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "c" Then
                                publishyear = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content260.Contains("$b") Then
                        Dim split() As String = content260.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "b" Then
                                publisher = iSplit.Substring(1, iSplit.Length - 2).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content260.Contains("$a") Then
                        Dim split() As String = content260.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                nxb = iSplit.Substring(1, iSplit.Length - 2).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content082.Contains("$a") Then
                        Dim split() As String = content082.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                classification = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content691.Contains("$a") Then
                        Dim split() As String = content691.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                specialized = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    Dim stt As String = rows.Item("STT")
                    'Dim strCopyNumber As String = rows.Item("CopyNumber").ToString()
                    'Dim barcode As String = rows.Item("BarCode") & ""
                    Dim strItemType As String = rows.Item("TypeName") & ""

                    Dim countCopyNumber As String = rows.Item("CountCopyNumber").ToString()

                    totalCopyNumber = totalCopyNumber + CType(countCopyNumber, Double)

                    dtRow.Item("STT") = stt
                    'dtRow.Item("CopyNumber") = strCopyNumber
                    'dtRow.Item("BarCode") = barcode
                    dtRow.Item("Title") = title
                    dtRow.Item("Author") = author
                    dtRow.Item("NXB") = nxb
                    dtRow.Item("Publisher") = publisher
                    dtRow.Item("PublishYear") = publishyear
                    dtRow.Item("Classification") = classification
                    dtRow.Item("Specialized") = specialized
                    dtRow.Item("CountCopyNumber") = countCopyNumber
                    dtRow.Item("ItemType") = strItemType

                    tblConvert.Rows.Add(dtRow)
                Next
            End If

        End Sub
        Private Sub ConvertTableExport(ByVal tblResult As DataTable, ByRef tblConvert As DataTable, ByRef totalRecord As Integer, ByRef totalCopyNumber As Integer)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then

                Dim countItemID As Integer = tblResult.AsEnumerable.GroupBy(Of Integer)(Function(x) x.Item("ID")).Count()

                totalRecord = countItemID
                totalCopyNumber = tblResult.Rows.Count

                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("NXB")
                tblConvert.Columns.Add("Publisher")
                tblConvert.Columns.Add("PublishYear")
                tblConvert.Columns.Add("Classification")
                tblConvert.Columns.Add("Specialized")
                tblConvert.Columns.Add("ItemType")
                tblConvert.Columns.Add("CountCopyNumber")
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim content245 As String = rows.Item("Content245").ToString()
                    Dim content082 As String = rows.Item("Content082").ToString()
                    Dim content260 As String = rows.Item("Content260").ToString()
                    Dim content691 As String = rows.Item("Content691").ToString()

                    Dim title As String = ""
                    Dim author As String = ""
                    Dim publisher As String = ""
                    Dim publishyear As String = ""
                    Dim classification As String = ""
                    Dim nxb As String = ""
                    Dim specialized As String = ""

                    Dim titleP As String = ""
                    Dim titleN As String = ""

                    If content245.Contains("$a") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                If split.Length >= 3 Then 'co $c hoac $n
                                    title = iSplit.Substring(1, iSplit.Length - 1).Trim()
                                Else 'chi co $a
                                    title = iSplit.Substring(1).Trim()
                                End If
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$c") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "c" Then
                                author = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$b") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "b" Then
                                title = title & " : " & iSplit.Substring(1).Replace("/", "").Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$n") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "n" Then
                                title = title & " . " & iSplit.Substring(1).Replace("/", "").Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content245.Contains("$p") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "p" Then
                                title = title & " , " & iSplit.Substring(1).Replace("/", "").Trim()
                                Exit For
                            End If
                        Next
                    End If

                    title = title.Replace(" . . ", " . ")
                    title = title.Replace(" , , ", " , ")

                    If content260.Contains("$c") Then
                        Dim split() As String = content260.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "c" Then
                                publishyear = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content260.Contains("$b") Then
                        Dim split() As String = content260.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "b" Then
                                publisher = iSplit.Substring(1, iSplit.Length - 1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content260.Contains("$a") Then
                        Dim split() As String = content260.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                nxb = iSplit.Substring(1, iSplit.Length - 1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content082.Contains("$a") Then
                        Dim split() As String = content082.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                classification = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content691.Contains("$a") Then
                        Dim split() As String = content691.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                specialized = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    Dim stt As String = rows.Item("STT")
                    Dim strItemType As String = rows.Item("TypeName") & ""
                    Dim strCountCopyNumber As String = rows.Item("CountCopyNumber") & ""

                    'Dim countCopyNumber As String = rows.Item("CountCopyNumber").ToString()

                    'totalCopyNumber = totalCopyNumber + CType(countCopyNumber, Double)

                    dtRow.Item("STT") = stt
                    dtRow.Item("Title") = title
                    dtRow.Item("Author") = author
                    dtRow.Item("NXB") = nxb
                    dtRow.Item("Publisher") = publisher
                    dtRow.Item("PublishYear") = publishyear
                    dtRow.Item("Classification") = classification
                    dtRow.Item("Specialized") = specialized
                    dtRow.Item("CountCopyNumber") = strCountCopyNumber
                    dtRow.Item("ItemType") = strItemType

                    tblConvert.Rows.Add(dtRow)
                Next
            End If

        End Sub

        Private Sub BindData(ByVal intKeywordId As Integer, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanType As Integer = 0)
            Try
                Dim yearFrom As Integer = CType(If(String.IsNullOrEmpty(txtYearFrom.Text), "0", txtYearFrom.Text), Integer)
                Dim yearTo As Integer = CType(If(String.IsNullOrEmpty(txtYearTo.Text), "0", txtYearTo.Text), Integer)
                Dim strAdditionalBy As String = txtAdditionalBy.Text
                Dim strDicFaculty As String = ddlFaculty.SelectedValue
                Dim intAcqSource As Integer = CType(If(String.IsNullOrEmpty(ddlAcqSource.SelectedItem.Value), "0", ddlAcqSource.SelectedItem.Value), Integer)
                Dim intLocation As Integer = CType(If(String.IsNullOrEmpty(ddlLocation.SelectedItem.Value), "0", ddlLocation.SelectedItem.Value), Integer)

                Dim strDateFrom As String = txtDateFrom.Text
                Dim strDateTo As String = txtDateTo.Text
                If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom + " 00:00:00")
                If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo + " 23:59:59")

                Dim tblResult As DataTable = objBItem.GetItemBySHCount(intKeywordId, intTypeId, intLoanType, yearFrom, yearTo, intAcqSource, intLocation, strAdditionalBy, strDicFaculty, strDateFrom, strDateTo)
                Dim totalRecord As Integer = 0
                Dim totalCopyNumber As Integer = 0
                ResultSearch(tblResult, totalRecord, totalCopyNumber)

                lblTotal.Text = hidMessageBook.Value & "<b>" & totalRecord & "</b>" & " / " & hidMessageCopyNumber.Value & "<b>" & totalCopyNumber & "</b>"

                'lblCountBook.Text = hidMessageBook.Value & "<b>" & totalRecord & "</b>" & " / "
                'lblCountCopyNumber.Text = hidMessageCopyNumber.Value & "<b>" & totalCopyNumber & "</b>"

            Catch ex As Exception
            End Try
        End Sub

        Private Sub BindData(ByVal strKeyword As String, Optional ByVal intTypeId As Integer = 0, Optional ByVal intLoanType As Integer = 0)
            Try
                Dim yearFrom As Integer = CType(If(String.IsNullOrEmpty(txtYearFrom.Text), "0", txtYearFrom.Text), Integer)
                Dim yearTo As Integer = CType(If(String.IsNullOrEmpty(txtYearTo.Text), "0", txtYearTo.Text), Integer)
                Dim strAdditionalBy As String = txtAdditionalBy.Text
                Dim strDicFaculty As String = ddlFaculty.SelectedValue
                Dim intAcqSource As Integer = CType(If(String.IsNullOrEmpty(ddlAcqSource.SelectedItem.Value), "0", ddlAcqSource.SelectedItem.Value), Integer)
                Dim intLocation As Integer = CType(If(String.IsNullOrEmpty(ddlLocation.SelectedItem.Value), "0", ddlLocation.SelectedItem.Value), Integer)

                Dim strDateFrom As String = txtDateFrom.Text
                Dim strDateTo As String = txtDateTo.Text
                If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom + " 00:00:00")
                If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo + " 23:59:59")

                Dim tblResult As DataTable = objBItem.GetItemBySHCount(strKeyword, intTypeId, intLoanType, yearFrom, yearTo, intAcqSource, intLocation, strAdditionalBy, strDicFaculty, strDateFrom, strDateTo)
                Dim totalRecord As Integer = 0
                Dim totalCopyNumber As Integer = 0
                ResultSearch(tblResult, totalRecord, totalCopyNumber)

                lblTotal.Text = hidMessageBook.Value & "<b>" & totalRecord & "</b>" & " / " & hidMessageCopyNumber.Value & "<b>" & totalCopyNumber & "</b>"

                'lblCountBook.Text = hidMessageBook.Value & "<b>" & totalRecord & "</b>" & " / "
                'lblCountCopyNumber.Text = hidMessageCopyNumber.Value & "<b>" & totalCopyNumber & "</b>"

            Catch ex As Exception
            End Try
        End Sub


        Protected Sub btnExportData_Click(sender As Object, e As EventArgs) Handles btnExportData.Click
            If rdDDLSH.Checked = True Then
                BindData(CInt(ddlSH.SelectedItem.Value), CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue))
                rdTextSH.Checked = False
                rdDDLSH.Checked = True

                txtSH.CssClass = "lbTextBox disable-block"
                txtSH.Enabled = False

                ddlSH.CssClass = "enable-block"
                ddlSH.Enabled = True


                PanelTextSH.Attributes.Add("style", "display:none")
                PanelDDLSH.Attributes.Remove("style")
            End If
            If rdTextSH.Checked = True Then
                BindData(txtSH.Text, CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue))
                rdTextSH.Checked = True
                rdDDLSH.Checked = False

                txtSH.CssClass = "lbTextBox enable-block"
                txtSH.Enabled = True

                ddlSH.CssClass = "disable-block"
                ddlSH.Enabled = False

                PanelDDLSH.Attributes.Add("style", "display:none")
                PanelTextSH.Attributes.Remove("style")
            End If
        End Sub

        Protected Sub dtgPolicy_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgPolicy.PageIndexChanging
            Session("pageIndex") = e.NewPageIndex
            'BindData(ddlKeyword.SelectedItem.Value, ddlItemType.SelectedValue, ddlLoanType.SelectedValue)
            If rdDDLSH.Checked = True Then
                BindData(CInt(ddlSH.SelectedItem.Value), CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue))
            End If
            If rdTextSH.Checked = True Then
                BindData(txtSH.Text, CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue))
            End If
        End Sub

        'Public Sub DataExample()
        '    Dim listWidth As New List(Of Double)()
        '    listWidth.Add(2)
        '    listWidth.Add(1)
        '    listWidth.Add(1)
        '    listWidth.Add(2.5)

        '    Dim data As New DataTable


        '    'data.Columns.Add("Dosage", typeof(Integer))
        '    data.Columns.Add("ID", GetType(String))
        '    data.Columns.Add("Name", GetType(String))
        '    data.Columns.Add("Name1", GetType(String))
        '    data.Columns.Add("Name2", GetType(String))

        '    data.Rows.Add("STT", "Ten", "thoi gian", "XXX")

        '    data.Rows.Add("1", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("2", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("3", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("4", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("5", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("6", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("7", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("8", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("9", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("10", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("11", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")
        '    data.Rows.Add("12", "Often we want to ", "Often we want to loop over our DataTable rows", "Often we want to loop over our DataTable rows")

        '    Dim a As New clsBExportHelper

        '    a.ExportWord(listWidth, data, "báo cáo")
        'End Sub

        Protected Sub btnExportWord_Click(sender As Object, e As EventArgs) Handles btnExportWord.Click
            'DataExample()
            Response.ClearContent()
            Response.AppendHeader("content-disposition", "attachment;filename=export_" & DateTime.Now.Year.ToString() & DateTime.Now.Month.ToString() & DateTime.Now.Day.ToString() & DateTime.Now.Hour.ToString() & DateTime.Now.Minute.ToString() & DateTime.Now.Second.ToString() & DateTime.Now.Millisecond.ToString() & ".doc")
            Response.Charset = "UTF-8"
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/msword"
            Response.ContentEncoding = Encoding.Unicode
            Response.BinaryWrite(Encoding.Unicode.GetPreamble())

            Dim yearFrom As Integer = CType(If(String.IsNullOrEmpty(txtYearFrom.Text), "0", txtYearFrom.Text), Integer)
            Dim yearTo As Integer = CType(If(String.IsNullOrEmpty(txtYearTo.Text), "0", txtYearTo.Text), Integer)
            Dim strAdditionalBy As String = txtAdditionalBy.Text
            Dim intAcqSource As Integer = CType(If(String.IsNullOrEmpty(ddlAcqSource.SelectedItem.Value), "0", ddlAcqSource.SelectedItem.Value), Integer)
            Dim intLocation As Integer = CType(If(String.IsNullOrEmpty(ddlLocation.SelectedItem.Value), "0", ddlLocation.SelectedItem.Value), Integer)

            Dim tblResult As New DataTable("tblResult")
            'tblResult = objBItem.GetItemByKeyword(ddlKeyword.SelectedItem.Value, ddlItemType.SelectedValue, ddlLoanType.SelectedValue, yearFrom, yearTo, intAcqSource, intLocation)
            If rdDDLSH.Checked = True Then
                tblResult = objBItem.GetItemBySHCount(CInt(ddlSH.SelectedItem.Value), CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue), yearFrom, yearTo, intAcqSource, intLocation, strAdditionalBy)
            End If
            If rdTextSH.Checked = True Then
                tblResult = objBItem.GetItemBySHCount(txtSH.Text, CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue), yearFrom, yearTo, intAcqSource, intLocation, strAdditionalBy)
            End If

            Dim totalRecord As Integer = 0
            Dim totalCopyNumber As Integer = 0
            ResultSearch(tblResult, totalRecord, totalCopyNumber)
            Dim tblConvert As New DataTable("tblConvert")
            totalCopyNumber = 0
            ConvertTableExport(tblResult, tblConvert, totalRecord, totalCopyNumber)
            tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text, ddlLabelHeaderTable.Items(9).Text)

            Dim wordHelper As New clsBExportHelper

            Dim strHTMLContent As New StringBuilder()
            'strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='www.w3.org/TR/REC-html40'>")
            'strHTMLContent.Append("<head>")
            'strHTMLContent.Append("<title></title>")
            'strHTMLContent.Append("<!--[if gte mso 9]>")
            'strHTMLContent.Append("<xml>" & clsBExportHelper.Xml_Word() & "</xml>")
            'strHTMLContent.Append("<![endif]-->")
            'strHTMLContent.Append("<style>" & clsBExportHelper.css_word("2cm", "1.5cm", "2cm", "1.5cm", True) & "</style>")
            'strHTMLContent.Append("</head>")
            'strHTMLContent.Append("<body lang=EN-US style='tab-interval:.5in'>")
            'strHTMLContent.Append("<div class=Section1>")
            'strHTMLContent.Append("<p>" & clsBExportHelper.GenHeader(hidLeftTable.Value, hidRightTable.Value, hidTitleTable.Value & ": " & ddlKeyword.SelectedItem.Text.ToUpper) & "</p>")
            ''strHTMLContent.Append("<br/>")
            ''strHTMLContent.Append("<p>" & clsBExportHelper.GenFooter(hidMessageBook.Value & "<b>" & totalRecord & "</b>", hidMessageCopyNumber.Value & "<b>" & totalCopyNumber & "</b>") & "</p>")
            'strHTMLContent.Append("<br/>")
            'strHTMLContent.Append("<p>" & clsBExportHelper.GenDataTableToString(tblConvert) & "</p>")
            'strHTMLContent.Append("<div id='hrdftrtbl'>")
            ''strHTMLContent.Append("<div style='mso-element:header' id=h1>" & clsBExportHelper.HeaderWord("") & "</div>")
            ''strHTMLContent.Append("<div style='mso-element:footer; text-align:right;' id=f1>" & clsBExportHelper.FooterWord("<span style='mso-tab-count:1'></span>" & "<b>" & "Trang: </b>" & "<i><span style='mso-field-code:"" PAGE ""'></span>" & " / " & "<span style='mso-field-code:"" NUMPAGES ""'></span></i>") & "</div>")
            'strHTMLContent.Append("</div></body></html>")

            strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='www.w3.org/TR/REC-html40'>")
            strHTMLContent.Append("<head>")
            strHTMLContent.Append("<!--[if gte mso 9]>")
            strHTMLContent.Append("<xml>" & clsBExportHelper.Xml_Word() & "</xml>")
            strHTMLContent.Append("<![endif]-->")
            strHTMLContent.Append("<style>" & clsBExportHelper.css_word(True) & "</style>")
            strHTMLContent.Append("</head>")
            strHTMLContent.Append("<body>")
            strHTMLContent.Append("<div class=Section2>")
            strHTMLContent.Append("<p>" & clsBExportHelper.GenHeader(hidLeftTable.Value, hidRightTable.Value, hidTitleTable.Value & ": " & ddlSH.SelectedItem.Text.ToUpper) & "</p>")
            strHTMLContent.Append("<br/>")
            strHTMLContent.Append("<p>" & clsBExportHelper.GenDataTableToString(tblConvert) & "</p>")
            strHTMLContent.Append("</div></body></html>")

            Response.Write(strHTMLContent)
            Response.End()
            Response.Flush()
        End Sub

        Protected Sub btnDelSH_Click(sender As Object, e As EventArgs) Handles btnDelSH.Click
            Dim result As Integer = objBSH.DeleteSHBibliography(CType(ddlSH.SelectedItem.Value.ToString(), Integer))
            If (result = 1) Then
                'Dim strJava As String = "var x = window.opener.document.getElementById('ddlKeyword');"
                'strJava = strJava & " var option = window.opener.document.createElement('option');"
                'strJava = strJava & " option.text = '" & Request("strDisplayEntry").ToString() & "';"
                'strJava = strJava & " option.value = '" & Request("intKeywordID").ToString() & "';"
                'strJava = strJava & " x.add(option);"

                Dim strJava As String = "alert('Xóa từ khóa trong điều kiện lọc thành công');"
                Page.RegisterClientScriptBlock("JSSelf", "<script type='text/javascript'>" & strJava & "</script>")
                BinDDl()
            End If
        End Sub
        Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
            Try

                Dim yearFrom As Integer = CType(If(String.IsNullOrEmpty(txtYearFrom.Text), "0", txtYearFrom.Text), Integer)
                Dim yearTo As Integer = CType(If(String.IsNullOrEmpty(txtYearTo.Text), "0", txtYearTo.Text), Integer)
                Dim strAdditionalBy As String = txtAdditionalBy.Text
                Dim intAcqSource As Integer = CType(If(String.IsNullOrEmpty(ddlAcqSource.SelectedItem.Value), "0", ddlAcqSource.SelectedItem.Value), Integer)
                Dim intLocation As Integer = CType(If(String.IsNullOrEmpty(ddlLocation.SelectedItem.Value), "0", ddlLocation.SelectedItem.Value), Integer)
                Dim strDicFaculty As String = ddlFaculty.SelectedValue
                Dim tblResult As New DataTable("tblResult")
                'tblResult = objBItem.GetItemByKeyword(ddlKeyword.SelectedItem.Value, ddlItemType.SelectedValue, ddlLoanType.SelectedValue, yearFrom, yearTo, intAcqSource, intLocation)
                If rdDDLSH.Checked = True Then
                    tblResult = objBItem.GetItemBySHCount(CInt(ddlSH.SelectedItem.Value), CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue), yearFrom, yearTo, intAcqSource, intLocation, strAdditionalBy,strDicFaculty)
                End If
                If rdTextSH.Checked = True Then
                    tblResult = objBItem.GetItemBySHCount(txtSH.Text, CInt(ddlItemType.SelectedValue), CInt(ddlLoanType.SelectedValue), yearFrom, yearTo, intAcqSource, intLocation, strAdditionalBy,strDicFaculty)
                End If

                Dim totalRecord As Integer = 0
                Dim totalCopyNumber As Integer = 0
                ResultSearch(tblResult, totalRecord, totalCopyNumber)
                Dim tblConvert As New DataTable("tblConvert")
                totalCopyNumber = 0
                ConvertTableExport(tblResult, tblConvert, totalRecord, totalCopyNumber)
                'tblResult = objBCDBS.ConvertTable(tblResult, False)

                Dim filename As String = String.Format("Report_{0}.xls", DateAndTime.Now.Ticks)

                Response.Clear()
                Response.ClearContent()
                Response.ClearHeaders()
                Response.Buffer = True
                Response.ContentType = "application/ms-excel"
                Response.AddHeader("Content-Disposition", "attachment;filename=" & filename)

                Response.Charset = Encoding.UTF8.EncodingName
                Response.ContentEncoding = System.Text.Encoding.Unicode
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
                Response.Write("<Table border='1' borderColor='#000000' cellSpacing='0' cellPadding='0'><TR>")
                Dim columnscount As Integer = tblConvert.Columns.Count

                For i As Integer = 0 To columnscount - 1
                    Response.Write("<Td>")
                    Response.Write("<B>")
                    Select Case tblConvert.Columns(i).ColumnName.ToString()
                        Case "STT"
                            Response.Write(ddlLabelHeaderTable.Items(0).Text)
                        Case "Title"
                            Response.Write(ddlLabelHeaderTable.Items(1).Text)
                        Case "Author"
                            Response.Write(ddlLabelHeaderTable.Items(2).Text)
                        Case "NXB"
                            Response.Write(ddlLabelHeaderTable.Items(3).Text)
                        Case "Publisher"
                            Response.Write(ddlLabelHeaderTable.Items(4).Text)
                        Case "PublishYear"
                            Response.Write(ddlLabelHeaderTable.Items(5).Text)
                        Case "Classification"
                            Response.Write(ddlLabelHeaderTable.Items(6).Text)
                        Case "Specialized"
                            Response.Write(ddlLabelHeaderTable.Items(7).Text)
                        Case "CountCopyNumber"
                            Response.Write(ddlLabelHeaderTable.Items(8).Text)
                        Case "ItemType"
                            Response.Write(ddlLabelHeaderTable.Items(9).Text)
                        Case Else
                            Response.Write(tblConvert.Columns(i).ColumnName.ToString())
                    End Select

                    Response.Write("</B>")
                    Response.Write("</Td>")
                Next

                Response.Write("</TR>")
                For Each Row As DataRow In tblConvert.Rows
                    Response.Write("<TR>")
                    For i As Integer = 0 To columnscount - 1
                        Response.Write("<Td>")
                        Dim gType As System.Type = Row(i).GetType()
                        If gType.ToString() = "System.DateTime" Then
                            Response.Write(String.Format("{0:dd/MM/yyyy}", CType(Row(i).ToString(), Date)))
                        Else
                            Response.Write(Row(i).ToString())
                        End If
                        Response.Write("</Td>")
                    Next
                    Response.Write("</TR>")
                Next
                Response.Write("</Table>")
                Response.Write("</font>")
                Response.Flush()
                Response.End()

            Catch ex As Exception

            End Try
        End Sub

    End Class

End Namespace
