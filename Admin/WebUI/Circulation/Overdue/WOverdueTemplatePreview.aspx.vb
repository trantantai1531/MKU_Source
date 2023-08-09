' Class: WOverdueTemplatePreview
' Puspose: For preview template
' Creator: Sondp
' CreatedDate: 20/12/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOverdueTemplatePreview
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

        ' Declare variables
        Private objBCSP As New clsBCommonStringProc
        Private objBOverdueTemplate As New clsBOverdueTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call CreateData()
            Call BindScript()
        End Sub

        ' Initialize method
        ' Init all necessary objects
        Private Sub Initialize()
            ' Init objBCSP object
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCSP.Initialize()

            ' Init objBOverdueTemplate object
            objBOverdueTemplate.ConnectionString = Session("ConnectionString")
            objBOverdueTemplate.DBServer = Session("DBServer")
            objBOverdueTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTemplate.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: include some necessary javascript functions
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "javascript:self.close(); return(false);")
        End Sub

        ' Method: CreateData
        Private Sub CreateData()
            ' Header Data
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblCardNumber.Text), "CARDNUMBER")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblName.Text), "NAME")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblDOB.Text), "DOB")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblOcupation.Text), "OCUPATION")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblWorkPlace.Text), "WORKPLACE")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblWorkAddress.Text), "WORKADDRESS")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblHomeAddress.Text), "HOMEADDRESS")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblPhone.Text), "PHONE")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblGrade.Text), "GRADE")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblFaculity.Text), "FACULITY")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblCardValidDate.Text), "CARDVALIDDATE")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblCardExpiredDate.Text), "CARDEXCARDEXPIREDDATEPRE")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblEmail.Text), "EMAIL")
            objBOverdueTemplate.HeaderData.Add(objBCSP.ToUTF8(lblLoanCountData.Text), "LOANCOUNT")

            ' Content Data            
            objBOverdueTemplate.ContentData.Add(lblSequency.Text, "<$SEQUENCY$>")
            objBOverdueTemplate.ContentData.Add(lblCopyNumber.Text, "<$COPYNUMBER$>")
            objBOverdueTemplate.ContentData.Add(lblItemTitle.Text, "<$ITEMTITLE$>")
            objBOverdueTemplate.ContentData.Add(lblItemCode.Text, "<$ITEMCODE$>")
            objBOverdueTemplate.ContentData.Add(lblCheckOutDate.Text, "<$CHECKOUTDATE$>")
            objBOverdueTemplate.ContentData.Add(lblCheckInDate.Text, "<$CHECKINDATE$>")
            objBOverdueTemplate.ContentData.Add(lblOverdueDate.Text, "<$OVERDUEDATE$>")
            objBOverdueTemplate.ContentData.Add(lblPenati.Text, "<$PENATI$>")
            objBOverdueTemplate.ContentData.Add(lblLibrary.Text, "<$LIBRARY$>")
            objBOverdueTemplate.ContentData.Add(lblStore.Text, "<$STORE$>")
            objBOverdueTemplate.ContentData.Add(lblNote.Text, "<$NOTE$>")
            objBOverdueTemplate.ContentData.Add(lblLoanCount.Text, "<$LOANCOUNT$>")

            ' Data display
            objBOverdueTemplate.ContentData.Add(lblSequencyData.Text, "<$SEQUENCYDATA$>")
            objBOverdueTemplate.ContentData.Add(lblCopyNumberData.Text, "<$COPYNUMBERDATA$>")
            objBOverdueTemplate.ContentData.Add(lblItemTitleData.Text, "<$ITEMTITLEDATA$>")
            objBOverdueTemplate.ContentData.Add(lblItemCodeData.Text, "<$ITEMCODEDATA$>")
            objBOverdueTemplate.ContentData.Add(lblCheckOutDateData.Text, "<$CHECKOUTDATEDATA$>")
            objBOverdueTemplate.ContentData.Add(lblCheckInDateData.Text, "<$CHECKINDATEDATA$>")
            objBOverdueTemplate.ContentData.Add(lblOverdueDateData.Text, "<$OVERDUEDATEDATA$>")
            objBOverdueTemplate.ContentData.Add(lblPenatiData.Text, "<$PENATIDATA$>")
            objBOverdueTemplate.ContentData.Add(lblOverdueLibrary.Text, "<$LIBRARYDATA$>")
            objBOverdueTemplate.ContentData.Add(lblOverdueStore.Text, "<$STOREDATA$>")
            objBOverdueTemplate.ContentData.Add(lblNoteData.Text, "<$NOTEDATA$>")
            objBOverdueTemplate.ContentData.Add(lblLoanCountData.Text, "<$LOANCOUNTDATA$>")

            objBOverdueTemplate.Header = Replace(Replace(Request("txtHeader"), "&lt;", "<"), "&gt;", ">")
            objBOverdueTemplate.Collums = Replace(Replace(Request("txtCollum"), "&lt;", "<"), "&gt;", ">")
            objBOverdueTemplate.CollumCaption = Replace(Replace(Request("txtCollumCaption"), "&lt;", "<"), "&gt;", ">")
            objBOverdueTemplate.CollumWidth = Replace(Replace(Request("txtCollumWidth"), "&lt;", "<"), "&gt;", ">")
            objBOverdueTemplate.CollumAlign = Replace(Replace(Request("txtAlign"), "&lt;", "<"), "&gt;", ">")
            objBOverdueTemplate.CollumFormat = Replace(Replace(Request("txtWord"), "&lt;", "<"), "&gt;", ">")
            objBOverdueTemplate.Footer = Replace(Replace(Replace(Request("txtFooter"), "&lt;", "<"), "&gt;", ">"), vbCrLf, "<br/>") & "<br/>" & clsSession.GlbUserFullName

            ' Generate template
            lblOutMsg.Text = objBOverdueTemplate.GenOverdueData
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBOverdueTemplate Is Nothing Then
                    objBOverdueTemplate.Dispose(True)
                    objBOverdueTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace