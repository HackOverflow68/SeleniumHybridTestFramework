using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHybridTestFramework.Core;
using System.Collections;
using System.Data;

namespace SeleniumHybridTestFramework.Task_1
{
    class SignInTests
    {
        public SeleniumDriver driver;
        public Reports TestReport;

        [SetUp]
        public void Setup()
        {
            driver = new SeleniumDriver();
            driver.MaximizeBrowserWindow();
            TestReport = new Reports("SignIn");
        }

        [Test]
        public void SignInFailTest()
        {
            ArrayList test = ExcelDataAccess.GetExcelQueryData("SignInFail");

            foreach (KeywordData kd in test)
            {
                UIOperation.PerformStep(kd, driver, TestReport);
            }
        }

        [Test]
        public void SignUpPassTest()
        {
            ArrayList test = ExcelDataAccess.GetExcelQueryData("SignInPass");

            foreach (KeywordData kd in test)
            {
                UIOperation.PerformStep(kd, driver, TestReport);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
