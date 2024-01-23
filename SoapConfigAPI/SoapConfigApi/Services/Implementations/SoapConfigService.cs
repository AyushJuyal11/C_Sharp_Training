using AutoMapper;
using System.Xml.Serialization;
using SoapConfigAPI.DAL.Entities;
using SoapConfigAPI.DAL.Repositories.Interfaces;
using SoapConfigAPI.Models.RequestViewModels;
using SoapConfigAPI.Models.ResponseViewModels;
using SoapConfigAPI.Services.Interfaces;

namespace SoapConfigAPI.Services.Implementations
{
    public class SoapConfigService : ISoapConfigService
    {

        private readonly ISoapConfigRepository _soapConfigRepository;
        private readonly IMapper _mapper;

        public SoapConfigService(IMapper mapper , ISoapConfigRepository soapConfigRepository)
        {
            _soapConfigRepository = soapConfigRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<UserResponseModelList>> GetAllSoapConfigsAsync()
        {
            IEnumerable<SoapConfig> allSoapConfigs = await _soapConfigRepository.GetAllSoapConfigsAsync();
            if(allSoapConfigs == null) { throw new Exception("There are no soapConfigs currently "); }

            List<UserResponseModelList> userList = new(); 
            foreach(SoapConfig soapConfig in allSoapConfigs)
            {
                XmlSerializer serializer = new(typeof(UserResponseModelList));
                using (StringReader reader = new(soapConfig.XML))
                {
                    userList.Add((UserResponseModelList)serializer.Deserialize(reader));
                }
            }
            return userList; 
        }

        public async Task<IEnumerable<UserResponseModel>> GetSoapConfigByIdAsync(int ID)
        {
           SoapConfig requiredSoapConfig = await _soapConfigRepository.GetSoapConfigByIdAsync(ID)??throw new Exception("SoapConfig not found");
           UserResponseModelList userList = new(); 

           XmlSerializer serializer = new(typeof(UserResponseModelList)); 
           using(StringReader reader = new(requiredSoapConfig.XML))
            {
                userList = (UserResponseModelList)serializer.Deserialize(reader);
            }
            return userList.Users; 
        }

        public async Task<int> AddSoapConfigAsync(SoapConfigRequest soapConfig)
        {
            SoapConfig? soapConfigToAdd = _mapper.Map<SoapConfig>(soapConfig);
            SoapConfig? addedSoapConfig = await _soapConfigRepository.AddSoapConfigAsync(soapConfigToAdd);
            if (addedSoapConfig == null) throw new Exception("bad request");
            else return 1; 
        }

        public async Task<int> DeleteSoapConfigAsync(int ID)
        {
            SoapConfig soapConfigToBeDeleted = await _soapConfigRepository.DeleteSoapConfigAsync(ID);
            if (soapConfigToBeDeleted == null) throw new Exception("soapConfig not found");
            else return 1; 
        }

        public async Task<int> UpdateSoapConfigAsync(SoapConfigRequest soapConfig)
        {
            SoapConfig soapConfigToBeUpdated = _mapper.Map<SoapConfig>(soapConfig); 
            SoapConfig updatedSoapConfig = await _soapConfigRepository.UpdateSoapConfigAsync(soapConfigToBeUpdated);
            if (updatedSoapConfig == null) throw new Exception("soapConfig not found");
            else return 1; 
        }
    }
}
