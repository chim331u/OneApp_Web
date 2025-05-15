using Deployer_Web.Data.Enum;

namespace OneApp_Web.Data.DTOs;

public class SettingListDto
{
    public int Id { get; set; }
    public string? Alias { get; set; }
    public SettingType? Type { get; set; }
}