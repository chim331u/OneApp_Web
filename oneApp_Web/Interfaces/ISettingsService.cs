using oneAppWeb.Data;
using oneAppWeb.Data.DTOs;

namespace OneApp_Web.Interfaces;

public interface ISettingsService
{
    Task<IEnumerable<SettingDto>> GetSettingsList();
    Task<SettingDto> CreateSetting(SettingDto setting);
    Task<bool> DeleteSetting(SettingDto setting);
    Task<SettingDto> UpadateSetting(SettingDto setting);
}