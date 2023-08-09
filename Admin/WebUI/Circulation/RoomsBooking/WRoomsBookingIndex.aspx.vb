Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WRoomsBookingIndex
        Inherits clsWBase
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
        End Sub
    End Class
End Namespace

