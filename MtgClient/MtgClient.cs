using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Linq;

namespace MtgClient;

public class Client
{
    public static readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://api.scryfall.com/")
    };

    public async Task ReadRandomCards()
    {
        /*
        * The API developers ask us to insert 50-100 ms of delay between requests
        * (10 requests per second on average).
        * Excessive requests may result in a HTTP 429 Too many requests status code.
        */

        // Define tasks delayer:
        async Task<T> waitThen<T>(int milliseconds, Func<Task<T>> action, int id)
        {
            Console.WriteLine($"# Start timer with id {id}");
            await Task.Delay(milliseconds);
            var t = await action();
            Console.WriteLine($"# End timer with id {id}");
            return t;
        }

        async Task<CardModel?> getRandom()
        {
            try
            {
                var json = await _httpClient.GetStringAsync("cards/random");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var card = JsonSerializer.Deserialize<CardModel>(json, options);
                Console.WriteLine($"Carte lue: {card?.Name}");
                return card;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException caught !");
                Console.WriteLine("Message: {0} ", e.Message);
                return null;
            }
        }
        var tasks = new Task<CardModel?>[]
        {
                Task.Run(getRandom),
                Task.Run(() => waitThen(1000, getRandom, 1)),
                Task.Run(() => waitThen(1000, getRandom, 2)),
        };

        var cards = await Task.WhenAll(tasks);
        foreach (var card in cards.Where(x => x != null))
        {
            Console.WriteLine($"Carte lue: {card?.Name}");
        }

    }

    // public async Task<CardModel?[]> ReadRandomCards()
    // {
    //     // Initialize cards tasks list
    //     List<Task<CardModel?>> tasks = new List<Task<CardModel?>>();
    //     // Add tasks to list
    //     for (int i = 0; i < 3; i++)
    //     {
    //         tasks.Add(httpClient.GetFromJsonAsync<CardModel>(this.Api + "/cards/random"));
    //     }
    //     Console.WriteLine($"--- J'ai {tasks.Count()} tâches listées.");

    //     // Wait for tasks resolution and add results to cards list
    //     CardModel?[] loadedCards = await Task.WhenAll(tasks);

    //     Console.WriteLine($"--- La liste des cartes comporte {loadedCards.Count()} items");
    //     Console.WriteLine("Contenu de la liste des cartes:");

    //     // Print cards list
    //     foreach (var card in loadedCards)
    //     {
    //         Console.WriteLine($"CARTE: {card?.ToString()}");
    //     }

    //     return loadedCards;
    // }

}
