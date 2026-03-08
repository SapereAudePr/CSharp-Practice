using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Companion;

namespace PDFDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "Test.pdf");
            string txtFilePath = @"C:\Users\38125\Desktop\text.txt";
            var read = File.ReadAllText(txtFilePath);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                    .Text("Header")
                    .SemiBold().FontSize(16).FontColor(Colors.Black).FontFamily(Fonts.LucidaConsole);

                    page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Item().Text(read);
                    });


                    page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.CurrentPageNumber();
                    });

                });
            });

            // instead of the standard way of generating a PDF file
            //document.GeneratePdf(path);

            // use the following invocation
            document.ShowInCompanion(12500);
        }
    }
}
