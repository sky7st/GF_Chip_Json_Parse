using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GF_Chip_Json_Parse_excel
{
    class ExcelReader
    {
        protected Excel.Application xlApp;
        private Excel.Workbooks xlWorkbooks;
        private Excel.Workbook xlWorkbook;
        private Excel.Sheets xlWorksheets;
        private Excel.Worksheet xlWorksheet;
        public ExcelReader() {
            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkbooks = xlApp.Workbooks;
        }
        public bool openExcelFile(string path)
        {
            try
            {
                xlWorkbook = xlWorkbooks.Open(path);
                //xlWorkbook = xlWorkbooks.Add(path);
            }
            catch
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.FinalReleaseComObject(xlWorkbook);
                Marshal.FinalReleaseComObject(xlWorkbooks);

                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);

                return false;
            }
            try
            {
                xlWorksheets = xlWorkbook.Worksheets;
                xlWorksheet = xlWorkbook.Sheets["芯片总表"];
                return true;
            }
            catch 
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.FinalReleaseComObject(xlWorksheet);
                Marshal.FinalReleaseComObject(xlWorksheets);
                xlWorkbook.Close(false);
                
                Marshal.FinalReleaseComObject(xlWorkbook);
                Marshal.FinalReleaseComObject(xlWorkbooks);
                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                return false;
            }        
        }   
        public void writeRow(string[] val, int rowCnt = 1)
        {
            try
            {
                xlWorksheet.Cells[rowCnt + 3, 1].value = rowCnt;
                for (int i = 0; i <= 5; i++)
                {
                    xlWorksheet.Cells[rowCnt + 3, i + 2].value = val[i];
                }
            }
            catch
            {
            }   
        }
        public void clearRangeRow(int startIndex=1, int endIndex = 300)
        {
            Excel.Range rng = xlWorksheet.Range[xlWorksheet.Cells[startIndex+3, 1], xlWorksheet.Cells[endIndex+3, 7]];
            rng.Clear();
            Marshal.ReleaseComObject(rng);
        }
        public void exitAll(bool save= true)
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.FinalReleaseComObject(xlWorksheet);
                Marshal.FinalReleaseComObject(xlWorksheets);
                if(save)
                    xlWorkbook.Save();
                xlWorkbook.Close(save, true, true);
                xlWorkbooks.Close();

                Marshal.FinalReleaseComObject(xlWorkbook);
                Marshal.FinalReleaseComObject(xlWorkbooks);
                xlApp.Quit();

                Marshal.FinalReleaseComObject(xlApp);
            }
            catch
            {
                
            }
        }

    }
}

