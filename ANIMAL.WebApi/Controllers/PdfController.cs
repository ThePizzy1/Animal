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

    public class PdfController : ControllerBase
    {
        private readonly AnimalRescueDbContext _appDbContext;
        public PdfController(AnimalRescueDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

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
            catch (Exception ex)
            {
                throw new Exception("Greska: " + ex.InnerException);
            }


        }
        //Ljekovi se pozivaju na id životinje BITNO!!
        [HttpGet("generateMedicines/{idAnimal}")]
        public async Task<IActionResult> RendererPdfMedicines(int idAnimal)
        {
            try
            {
                // Dohvati lijekove za zadanu životinju
                var meds = _appDbContext.Medicines.ToList();
                var medicinesDomain = meds
                    .Where(m => m.AnimalId == idAnimal)
                    .Select(e => new MedicinesDomain(
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
                    )).ToList();

                // Dohvati podatke o životinji
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
                    .FirstOrDefault();

                if (animalData == null)
                    return NotFound($"Animal with ID {idAnimal} not found.");

                // Kreiraj dokument
                MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
                document.Info.Title = "Animal Medication Report";
                document.Info.Subject = "Detailed report of medications for a specific animal";
                document.Info.Author = "Animal Rescue Web API";

                var section = document.AddSection();

                // Naslov
                var title = section.AddParagraph("Animal Medication Report");
                title.Format.Font.Size = 20;
                title.Format.Font.Bold = true;
                title.Format.SpaceAfter = Unit.FromCentimeter(0.5);
                title.Format.Alignment = ParagraphAlignment.Center;

                // Podaci o životinji
                var animalInfo = section.AddParagraph();
                animalInfo.Format.Font.Size = 12;
                animalInfo.Format.SpaceAfter = Unit.FromCentimeter(0.5);

                animalInfo.AddFormattedText("Name: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Name}\n");

                animalInfo.AddFormattedText("Family: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Family}, {animalData.Species}, {animalData.Subspecies}\n");

                animalInfo.AddFormattedText("Age: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Age} years\n");

                animalInfo.AddFormattedText("Gender: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Gender}\n");

                // Prazan red za razmak
                section.AddParagraph();

                // Kreiraj tablicu lijekova
                var table = new Table();
                table.Borders.Width = 0.75;
                table.Borders.Color = Colors.DarkGray;
                table.Rows.LeftIndent = 0;

                // Definiraj stupce
                table.AddColumn(Unit.FromCentimeter(5));  // Description
                table.AddColumn(Unit.FromCentimeter(3));  // Name
                table.AddColumn(Unit.FromCentimeter(3));  // Amount
                table.AddColumn(Unit.FromCentimeter(3));  // Intake
                table.AddColumn(Unit.FromCentimeter(4));  // Frequency

                // Zaglavlje tablice
                var headerRow = table.AddRow();
                headerRow.Shading.Color = Colors.LightGray;
                headerRow.Format.Font.Bold = true;
                headerRow.Format.Alignment = ParagraphAlignment.Center;

                headerRow.Cells[0].AddParagraph("Description");
                headerRow.Cells[1].AddParagraph("Name");
                headerRow.Cells[2].AddParagraph("Amount");
                headerRow.Cells[3].AddParagraph("Intake");
                headerRow.Cells[4].AddParagraph("Frequency");

                // Popuni redove tablice
                foreach (var m in medicinesDomain)
                {
                    var row = table.AddRow();
                    row.Cells[0].AddParagraph(string.IsNullOrWhiteSpace(m.Description) ? "N/A" : m.Description);
                    row.Cells[1].AddParagraph(string.IsNullOrWhiteSpace(m.NameOfMedicines) ? "N/A" : m.NameOfMedicines);
                    row.Cells[2].AddParagraph($"{m.AmountOfMedicine} {m.MesurmentUnit}".Trim());
                    row.Cells[3].AddParagraph(m.MedicationIntake.ToString() ?? "N/A");
                    row.Cells[4].AddParagraph(string.IsNullOrWhiteSpace(m.FrequencyOfMedicationUse) ? "N/A" : m.FrequencyOfMedicationUse);
                }

                table.Rows.Alignment = RowAlignment.Center;
                section.Add(table);

                // Generiraj PDF u memorijski tok
                using var memoryStream = new MemoryStream();
                var pdfRenderer = new PdfDocumentRenderer(unicode: true)
                {
                    Document = document
                };
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(memoryStream, false);
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Vrati PDF datoteku
                return File(memoryStream.ToArray(), "application/pdf", $"animal_medicines_{idAnimal}.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest($"Greška prilikom generiranja PDF-a: {ex.Message}");
            }
        }
        [HttpGet("generateLabs/{idAnimal}")]
        public async Task<IActionResult> RendererPdfLabs(int idAnimal)
        {
            try
            {
                // Dohvati podatke o životinji
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
                    .FirstOrDefault();

                if (animalData == null)
                    return NotFound($"Animal with ID {idAnimal} not found.");

                // Dohvati laboratorijske pretrage za životinju
                var labs = _appDbContext.Labs
                    .Where(l => l.AnimalId == idAnimal)
                    .OrderByDescending(l => l.DateTime)
                    .Select(l => new LabsDomain(
                        l.Id,
                        l.AnimalId,
                        l.DateTime))
                    .FirstOrDefault();

                if (labs == null)
                    return NotFound($"No lab data found for animal ID {idAnimal}.");

                // Dohvati parametre laboratorijskih pretraga
                var parameterDomain = _appDbContext.Parameter
                    .Where(p => p.LabId == labs.Id)
                    .Select(e => new ParameterDomain(
                        e.Id,
                        e.LabId,
                        e.ParameterName,
                        e.ParameterValue,
                        e.Remarks,
                        e.MeasurementUnits))
                    .ToList();

                // Kreiraj dokument i sekciju
                var document = new MigraDoc.DocumentObjectModel.Document();
                document.Info.Title = "Laboratory Report";
                document.Info.Subject = "Detailed laboratory results for a specific animal";
                document.Info.Author = "Animal Rescue Web API";

                var section = document.AddSection();

                // Naslov
                var title = section.AddParagraph("Laboratory Report");
                title.Format.Font.Size = 20;
                title.Format.Font.Bold = true;
                title.Format.SpaceAfter = Unit.FromCentimeter(0.5);
                title.Format.Alignment = ParagraphAlignment.Center;

                // Podaci o životinji
                var animalInfo = section.AddParagraph();
                animalInfo.Format.Font.Size = 12;
                animalInfo.Format.SpaceAfter = Unit.FromCentimeter(0.5);

                animalInfo.AddFormattedText("Name: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Name}\n");

                animalInfo.AddFormattedText("Family: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Family}, {animalData.Species}, {animalData.Subspecies}\n");

                animalInfo.AddFormattedText("Age: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Age} years\n");

                animalInfo.AddFormattedText("Gender: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Gender}\n");

                animalInfo.AddFormattedText("Lab Number: ", TextFormat.Bold);
                animalInfo.AddText($"{labs.Id}\n");

                animalInfo.AddFormattedText("Date: ", TextFormat.Bold);
                animalInfo.AddText($"{labs.DateTime:dd.MM.yyyy HH:mm}\n");

                section.AddParagraph();

                // Kreiraj tablicu za parametre laboratorijskih nalaza
                var table = new Table();
                table.Borders.Width = 0.75;
                table.Borders.Color = Colors.DarkGray;

                table.AddColumn(Unit.FromCentimeter(6)); // Parameter Name
                table.AddColumn(Unit.FromCentimeter(4)); // Parameter Value
                table.AddColumn(Unit.FromCentimeter(6)); // Remarks

                // Zaglavlje tablice
                var headerRow = table.AddRow();
                headerRow.Shading.Color = Colors.LightGray;
                headerRow.Format.Font.Bold = true;
                headerRow.Format.Alignment = ParagraphAlignment.Center;

                headerRow.Cells[0].AddParagraph("Parameter Name");
                headerRow.Cells[1].AddParagraph("Parameter Value");
                headerRow.Cells[2].AddParagraph("Remarks");

                // Podaci u tablici
                foreach (var p in parameterDomain)
                {
                    var row = table.AddRow();
                    row.Cells[0].AddParagraph(string.IsNullOrWhiteSpace(p.ParameterName) ? "N/A" : p.ParameterName);
                    row.Cells[1].AddParagraph($"{p.ParameterValue} {p.MeasurementUnits}".Trim());
                    row.Cells[2].AddParagraph(string.IsNullOrWhiteSpace(p.Remarks) ? "-" : p.Remarks);
                }

                table.Rows.Alignment = RowAlignment.Center;
                section.Add(table);

                // Generiranje PDF-a u memorijski tok
                using var memoryStream = new MemoryStream();
                var pdfRenderer = new PdfDocumentRenderer(unicode: true)
                {
                    Document = document
                };
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(memoryStream, false);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return File(memoryStream.ToArray(), "application/pdf", $"lab_report_{idAnimal}.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest($"Greška prilikom generiranja PDF-a: {ex.Message}");
            }
        }



        [HttpGet("generateVetVisits/{idAnimal}")]
        public async Task<IActionResult> RendererPdfVetVisit(int idAnimal)
        {
            try
            {
                // Dohvati podatke o životinji
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
                    .FirstOrDefault();

                if (animalData == null)
                    return NotFound($"Animal with ID {idAnimal} not found.");

                // Dohvati veterinarske preglede za životinju
                var vetVisitDomain = _appDbContext.VetVisits
                    .Where(v => v.AnimalId == idAnimal)
                    .Select(e => new VetVisitsDomain(
                        e.Id,
                        e.AnimalId,
                        e.StartTime,
                        e.EndTime,
                        e.TypeOfVisit,
                        e.Notes))
                    .ToList();

                // Kreiraj dokument i sekciju
                var document = new MigraDoc.DocumentObjectModel.Document();
                document.Info.Title = "Veterinary Visits Report";
                document.Info.Subject = "Detailed veterinary visit records for an animal";
                document.Info.Author = "Animal Rescue Web API";

                var section = document.AddSection();

                // Naslov
                var title = section.AddParagraph("Veterinary Visits");
                title.Format.Font.Size = 20;
                title.Format.Font.Bold = true;
                title.Format.SpaceAfter = Unit.FromCentimeter(0.5);
                title.Format.Alignment = ParagraphAlignment.Center;

                // Podaci o životinji
                var animalInfo = section.AddParagraph();
                animalInfo.Format.Font.Size = 12;
                animalInfo.Format.SpaceAfter = Unit.FromCentimeter(0.5);

                animalInfo.AddFormattedText("Name: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Name}\n");

                animalInfo.AddFormattedText("Family: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Family}, {animalData.Species}, {animalData.Subspecies}\n");

                animalInfo.AddFormattedText("Age: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Age} years\n");

                animalInfo.AddFormattedText("Gender: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Gender}\n");

                section.AddParagraph();

                // Kreiraj tablicu za veterinarske preglede
                var table = new Table();
                table.Borders.Width = 0.75;
                table.Borders.Color = Colors.DarkGray;

                table.AddColumn(Unit.FromCentimeter(4)); // Type Of Visit
                table.AddColumn(Unit.FromCentimeter(4)); // Start Time
                table.AddColumn(Unit.FromCentimeter(4)); // End Time
                table.AddColumn(Unit.FromCentimeter(5)); // Notes

                // Zaglavlje tablice
                var headerRow = table.AddRow();
                headerRow.Shading.Color = Colors.LightGray;
                headerRow.Format.Font.Bold = true;
                headerRow.Format.Alignment = ParagraphAlignment.Center;

                headerRow.Cells[0].AddParagraph("Type Of Visit");
                headerRow.Cells[1].AddParagraph("Start Time");
                headerRow.Cells[2].AddParagraph("End Time");
                headerRow.Cells[3].AddParagraph("Notes");

                // Podaci u tablici
                foreach (var visit in vetVisitDomain)
                {
                    var row = table.AddRow();
                    row.Cells[0].AddParagraph(string.IsNullOrWhiteSpace(visit.TypeOfVisit) ? "-" : visit.TypeOfVisit);
                    row.Cells[1].AddParagraph(visit.StartTime.ToString("dd.MM.yyyy HH:mm"));
                    row.Cells[2].AddParagraph(visit.EndTime != null ? visit.EndTime.ToString("dd.MM.yyyy HH:mm") : "-");
                    row.Cells[3].AddParagraph(string.IsNullOrWhiteSpace(visit.Notes) ? "-" : visit.Notes);
                }

                table.Rows.Alignment = RowAlignment.Center;
                section.Add(table);

                // Generiranje PDF-a u memorijski tok
                using var memoryStream = new MemoryStream();
                var pdfRenderer = new PdfDocumentRenderer(unicode: true)
                {
                    Document = document
                };
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(memoryStream, false);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return File(memoryStream.ToArray(), "application/pdf", $"vet_visits_{idAnimal}.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest($"Greška prilikom generiranja PDF-a: {ex.Message}");
            }
        }




        [HttpGet("generateMedicalHistory/{idAnimal}")]
        public async Task<IActionResult> RendererPdfMedicalHistory(int idAnimal)
        {
            try
            {
                // Dohvati podatke o životinji
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
                    .FirstOrDefault();

                if (animalData == null)
                    return NotFound($"Animal with ID {idAnimal} not found.");

                // Dohvati podatke iz baze
                var contageusAnimalsDomain = _appDbContext.ContageusAnimals
                    .Where(c => c.AnimalId == idAnimal)
                    .Select(c => new ContageusAnimalsDomain(
                        c.Id,
                        c.AnimalId,
                        c.DesisseName,
                        c.Description,
                        c.Contageus,
                        c.StartTime))
                    .ToList();

                var vetVisitDomain = _appDbContext.VetVisits
                    .Where(v => v.AnimalId == idAnimal)
                    .Select(v => new VetVisitsDomain(
                        v.Id,
                        v.AnimalId,
                        v.StartTime,
                        v.EndTime,
                        v.TypeOfVisit,
                        v.Notes))
                    .ToList();

                var labs = _appDbContext.Labs
                    .Where(l => l.AnimalId == idAnimal)
                    .Select(l => new LabsDomain(
                        l.Id,
                        l.AnimalId,
                        l.DateTime))
                    .ToList();

                var medicinesDomain = _appDbContext.Medicines
                    .Where(m => m.AnimalId == idAnimal)
                    .Select(m => new MedicinesDomain(
                        m.Id,
                        m.AnimalId,
                        m.NameOfMedicines,
                        m.Description,
                        m.VetUsername,
                        m.AmountOfMedicine,
                        m.MesurmentUnit,
                        m.MedicationIntake,
                        m.FrequencyOfMedicationUse,
                        m.Usage))
                    .ToList();

                var document = new MigraDoc.DocumentObjectModel.Document();
                var section = document.AddSection();

                // Naslov dokumenta
                var title = section.AddParagraph("Medical History");
                title.Format.Font.Size = 24;
                title.Format.Font.Bold = true;
                title.Format.SpaceAfter = Unit.FromCentimeter(0.5);
                title.Format.Alignment = ParagraphAlignment.Center;

                // Podaci o životinji
                var animalInfo = section.AddParagraph();
                animalInfo.Format.Font.Size = 14;
                animalInfo.AddFormattedText("Name: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Name}\n");

                animalInfo.AddFormattedText("Family: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Family}, {animalData.Species}, {animalData.Subspecies}\n");

                animalInfo.AddFormattedText("Age: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Age}\n");

                animalInfo.AddFormattedText("Gender: ", TextFormat.Bold);
                animalInfo.AddText($"{animalData.Gender}\n");

                section.AddParagraph();

                // Contageus Animals tablica
                var contageusTitle = section.AddParagraph("Contagious Animals");
                contageusTitle.Format.Font.Size = 20;
                contageusTitle.Format.SpaceBefore = Unit.FromCentimeter(0.5);
                contageusTitle.Format.SpaceAfter = Unit.FromCentimeter(0.3);

                var tableContageus = new Table();
                tableContageus.Borders.Width = 0.75;
                tableContageus.AddColumn(Unit.FromCentimeter(4)); // Disease Name
                tableContageus.AddColumn(Unit.FromCentimeter(3)); // Contagious (bool)
                tableContageus.AddColumn(Unit.FromCentimeter(6)); // Description
                tableContageus.AddColumn(Unit.FromCentimeter(3)); // Date

                var headerRowContageus = tableContageus.AddRow();
                headerRowContageus.Shading.Color = Colors.LightGray;
                headerRowContageus.Format.Font.Bold = true;
                headerRowContageus.Cells[0].AddParagraph("Disease Name");
                headerRowContageus.Cells[1].AddParagraph("Contagious");
                headerRowContageus.Cells[2].AddParagraph("Description");
                headerRowContageus.Cells[3].AddParagraph("Date");

                foreach (var cont in contageusAnimalsDomain)
                {
                    var row = tableContageus.AddRow();
                    row.Cells[0].AddParagraph(cont.DesisseName ?? "-");
                    row.Cells[1].AddParagraph(cont.Contageus ? "Yes" : "No");
                    row.Cells[2].AddParagraph(cont.Description ?? "-");
                    row.Cells[3].AddParagraph(cont.StartTime.ToString("dd.MM.yyyy"));
                }

                section.Add(tableContageus);

                // Medicines tablica
                var medsTitle = section.AddParagraph("Medicines");
                medsTitle.Format.Font.Size = 20;
                medsTitle.Format.SpaceBefore = Unit.FromCentimeter(1);
                medsTitle.Format.SpaceAfter = Unit.FromCentimeter(0.3);

                var tableMeds = new Table();
                tableMeds.Borders.Width = 0.75;
                tableMeds.AddColumn(Unit.FromCentimeter(4)); // Description
                tableMeds.AddColumn(Unit.FromCentimeter(3)); // Name
                tableMeds.AddColumn(Unit.FromCentimeter(3)); // Amount
                tableMeds.AddColumn(Unit.FromCentimeter(3)); // Intake
                tableMeds.AddColumn(Unit.FromCentimeter(3)); // Frequency

                var headerRowMeds = tableMeds.AddRow();
                headerRowMeds.Shading.Color = Colors.LightGray;
                headerRowMeds.Format.Font.Bold = true;
                headerRowMeds.Cells[0].AddParagraph("Description");
                headerRowMeds.Cells[1].AddParagraph("Name");
                headerRowMeds.Cells[2].AddParagraph("Amount");
                headerRowMeds.Cells[3].AddParagraph("Intake");
                headerRowMeds.Cells[4].AddParagraph("Frequency");

                foreach (var med in medicinesDomain)
                {
                    var row = tableMeds.AddRow();
                    row.Cells[0].AddParagraph(med.Description ?? "-");
                    row.Cells[1].AddParagraph(med.NameOfMedicines ?? "-");
                    row.Cells[2].AddParagraph($"{med.AmountOfMedicine} {med.MesurmentUnit}".Trim());
                    row.Cells[3].AddParagraph(med.MedicationIntake.ToString() ?? "-");
                    row.Cells[4].AddParagraph(med.FrequencyOfMedicationUse ?? "-");
                }

                section.Add(tableMeds);

                // Vet Visits tablica
                var vetTitle = section.AddParagraph("Vet Visits");
                vetTitle.Format.Font.Size = 20;
                vetTitle.Format.SpaceBefore = Unit.FromCentimeter(1);
                vetTitle.Format.SpaceAfter = Unit.FromCentimeter(0.3);

                var tableVet = new Table();
                tableVet.Borders.Width = 0.75;
                tableVet.AddColumn(Unit.FromCentimeter(4)); // Type Of Visit
                tableVet.AddColumn(Unit.FromCentimeter(4)); // Start Time
                tableVet.AddColumn(Unit.FromCentimeter(4)); // End Time
                tableVet.AddColumn(Unit.FromCentimeter(5)); // Notes

                var headerRowVet = tableVet.AddRow();
                headerRowVet.Shading.Color = Colors.LightGray;
                headerRowVet.Format.Font.Bold = true;
                headerRowVet.Cells[0].AddParagraph("Type Of Visit");
                headerRowVet.Cells[1].AddParagraph("Start Time");
                headerRowVet.Cells[2].AddParagraph("End Time");
                headerRowVet.Cells[3].AddParagraph("Notes");

                foreach (var visit in vetVisitDomain)
                {
                    var row = tableVet.AddRow();
                    row.Cells[0].AddParagraph(visit.TypeOfVisit ?? "-");
                    row.Cells[1].AddParagraph(visit.StartTime.ToString("dd.MM.yyyy HH:mm"));
                    row.Cells[2].AddParagraph(visit.EndTime != null ? visit.EndTime.ToString("dd.MM.yyyy HH:mm") : "-");
                    row.Cells[3].AddParagraph(visit.Notes ?? "-");
                }

                section.Add(tableVet);

                // Labs and Parameters
                var labsTitle = section.AddParagraph("Labs");
                labsTitle.Format.Font.Size = 20;
                labsTitle.Format.SpaceBefore = Unit.FromCentimeter(1);
                labsTitle.Format.SpaceAfter = Unit.FromCentimeter(0.3);

                foreach (var lab in labs)
                {
                    section.AddParagraph($"Lab ID: {lab.Id}   Date: {lab.DateTime.ToString("dd.MM.yyyy HH:mm")}", "Heading3")
                           .Format.Font.Size = 14;

                    var parameters = _appDbContext.Parameter
                        .Where(p => p.LabId == lab.Id)
                        .Select(p => new ParameterDomain(
                            p.Id,
                            p.LabId,
                            p.ParameterName,
                            p.ParameterValue,
                            p.Remarks,
                            p.MeasurementUnits))
                        .ToList();

                    var tableLabs = new Table();
                    tableLabs.Borders.Width = 0.75;
                    tableLabs.AddColumn(Unit.FromCentimeter(7)); // Parameter Name
                    tableLabs.AddColumn(Unit.FromCentimeter(5)); // Parameter Value
                    tableLabs.AddColumn(Unit.FromCentimeter(5)); // Remarks

                    var headerRowLabs = tableLabs.AddRow();
                    headerRowLabs.Shading.Color = Colors.LightGray;
                    headerRowLabs.Format.Font.Bold = true;
                    headerRowLabs.Cells[0].AddParagraph("Parameter Name");
                    headerRowLabs.Cells[1].AddParagraph("Parameter Value");
                    headerRowLabs.Cells[2].AddParagraph("Remarks");

                    foreach (var param in parameters)
                    {
                        var row = tableLabs.AddRow();
                        row.Cells[0].AddParagraph(param.ParameterName ?? "-");
                        row.Cells[1].AddParagraph($"{param.ParameterValue} {param.MeasurementUnits}".Trim());
                        row.Cells[2].AddParagraph(param.Remarks ?? "-");
                    }

                    section.Add(tableLabs);
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
            catch (Exception ex)
            {
                // Logiraj grešku po potrebi
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        










     


        }















    }



}


