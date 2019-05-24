using System;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;


namespace MercedesAutomation
{

    public class MercedesAtuomation
    {
        private IWebDriver driver;

        [Test]
        public void MercedesShopping()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                Actions clicker = new Actions(driver);

                //1. Open website
                driver.Navigate().GoToUrl("https://shop.mercedes-benz.com/en-gb/collection/");

                //Wait for Cookies information to be displayed and Close it.
                this.WaitAndVerifyIFElementIsAvailable(By.XPath("//*[@id='cp-inner']/div/div"));
                IWebElement clickableTwitter = driver.FindElement(By.Id("button-text"));
                clicker.Click(clickableTwitter).Build().Perform();

                //Is this the Correct URL
                Assert.IsTrue(driver.Url.Contains("shop.mercedes-benz.com"));

                //Is Mercedes Logo Displayed?
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/header-grid/div/div/div[2]/div[1]/header-logo/header/div/img")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/header-grid/div/div/div[2]/div[1]/header-logo/header/div/img"))
                    .GetAttribute("alt").Contains("Mercedes-Benz"));

                //Is Chart logo displayed?
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/header-grid/div/div/div[2]/div[2]/div/co-header-cart/div/div[1]/a")).Displayed);

                //Is Mercedes Mini Car Displeyd?
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[2]/utils-product-cms-carousel/div/div/div[2]/ui-helper-slick/div/div/div[2]/div/div[1]/div[1]/a")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[2]/utils-product-cms-carousel/div/div/div[2]/ui-helper-slick/div/div/div[2]/div/h3")).
                    Text.Contains("Mercedes-AMG GT S, Coupé"));

                Actions clicker2 = new Actions(driver);
                clicker2.Click(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[2]/utils-product-cms-carousel/div/div/div[2]/ui-helper-slick/div/div/div[2]/div/div[1]/div[1]/a"))).Build().Perform();

                this.WaitAndVerifyIFElementIsAvailable(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[1]/div/pdp-grid/div[1]/div[2]/div[1]/pdp-shortdescription/div/div[1]/div/h2"));

                //Redirected to Mini Car Detail Page?
                Assert.IsTrue(driver.Url.Contains("shop.mercedes-benz.com/en-gb/collection/pdp/Mercedes-AMG-GT-S--Coupe"));

                //Contains Car Details?
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[1]/div/pdp-grid/div[1]/div[2]/div[1]/pdp-shortdescription/div/div[1]/div/h2")).Displayed
                    && driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[1]/div/pdp-grid/div[1]/div[2]/div[1]/pdp-shortdescription/div/div[1]/div/h2")).Text.Contains("Mercedes-AMG GT S, Coupé"));

                //Add to Basket Button Enabled?
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[1]/div/pdp-grid/div[1]/div[2]/utils-sticky-bar/ng-transclude/div/div/pdp-buy-box-add-to-basket/div/div/div/div[2]/button[2]")).Displayed);

                Actions clicker3 = new Actions(driver);
                clicker3.Click(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div/div[1]/div/pdp-grid/div[1]/div[2]/utils-sticky-bar/ng-transclude/div/div/pdp-buy-box-add-to-basket/div/div/div/div[2]/button[2]"))).Build().Perform();

                this.WaitAndVerifyIFElementIsAvailable(By.XPath("/html/body/div[8]/div/div/div/div[2]"));

                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[8]/div/div/div/div[2]/div[2]/div/div[1]/co-orderline/div/div/div/div/div[2]/div/ng-include/div/div[1]/a/ng-include/span")).Displayed
                    && driver.FindElement(By.XPath("/html/body/div[8]/div/div/div/div[2]/div[2]/div/div[1]/co-orderline/div/div/div/div/div[2]/div/ng-include/div/div[1]/a/ng-include/span")).Text.Contains("Mercedes-AMG GT S, Coupé"));

                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[8]/div/div/div/div[2]/div[2]/div/div[2]/button[1]")).Displayed
                    && driver.FindElement(By.XPath("/html/body/div[8]/div/div/div/div[2]/div[2]/div/div[2]/button[1]")).Text.Contains("Go to shopping basket"));

                //Click on go to shopping basket 
                Actions clicker4 = new Actions(driver);
                clicker4.Click(driver.FindElement(By.XPath("/html/body/div[8]/div/div/div/div[2]/div[2]/div/div[2]/button[1]"))).Build().Perform();

                //Is Cart Page enable?
                this.WaitAndVerifyIFElementIsAvailable(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[1]/div/div/form/co-stepnavigation/div/ul"));

                Assert.IsTrue(driver.Url.Contains("shop.mercedes-benz.com/en-gb/collection/cart"));

                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/div/co-grid/div/div/div/form/div/div[2]/co-orderline/div/div/div/div[1]/div[1]/div[2]/div/ng-include/div/div[1]/a/ng-include/span")).Displayed
                    && driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/div/co-grid/div/div/div/form/div/div[2]/co-orderline/div/div/div/div[1]/div[1]/div[2]/div/ng-include/div/div[1]/a/ng-include/span")).Text.Contains("Mercedes-AMG GT S, Coupé"));

                Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Shopping basket']")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Address and delivery']")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Verification and order placement']")).Displayed);

                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[3]/div/co-func-header/div/div[2]/button")).Displayed
                    && driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[3]/div/co-func-header/div/div[2]/button")).Text.Contains("Continue to address and delivery"));

                //Click on Button Continue to address and delivery
                Actions clicker5 = new Actions(driver);
                clicker5.Click(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[3]/div/co-func-header/div/div[2]/button"))).Build().Perform();

                this.WaitAndVerifyIFElementIsAvailable(By.Id("dcp-login-guest-user-email"));
                Assert.IsTrue(driver.Url.Contains("collection/tunnel"));
                Assert.IsTrue(driver.FindElement(By.XPath("//button[@class='wb-e-btn-2 dcp-order-process-login-panel__cta ng-binding wb-e-btn-2--disabled']")).Displayed);

                //Insert Email for guest shopping
                IWebElement comboBox = driver.FindElement(By.Id("dcp-login-guest-user-email"));
                string[] array = { "teste1234@gmail.com" };
                this.InsertKeys(comboBox, array, 1000, false);
                Thread.Sleep(1000);

                //Is Button Enable?
                Assert.IsFalse(this.isElementPresent(By.XPath("//button[@class='wb-e-btn-2 dcp-order-process-login-panel__cta ng-binding wb-e-btn-2--disabled']")));

                Actions clicker6 = new Actions(driver);
                clicker6.Click(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/co-grid-tunnel/div/div/co-order-process-login/div/div/div[3]/ng-include/div/form/button"))).Build().Perform();

                this.WaitAndVerifyIFElementIsAvailable(By.Id("co_payment_address-salutationCode-radio-id-0"));
                Assert.IsTrue(driver.Url.Contains("collection/shipping"));

                //Fill The Form
                Actions clicker7 = new Actions(driver);
                clicker7.Click(driver.FindElement(By.Id("co_payment_address-salutationCode-radio-id-0"))).Build().Perform();

                IWebElement name = driver.FindElement(By.Id("co_payment_address-firstName"));
                string[] arrayName = { "Mercedes" };
                this.InsertKeys(name, arrayName, 1000, false);
                Thread.Sleep(1000);

                IWebElement lastname = driver.FindElement(By.Id("co_payment_address-lastName"));
                string[] arraylastname = { "Automation" };
                this.InsertKeys(lastname, arraylastname, 1000, false);
                Thread.Sleep(1000);

                IWebElement number = driver.FindElement(By.Id("co_payment_address-line2"));
                string[] arraynumber = { "123" };
                this.InsertKeys(number, arraynumber, 1000, false);
                Thread.Sleep(1000);

                IWebElement street = driver.FindElement(By.Id("co_payment_address-line1"));
                string[] arraystreet = { "Lisbon Street" };
                this.InsertKeys(street, arraystreet, 1000, false);
                Thread.Sleep(1000);

                IWebElement town = driver.FindElement(By.Id("co_payment_address-town"));
                string[] arraytown = { "Lisbon" };
                this.InsertKeys(town, arraytown, 1000, false);
                Thread.Sleep(1000);

                IWebElement postCode = driver.FindElement(By.Id("co_payment_address-postalCode"));
                string[] arrayPostCode = { "SP2 0FL" };
                this.InsertKeys(postCode, arrayPostCode, 1000, false);
                Thread.Sleep(1000);
               
                //Click on Next Button
                Actions clicker8 = new Actions(driver);
                clicker8.Click(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[6]/div/co-func-footer/div/div/div/div[1]/button"))).Build().Perform();

                //Redirected to the Payment Page
                this.WaitAndVerifyIFElementIsAvailable(By.Id("dcp-co-payment-modes_options-paypal"));
                Assert.IsTrue(driver.Url.Contains("collection/payment"));

                //Choose option Paypal
                Actions clicker9 = new Actions(driver);
                clicker9.Click(driver.FindElement(By.Id("dcp-co-payment-modes_options-paypal"))).Build().Perform();

                Actions clicker10 = new Actions(driver);
                clicker10.Click(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[6]/div/co-func-footer/div/div/div/div[1]/button"))).Build().Perform();

                //Summary Page
                this.WaitAndVerifyIFElementIsAvailable(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/div[3]/div"));
                Assert.IsTrue(driver.Url.Contains("collection/summary"));

                //Client Info Displayed?
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("Mr"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("Mercedes"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("Automation"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("SP2 0FL"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("teste1234@gmail.com"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("Lisbon Street"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("Lisbon"));
                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order-data/div/div/div[2]/div[1]/div[1]")).Text.Contains("123"));

                Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[4]/co-grid-summary/div/div/div/co-order/div/div/co-delivery/div/div[2]/co-orderline/div/div/div/div[1]/div[1]/div[2]/div/ng-include/div/div[1]/a/ng-include/span"))
                    .Text.Contains("Mercedes-AMG GT S, Coupé"));
            }
            catch (Exception ex)
            {
                Assert.IsNull(this.ProcessErrorMessage(ex));
            }
        }
        #region HelperMethods

        [Description ("Catches Exception and show information about exception Error")]
        private String ProcessErrorMessage(Exception ex)
        {
            if (ex == null)
                return null;

            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(ex, true);

            if (st.FrameCount <= 0)
                return null;

            System.Diagnostics.StackFrame sf = st.GetFrame(st.FrameCount - 1);
            String ErrorCause = ex.Message;
            if (ex.Message.IndexOf('\n') > 0)
            {
                ErrorCause = ex.Message.Substring(0, ex.Message.IndexOf('\n'));
            }

            String ExceptionType = ex.GetType().ToString();
            String LineNumber = sf.GetFileLineNumber().ToString();
            String TestMethod = sf.GetMethod().Name;

            String ErrorMessage = ("Exception=" + ExceptionType + " Cause=" + ErrorCause + " Line Number=" + LineNumber + " Test Method=" + TestMethod + "");
            System.Console.WriteLine("ErrorMessage:");
            System.Console.WriteLine(ErrorMessage);
            System.Console.WriteLine("StackTrace:");
            System.Console.WriteLine(st.ToString());

            return ErrorMessage;
        }

        [Description ("Waits 2 minutes for an element on the Page")]
        private void WaitAndVerifyIFElementIsAvailable(By locator, int TimeOutInSeconds = 120)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(TimeOutInSeconds))).Until(ExpectedConditions.ElementExists(locator));
        }

        [Description ("Insertes Characters into an element(for exemple Text box")]
        public void InsertKeys(IWebElement element, String[] array, int intervalMilis, bool enterOnEnd = false)
        {
            foreach (string i in array)
            {
                element.SendKeys(i);
                Thread.Sleep(intervalMilis);
            }
            if (enterOnEnd)
            {
                element.SendKeys(Keys.Return);
                Thread.Sleep(intervalMilis);
            }
        }

        [Description ("Checks if an element is present")]
        public bool isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        #endregion

        [Description ("Closes the driver and the window")]
        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
