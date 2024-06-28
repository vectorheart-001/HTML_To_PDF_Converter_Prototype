using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace PDF_Converter_Prototype.Converters
{
    public class HTMLtoPDFConverter
    {
        public ChromeOptions _chromeOptions;
        public WebDriver _driver;
        public static string fileName = "PDF_Example";
        public static string printFinalPath = System.IO.Directory.GetCurrentDirectory() + @$"\{fileName}";

        public IHttpContextAccessor _contextAccessor = null;

        public HTMLtoPDFConverter(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public byte[] PrintHTMLToPDF()
        {
            try
            {
                string url = "https://www.eveliko.com";

                if (!string.IsNullOrWhiteSpace(_contextAccessor.HttpContext.Request.Query["printUrl"]))
                {
                    url = _contextAccessor.HttpContext.Request.Query["printUrl"];
                }

                _chromeOptions = new ChromeOptions();
                _chromeOptions.AddArguments("--no-sandbox");
                _chromeOptions.AddArgument("--disable-dev-shm-usage");
                _chromeOptions.AddArgument("--whitelisted-ips=");
                _chromeOptions.AddArguments("--headless");

                //creating webdriver
                _driver = new ChromeDriver(_chromeOptions);

                //go to the website
                _driver.Navigate().GoToUrl(url);

                //defining configurations for de printing
                PrintOptions printOptions = new PrintOptions
                {
                    Orientation = PrintOrientation.Portrait
                };

                //printing...
                PrintDocument printDocument = _driver.Print(printOptions);
                try
                {
                    _driver.Quit();
                }
                catch { } // On Purpose, we want to ensure Quit doesn't interupt already rendered doc.
                return printDocument.AsByteArray;
            }
            catch
            {
                _driver.Quit();
                return null;
            }
            //saving the file
            //printDocument.SaveAsFile(printFinalPath);
            //return File.ReadAllBytes(printFinalPath);
        }
        

    }
}
