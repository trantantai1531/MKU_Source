Imports System
Imports System.Text
Imports System.IO
Imports System.Text.Encoding
Imports System.Security.Cryptography


Public Class clsLicense

    Public Shared Function CheckLicense() As Boolean
        Dim _result As Boolean = False
        Try
            Dim _flic As String = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\bin\MLEmiclib.lic"
            Dim myInputString As String = ""
            Dim myStreamReader As StreamReader
            myStreamReader = File.OpenText(_flic)
            myInputString = myStreamReader.ReadToEnd
            Dim cls As New clsLicenseCrypt
            Dim TempArr() As String
            TempArr = Split(myInputString, vbCrLf)
            Dim _biosId As String = GetBios_ID()
            Dim _cpuId As String = GetCPU_ID()
            If cls.psEncrypt(_biosId) = TempArr(0) AndAlso cls.psEncrypt(_cpuId) = TempArr(1) Then
                _result = True
            End If
            cls = Nothing
        Catch ex As Exception
        End Try
        Return _result
    End Function

    Private Shared Function GetBios_ID() As String
        Dim strReturn As String = ""
        Try
            Dim moSearch As New Management.ManagementObjectSearcher("Select * FROM Win32_BIOS")
            Dim moReturn As Management.ManagementObjectCollection = moSearch.[Get]()

            For Each serial As Management.ManagementObject In moReturn
                strReturn &= serial("SerialNumber").ToString() & " - "
            Next
        Catch ex As Exception
        End Try
        Return strReturn
    End Function

    Private Shared Function GetCPU_ID() As String
        Dim strReturn As String = ""
        Try
            Dim moReturn As Management.ManagementObjectCollection
            Dim moSearch As Management.ManagementObjectSearcher
            Dim mo As Management.ManagementObject

            moSearch = New Management.ManagementObjectSearcher("Select * from Win32_Processor")
            moReturn = moSearch.Get

            For Each mo In moReturn
                strReturn &= mo("ProcessorID") & " - "
            Next
        Catch ex As Exception
        End Try
        Return strReturn
    End Function

    Private Shared Function GetHardDisk_ID() As String
        Dim strReturn As String = ""
        Try
            Dim moReturn As Management.ManagementObjectCollection
            Dim moSearch As Management.ManagementObjectSearcher
            Dim mo As Management.ManagementObject
            moSearch = New Management.ManagementObjectSearcher("Select * from Win32_LogicalDisk")
            moReturn = moSearch.Get
            For Each mo In moReturn
                Dim VolumeName As String = mo("Volumename")
                Dim SerialNumber As String = mo("Volumeserialnumber")
                Dim strOut As String = String.Format("{0} - {1}", VolumeName, SerialNumber)
                strReturn &= strOut & " - "
            Next
        Catch ex As Exception
        End Try
        Return strReturn
    End Function
End Class
