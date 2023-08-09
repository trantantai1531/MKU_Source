Imports ComponentArt.Web.UI
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqPreviewValue
        Inherits clsWBase

        ' Declare variables
        Private objBItemCollection As New clsBItemCollection

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not Request("id") Is Nothing AndAlso Not Request("id") = "" Then
                'Dim procs As New BusinessLayer.Acquisition
                'Dim _id As String = "," & Request("id").Trim & ","
                'Dim _GetFields As IList = procs.Select_fields_dublincore(_id, Session("Language"))
                'procs = Nothing
                'Call LoadDataForViewRecord(_GetFields, CInt(Request("id")))
                BindData(Request("id"))
            Else
                'Call LoadData(Session("dtFields"))
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
        End Sub

        Private Sub BindData(ByVal intItemID As Integer)
            Try
                objBItemCollection.ItemIDs = intItemID
                grdProperty.DataSource = objBItemCollection.GetContents
                grdProperty.DataBind()
            Catch ex As Exception
            End Try
        End Sub

        'Private Sub LoadDataForViewRecord(ByVal _iList As IList, ByVal _id As Integer)
        '    If Not _iList Is Nothing AndAlso _iList.Count > 0 Then
        '        Dim _MarcField As String = ""
        '        Dim _strInfo As String = ""
        '        _strInfo &= "<script language='javascript'>" & Chr(10)
        '        _strInfo &= "document.write(""<TABLE CELLPADDING='3' CELLSPACING='3' BORDER='0' WIDTH='100%' class='MultiFont'>"");" & Chr(10)
        '        'Data for catalogue
        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD COLSPAN='2' style='cursor:default;background-color:#d5d5d5;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""<B>" & span_catalogue.InnerText & "</B>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '        Dim _Charge As Boolean = False
        '        Dim _Security As Integer = 0
        '        Dim _DocType As String = ""
        '        Dim _Status As String = ""
        '        Dim _CollectionId As Integer = 0
        '        Dim _CollectionStr As String = ""
        '        For Each pro In _iList
        '            _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '            If _MarcField = pro.DubMarcField.ToString Then
        '                _strInfo &= "document.write(""<TD style='width:20%;'></TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""" & clsCommon.ReplaceTagToHTML(pro.Name.ToString) & """);" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '            Else
        '                _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""" & pro.dubName.ToString & " (" & pro.DubMarcField.ToString & ")" & """);" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""" & clsCommon.ReplaceTagToHTML(pro.Name.ToString) & """);" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '            End If
        '            _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '            _MarcField = pro.DubMarcField.ToString
        '            If Not IsNothing(pro.Charge) Then
        '                _Charge = pro.Charge
        '            End If
        '            If Not IsNothing(pro.SercretLevel) Then
        '                _Security = pro.SercretLevel.ToString
        '            End If
        '            If Not IsNothing(pro.DocType) Then
        '                _DocType = pro.DocType.ToString
        '            End If
        '            If Not IsNothing(pro.Status) Then
        '                _Status = pro.Status.ToString
        '            End If
        '            If Not IsNothing(pro.CollectionID) Then
        '                _CollectionId = pro.CollectionID.ToString
        '            End If
        '        Next

        '        'Data for attribute
        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD COLSPAN='2' style='cursor:default;background-color:#d5d5d5;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""<B>" & span_attribute.InnerText & "</B>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_access.InnerText & """)" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        If _Charge Then
        '            _strInfo &= "document.write(""" & span_access_charge.InnerText & """);" & Chr(10)
        '        Else
        '            _strInfo &= "document.write(""" & span_access_free.InnerText & """);" & Chr(10)
        '        End If
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_security.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & _Security & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_doctype.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & _DocType & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_status.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & _Status & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        Call clsCommon.GetvalueHierachyCollection(_CollectionId, _CollectionStr)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_collection_path.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & _CollectionStr & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        'Data for attach
        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD COLSPAN='2' style='cursor:default;background-color:#d5d5d5;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""<B>" & span_attach.InnerText & "</B>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        'Files
        '        Dim procs As New BusinessLayer.Acquisition
        '        Dim _files As IList = procs.Select_cat_files(_id)
        '        procs = Nothing
        '        'Dim _DataAttach(,) As String = Nothing
        '        If Not _files Is Nothing AndAlso _files.Count > 0 Then
        '            Session("uploadFiles") = Nothing
        '            For Each _file In _files
        '                If Session("uploadFiles") Is Nothing Then
        '                    ReDim Preserve Session("uploadFiles")(1, 0)
        '                    Session("uploadFiles")(0, 0) = _file.Path.ToString.Substring(0, _file.Path.ToString.LastIndexOf("\"))
        '                    Session("uploadFiles")(1, 0) = _file.FileName.ToString
        '                Else
        '                    Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2) + 1
        '                    ReDim Preserve Session("uploadFiles")(1, _icountArr)
        '                    Session("uploadFiles")(0, _icountArr) = _file.Path.ToString.Substring(0, _file.Path.ToString.LastIndexOf("\"))
        '                    Session("uploadFiles")(1, _icountArr) = _file.FileName.ToString
        '                End If
        '            Next
        '            '_DataAttach = Session("uploadFiles")
        '        End If
        '        If Not Session("uploadFiles") Is Nothing Then
        '            Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2)
        '            Dim _bolTitle As Boolean = False
        '            Dim _strGetIcon As String = ""
        '            For _icount As Integer = 0 To _icountArr
        '                If Session("uploadFiles")(1, _icount).Length > 0 Then
        '                    _strGetIcon = clsCommon.GetImage(Session("uploadFiles")(1, _icount))
        '                Else
        '                    _strGetIcon = ""
        '                End If

        '                _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '                If _icount = 0 Then
        '                    _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '                    _strInfo &= "document.write(""" & span_attach_info.InnerText & """);" & Chr(10)
        '                    _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                Else
        '                    _strInfo &= "document.write(""<TD style='width:20%;'></TD>"");" & Chr(10)
        '                End If
        '                _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TABLE CELLPADDING='1' CELLSPACING='0' BORDER='0' WIDTH='100%' class='MultiFont'>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD align='right' style='width:2%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""<img src='../../Skin/" & Session("Theme") & "/FileType/" & _strGetIcon & "' height='32' width='32' border='0'/>"")" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD valign='top' align='left' style='width:98%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""" & Session("uploadFiles")(1, _icount) & " (" & Session("uploadFiles")(0, _icount).Replace("\", "\\") & ")"");" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TABLE>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '                'attribs.
        '            Next
        '        End If

        '        _strInfo &= "document.write(""</TABLE>"");" & Chr(10)
        '        _strInfo &= "</script>"
        '        infoPreview.Text = _strInfo
        '    End If
        'End Sub

        'Private Sub LoadData(ByVal _DataTable As DataTable)
        '    If Not _DataTable Is Nothing AndAlso _DataTable.Rows.Count > 0 Then
        '        Dim _MarcField As String = ""
        '        Dim _strInfo As String = ""
        '        _strInfo &= "<script language='javascript'>" & Chr(10)
        '        _strInfo &= "document.write(""<TABLE CELLPADDING='3' CELLSPACING='3' BORDER='0' WIDTH='100%' class='MultiFont'>"");" & Chr(10)
        '        'Data for catalogue
        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD COLSPAN='2' style='cursor:default;background-color:#d5d5d5;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""<B>" & span_catalogue.InnerText & "</B>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        For i As Integer = 0 To _DataTable.Rows.Count - 1
        '            _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '            If _MarcField = _DataTable.Rows(i).Item("MarcField").ToString Then
        '                _strInfo &= "document.write(""<TD style='width:20%;'></TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(top.MLContent.main.maincontent.document.getElementById('tag" & _DataTable.Rows(i).Item("MarcField").ToString & "_" & _DataTable.Rows(i).Item("RepeatCode").ToString & "').value);" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '            Else
        '                _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""" & _DataTable.Rows(i).Item("Name").ToString & " (" & _DataTable.Rows(i).Item("MarcField").ToString & ")" & """);" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(top.MLContent.main.maincontent.document.getElementById('tag" & _DataTable.Rows(i).Item("MarcField").ToString & "').value);" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '            End If
        '            _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '            _MarcField = _DataTable.Rows(i).Item("MarcField").ToString
        '        Next

        '        'Data for attribute
        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD COLSPAN='2' style='cursor:default;background-color:#d5d5d5;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""<B>" & span_attribute.InnerText & "</B>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_access.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "if (top.MLContent.main.maincontent.document.getElementById('optAccessFree').checked==true)" & Chr(10)
        '        _strInfo &= "document.write(""" & span_access_free.InnerText & """);" & Chr(10)
        '        _strInfo &= "else" & Chr(10)
        '        _strInfo &= "document.write(""" & span_access_charge.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_security.InnerText & """)" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(top.MLContent.main.maincontent.cboSecurity.get_text());" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_doctype.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(top.MLContent.main.maincontent.cboDocType.get_text());" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_status.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(top.MLContent.main.maincontent.cboStatus.get_text());" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""" & span_collection_path.InnerText & """);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '        _strInfo &= "document.write(top.MLContent.main.maincontent.document.getElementById('txtCollectionPath').value);" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)

        '        'Data for attach
        '        _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '        _strInfo &= "document.write(""<TD COLSPAN='2' style='cursor:default;background-color:#d5d5d5;'>"");" & Chr(10)
        '        _strInfo &= "document.write(""<B>" & span_attach.InnerText & "</B>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '        _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '        If Not Session("uploadFiles") Is Nothing Then
        '            Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2)
        '            Dim _bolTitle As Boolean = False
        '            Dim _strGetIcon As String = ""
        '            For _icount As Integer = 0 To _icountArr
        '                If Session("uploadFiles")(1, _icount).Length > 0 Then
        '                    _strGetIcon = clsCommon.GetImage(Session("uploadFiles")(1, _icount))
        '                Else
        '                    _strGetIcon = ""
        '                End If

        '                _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '                If _icount = 0 Then
        '                    _strInfo &= "document.write(""<TD style='width:20%;'>"");" & Chr(10)
        '                    _strInfo &= "document.write(""" & span_attach_info.InnerText & """);" & Chr(10)
        '                    _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                Else
        '                    _strInfo &= "document.write(""<TD style='width:20%;'></TD>"");" & Chr(10)
        '                End If
        '                _strInfo &= "document.write(""<TD style='width:80%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TABLE CELLPADDING='1' CELLSPACING='0' BORDER='0' WIDTH='100%' class='MultiFont'>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TR>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD align='right' style='width:2%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""<img src='../../Skin/" & Session("Theme") & "/FileType/" & _strGetIcon & "' height='32' width='32' border='0'/>"")" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""<TD valign='top' align='left' style='width:98%;'>"");" & Chr(10)
        '                _strInfo &= "document.write(""" & Session("uploadFiles")(1, _icount) & " (" & Session("uploadFiles")(0, _icount).Replace("\", "\\") & ")"");" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TABLE>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TD>"");" & Chr(10)
        '                _strInfo &= "document.write(""</TR>"");" & Chr(10)
        '            Next
        '        End If

        '        _strInfo &= "document.write(""</TABLE>"");" & Chr(10)
        '        _strInfo &= "</script>"
        '        infoPreview.Text = _strInfo
        '    End If
        'End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

