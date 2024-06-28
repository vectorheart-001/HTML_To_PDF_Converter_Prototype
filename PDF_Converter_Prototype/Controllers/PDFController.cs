using Microsoft.AspNetCore.Mvc;
using PDF_Converter_Prototype.Converters;

namespace PDF_Converter_Prototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PDFController : ControllerBase
    {
        public IHttpContextAccessor _accessor = null;
        public PDFController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        [HttpGet(Name = "GET-PDF")]
        public FileContentResult Get_PDF()
        {
            var converter = new HTMLtoPDFConverter(_accessor);
            var bytes = converter.PrintHTMLToPDF();
            return File(bytes, "application/pdf", "PDF_Example.pdf");
        }
    }
}
