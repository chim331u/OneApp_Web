using oneAppWeb.Data.Enum;

namespace oneAppWeb.Data.DTOs;

/// <summary>
/// Represents a Data Transfer Object (DTO) for settings.
/// </summary>
public class SettingDto
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Password { get; set; }

    public string? Alias { get; set; }

    public string? Address { get; set; } //https://hub.docker.com/

    public SettingType? Type { get; set; } //DD, Nas, DockerRegistry
    public string? DockerCommandPath { get; set; } //share/.../docker
    public string? DockerFilePath { get; set; } // /root/Dockerfile
    public string? Note { get; set; }
}