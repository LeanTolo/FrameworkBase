﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;
using System.Security.AccessControl;
using System.Collections;
using System.Runtime.ExceptionServices;

namespace AutomationFramework.Helpers
{

    public class HtmlTableHelper
    {
        private static List<TableDataCollection> _tableDataCollections;

        public static void readTable(IWebElement table) //read Table allow us to read an html table and then perform actios in case we need
        {
            //init Table
            _tableDataCollections = new List<TableDataCollection>();

            //get all columns
            var columns = table.FindElements(By.TagName("th"));

            //get all rows
            var rows = table.FindElements(By.TagName("tr"));

            //create row index
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));
                //store data only if it has value in row
                if (colDatas.Count != 0)
                {
                    foreach (var colValue in colDatas)
                    {
                        _tableDataCollections.Add(new TableDataCollection
                        {
                            rowNumber = rowIndex,
                            columnName = columns[colIndex].Text != "" ?
                                         columns[colIndex].Text : colIndex.ToString(),
                            columnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });

                        //Move to next column
                        colIndex++;
                    }
                    rowIndex++;
                }

            }
        }

        private static ColumnSpecialValue GetControl(IWebElement columnValue) //gets colum special values like inputs or hyperlinks
        {
            ColumnSpecialValue columnSpecialValue = null;
            //Check if the control has specific tags like input / hyperlink etc

            if (columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperLink"
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }

            return columnSpecialValue;
        }

        //perform operations on a special value into specific cell
        public static void PerformActionOnCell (string columnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDataCollections
                            where e.columnName == columnIndex && e.rowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                //need to operate on those controls
                if (controlToOperate != null && cell != null)
                {

                    //Since based on the control type, the retriving of text changes
                    //created this kind of control
                    if(cell.ControlType == "hyperLink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.Text == controlToOperate
                                               select c).SingleOrDefault();
                        //Currently only click is suported
                        returnedControl?.Click();
                    }

                    if (cell.ControlType == "input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.GetAttribute("value") == controlToOperate
                                               select c).SingleOrDefault();
                        returnedControl?.Click();
                    }
                }
            }
        } 



        private static IEnumerable GetDynamicRowNumber (string columnName, string columnValue)
        {
            //dynamic row
            foreach (var table in _tableDataCollections)
            {
                if (table.columnName == columnName && table.columnValue == columnValue)
                {
                    yield return table.rowNumber;
                }
            }
        }

    }

    public class TableDataCollection
    {
        public int rowNumber { get; set; }
        public string columnName { get; set; }
        public string columnValue { get; set; }
        //we gonna use the column special value if we have any colum with checkbox, drop down list / etc.
        public ColumnSpecialValue ColumnSpecialValues { get; set; }

    }

    public class ColumnSpecialValue
    {
        //Its a collection because they could have more than 1 IWebElement
        public IEnumerable<IWebElement> ElementCollection { get; set; }
        public string ControlType { get; set; }

    }
}
