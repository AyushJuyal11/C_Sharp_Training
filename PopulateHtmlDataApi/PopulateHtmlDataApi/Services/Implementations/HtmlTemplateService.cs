using AutoMapper;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;
using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.Services.Interfaces;
using PopulateHtmlDataApi.Models.ResponseViewModels;

namespace PopulateHtmlDataApi.Services.Implementations
{
    public class HtmlTemplateService : IHtmlTemplateService
    {
        private readonly IHtmlTemplateRepository _htmlTemplateRepository;
        private readonly IMapper _mapper;

        public HtmlTemplateService(IMapper mapper, IHtmlTemplateRepository htmlTemplateRepository)
        {
            _htmlTemplateRepository = htmlTemplateRepository;
            _mapper=mapper;
        }

        public async Task<HtmlTemplateResponseModel> GetHtmlTemplateByIdAsync(int ID)
        {
            HtmlTemplateEntity requiredHtmlTemplateEntity = await _htmlTemplateRepository.GetHtmlTemplateEntityByIdAsync(ID); 
            HtmlTemplateResponseModel requiredResponseModel = _mapper.Map<HtmlTemplateResponseModel>(requiredHtmlTemplateEntity); 
            return requiredResponseModel; 
        }

    }
}
