using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Repository.Automaper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf.Filters;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;


namespace ANIMAL.WebApi.Controllers
{
    //Napravi tablicu koja će se ispisivati u obliku pdf
    //Nemoj imat previše parametara da to ne izgleda ružno
    //Prvo izradi tablicu, zatim shvati kak pdf dio
    //Napravi da imaš drugu funkciju u kojoj stvaraš tablicu i onda ju pozovi  u ovom glavnom dijelu prebaci u pdf
    //Kad napraviš osnovno probaj složit nekek da možeš birat koju tablicu ćeš izradit bila bi korisna na više mjesta
    
    [Route("api/pdf")]
    [ApiController]

    public class PdfController :    ControllerBase
    {
        private readonly AnimalRescueDbContext _appDbContext;
        public PdfController(AnimalRescueDbContext appDbContext)
        {
            _appDbContext = appDbContext;
           
        }
        /* 
         * za renderiranje pdf
    var pdfRenderer = new PdfDocumentRenderer();
    pdfRenderer.Document = document;
    pdfRenderer.RenderDocument();
    MemoryStream memoryStream = new MemoryStream();
    pdfRenderer.PdfDocument.Save(memoryStream, false);
    memoryStream.Seek(0, SeekOrigin.Begin);
                                        /govori koji tip dokumenta      /naziv stavi svoj        
    return File(memoryStream.ToArray(), "application/pdf", "Amandman_ID_" + IzradaAmandmana.AmandmanId + ".pdf");  */


        //Uspješno generir neku ružnu tablicu :)
        [HttpGet("generateTest")]      
        public async Task<IActionResult> RendererPdf()//Zove funkciju DefineTables() i pretvara u pdf
            {
            try
            {

                MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
                Paragraph paragraph = document.LastSection.AddParagraph("Ugly table", "Heading1");
                paragraph.AddBookmark("Test table");
                document.LastSection.AddParagraph("Simple Tables", "Heading2");
                Table table = new Table();
                table.Borders.Width = 0.5;
                Column column = table.AddColumn(Unit.FromCentimeter(2));
                column.Format.Alignment = ParagraphAlignment.Center;
                table.AddColumn(Unit.FromCentimeter(5));

                Row row = table.AddRow();
                row.Shading.Color = Colors.PaleGoldenrod;
                Cell cell = row.Cells[0];
                cell.AddParagraph("Itemus");
                cell = row.Cells[1];
                cell.AddParagraph("Descriptum");

                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("1");
                cell = row.Cells[1];
                cell.AddParagraph();
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("2");
                cell = row.Cells[1];
                cell.AddParagraph();
                table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);
                document.LastSection.Add(table);
                MemoryStream memoryStream = new MemoryStream();
                var pdfRenderer = new PdfDocumentRenderer();
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(memoryStream, false);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return File(memoryStream.ToArray(), "application/pdf", "medicines.pdf");
            }
            catch(Exception ex)
            {
                throw new Exception("Greska: "+ex.InnerException);
            }
                                     
                
        }
        //Ljekovi se pozivaju na id životinje BITNO!!
        [HttpGet("generateMedicines/{idAnimal}")]
        public async Task<IActionResult> RendererPdfMedicines(int idAnimal)//Zove funkciju DefineTables() i pretvara u pdf
        {
                //ovo bi trebalo vratit sve ljekove koje životinja ima

                var meds = _appDbContext.Medicines.ToList();
                var medicinesDomain = meds.Select(e => new MedicinesDomain(
                    e.Id,
                    e.AnimalId,
                    e.NameOfMedicines,
                    e.Description,
                    e.VetUsername,
                    e.AmountOfMedicine,
                    e.MesurmentUnit,
                    e.MedicationIntake,
                    e.FrequencyOfMedicationUse,
                    e.Usage
                    )).Where(a=>a.AnimalId == idAnimal).ToList();
                   ;//vrati dobro
                
                //povuci iz baze sve podatke životinje,  njih stavi kao onaj fensi tekst, a ljeove strpaj u tablicu
                var animalData = _appDbContext.Animals
                  .Where(a => a.IdAnimal == idAnimal ) 
                  .Select(e => new AnimalDomain(
                      e.IdAnimal,
                      e.Name,
                      e.Family,
                      e.Species,
                      e.Subspecies,
                      e.Age,
                      e.Gender,
                      e.Weight,
                      e.Height,
                      e.Length,
                      e.Neutered,
                      e.Vaccinated,
                      e.Microchipped,
                      e.Trained,
                      e.Socialized,
                      e.HealthIssues,
                      e.Picture,
                      e.PersonalityDescription,
                      e.Adopted))
                  .FirstOrDefault();//vrati dobro



            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
            
            Paragraph paragraphH = document.LastSection.AddParagraph("Medicines", "Heading1");
            paragraphH.Format.Font.Size = 24;
            paragraphH.Format.Font.Bold = true;
            Paragraph paragraph = document.LastSection.AddParagraph("Name: "+animalData.Name, "Heading3");
            document.LastSection.AddParagraph($"Family:{animalData.Family}, {animalData.Species} ,{animalData.Subspecies}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Age:  {animalData.Age}" , "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Gender: {animalData.Gender}"  , "Heading3").Format.Font.Size = 14;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Bold = false;
            document.LastSection.AddParagraph(" ", "Heading3");


            Table table = new Table();
            table.Borders.Width = 0.5;
            Column column = table.AddColumn(Unit.FromCentimeter(4)); 
                            table.AddColumn(Unit.FromCentimeter(3));
                            table.AddColumn(Unit.FromCentimeter(4));
                            table.AddColumn(Unit.FromCentimeter(3));
                            table.AddColumn(Unit.FromCentimeter(3));
            Row row = table.AddRow();
            row.Shading.Color = Colors.Aquamarine;
            table.Borders.Visible = false;
            table.Format.Font.Size = Unit.FromPoint(14);
            table.TopPadding = 0.5;
            table.BottomPadding = 0.5;
            table.LeftPadding = 0.5;
            table.RightPadding = 0.5;
            
            Cell cell = row.Cells[0];
            cell.AddParagraph("Description");
            cell = row.Cells[1];
            cell.AddParagraph("Name");
            cell = row.Cells[2];
            cell.AddParagraph("Amount");
            cell = row.Cells[3];
            cell.AddParagraph("Intake");
            cell = row.Cells[4];
            cell.AddParagraph("Frequency");

            foreach (MedicinesDomain m in medicinesDomain)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph(m.Description);
                cell = row.Cells[1];
                cell.AddParagraph(m.NameOfMedicines);
                cell = row.Cells[2];
                cell.AddParagraph(Convert.ToString( m.AmountOfMedicine)+ m.MesurmentUnit);
                cell = row.Cells[3];
                cell.AddParagraph(Convert.ToString(m.MedicationIntake));
                cell = row.Cells[4];
                cell.AddParagraph(m.FrequencyOfMedicationUse);
             
            }
          
             table.Rows.Alignment = RowAlignment.Center;
            document.LastSection.Add(table);

            //ovo dalje za pdf
            MemoryStream memoryStream = new MemoryStream();
                var pdfRenderer = new PdfDocumentRenderer();
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(memoryStream, false);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return File(memoryStream.ToArray(), "application/pdf", "medicines.pdf");
           


        }



    }



}


