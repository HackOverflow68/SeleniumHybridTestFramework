using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHybridTestFramework.Core
{
    public class Reports
    {
        private DateTime date;
        private FileStream fs;
        private StringBuilder reportcsv;
        private string filePath;
        private string fileName;
        private string testcase;
        public Reports(string testcase)
        {
            this.testcase = testcase;
            date = DateTime.Now;
            fileName = String.Format("Test Case Report ({0})",testcase) + date.Date.Date.ToShortDateString() + date.TimeOfDay.Hours.ToString() + date.TimeOfDay.Minutes.ToString();
            reportcsv = new StringBuilder();
            filePath = @"C:\Users\Christopher\source\repos\SeleniumHybridTestFramework\SeleniumHybridTestFramework\Reports\" + fileName + ".csv";
            createFile();
        }
        private void createFile()
        {
            reportcsv.Append("StepDescription,");
            reportcsv.Append("Pass/Fail,");
            reportcsv.Append("Exception");
            File.WriteAllText(filePath, reportcsv.ToString());
        }
        public void addLine(string description, string result, string message)
        {
            reportcsv.Append(Environment.NewLine);
            reportcsv.Append(description + ",");
            reportcsv.Append(result + ",");
            reportcsv.Append(message + ",");
            reportcsv.Append(Environment.NewLine);
            File.AppendAllText(filePath, reportcsv.ToString());
        }
    }
}
