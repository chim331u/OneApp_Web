using OneApp_Web.Data.DTOs;
using OneApp_Web.Data.DTOs.DockerDeployDTOs;
using oneAppWeb.Data.DTOs;
using oneAppWeb.Data.DTOs.DockerDeployDTOs;

namespace OneApp_Web.Interfaces;

public interface IDockerDeployService
{
    string GetRestUrl();
    Task<List<DockerConfigListDto>> GetActiveDockerConfigList();
    Task<DockerConfigsDto?> GetDockerConfig(int id);
    Task<DockerConfigsDto> UpdateConfig(DockerConfigsDto dockerConfig);
    Task<DockerConfigsDto> AddConfig(DockerConfigsDto dockerConfig);
    Task<bool> DeleteConfig(int dockerConfigId);
    Task<List<DeployDetailDto>> GetDeployDetailList(string dockerConfigId);
    Task<List<SettingListDto>> GetSettingsList();
        
    Task<DeployDetailDto> GetDeployDetail(int deployDetailId);
    Task<string> RunDeploy(int dockerConfigId);
    Task<string> GetDockerFile(DockerConfigsDto dockerConfig);

    Task<DeployDetailDto> UpdateDeployDetail(int id, string result);
    Task<DockerCommandResponse<string>> SendCommand(int id, string command);
    
    Task<string> GetRunningContainerCommand();
    Task<string> GetImagesCommand();
    Task<DockerCommandResponse<string>> GetBuildCommand(int id);
    Task<DockerCommandResponse<string>> GetRunDockerCommand(int id);
    Task<DockerCommandResponse<string>> CreateDockerFile(int id);
    Task<List<DockerParameterDto>> GetParametersList(int dockerConfigId);
    Task<DockerParameterDto> AddParameter(DockerParameterDto dockerParameterDto);
    Task<DockerParameterDto> UpdateParameter(int dockerParameterId, DockerParameterDto dockerParameter);
    Task<bool> DeleteParameter(int dockerParameterId);
}