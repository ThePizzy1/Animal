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
using Fonts = DocumentFormat.OpenXml.Spreadsheet.Fonts;
using Fill = DocumentFormat.OpenXml.Spreadsheet.Fill;
using PatternFill = DocumentFormat.OpenXml.Spreadsheet.PatternFill;
using ForegroundColor = DocumentFormat.OpenXml.Spreadsheet.ForegroundColor;


/*
 *Ispis bankovnih podataka za 30 dana, 3mj, godinu
 *Ispis transakcija u zadnjih mj dana
 *NAPRAVI U FRONTENDU FUNDS I BALANS ISPIS OVOGA
 */
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
   
        [HttpGet("generateDva")]
        public async Task<IActionResult> TestDva()
        {
            try
            {
                var funds = _appDbContext.Funds
                    .Where(a => a.DateTimed >= DateTime.Now.AddDays(-30))
                    .ToList();

                MemoryStream memoryStream = new MemoryStream();
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    Worksheet worksheet = new Worksheet();
                    SheetData sheetData = new SheetData();

                    // Define columns
                    Columns columns = new Columns(
                        new Column() { Min = 1, Max = 1, Width = 10, CustomWidth = true },
                        new Column() { Min = 2, Max = 2, Width = 15, CustomWidth = true },
                        new Column() { Min = 3, Max = 3, Width = 40, CustomWidth = true },
                        new Column() { Min = 4, Max = 4, Width = 20, CustomWidth = true },
                        new Column() { Min = 5, Max = 5, Width = 25, CustomWidth = true }
                    );
                    worksheet.Append(columns);

                    // Styles
                    WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = GenerateStylesheet();
                    stylesPart.Stylesheet.Save();

                    // Header row
                    Row headerRow = new Row();
                    headerRow.Append(
                        CreateTextCell("Id", 2),
                        CreateTextCell("AdopterId", 2),
                        CreateTextCell("Purpose", 2),
                        CreateTextCell("Amount", 2),
                        CreateTextCell("Date", 2)
                    );
                    sheetData.Append(headerRow);

                    decimal total = 0;
                    foreach (var data in funds)
                    {
                        Row row = new Row();
                        row.Append(
                            CreateNumberCell(data.Id.ToString()),
                            CreateNumberCell(data.AdopterId.ToString() ?? "0"),
                            CreateTextCell(data.Purpose),
                            CreateCurrencyCell(data.Amount),
                            CreateDateCell(data.DateTimed)
                        );
                        sheetData.Append(row);
                        total += data.Amount;
                    }

                    // Total row
                    Row totalRow = new Row();
                    totalRow.Append(
                        new Cell(),
                        new Cell(),
                        CreateTextCell("In total:", 2),
                        CreateCurrencyCell(total),
                        new Cell()
                    );
                    sheetData.Append(totalRow);

                    worksheet.Append(sheetData);
                    worksheetPart.Worksheet = worksheet;

                    Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                    sheets.Append(new Sheet()
                    {
                        Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Funds"
                    });

                    workbookPart.Workbook.Save();
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "FundsReport.xlsx"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Excel generation failed: " + ex.Message);
            }
        }
        [HttpGet("generateThree")]
        public async Task<IActionResult> FundsThreeMonts()
        {
            try
            {
                var funds = _appDbContext.Funds
                    .Where(a => a.DateTimed >= DateTime.Now.AddMonths(-3))
                    .ToList();

                MemoryStream memoryStream = new MemoryStream();
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    Worksheet worksheet = new Worksheet();
                    SheetData sheetData = new SheetData();

                    // Define columns
                    Columns columns = new Columns(
                        new Column() { Min = 1, Max = 1, Width = 10, CustomWidth = true },
                        new Column() { Min = 2, Max = 2, Width = 15, CustomWidth = true },
                        new Column() { Min = 3, Max = 3, Width = 40, CustomWidth = true },
                        new Column() { Min = 4, Max = 4, Width = 20, CustomWidth = true },
                        new Column() { Min = 5, Max = 5, Width = 25, CustomWidth = true }
                    );
                    worksheet.Append(columns);

                    // Styles
                    WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = GenerateStylesheet();
                    stylesPart.Stylesheet.Save();

                    // Header row
                    Row headerRow = new Row();
                    headerRow.Append(
                        CreateTextCell("Id", 2),
                        CreateTextCell("AdopterId", 2),
                        CreateTextCell("Purpose", 2),
                        CreateTextCell("Amount", 2),
                        CreateTextCell("Date", 2)
                    );
                    sheetData.Append(headerRow);

                    decimal total = 0;
                    foreach (var data in funds)
                    {
                        Row row = new Row();
                        row.Append(
                            CreateNumberCell(data.Id.ToString()),
                            CreateNumberCell(data.AdopterId.ToString() ?? "0"),
                            CreateTextCell(data.Purpose),
                            CreateCurrencyCell(data.Amount),
                            CreateDateCell(data.DateTimed)
                        );
                        sheetData.Append(row);
                        total += data.Amount;
                    }

                    // Total row
                    Row totalRow = new Row();
                    totalRow.Append(
                        new Cell(),
                        new Cell(),
                        CreateTextCell("In total:", 2),
                        CreateCurrencyCell(total),
                        new Cell()
                    );
                    sheetData.Append(totalRow);

                    worksheet.Append(sheetData);
                    worksheetPart.Worksheet = worksheet;

                    Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                    sheets.Append(new Sheet()
                    {
                        Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Funds"
                    });

                    workbookPart.Workbook.Save();
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "FundsReport.xlsx"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Excel generation failed: " + ex.Message);
            }
        }

        [HttpGet("generateYear")]
        public async Task<IActionResult> FundsYear()
        {
            try
            {
                var funds = _appDbContext.Funds
                    .Where(a => a.DateTimed >= DateTime.Now.AddYears(-1))
                    .ToList();

                MemoryStream memoryStream = new MemoryStream();
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    Worksheet worksheet = new Worksheet();
                    SheetData sheetData = new SheetData();

                    // Define columns
                    Columns columns = new Columns(
                        new Column() { Min = 1, Max = 1, Width = 10, CustomWidth = true },
                        new Column() { Min = 2, Max = 2, Width = 15, CustomWidth = true },
                        new Column() { Min = 3, Max = 3, Width = 40, CustomWidth = true },
                        new Column() { Min = 4, Max = 4, Width = 20, CustomWidth = true },
                        new Column() { Min = 5, Max = 5, Width = 25, CustomWidth = true }
                    );
                    worksheet.Append(columns);

                    // Styles
                    WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = GenerateStylesheet();
                    stylesPart.Stylesheet.Save();

                    // Header row
                    Row headerRow = new Row();
                    headerRow.Append(
                        CreateTextCell("Id", 2),
                        CreateTextCell("AdopterId", 2),
                        CreateTextCell("Purpose", 2),
                        CreateTextCell("Amount", 2),
                        CreateTextCell("Date", 2)
                    );
                    sheetData.Append(headerRow);

                    decimal total = 0;
                    foreach (var data in funds)
                    {
                        Row row = new Row();
                        row.Append(
                            CreateNumberCell(data.Id.ToString()),
                            CreateNumberCell(data.AdopterId.ToString() ?? "0"),
                            CreateTextCell(data.Purpose),
                            CreateCurrencyCell(data.Amount),
                            CreateDateCell(data.DateTimed)
                        );
                        sheetData.Append(row);
                        total += data.Amount;
                    }

                    // Total row
                    Row totalRow = new Row();
                    totalRow.Append(
                        new Cell(),
                        new Cell(),
                        CreateTextCell("In total:", 2),
                        CreateCurrencyCell(total),
                        new Cell()
                    );
                    sheetData.Append(totalRow);

                    worksheet.Append(sheetData);
                    worksheetPart.Worksheet = worksheet;

                    Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                    sheets.Append(new Sheet()
                    {
                        Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Funds"
                    });

                    workbookPart.Workbook.Save();
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "FundsReport.xlsx"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Excel generation failed: " + ex.Message);
            }
        }


        [HttpGet("transactions-report")]
        public IActionResult GenerateTransactionsExcel()
        {
            try
            {
                var transactions = _appDbContext.Transactions
                    .Where(t => t.Date >= DateTime.Now.AddMonths(-1))
                    .ToList();

                decimal income = transactions.Where(t => t.Type.ToLower() == "uplata").Sum(t => t.Cost);
                decimal expenses = transactions.Where(t => t.Type.ToLower() == "isplata").Sum(t => t.Cost);
                decimal balance = income - expenses;

                MemoryStream memoryStream = new MemoryStream();
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    SheetData sheetData = new SheetData();

                    // Define columns
                    Columns columns = new Columns(
                        new Column() { Min = 1, Max = 1, Width = 10, CustomWidth = true },
                        new Column() { Min = 2, Max = 2, Width = 25, CustomWidth = true },
                        new Column() { Min = 3, Max = 3, Width = 25, CustomWidth = true },
                        new Column() { Min = 4, Max = 4, Width = 15, CustomWidth = true },
                        new Column() { Min = 5, Max = 5, Width = 20, CustomWidth = true },
                        new Column() { Min = 6, Max = 6, Width = 50, CustomWidth = true }
                    );
                    worksheetPart.Worksheet = new Worksheet();
                    worksheetPart.Worksheet.Append(columns);

                    // Add styles
                    WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = GenerateStylesheetWithRed();
                    stylesPart.Stylesheet.Save();

                    // Header
                    Row headerRow = new Row();
                    headerRow.Append(
                        CreateTextCell("Id", 1),
                        CreateTextCell("Iban", 1),
                        CreateTextCell("Shelter Iban", 1),
                        CreateTextCell("Type", 1),
                        CreateTextCell("Date", 1),
                        CreateTextCell("Purpose", 1),
                        CreateTextCell("Cost", 1)
                    );
                    sheetData.Append(headerRow);

                    foreach (var t in transactions)
                    {
                        Row row = new Row();
                        row.Append(
                            CreateNumberCell(t.Id.ToString()),
                            CreateTextCell(t.Iban),
                            CreateTextCell(t.IbanAnimalShelter),
                            CreateTextCell(t.Type),
                            CreateDateCell(t.Date),
                            CreateTextCell(t.Purpose),
                            CreateCurrencyCell(t.Cost)
                        );
                        sheetData.Append(row);
                    }

                    // Totals
                    Row summaryRow1 = new Row();
                    summaryRow1.Append(
                        new Cell(), new Cell(), new Cell(),
                        CreateTextCell("Total Earned:", 0),
                        new Cell(), new Cell(),
                        CreateCurrencyCell(income)
                    );
                    sheetData.Append(summaryRow1);

                    Row summaryRow2 = new Row();
                    summaryRow2.Append(
                        new Cell(), new Cell(), new Cell(),
                        CreateTextCell("Total Spent:", 0),
                        new Cell(), new Cell(),
                        CreateCurrencyCell(expenses)
                    );
                    sheetData.Append(summaryRow2);

                    Row balanceRow = new Row();
                    uint style = balance >= 0 ? 0u : 2u; // 2 = red style
                    balanceRow.Append(
                        new Cell(), new Cell(), new Cell(),
                        CreateTextCell("Balance:", style),
                        new Cell(), new Cell(),
                        CreateCurrencyCell(balance, style)
                    );
                    sheetData.Append(balanceRow);

                    worksheetPart.Worksheet.Append(sheetData);

                    Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                    sheets.Append(new Sheet()
                    {
                        Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Transactions"
                    });

                    workbookPart.Workbook.Save();
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "TransactionsReport.xlsx"
                };
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        private Stylesheet GenerateStylesheetWithRed()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(), // 0: Default
                    new Font(new Bold()), // 1: Bold
                    new Font(new Color() { Rgb = "FFFF0000" }, new Bold()) // 2: Red Bold
                ),
                new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(new PatternFill() { PatternType = PatternValues.Gray125 })
                ),
                new Borders(new Border()),
                new CellFormats(
                    new CellFormat(),                      // 0: default
                    new CellFormat() { FontId = 1 },       // 1: bold
                    new CellFormat() { FontId = 2 }        // 2: red
                )
            );
        }
        private Cell CreateCurrencyCell(decimal amount, uint styleIndex = 0)
        {
            return new Cell
            {
                CellValue = new CellValue(amount.ToString()),
                StyleIndex = styleIndex,
                DataType = CellValues.Number
            };
        }

        private Stylesheet GenerateStylesheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(), // Default
                    new Font(new Bold()) // Bold
                ),
                new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(new PatternFill(new ForegroundColor { Rgb = "FFD3D3D3" }) { PatternType = PatternValues.Solid }) // Header bg
                ),
                new Borders(new Border()), // Default border
                new CellFormats(
                    new CellFormat(), // default
                    new CellFormat { FontId = 1, FillId = 2, ApplyFont = true, ApplyFill = true }, // header
                    new CellFormat { NumberFormatId = 4, ApplyNumberFormat = true }, // currency
                    new CellFormat { NumberFormatId = 14, ApplyNumberFormat = true } // date
                )
            );
        }












        private Cell CreateTextCell(string text, uint styleIndex = 0)
        {
            return new Cell()
            {
                DataType = CellValues.String,
                CellValue = new CellValue(text),
                StyleIndex = styleIndex
            };
        }

        private Cell CreateNumberCell(string number)
        {
            return new Cell()
            {
                DataType = CellValues.Number,
                CellValue = new CellValue(number)
            };
        }

        private Cell CreateCurrencyCell(decimal amount)
        {
            return new Cell()
            {
                CellValue = new CellValue(amount.ToString()),
                StyleIndex = 2
            };
        }

        private Cell CreateDateCell(DateTime date)
        {
            return new Cell()
            {
                CellValue = new CellValue(date.ToOADate().ToString()),
                StyleIndex = 3,
                DataType = CellValues.Number
            };
        }

    }

}
