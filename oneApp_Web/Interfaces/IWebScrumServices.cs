using oneAppWeb.Data.DTOs.WebScrum;

namespace OneApp_Web.Interfaces;

public interface IWebScrumServices
{
    Task<List<ThreadsDto>> GetActiveThreads();
    Task<List<Ed2kLinkDto>> GetEd2kLinks(int threadId);
    Task<string> UseLink(int linkId);

    Task<bool> RenewThread(int threadId);
    Task<bool> CheckUrl(string urlToCheck);
}