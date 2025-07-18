using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using OneApp_Web.Interfaces;
using oneAppWeb.Data;
using oneAppWeb.Data.DTOs;

namespace OneApp_Web.Services;

public class SettingsService : ISettingsService
{
    HttpClient _httpClient;
    JsonSerializerOptions _serializerOptions;
    private readonly IConfiguration _config;

    public SettingsService(IConfiguration config)
    {
        _httpClient = new HttpClient();

        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            NumberHandling =
                JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString,
            ReadCommentHandling = JsonCommentHandling.Skip
        };
        _config = config;
    }
    public async Task<IEnumerable<SettingDto>> GetSettingsList()
    {
        Uri uri = new Uri(string.Format($"{_config.GetSection("Uri").Value}api/v1/GetSettingFullList", string.Empty));


        var dataResponse = new ApiResponse<IEnumerable<SettingDto>>();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<SettingDto>>>(content, _serializerOptions);
                return dataResponse.Data;
            }

            return dataResponse.Data;
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"\tERROR {0}", ex.Message);

            return null;
        }
    }

    public async Task<SettingDto> CreateSetting(SettingDto setting)
    {
        Uri uri = new Uri(string.Format($"{_config.GetSection("Uri").Value}api/v1/AddSetting", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(uri, setting);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonSerializer.Deserialize<SettingDto>(content, _serializerOptions);
                return dataResponse;
            }

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"\tERROR {0}", ex.Message);

            return null;
        }
    }

    public async Task<bool> DeleteSetting(SettingDto setting)
    {
        Uri uri = new Uri(string.Format($"{_config.GetSection("Uri").Value}api/v1/DeleteSetting/{setting.Id}", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(uri, string.Empty);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonSerializer.Deserialize<bool>(content, _serializerOptions);
                return dataResponse;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"\tERROR {0}", ex.Message);

            return false;
        }
    }

    public async Task<SettingDto> UpadateSetting(SettingDto setting)
    {
        Uri uri = new Uri(string.Format($"{_config.GetSection("Uri").Value}api/v1/UpdateSetting/{setting.Id}", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(uri, setting);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonSerializer.Deserialize<SettingDto>(content, _serializerOptions);
                return dataResponse;
            }

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"\tERROR {0}", ex.Message);

            return null;
        }
    }
}