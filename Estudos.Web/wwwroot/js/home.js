
const home = function () {

    const controles = function () {
        return {
            tabelaUsuarios: '#tabelaUsuarios'
        }
    }

    const tabelaUsuarios = function (data) {
        $(controles().tabelaUsuarios).DataTable({
            data: data,
            filter: true,
            info: true,
            paginate: true,
            searching: false,
            paginationType: 'full_numbers',
            lengthChange: false,
            iDisplayLength: 10,
            language: {
                info: "Mostrando _END_ de _TOTAL_ registros",
                processing: 'Processando...',
                zeroRecords: 'Nenhum registro encontrado.',
                paginate: {

                    first: '&laquo;',
                    previous: '<',
                    next: '>',
                    last: '&raquo;'
                }
            },
            order: [[0, 'asc']],
            columns: [
                {
                    data: 'id',
                    title: 'ID'
                },
                {
                    data: 'nome',
                    title: 'Nome'
                },
                {
                    data: 'email',
                    title: 'Email'
                },
                {
                    data: 'dataCriacao',
                    title: 'Data de Criação',
                    render: function (data) {
                        const d = new Date(data)
                        return `${d.toLocaleDateString('pt-BR')} ${d.toLocaleTimeString('pt-BR', {
                            hour: '2-digit',
                            minute: '2-digit'
                        })}`
                    }
                }

            ]
        })
    }

    const listarUsuarios = function () {
        $.ajax({
            type: 'GET',
            url: '/Home/ListarUsuarios',
            cache: false,
        }).done(function (data) {
           console.log('Entrou o grosso!', data)
            tabelaUsuarios(data)
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log('Erro ao listar usuários: ' + textStatus)
        })
    }

    return {
        listarUsuarios: listarUsuarios
    }
}