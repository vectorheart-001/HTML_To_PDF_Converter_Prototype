using Microsoft.AspNetCore.Mvc;
using PDF_Converter_Prototype.Converters;

namespace PDF_Converter_Prototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PDFController : ControllerBase
    {
        HTMLtoPDFConverter converter = new();

        [HttpGet(Name = "GET-PDF")]
        public FileContentResult Get_PDF()
        {
            var bytes = converter.PrintHTMLToPDF();
            return File(bytes, "application/pdf", "PDF_Example.pdf");
        }
    }
}
