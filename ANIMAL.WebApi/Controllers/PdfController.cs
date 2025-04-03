using ANIMAL.DAL.DataModel;
using ANIMAL.MODEL;
using ANIMAL.Repository.Automaper;
using DocumentFormat.OpenXml.Office2010.Excel;
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
using Table = MigraDoc.DocumentObjectModel.Tables.Table;


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
            row.Shading.Color = Colors.Gray;
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

        [HttpGet("generateLabs/{idAnimal}")]
        public async Task<IActionResult> RendererPdfLabs(int idAnimal)//Zove funkciju DefineTables() i pretvara u pdf
        {
            //id albaratorija i onda iz toga izvuci životinju
           
            //povuci iz baze sve podatke životinje,  njih stavi kao onaj fensi tekst, a ljeove strpaj u tablicu
            var animalData = _appDbContext.Animals
              .Where(a => a.IdAnimal == idAnimal)
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

            var labs = _appDbContext.Labs
                  .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                      (r, a) => new { Labs = r, Animal = a })
                                  .Where(x => x.Labs.AnimalId == idAnimal)
                               .Select(x => new LabsDomain(
                                    x.Labs.Id,
                                    x.Labs.AnimalId,
                                    x.Labs.DateTime
                                )).FirstOrDefault();

            var parameterDb = _appDbContext.Parameter.ToList();
            var parameterDomain = parameterDb.Select(e => new ParameterDomain(
                e.Id,
                e.LabId,
                e.ParameterName,
                e.ParameterValue,
                e.Remarks,
                e.MeasurementUnits
                )).Where(a => a.LabId == labs.Id);


            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();

            Paragraph paragraphH = document.LastSection.AddParagraph("Labs", "Heading1");
            paragraphH.Format.Font.Size = 24;
            paragraphH.Format.Font.Bold = true;
            Paragraph paragraph = document.LastSection.AddParagraph("Name: " + animalData.Name, "Heading3");
            document.LastSection.AddParagraph($"Family:{animalData.Family}, {animalData.Species} ,{animalData.Subspecies}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Age:  {animalData.Age}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Gender: {animalData.Gender}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Lab Number:  {labs.Id}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Date: {labs.DateTime}", "Heading3").Format.Font.Size = 14;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Bold = false;
            document.LastSection.AddParagraph(" ", "Heading3");


            Table table = new Table();
            table.Borders.Width = 0.5;
            Column column = table.AddColumn(Unit.FromCentimeter(5));
            table.AddColumn(Unit.FromCentimeter(6));
            table.AddColumn(Unit.FromCentimeter(5));
      
   
            Row row = table.AddRow();
            row.Shading.Color = Colors.Gray;
            table.Borders.Visible = false;
            table.Format.Font.Size = Unit.FromPoint(14);
            table.TopPadding = 0.5;
            table.BottomPadding = 0.5;
            table.LeftPadding = 0.5;
            table.RightPadding = 0.5;

            Cell cell = row.Cells[0];
            cell.AddParagraph("Parameter Name");
            cell = row.Cells[1];
            cell.AddParagraph("Parameter Value");
            cell = row.Cells[2];
            cell.AddParagraph("Remarks");
          
         

            foreach (ParameterDomain m in parameterDomain)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph(m.ParameterName);
                cell = row.Cells[1];
                cell.AddParagraph(Convert.ToString( m.ParameterValue)+" "+m.MeasurementUnits);
                cell = row.Cells[2];
                cell.AddParagraph(m.Remarks);
      

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





        [HttpGet("generateVetVisits/{idAnimal}")]
        public async Task<IActionResult> RendererPdfVetVisit(int idAnimal)//Zove funkciju DefineTables() i pretvara u pdf
        {

            //povuci iz baze sve podatke životinje,  njih stavi kao onaj fensi tekst, a ljeove strpaj u tablicu
            var animalData = _appDbContext.Animals
              .Where(a => a.IdAnimal == idAnimal)
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


            var vetVisitDb = _appDbContext.VetVisits.ToList();
            var vetVisitDomain = vetVisitDb.Select(
                e => new VetVisitsDomain(
                    e.Id,
                    e.AnimalId,
                    e.StartTime,
                    e.EndTime,
                    e.TypeOfVisit,
                    e.Notes
                    )).Where(v=>v.AnimalId==idAnimal);




            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();

            Paragraph paragraphH = document.LastSection.AddParagraph("Vet Visit", "Heading1");
            paragraphH.Format.Font.Size = 24;
            paragraphH.Format.Font.Bold = true;
            Paragraph paragraph = document.LastSection.AddParagraph("Name: " + animalData.Name, "Heading3");
            document.LastSection.AddParagraph($"Family:{animalData.Family}, {animalData.Species} ,{animalData.Subspecies}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Age:  {animalData.Age}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Gender: {animalData.Gender}", "Heading3").Format.Font.Size = 14;
          


            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Bold = false;
            document.LastSection.AddParagraph(" ", "Heading3");


            Table table = new Table();
            table.Borders.Width = 0.5;
            Column column = table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(5));

            Row row = table.AddRow();
            row.Shading.Color = Colors.Gray;
            table.Borders.Visible = false;
            table.Format.Font.Size = Unit.FromPoint(14);
            table.TopPadding = 0.5;
            table.BottomPadding = 0.5;
            table.LeftPadding = 0.5;
            table.RightPadding = 0.5;

            Cell cell = row.Cells[0];
            cell.AddParagraph("Type Of Visit");
            cell = row.Cells[1];
            cell.AddParagraph("Start Time");
            cell = row.Cells[2];
            cell.AddParagraph("End Time");
            cell = row.Cells[3];
            cell.AddParagraph("Notes");


            foreach (VetVisitsDomain m in vetVisitDomain)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph(m.TypeOfVisit);
                cell = row.Cells[1];
                cell.AddParagraph(Convert.ToString(m.StartTime));
                cell = row.Cells[2];
                cell.AddParagraph(Convert.ToString( m.EndTime));
                cell = row.Cells[3];
                cell.AddParagraph(Convert.ToString(m.Notes));

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
            return File(memoryStream.ToArray(), "application/pdf", "vetvisits.pdf");



        }





        [HttpGet("generateMedicalHistory/{idAnimal}")]
        public async Task<IActionResult> RendererPdfMedicalHistory(int idAnimal)//Zove funkciju DefineTables() i pretvara u pdf
        {

            //povuci iz baze sve podatke životinje,  njih stavi kao onaj fensi tekst, a ljeove strpaj u tablicu
            var animalData = _appDbContext.Animals
              .Where(a => a.IdAnimal == idAnimal)
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

            var contageusAnimalsDb = _appDbContext.ContageusAnimals.ToList();
            var contageusAnimalsDomain = contageusAnimalsDb.Select(
                e => new ContageusAnimalsDomain(
                    e.Id,
                    e.AnimalId,
                    e.DesisseName,
                    e.Description,
                    e.Contageus,
                    e.StartTime
                    )).Where(c=>c.AnimalId==animalData.IdAnimal);

            var vetVisitDb = _appDbContext.VetVisits.ToList();
            var vetVisitDomain = vetVisitDb.Select(
                e => new VetVisitsDomain(
                    e.Id,
                    e.AnimalId,
                    e.StartTime,
                    e.EndTime,
                    e.TypeOfVisit,
                    e.Notes
                    )).Where(v => v.AnimalId == idAnimal);


            var labs = _appDbContext.Labs
                 .Join(_appDbContext.Animals, r => r.AnimalId, a => a.IdAnimal,
                                     (r, a) => new { Labs = r, Animal = a })
                                 .Where(x => x.Labs.AnimalId == idAnimal)
                              .Select(x => new LabsDomain(
                                   x.Labs.Id,
                                   x.Labs.AnimalId,
                                   x.Labs.DateTime
                               )).ToList();

          

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
                )).Where(a => a.AnimalId == idAnimal).ToList();
            




            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();

            Paragraph paragraphH = document.LastSection.AddParagraph("Medical History", "Heading1");
            paragraphH.Format.Font.Size = 24;
            paragraphH.Format.Font.Bold = true;
            Paragraph paragraph = document.LastSection.AddParagraph("Name: " + animalData.Name, "Heading3");
            document.LastSection.AddParagraph($"Family:{animalData.Family}, {animalData.Species} ,{animalData.Subspecies}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Age:  {animalData.Age}", "Heading3").Format.Font.Size = 14;
            document.LastSection.AddParagraph($"Gender: {animalData.Gender}", "Heading3").Format.Font.Size = 14;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Bold = false;
            document.LastSection.AddParagraph(" ", "Heading3");

            Paragraph paragraphContageusAnimals = document.LastSection.AddParagraph("Contageus Animal", "Heading1");
            paragraphContageusAnimals.Format.Font.Size = 20;
            //tablica contageusAnimalsDb
            Table tablecontageus = new Table();
            tablecontageus.Borders.Width = 0.5;
            Column columncontageus = tablecontageus.AddColumn(Unit.FromCentimeter(4));
            tablecontageus.AddColumn(Unit.FromCentimeter(4));
            tablecontageus.AddColumn(Unit.FromCentimeter(6));
            tablecontageus.AddColumn(Unit.FromCentimeter(3));
            Row rowcontageus = tablecontageus.AddRow();
            rowcontageus.Shading.Color = Colors.Gray;
            tablecontageus.Borders.Visible = false;
            tablecontageus.Format.Font.Size = Unit.FromPoint(14);
            tablecontageus.TopPadding = 0.5;
            tablecontageus.BottomPadding = 0.5;
            tablecontageus.LeftPadding = 0.5;
            tablecontageus.RightPadding = 0.5;

            Cell cellcontageus = rowcontageus.Cells[0];
            cellcontageus.AddParagraph("DesisseName");
            cellcontageus = rowcontageus.Cells[1];
            cellcontageus.AddParagraph("Contageus");
            cellcontageus = rowcontageus.Cells[2];
            cellcontageus.AddParagraph("Description");
            cellcontageus = rowcontageus.Cells[3];
            cellcontageus.AddParagraph("Date");


            foreach (ContageusAnimalsDomain m in contageusAnimalsDomain)
            {
                rowcontageus = tablecontageus.AddRow();
                cellcontageus = rowcontageus.Cells[0];
                cellcontageus.AddParagraph(m.DesisseName);
                cellcontageus = rowcontageus.Cells[1];
                cellcontageus.AddParagraph(Convert.ToString(m.Contageus));
                cellcontageus = rowcontageus.Cells[2];
                cellcontageus.AddParagraph(Convert.ToString(m.Description));
                cellcontageus = rowcontageus.Cells[3];
                cellcontageus.AddParagraph(Convert.ToString(m.StartTime));

            }
            tablecontageus.Rows.Alignment = RowAlignment.Center;
            tablecontageus.BottomPadding = 25;
            document.LastSection.Add(tablecontageus);



            document.LastSection.AddParagraph(" ", "Heading3");
            document.LastSection.AddParagraph(" ", "Heading3");
            Paragraph paragraphMedicinesDomain = document.LastSection.AddParagraph("Medicines", "Heading1");
            paragraphMedicinesDomain.Format.Font.Size = 20;
            tablecontageus.Rows.Alignment = RowAlignment.Center;
            tablecontageus.BottomPadding = 25;
            document.LastSection.Add(tablecontageus);
            document.LastSection.AddParagraph(" ", "Heading3");         
          //Ljekovi svi u jednu tablicu
            Table tableMeds = new Table();
            tableMeds.Borders.Width = 0.5;
            Column columnMeds = tableMeds.AddColumn(Unit.FromCentimeter(4));
            tableMeds.AddColumn(Unit.FromCentimeter(3));
            tableMeds.AddColumn(Unit.FromCentimeter(4));
            tableMeds.AddColumn(Unit.FromCentimeter(3));
            tableMeds.AddColumn(Unit.FromCentimeter(3));
            Row rowm = tableMeds.AddRow();
            rowm.Shading.Color = Colors.Gray;
            tableMeds.Borders.Visible = false;
            tableMeds.Format.Font.Size = Unit.FromPoint(14);
            tableMeds.TopPadding = 0.5;
            tableMeds.BottomPadding = 0.5;
            tableMeds.LeftPadding = 0.5;
            tableMeds.RightPadding = 0.5;

            Cell cellMeds = rowm.Cells[0];
            cellMeds.AddParagraph("Description");
            cellMeds = rowm.Cells[1];
            cellMeds.AddParagraph("Name");
            cellMeds = rowm.Cells[2];
            cellMeds.AddParagraph("Amount");
            cellMeds = rowm.Cells[3];
            cellMeds.AddParagraph("Intake");
            cellMeds = rowm.Cells[4];
            cellMeds.AddParagraph("Frequency");

            foreach (MedicinesDomain m in medicinesDomain)
            {
                rowm = tableMeds.AddRow();
                cellMeds = rowm.Cells[0];
                cellMeds.AddParagraph(m.Description);
                cellMeds = rowm.Cells[1];
                cellMeds.AddParagraph(m.NameOfMedicines);
                cellMeds = rowm.Cells[2];
                cellMeds.AddParagraph(Convert.ToString(m.AmountOfMedicine) + m.MesurmentUnit);
                cellMeds = rowm.Cells[3];
                cellMeds.AddParagraph(Convert.ToString(m.MedicationIntake));
                cellMeds = rowm.Cells[4];
                cellMeds.AddParagraph(m.FrequencyOfMedicationUse);

            }

            tableMeds.Rows.Alignment = RowAlignment.Center;
            tableMeds.BottomPadding = 25;
            document.LastSection.Add(tableMeds);


            //Vet visit sve u jednu tablicu
            document.LastSection.AddParagraph(" ", "Heading3");
            document.LastSection.AddParagraph(" ", "Heading3");
            Paragraph paragraphVetVisitsDomain = document.LastSection.AddParagraph("Vet Visits", "Heading1");
            paragraphVetVisitsDomain.Format.Font.Size = 20;
            document.LastSection.AddParagraph(" ", "Heading3");
            Table table = new Table();
            table.Borders.Width = 0.5;
            Column column = table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(4));
            table.AddColumn(Unit.FromCentimeter(5));

            Row row = tableMeds.AddRow();
             row.Shading.Color = Colors.Gray;
            table.Borders.Visible = false;
            table.Format.Font.Size = Unit.FromPoint(14);
            table.TopPadding = 0.5;
            table.BottomPadding = 0.5;
            table.LeftPadding = 0.5;
            table.RightPadding = 0.5;

            Cell cell = row.Cells[0];
            cell.AddParagraph("Type Of Visit");
            cell = row.Cells[1];
            cell.AddParagraph("Start Time");
            cell = row.Cells[2];
            cell.AddParagraph("End Time");
            cell = row.Cells[3];
            cell.AddParagraph("Notes");
            

            foreach (VetVisitsDomain m in vetVisitDomain)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph(m.TypeOfVisit);
                cell = row.Cells[1];
                cell.AddParagraph(Convert.ToString(m.StartTime));
                cell = row.Cells[2];
                cell.AddParagraph(Convert.ToString(m.EndTime));
                cell = row.Cells[3];
                cell.AddParagraph(Convert.ToString(m.Notes));

            }

            table.Rows.Alignment = RowAlignment.Center;
            tableMeds.BottomPadding = 25;
            document.LastSection.Add(table);
            //

            document.LastSection.AddParagraph(" ", "Heading3");
            document.LastSection.AddParagraph(" ", "Heading3");
            Paragraph paragraphLabs = document.LastSection.AddParagraph("Labs", "Heading1");
            paragraphLabs.Format.Font.Size = 20;
            foreach (LabsDomain l in labs)
            {
                document.LastSection.AddParagraph(" ", "Heading3");

                var parameterDb = _appDbContext.Parameter.ToList();
                var parameterDomain = parameterDb.Select(e => new ParameterDomain(
                    e.Id,
                    e.LabId,
                    e.ParameterName,
                    e.ParameterValue,
                    e.Remarks,
                    e.MeasurementUnits
                    )).Where(a => a.LabId == l.Id);


                Table tablelabs = new Table();
                tablelabs.Borders.Width = 0.5;
                document.LastSection.AddParagraph($"Lab: {l.Id} Date: {l.DateTime}", "Heading3").Format.Font.Size = 14;
                Column columnlabs = tablelabs.AddColumn(Unit.FromCentimeter(7));
                tablelabs.AddColumn(Unit.FromCentimeter(5));
                tablelabs.AddColumn(Unit.FromCentimeter(5));
               

                Row rowlabs = tablelabs.AddRow();
                rowlabs.Shading.Color = Colors.Gray;
                tablelabs.Borders.Visible = false;
                tablelabs.Format.Font.Size = Unit.FromPoint(14);
                tablelabs.TopPadding = 0.5;
                tablelabs.BottomPadding = 0.5;
                tablelabs.LeftPadding = 0.5;
                tablelabs.RightPadding = 0.5;

                Cell celllabs = rowlabs.Cells[0];
                celllabs.AddParagraph("Parameter Name");
                celllabs = rowlabs.Cells[1];
                celllabs.AddParagraph("Parameter Value");
                celllabs = rowlabs.Cells[2];
                celllabs.AddParagraph("Remarks");

                foreach (ParameterDomain m in parameterDomain)
                {
                    rowlabs = tablelabs.AddRow();
                    celllabs = rowlabs.Cells[0];
                    celllabs.AddParagraph(m.ParameterName);
                    celllabs = rowlabs.Cells[1];
                    celllabs.AddParagraph(Convert.ToString(m.ParameterValue)+m.MeasurementUnits);
                    celllabs = rowlabs.Cells[2];
                    celllabs.AddParagraph(Convert.ToString(m.Remarks));
                }

                tablelabs.Rows.Alignment = RowAlignment.Center;
                tableMeds.BottomPadding = 10;
                document.LastSection.Add(tablelabs);
            }










            //ovo dalje za pdf
            MemoryStream memoryStream = new MemoryStream();
            var pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save(memoryStream, false);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return File(memoryStream.ToArray(), "application/pdf", "medicalhistory.pdf");



        }















    }



}


