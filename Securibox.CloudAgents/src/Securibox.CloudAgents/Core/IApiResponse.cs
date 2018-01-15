namespace Securibox.CloudAgents.Core
{
    public interface IApiResponse
    {
        string GetBodyContent();
        System.Net.HttpStatusCode GetStatusCode();
        string GetResponseMessage();
    }
}
