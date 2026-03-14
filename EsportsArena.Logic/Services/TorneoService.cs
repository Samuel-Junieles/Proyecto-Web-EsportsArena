namespace EsportsArena.Logic.Services
{
    public class TorneoService
    {
        // Método solicitado: Simulación de resultado al inscribirse
        public string GenerarResultadoAleatorio()
        {
            string[] resultados = { "Ganó", "Perdió", "Empate" };
            Random ran = new Random();
            return resultados[ran.Next(resultados.Length)];
        }
    }
}