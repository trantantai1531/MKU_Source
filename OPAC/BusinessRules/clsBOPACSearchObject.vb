Imports Microsoft.VisualBasic
Imports System.Data

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACSearchObjectSimple
        Public Property ISBN() As Integer
        Public Property TACGIA() As String
        Public Property NHANDE() As String
        Public Property LANXUATBAN() As Integer
        Public Property THONGTINXUATBAN() As Integer
        Public Property MOTATVATLY() As Integer
        Public Property TUNGTHU() As String
        Public Property MUCTUBOTRO() As String
        Public Property MUCTUANPHAM() As String
        Public Property BIA() As Double
    End Class

    Public Class clsBOPACSearchObjectISBD
        Public Property FileId() As Integer
        Public Property LinkPage() As Integer
        Public Property Contents() As String
        Public Property DocID() As Integer
    End Class
End Namespace

