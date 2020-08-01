using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MaterialTesting
{
    [TestFixture]
    class MainClass
    {
        
        public static void Main(string[] args)
        {
            //test1_Autocompleate();
            //test2_Badge();
            //test3_bottomSheet();
            //test4_Button();
            //test5_ButtonToggle();
        }

        [Test]
        public static void test1_Autocompleate()
        {
            string expResult = "Two";
            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver();

            //Navigate to material design page
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

            Assert.AreEqual(result, expResult, "Test one OK");
            
        }

        [Test]
        public static void test2_Badge()
        {

            string badgeCss = "mat-badge-hidden";

            IWebDriver driver = new ChromeDriver();

            //Navigate to metrial design page
            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            //Maximize the window
            driver.Manage().Window.Maximize();

            //Navigate to Autocomplete page

            driver.FindElement(By.XPath("//div[text() = 'Badge']")).Click();

            //Wait the page to load

            System.Threading.Thread.Sleep(1000);

            IWebElement button = driver.FindElement(By.XPath("//button[@class='mat-focus-indicator mat-badge mat-raised-button mat-button-base mat-badge-overlap mat-badge-above mat-badge-after mat-badge-medium']"));

            button.Click();

            // Check if element has a class

           string classes = button.GetAttribute("class");

            //Console.WriteLine(classes);

            Assert.That(classes, Does.Contain(badgeCss), "Test 2 OK");

            Console.ReadLine();

            driver.Close();
        }

        [Test]
        public static void test3_bottomSheet()
        {
            IWebDriver driver = new ChromeDriver();

            //Navigate to metrial design page
            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            //Maximize the window
            driver.Manage().Window.Maximize();

            //Navigate to Autocomplete page

            driver.FindElement(By.XPath("//div[text() = 'Bottom Sheet']")).Click();

            //Wait the page to load

            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.XPath("//button[@class='mat-focus-indicator mat-raised-button mat-button-base']")).Click();

            

            bool IsElementPresent()
            {
                try
                {
                    driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[2]/div[1]/mat-bottom-sheet-container[1]"));
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            Assert.IsTrue(IsElementPresent());

            //Console.ReadLine();

            driver.Close();
        }

        [Test]
        public static void test4_Button()
        {
            string expTitle = "Google";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Button']")).Click();

            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.XPath("//a[@class='mat-focus-indicator mat-raised-button mat-button-base']")).Click();

            var browserTabs = driver.WindowHandles;

            Console.WriteLine(browserTabs);
            Console.WriteLine(browserTabs[0]);
            Console.WriteLine(browserTabs[1]);

            driver.SwitchTo().Window(browserTabs[1]);
  

            string pageTitle = driver.Title;

            Assert.That(expTitle, Is.EqualTo(pageTitle));

            driver.Quit();
        }

        [Test]

        public static void test5_ButtonToggle()
        {
            //Not working cannot find how to check if button is toggled
            
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Button toggle']")).Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement boldButton = driver.FindElement(By.XPath("//mat-button-toggle [@value = 'bold']"));


            //Testing bold button

            //Get arria-pressed

            string pressedValue = boldButton.GetAttribute("aria-pressed");

            Console.WriteLine("pressedValue: " + pressedValue);

            Console.ReadLine();

            //Assert.That('false', 'true');

            boldButton.Click();

            System.Threading.Thread.Sleep(1000);

            pressedValue = boldButton.GetAttribute("aria-pressed");

            Console.WriteLine("pressedValue: " + pressedValue);

            Console.ReadLine();

            driver.Close();

        }

        [Test]
        public static void test6_Checkbox()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Checkbox']")).Click();

            System.Threading.Thread.Sleep(1000);

        }

    }
}


