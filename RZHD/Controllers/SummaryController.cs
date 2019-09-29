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

            foreach (var prod in context.Products)
            {
                var colNum = 0;
                var row = summaryTableSheet.CreateRow(rowNum++);
                row.CreateCell(colNum++).SetCellValue(prod.Price);
                row.CreateCell(colNum++).SetCellValue(prod.Name);
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
