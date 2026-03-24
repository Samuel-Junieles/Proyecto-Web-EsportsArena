document.addEventListener("DOMContentLoaded", function () {
    const successMsg = document.getElementById("registroSuccessData")?.value;

    if (successMsg && successMsg.trim() !== "") {
        Swal.fire({
            icon: 'success',
            title: '¡BIENVENIDO A LA ARENA!',
            text: successMsg,
            background: 'rgba(20, 25, 30, 0.95)',
            color: '#fff',
            backdrop: `rgba(0,0,0,0.6)`,

            timer: 2000, 
            timerProgressBar: true, 
            showConfirmButton: false, 

            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        });
    }
});