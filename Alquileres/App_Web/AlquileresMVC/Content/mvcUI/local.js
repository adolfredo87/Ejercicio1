var mvcLocal = {};

mvcLocal.jqGrid = {};

mvcLocal.jqGrid.getOptionsDefaults = function(uniqueID) {
    return {
        options: {
            // Ajax related configurations
            url: "GetListData",
            datatype: "json",
            mtype: "POST",
            //
            // Specify the column names
            colNames: ["Acciones"],
            //
            // Configure the columns
            colModel:
            [
                mvcLocal.jqGrid.columnAcciones
            ],
            //
            // Grid total width and height
            width: 870,
            height: 350,//350
            //
            // Paging
            toppager: true,
            pager: $("#MvcJqTable" + uniqueID + "_Pager"),
            rowNum: 15,
            rowList: [15, 20, 30, 50, 100],
            viewrecords: true, // Specify if "total number of records" is displayed
            //
            // Default sorting
            sortname: "",
            sortorder: "asc",
            //
            // Grid caption
            caption: "&nbsp;",
            loadComplete: function() {

            },
            loadBeforeSend: function(xhr) {
                //
                $('#' + this.id + '_Message').addClass('MvcHidden');
            },
            loadError: function(xhr, st, err) {
                var msg = JSON.parse(xhr.responseText);
                $('#' + this.id + '_Message' + " label").html(
                    xhr.status + ": " + xhr.statusText + " " + msg.clientMessage);
                console.error(msg.stackTrace);

                //                $('#MvcJqMessage_' + uniqueID + ' #message').dialog({
                //                    title: xhr.statusText, // 'Error obteniendo datos',                    
                //                    modal: true,
                //                    show: "scale",
                //                    hide: "scale",
                //                    autoOpen: true
                //                });
                $('#' + this.id + '_Message').removeClass('MvcHidden');
            }
        },
        buttons: {
            refresh: true, add: false, edit: false, del: false
        },
        settingsEdit: {}, // settings for edit
        settingsAdd: {},  // settings for add
        settingsDelete: {},  // define settings for Delete
        searchOptions: { sopt: ['cn', 'eq', 'ne', 'bw', 'ew']}  // Search options. Some options can be set on column level
    };
};

mvcLocal.jqGrid.init = function(name) {
    var jqTableGrid = $('#MvcJqTable' + name);
    if (!!jqTableGrid && !!jqTableGrid[0]) {
        jqTableGrid[0].mvcUI = {
            pager: $('#' + jqTableGrid[0].id + '_Pager')[0],
            message: $('#' + jqTableGrid[0].id + '_Message')[0],
            config: mvcLocal.jqGrid.getOptionsDefaults(name)
        };
    }
    return jqTableGrid[0];
};

mvcLocal.jqGrid.initAjaxDetailSelect = function(nameDetails, nameSelect) {    

    var grid = this.initAjax(nameDetails);
    grid.mvcUI.selectGrid = this.initAjax(nameSelect);

    grid.mvcUI.config.options.rowNum = 10;
    grid.mvcUI.config.options.rowList = [10, 15, 20];
    grid.mvcUI.config.options.height = 240;
    grid.mvcUI.config.options.width = 850;

    grid.mvcUI.selectGrid.mvcUI.config.options.rowNum = 10;
    grid.mvcUI.selectGrid.mvcUI.config.options.rowList = [10, 15, 20];
    grid.mvcUI.selectGrid.mvcUI.config.options.height = 300;
    grid.mvcUI.selectGrid.mvcUI.config.options.width = 900;
    grid.mvcUI.selectGrid.mvcUI.config.options.caption = "";
    
    grid.mvcUI.selectGrid.mvcUI.openDialog = function(gridId) {
        $('#' + gridId).jqGrid().trigger('reloadGrid');
        $(this.divDialog).dialog('open');
    }

    grid.mvcUI.ajax.buttons[1].onclick = "$('#" + grid.mvcUI.selectGrid.id + "')[0].mvcUI.openDialog('" + grid.mvcUI.selectGrid.id + "');"

    grid.mvcUI.selectGrid.mvcUI.ajax.onSuccess = function(ajaxContext) {
        $(grid).jqGrid().trigger('reloadGrid');
    }

    return grid;
};

mvcLocal.jqGrid.initAjax = function(name) {
    var jqTableGrid = this.init(name);
    if (!!jqTableGrid) {
        jqTableGrid.mvcUI.ajax = {
            id: jqTableGrid.id,
            insertionMode: 'Sys.Mvc.InsertionMode.replace',
            loadingElementId: "",
            updateTargetId: "",

            onSuccess: function(ajaxContext) { },
            onFailure: function(ajaxContext) { },
            onBegin: function(ajaxContext) { },
            onComplete: function(ajaxContext) { },

            _onSuccess: function(ajaxContext) {
                $(jqTableGrid).delRowData($(this).attr('rowid'));
                jqTableGrid.mvcUI.ajax.onSuccess(ajaxContext);
            },
            _onFailure: function(ajaxContext) {
                jqTableGrid.mvcUI.ajax.onFailure(ajaxContext);
            },
            _onBegin: function(ajaxContext) {
                $('#' + jqTableGrid.id + '_divButtons_' + $(this).attr('rowid')).toggleClass('MvcHidden');
                jqTableGrid.mvcUI.ajax.onBegin(ajaxContext);
            },
            _onComplete: function(ajaxContext) {
                $('#' + jqTableGrid.id + '_divButtons_' + $(this).attr('rowid')).toggleClass('MvcHidden');
                jqTableGrid.mvcUI.ajax.onComplete(ajaxContext);
            },
            handleClick: function(rowId) {
                return "Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), { " +
                    "insertionMode: " + this.insertionMode + ", " +
                    //"loadingElementId: $(\'#" + jqTableGrid.id + "\')[0].mvcUI.ajax.loadingElementId, " +
                    "loadingElementId:  '" + jqTableGrid.id + "_divLoading_" + rowId + "', " +
                    "updateTargetId: $(\'#" + jqTableGrid.id + "\')[0].mvcUI.ajax.updateTargetId, " +
                    "onBegin: Function.createDelegate(this, $('#" + jqTableGrid.id + "')[0].mvcUI.ajax._onBegin), " +
                    "onComplete: Function.createDelegate(this, $('#" + jqTableGrid.id + "')[0].mvcUI.ajax._onComplete), " +
                    "onFailure: Function.createDelegate(this, $('#" + jqTableGrid.id + "')[0].mvcUI.ajax._onFailure), " +
                    "onSuccess: Function.createDelegate(this, $('#" + jqTableGrid.id + "')[0].mvcUI.ajax._onSuccess) " +
                "});"
            },
            buttons: [
                { action: '', onclick: '', srcImage: '../../Content/images/hbotons/delete.png' },
                { action: '', onclick: '', srcImage: '../../Content/images/hbotons/add.png' }

            ],
            actionsIconFormatter: function(href, rowId, srcImage) {
                var htmlFormatter = "<div id='" + jqTableGrid.id + "_divLoading_" + rowId + "' style='display:none; visibility:hidden;'>";
                htmlFormatter += "<img src='../../Content/images/hpantalla/ajax-loader.gif' id='" + jqTableGrid.id + "_divLoading_" + rowId + "'  /> </div>";
                htmlFormatter += "<div id='" + jqTableGrid.id + "_divButtons_" + rowId + "' class='ActionsButtons'> ";

                for (var i = 0; i < this.buttons.length; i++) {
                    if (this.buttons[i].action != null && this.buttons[i].action != '') {
                        htmlFormatter += "<a href='" + this.buttons[i].action + "/" + rowId + "' onclick=\"" + this.handleClick(rowId) + "\" rowId='" + rowId + "'>";
                        htmlFormatter += "<img src='" + this.buttons[i].srcImage + "'/></a>";
                    } else if (this.buttons[i].onclick != null && this.buttons[i].onclick != '') {
                        htmlFormatter += "<a href='#' onclick=\"" + this.buttons[i].onclick + "\" rowId='" + rowId + "'>";
                        htmlFormatter += "<img src='" + this.buttons[i].srcImage + "'/></a>";
                    }
                }

                htmlFormatter += "</div>";

                return htmlFormatter;

            },
            columnActions: {
                name: 'Actions',
                width: 35,
                align: 'center',
                search: false,
                sortable: false,
                formatter: function(cellvalue, options, rowObject) {
                    return this.mvcUI.ajax.actionsIconFormatter(this.mvcUI.ajax.hrefDelete, options.rowId, this.mvcUI.ajax.srcImageDelete);
                }
            }
        }; // End Ajax Options
    }
    return jqTableGrid;
};

mvcLocal.jqGrid.actionsFormatter = function ActionsFormatter(cellvalue, options, rowObject) {
    return "<div class='ActionsButtons'>" +
        "<a href='Details/" + options.rowId + "'><img src='../../Content/images/hbotons/search.png'/></a>" +
        "<a href='Edit/" + options.rowId + "'><img src='../../Content/images/hbotons/edit.png' /></a>" +
        "<a href='Delete/" + options.rowId + "'><img src='../../Content/images/hbotons/delete.png'/></a>" +
        "</div>";
};

mvcLocal.jqGrid.actionsFormatterDetailsAndEdit = function ActionsFormatter(cellvalue, options, rowObject) {
    return "<div class='ActionsButtons'>" +
        "<a href='Details/" + options.rowId + "'><img src='../../Content/images/hbotons/search.png'/></a>" +
        "<a href='Edit/" + options.rowId + "'><img src='../../Content/images/hbotons/edit.png' /></a>" +
        "</div>";
};

mvcLocal.jqGrid.actionsFormatterDetailsAndDelete = function ActionsFormatter(cellvalue, options, rowObject) {
    return "<div class='ActionsButtons'>" +
        "<a href='Details/" + options.rowId + "'><img src='../../Content/images/hbotons/search.png'/></a>" +
        "<a href='Delete/" + options.rowId + "'><img src='../../Content/images/hbotons/delete.png'/></a>" +
        "</div>";
};

mvcLocal.jqGrid.actionsFormatterDetails = function ActionsFormatter(cellvalue, options, rowObject) {
    return "<div class='ActionsButtons'>" +
        "<a href='Details/" + options.rowId + "'><img src='../../Content/images/hbotons/search.png'/></a>" +
        "</div>";
};

mvcLocal.jqGrid.columnActions = {
    name: "Actions", width: 35, align: "center", search: false, sortable: false, formatter: mvcLocal.jqGrid.actionsFormatter
};

mvcLocal.jqGrid.columnActionsDetailAndEdit = {
    name: "Actions", width: 35, align: "center", search: false, sortable: false, formatter: mvcLocal.jqGrid.actionsFormatterDetailsAndEdit
};

mvcLocal.jqGrid.columnActionsDetailAndDelete = {
    name: "Actions", width: 35, align: "center", search: false, sortable: false, formatter: mvcLocal.jqGrid.actionsFormatterDetailsAndDelete
};

mvcLocal.jqGrid.columnActionsDetail = {
    name: "Actions", width: 35, align: "center", search: false, sortable: false, formatter: mvcLocal.jqGrid.actionsFormatterDetails
};

mvcLocal.jqGrid.print = function(uniqueID) {

    var grid = $('#' + uniqueID);
    var prtPage = $('#prt-page');
    if (!prtPage[0]) {
        $('body').append("<div id='prt-page' />");
        prtPage = $('#prt-page');
    }
    prtPage.empty();

    grid.hideCol("Actions");
    var cloneGrid = $('#gbox_' + uniqueID + ' .ui-jqgrid-bdiv').clone();
    var cloneHead = $('#gbox_' + uniqueID + ' .ui-jqgrid-htable thead').clone();
    grid.showHideCol("Actions");

    var newHead = $(cloneGrid.find('table')[0].createTHead());

    var style = $("<style media='print' type='text/css'> #main{ display:none; visibility:hidden; } #prt-page{ display:inline; visibility:visible; } </style>")
    style.appendTo('head');

    cloneGrid.appendTo(prtPage);
    newHead[0].outerHTML = cloneHead[0].outerHTML;

    cloneGrid.find('.jqgfirstrow').remove();
    cloneGrid.find('.s-ico').css({ 'display': 'none' });

    //Print Page
    window.print();

    // empty clone grid.
    prtPage.empty();

    style.remove();
};

mvcLocal.jqGrid.addColumnChooser = function(grid, pager) {
    $(grid).navButtonAdd(pager, {
        caption: "",
        buttonicon: "ui-icon-calculator",
        title: "Elejir Columnas",
        onClickButton: function() {
            $(grid).columnChooser();
        }   // onClickButton function ends here.
    }); // navButtonAdd ends here
};

mvcLocal.jqGrid.loadGrid = function(grid) {

    $(grid).jqGrid(grid.mvcUI.config.options);

    $(grid).jqGrid().navGrid(
	                 "#" + grid.mvcUI.pager.id, //pager[0].id,
                    grid.mvcUI.config.buttons,
                    grid.mvcUI.config.settingsEdit, // settings for edit
                    grid.mvcUI.config.settingsAdd, // settings for add
                    grid.mvcUI.config.settingsDelete, // define settings for Delete
                    grid.mvcUI.config.searchOptions	// Search options. Some options can be set on column level
            );
    this.addColumnChooser(grid, grid.mvcUI.pager);
};

mvcLocal.jqGrid.loadAjaxDetailSelect = function(grid) {

    grid.mvcUI.selectGrid.mvcUI.divDialog = $(grid.mvcUI.selectGrid.parentElement)[0]; //
    $(grid.mvcUI.selectGrid.mvcUI.divDialog).dialog
    ({
        autoOpen: false,
        height: grid.mvcUI.selectGrid.mvcUI.config.options.height + 177, //477,
        width: grid.mvcUI.selectGrid.mvcUI.config.options.width + 27,   //927,
        modal: true,
        show: "scale",
        hide: "scale",
        buttons:
        {
            Cerrar: function() {
                $(this).dialog("close");
            }
        },
        close: function() {
            $(this).dialog("close");
        }
    });

    mvcLocal.jqGrid.loadGrid(grid);
    mvcLocal.jqGrid.loadGrid(grid.mvcUI.selectGrid);

};
mvcLocal.jqGrid.loadGridAjax2 = function(gridData, optionsGridData) {

    optionsGridData.options.rowNum = 10;
    optionsGridData.options.rowList = [10, 15, 20];
    optionsGridData.options.height = 300;
    optionsGridData.options.width = 700;

    gridData.mvcUI.ajax.dialog = $(gridData.parentElement); //
    gridData.mvcUI.ajax.dialog.dialog
    ({
        autoOpen: false,
        height: 530,
        width: 727,
        modal: true,
        show: "scale",
        hide: "scale",
        buttons:
        {
            Cerrar: function() {
                $(this).dialog("close");
            }
        },
        close: function() {
            $(this).dialog("close");
        }
    });

    mvcLocal.jqGrid.loadGrid(gridData, optionsGridData);
};


mvcLocal.getAutocompleteConfig = function(searchUrl, cell1, cell2, separator) {
    var config = {};
    config = {
        source: function(request, response) {
            $.ajax({
                url: searchUrl,
                dataType: "json",
                data: {
                    'searchString': request.term
                },
                success: function(data) {
                    response($.map(data.rows, function(item) {
                        return {
                            label: item.cell[cell1].trim() + separator + item.cell[cell2].trim(),
                            value: item.id
                        }
                    }));

                }
            });
        },
        minLength: 1,
        select: function(event, ui) {
            //log(ui.item ?"Selected: " + ui.item.label :"Nothing selected, input was " + this.value);
        },
        open: function() {
            $(this).addClass("ui-corner-top");
        },
        close: function() {
            $(this).removeClass("ui-corner-top");
        }
    };

    return config;
};

mvcLocal.autocomplete = {};
mvcLocal.autocomplete.getValue = function(controlID) {
    var control = $('#' + controlID);
    if(!!control){
        return control.val();
    }
    return undefined;
};
mvcLocal.autocomplete.getConfig = function(/*controlHidden,*/controlSelectedValue, searchUrl, getParametersData, labelCells, separator) {

    var config = {};
    var indexCell = labelCells.split(',');
    var getParametersUrl = function(request) {
        var data = getParametersData();
        data.searchString = request.term;
        return data;
    };
    
    config = {
        source: function(request, response) {
            $.ajax({
                url: searchUrl,
                dataType: "json",
                data: getParametersUrl(request),
                success: function(data) {
                    response($.map(data.rows, function(item) {
                        var getlabel = function() {
                            var description = '';
                            for (i = 0; i < indexCell.length; i++) {
                                description += item.cell[indexCell[i]].trim();
                                if (i <= indexCell.length - 2)
                                    description += separator;
                            }
                            return description;
                        };
                        return {
                            label: getlabel(),
                            value: item.cell[indexCell[0]].trim(),
                            id: item.id
                        }
                    }));
                }
            });
        },
        minLength: 1,
        focus: function(event, ui) {
            $(this).val(ui.item.value);
            //this.title = ui.item.label;
            return false;
        },
        search: function(event, ui) {
            //this.title = '';
            if (!!controlSelectedValue)
                controlSelectedValue.html('');
        },
        select: function(event, ui) {
            if (!!controlSelectedValue)
                controlSelectedValue.html(ui.item.label);
            //controlHidden.val(ui.item.id);
            //controlSelectedValue.val(ui.item.label);
            //$("#" + controlEditor.attr('id') + "-selected-value").html(ui.item.label);
            //controlEditor.val(ui.item.label);
            //$("#project").val(ui.item.label);
            //$("#project-id").val(ui.item.value);
            //$("#project-description").html(ui.item.desc);
            //$("#project-icon").attr("src", "images/" + ui.item.icon);
            //log(ui.item ?"Selected: " + ui.item.label :"Nothing selected, input was " + this.value);
        },
        open: function() {
            $(this).addClass("ui-corner-top");
        },
        close: function() {
            $(this).removeClass("ui-corner-top");
        }
    };

    return config;
};

mvcLocal.utility = {
    // Find de Form parent the node
    findParentForm: function(node) {
        while (!!node) {
            if (node.tagName == "FORM") {
                return node;
            }
            node = node.parentNode;
        }
        return undefined;
    },
    submitAction: function(node, action) {
        var form = this.findParentForm(node);
        if (!!form) {
            form.action = action;
            submit();
        }
    },
    //Add to link menu the active
    setActionMenu: function(nodeMenu) {
        var nodes = nodeMenu.children();
        var indexPanel = -1;

        for (i = 0; i < nodes.length; i++) {
            if (nodes[i].tagName.toUpperCase() == 'DIV') {
                indexPanel++;
                var links = $(nodes[i]).find("a");
                for (j = 0; j < links.length; j++) {
                    if (links[j].href.indexOf("?imnu=") < 0) {
                        links[j].href = links[j].href + "?imnu=" + indexPanel;
                    }
                }
            }
        }
    }
};


(function($) {
    $.widget("custom.combobox", {
        _create: function() {
            this.wrapper = $("<span>").addClass("custom-combobox").insertAfter(this.element);
            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },
        _createAutocomplete: function() {
            var selected = this.element.children(":selected"),
            value = selected.val() ? selected.text() : "";
            this.input = $("<input>").appendTo(this.wrapper).val(value).attr("title", "")
            .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
            .autocomplete({
                delay: 0,
                minLength: 0,
                source: $.proxy(this, "_source")
            }).tooltip({ tooltipClass: "ui-state-highlight" });
            this._on(this.input, {
                autocompleteselect: function(event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                    if (!!this.widget() && !!this.widget().get && !!this.widget().get(0) && !!this.widget().get(0).onchange) {
                        this.widget().get(0).onchange();
                    }
                },
                autocompletechange: "_removeIfInvalid"
            });
        },
        _createShowAllButton: function() {
            var input = this.input, wasOpen = false;
            $("<a>").attr("tabIndex", -1).attr("title", "Ver Todos lo Items").tooltip().appendTo(this.wrapper).button(
                { icons: { primary: "ui-icon-triangle-1-s" }, text: false }).removeClass("ui-corner-all").addClass("custom-combobox-toggle ui-corner-right")
                .mousedown(function() {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .click(function() {
                    input.focus();
                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }
                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },
        _source: function(request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function() {
                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
        },
        _removeIfInvalid: function(event, ui) {
            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }
            // Search for a match (case-insensitive)
            var value = this.input.val(), valueLowerCase = value.toLowerCase(), valid = false;
            this.element.children("option").each(function() {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });
            // Found a match, nothing to do
            if (valid) {
                return;
            }
            // Remove invalid value
            this.input.val("").attr("title", "No se encontró ningún elemento " + value).tooltip("open");
            var preval = this.element.val();
            //this.element.val("");
            this._delay(function() {
                this.input.tooltip("close").attr("title", "");
                this.input.val($(this.element.find("option:selected")).text());
            }, 2000);
            this.input.data("ui-autocomplete").term = "";
        },
        _destroy: function() {
            this.wrapper.remove();
            this.element.show();
        }
    });
})(jQuery);