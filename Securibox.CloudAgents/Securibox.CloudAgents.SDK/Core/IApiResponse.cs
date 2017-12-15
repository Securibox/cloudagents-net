namespace Securibox.CloudAgents.SDK.Core
{
    public interface IApiResponse
    {
        string GetBodyContent();
        System.Net.HttpStatusCode GetStatusCode();
        string GetResponseMessage();
    }
}
