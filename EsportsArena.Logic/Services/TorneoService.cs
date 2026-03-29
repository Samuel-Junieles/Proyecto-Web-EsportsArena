namespace EsportsArena.Logic.Services
{
    public class TorneoService
    {
        public string GenerarResultadoAleatorio(string local, string visitante)
        {
            // Aumentamos las opciones para que haya más variedad
            string[] opciones = {
                $"Ganó {local}",
                $"Ganó {visitante}",
                "Empate Técnico",
            };

            Random ran = new Random();
            return opciones[ran.Next(opciones.Length)];
        }
    }
}