Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.News
Namespace eMicLibAdmin.BusinessRules.News
    Public Class clsBCAT_Type
        Inherits clsBBase
        Private objType As New clsDCAT_Type
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

        Private id_LStr As Integer
        Public Property id_L() As Integer
            Get
                Return id_LStr
            End Get
            Set(ByVal value As Integer)
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

        Private intLibID As Integer
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal value As Integer)
                intLibID = value
            End Set
        End Property
#End Region

        Public Sub Initialize()
            'Init objDOPACComment object
            objType.DBServer = strDBServer
            objType.ConnectionString = strConnectionString
            objType.Initialize()

        End Sub

        Public Function Create(ByVal intSelect As Integer) As Integer
            Try
                objType.Anh = AnhStr
                objType.GioiThieu = GioiThieuStr
                objType.Hot = HotStr
                objType.id_L = id_LStr
                objType.Link = LinkStr
                objType.Loai = LoaiStr
                objType.NN = NNStr
                objType.Status = StatusStr
                objType.Vi_tri = Vi_triStr
                objType.LibID = intLibID
                Create = objType.Create(intSelect)
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objType.ErrorMsg
                intErrorCode = objType.id
            End Try
        End Function

        Public Function CAT_Type_sl() As DataTable
            Try
                objType.id_L = id_LStr
                objType.NN = NNStr
                objType.LibID = intLibID
                CAT_Type_sl = objBCDBS.ConvertTable(objType.CAT_Type_sl)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_Type_sl_id() As DataTable
            Try
                objType.id = idStr
                CAT_Type_sl_id = objBCDBS.ConvertTable(objType.CAT_Type_sl_id)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_Type_sl_all() As DataTable
            Try
                objType.id_L = id_LStr
                objType.NN = NNStr
                objType.LibID = intLibID
                CAT_Type_sl_all = objBCDBS.ConvertTable(objType.CAT_Type_sl_all)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CAT_Type_de(ByVal intCo_ID As Integer) As Integer
            Try
                CAT_Type_de = objType.CAT_Type_de(intCo_ID)
            Catch ex As Exception
                'Return error if sub delete not succeed
                strErrorMsg = objType.ErrorMsg
                intErrorCode = objType.id
            End Try
        End Function

        Public Function CAT_Type_up_vi_tri(ByVal intSelect As Integer) As Integer
            Try
                objType.id = idStr
                objType.id_L = id_LStr
                objType.Vi_tri = Vi_triStr
                objType.Loai = LoaiStr
                objType.CAT_Type_up_vi_tri()
                CAT_Type_up_vi_tri = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objType.ErrorMsg
                intErrorCode = objType.id
            End Try
        End Function

        Public Function CAT_Type_up(ByVal intSelect As Integer) As Integer
            Try
                objType.id = idStr
                objType.id_L = id_LStr
                objType.Loai = LoaiStr
                objType.NN = NNStr
                objType.Anh = AnhStr
                objType.Hot = HotStr
                objType.GioiThieu = GioiThieuStr
                objType.CAT_Type_up()
                CAT_Type_up = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objType.ErrorMsg
                intErrorCode = objType.id
            End Try
        End Function

        Public Function CAT_Type_update_Status(ByVal intSelect As Integer) As Integer
            Try
                objType.id = idStr
                objType.CAT_Type_update_Status()
                CAT_Type_update_Status = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objType.ErrorMsg
                intErrorCode = objType.id
            End Try
        End Function

        Public Function CAT_Typeupdate_Hot(ByVal intSelect As Integer) As Integer
            Try
                objType.id = idStr
                objType.CAT_Typeupdate_Hot()
                CAT_Typeupdate_Hot = 1
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objType.ErrorMsg
                intErrorCode = objType.id
            End Try
        End Function

    End Class
End Namespace

