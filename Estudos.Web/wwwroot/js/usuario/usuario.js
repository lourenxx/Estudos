const usuario = function () {

    const controles = function () {
        return {
            //tabelas
            tabelaUsuarios: '#tabelaUsuarios',

            //Cadastro
            nomeUsuario: '#nomeUsuario',
            emailUsuario: '#emailUsuario',
            senhaUsuario: '#senhaUsuario',
            dataNascimentoUsuario: '#dataNascimentoUsuario'
        }
    }

    const getDtoUsuario = function () {
        return {
            nome: $(controles().nomeUsuario).val(),
            email: $(controles().emailUsuario).val(),
            senha: $(controles().senhaUsuario).val(),
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
                },
                {
                    data: null,
                    title: 'Ações',
                    className: 'text-center align-middle',
                    orderable: false,
                    render: function (data, type, row) {
                       return `
                        <div class="btn-group btn-group-sm" role="group">
                            <button title="Alterar"
                                    class="btn btn-outline-primary"
                                    onclick="usuario().editarUsuario(${row.id})">
                                ✏
                            </button>
                            <button title="Excluir"
                                    class="btn btn-outline-danger"
                                    onclick="usuario().excluirUsuario(${row.id})">
                                🗑️
                            </button>
                        </div>
                    `;
                    }
                }

            ]
        })
    }

    const listarUsuarios = function () {
        Main.mostrarLoading()
        $.ajax({
            type: 'GET',
            url: '../Usuario/ListarUsuarios',
            cache: false,
        }).done(function (data) {
            Main.esconderLoading();
            tabelaUsuarios(data)
        }).fail(function (jqXHR, textStatus, errorThrown) {
            Main.esconderLoading();
            console.log('Erro ao listar usuários: ' + textStatus)
        })
    }

    const cadastrarUsuarios = function () {
        $.ajax({
            type: 'POST',
            url: '../Usuario/CadastrarUsuarios',
            data: {
                'dto': getDtoUsuario()
            },
            cache: false,
        }).done(function (data) {
            window.location.href = '/Usuario'
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log('Erro ao cadastrar usuário: ' + textStatus)
        });
    }

    const excluirUsuario = function (id) {
        $.ajax({
            type: 'POST',
            url: `../Usuario/ExcluirUsuario`,
            data: {
                'id': id
            },
            cache: false,
        }).done(function (data) {
            alert(data);
            window.location.href = '/Usuario'
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log('Erro ao excluir usuário: ' + textStatus)
        });
    }

    return {
        listarUsuarios: listarUsuarios,
        cadastrarUsuarios: cadastrarUsuarios,
        excluirUsuario: excluirUsuario
    }
}