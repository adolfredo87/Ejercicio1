$(document).ready(function() {
    GridDemo.SiteMaster.setDefaults();
});

var DemoAlquileresMVC = {
    Home: {
    View: {}
    },
    SiteMaster: {
        setDefaults: function() {
            $.jgrid.defaults = $.extend($.jgrid.defaults, {
                datatype: 'json',
                height: 'auto',
                imgpath: '/Content/jqGridCss/images',
                jsonReader: {
                    root: "Rows",
                    page: "Page",
                    total: "Total",
                    records: "Records",
                    repeatitems: false,
                    userdata: "UserData",
                    id: "Id"
                },
                loadui: "block",
                mtype: 'GET',
                multiboxonly: true,
                rowNum: 20,
                rowList: [10, 20, 50],
                viewrecords: true
            });
        }
    }
};