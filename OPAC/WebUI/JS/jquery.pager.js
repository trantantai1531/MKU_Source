//  Client-side data pager widget that works with client databound RadListView
//  Supported usage: 
//      1. $("#pagerContainer").pager(listView);    // render full pager in specified container
//
//      2. $("#pagerContainer").pager({             //render pager with Prev/Next command buttons
//              listView: listViewInstance,         //and 5 pager index buttons
//              numericButtonCount: 5,
//              parts: ["prev", "numeric", "next"]
//              });

(function ($) {
    $.fn.pager = function (options) {
        if (options.get_id)
            options = { listView: options };

        var opt = $.extend({}, $.fn.pager.defaults, options);

        return this.each(function () {
            $($.format("<div class='{0}'></div>",
                $.format("{0} {0}_{1}", opt.css.pager, opt.listView.Skin)))
                .append(renderPagerParts(opt)).appendTo(this);

            attachEventHandlers(this, opt);
        });
    }

    $.fn.pager.defaults =
    {
        listView: null,
        numericButtonCount: 10,
        parts: ["pager", "first", "prev", "numeric", "next", "last", "pagecurrent"],
        css:
        {
            pager: "RadDataPager",
            wrap: "rdpWrap",
            numeric: "rdpNumPart",
            first: "rdpPageFirst",
            prev: "rdpPagePrev",
            next: "rdpPageNext",
            last: "rdpPageLast",
            current: "rdpCurrentPage"
        },
        templates:
        {
            wrap: "<div class='{0}'>{1}</div>",
            commandButton: "<input type='button' class='{0}' data-command='{1}' />",
            pageButton: "<a class='{0}' data-command='{1}'><span>{2}</span></a>",
            pageCurrent: "<b><div style='vertical-align:middle;text-align:right;display:inline;' class='{0}'>{1}{2}</div></b>"
        }
    }

    function setPageSize(value) {
        alert(value);
    }

    $.format = function () {
        var str = arguments[0],
            i = arguments.length;

        while (i--)
            str = str.replace(new RegExp('\\{' + (i - 1) + '\\}', 'gm'), arguments[i]);

        return str;
    }

    function attachEventHandlers(container, options) {
        var lv = options.listView,
            selector = "." + options.css.wrap + " input, ." + options.css.wrap + " a";

        $(container).find(selector).click(function () {
            lv.page($(this).data("command"));
        });   
    }

    function renderPagerParts(options) {
        var parts = options.parts.join(",").toLowerCase(),
            first = parts.indexOf("first") > -1,
            prev = parts.indexOf("prev") > -1,
            next = parts.indexOf("next") > -1,
            last = parts.indexOf("last") > -1,
            numeric = parts.indexOf("numeric") > -1,
			pagecurrent = parts.indexOf("pagecurrent") > -1,
            css = options.css,
            html = "";      

        if (first || prev) {
            html += renderWrap(options, css.wrap, function () {
                var chunk = "";
                if (first)
                    chunk += renderCommandButton(options, css.first, "First");
                if (prev)
                    chunk += renderCommandButton(options, css.prev, "Prev");

                return chunk;
            });
        }

        if (numeric) {
            html += renderWrap(options, $.format("{0} {1}", css.wrap, css.numeric), function () {
                return renderNumericButtons(options);
            });
        }

        if (next || last) {
            html += renderWrap(options, css.wrap, function () {
                var chunk = "";
                if (first)
                    chunk += renderCommandButton(options, css.next, "Next");
                if (prev)
                    chunk += renderCommandButton(options, css.last, "Last");

                return chunk;
            });
        }

		if (pagecurrent) {            
			html += renderWrap(options, css.wrap, function () {    
				var index = options.listView.get_currentPageIndex(),
					pageCount = options.listView.get_pageCount(),            
					pageSize = options.listView.get_pageSize(),
					virtualCount = options.listView.get_virtualItemCount(),
					itemStar = index * pageSize + 1,
					itemEnd = (index + 1) * pageSize,
					content = "",
					chunk = "",
					css = options.css;
				if (itemEnd>virtualCount)
				{
					itemEnd = virtualCount;
				}
				content = 'Mục ' + itemStar + ' đến ' + itemEnd + ' của ' + virtualCount;
                chunk += renderCurrentPage(options, css.pageCurrent, "", content);;

                return chunk;
            });
        }

        return html;
    }

    function renderWrap(options, cssClass, innerHtmlCallback) {
        return $.format(options.templates.wrap, cssClass, innerHtmlCallback());
    }

    function renderCommandButton(options, cssClass, command) {
        return $.format(options.templates.commandButton, cssClass, command)
    }

    function renderPageLink(options, cssClass, command, content) {
        return $.format(options.templates.pageButton, cssClass, command, content);
    }

    function renderCurrentPage(options, cssClass, command, content) {
        return $.format(options.templates.pageCurrent, cssClass, command, content);       
    }


    function renderNumericButtons(options) {
        var buttoncount = options.numericButtonCount,
            index = options.listView.get_currentPageIndex(),
            pageCount = options.listView.get_pageCount(),
            start = Math.floor(index / buttoncount) * buttoncount + 1,
            end = Math.min(start + buttoncount - 1, pageCount),
            html = "",
            css = options.css;

        if (start > 1) {
            html += renderPageLink(options, "", start - 2, "...");
        }

        for (var i = start; i <= end; i++) {
            var cssClass = i === index + 1 ? css.current : "";
            html += renderPageLink(options, cssClass, i - 1, i);
        }

        if (end < pageCount) {
            html += renderPageLink(options, "", end, "...");
        }

        return html;
    }
})($telerik.$ || jQuery);