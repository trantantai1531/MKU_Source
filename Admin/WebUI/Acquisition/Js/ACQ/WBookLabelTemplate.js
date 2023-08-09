/**********************************************************************************/
/*******************		WBookLabelTemplate Js file		***********************/
/**********************************************************************************/
//method: replaceSubstring
//Purpose: Replate String
//In: string source, string find, string replate
//Out: string source
//Creator: sondp
//CreatedDate: 25/09/2004
function replaceSubstring(inputString, fromString, toString) {
    // Goes through the inputString and replaces every occurrence of fromString with toString
    temp = inputString;
    if (fromString == "") {
        return (inputString);
    }
    if (toString.indexOf(fromString) == -1) {// If the string being replaced is not a part of the replacement string (normal situation)
        while (temp.indexOf(fromString) != -1) {
            var toTheLeft = temp.substring(0, temp.indexOf(fromString));
            var toTheRight = temp.substring(temp.indexOf(fromString) + fromString.length, temp.length);
            temp = toTheLeft + toString + toTheRight;
        }
    } else {// String being replaced is part of replacement string (like "+" being replaced with "++") - prevent aninfinite loop
        var midStrings = Array("~", "`", "_", "^", "#");
        var midStringLen = 1;
        var midString = "";// Find a string that doesn't exist in the inputString to be usedas an "inbetween" string
        while (midString == "") {
            for (var i = 0; i < midStrings.length; i++) {
                var tempMidString = "";
                for (var j = 0; j < midStringLen; j++) {
                    tempMidString += midStrings[i];
                }
                if (fromString.indexOf(tempMidString) == -1) {
                    midString = tempMidString;
                    i = midStrings.length + 1;
                }
            }
        }
        // Keep on going until we build an "inbetween" string that doesn't exist
        // Now go through and do two replaces - first, replace the "fromString" with the "inbetween" string
        while (temp.indexOf(fromString) != -1) {
            var toTheLeft = temp.substring(0, temp.indexOf(fromString));
            var toTheRight = temp.substring(temp.indexOf(fromString) + fromString.length, temp.length);
            temp = toTheLeft + midString + toTheRight;
        }
        // Next, replace the "inbetween" string with the "toString"
        while (temp.indexOf(midString) != -1) {
            var toTheLeft = temp.substring(0, temp.indexOf(midString));
            var toTheRight = temp.substring(temp.indexOf(midString) + midString.length, temp.length);
            temp = toTheLeft + toString + toTheRight;
        }
    }
    // Ends the check to see if the string being replaced is part of the replacement string or not
    return temp;
    // Send the updated string back to the user
}
// Ends the "replaceSubstring" function		
function storeCaret(textEl) {
    if (textEl.createTextRange) {
        textEl.caretPos = document.selection.createRange().duplicate();
    }
}
// Replace < or > by &lt; or &gt;
function EncryptionTags(obj) {
    console.log(obj);
    //	eval(obj).value=replaceSubstring(obj.value,'<','&lt;');
    //eval(obj).value=replaceSubstring(obj).value,'>','&gt;');	
}
// Replace &lt; or &gt; by < or >
function DecryptionTags(obj) {
    eval(obj).value = replaceSubstring(eval(obj).value, '&lt;', '<');
    eval(obj).value = replaceSubstring(eval(obj).value, '&gt;', '>');
}
// Change Template function
function ChangeTemplate() {
    console.log("booklabeltemplatejs");
    console.log(document);
    if (document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value == 0) {
        //location.reload();
        
        document.forms[0].txtTitle.value = '';
        document.forms[0].txtTitle.focus();
        var oEditor = FCKeditorAPI.GetInstance('fckContent');
        oEditor.SetHTML('');
        document.forms[0].ddlInf.selectedIndex = 0;

        return false;
    } else {
        top.main.hiddenbase.location.href = 'WBookLabelTemplateHidden.aspx?TemplateID=' + document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value;
        return false;
    }
    return false;
}


// Confirm delete template
function AskDelete(strMssg1, strMssg2) {
    EncryptionTags('document.forms[0].txtContent');
    if (document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value != 0) {
        if (confirm(strMssg1)) {
            return true;
        } else {
            return false;
        }
    } else {
        alert(strMssg2);
        return false;
    }
}
// Check ValidData
function CheckValidData(strEmtyTitle) {
    EncryptionTags('document.forms[0].txtContent');
    if (document.forms[0].txtTitle.value == '') {
        alert(strEmtyTitle);
        document.forms[0].txtTitle.focus();
        return false;
    }
    return true;
}
// Preview BookLabel Template
function PreviewBookLabelTemplate() {
    //EncryptionTags('document.forms[0].txtContent');
    PreviewTemplateWin = window.open('', 'PreviewTemplateWin', 'height=200,width=300,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=40,left=60');
    document.forms[0].action = 'WBookLabelTemplatePreview.aspx';
    document.forms[0].target = 'PreviewTemplateWin';
    document.forms[0].submit();
    document.forms[0].action = 'WBookLabelTemplateDisplay.aspx';
    document.forms[0].target = self.name;
    PreviewTemplateWin.focus();
    return false;
}

function InsertPatronContent() {
    var oEditor = FCKeditorAPI.GetInstance('fckContent');
    var sample = document.getElementById("ddlInf").value;
    oEditor.InsertHtml(sample);

}

function setPatronContent(val) {
    var oEditor = FCKeditorAPI.GetInstance('fckContent');
    oEditor.SetHTML(val);
}
function resetEditor() {
    var oEditor = FCKeditorAPI.GetInstance('fckContent');
    oEditor.SetHTML('');
}