namespace WarGame.Core;

public class PlayerHands
{
    public Dictionary<string, Hand> Hands { get; } = new();

    public void AddPlayer(string name)
    {
        Hands[name] = new Hand();
    }

    public IEnumerable<string> ActivePlayers()
    {
        return Hands.Where(h => h.Value.Count > 0)
                    .Select(h => h.Key);
    }
}