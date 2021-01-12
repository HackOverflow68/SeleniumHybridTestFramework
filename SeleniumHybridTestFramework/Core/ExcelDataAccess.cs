using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace SeleniumHybridTestFramework.Core
{
    class ExcelDataAccess
    {
        public static ArrayList GetExcelQueryData(string testCase)
        {
            //create datatable object
            DataTable dt = new DataTable();

            var fileName = @"C:\Users\Christopher\source\repos\SeleniumHybridTestFramework\SeleniumHybridTestFramework\Data\TestData.xlsx";

            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(fileName))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable if the testcase id matches
                        IXLCell TestCaseIDCell = row.Cell("1");
                        if(TestCaseIDCell.Value.ToString() == testCase)
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }
                    }
                }
            }

            ArrayList keywordDataList = new ArrayList();                        

            foreach(DataRow row in dt.Rows)
            {
                KeywordData kd = new KeywordData();
                kd.TestCaseID = row["TestCaseID"].ToString();
                kd.Keyword = row["Keyword"].ToString();
                kd.Object = row["Object"].ToString();
                kd.ObjectType = row["ObjectType"].ToString();
                kd.Value = row["Value"].ToString();

                keywordDataList.Add(kd);
            }

            return keywordDataList;
        }
    }
}
