using PopulateHtmlDataApi.Services.Interfaces;
using PuppeteerSharp;

namespace PopulateHtmlDataApi.Services.Implementations
{
    public class ConvertToPdfService : IConvertToPdfService
    {
        public async Task<byte[]> GetByteDataAsync(string mappedHtmlData)
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using(var page = await browser.NewPageAsync()){
                await page.SetContentAsync(mappedHtmlData);
                var bytePdfData = await page.PdfDataAsync();
                var pdfFileName = "pdf_file.pdf"; 
                await File.WriteAllBytesAsync(pdfFileName, bytePdfData);
                return bytePdfData;
            }
        }
    }
}
