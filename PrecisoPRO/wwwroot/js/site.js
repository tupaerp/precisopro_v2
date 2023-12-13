// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/*ALTERAÇÕES PAULO - 29112023 */
function maiuscula(z) {
    v = z.value.toUpperCase();
    z.value = v;
}

function limparInputs() {
    // Obtém todos os elementos de entrada (inputs) usando document.querySelectorAll
    var inputs = document.querySelectorAll('input');
   
   
    // Itera sobre os elementos e define o valor de cada input como uma string vazia
    inputs.forEach(function (input) {
        input.value = '';
    });

    var valor = "";
    document.getElementById('estado').value = valor;
}

//mascaras
//mascaras
$(document).ready(function () {
    $('.date').mask('99/99/9999');
    $('.time').mask('00:00:00');
    $('#cep').mask('99.999-999');
    $('#Cep').mask('99.999-999');
    $('.phone').mask('9999-9999');
    $('.telefone').mask('(99)9999-9999');
    $('.celular').mask("(99)99999-9999");
    $('#cnpj').mask('99.999.999/9999-99');
    $('#Cnpj').mask('99.999.999/9999-99');
    $('#telefone').mask('(99)99999-9999');
    $(".senha").mask("xxxxxxxxx");
    $("#cest").mask("99.999.99");
    $("#ProcuraNCM").mask("9999.99.99");
    $("#ncm").mask("9999.99.99");
    $(".decimal").mask("9999,999");
    $(".pr-aliq").mask("9999.999");

});
jQuery(function ($) {
    $("#campoData").mask("99/99/9999");
    $("#campoTelefone").mask("(999) 999-9999");

});
function chamarIncluir() {

    var cont = document.querySelector(".pro-titulo"); //pega o titulo

    var controller = cont.innerText;

  

    $("#modal").load("/" + controller + "/Incluir/", function () {

        $('#modal').modal("show");

    });
}


//obsoleto, so esta aqui para documentação
function chamarAssociar() {

    var cont = document.querySelector(".pro-titulo"); //pega o titulo

    var controller = cont.innerText;



    $("#modal").load("/" + controller + "/AssociarEmpresa/", function () {

        $('#modal').modal("show");

    });
}

function chamarAssociarIndividual(id) {

    var cont = document.querySelector(".pro-titulo"); //pega o titulo

    var controller = cont.innerText;
   
    $("#modal").load("/" + controller + "/AssociarIndividual/" + id, function () {
        $('#modal').modal("show");

    });
}
//fim obsoleto

//FECHAR O ALERT APOS A MENSAGEM
$(document).ready(function () {
    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {

            $(this).alert('close');
        });

    }, 5000);
});

$(document).ready(function () {

    
    $('#EmpresaIncluir').on('submit', function (e) {
        $.each($('input[aria-required="true"]'), function () {
            if (!this.value || this.value == '') {


                               
                alert('Há campos obrigatórios sem preenchimento, verifique todas as abas!');
                e.preventDefault();
                return false;
            }
        });
    });




});