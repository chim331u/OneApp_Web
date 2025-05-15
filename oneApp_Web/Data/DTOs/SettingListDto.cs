using oneAppWeb.Data.Enum;

namespace oneAppWeb.Data.DTOs;

public class SettingListDto
{
    public int Id { get; set; }
    public string? Alias { get; set; }
    public SettingType? Type { get; set; }
}