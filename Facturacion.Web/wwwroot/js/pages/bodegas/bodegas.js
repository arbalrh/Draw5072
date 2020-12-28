let bodegas = (function (window, undefined) {
    let st = {
        urlIndexGrid: "#urlgetbodegas",
        grid: "#grid-bodega",
        btnDeleteBodega: "a[id^='delete_']",
    };
    let dom = {};
    let catchDom = function () {
        dom.Document = $(document);
    };
    let suscribeEvents = function () {
        dom.Document.on("click", st.btnDeleteBodega, events.eDelete);
        //dom.Document.on("click", st.btnFilterReset, events.eLimpiarGrid);
    };
    let events = {
        eDelete: function (e) {
            appBodegas.deleteBodega($(this).attr('id').split('_')[1]);
        },
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
                "order": [[0, "desc"]],
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
                            Nombre: ''
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
                    { "data": "Nombre" },//0
                    { "data": "Direccion" },//1
                    { "data": "Observaciones" },//2
                    {
                        "className": 'pl-0',
                        "width": '5%',
                        "orderable": false,
                        "data": null,
                        "defaultContent": ''
                    },//3
                ],
                "rowCallback": function (row, data, index) {
                    $('td:eq(3)', row).html(
                        `
                            <ul class="table-controls">
                                <li><a id="edit_${data.BodegaId}" href="javascript:void(0);" class="bs-tooltip" data-toggle="tooltip" data-placement="top" title="" data-original-title="Edit"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-edit-2 p-1 br-6 mb-1"><path d="M17 3a2.828 2.828 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5L17 3z"></path></svg></a></li>
                                <li><a id="delete_${data.BodegaId}" href="javascript:void(0);" class="bs-tooltip" data-toggle="tooltip" data-placement="top" title="" data-original-title="Delete"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-trash p-1 br-6 mb-1"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path></svg></a></li>
                            </ul>
                        `
                    );                    
                },
                "drawCallback": function (settings) {
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
    bodegas.init();
});

const appBodegas = new Vue({
    el: '#app-bodega',
    data: {
        basePath: '',
        url: '',
        urlcreatebodega: '',
        urldeletebodega: '',
        formValidationBodega: {
            nombreRequerido: false
        },
        formBodega: {
            nombre: '',
            direccion: '',
            observaciones: ''
        },
        resources: {
            unexpectedError: 'Ha ocurrido un error inesperado',
            deleteMensajeBodega: '¿Está seguro de que desea eliminar la bodega?',
        }
    },
    methods: {
        localizer: function (key) {
            return this.resources[key];
        },
        showModal() {
            this.formValidationBodega.nombreRequerido = false;
            $('#modal-register').modal();
        },
        createBodega() {
            if (!this.formBodega.nombre) {
                this.formValidationBodega.nombreRequerido = true;
                return;
            }
            $('#modal-register').modal('hide');
            InitApp.showLoading();
            axios
                .post(this.urlcreatebodega, this.formBodega, {
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                    }
                })
                .then((response) => {
                    InitApp.hideLoading();
                    if (response.data.Status === "success") {
                        bodegas.reDrawGrid();
                        InitApp.toastNotification(response.data.Message);
                    }
                    else {
                        InitApp.swalNotification("", response.data.Message, "error");
                    }
                })
                .catch(err => {
                    console.log(err);
                    InitApp.swalNotification("", err.response.data.Message, "error");
                });
        },
        async deleteBodega(guid) {
            const { dismiss } = await Swal.fire({
                title: this.resources['deleteMensajeBodega'],
                type: "warning",
                showCancelButton: true,
                confirmButtonText: 'Sí',
                cancelButtonText: 'No',
            });
            if (dismiss) {
                return;
            }
            InitApp.showLoading();
            axios
                .delete(this.urldeletebodega + `?guid=${guid}`, {
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                    }
                })
                .then((response) => {
                    InitApp.hideLoading();
                    if (response.data.Status === "success") {
                        bodegas.reDrawGrid();
                        InitApp.toastNotification(response.data.Message);
                    }
                    else {
                        InitApp.swalNotification("", response.data.Message, "error");
                    }
                })
                .catch(err => {
                    console.log(err);
                    InitApp.swalNotification("", err.response.data.Message, "error");
                });
        }
    },
    computed: {
    },
    beforeMount: function () {
        this.basePath = $("#basePath").val();
        this.urlcreatebodega = `${this.basePath}Bodega/CreateBodega`;
        this.urldeletebodega = `${this.basePath}Bodega/DeleteBodega`;
    },
    mounted: function () {
    }
});