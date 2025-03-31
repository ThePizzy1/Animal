using ANIMAL.DAL.DataModel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Column = DocumentFormat.OpenXml.Spreadsheet.Column;
using Columns = DocumentFormat.OpenXml.Wordprocessing.Columns;
using Index = DocumentFormat.OpenXml.Drawing.Charts.Index;



namespace ANIMAL.WebApi.Controllers
{
    [Route("api/excel")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly AnimalRescueDbContext _appDbContext;
        public ExcelController(AnimalRescueDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        //uzmi tablicu funds i ispiši sve doancijeu excelu
        /*
         //bitno stavit na početak da sve radi
          MemoryStream memoryStream = new MemoryStream();
        SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook);
           WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
        workbookPart.Workbook = new Workbook();
          //spremanje
        worksheetPart.Worksheet.Save();
        spreadsheetDocument.Close();
        memoryStream.Seek(0, SeekOrigin.Begin);
        return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         */
        [HttpGet("generateDva")]
        public async Task<IActionResult> TestDva()
        {
            try
            {

                var funds = _appDbContext.Funds.ToList().Where(a => a.DateTimed >= DateTime.Now.AddDays(-30));
                MemoryStream memoryStream = new MemoryStream();
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // Postavljanje širina kolona
                    Columns columns = new Columns();
                    columns.Append(new Column() { Min = 2, Max = 2, Width = 20, CustomWidth = true });
                    columns.Append(new Column() { Min = 2, Max = 2, Width = 20, CustomWidth = true });
                    columns.Append(new Column() { Min = 3, Max = 5, Width = 80, CustomWidth = true });
                    columns.Append(new Column() { Min = 5, Max = 7, Width = 35, CustomWidth = true });
                    columns.Append(new Column() { Min = 7, Max = 9, Width = 50, CustomWidth = true });

                    worksheetPart.Worksheet.InsertAt(columns, 0);

                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Funds"
                    };
                    sheets.Append(sheet);

                    // Heder
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    Row headerRow = new Row();
                    headerRow.Append(
                        new Cell() { CellValue = new CellValue("Id"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("AdopterId"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Purpose"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Amount"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("DateTimed"), DataType = CellValues.String }
                    );

                    sheetData.Append(headerRow);
                    decimal a = 0;
                    // Ispis podataka
                    foreach (Funds data in funds)
                    {
                        Row row = new Row();
                        row.Append(
                            new Cell() { CellValue = new CellValue(data.Id.ToString()), DataType = CellValues.Number },
                            new Cell() { CellValue = new CellValue(data.AdopterId.ToString()), DataType = CellValues.Number },
                            new Cell() { CellValue = new CellValue(data.Purpose), DataType = CellValues.String },
                            new Cell() { CellValue = new CellValue(data.Amount.ToString() + " €"), DataType = CellValues.Number },
                            new Cell() { CellValue = new CellValue(data.DateTimed.ToString()), DataType = CellValues.String }
                        );
                        sheetData.Append(row);
                        a += data.Amount;
                    }
                    Row rowl = new Row();
                    rowl.Append(
                        new Cell() { CellValue = new CellValue() },
                        new Cell() { CellValue = new CellValue() },
                        new Cell() { CellValue = new CellValue("In total:"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue(a.ToString() + " €"), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue() }
                    );
                    sheetData.Append(rowl);
                    workbookPart.Workbook.Save();
                }
               
                memoryStream.Seek(0, SeekOrigin.Begin); // Pobrinimo se da je pozicija na početku stream-a
                return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            catch (Exception ex) { throw new Exception(" " + ex.Message); }




        }





        
    }




}    
