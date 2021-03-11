using System;
using System.Collections.Generic;
using System.Text;
using EPPlusTest;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;

namespace NewPostgresApp
{
   public class ExcelGenerator
    {
        public byte[] Generate(BlogReport report)
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Blog Report");

            sheet.Cells[2, 2, 2, 3].LoadFromArrays(new object[][] { new[] { "Name", "Post" } });
            
            var row = 3;
            var column = 2;

            sheet.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            sheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            for (int i = 0; i<report.Writer.Count; i++)
            {
                sheet.Cells[row, column].Value = report.Writer[i].Name;

                for (int j = 0; j < report.Writer[i].Posted.Count; j++)
                {
                    sheet.Cells[row, column + 1].Value = report.Writer[i].Posted[j].Name;
                    row++;

                }

            }

            int x = 3;
            int y = 10;

            for (int k = 0; k < report.Post.Count/2; k++)
            {
                
                sheet.Cells[x, 2, y, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                sheet.Cells[x, 3, y, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                x++;
                y--;   
            }
            sheet.Cells[2, 2, 2, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[6, 2, 6, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[11, 2, 11, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            sheet.Cells[2, 2, 11, 3].Style.Border.BorderAround(ExcelBorderStyle.Double);
            sheet.Cells[2, 2, 2, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
            
            sheet.Column(3).Width = 12;
            
            return package.GetAsByteArray();
            
        }
    }
}
