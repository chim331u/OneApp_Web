namespace oneAppWeb.Data.DTOs.DockerDeployDTOs;

public class DockerParameterDto
{
    public int Id { get; set; }
    public string ParameterName { get; set; }
    public string ParameterValue { get; set; }
    public bool CidData { get; set; } = false;
    public int DockerConfigId { get; set; }
    
}