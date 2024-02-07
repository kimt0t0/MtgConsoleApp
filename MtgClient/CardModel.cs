using System.Text.Json;

namespace MtgClient;

public class CardModel
{
    public required string Id { get; set; }
    public string? Oracle_Id { get; set; }
    public int? Mtgo_Id { get; set; }
    public int? TcgPlayer_Id { get; set; }
    public int? CardMarket_Id { get; set; }
    public required string Name { get; set; }
    public string? Lang { get; set; }
    public required string Released_At { get; set; }
    public string? Uri { get; set; }
    public Dictionary<string, string>? Image_Uris { get; set; }
    // expect "small", "normal", "large"
    public string? Mana_Cost { get; set; }
    // cmc is commented because its format seemed to be uncompatible with int32
    // public int? Cmc { get; set; }
    public required string Type_Line { get; set; }
    public string? Oracle_Text { get; set; }
    public string? Power { get; set; }
    public string? Toughness { get; set; }
    public List<string>? Colors { get; set; }
    public List<string>? Color_Identity { get; set; }

    public Dictionary<string, string>? Legalities { get; set; }
    // expect "modern", "legacy", "commander", "duel"
    public bool? Reserved { get; set; }
    public string? Set_Id { get; set; }
    public string? Set_Name { get; set; }
    public string? Set_Uri { get; set; }
    public string? Set_Search_Uri { get; set; }
    public string? Rulings_Uri { get; set; }
    public required string Rarity { get; set; }
    public string? Artist { get; set; }
    public List<string>? Artist_Ids { get; set; }
    public string? Illustration_Id { get; set; }
    public Dictionary<string, string>? Prices { get; set; }
    // expect "usd", "eur"
    public Dictionary<string, string>? Related_Uris { get; set; }
    // expect "gatherer", "tcgplayer_infinite_articles", "tcgplayer_infinite_decks","edhrec"
    public Dictionary<string, string>? Purchase_Uris { get; set; }
    // expect "tcgplayer", "cardmarket", "cardhoarder"

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}