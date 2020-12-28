var InitApp = (function (window, undefined) {
    let constantes = {

    };
    let dataTableGridOptions = {
        language: {
            es: {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            },
            en: {
                "sProcessing": "Processing...",
                "sLengthMenu": "Show _MENU_ entries",
                "sZeroRecords": "No found results",
                "sEmptyTable": "No data available in table",
                "sInfo": "Showing _START_ to _END_ of _TOTAL_ entries",
                "sInfoEmpty": "Showing 0 to 0 of 0 entries",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Search:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Loading...",
                "oPaginate": {
                    "sFirst": "First",
                    "sLast": "Last",
                    "sNext": "Next",
                    "sPrevious": "Previous"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        },
        lengthMenu: [[10, 15, 20, 25, -1], [10, 15, 20, 25, "All"]]
    };
    let st = {
        body: "body",
        lnkLogOut: "#lnk-logOut",
        modalSmall: "#smallAlertModal",
        divSmallModalBody: "#smallModalBody",
        hdnMessage: "#JSMessages",
        frmLogOut: "#frm-LogOut",
        btnConfirm: "#confirm-ok",
        cssMenu: ".menu-item",
        hiddenItemActive: "#lastOption",
        btnPrint: "#print-general"
    };
    let myWind = "";
    let functionToExecute;
    let parametros;
    let dom = {};
    let toast = swal.mixin({
        toast: true,
        position: "top-end",
        showClass: {
            popup: 'animate__animated animate__fadeInRight'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutRight',
        },
        showConfirmButton: false,
        timer: 4000,
        padding: "2em",
    });
    let catchDom = function () {
        dom.lnkLogOut = $(st.lnkLogOut);
        dom.modalSmall = $(st.modalSmall);
        dom.btnConfirm = $(st.btnConfirm);
        dom.btnPrint = $(st.btnPrint);
        dom.cssMenu = $(st.cssMenu);
    };
    let suscribeEvents = function () {
        dom.lnkLogOut.on("click", events.eLogOut);
        dom.btnConfirm.on("click", events.eConfirm);
        dom.btnPrint.on("click", events.ePrint);
    };
    $('#modal').on('hidden.bs.modal', function (e) {
        $('.modal-backdrop').remove();
    });
    let events = {
        eLogOut: function (e) {
            $(st.frmLogOut).submit();
        },
        eConfirm: function () {
            $("#confirm-dialog").modal("hide");
            functionToExecute(parametros);
        },
        ePrint: function () {
            window.print();
        }
    };
    let getCulture = function () {
        return ($("#l-selected").attr("data-language") || "en-US") === 'en-US' ? 'en' : 'es';
    };
    let isNumeric = function (value) {
        return !isNaN(value);
    };
    let containsDuplicates = function (array) {
        return new Set(array).size !== array.length;
    };
    let getDefaultDateConfig = function () {
        let dateFormat = "DD-MM-YYYY hh:mm A";
        return {
            format: dateFormat,
            defaultDate: new Date(),
            minDate: new Date()
        };
    };
    let getDateConfig = function () {
        let dateFormat = "DD-MM-YYYY";
        return {
            format: dateFormat,
            defaultDate: new Date(),
            minDate: new Date()
        };
    };
    let getCustomDateConfig = function (date) {
        let dateFormat = "DD-MM-YYYY";
        return {
            format: dateFormat,
            defaultDate: moment(date, "DD-MM-YYYY")
        };
    };
    let getCustomShiftDateConfig = function () {
        let dateFormat = "DD-MM-YYYY";
        return {
            format: dateFormat
        };
    };
    let getTimeConfig = function () {
        let dateFormat = "hh:mm A";
        return {
            format: dateFormat,
            defaultDate: new Date()
        };
    };
    let getTime24HDefaultConfig = function () {
        let dateFormat = "HH:mm";
        return {
            format: dateFormat,
            defaultDate: new Date()
        };
    };
    let getTime24HConfig = function () {
        let dateFormat = "HH:mm";
        return {
            format: dateFormat
        };
    };
    let getPermissions = function () {
        let name = "lwp=";
        let allCookieArray = document.cookie.split(';');
        let stringValue = '';
        for (var i = 0; i < allCookieArray.length; i++) {
            var temp = allCookieArray[i].trim();
            if (temp.indexOf(name) == 0) {
                stringValue = temp.substring(name.length, temp.length).replace(/%2C%20/g, ",").toUpperCase();
                break;
            }
        }
        return stringValue.split(',');
    };
    let containPermission = function (permissionId) {
        let permissions = getPermissions();
        return permissions.includes(permissionId.toUpperCase());
    };
    let toastNotification = function (title) {
        toast.fire({
            type: "success",
            title: title,
            icon: 'success',
            padding: "2em",
        });
    };
    let swalNotification = function (title, text, type) {
        Swal.fire({
            type: type,
            title: title,
            text: text,
            width: 400,
            padding: '1em'
        });
    };
    let showLoading = function () {
        $("#app-loading").removeClass('animate__fadeOut d-none').addClass('animate__fadeIn');
    };
    let hideLoading = function () {
        $("#app-loading").addClass('animate__fadeOut').addClass('d-none');
    };
    let fadeHideLoading = function (ms) {
        $("#app-loading").addClass('animate__fadeOut');
        setTimeout(() => $("#app-loading").addClass('d-none'), ms);
    };
    let IniciarComponentes = function () {
        $('[data-toggle="tooltip"]').tooltip();
        //toastr.options = {
        //    "closeButton": true,
        //    "showDuration": "500",
        //};
    };
    let advertencia = function () {
        //console.clear();
        console.log('%cAtención', 'color:red;font-weight: bold;font-size:xx-large;');
        console.log('%cEsta función del navegador está pensada para desarrolladores. Si intentas "hackear" este sitio web podrá deshabilitar tus credenciales de acceso.', 'color:black;font-size:large;');
    };
    let initialize = function () {
        catchDom();
        suscribeEvents();
        IniciarComponentes();
        advertencia();
    };
    return {
        init: initialize,
        dataTableGridOptions: dataTableGridOptions,
        getCulture: getCulture,
        getDefaultDateConfig: getDefaultDateConfig,
        getDateConfig: getDateConfig,
        getTimeConfig: getTimeConfig,
        getCustomDateConfig: getCustomDateConfig,
        getTime24HConfig: getTime24HConfig,
        getTime24HDefaultConfig: getTime24HDefaultConfig,
        getCustomShiftDateConfig: getCustomShiftDateConfig,
        toastNotification: toastNotification,
        isNumeric: isNumeric,
        containsDuplicates: containsDuplicates,
        swalNotification: swalNotification,
        showLoading: showLoading,
        hideLoading: hideLoading,
        fadeHideLoading: fadeHideLoading,
        containPermission: containPermission
    };
})(window);

$(function () {
    InitApp.init();
});

