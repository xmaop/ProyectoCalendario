$(document).ready(function () {



    $('#tablaCalendario tr').click(function (event) {

        $.ajax({
            url: "/DetalleCalendarios/Filtra/" + $(this).attr('id'), success: function (result) {
                $("#contenedorDetalle").html(result);
                $("#contenedorPauta").html('');
            }
        });
    });



    $(document).on("click", ".sframe", function (e) {

        $.ajax({
            url: "/Pautas/Filtra/" + this.id, success: function (result) {
                $("#contenedorPauta").html(result);
            }
        });
    });

    $('#FF').change(function (event) {

        //("#FF").rules('add', { greaterThan: "#FI" });
        if ($("#FF").val() < $("#FI").val()) {
            alert('Fecha final menor que inicial.');
            $("#FF").val('');
        }
    });
    $('#FI').change(function (event) {
        if ($("#FF").val() != "") {
            //("#FF").rules('add', { greaterThan: "#FI" });
            if ($("#FF").val() < $("#FI").val()) {
                alert('FF' + $("#FF").val());
                $("#FF").val('');
            }
        }
    });


});

