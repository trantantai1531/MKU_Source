Imports System.Text
Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCataScriptHelper
#If 0 Then
    //add to txtModifiedFieldCodes if this fieldcode wasn't presented.
    u('245');

    //in case of fieldcode 245$a, check for the title
    if (parent.Sentform.location.href.indexOf('WCataSent.aspx') >= 0) {
        parent.Hiddenbase.location.href = 'WCheckItemTitle.aspx?FieldCode=245$a&Value=' + Esc(this.value, 1);
    }
    if (document.forms[0].ind245) {
        if (this.value != '') {
            parent.Sentform.document.forms[0].tag245.value = document.forms[0].ind245.value + '::' + this.value;
        } else {
            parent.Sentform.document.forms[0].tag245.value = '', document.forms[0].ind245.value = '';
        }
    } else {
        if (this.value != '') {
            parent.Sentform.document.forms[0].tag245.value = this.value;
        } else {
            parent.Sentform.document.forms[0].tag245.value = '';
        }
    }
    UpdateLeader('', '', '', '');
#End If
        ''' <summary>
        ''' Bind input tag OnChange event handler with specify javascript code for non-repeatable field.
        ''' This javascript codes actually update Hidden Field in form WCataModify.aspx ( Sentform iframe) and change value of leader.
        ''' The format for separates between fieldcode value and it's indicator as follow : 10::data
        ''' </summary>
        ''' <param name="fieldCode">FieldCode with sub field if exists</param>
        ''' <param name="checkTitleScript">If this fieldcode is 245$a</param>
        ''' <returns></returns>
        Public Shared Function CreateOnChangeScriptForNonrepeatableFieldContent(ByVal fieldCode As String, Optional checkTitleScript As String = "") As String
            If checkTitleScript Is Nothing Then
                checkTitleScript = ""
            End If
            Dim onChange As New StringBuilder(1024)
            onChange.
            Append("u('").Append(fieldCode).Append("');").
            Append(checkTitleScript).
            Append("if(document.forms[0].ind").Append(fieldCode).Append("){").
            Append("if(this.value != ''){").
            Append("parent.Sentform.document.forms[0].tag").Append(fieldCode).Append(".value = document.forms[0].ind").Append(fieldCode).Append(".value + '::' + this.value;").
            Append("} else { parent.Sentform.document.forms[0].tag").Append(fieldCode).Append(".value = ''; document.forms[0].ind").Append(fieldCode).Append(".value = '';}").
            Append("} else { if (this.value != '') {").
            Append("parent.Sentform.document.forms[0].tag").Append(fieldCode).Append(".value = this.value;}").
            Append("else { parent.Sentform.document.forms[0].tag").Append(fieldCode).Append(".value = ''; } }").
            Append("UpdateLeader('', '', '', '');")
            Return onChange.ToString()
        End Function

        Public Shared Function CreateOnChangeScriptForNonrepeatableFieldContent245(ByVal fieldCode As String, Optional checkTitleScript As String = "") As String
            If checkTitleScript Is Nothing Then
                checkTitleScript = ""
            End If
            Dim onChange As New StringBuilder(1024)
            onChange.Append(" u('245$b');").
                 Append(checkTitleScript).
                 Append(" UpdateRecord245('").Append(fieldCode).Append("');")
            Return onChange.ToString()
        End Function

        ''' <summary>
        ''' Bind input tag OnChange event handler with specify javascript code for repeatable field.
        ''' This javascript codes actually update Hidden Field in form WCataModify.aspx ( Sentform iframe) and change value of leader.
        ''' The format for separates between fieldcode value and it's indicator as follow : 10::data
        ''' </summary>
        ''' <param name="fieldCode">FieldCode with sub field if exists</param>
        ''' <param name="checkTitleScript">If this fieldcode is 245$a</param>
        ''' <returns></returns>
        Public Shared Function CreateOnChangeScriptForRepeatableFieldContent(ByVal fieldCode As String, ByVal checkTitleScript As String) As String
            If checkTitleScript Is Nothing Then
                checkTitleScript = ""
            End If
            Dim onChange As New StringBuilder(1024)
            onChange.Append(" u('").Append(fieldCode).Append("');").
                 Append(checkTitleScript).
                 Append(" UpdateRecord('").Append(fieldCode).Append("', 0);")
            Return onChange.ToString()
        End Function

#If 0 Then
    if (parent.Sentform.location.href.indexOf('WCataSent.aspx') >= 0) {
        parent.Hiddenbase.location.href = 'WCheckItemTitle.aspx?FieldCode=245$a&Value=' + Esc(this.value, 1);
    }
#End If
        ''' <summary>
        ''' When value of fieldcode 245$a changed, check for duplicate Title
        ''' </summary>
        ''' <param name="intUTF">0 if not convert to UTF-8 else convert</param>
        ''' <returns></returns>
        Public Shared Function CreateCheckTitleScript(ByVal intUTF As Integer) As String
            Dim checkTitleScriptBuilder As New StringBuilder(256)
            checkTitleScriptBuilder.Append("if(parent.Sentform.location.href.indexOf('WCataSent.aspx')>= 0){").
                            Append("parent.Hiddenbase.location.href='WCheckItemTitle.aspx?FieldCode=245$a&Value=' + Esc(this.value, ").Append(intUTF).Append(");}")
            Return checkTitleScriptBuilder.ToString()
        End Function

#If 0 Then
    if (this.value != '') {
        parent.Hiddenbase.location.href = 'WCheckItemCode.aspx?ItemCode=' + Esc(this.value, 1);
    }
#End If
        ''' <summary>
        ''' When value of fielcode 001 changed, check for duplicate Item-Code
        ''' </summary>
        ''' <param name="intUTF">0 if not convert to UTF-8 else convert</param>
        ''' <returns></returns>
        Public Shared Function CreateCheckItemCodeScript(ByVal intUTF As Integer) As String
            Dim checkTitleScriptBuilder As New StringBuilder(256)
            checkTitleScriptBuilder.Append("if (this.value != ''){").
                                Append("parent.Hiddenbase.location.href='WCheckItemCode.aspx?ItemCode=' + Esc(this.value,").Append(intUTF).Append(");}")
            Return checkTitleScriptBuilder.ToString()
        End Function
    End Class
End Namespace

