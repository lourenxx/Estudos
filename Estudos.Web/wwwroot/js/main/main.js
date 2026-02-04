const Main = function () {

    const controles = function () {
        return {
            loading: '#loading'
        }
    }

    const mostrarLoading = function () {
        $(controles().loading).show();
    }

    const esconderLoading = function () {
        $(controles().loading).hide();
    }

    return {
        mostrarLoading: mostrarLoading,
        esconderLoading: esconderLoading
    }
}