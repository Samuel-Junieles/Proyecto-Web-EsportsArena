document.addEventListener("DOMContentLoaded", function () {
    const ctxArena = document.getElementById('arenaChart');
    const ctxDist = document.getElementById('distribucionChart');

    if (ctxArena) {
        new Chart(ctxArena, {
            type: 'line',
            data: {
                labels: ['Sem 1', 'Sem 2', 'Sem 3', 'Sem 4'],
                datasets: [{
                    label: 'Puntaje de Arena',
                    data: [12, 19, 3, 5],
                    borderColor: '#00f2fe',
                    backgroundColor: 'rgba(0, 242, 254, 0.05)',
                    borderWidth: 4,
                    fill: true,
                    tension: 0.5, // Curvas más suaves estilo gamer
                    pointRadius: 6, // Puntos más grandes
                    pointBackgroundColor: '#fff',
                    pointBorderColor: '#00f2fe'
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: { labels: { color: '#ffffff', font: { size: 14 } } }
                },
                scales: {
                    y: { grid: { color: 'rgba(255,255,255,0.02)' }, ticks: { color: '#8b949e' } },
                    x: { grid: { display: false }, ticks: { color: '#8b949e' } }
                }
            }
        });
    }

    if (ctxDist) {
        new Chart(ctxDist, {
            type: 'doughnut',
            data: {
                labels: ['Victorias', 'Derrotas', 'Empates'],
                datasets: [{
                    data: [15, 7, 3],
                    backgroundColor: ['#00f2fe', '#7000ff', '#444'],
                    borderWidth: 0,
                    hoverOffset: 15
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: { position: 'bottom', labels: { color: '#ffffff' } }
                }
            }
        });
    }
});