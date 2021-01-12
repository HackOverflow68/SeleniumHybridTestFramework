using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumHybridTestFramework.Core
{
    public class SeleniumDriver
    {
        public IWebDriver driver { get; set; }

        public SeleniumDriver()
        {
            driver = new ChromeDriver();
        }        

        public void MaximizeBrowserWindow()
        {
            driver.Manage().Window.Maximize();
        }
        public void Navigate(string URLToNavigate)
        {
            driver.Navigate().GoToUrl(URLToNavigate);
        }
        public void Click(string selector, string selectortype)
        {
            switch(selectortype.ToUpper())
            {
                case "XPATH":
                    driver.FindElement(By.XPath(selector)).Click();
                    break;
                case "CSS":
                    driver.FindElement(By.CssSelector(selector)).Click();
                    break;
                case "ID":
                    driver.FindElement(By.Id(selector)).Click();
                    break;
                case "NAME":
                    driver.FindElement(By.Name(selector)).Click();
                    break;
                case "LINKTEXT":
                    driver.FindElement(By.LinkText(selector)).Click();
                    break;
                case "TAGNAME":
                    driver.FindElement(By.TagName(selector)).Click();
                    break;
                default:
                    break;
            }
        }
        public void SetText(string selector, string selectortype, string value)
        {
            switch (selectortype.ToUpper())
            {
                case "XPATH":
                    driver.FindElement(By.XPath(selector)).SendKeys(value);
                    break;
                case "CSS":
                    driver.FindElement(By.CssSelector(selector)).SendKeys(value);
                    break;
                case "ID":
                    driver.FindElement(By.Id(selector)).SendKeys(value);
                    break;
                case "NAME":
                    driver.FindElement(By.Name(selector)).SendKeys(value);
                    break;
                case "LINKTEXT":
                    driver.FindElement(By.LinkText(selector)).SendKeys(value);
                    break;
                case "TAGNAME":
                    driver.FindElement(By.TagName(selector)).SendKeys(value);
                    break;
                default:
                    break;
            }
        }
        public string GetText(string selector, string selectortype)
        {
            string result = "";

            switch (selectortype.ToUpper())
            {
                case "XPATH":
                    result = driver.FindElement(By.XPath(selector)).Text;
                    break;
                case "CSS":
                    result = driver.FindElement(By.CssSelector(selector)).Text;
                    break;
                case "ID":
                    result = driver.FindElement(By.Id(selector)).Text;
                    break;
                case "NAME":
                    result = driver.FindElement(By.Name(selector)).Text;
                    break;
                case "LINKTEXT":
                    result = driver.FindElement(By.LinkText(selector)).Text; ;
                    break;
                case "TAGNAME":
                    result = driver.FindElement(By.TagName(selector)).Text;
                    break;
                default:
                    break;
            }
            return result;
        }
        public bool isDisplayed(string selector, string selectortype)
        {
            bool result = false;

            switch (selectortype.ToUpper())
            {
                case "XPATH":
                    result = driver.FindElement(By.XPath(selector)).Displayed;
                    break;
                case "CSS":
                    result = driver.FindElement(By.CssSelector(selector)).Displayed;
                    break;
                case "ID":
                    result = driver.FindElement(By.Id(selector)).Displayed;
                    break;
                case "NAME":
                    result = driver.FindElement(By.Name(selector)).Displayed;
                    break;
                case "LINKTEXT":
                    result = driver.FindElement(By.LinkText(selector)).Displayed;
                    break;
                case "TAGNAME":
                    result = driver.FindElement(By.TagName(selector)).Displayed;
                    break;
                default:
                    break;
            }
            return result;
        }

        public bool elementHasClass(string selector, string selectortype, string value)
        {
            bool result = false;

            switch (selectortype.ToUpper())
            {
                case "XPATH":
                    result = driver.FindElement(By.XPath(selector)).GetAttribute("class").Contains(value);
                    break;
                case "CSS":
                    result = driver.FindElement(By.CssSelector(selector)).GetAttribute("class").Contains(value);
                    break;
                case "ID":
                    result = driver.FindElement(By.Id(selector)).GetAttribute("class").Contains(value);
                    break;
                case "NAME":
                    result = driver.FindElement(By.Name(selector)).GetAttribute("class").Contains(value);
                    break;
                case "LINKTEXT":
                    result = driver.FindElement(By.LinkText(selector)).GetAttribute("class").Contains(value);
                    break;
                case "TAGNAME":
                    result = driver.FindElement(By.TagName(selector)).GetAttribute("class").Contains(value);
                    break;
                default:
                    break;
            }
            return result;
        }
        public bool ElementTextContains(string selector, string selectortype, string value)
        {
            string actualText = GetText(selector, selectortype);
            bool result = actualText.Contains(value);
            return result;
        }
        public void AssertElementIsVisible(string selector, string selectortype)
        {
            bool result = isDisplayed(selector, selectortype);
            Assert.IsTrue(result);
        }
        public void AssertElementNotVisible(string selector, string selectortype)
        {
            bool result = !isDisplayed(selector, selectortype);
            Assert.IsFalse(result);
        }

        public void AssertElementHasClass(string selector, string selectortype, string value)
        {
            bool result = elementHasClass(selector, selectortype, value);
            Assert.IsTrue(result);
        }
        public void AssertElementTextContains(string selector, string selectortype, string value)
        {
            bool result = ElementTextContains(selector, selectortype, value);
            Assert.IsTrue(result);
        }
        public void ClickRefresh()
        {
            driver.Navigate().Refresh();
        }
        public void Quit()
        {
            driver.Quit();
        }
        public void ImplicitWait(int seconds)
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
    }
}
