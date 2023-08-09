Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.News

Namespace eMicLibAdmin.BusinessRules.News
    Public Class clsBCAT_WebsiteUseful
        Inherits clsBBase
        Private objwebsite As New clsDCAT_WebsiteUseful
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

#Region "Properties"
        Private idStr As String
        Public Property id() As String
            Get
                Return idStr
            End Get
            Set(ByVal value As String)
                idStr = value
            End Set
        End Property

        Private id_LStr As String
        Public Property id_L() As String
            Get
                Return id_LStr
            End Get
            Set(ByVal value As String)
                id_LStr = value
            End Set
        End Property


        Private LoaiStr As String
        Public Property Loai() As String
            Get
                Return LoaiStr
            End Get
            Set(ByVal value As String)
                LoaiStr = value
            End Set
        End Property


        Private Vi_triStr As String
        Public Property Vi_tri() As String
            Get
                Return Vi_triStr
            End Get
            Set(ByVal value As String)
                Vi_triStr = value
            End Set
        End Property


        Private NNStr As String
        Public Property NN() As String
            Get
                Return NNStr
            End Get
            Set(ByVal value As String)
                NNStr = value
            End Set
        End Property


        Private StatusStr As String
        Public Property Status() As String
            Get
                Return StatusStr
            End Get
            Set(ByVal value As String)
                StatusStr = value
            End Set
        End Property


        Private AnhStr As String
        Public Property Anh() As String
            Get
                Return AnhStr
            End Get
            Set(ByVal value As String)
                AnhStr = value
            End Set
        End Property


        Private HotStr As String
        Public Property Hot() As String
            Get
                Return HotStr
            End Get
            Set(ByVal value As String)
                HotStr = value
            End Set
        End Property


        Private GioiThieuStr As String
        Public Property GioiThieu() As String
            Get
                Return GioiThieuStr
            End Get
            Set(ByVal value As String)
                GioiThieuStr = value
            End Set
        End Property


        Private LinkStr As String
        Public Property Link() As String
            Get
                Return LinkStr
            End Get
            Set(ByVal value As String)
                LinkStr = value
            End Set
        End Property

        Private AuthorStr As String
        Public Property Author() As String
            Get
                Return AuthorStr
            End Get
            Set(ByVal value As String)
                AuthorStr = value
            End Set
        End Property

        Private DuoiAnhStr As String
        Public Property DuoiAnh() As String
            Get
                Return DuoiAnhStr
            End Get
            Set(ByVal value As String)
                DuoiAnhStr = value
            End Set
        End Property


        Private id_FormatStr As String
        Public Property id_Format() As String
            Get
                Return id_FormatStr
            End Get
            Set(ByVal value As String)
                id_FormatStr = value
            End Set
        End Property


        Private id_LexileStr As String
        Public Property id_Lexile() As String
            Get
                Return id_LexileStr
            End Get
            Set(ByVal value As String)
                id_LexileStr = value
            End Set
        End Property


        Private id_LanguageStr As String
        Public Property id_Language() As String
            Get
                Return id_LanguageStr
            End Get
            Set(ByVal value As String)
                id_LanguageStr = value
            End Set
        End Property


        Private id_GradeStr As String
        Public Property id_Grade() As String
            Get
                Return id_GradeStr
            End Get
            Set(ByVal value As String)
                id_GradeStr = value
            End Set
        End Property
#End Region

        Public Sub Initialize()
            'Init objDOPACComment object
            objwebsite.DBServer = strDBServer
            objwebsite.ConnectionString = strConnectionString
            objwebsite.Initialize()

        End Sub

        Public Function Create(ByVal intSelect As Integer) As Integer
            Try
                objwebsite.Anh = AnhStr
                objwebsite.GioiThieu = GioiThieuStr
                objwebsite.Hot = HotStr
                objwebsite.id_L = id_LStr
                objwebsite.Link = LinkStr
                objwebsite.Loai = LoaiStr
                objwebsite.NN = NNStr
                objwebsite.Status = StatusStr
                objwebsite.Vi_tri = Vi_triStr
                objwebsite.Author = AuthorStr
                objwebsite.DuoiAnh = DuoiAnhStr

                objwebsite.id_Format = id_FormatStr
                objwebsite.id_Lexile = id_LexileStr
                objwebsite.id_Language = id_LanguageStr
                objwebsite.id_Grade = id_GradeStr

                Create = objwebsite.Create(intSelect)
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objwebsite.ErrorMsg
                intErrorCode = objwebsite.id
            End Try
        End Function

        Public Function CAT_WebsiteUseful_sl() As DataTable
            Try
                objwebsite.id_L = id_LStr
                objwebsite.NN = NNStr

                CAT_WebsiteUseful_sl = objBCDBS.ConvertTable(objwebsite.CAT_WebsiteUseful_sl)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        Public Function CAT_WebsiteUseful_Search() As DataTable
            Try
                objwebsite.id_L = IIf(id_LStr = "", 0, id_LStr)
                objwebsite.id_Format = IIf(id_FormatStr = "", 0, id_FormatStr)
                objwebsite.id_Lexile = IIf(id_LexileStr = "", 0, id_LexileStr)
                objwebsite.id_Language = IIf(id_LanguageStr = "", 0, id_LanguageStr)
                objwebsite.id_Grade = IIf(id_GradeStr = "", 0, id_GradeStr)
                CAT_WebsiteUseful_Search = objBCDBS.ConvertTable(objwebsite.CAT_WebsiteUseful_Search)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        Public Function CAT_WebsiteUseful_Search_InRepeater() As DataTable
            Try
                objwebsite.id_L = IIf(id_LStr = "", 0, id_LStr)
                objwebsite.id_Format = IIf(id_FormatStr = "", 0, id_FormatStr)
                objwebsite.id_Lexile = IIf(id_LexileStr = "", 0, id_LexileStr)
                objwebsite.id_Language = IIf(id_LanguageStr = "", 0, id_LanguageStr)
                objwebsite.id_Grade = IIf(id_GradeStr = "", 0, id_GradeStr)
                CAT_WebsiteUseful_Search_InRepeater = objBCDBS.ConvertTable(objwebsite.CAT_WebsiteUseful_Search_InRepeater)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_WebsiteUseful_sl_id() As DataTable
            Try
                objwebsite.id = idStr
                CAT_WebsiteUseful_sl_id = objBCDBS.ConvertTable(objwebsite.CAT_WebsiteUseful_sl_id)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_WebsiteUseful_sl_all() As DataTable
            Try
                objwebsite.id_L = id_LStr
                objwebsite.NN = NNStr
                CAT_WebsiteUseful_sl_all = objBCDBS.ConvertTable(objwebsite.CAT_WebsiteUseful_sl_all)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_WebsiteUseful_de(ByVal intCo_ID As Integer) As Integer
            Try
                CAT_WebsiteUseful_de = objwebsite.CAT_WebsiteUseful_de(intCo_ID)
            Catch ex As Exception
                'Return error if sub delete not succeed
                strErrorMsg = objwebsite.ErrorMsg
                intErrorCode = objwebsite.id
            End Try
        End Function

        Public Function CAT_WebsiteUseful_up_vi_tri(ByVal intSelect As Integer) As Integer
            Try
                objwebsite.id = idStr
                objwebsite.id_L = id_LStr
                objwebsite.Vi_tri = Vi_triStr
                objwebsite.Loai = LoaiStr
                objwebsite.CAT_WebsiteUseful_up_vi_tri()
                CAT_WebsiteUseful_up_vi_tri = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objwebsite.ErrorMsg
                intErrorCode = objwebsite.id
            End Try
        End Function

        Public Function CAT_WebsiteUseful_up(ByVal intSelect As Integer) As Integer
            Try
                objwebsite.id = idStr
                objwebsite.id_L = id_LStr
                objwebsite.Loai = LoaiStr
                objwebsite.NN = NNStr
                objwebsite.Anh = AnhStr
                objwebsite.Hot = HotStr
                objwebsite.GioiThieu = GioiThieuStr
                objwebsite.Author = AuthorStr
                objwebsite.Link = LinkStr

                objwebsite.id_Format = id_FormatStr
                objwebsite.id_Lexile = id_LexileStr
                objwebsite.id_Language = id_LanguageStr
                objwebsite.id_Grade = id_GradeStr

                objwebsite.CAT_WebsiteUseful_up()
                CAT_WebsiteUseful_up = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objwebsite.ErrorMsg
                intErrorCode = objwebsite.id
            End Try
        End Function

        Public Function CAT_WebsiteUseful_update_Status(ByVal intSelect As Integer) As Integer
            Try
                objwebsite.id = idStr
                objwebsite.CAT_WebsiteUseful_update_Status()
                CAT_WebsiteUseful_update_Status = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objwebsite.ErrorMsg
                intErrorCode = objwebsite.id
            End Try
        End Function

        Public Function CAT_WebsiteUsefulupdate_Hot(ByVal intSelect As Integer) As Integer
            Try
                objwebsite.id = idStr
                objwebsite.CAT_WebsiteUsefulupdate_Hot()
                CAT_WebsiteUsefulupdate_Hot = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objwebsite.ErrorMsg
                intErrorCode = objwebsite.id
            End Try
        End Function
    End Class
End Namespace
