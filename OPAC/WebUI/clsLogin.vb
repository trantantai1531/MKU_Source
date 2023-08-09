Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.IO
Imports System.Runtime.InteropServices
Imports XCrypt

Namespace eMicLibLogin
    Public Class clseMicLibLogin
        ' Methods
        Public Sub New()
            Me.pathLogin = Me.SetPathLogin
            Me.strDBServer = "SQLSERVER"
        End Sub

        Public Sub AddNewConnection(ByVal strUserName As String, ByVal strPassWord As String, ByVal strDataSource As String, ByVal strServerIP As String, ByVal strConnectionName As String, Optional ByVal blnRun As Boolean = False)
            Dim xmlFile As DataTable
            Dim engine As New XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.TripleDES)
            Dim num As Integer = 1
            Dim info As New FileInfo(Me.pathLogin)
            If info.Exists Then
                xmlFile = Me.GetXmlFile(Me.pathLogin)
                info.Delete()
            End If
            Dim writer As StreamWriter = File.CreateText(Me.pathLogin)
            writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            writer.WriteLine("<Head>")
            If ((Not xmlFile Is Nothing) AndAlso (xmlFile.Rows.Count > 0)) Then
                Dim num2 As Integer = (xmlFile.Rows.Count - 1)
                num = 0
                Do While (num <= num2)
                    writer.WriteLine("<data>")
                    writer.WriteLine(("<ID>" & StringType.FromInteger((num + 1)) & "</ID>"))
                    writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<UserName>", xmlFile.Rows.Item(num).Item("UserName")), "</UserName>"))
                    writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<PassWord>", xmlFile.Rows.Item(num).Item("PassWord")), "</PassWord>"))
                    writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DataSource>", xmlFile.Rows.Item(num).Item("DataSource")), "</DataSource>"))
                    writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ServerIP>", xmlFile.Rows.Item(num).Item("ServerIP")), "</ServerIP>"))
                    writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DBServer>", xmlFile.Rows.Item(num).Item("DBServer")), "</DBServer>"))
                    writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ConnectionName>", xmlFile.Rows.Item(num).Item("ConnectionName")), "</ConnectionName>"))
                    If blnRun Then
                        writer.WriteLine("<Run>0</Run>")
                    Else
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<Run>", xmlFile.Rows.Item(num).Item("Run")), "</Run>"))
                    End If
                    writer.WriteLine("</data>")
                    num += 1
                Loop
                num = (xmlFile.Rows.Count + 1)
            Else
                blnRun = True
            End If
            writer.WriteLine("<data>")
            writer.WriteLine(("<ID>" & StringType.FromInteger(num) & "</ID>"))
            writer.WriteLine(("<UserName>" & strUserName & "</UserName>"))
            writer.WriteLine(("<PassWord>" & engine.Encrypt(strPassWord) & "</PassWord>"))
            writer.WriteLine(("<DataSource>" & strDataSource & "</DataSource>"))
            writer.WriteLine(("<ServerIP>" & strServerIP & "</ServerIP>"))
            writer.WriteLine(("<DBServer>" & Me.strDBServer & "</DBServer>"))
            writer.WriteLine(("<ConnectionName>" & strConnectionName & "</ConnectionName>"))
            writer.WriteLine(("<Run>" & StringType.FromInteger(Math.Abs(CInt(-(blnRun > False)))) & "</Run>"))
            writer.WriteLine("</data>")
            writer.WriteLine("</Head>")
            writer.Close()
            writer = Nothing
        End Sub

        Public Sub DeleteConnection(ByVal strConnIDs As String)
            Dim xmlFile As DataTable
            Dim num As Integer = 1
            Dim num2 As Integer = 1
            Dim info As New FileInfo(Me.pathLogin)
            Dim flag As Boolean = False
            If info.Exists Then
                xmlFile = Me.GetXmlFile(Me.pathLogin)
                info.Delete()
            End If
            strConnIDs = (",," & strConnIDs & ",")
            Dim writer As StreamWriter = File.CreateText(Me.pathLogin)
            writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            writer.WriteLine("<Head>")
            If ((Not xmlFile Is Nothing) AndAlso (xmlFile.Rows.Count > 0)) Then
                Dim num4 As Integer = (xmlFile.Rows.Count - 1)
                num = 0
                Do While (num <= num4)
                    If ((Strings.InStr(strConnIDs, StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(",", xmlFile.Rows.Item(num).Item("ID")), ",")), 0) > 0) AndAlso (ObjectType.ObjTst(xmlFile.Rows.Item(num).Item("Run"), "1", False) = 0)) Then
                        flag = True
                        Exit Do
                    End If
                    num += 1
                Loop
                Dim num3 As Integer = (xmlFile.Rows.Count - 1)
                num = 0
                Do While (num <= num3)
                    If (Strings.InStr(strConnIDs, StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(",", xmlFile.Rows.Item(num).Item("ID")), ",")), 0) = 0) Then
                        writer.WriteLine("<data>")
                        writer.WriteLine(("<ID>" & StringType.FromInteger(num2) & "</ID>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<UserName>", xmlFile.Rows.Item(num).Item("UserName")), "</UserName>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<PassWord>", xmlFile.Rows.Item(num).Item("PassWord")), "</PassWord>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DataSource>", xmlFile.Rows.Item(num).Item("DataSource")), "</DataSource>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ServerIP>", xmlFile.Rows.Item(num).Item("ServerIP")), "</ServerIP>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DBServer>", xmlFile.Rows.Item(num).Item("DBServer")), "</DBServer>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ConnectionName>", xmlFile.Rows.Item(num).Item("ConnectionName")), "</ConnectionName>"))
                        If flag Then
                            writer.WriteLine("<Run>1</Run>")
                            flag = False
                        Else
                            writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<Run>", xmlFile.Rows.Item(num).Item("Run")), "</Run>"))
                        End If
                        writer.WriteLine("</data>")
                        num2 += 1
                    End If
                    num += 1
                Loop
            End If
            writer.WriteLine("</Head>")
            writer.Close()
            writer = Nothing
        End Sub

        Public Sub DeleteConnection(ByVal strDBName As String, ByVal strDBServer As String, Optional ByVal strIPHost As String = "")
            Dim xmlFile As DataTable
            Dim num As Integer = 1
            Dim num2 As Integer = 1
            Dim info As New FileInfo(Me.pathLogin)
            Dim flag As Boolean = False
            If info.Exists Then
                xmlFile = Me.GetXmlFile(Me.pathLogin)
                info.Delete()
            End If
            Dim writer As StreamWriter = File.CreateText(Me.pathLogin)
            writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            writer.WriteLine("<Head>")
            If ((Not xmlFile Is Nothing) AndAlso (xmlFile.Rows.Count > 0)) Then
                Dim num4 As Integer = (xmlFile.Rows.Count - 1)
                num = 0
                Do While (num <= num4)
                    If (((((StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("UserName")).ToUpper, strDBName.ToUpper, False) = 0) And (StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("DBServer")).ToUpper, strDBServer.ToUpper, False) = 0)) And (StringType.StrCmp(strDBServer.ToUpper, "ORACLE", False) = 0)) Or ((((StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("DataSource")).ToUpper, strDBName.ToUpper, False) = 0) And (StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("DBServer")).ToUpper, strDBServer.ToUpper, False) = 0)) And (StringType.StrCmp(strDBServer.ToUpper, "SQLSERVER", False) = 0)) And (StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("ServerIP")).ToUpper, strIPHost.ToUpper, False) = 0))) AndAlso (ObjectType.ObjTst(xmlFile.Rows.Item(num).Item("Run"), "1", False) = 0)) Then
                        flag = True
                        Exit Do
                    End If
                    num += 1
                Loop
                Dim num3 As Integer = (xmlFile.Rows.Count - 1)
                num = 0
                Do While (num <= num3)
                    If ((StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("UserName")).Trim, "", False) <> 0) AndAlso Not ((((StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("UserName")).ToUpper, strDBName.ToUpper, False) = 0) And (StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("DBServer")).ToUpper, strDBServer.ToUpper, False) = 0)) And (StringType.StrCmp(strDBServer.ToUpper, "ORACLE", False) = 0)) Or ((((StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("DataSource")).ToUpper, strDBName.ToUpper, False) = 0) And (StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("DBServer")).ToUpper, strDBServer.ToUpper, False) = 0)) And (StringType.StrCmp(strDBServer.ToUpper, "SQLSERVER", False) = 0)) And (StringType.StrCmp(StringType.FromObject(xmlFile.Rows.Item(num).Item("ServerIP")).ToUpper, strIPHost.ToUpper, False) = 0)))) Then
                        writer.WriteLine("<data>")
                        writer.WriteLine(("<ID>" & StringType.FromInteger(num2) & "</ID>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<UserName>", xmlFile.Rows.Item(num).Item("UserName")), "</UserName>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<PassWord>", xmlFile.Rows.Item(num).Item("PassWord")), "</PassWord>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DataSource>", xmlFile.Rows.Item(num).Item("DataSource")), "</DataSource>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ServerIP>", xmlFile.Rows.Item(num).Item("ServerIP")), "</ServerIP>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DBServer>", xmlFile.Rows.Item(num).Item("DBServer")), "</DBServer>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ConnectionName>", xmlFile.Rows.Item(num).Item("ConnectionName")), "</ConnectionName>"))
                        If flag Then
                            writer.WriteLine("<Run>1</Run>")
                            flag = False
                        Else
                            writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<Run>", xmlFile.Rows.Item(num).Item("Run")), "</Run>"))
                        End If
                        writer.WriteLine("</data>")
                        num2 += 1
                    End If
                    num += 1
                Loop
            End If
            writer.WriteLine("</Head>")
            writer.Close()
            writer = Nothing
        End Sub

        Public Function GetConnectionString(Optional ByVal intConnID As Integer = 0) As String
            Dim dBConnection As DataTable = Me.GetDBConnection
            Dim message As String = ""
            Try
                Dim num As Integer
                Dim str3 As String
                Dim str4 As String
                Dim str5 As String
                Dim str6 As String
                If ((dBConnection Is Nothing) OrElse (dBConnection.Rows.Count <= 0)) Then
                    Return message
                End If
                Dim num3 As Integer = (dBConnection.Rows.Count - 1)
                num = 0
                Do While (num <= num3)
                    If (ObjectType.ObjTst(dBConnection.Rows.Item(num).Item("ID"), intConnID, False) = 0) Then
                        If (ObjectType.ObjTst(dBConnection.Rows.Item(num).Item("DBServer"), "SQLSERVER", False) = 0) Then
                            Me.DBServer = "SQLSERVER"
                            str6 = StringType.FromObject(dBConnection.Rows.Item(num).Item("UserName"))
                            str3 = StringType.FromObject(dBConnection.Rows.Item(num).Item("DataSource"))
                            str4 = StringType.FromObject(dBConnection.Rows.Item(num).Item("ServerIP"))
                            str5 = StringType.FromObject(dBConnection.Rows.Item(num).Item("PassWord"))
                            Return String.Concat(New String() {"Data Source=", str4, ";Initial Catalog=", str3, ";UID=", str6, ";PWD=", str5, ";"})
                        End If
                        Me.DBServer = "ORACLE"
                        str6 = StringType.FromObject(dBConnection.Rows.Item(num).Item("UserName"))
                        str3 = StringType.FromObject(dBConnection.Rows.Item(num).Item("DataSource"))
                        str4 = StringType.FromObject(dBConnection.Rows.Item(num).Item("ServerIP"))
                        str5 = StringType.FromObject(dBConnection.Rows.Item(num).Item("PassWord"))
                        Return String.Concat(New String() {"User ID=", str6, ";Password=", str5, ";Data Source=", str3})
                    End If
                    num += 1
                Loop
                Dim num2 As Integer = (dBConnection.Rows.Count - 1)
                num = 0
                Do While (num <= num2)
                    If (ObjectType.ObjTst(dBConnection.Rows.Item(num).Item("Run"), 1, False) = 0) Then
                        If (ObjectType.ObjTst(dBConnection.Rows.Item(num).Item("DBServer"), "SQLSERVER", False) = 0) Then
                            Me.DBServer = "SQLSERVER"
                            str6 = StringType.FromObject(dBConnection.Rows.Item(num).Item("UserName"))
                            str3 = StringType.FromObject(dBConnection.Rows.Item(num).Item("DataSource"))
                            str4 = StringType.FromObject(dBConnection.Rows.Item(num).Item("ServerIP"))
                            str5 = StringType.FromObject(dBConnection.Rows.Item(num).Item("PassWord"))
                            Return String.Concat(New String() {"Data Source=", str4, ";Initial Catalog=", str3, ";UID=", str6, ";PWD=", str5, ";"})
                        End If
                        Me.DBServer = "ORACLE"
                        str6 = StringType.FromObject(dBConnection.Rows.Item(num).Item("UserName"))
                        str3 = StringType.FromObject(dBConnection.Rows.Item(num).Item("DataSource"))
                        str4 = StringType.FromObject(dBConnection.Rows.Item(num).Item("ServerIP"))
                        str5 = StringType.FromObject(dBConnection.Rows.Item(num).Item("PassWord"))
                        Return String.Concat(New String() {"User ID=", str6, ";Password=", str5, ";Data Source=", str3})
                    End If
                    num += 1
                Loop
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                message = exception.Message
                ProjectData.ClearProjectError()
            End Try
            Return message
        End Function

        Public Function GetConnStringForZ3950() As String
            Dim dBConnection As DataTable = Me.GetDBConnection
            Dim message As String = ""
            Try
                If ((dBConnection Is Nothing) OrElse (dBConnection.Rows.Count <= 0)) Then
                    Return message
                End If
                Dim num2 As Integer = (dBConnection.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (ObjectType.ObjTst(dBConnection.Rows.Item(i).Item("Run"), 1, False) = 0) Then
                        Dim str3 As String
                        Dim str4 As String
                        Dim str5 As String
                        Dim str6 As String
                        If (ObjectType.ObjTst(dBConnection.Rows.Item(i).Item("DBServer"), "SQLSERVER", False) = 0) Then
                            Me.DBServer = "SQLSERVER"
                            str6 = StringType.FromObject(dBConnection.Rows.Item(i).Item("UserName"))
                            str3 = StringType.FromObject(dBConnection.Rows.Item(i).Item("DataSource"))
                            str4 = StringType.FromObject(dBConnection.Rows.Item(i).Item("ServerIP"))
                            str5 = StringType.FromObject(dBConnection.Rows.Item(i).Item("PassWord"))
                            Return String.Concat(New String() {"DRIVER={SQL Server};SERVER=", str4, ";UID=", str6, ";PWD=", str5, ";DATABASE=", str3, ";Address=", str4, ",1433;Network=DBMSSOCN;"})
                        End If
                        Me.DBServer = "ORACLE"
                        str6 = StringType.FromObject(dBConnection.Rows.Item(i).Item("UserName"))
                        str3 = StringType.FromObject(dBConnection.Rows.Item(i).Item("DataSource"))
                        str4 = StringType.FromObject(dBConnection.Rows.Item(i).Item("ServerIP"))
                        str5 = StringType.FromObject(dBConnection.Rows.Item(i).Item("PassWord"))
                        Return String.Concat(New String() {"Provider=MSDAORA.1;User ID=", str6, ";Password=", str5, ";Data Source=", str3})
                    End If
                    i += 1
                Loop
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                message = exception.Message
                ProjectData.ClearProjectError()
            End Try
            Return message
        End Function

        Public Function GetDBConnection() As DataTable
            Dim info As New FileInfo(Me.pathLogin)
            If info.Exists Then
                Dim xmlFile As DataTable = Me.GetXmlFile(Me.pathLogin)
                Dim engine As New XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.TripleDES)
                If ((Not xmlFile Is Nothing) AndAlso (xmlFile.Rows.Count > 0)) Then
                    Dim num2 As Integer = (xmlFile.Rows.Count - 1)
                    Dim i As Integer = 0
                    Do While (i <= num2)
                        If (ObjectType.ObjTst(xmlFile.Rows.Item(i).Item("Password"), "", False) <> 0) Then
                            xmlFile.Rows.Item(i).Item("Password") = engine.Decrypt(StringType.FromObject(xmlFile.Rows.Item(i).Item("Password")))
                        End If
                        i += 1
                    Loop
                End If
                engine = Nothing
                Return xmlFile
            End If
            Return Nothing
        End Function

        Private Function GetXmlFile(ByVal strFileNameXml As String) As DataTable
            Dim table As DataTable = Nothing
            Dim ds As New DataSet
            Try
                ds.ReadXml(strFileNameXml)
                If (ds.Tables.Count > 0) Then
                    table = ds.Tables.Item(0)
                    ds.Tables.Clear()
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError()
            End Try
            Return table
        End Function

        Private Function SetPathLogin() As String
             Dim str As String = "C:\Program Files\DGSoft\WLoginDB.xml"
            Dim info As New FileInfo(str)
            If Not info.Exists Then
                Dim strPath As String = System.Web.HttpContext.Current.Server.MapPath("~")
                If Not strPath.EndsWith("\") Then
                    strPath &= "\"
                End If
                str = strPath & "DataXML\WLoginDB.xml"
            End If
            Return str
        End Function

        Public Sub UpdateConnection(ByVal intConnID As Integer, ByVal strUserName As String, ByVal strPassWord As String, ByVal strDataSource As String, ByVal strServerIP As String, ByVal strConnectionName As String, Optional ByVal blnRun As Boolean = False)
            Dim xmlFile As DataTable
            Dim engine As New XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.TripleDES)
            Dim info As New FileInfo(Me.pathLogin)
            If info.Exists Then
                xmlFile = Me.GetXmlFile(Me.pathLogin)
                info.Delete()
            End If
            Dim writer As StreamWriter = File.CreateText(Me.pathLogin)
            writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            writer.WriteLine("<Head>")
            If ((Not xmlFile Is Nothing) AndAlso (xmlFile.Rows.Count > 0)) Then
                Dim num2 As Integer = (xmlFile.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If ((intConnID > 0) AndAlso (ObjectType.ObjTst(xmlFile.Rows.Item(i).Item("ID"), intConnID, False) = 0)) Then
                        writer.WriteLine("<data>")
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ID>", xmlFile.Rows.Item(i).Item("ID")), "</ID>"))
                        writer.WriteLine(("<UserName>" & strUserName & "</UserName>"))
                        writer.WriteLine(("<PassWord>" & engine.Encrypt(strPassWord) & "</PassWord>"))
                        writer.WriteLine(("<DataSource>" & strDataSource & "</DataSource>"))
                        writer.WriteLine(("<ServerIP>" & strServerIP & "</ServerIP>"))
                        writer.WriteLine(("<DBServer>" & Me.strDBServer & "</DBServer>"))
                        writer.WriteLine(("<ConnectionName>" & strConnectionName & "</ConnectionName>"))
                        writer.WriteLine(("<Run>" & StringType.FromInteger(Math.Abs(CInt(-(blnRun > False)))) & "</Run>"))
                        writer.WriteLine("</data>")
                    Else
                        writer.WriteLine("<data>")
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ID>", xmlFile.Rows.Item(i).Item("ID")), "</ID>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<UserName>", xmlFile.Rows.Item(i).Item("UserName")), "</UserName>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<PassWord>", xmlFile.Rows.Item(i).Item("PassWord")), "</PassWord>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DataSource>", xmlFile.Rows.Item(i).Item("DataSource")), "</DataSource>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ServerIP>", xmlFile.Rows.Item(i).Item("ServerIP")), "</ServerIP>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<DBServer>", xmlFile.Rows.Item(i).Item("DBServer")), "</DBServer>"))
                        writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<ConnectionName>", xmlFile.Rows.Item(i).Item("ConnectionName")), "</ConnectionName>"))
                        If blnRun Then
                            writer.WriteLine("<Run>0</Run>")
                        Else
                            writer.WriteLine(ObjectType.StrCatObj(ObjectType.StrCatObj("<Run>", xmlFile.Rows.Item(i).Item("Run")), "</Run>"))
                        End If
                        writer.WriteLine("</data>")
                    End If
                    i += 1
                Loop
            Else
                writer.WriteLine("<data>")
                writer.WriteLine("<ID>1</ID>")
                writer.WriteLine(("<UserName>" & strUserName & "</UserName>"))
                writer.WriteLine(("<PassWord>" & engine.Encrypt(strPassWord) & "</PassWord>"))
                writer.WriteLine(("<DataSource>" & strDataSource & "</DataSource>"))
                writer.WriteLine(("<ServerIP>" & strServerIP & "</ServerIP>"))
                writer.WriteLine(("<DBServer>" & Me.strDBServer & "</DBServer>"))
                writer.WriteLine(("<ConnectionName>" & strConnectionName & "</ConnectionName>"))
                writer.WriteLine("<Run>1</Run>")
                writer.WriteLine("</data>")
            End If
            writer.WriteLine("</Head>")
            writer.Close()
            writer = Nothing
        End Sub


        ' Properties
        Public Property DBServer As String
            Get
                Return Me.strDBServer
            End Get
            Set(ByVal Value As String)
                Me.strDBServer = Value
            End Set
        End Property

        Public ReadOnly Property GetpathLogin As String
            Get
                Return Me.pathLogin
            End Get
        End Property


        ' Fields
        Public Const fileInstallLog As String = "\eMicLibInstall.log"
        Private pathLogin As String
        Private strDBServer As String
    End Class
End Namespace

