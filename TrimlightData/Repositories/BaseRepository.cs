using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace TrimlightData.Repositories;
public abstract class BaseRepository
{
    private const string BASE_URL = "https://trimlight.ledhue.com/trimlight/v1/oauth/resources/";
    protected readonly string ClientId;
    protected readonly string ClientSecret;

    public BaseRepository(string clientId, string clientSecret)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    protected async Task<T> GetTrimlightDataAsync<T>(string url)
    {
        var client = sharedClient;
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        Dictionary<string, string> headers = BuildHeaders();
        foreach (var header in headers)
        {
            if (string.Equals(header.Key, "authorization", StringComparison.OrdinalIgnoreCase))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(header.Value);
            }
            else
            {
                request.Headers.Add(header.Key, header.Value);
            }

            request.Headers.Add(header.Key, header.Value);
        }

        var httpResponse = await client.SendAsync(request);
        httpResponse.EnsureSuccessStatusCode();

        var response = await httpResponse.Content.ReadFromJsonAsync<PagedResponse<T>>();
        if (response?.Code == ResultCode.Success && response?.Payload != null && response.Payload.Data != null)
        {
            return response.Payload.Data;
        }

        throw new InvalidDataException(string.Format("Error calling Trimlight service {0}. Error {1]: {2}", httpResponse.RequestMessage.RequestUri, response.Code, response.Desc));
    }

    protected async Task<T> PostTrimlightDataAsync<T>(string url, object requestPayload)
    {
        var content = JsonContent.Create(requestPayload);

        var client = sharedClient;
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = content
        };

        Dictionary<string, string> headers = BuildHeaders();
        foreach (var header in headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }

        var httpResponse = await client.SendAsync(request);
        httpResponse.EnsureSuccessStatusCode();

        var response = await httpResponse.Content.ReadFromJsonAsync<PagedResponse<T>>();
        if (response?.Code == ResultCode.Success && response.Payload != null && response.Payload.Data != null)
        {
            return response.Payload.Data;
        }

        throw new InvalidDataException(string.Format("Error calling Trimlight service {0}. Error {1]: {2}", httpResponse.RequestMessage.RequestUri, response.Code, response.Desc));
    }

    protected async Task PostTrimlightDataAsync(string url, object requestPayload)
    {
        var content = JsonContent.Create(requestPayload);

        var client = sharedClient;
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = content
        };

        Dictionary<string, string> headers = BuildHeaders();
        foreach (var header in headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }

        var httpResponse = await client.SendAsync(request);
        httpResponse.EnsureSuccessStatusCode();

        var response = await httpResponse.Content.ReadFromJsonAsync<Response>();
        if (response?.Code == ResultCode.Success)
        {
            return;
        }

        throw new InvalidDataException(string.Format("Error calling Trimlight service {0}. Error {1]: {2}", httpResponse.RequestMessage.RequestUri, response.Code, response.Desc));
    }

    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri(BASE_URL),
    };

    private Dictionary<string, string> BuildHeaders()
    {
        // 1.Concatenate strings: "Trimlight|<S-ClientId>|<S-Timestamp>"
        // 2.Compute the HMAC-SHA256 of the string concatenated in step 1.The secret key for HMAC - SHA256 is clientSecret.
        // 3.The value of the accessToken is the base64 encoding of the computed HMAC - SHA256 value.
        // for example, "Trimlight|tester|1713166849256"

        TimeSpan elapsedTime = DateTime.Now - new DateTime(1970, 1, 1);
        string accessString = "Trimlight|" + this.ClientId + "|" + Convert.ToInt64(elapsedTime.TotalMilliseconds).ToString();
        string accessToken = accessString.HMACSHA256Hash(this.ClientSecret);

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("authorization", accessToken);
        headers.Add("S-ClientId", this.ClientId);
        headers.Add("S-Timestamp", Convert.ToInt64(elapsedTime.TotalMilliseconds).ToString());
        return headers;
    }
}
