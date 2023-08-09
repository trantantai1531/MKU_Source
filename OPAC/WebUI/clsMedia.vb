Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Threading
Imports System.Diagnostics

Namespace eMicLibOPAC.WebUI

    Public Class clsMedia
        'Public Shared Function FLV_encode(ByVal filename As String, ByVal width As String, ByVal height As String, ByVal bitrate As String, ByVal samplingrate As String) As String
        '    Try
        '        Dim outfile As String = ""
        '        Dim size As String = width + "*" + height
        '        outfile = System.IO.Path.GetFileNameWithoutExtension(ConfigurationManager.AppSettings("PathFILE").ToString() + filename)
        '        outfile = outfile + ".flv"

        '        Dim ffmpegargs As String = " -i " + ConfigurationManager.AppSettings("PathFILE").ToString() + filename + " -acodec libmp3lame -ar " + samplingrate + " -ab " + bitrate + " -f flv -s " + size + " " + ConfigurationManager.AppSettings("PathFLV").ToString() + outfile
        '        Dim pProcess As New System.Diagnostics.Process()
        '        pProcess.StartInfo.FileName = ConfigurationManager.AppSettings("PathFFMPEG").ToString()
        '        pProcess.StartInfo.UseShellExecute = False
        '        pProcess.StartInfo.RedirectStandardOutput = True
        '        pProcess.StartInfo.CreateNoWindow = True
        '        pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '        pProcess.StartInfo.Arguments = ffmpegargs
        '        pProcess.EnableRaisingEvents = True
        '        pProcess.Start()
        '        pProcess.WaitForExit()
        '        pProcess.Close()
        '        pProcess.Dispose()
        '        Return outfile
        '    Catch err As Exception
        '        Return "KO"
        '    End Try
        'End Function

        'Public Shared Function Grab_image(ByVal filename As String, ByVal frame_number As String, ByVal image_format As String, ByVal width As String, ByVal height As String) As String
        '    Try
        '        Dim outfile As String = ""
        '        Dim size As String = width + "*" + height
        '        outfile = System.IO.Path.GetFileNameWithoutExtension(ConfigurationManager.AppSettings("PathFLV").ToString() + filename)
        '        outfile = outfile + "." + image_format
        '        Dim mid_duration As String = Calculate_Mid_Duration(Get_duration(filename, ""))
        '        Dim ffmpegargs As String = " -i " + ConfigurationManager.AppSettings("PathFLV").ToString() + filename + " -vframes " + frame_number + " -ss " + mid_duration + " -an -vcodec " + image_format + " -f rawvideo -s " + size + " " + ConfigurationManager.AppSettings("PathTHUMBS").ToString() + outfile

        '        Dim pProcess As New System.Diagnostics.Process()
        '        pProcess.StartInfo.FileName = ConfigurationManager.AppSettings("PathFFMPEG").ToString()
        '        pProcess.StartInfo.UseShellExecute = False
        '        pProcess.StartInfo.RedirectStandardOutput = True
        '        pProcess.StartInfo.CreateNoWindow = True
        '        pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '        pProcess.StartInfo.Arguments = ffmpegargs
        '        pProcess.EnableRaisingEvents = True
        '        pProcess.Start()
        '        pProcess.WaitForExit()
        '        pProcess.Close()
        '        pProcess.Dispose()
        '        Return outfile
        '    Catch err As Exception
        '        Return err.ToString
        '    End Try
        'End Function

        'Public Shared Function Calculate_Mid_Duration(ByVal Duration As String) As String
        '    Dim _seconds As String = Duration.Remove(0, Duration.LastIndexOf(":") + 1)
        '    Dim seconds As Double
        '    If _seconds.Chars(2).ToString = "." Then
        '        seconds = Math.Ceiling(Double.Parse(_seconds.Substring(0, _seconds.IndexOf("."))))
        '    Else
        '        seconds = Math.Ceiling(Double.Parse(_seconds))
        '    End If
        '    Dim _minutes As String = Duration.Remove(0, Duration.IndexOf(":") + 1)
        '    Dim minutes As Double = Math.Ceiling(Double.Parse(_minutes.Remove(_minutes.LastIndexOf(":"))))
        '    Dim hours As Double = Math.Ceiling(Double.Parse(Duration.Remove(Duration.IndexOf(":"))))
        '    Dim str As String = ""
        '    If hours > 0 Then
        '        ' divide hours by 2
        '        Dim mid_hours As Integer = CType(hours / 2, Integer)
        '        If mid_hours < 10 Then
        '            str = str + "0" + mid_hours.ToString + ":"
        '        Else
        '            str = str + "" + mid_hours.ToString + ":"
        '        End If
        '    Else
        '        str = str + "00:"
        '    End If
        '    If minutes > 0 Then
        '        ' divide minutes by 2
        '        Dim mid_minutes As Integer = CType(minutes / 2, Integer)
        '        If mid_minutes < 10 Then
        '            str = str + "0" + mid_minutes.ToString + ":"
        '        Else
        '            str = str + "" + mid_minutes.ToString + ":"
        '        End If
        '    Else
        '        str = str + "00:"
        '    End If
        '    If seconds > 0 Then
        '        ' divide seconds by 2
        '        Dim mid_seconds As Double = CType(seconds / 2, Integer)
        '        If mid_seconds < 10 Then
        '            str = str + "0" + mid_seconds.ToString
        '        Else
        '            str = str + "" + mid_seconds.ToString
        '        End If
        '    Else
        '        str = str + "00"
        '    End If
        '    Return str
        'End Function



        'Public Shared Function Set_buffering(ByVal filename As String)
        '    Try
        '        Dim flvtoolsargs As String = " -U " + ConfigurationManager.AppSettings("PathFLV").ToString() + filename
        '        Dim pProcess As New System.Diagnostics.Process()
        '        pProcess.StartInfo.FileName = ConfigurationManager.AppSettings("PathFLVTOOL").ToString()
        '        pProcess.StartInfo.UseShellExecute = False
        '        pProcess.StartInfo.RedirectStandardOutput = True
        '        pProcess.StartInfo.CreateNoWindow = True
        '        pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '        pProcess.StartInfo.Arguments = flvtoolsargs
        '        pProcess.EnableRaisingEvents = True
        '        pProcess.Start()
        '        pProcess.WaitForExit()
        '        pProcess.Close()
        '        pProcess.Dispose()
        '        Return "OK"
        '    Catch err As Exception
        '        Return "KO"
        '    End Try
        'End Function

        Public Shared Function Get_duration(ByVal filename As String, ByVal PathFFMPEG As String) As String
            Try
                Dim ffmpegargs As String = " -i """ & filename & """" ' + " -acodec libmp3lame -ar " + samplingrate + " -ab " + bitrate + " -f flv -s " + size + " " + ConfigurationManager.AppSettings("PathFLV").ToString() + outfile
                Dim pProcess As New System.Diagnostics.Process()
                pProcess.StartInfo.FileName = PathFFMPEG
                pProcess.StartInfo.UseShellExecute = False
                pProcess.StartInfo.RedirectStandardOutput = False
                pProcess.StartInfo.RedirectStandardError = True
                pProcess.StartInfo.CreateNoWindow = True
                pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                pProcess.StartInfo.Arguments = ffmpegargs
                pProcess.EnableRaisingEvents = True
                pProcess.Start()
                Dim Durata As String = pProcess.StandardError.ReadToEnd.ToString
                pProcess.Close()
                pProcess.Dispose()
                Durata = Durata.Remove(0, Durata.LastIndexOf("Duration: ") + 10)
                Durata = Durata.Substring(0, Durata.IndexOf(","))
                Return Durata
            Catch err As Exception
                Return ""
            End Try
        End Function

        'Public Shared Function Set_watermark(ByVal filename As String, ByVal Image As String) As String
        '    Try
        '        Dim ffmpegargs As String = " -i " + ConfigurationManager.AppSettings("PathFLV").ToString() + filename + " -vhook """ + ConfigurationManager.AppSettings("PathFFMPEGdir").ToString() + "vhook\watermark.dll" + " -f " + ConfigurationManager.AppSettings("PathFFMPEGdir").ToString() + Image + """ " + ConfigurationManager.AppSettings("PathFLV").ToString() + filename
        '        Dim pProcess As New System.Diagnostics.Process()
        '        pProcess.StartInfo.FileName = ConfigurationManager.AppSettings("PathFFMPEG").ToString()
        '        pProcess.StartInfo.UseShellExecute = False
        '        pProcess.StartInfo.RedirectStandardOutput = True
        '        pProcess.StartInfo.CreateNoWindow = True
        '        pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '        pProcess.StartInfo.Arguments = ffmpegargs
        '        pProcess.EnableRaisingEvents = True
        '        pProcess.Start()
        '        pProcess.WaitForExit()
        '        pProcess.Close()
        '        pProcess.Dispose()
        '        Return "OK"
        '    Catch err As Exception
        '        Return "KO"
        '    End Try
        'End Function
    End Class

End Namespace

