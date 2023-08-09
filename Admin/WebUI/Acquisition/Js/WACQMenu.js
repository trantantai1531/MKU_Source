function AddRef() {
    document.forms[0].txtHref.value = parent.mainacq.location.href;
    parent.mainacq.location.href = 'WACQManRef.aspx';
    //	return false;
}

function IndexACQ_Click() {
    parent.mainacq.location.href = 'ACQ/WIndexAcq.aspx';
}

function IndexPO_Click() {
    parent.mainacq.location.href = 'PO/WIndexPo.aspx';
}

function IndexAccounting_Click() {
    parent.mainacq.location.href = 'Accounting/WAccountingIndex.aspx';
}

function IndexStore_Click() {
    parent.mainacq.location.href = 'Location/WIndexSto.aspx';
}

function IndexStat_Click() {
    parent.mainacq.location.href = 'Statistic/WStatIndex.aspx';
}