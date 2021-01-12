using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumHybridTestFramework.Core
{
    public class UIOperation
    {
        public static void performAction(KeywordData data, SeleniumDriver selenDriver)
        {
            switch(data.Keyword.ToUpper())
            {
                case "GOTOURL":
                        selenDriver.Navigate(data.Value);                                           
                    break;
                case "CLICK":
                    selenDriver.Click(data.Object, data.ObjectType);
                    break;
                case "SETTEXT":
                    selenDriver.SetText(data.Object, data.ObjectType, data.Value);
                    break;
                case "GETTEXT":
                    selenDriver.GetText(data.Object, data.ObjectType);
                    break;
                case "ASSERTELEMENTVISIBLE":
                    selenDriver.AssertElementIsVisible(data.Object, data.ObjectType);
                    break;
                case "ASSERTELEMENTNOTVISIBLE":
                    selenDriver.AssertElementNotVisible(data.Object, data.ObjectType);
                    break;
                case "ASSERTELEMENTTEXTCONTAINS":
                    selenDriver.AssertElementTextContains(data.Object, data.ObjectType, data.Value);
                    break;
                case "ASSERTELEMENTHASCLASS":
                    selenDriver.AssertElementHasClass(data.Object, data.ObjectType, data.Value);
                    break;
                case "REFRESH":
                    selenDriver.ClickRefresh();
                    break;
                case "WAIT":
                    selenDriver.ImplicitWait(int.Parse(data.Value));
                    break;
                default:
                    break;
            }
            selenDriver.ImplicitWait(10);
        }

        public static void PerformStep(KeywordData data, SeleniumDriver selenDriver, Reports report)
        {
            string desc = data.Keyword + " " + data.Object;

            try
            {
                performAction(data, selenDriver);                
                report.addLine(desc, "PASS", "");
            }
            catch (Exception ex)
            {
                report.addLine(desc, "Fail", ex.Message);
            }
        }
    }
}
