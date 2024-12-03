using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace EclipseWorksAssessment.WebAPI.Controllers
{
    //[Authorize(Roles = "Manager")]
    [ApiController]
    [Route("api/relatories")]
    public class RelatoriesController : ControllerBase
    {
        private readonly IRelatoriesService _relat;
        
        public RelatoriesController(IRelatoriesService reportService)
        {
            _relat = reportService;
        }

        [HttpGet("performance")]
        public async Task<IActionResult> GetUserPerformanceReport([FromQuery] string format = "json")
        {
            var reportData = await _relat.GenerateUserTaskPerformanceReport();

            return format.ToLower() switch
            {
                "json" => Ok(reportData),
                "excel" => File(GenerateExcelReport(reportData), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PerformanceReport.xlsx"),
                "pdf" => File(GeneratePdfReport(reportData), "application/pdf", "PerformanceReport.pdf"),
                _ => BadRequest("Unsupported format.")
            };
        }
        private byte[] GenerateExcelReport(List<UserTaskPerformanceViewModel> data)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Relatório de Performance");

            worksheet.Cells[1, 1].Value = "Usuário";
            worksheet.Cells[1, 2].Value = "Tarefas Completadas";
            worksheet.Cells[1, 3].Value = "Média de Tarefas Completadas por Usuário nos últimos 30 dias";

            for (int i = 0; i < data.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = data[i].UserName;
                worksheet.Cells[i + 2, 2].Value = data[i].CompletedTasks;
                worksheet.Cells[i + 2, 3].Value = data[i].AverageCompletedTasks;
            }

            return package.GetAsByteArray();
        }
        private byte[] GeneratePdfReport(List<UserTaskPerformanceViewModel> data)
        {
            using var memoryStream = new MemoryStream();
            var document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, memoryStream);

            document.Open();
            document.Add(new Paragraph("Performance Report"));

            foreach (var item in data)
            {
                document.Add(new Paragraph($"User: {item.UserName}, Tasks Completed: {item.CompletedTasks}, Average: {item.AverageCompletedTasks:F2}"));
            }

            document.Close();
            return memoryStream.ToArray();
        }

    }
}
