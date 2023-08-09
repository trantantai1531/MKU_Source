function gotoShowRecord(dicId, BrowseId) {
    self.location.href = "OShow.aspx?DicID=" + dicId.toString() + "&BrowseId=" + BrowseId.toString();
    parent.showWaiting();
}

function ShowRecordByItemType(FormatType) {
    self.location.href = "OShow.aspx?FormatType=" + FormatType.toString();
    parent.showWaiting();
}

function showMagazineList(ItemID) {
    self.location.href = "OMagList.aspx?ItemId=" + ItemID.toString();
}