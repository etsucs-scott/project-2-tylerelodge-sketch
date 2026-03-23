namespace WarGame.Core;

public class RoundResult
{
    public Dictionary<string, Card> PlayedCards { get; set; } = new();
    public List<string> RoundWinners { get; set; } = new();
    public bool IsTie => RoundWinners.Count > 1;
    public string? FinalWinner { get; set; }
    public Dictionary<string, int> CardCounts { get; set; } = new();
}