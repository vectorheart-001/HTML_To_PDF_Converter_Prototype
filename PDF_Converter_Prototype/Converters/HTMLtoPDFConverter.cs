using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
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
            _chromeOptions.AddArguments("headless"); //your chrome driver needs run in headless!

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

            //saving the file
            printDocument.SaveAsFile(printFinalPath);
            return File.ReadAllBytes(printFinalPath);
        }
        

    }
}
