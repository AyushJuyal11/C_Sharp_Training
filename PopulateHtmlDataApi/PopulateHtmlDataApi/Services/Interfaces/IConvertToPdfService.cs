namespace PopulateHtmlDataApi.Services.Interfaces
{
    public interface IConvertToPdfService
    {
        Task<byte[]> GetByteDataAsync(string mappedHtmlData);
    }
}
