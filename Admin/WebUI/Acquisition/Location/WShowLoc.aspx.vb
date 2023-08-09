' purpose : Show location diagram
' Create Date 25/11/2004
' Creator : Lent
Imports System.io
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition

    Partial Class WShowLoc
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBLocation As New clsBLocation

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call DrawLocation()
        End Sub
        ' Initialize method
        Private Sub Initialize()
            ' Init objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBLocation.Initialize()
        End Sub

        Private Sub DrawLocation()
            Dim tblResult As DataTable
            Dim intLocID As Integer = 0

            If Request("LocID") & "" <> "" Then
                intLocID = CInt(Request("LocID"))
            End If
            objBLocation.LibID = 0
            objBLocation.LocID = intLocID
            objBLocation.UserID = Session("UserID")
            tblResult = objBLocation.GetHoldingLocSchema("")
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                'Delete old temporary file first
                Dim objFolder As DirectoryInfo
                Dim objFile As FileInfo
                objFolder = New DirectoryInfo(Server.MapPath("../Images/Schema"))
                For Each objFile In objFolder.GetFiles("*.*")
                    If DateAdd(DateInterval.Hour, 3, objFile.CreationTime) <= Now Then
                        Try
                            objFile.Delete()
                        Catch ex As Exception
                            'Call WriteErrorMssg(ddlLabelNote.Items(0).Text, ex.Message, ddlLabelNote.Items(1).Text, ex.ToString)
                        End Try
                    End If
                Next
                objFile = Nothing
                objFolder = Nothing

                objBLocation.ImgWidth = CLng(tblResult.Rows(0).Item("ImgWidth"))
                objBLocation.ImgHeight = CLng(tblResult.Rows(0).Item("ImgHeight"))
                'Write image from database to file..
                Dim strFileName As String = ""
                Dim strExt As String = ".gif"
                Dim imgByte() As Byte

                strExt = tblResult.Rows(0).Item("ImgURL")
                strExt = strExt.Substring(strExt.IndexOf("."), strExt.Length - strExt.IndexOf(".")) 'Get file extension
                strFileName = Server.MapPath("../Images/Schema/") & "TmpImage" & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & strExt
                'imgByte = tblResult.Rows(0).Item("ImgByte")
                imgByte = objBLocation.GetHoldingLocSchemaImage
                Dim objFS As New FileStream(strFileName, FileMode.OpenOrCreate)

                objFS.Write(imgByte, 0, imgByte.Length)
                objFS.Close()
                objFS = Nothing
                '                
                objBLocation.ImgPath = strFileName
                objBLocation.ImgHeightMetter = CDbl(tblResult.Rows(0).Item("ImgHeightMetter"))
                objBLocation.ImgWidthMetter = CDbl(tblResult.Rows(0).Item("ImgWidthMetter"))

                tblResult = Nothing
                tblResult = objBLocation.GetHoldingShelfSchema("", "")

                Response.ClearContent()

                Response.Expires = 0
                Response.ContentType = "image/png"

                ' Display image

                Response.BinaryWrite(objBLocation.ImageOfLocation(tblResult))
            Else
                Response.Expires = 0
                Response.ContentType = "image/png"
            End If
            Response.End()

        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace