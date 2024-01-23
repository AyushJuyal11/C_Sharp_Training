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
            IEnumerable<SoapConfig> allFiles = await _soapConfigRepository.GetAllSoapConfigsAsync();
            if(allFiles == null) { throw new Exception("There are no files currently "); }

            List<UserResponseModelList> userList = new(); 
            foreach(SoapConfig file in allFiles)
            {
                XmlSerializer serializer = new(typeof(UserResponseModelList));
                using (StringReader reader = new(file.XML))
                {
                    userList.Add((UserResponseModelList)serializer.Deserialize(reader));
                }
            }
            return userList; 
        }

        public async Task<IEnumerable<UserResponseModel>> GetSoapConfigByIdAsync(int ID)
        {
           SoapConfig requiredFile = await _soapConfigRepository.GetSoapConfigByIdAsync(ID)??throw new Exception("File not found");
           UserResponseModelList userList = new(); 

           XmlSerializer serializer = new(typeof(UserResponseModelList)); 
           using(StringReader reader = new(requiredFile.XML))
            {
                userList = (UserResponseModelList)serializer.Deserialize(reader);
            }
            return userList.Users; 
        }

        public async Task<int> AddSoapConfigAsync(SoapConfigRequest file)
        {
            SoapConfig? fileToAdd = _mapper.Map<SoapConfig>(file);
            SoapConfig? addedFile = await _soapConfigRepository.AddSoapConfigAsync(fileToAdd);
            if (addedFile == null) throw new Exception("bad request");
            else return 1; 
        }

        public async Task<int> DeleteSoapConfigAsync(int ID)
        {
            SoapConfig fileToBeDeleted = await _soapConfigRepository.DeleteSoapConfigAsync(ID);
            if (fileToBeDeleted == null) throw new Exception("file not found");
            else return 1; 
        }

        public async Task<int> UpdateSoapConfigAsync(SoapConfigRequest file)
        {
            SoapConfig fileToBeUpdated = _mapper.Map<SoapConfig>(file); 
            SoapConfig updatedFile = await _soapConfigRepository.UpdateSoapConfigAsync(fileToBeUpdated);
            if (updatedFile == null) throw new Exception("file not found");
            else return 1; 
        }
    }
}
