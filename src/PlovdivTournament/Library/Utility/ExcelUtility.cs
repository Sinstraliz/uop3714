using OfficeOpenXml;
using System.IO;

namespace PlovdivTournament.Web.Library.Utility
{
    public class ExcelUtility
    {
        public void ExportToExcel(string path)
        {
            FileInfo newFile = new FileInfo(path);

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets.Add("Content");
        }
    }
}