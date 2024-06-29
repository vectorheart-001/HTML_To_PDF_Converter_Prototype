using Microsoft.AspNetCore.Mvc;
using PDF_Converter_Prototype.Converters;
using System;
using System.Text.RegularExpressions;

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
        public async Task<FileContentResult> Get_PDF()
        {
            var converter = new HTMLtoPDFConverter(_accessor);
            var res = await converter.PrintHTMLToPDF();
            return File(res.Item1, "application/pdf", $"{res.Item2}.pdf");
        }
    }
}
