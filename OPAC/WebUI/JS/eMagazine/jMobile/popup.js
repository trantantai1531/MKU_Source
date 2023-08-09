// popup examples
jQuery( document ).on( "pageinit", function() {
	
	function scale( width, height, padding, border ) {
		var scrWidth = jQuery( window ).width() - 30,
			scrHeight = jQuery( window ).height() - 30,
			ifrPadding = 2 * padding,
			ifrBorder = 2 * border,
			ifrWidth = width + ifrPadding + ifrBorder,
			ifrHeight = height + ifrPadding + ifrBorder,
			h, w;

		if ( ifrWidth < scrWidth && ifrHeight < scrHeight ) {
			w = ifrWidth;
			h = ifrHeight;
		} else if ( ( ifrWidth / scrWidth ) > ( ifrHeight / scrHeight ) ) {
			w = scrWidth;
			h = ( scrWidth / ifrWidth ) * ifrHeight;
		} else {
			h = scrHeight;
			w = ( scrHeight / ifrHeight ) * ifrWidth;
		}
		
		return {
			'width': w - ( ifrPadding + ifrBorder ),
			'height': h - ( ifrPadding + ifrBorder )
		};
	};

	jQuery( ".ui-popup iframe" )
		.attr( "width", 0 )
		.attr( "height", "auto" );
	 
	jQuery( "#popupAllpages" ).on({
		popupbeforeposition: function() {
			// call our custom function scale() to get the width and height 
			var size = scale( jQuery( window ).width(), 430, 15, 1 ),
				w = size.width,
				h = size.height;

			jQuery( "#popupAllpages iframe" )
				.attr( "width", w )
				.attr( "height", h );
		},
		popupafterclose: function() {
			jQuery( "#popupAllpages iframe" )
				.attr( "width", 0 )
				.attr( "height", 0 );	
		}
	});

	jQuery( "#popupBrowseIssue" ).on({
		popupbeforeposition: function() {
			// call our custom function scale() to get the width and height 
			var size = scale( jQuery( window ).width(), jQuery( window ).height(), 15, 1 ),
				w = size.width,
				h = size.height;

			jQuery( "#popupBrowseIssue iframe" )
				.attr( "width", w )
				.attr( "height", h );
		},
		popupafterclose: function() {
			jQuery( "#popupBrowseIssue iframe" )
				.attr( "width", 0 )
				.attr( "height", 0 );	
		}
	});

	
});