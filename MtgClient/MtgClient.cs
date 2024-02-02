using System.Net.Http.Headers;

namespace MtgClient;

public class Client
{
    public HttpClient httpClient;
    public string Api;

    public Client()
    {
        this.Api = "https://api.scryfall.com";
        this.httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        httpClient.DefaultRequestHeaders.Add("Page-Size", "10");
        httpClient.DefaultRequestHeaders.Add("Count", "10");
    }

    public async Task<string> ReadCard(string blob)
    {
        var card = await this.httpClient.GetStringAsync(this.Api + $"/cards/{blob}");
        return card;
    }


    // public static bool StartsWithUpper(this string? str)
    // {
    //     if (string.IsNullOrWhiteSpace(str))
    //         return false;

    //     char ch = str[0];
    //     return char.IsUpper(ch);
    // }
}
