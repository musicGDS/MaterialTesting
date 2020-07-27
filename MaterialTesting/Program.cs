using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MaterialTesting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            test1_Autocompleate();
        }

        public static void test1_Autocompleate()
        {
            string result = "two";
            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            //Maximize the window
            driver.Manage().Window.Maximize();

            //Navigate to Autocomplete page

            driver.FindElement(By.XPath("//div[text() = 'Autocomplete']")).Click();


            // Write an half of input and press enter

            IWebElement element = driver.FindElement(By.XPath("//input[@id='mat-input-0']"));
            //IWebElement element = driver.FindElement(By.Id("mat-input-0"));
            //IWebElement element = driver.FindElement(By.XPath("");


            element.SendKeys("Tw");
            

            element.Click();


            string end = Console.ReadLine();
            driver.Close();
        }


    }
}


//<input _ngcontent-ewa-c154="" type="text" aria-label="Number" matinput="" class="mat-input-element mat-form-field-autofill-control mat-autocomplete-trigger ng-tns-c144-6 ng-pristine ng-valid cdk-text-field-autofill-monitored ng-touched" id="mat-input-0" data-placeholder="Pick one" aria-invalid="false" aria-required="false" autocomplete="off" role="combobox" aria-autocomplete="list" aria-expanded="false" aria-haspopup="true">