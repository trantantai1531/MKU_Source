function get_param(return_this)
	{
		return_this = return_this.replace(/\?/ig, "").replace(/=/ig, ""); // Globally replace illegal chars.

		var url = window.location.href;                                   // Get the URL.
		var parameters = url.substring(url.indexOf("?") + 1).split("&");  // Split by "param=value".
		var params = [];                                                  // Array to store individual values.

		for(var i = 0; i < parameters.length; i++)
			if(parameters[i].search(return_this + "=") != -1)
				return parameters[i].substring(parameters[i].indexOf("=") + 1).split("+");

		return null;
	}	