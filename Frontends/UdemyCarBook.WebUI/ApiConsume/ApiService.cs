using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ApiService
{
    private readonly HttpClient _httpClient; 

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }
    public async Task<T> GetApiAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    public async Task PostApiAsync<T>(string url,T data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        StringContent stringcontent = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var responseMessage = await _httpClient.PostAsync(url,stringcontent);
        var responseString = await responseMessage.Content.ReadAsStringAsync();
        responseMessage.EnsureSuccessStatusCode();
    }

    public async Task RemoveApiAsync(string url)
    {
        var responseMessage = await _httpClient.DeleteAsync(url);
        var responseString = await responseMessage.Content.ReadAsStringAsync();
        responseMessage.EnsureSuccessStatusCode();
    }

    public async Task PutApiAsync<T>(string url, T dto)
    {
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await _httpClient.PutAsync(url, stringcontent);
        var responseString = await responseMessage.Content.ReadAsStringAsync();
        responseMessage.EnsureSuccessStatusCode();
    }

    public async Task ExecuteApiAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
    }
}
