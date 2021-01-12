using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHybridTestFramework.Core;
using System.Collections;
using System.Data;

namespace SeleniumHybridTestFramework.Task_1
{
    class PopularTagTests
    {
        public SeleniumDriver driver;
        public Reports TestReport;

        [SetUp]
        public void Setup()
        {
            driver = new SeleniumDriver();
            driver.MaximizeBrowserWindow();
            TestReport = new Reports("PopularTags");
        }

        [Test]
        public void PopularTagsTest()
        {
            ArrayList test = ExcelDataAccess.GetExcelQueryData("PopularTags");

            foreach (KeywordData kd in test)
            {
                UIOperation.PerformStep(kd, driver,TestReport);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
