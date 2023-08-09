function CheckTime(f,msg) {
	if (CheckNull(f)) {return true;}
	if (f.value.indexOf(":") <= 0) {
		alert(msg);
		f.value = ""
		f.blur();
		f.focus();
		return false;
	}
	hh = f.value.substring(0, f.value.indexOf(":"));
	f1 = f.value.substring(f.value.indexOf(":") + 1, f.value.length);
	mm = f1.substring(0, f1.indexOf(":"));
	ss = f1.substring(f1.indexOf(":") + 1, f1.length);
	if (isNaN(hh) || parseFloat(hh) > 23 || isNaN(mm) || f1 == "" || parseFloat(mm) > 59 || isNaN(ss) || parseFloat(ss) > 59 || parseFloat(hh) < 0 || parseFloat(mm) < 0 || parseFloat(ss) < 0) {
		alert(msg);
		f.value = ""
		f.blur();
		f.focus();
		return false;
	}
	else {
		return true;
	}
}