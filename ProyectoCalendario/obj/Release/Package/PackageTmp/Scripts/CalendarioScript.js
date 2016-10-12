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
                alert('Fecha final menor que inicial.');
                $("#FF").val('');
            }
        }
    });

    $('#edadmax').change(function (event) {

        //("#FF").rules('add', { greaterThan: "#FI" });
        if ($("#edadmax").val() < $("#edadmin").val()) {
            alert('Edad Máxima menor a mínima');
            $("#edadmax").val('');
        }
    });

    $('#edadmin').change(function (event) {
        if ($("#edadmax").val() != "") {
            //("#FF").rules('add', { greaterThan: "#FI" });
            if ($("#edadmax").val() < $("#edadmin").val()) {
                alert('Edad Máxima menor a mínima');
                $("#edadmin").val('');
            }
        }
    });

    $('#viaaplicacion').change(function (event) {
        if($('#viaaplicacion').val()=='Oral')
        {
            $('#unidad').val('Gotas');
        }
        else
        {
            $('#unidad').val('cc');
        }
    });

    $('#TF').change(function (event) {

        //("#FF").rules('add', { greaterThan: "#FI" });
        if ($("#TF").val() < $("#TI").val()) {
            alert('Tiempo Final Menor que inicial');
            $("#TF").val('');
        }
    });

    $('#TI').change(function (event) {
        if ($("#TF").val() != "") {
            //("#FF").rules('add', { greaterThan: "#FI" });
            if ($("#TF").val() < $("#TI").val()) {
                alert('Tiempo Final Menor que inicial');
                $("#TI").val('');
            }
        }
    });

    var parauno = {
        "Contado desde nacimiento": "1",
        "Contado desde la última dosis aplicada": "2",
        "Despues de cumplir la edad indicada": "3"
        };

var parados = {

    "Contado desde la última dosis aplicada": "2",
    "Despues de cumplir la edad indicada": "3",
        "Antes de cumplir la edad indicada": "4"
        };

    $('#numeroveces').change(function (event) {
        var $el = $("#PI");
        var $pf = $("#PF");
        $el.empty();
        $pf.empty();
        if ($('#numeroveces').val() == 1) {
            $.each(parauno, function (key, value) {
                $el.append($("<option></option>")
                   .attr("value", value).text(key));
                $pf.append($("<option></option>")
                   .attr("value", value).text(key));
            });
        }
        else {
            $.each(parados, function (key, value) {
                $el.append($("<option></option>")
                   .attr("value", value).text(key));
                $pf.append($("<option></option>")
                   .attr("value", value).text(key));
            });
        }
        $("#TI").val('');
        $("#TF").val('');
    });

});

