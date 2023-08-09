function gotoLibrary(libId) {
    self.location.href = "OIndex.aspx?Site=" + libId.toString();
}
function changLanguage(val) {
    var Language = "Lang=" + val;
    var url = String(location.href);
    url = url.replace('Lang=', 'L=').replace('#', '');
    if (url != null)
        if (url.indexOf("?") > 0)
            url = String(url) + "&" + Language;
        else
            url = String(url) + "?" + Language;
    location.href = url;
}