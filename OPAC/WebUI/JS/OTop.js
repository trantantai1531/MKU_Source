var bolSubmit = false;

function keySearch(e) {
    var key = e.keyCode || e.which;
    if (key == 13) {
        checkValid();
    }
}

function clickSearch(e) {
    if (bolSubmit) {
        var btSubmit = document.getElementById("btSubmit");
        if (btSubmit) {
            btSubmit.click();  
        }       
    }    
}

function checkValid() {
    var txtSearch = document.getElementById("txtSearch");
    if (txtSearch.value.trim() != '') {
        bolSubmit = true;
    }    
}