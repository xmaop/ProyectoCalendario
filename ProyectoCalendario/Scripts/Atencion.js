var atencion = "";
var calendario = "";
var detalleCalendario = "";
var pautas = "";

$(document).ready(function () {

   
    $('#tablaListaAtencion tr').click(function (event) {
        atencion = $(this).attr('id');

        $.ajax({
            url: "/Clientes/Filtra/" + $(this).attr('id'), success: function (result) {
                //alert(result);
                $("#contenedorClienteAtencion").html(result);
                $("#contenedorClienteAtencion").show();
                //$("#contenedorPauta").html('');
            }
        });

        $.ajax({
            url: "/Mascotas/Filtra/" + $(this).attr('id'), success: function (result) {
                //alert(result);
                $("#contenedorMascotaAtencion").html(result);
                $("#contenedorMascotaAtencion").show();
                //$("#contenedorPauta").html('');
            }


        });

        $.ajax({
            url: "/Calendarios/FiltraCalendario/", success: function (result) {
                //alert(result);
                $("#contenedorCalendarioAtencion").html(result);
                $("#contenedorCalendarioAtencion").show();
                //$("#contenedorPauta").html('');
            }
        });

        $("#ListaEpera").hide();
        $("#botonRegresa").show();
    });

    $(document).on("click", ".sframe2", function (e) {
        calendario = $(this).attr('id')

        $.ajax({
            url: "/DetalleCalendarios/FiltraDetalle/" + $(this).attr('id'), success: function (result) {
                $("#contenedorDetalleAtencion").html(result);
                $("#contenedorDetalleAtencion").show();
                $("#contenedorPautaAtencion").html('');
            }
        });
    });



    $(document).on("click", ".sframe3", function (e) {
        detalleCalendario = this.id;
        $.ajax({
            url: "/Pautas/FiltraPautas/" + this.id, success: function (result) {
                $("#contenedorPautaAtencion").html(result);
                $("#contenedorPautaAtencion").show();
            }
        });
    });

    $(document).on("click", ".sframe4", function (e) {
        pautas = this.id;
        $("#contenedorFinalizaAtencion").show();
    });



});


function btn_grabar() {
    alert("datos a guardar : atencion: " + atencion + " | calendario: " + calendario + " | detalleCalendario: " + detalleCalendario + " | pautas" + pautas + " | txtRechazo: " + $("#txtRechazo").val());

    var servicio = [atencion, calendario, detalleCalendario, pautas];
    
    $.ajax({
        url: "/ServicioCliniceos/Create/",
        data: { //Passing data   
            ListaAtencionId: atencion, //Reading text box values using Jquery   
            CalendarioId: calendario,
            detalleCalendarioId: detalleCalendario,
            pautasId: pautas,
            FF: '20161012'
        }, success: function (result) {
            alert("Se registro correctamente");
        }
    });
}

function btn_Regresa() {
    $("#contenedorClienteAtencion").html('');
    $("#contenedorMascotaAtencion").html('');
    $("#contenedorClienteAtencion").hide();
    $("#contenedorMascotaAtencion").hide();
    $("#contenedorCalendarioAtencion").html('');
    $("#contenedorCalendarioAtencion").hide();

    $("#contenedorDetalleAtencion").html('');
    $("#contenedorDetalleAtencion").hide();
    $("#contenedorPautaAtencion").html('');
    $("#contenedorPautaAtencion").hide();

    $("#ListaEpera").show();
    $("#botonRegresa").hide();
}