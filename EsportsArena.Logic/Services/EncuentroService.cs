using EsportsArena.Data;
using EsportsArena.Data.Interface;
using EsportsArena.Entities.Models;

namespace EsportsArena.Logic.Services
{
    public class EncuentroService
    {
        private readonly IGenericDAO<Encuentro> _encuentroDAO;

        public EncuentroService(IGenericDAO<Encuentro> encuentroDAO)
        {
            _encuentroDAO = encuentroDAO;
        }

        public void InscribirEnTorneo(int equipoId, string nombreTorneo)
        {
            string[] opciones = { "Ganó", "Perdió", "Empate" };
            Random ran = new Random();

            var nuevoEncuentro = new Encuentro
            {
                EquipoId = equipoId,
                NombreTorneo = nombreTorneo,
                ResultadoRandom = opciones[ran.Next(opciones.Length)],
                FechaEncuentro = DateTime.Now,
                PremioAcumulado = (decimal)(ran.NextDouble() * 1000) // Simulación de premio
            };

            _encuentroDAO.Insertar(nuevoEncuentro);
            _encuentroDAO.Guardar();
        }
    }
}