using System.Net.Http.Headers;

namespace MtgClient;

public class Client
{
    public HttpClient httpClient;
    public string Api;

    public Client()
    {
        this.httpClient = new HttpClient();
        this.Api = "https://api.scryfall.com";
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        httpClient.DefaultRequestHeaders.Add("Page-Size", "10");
        httpClient.DefaultRequestHeaders.Add("Count", "10");
    }


    // public static bool StartsWithUpper(this string? str)
    // {
    //     if (string.IsNullOrWhiteSpace(str))
    //         return false;

    //     char ch = str[0];
    //     return char.IsUpper(ch);
    // }
}
