using EsportsArena.Logic.Services;
using Microsoft.AspNetCore.Mvc;

public class ReportesController : Controller
{
    private readonly UsuarioService _usuarioService;
    private readonly ReporteService _reporteService;

    public ReportesController(UsuarioService usuarioService, ReporteService reporteService)
    {
        _usuarioService = usuarioService;
        _reporteService = reporteService;
    }

    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult ExportarUsuariosExcel()
    {
        var usuarios = _usuarioService.ObtenerTodosLosUsuarios();
        var archivo = _reporteService.GenerarExcelUsuarios(usuarios);
        return File(archivo, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteUsuarios.xlsx");
    }

    [HttpGet]
    public IActionResult ExportarUsuariosPdf()
    {
        var usuarios = _usuarioService.ObtenerTodosLosUsuarios();

        var archivo = _reporteService.GenerarPdfUsuarios(usuarios);

        return File(archivo, "application/pdf", "Reporte_Operadores_Arena.pdf");
    }
}