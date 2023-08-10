
function DeleteInstitution(id) {
    Swal.fire({
        title: 'Você tem certeza?',
        text: "Essa Instituição será excluída permanentemente!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Excluir',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: document.URL + "/DeleteBank/" + id,
                success: function (data) {
                    if (data) {
                        window.location.reload();
                    }
                },
                error: function (errorThrown) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Algo deu errado!'
                    })
                }
            });
        }
    })
};

function UpdateInstitutionName(input, id) {
    var dados = {
        Name: input.value,
        BankId: id
    };

    $.ajax({
        type: "POST",
        url: document.URL + "/UpdateBankName",
        contentType: "application/json",
        data: JSON.stringify(dados),
        success: function (result) {
            if (result) {
                input.value = result;
            }
        },
        error: function (errorThrown) {
            Swal.fire({
                icon: 'error',
                title: 'Erro',
                text: JSON.stringify(errorThrown)
            })
        }
    });
};

function SetBankId(id) {
    $('#cadastro-conta-bankid').val(id);
}