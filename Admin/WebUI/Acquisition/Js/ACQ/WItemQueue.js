function LoadData(ItemID) {
	opener.parent.hiddenbase.location.href='WReUseRec.aspx?ItemID=' + ItemID;
	self.close();
}