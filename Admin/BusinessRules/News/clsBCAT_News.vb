Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.News

Namespace eMicLibAdmin.BusinessRules.News
    Public Class clsBCAT_News
        Inherits clsBBase
        Private objNews As New clsDCAT_News
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

#Region "Propertites"

        Private idStr As String
        Public Property id() As String
            Get
                Return idStr
            End Get
            Set(ByVal value As String)
                idStr = value
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

        Private id_LStr As Integer
        Public Property id_L() As Integer
            Get
                Return id_LStr
            End Get
            Set(ByVal value As Integer)
                id_LStr = value
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

        Private Tieu_deStr As String
        Public Property Tieu_de() As String
            Get
                Return Tieu_deStr
            End Get
            Set(ByVal value As String)
                Tieu_deStr = value
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

        Private Tom_tatStr As String
        Public Property Tom_tat() As String
            Get
                Return Tom_tatStr
            End Get
            Set(ByVal value As String)
                Tom_tatStr = value
            End Set
        End Property

        Private Noi_dungStr As String
        Public Property Noi_dung() As String
            Get
                Return Noi_dungStr
            End Get
            Set(ByVal value As String)
                Noi_dungStr = value
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

        Private iconNewStr As String
        Public Property iconNew() As String
            Get
                Return iconNewStr
            End Get
            Set(ByVal value As String)
                iconNewStr = value
            End Set
        End Property

        Private TitleStr As String
        Public Property Title() As String
            Get
                Return TitleStr
            End Get
            Set(ByVal value As String)
                TitleStr = value
            End Set
        End Property

        Private MetaMoTaStr As String
        Public Property MetaMoTa() As String
            Get
                Return MetaMoTaStr
            End Get
            Set(ByVal value As String)
                MetaMoTaStr = value
            End Set
        End Property

        Private KeywordStr As String
        Public Property Keyword() As String
            Get
                Return KeywordStr
            End Get
            Set(ByVal value As String)
                KeywordStr = value
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

        Private TKStr As String
        Public Property TK() As String
            Get
                Return TKStr
            End Get
            Set(ByVal value As String)
                TKStr = value
            End Set
        End Property

        Private id_CStr As String
        Public Property id_C() As String
            Get
                Return id_CStr
            End Get
            Set(ByVal value As String)
                id_CStr = value
            End Set
        End Property

        Private intLibID As Integer = 0
        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
#End Region

        Public Sub Initialize()
            'Init objDOPACComment object
            objNews.DBServer = strDBServer
            objNews.ConnectionString = strConnectionString
            objNews.Initialize()

            'Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            'Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub


        Public Function Create(ByVal intSelect As Integer) As Integer
            Try
                objNews.id_L = id_LStr
                objNews.Hot = HotStr
                objNews.Tieu_de = Tieu_deStr
                objNews.Anh = AnhStr
                objNews.Tom_tat = Tom_tatStr
                objNews.Noi_dung = Noi_dungStr
                objNews.NN = NNStr
                objNews.iconNew = iconNewStr
                objNews.Title = TitleStr
                objNews.MetaMoTa = MetaMoTaStr
                objNews.DuoiAnh = DuoiAnhStr
                objNews.Keyword = KeywordStr
                objNews.LibID = intLibID
                Create = objNews.Create(intSelect)
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.id
            End Try
        End Function

        Public Function Update(ByVal intSelect As Integer) As Integer
            Try
                objNews.id = idStr
                objNews.id_L = id_LStr
                objNews.Hot = HotStr
                objNews.Tieu_de = Tieu_deStr
                objNews.Anh = AnhStr
                objNews.Tom_tat = Tom_tatStr
                objNews.Noi_dung = Noi_dungStr
                objNews.NN = NNStr
                objNews.iconNew = iconNewStr
                objNews.Title = TitleStr
                objNews.MetaMoTa = MetaMoTaStr
                objNews.Keyword = KeywordStr
                objNews.Update()
                Update = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.id
            End Try
        End Function

        Public Function News_update_Hot(ByVal intSelect As Integer) As Integer
            Try
                objNews.id = idStr
                objNews.News_update_Hot()
                News_update_Hot = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.id
            End Try
        End Function

        Public Function News_update_Status(ByVal intSelect As Integer) As Integer
            Try
                objNews.id = idStr
                objNews.News_update_Status()
                News_update_Status = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.id
            End Try
        End Function

        Public Function CAT_News_up_vi_tri(ByVal intSelect As Integer) As Integer
            Try
                objNews.id = idStr
                objNews.Vi_tri = Vi_triStr
                objNews.CAT_News_up_vi_tri()
                CAT_News_up_vi_tri = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.id
            End Try
        End Function

        Public Function CAT_News_sl_admin() As DataTable
            Try
                objNews.NN = NNStr
                objNews.id_L = id_LStr
                objNews.LibID = intLibID
                CAT_News_sl_admin = objBCDBS.ConvertTable(objNews.CAT_News_sl_admin_all)
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_News_sl_admin_all() As DataTable
            Try
                objNews.NN = NNStr
                objNews.id_L = id_LStr
                objNews.id_C = id_CStr
                objNews.LibID = intLibID
                CAT_News_sl_admin_all = objBCDBS.ConvertTable(objNews.CAT_News_sl_admin_all)
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        Public Function CAT_News_sl_id() As DataTable
            Try
                objNews.id = idStr
                CAT_News_sl_id = objBCDBS.ConvertTable(objNews.CAT_News_sl_id)
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_News_SelectId_L() As DataTable
            Try
                objNews.id_L = id_LStr
                objNews.NN = NNStr
                CAT_News_SelectId_L = objBCDBS.ConvertTable(objNews.CAT_News_SelectId_L)
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_News_sl_id_out() As DataTable
            Try
                objNews.id = idStr
                CAT_News_sl_id_out = objBCDBS.ConvertTable(objNews.CAT_News_sl_id_out)
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_News_sl_admin_search() As DataTable
            Try
                objNews.id_L = id_LStr
                objNews.NN = NNStr
                objNews.TK = TKStr
                objNews.LibID = intLibID
                CAT_News_sl_admin_search = objBCDBS.ConvertTable(objNews.CAT_News_sl_admin_search)
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        Public Function CAT_News_SelectIndex() As DataTable
            Try
                objNews.NN = NNStr
                CAT_News_SelectIndex = objBCDBS.ConvertTable(objNews.CAT_News_SelectIndex)
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        Public Function CAT_News_de_id(ByVal intCo_ID As Integer) As Integer
            Try
                CAT_News_de_id = objNews.CAT_News_de_id(intCo_ID)
            Catch ex As Exception
                'Return error if sub delete not succeed
                strErrorMsg = objNews.ErrorMsg
                intErrorCode = objNews.id
            End Try
        End Function

    End Class
End Namespace

