using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHybridTestFramework.Core;
using System.Collections;
using System.Data;

namespace SeleniumHybridTestFramework.Task_1
{
    class NewPostsTests
    {
        public SeleniumDriver driver;
        public Reports TestReport;

        [SetUp]
        public void Setup()
        {
            driver = new SeleniumDriver();
            driver.MaximizeBrowserWindow();
            TestReport = new Reports("NewPost");
        }

        [Test]
        public void NewPostTest()
        {
            ArrayList test = ExcelDataAccess.GetExcelQueryData("NewPost");

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
