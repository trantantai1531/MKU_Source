Imports System.Collections.Specialized
Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WOAIRepository
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBRepository As New clsBRepository

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call LoadData()
        End Sub

        ' Initialize
        Private Sub Initialize()
            objBRepository.ConnectionString = Session("ConnectionString")
            objBRepository.DBServer = Session("DBServer")
            objBRepository.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBRepository.Initialize()
        End Sub

        ' LoadData
        Private Sub LoadData()
            objBRepository.Verb = Request("verb")
            objBRepository.ScriptName = Request.ServerVariables("SCRIPT_NAME")
            objBRepository.Identifier = Request("identifier")
            objBRepository.MetadataPrefix = Request("metadataPrefix")

            Dim strResumptionToken As String
            strResumptionToken = Trim(Request("resumptionToken"))
            Dim blnHasBadArg As Boolean = False
            Dim colVerbDict As New Collection
            Select Case Request("verb")
                Case "Identify"
                    colVerbDict.Add("1", "verb")
                Case "ListMetadataFormats"
                    colVerbDict.Add("1", "verb")
                    colVerbDict.Add("1", "identifier")
                Case "ListSets"
                    colVerbDict.Add("1", "verb")
                    colVerbDict.Add("1", "resumptionToken")
                Case "ListIdentifiers", "ListRecords"
                    If strResumptionToken = "" Then
                        colVerbDict.Add("1", "from")
                        colVerbDict.Add("1", "until")
                        colVerbDict.Add("1", "set")
                        colVerbDict.Add("1", "metadataPrefix")
                        colVerbDict.Add("1", "verb")
                    Else
                        colVerbDict.Add("1", "resumptionToken")
                        colVerbDict.Add("1", "verb")
                    End If
                    If Request("metadataPrefix") = "" And strResumptionToken = "" Then
                        blnHasBadArg = True
                    End If
                    objBRepository.ResumptionToken = strResumptionToken
                    objBRepository.OAISet = Trim(Request("set"))
                    Dim strFromDate As String = ""
                    If Not Trim(Request("from")) = "" Then
                        ' ParseISODate
                        strFromDate = Trim(Request("from"))
                        If Not IsDate(strFromDate) Then
                            blnHasBadArg = True
                        End If
                    End If
                    objBRepository.FromDate = strFromDate
                    Dim strToDate As String = ""
                    If Not Trim(Request("until")) = "" Then
                        ' ParseISODate
                        strToDate = Trim(Request("until"))
                        If Not IsDate(strToDate) Then
                            blnHasBadArg = True
                        End If
                    End If
                    objBRepository.ToDate = strToDate
                Case "GetRecord"
                    colVerbDict.Add("1", "verb")
                    colVerbDict.Add("1", "identifier")
                    colVerbDict.Add("1", "metadataPrefix")
            End Select
            Dim intCount As Integer
            Dim arrNameValueCol() As String
            Dim NameValueCol As NameValueCollection

            ' Load Form variables into NameValueCollection variable.
            If Not Request.ServerVariables("REQUEST_METHOD") = "GET" Then
                NameValueCol = Request.Form
            Else
                NameValueCol = Request.QueryString
            End If
            ' Get names of all forms into a string array.
            arrNameValueCol = NameValueCol.AllKeys
            For intCount = 0 To arrNameValueCol.GetUpperBound(0)
                Try
                    If colVerbDict.Item(arrNameValueCol(intCount)) = "" Then
                        blnHasBadArg = True
                    End If
                Catch ex As Exception
                    blnHasBadArg = True
                    Exit For
                End Try
            Next intCount
            objBRepository.HasBadArg = blnHasBadArg
            Dim SessionID
            If strResumptionToken <> "" Then
                If InStr(strResumptionToken, "pos") > 0 Then
                    SessionID = Left(strResumptionToken, InStr(strResumptionToken, "pos") - 1)
                    objBRepository.IDs = Application(SessionID & "OAIIDs")
                End If
            Else
                SessionID = Session.SessionID
            End If
            Response.ClearHeaders()
            Response.ClearContent()
            Response.ContentType = "text/xml"
            Response.Write(objBRepository.GetRecord())
            If strResumptionToken = "" Then
                Application(SessionID & "OAIIDs") = objBRepository.IDs
            End If
            Response.End()
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRepository Is Nothing Then
                    objBRepository.Dispose(True)
                    objBRepository = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace