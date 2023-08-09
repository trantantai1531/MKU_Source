/*	These function handle the enabling and disabling of the various
buttons used on the page,"Add Files" and "Upload":
* If the queue contains at least one item, the "Upload" button will	be enabled
* If the queue is full, "Add Files" will be disabled
* If the queue is empty, "Upload" will be disabled
*/

//	FileChange event handler
function file_change(sender, args) { check_upload_queue(sender); }

function check_upload_queue(ctrl) {
    var btn = document.getElementById("btn-upload");
    if (ctrl.GetFiles().length > 0) btn.className = "upload";
    else btn.className = "upload-d";
}

function add_file(ctrl, el) {
    ctrl.AddFile();
    if (ctrl.FileCount == ctrl.MaximumFileCount) el.className = "add-d";
}

function remove_file(ctrl, item) {
    if (ctrl.FileCount > 1) ctrl.RemoveFileAt(item);
    //else { ctrl.ClearFiles();ctrl.AddFile(); }
    //else ctrl.ClearFiles();
    //ctrl.ClearFiles();
    
    if (ctrl.FileCount < ctrl.MaximumFileCount) document.getElementById("btn-add").className = "add";
}

function upload_begin(sender, args) {
    //UploadDialog.Show();
}


function upload_end(sender, args) {
    sender.dispose();
    sender.clearFiles();
    sender.addFile();
}


function generate_file_list(ctrl, cur) {
    var files = ctrl.GetFiles();
    var out = "";
    var cls = "Hoàn thành";

    for (var f in files) {
        var file = files[f].substring(files[f].lastIndexOf("\\") + 1, files[f].length);
        var li = "<li class=\"" + cls + "\">";
        if (file == cur) {
            li = (ctrl.Uploading) ? "<li class=\"cur\">" : "<li class=\"done\">";
            cls = "";
        }
        out += li + file + "</li>";
    }

    return "<ul>" + out + "</ul>";
}

//	File size functions
function format_file_size(n, fmt) {
    if (!fmt) {		//	no formatting specified; automatically select the best format
        if (n < 1000) fmt = "b";
        else if (n < 1000000) fmt = "kb";
        else if (n < 1000000000) fmt = "mb";
        else fmt = "gb";
    }

    switch (fmt.toLowerCase()) {
        case "kb": return String((n * 0.001).toFixed(2)) + " KB"; break;
        case "mb": return String((n * 0.000001).toFixed(2)) + " MB"; break;
        case "gb": return String((n * 0.000000001).toFixed(2)) + " GB"; break;
        default: return String(n.toFixed(2)) + " B";
    }
}

function get_percentage(n) { return String(Math.round(n * 100)); }

//	Time functions
function format_time(t, txt) {
    var s = Math.floor(t);
    var m = Math.floor(s / 60);
    var h = Math.floor(m / 60);

    if (!txt) {
        //	Output will always have be least mm:ss
        s = pad_time(s % 60);
        m = pad_time(m % 60) + ":";
        h = (h == 0) ? "" : pad_time(h % 60) + ":";

        return (h + m + s);
    } else {
        var secs = (s > 1) ? "giây" : "giây"; 		//	plural & singular second units
        var mins = (m > 1) ? "phút" : "phút"; 		//	plural & singular minute units
        var hours = (h > 1) ? "giờ" : "giờ"; 			//	plural & singular hour units

        s = (s > 0) ? String(s) + " " + secs : ""; 		//	string or empty?
        m = (m > 0) ? String(m) + " " + mins : ""; 		//	string or empty?
        h = (h > 0) ? String(h) + " " + hours : ""; 		//	string or empty?

        var out = "";
        if (h !== "") {										//	longer than an hour
            out = h;
            if (m != "") out += ", " + m; 				//	at least one minute
            if (s != "") out += ", " + s; 				//	at least one second
        }

        if (m !== "" && out == "") {						//	shorter than an hour, greater than 60 seconds
            out += m;
            if (s != "") out += ", " + s; 				//	at least one second
        }

        if (s !== "" && out == "") out = s; 				//	at least one second

        if (out == "") out = "ít hơn 1 giây"; 		//	less than a second

        return out;
    }
}

function pad_time(t) { return String(((t > 9) ? "" : "0") + t); }

function get_file_position(ctrl, cur) {
    var files = ctrl.GetFiles();
    for (var i = 0; i < files.length; i++) {
        var file = files[i].substring(files[i].lastIndexOf("\\") + 1, files[i].length);
        if (file == cur) return String(i + 1);
    }

    return "1";
}

function init_upload(ctrl) {
    if (ctrl.GetFiles().length > 0) {
        var btn = document.getElementById("btn-upload");
        if (btn.className == "upload") {
            ctrl.Upload();
            UploadDialog.Show();
        }
        //ctrl.Upload();
        //UploadDialog.Show();
    }
}

function init_single_upload(ctrl) {
    if (ctrl.GetFiles().length > 0) {
        var btn = document.getElementById("btn-upload");
        if (btn.className == "upload") {
            ctrl.Upload();
        }
        //ctrl.Upload();
        //UploadDialog.Show();
    }
}


//	Background image preloader
(new Image()).src = "images/vertical.png";