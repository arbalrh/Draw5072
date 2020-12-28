let clientes = (function (window, undefined) {
    let st = {
        urlIndexGrid: "#urlgetclientes",
        grid: "#grid-clientes",
    };
    let dom = {};
    let catchDom = function () {
        dom.Document = $(document);
    };
    let suscribeEvents = function () {
        //dom.Document.on("click", st.btnFilterSearch, events.eRefrescarGrid);
        //dom.Document.on("click", st.btnFilterReset, events.eLimpiarGrid);
    };
    let events = {
        eRefrescarGrid: function (e) {
            $("#modal-search").modal('hide');
            $(st.txtByDefault).val('false');
            appLandings.formFilters.ByDefault = false;
            reDrawGrid();
        },
        eLimpiarGrid: function (e) {
            $(st.txtByDefault).val('false');
            appLandings.formFilters.ByDefault = false;
            appLandings.resetFilters();
            $(st.frmGrid)[0].reset();
            $("#Name").val('').selectpicker("refresh");
        }
    };
    let table;
    let grid = function () {
        if (!$(st.grid).hasClass('initialized')) {
            table = $(st.grid).DataTable({
                //"dom": '<lf<t>ip>',
                'responsive': true,
                "lengthMenu": InitApp.dataTableGridOptions.lengthMenu,
                "pageLength": 10,
                //"scrollX": true,
                "searching": false,
                "ordering": true,
                "order": [[1, "desc"]],
                "processing": false,
                "language": InitApp.dataTableGridOptions.language['es'],
                "serverSide": true,
                "stateSave": false,
                "pagingType": "full_numbers",
                "ajax": {
                    "url": $(st.urlIndexGrid).val(),
                    "type": "POST",
                    'contentType': 'application/json; charset=utf-8',
                    "beforeSend": function () {
                        InitApp.showLoading();
                    },
                    "data": function (d) {
                        d.filters = {
                            Nombre: 'Yo'
                        };

                        return JSON.stringify(d);
                    },
                    "dataSrc": function (json) {
                        InitApp.hideLoading();
                        if (!json.success) {
                            alert(json.message)
                        }
                        else {
                            //appLandings.tableData = json.data;
                            return json.data;
                        }
                    }
                },
                "columns": [
                    { "data": "Nombre" },//1
                    { "data": "Identificacion" },//2
                    { "data": "Telefono1" },//3
                    { "data": "Telefono2" },//3
                ],
                "rowCallback": function (row, data, index) {
                },
                "drawCallback": function (settings) {
                    //$(document).find('[data-toggle="tooltip"]').tooltip();
                    $(st.grid).DataTable().columns.adjust().responsive.recalc();
                }
            });
            $(st.grid).not('.initialized').addClass('initialized').dataTable();
        }
    };
    let reDrawGrid = function () {
        $(st.grid).DataTable().draw();
    };
    let IniciarComponentes = function () {
        grid();
    };
    let initialize = function () {
        catchDom();
        suscribeEvents();
        IniciarComponentes();
    };
    return {
        init: initialize,
        reDrawGrid: reDrawGrid
    };
})(window);

$(function () {
    clientes.init();
});

const appClientes = new Vue({
    el: '#app-clientes',
    data: {
        url: '',
        resources: {
            unexpectedError: 'Ha ocurrido un error inesperado',
        }
    },
    methods: {
        localizer: function (key) {
            return this.resources[key];
        },
        showFormCreate: function () {
            //axios
            //    .get(this.urlgetevtmslandings)
            //    .then((response) => {
            //        if (response.data.status === "success") {
            //            if (response.data.data.length > 0) {
            //                this.createlandingselect = this.localizer('select');
            //                this.landingsEVTMS = response.data.data;
            //            }
            //            else {
            //                this.createlandingselect = this.localizer('notResults');
            //            }
            //        }
            //        else {
            //            InitApp.swalNotification("", response.data.message, "error");
            //        }
            //    })
            //    .catch(err => {
            //        console.log(err);
            //        this.createlandingselect = 'ERROR';
            //        InitApp.swalNotification("", err.response.data.Message, "error");
            //    });
        },
    },
    computed: {
    },
    beforeMount: function () {
        //this.urlgetevtmslandings = this.$el.querySelector('[id="urlgetevtmslandings"]').value;
    },
    mounted: function () {
    }
});