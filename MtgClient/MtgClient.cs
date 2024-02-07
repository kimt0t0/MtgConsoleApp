using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using System.Globalization;

namespace MtgClient;

public class Client
{
    public static readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://api.scryfall.com/")
    };

    public async Task<CardModel?[]?> ReadRandomCards()
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
                Task.Run(() => waitThen(100, getRandom, 2)),
                Task.Run(() => waitThen(100, getRandom, 3)),
                Task.Run(() => waitThen(100, getRandom, 4)),
                Task.Run(() => waitThen(100, getRandom, 5)),
                Task.Run(() => waitThen(100, getRandom, 6)),
                Task.Run(() => waitThen(100, getRandom, 7)),
                Task.Run(() => waitThen(100, getRandom, 8)),
                Task.Run(() => waitThen(100, getRandom, 9)),
                Task.Run(() => waitThen(100, getRandom, 10)),
        };

        CardModel?[]? cards = await Task.WhenAll(tasks);
        foreach (var card in cards.Where(x => x != null))
        {
            Console.WriteLine($"Carte lue: {card?.Name}");
        }
        return cards;
    }

    public IEnumerable<CardModel?> FilterCardsByType(string type, CardModel?[]? cards)
    {
        IEnumerable<CardModel?> FilteredCards =
        from card in cards
        where card.Type_Line.IndexOf(type, 0, StringComparison.OrdinalIgnoreCase) != -1
        select card;
        Console.WriteLine($"Cartes avec le type {type}:");
        foreach (var fcard in FilteredCards)
        {
            Console.WriteLine($"{fcard?.Name}");
        }
        return FilteredCards;
    }

}
