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
        
        public byte[] PrintHTMLToPDF()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments("--no-sandbox");
            _chromeOptions.AddArgument("--disable-dev-shm-usage");
            _chromeOptions.AddArgument("--whitelisted-ips=");
            _chromeOptions.AddArguments("--headless");

            //creating webdriver
            _driver = new ChromeDriver(_chromeOptions);

            //go to the website
            _driver.Navigate().GoToUrl("https://www.eveliko.com/");

            //defining configurations for de printing
            PrintOptions printOptions = new PrintOptions
            {
                Orientation = PrintOrientation.Portrait
            };

            //printing...
            PrintDocument printDocument = _driver.Print(printOptions);

            return printDocument.AsByteArray;

            //saving the file
            //printDocument.SaveAsFile(printFinalPath);
            //return File.ReadAllBytes(printFinalPath);
        }
        

    }
}
