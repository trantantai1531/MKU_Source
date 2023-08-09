Imports ComponentArt.Web.UI
Imports System.Data
Imports System.IO
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqUploadFilesValue
        Inherits clsWBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack AndAlso Not UploadFiles.CausedCallback Then
                Call initUploadFields()
                If Not Request("uploadPath") Is Nothing Then
                    UploadFiles.CallbackParameter = Request("uploadPath")
                End If
            End If
        End Sub

        Private Sub initUploadFields()
            Session("uploadFiles") = Nothing
            litinfoUpload.Text = ""
            Call initTempUploadDirectory()
        End Sub

        Private Sub initTempUploadDirectory()
            UploadFiles.TempFileFolder = Server.MapPath("~/Upload")
        End Sub

        Protected Sub UploadFiles_Uploaded(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.UploadUploadedEventArgs) Handles UploadFiles.Uploaded
            Try
                For Each oInfo In e.UploadedFiles
                    If Directory.Exists(UploadFiles.CallbackParameter) Then
                        oInfo.SaveAs(Path.Combine(UploadFiles.CallbackParameter, oInfo.FileName), True)
                        If Session("uploadFiles") Is Nothing Then
                            ReDim Preserve Session("uploadFiles")(1, 0)
                            Session("uploadFiles")(0, 0) = UploadFiles.CallbackParameter
                            Session("uploadFiles")(1, 0) = oInfo.FileName
                        Else
                            Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2) + 1
                            ReDim Preserve Session("uploadFiles")(1, _icountArr)
                            Session("uploadFiles")(0, _icountArr) = UploadFiles.CallbackParameter
                            Session("uploadFiles")(1, _icountArr) = oInfo.FileName
                        End If
                    Else
                        Call DisplayInfo(span_info.InnerText, span_addnew_invalid2.InnerText, 5)
                        Exit For
                    End If
                Next
                UploadFiles.Dispose()
            Catch ex As Exception : End Try
        End Sub

        'Display information to be updated
        Public Sub DisplayInfo(ByVal title As String, ByVal info As String, ByVal icon As Integer)
            Dim _strInfo As String = ""
            _strInfo = "top.showDialogInfo('',true," & icon & ",'" & title & "','" & info & "');"
            clsWCommon.MyMsgBoxInfor(_strInfo, Me.Page)
        End Sub

        Private Sub DisplayUploadFields()
            Try
                If Not Session("uploadFiles") Is Nothing Then
                    Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2)
                    Dim _strUploadFiles As String = ""
                    _strUploadFiles = "<table cellpadding='1' cellspacing='1' border='0' width='100%'>"
                    Dim _Img As String = ""
                    Dim _strGetIcon As String = ""
                    For _icount As Integer = 0 To _icountArr
                        If _icount = 0 Then
                            _strUploadFiles &= "<tr>"
                            _strUploadFiles &= "<td valign='top' width='25%'>"
                            _strUploadFiles &= span_info_uploadfiles.InnerText & " : "
                            _strUploadFiles &= "</td>"
                        Else
                            _strUploadFiles &= "<tr>"
                            _strUploadFiles &= "<td  width='25%'>"
                            _strUploadFiles &= "&nbsp;"
                            _strUploadFiles &= "</td>"
                        End If
                        _Img = ""
                        If Session("uploadFiles")(1, _icount).Length > 0 Then
                            _strGetIcon = clsWCommon.GetImage(Session("uploadFiles")(1, _icount))
                        Else
                            _strGetIcon = ""
                        End If

                        _Img = "<img src='" & "../../Images/ComponentArt/FileType/" & _strGetIcon & "' height='32' width='32' border='0'/>"

                        _strUploadFiles &= "<td valign='top'  width='3%'>"
                        _strUploadFiles &= _Img
                        _strUploadFiles &= "</td>"
                        _strUploadFiles &= "<td valign='top'  width='72%'>"
                        _strUploadFiles &= "<b><i>" & Session("uploadFiles")(1, _icount) & "</i></b>" & " (" & Session("uploadFiles")(0, _icount) & ")"
                        _strUploadFiles &= " (<a href=""javascript:void(0);"" onclick=""removeFileUpload(" & _icount & ");return false;"">" & span_upload_removefiles.InnerText & "</a>)"
                        _strUploadFiles &= "</td>"
                        _strUploadFiles &= "</tr>"
                    Next
                    _strUploadFiles &= "</table>"
                    litinfoUpload.Text = _strUploadFiles
                Else
                    litinfoUpload.Text = ""
                End If
            Catch ex As Exception : End Try
        End Sub

        Protected Sub raiseRemoveFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseRemoveFile.Click
            Try
                Dim _id As Integer = hidRemovefileID.Value
                If _id > -1 Then
                    Call RemoveSession(_id)
                End If
                Call DisplayUploadFields()
            Catch ex As Exception : End Try
        End Sub

        Protected Sub raiseDisplayUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseDisplayUpload.Click
            Try
                Call DisplayUploadFields()
            Catch ex As Exception : End Try
        End Sub

        Public Sub RemoveSession(ByVal _item As Integer)
            Try
                If Not Session("uploadFiles") Is Nothing Then
                    Dim _iUbound As Integer = UBound(Session("uploadFiles"), 2) - 1
                    Dim _fileremovePath As String = IIf(Session("uploadFiles")(0, _item).ToString.Last = "\", Session("uploadFiles")(0, _item), Session("uploadFiles")(0, _item) & "\") & Session("uploadFiles")(1, _item)
                    For _icount As Integer = _item To _iUbound
                        Session("uploadFiles")(0, _icount) = Session("uploadFiles")(0, _icount + 1)
                        Session("uploadFiles")(1, _icount) = Session("uploadFiles")(1, _icount + 1)
                    Next
                    If _iUbound > -1 Then
                        ReDim Preserve Session("uploadFiles")(1, _iUbound)
                    Else
                        Session("uploadFiles") = Nothing
                    End If
                    If File.Exists(_fileremovePath) Then
                        File.Delete(_fileremovePath)
                    End If
                End If
            Catch ex As Exception : End Try
        End Sub

    End Class
End Namespace

