$(document).ready(function () {

    $.ajaxSetup({ cache: false });
    $(".btnDetalhes").click(function () {

        var id = $(this).data("value");
        $("#MODAL").load("/Perfil/Details/" + id, function () {
            $('#modal').modal("show");
        });
    });
});
//function perfilEdit(id, condicao) {

//    $("#MODAL").load("/Perfil/Edit/" + id, function () {
//        $('#modal').modal("show");

//        if (condicao == false)
//            $('#detailsBack').hide();
//        if (condicao == true)
//            $('#indexBack').hide();
//    });
//}
//function perfilDetails(id) {

//    $("#MODAL").load("/Perfil/Details/" + id, function () {
//        $('#modal').modal("show");
//    });
//}

//function fecharModal() {
//    $('#modal').modal("hide");
//}

$(document).ready(function () {

    $.ajaxSetup({ cache: false });
    $(".btnApagar").click(function () {

        var id = $(this).data("value");
        $("#MODAL").load("/Perfil/Apagar/" + id, function () {
            $('#modal').modal("show");
        });
    });
});

