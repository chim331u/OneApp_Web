using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using OneApp_Web.Data.DTOs;
using OneApp_Web.Data.DTOs.FileCategorizationDTOs;
using OneApp_Web.Interfaces;

namespace OneApp_Web.Services;

public class FileCategorizationServices : IFileCategorizationService
{
    HttpClient _httpClient;
    JsonSerializerOptions _serializerOptions;
    private readonly IConfiguration _config;

    public FileCategorizationServices(IConfiguration config)
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

    #region File Detail

    public async Task<string> RefreshCategory()
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/RefreshFiles", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<List<string>> GetCategoryList()
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/CategoryList", string.Empty));

        var dataResponse = new List<string>();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<List<string>>(content, _serializerOptions);
            }

            return dataResponse;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    //public async Task<List<FilesDetailDto>> GetFileList(int searchPar)
    //{
    //    Uri uri = new Uri(string.Format(GetRestUrl() + $"api/GetFileList/{searchPar}", string.Empty));

    //    var dataResponse = new List<FilesDetailDto>();

    //    try
    //    {
    //        HttpResponseMessage response = await _httpClient.GetAsync(uri);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            string content = await response.Content.ReadAsStringAsync();
    //            dataResponse = JsonSerializer.Deserialize<List<FilesDetailDto>>(content, _serializerOptions);
    //        }

    //        return dataResponse;

    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
    //        return null;
    //    }

    //}

    //v1
    public async Task<List<FilesDetailDto>> GetFileListDto(int searchPar)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/GetFileList/{searchPar}", string.Empty));

        var dataResponse = new List<FilesDetailDto>();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<List<FilesDetailDto>>(content, _serializerOptions);
            }

            return dataResponse;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<FilesDetailDto> UpdateFileDetail(FilesDetailDto item)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/UpdateFilesDetail/{item.Id}", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(uri, item);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonSerializer.Deserialize<FilesDetailDto>(content, _serializerOptions);
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

    #endregion


    #region Config

    public async Task<List<ConfigsDto>> GetConfigList()
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/GetConfigList", string.Empty));

        var dataResponse = new List<ConfigsDto>();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<List<ConfigsDto>>(content, _serializerOptions);
            }

            return dataResponse;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<ConfigsDto> GetConfig(int id)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/GetConfig/{id}", string.Empty));

        var dataResponse = new ConfigsDto();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<ConfigsDto>(content, _serializerOptions);
            }

            return dataResponse;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<ConfigsDto> UpdateConfig(ConfigsDto item)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/UpdateConfig", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(uri, item);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonSerializer.Deserialize<ConfigsDto>(content, _serializerOptions);
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

    public async Task<ConfigsDto> AddConfig(ConfigsDto item)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/AddConfig", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(uri, item);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonSerializer.Deserialize<ConfigsDto>(content, _serializerOptions);
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

    public async Task<ConfigsDto> DeleteConfig(ConfigsDto item)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/DeleteConfig", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(uri, item);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var dataResponse = JsonSerializer.Deserialize<ConfigsDto>(content, _serializerOptions);
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

    #endregion

    #region Last View

    public async Task<List<FilesDetailDto>> GetLastFilesList()
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/GetLastViewList", string.Empty));

        var dataResponse = new List<FilesDetailDto>();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<List<FilesDetailDto>>(content, _serializerOptions);
            }

            return dataResponse;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<List<FilesDetailDto>> GetAllFiles(string fileCategory)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/GetAllFiles/{fileCategory}", string.Empty));

        var dataResponse = new List<FilesDetailDto>();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<List<FilesDetailDto>>(content, _serializerOptions);
            }

            return dataResponse;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    #endregion

    #region Service

    public async Task<string> TrainModel()
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/TrainModel", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<string> ForceCategory()
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/ForceCategory", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }


    public async Task<List<FilesDetailDto>> GetFileToMove()
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/GetFileToMove", string.Empty));

        var dataResponse = new List<FilesDetailDto>();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dataResponse = JsonSerializer.Deserialize<List<FilesDetailDto>>(content, _serializerOptions);
            }

            return dataResponse;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<string> MoveFile(int id, string category)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/MoveFile/{id}/{category}", string.Empty));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    public async Task<string> MoveFiles(List<FilesDetailDto> filesToMove)
    {
        Uri uri = new Uri(string.Format(GetRestUrl() + $"api/v1/MoveFiles", string.Empty));

        try
        {
            var fileToMoveDto = filesToMove
                .Select(fileToMove => new FileMoveDto() { FileCategory = fileToMove.FileCategory, Id = fileToMove.Id })
                .ToList();


            if (fileToMoveDto == null || fileToMoveDto.Count == 0)
            {
                return "No files to move";
            }

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(uri, fileToMoveDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }

    //todo write config app.json
    private ICollection<LocalSettings> GetSettings()
    {
        string path = $"settings.json";

        var jsonResult = File.ReadAllText(path);

        var result = JsonSerializer.Deserialize<ICollection<LocalSettings>>(jsonResult);

        return result;
    }

    public string GetRestUrl()
    {
        var uri = _config.GetSection("Uri").Value;
        return uri;
    }

    #endregion
}