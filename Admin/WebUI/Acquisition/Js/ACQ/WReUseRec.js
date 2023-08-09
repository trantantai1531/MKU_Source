function UpgradeDDL(Obj, val)
{
    let strTemp = '';
    let lenObj = Obj.options.length;
    for (let i = 0; i < lenObj; i++) {
        strTemp = Obj.options[i].value;
        if (strTemp == val) {
            Obj.options.selectedIndex = i;
            break;
        }
    }
}