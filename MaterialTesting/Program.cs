using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MaterialTesting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //test1_Autocompleate();
            test2_Badge();

        }

        public static void test1_Autocompleate()
        {
            string expResult = "Two";
            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");
            
            //Maximize the window
            driver.Manage().Window.Maximize();

            //Navigate to Autocomplete page

            driver.FindElement(By.XPath("//div[text() = 'Autocomplete']")).Click();

            //Wait the page to load

            System.Threading.Thread.Sleep(1000);

            // Write an half of input and press selection

            
            IWebElement field = driver.FindElement(By.Id("mat-input-0"));

            field.SendKeys("Tw");

            driver.FindElement(By.XPath("//span[@class='mat-option-text']")).Click();

            string result = field.GetAttribute("value");

            driver.Close();

            Assert.Equals(result, expResult);
            
        }

        public static void test2_Badge()
        {

            string badgeCss = "mat-badge-hidden";

            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            //Maximize the window
            driver.Manage().Window.Maximize();

            //Navigate to Autocomplete page

            driver.FindElement(By.XPath("//div[text() = 'Badge']")).Click();

            //Wait the page to load

            System.Threading.Thread.Sleep(1000);

            IWebElement button = driver.FindElement(By.XPath("//button[@class='mat-focus-indicator mat-badge mat-raised-button mat-button-base mat-badge-overlap mat-badge-above mat-badge-after mat-badge-medium']"));

            button.Click();
            // Check if element has class

           string classes = button.GetAttribute("class");

            Assert.Contains(classes, badgeCss);
        Console.ReadLine();

            driver.Close();
        }

    }
}


