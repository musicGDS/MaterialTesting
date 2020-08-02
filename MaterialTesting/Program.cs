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
            //test6_Checkbox();
            //test7_Chips();
            //test8_Datepicker();
            //test9_Dialog();
            //test10_ExpansionPanel();
            test12_Paginator();
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
            //NOT FINISHED!!!!
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Checkbox']")).Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement checkbox = driver.FindElement(By.XPath("//mat-checkbox[@id='mat-checkbox-1']//label[@class='mat-checkbox-layout']"));

            checkbox.Click();

            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.XPath("//mat-checkbox[@class='mat-checkbox example-margin mat-accent mat-checkbox-checked']")).Click();

            int isChecked = driver.FindElements(By.XPath("//mat-checkbox[@class='mat-checkbox example-margin mat-accent mat-checkbox-checked']")).Count;

            Console.WriteLine(isChecked);

            //Assert.IsTrue(checkbox.GetAttribute(""));
            Console.ReadLine();
        }

        [Test]

        public static void test7_Chips()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Chips']")).Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement inputField = driver.FindElement(By.XPath("//mat-chip-list//input[@placeholder='New fruit...']"));

            IWebElement chipsList = driver.FindElement(By.XPath("//mat-chip-list//div[@class='mat-chip-list-wrapper']"));

            int chipsCountBefore = driver.FindElements(By.XPath("//chips-input-example[@class='ng-star-inserted']//mat-chip")).Count;

            Console.WriteLine(chipsCountBefore);

            inputField.SendKeys("Orange");

            inputField.SendKeys(Keys.Return);

            int chipsCountAfter = driver.FindElements(By.XPath("//chips-input-example[@class='ng-star-inserted']//mat-chip")).Count;

            driver.Close();

            Assert.True(chipsCountBefore < chipsCountAfter);

            //POSSIBLE TO DO MORE TESTS. F.ex check if chip is deleted

        }

        [Test]

        public static void test8_Datepicker()
        {
            string expectedResult = "1/4/2020";



            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Datepicker']")).Click();

            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.XPath("//html//body//material-docs-app//app-component-sidenav//mat-sidenav-container//mat-sidenav-content//div//div//main//app-component-viewer//div//div//component-overview//doc-viewer//div//div//example-viewer//div//div//datepicker-overview-example//mat-form-field//div//div//div//mat-datepicker-toggle//button")).Click();

            driver.FindElement(By.XPath("//body//mat-datepicker-content//button[1]")).Click();

            driver.FindElement(By.XPath("//div[contains(text(),'2020')]")).Click();

            driver.FindElement(By.XPath("//div[contains(text(),'JAN')]")).Click();

            driver.FindElement(By.XPath("//tr[1]//td[5]//div[1]")).Click();

            string resultDate = driver.FindElement(By.XPath("//html//body//material-docs-app//app-component-sidenav//mat-sidenav-container//mat-sidenav-content//div//div//main//app-component-viewer//div//div//component-overview//doc-viewer//div//div//example-viewer//div//div//datepicker-overview-example//mat-form-field//div//div//div//input")).GetAttribute("value");

            driver.Close();

            Assert.AreEqual(expectedResult, resultDate);
        }

        [Test]

        public static void test9_Dialog()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Dialog']")).Click();

            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.XPath("//button[@class='mat-focus-indicator mat-raised-button mat-button-base']")).Click();

            IWebElement textInput = driver.FindElement(By.XPath("//html//body//div//div//div//mat-dialog-container//dialog-overview-example-dialog//div//mat-form-field//div//div//div//input"));

            textInput.SendKeys("pig");

            textInput.SendKeys(Keys.Return);

            driver.FindElement(By.XPath("//button[2]")).Click();

            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.XPath("//i[contains(text(),'pig')]"));

            bool pigPresent = driver.FindElements(By.XPath("//i[contains(text(),'pig')]")).Count != 0;

            Assert.IsTrue(pigPresent);

            driver.Close();
        }

        [Test]

        public static void test10_ExpansionPanel()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Expansion Panel']")).Click();

            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.XPath("//mat-expansion-panel[1]//mat-expansion-panel-header[1]")).Click();

            bool panelPresent = driver.FindElements(By.XPath("//div[@class='docs-example-viewer-body ng-star-inserted']")).Count != 0;

            Assert.IsTrue(panelPresent);
        }

        //public static void test11_formField()
        //{
        //    IWebDriver driver = new ChromeDriver();

        //    driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

        //    driver.FindElement(By.XPath("//div[text() = 'Form Field']")).Click();

        //    System.Threading.Thread.Sleep(5000);
        //}

        [Test]

        public static void test12_Paginator()
        {
            string expectedValue = "1 – 25 of 100";

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://material.angular.io/components/categories");

            driver.FindElement(By.XPath("//div[text() = 'Paginator']")).Click();

            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.XPath("//html//body//material-docs-app//app-component-sidenav//mat-sidenav-container//mat-sidenav-content//div//div//main//app-component-viewer//div//div//component-overview//doc-viewer//div//div//example-viewer//div//div//paginator-overview-example//mat-paginator//div//div//div//mat-form-field//div//div//div//mat-select//div//div//span//span")).Click();

            driver.FindElement(By.XPath("//mat-option[3]//span[1]")).Click();

            string actualValue = driver.FindElement(By.XPath("//div[@class='mat-paginator-range-label']")).Text;


            driver.Close();

            Assert.AreEqual(expectedValue, actualValue);  

        }

    }
}


