using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RZHD.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Controllers
{
    [Route("api/summary")]
    public class SummaryController : MainController
    {
        private readonly DatabaseContext context;

        public SummaryController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            IWorkbook workbook = new XSSFWorkbook();
            var summaryTableSheet = workbook.CreateSheet("Сводка");
            int rowNum = 0;

            var titleRow = summaryTableSheet.CreateRow(rowNum++);

            int columnNum = 0;
            titleRow.CreateCell(columnNum++).SetCellValue("Цена");
            titleRow.CreateCell(columnNum++).SetCellValue("Название продукта");
            titleRow.CreateCell(columnNum++).SetCellValue("Название ресторана");
            titleRow.CreateCell(columnNum++).SetCellValue("Номер билета");
            titleRow.CreateCell(columnNum++).SetCellValue("Номер вагона в билете");
            titleRow.CreateCell(columnNum++).SetCellValue("");
            titleRow.CreateCell(columnNum++).SetCellValue("Назване станций");


            foreach (var prod in context.Products)
            {
                var colNum = 0;
                var row = summaryTableSheet.CreateRow(rowNum++);
                row.CreateCell(colNum++).SetCellValue(prod.Price);
                row.CreateCell(colNum++).SetCellValue(prod.Name);
                foreach (var rest in context.Restaurants)
                {
                    row.CreateCell(colNum++).SetCellValue(rest.Name);
                    //row.CreateCell(colNum++).SetCellValue();
                }
                foreach (var tick in context.Tickets)
                {
                    row.CreateCell(colNum++).SetCellValue(tick.Number);
                    row.CreateCell(colNum++).SetCellValue(tick.WagonNumber);
                }
                row.CreateCell(colNum++).SetCellValue("");

                foreach (var station in context.Stations)
                {
                    row.CreateCell(colNum++).SetCellValue(station.Name);
                }
            }

            var fileName = Path.GetTempFileName();
            using (var writeStream = System.IO.File.OpenWrite(fileName))
            {
                workbook.Write(writeStream);
            }
            var memoryStream = new MemoryStream();
            using (var readStream = System.IO.File.OpenRead(fileName))
            {
                await readStream.CopyToAsync(memoryStream);
            }

            memoryStream.Position = 0;

            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "summary.xlsx");
        }
    }
}
