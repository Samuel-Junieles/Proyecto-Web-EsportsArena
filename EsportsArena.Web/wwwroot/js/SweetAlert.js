document.addEventListener("DOMContentLoaded", function () {

    const loginError = document.getElementById("loginErrorData")?.value;

    if (loginError) {
        Swal.fire({
            icon: 'error',
            title: '¡ACCESO DENEGADO!',
            text: loginError,
            background: '#1a1a1a',
            color: '#fff',
            confirmButtonColor: '#ffc107',
            confirmButtonText: 'REINTENTAR',
            customClass: {
                popup: 'border-warning shadow-lg'
            }
        });
    }
});