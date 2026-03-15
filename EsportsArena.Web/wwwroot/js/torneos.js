/**
 * Lógica de simulación para Esports Arena
 */

function iniciarDuelo(id) {
    const wrapper = document.getElementById('wrapper-' + id);
    const timerContainer = document.getElementById('timer-container-' + id);
    const clock = document.getElementById('clock-' + id);
    const progressBar = document.getElementById('progress-' + id);

    // 1. Switchear vistas
    wrapper.classList.add('d-none');
    timerContainer.classList.remove('d-none');

    let count = 5;
    let width = 100;

    const countdown = setInterval(() => {
        count--;
        width -= 20;

        clock.innerText = count;
        if (progressBar) progressBar.style.width = width + '%';

        if (count <= 0) {
            clearInterval(countdown);
            ejecutarSimulacion(id);
        }
    }, 1000);
}

function ejecutarSimulacion(id) {
    // Llamada AJAX al controlador
    fetch(`/Torneos/ProcesarResultado/${id}`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    })
        .then(response => {
            if (!response.ok) throw new Error("Error en la respuesta del servidor");
            return response.json();
        })
        .then(data => {
            const timerContainer = document.getElementById('timer-container-' + id);

            if (data.success) {
                let color = "text-info";
                if (data.resultado === "Ganó") color = "text-success";
                if (data.resultado === "Perdió") color = "text-danger";

                timerContainer.innerHTML = `
                <div class="animate__animated animate__zoomIn">
                    <span class="text-muted d-block small mb-1">RESULTADO FINAL</span>
                    <h2 class="${color} fw-black text-uppercase">${data.resultado}</h2>
                    <button class="btn btn-sm btn-outline-secondary mt-2" onclick="location.reload()">Cerrar</button>
                </div>
            `;
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("Hubo un fallo al conectar con el servidor.");
            location.reload();
        });
}