namespace WarGame.Core;

public class WarGame
{
    private readonly PlayerHands _playerHands = new();
    private readonly List<Card> _pot = new();
    private const int MAX_ROUNDS = 10000;

    public WarGame(List<string> players)
    {
        foreach (var player in players)
            _playerHands.AddPlayer(player);

        DealCards(players);
    }

    private void DealCards(List<string> players)
    {
        var deck = new Deck();
        int i = 0;

        while (deck.Count > 0)
        {
            var player = players[i % players.Count];
            _playerHands.Hands[player].AddToBottom(deck.Draw());
            i++;
        }
    }

    public RoundResult PlaySingleRound()
    {
        var result = new RoundResult();
        var active = _playerHands.ActivePlayers().ToList();

        if (active.Count <= 1)
        {
            result.FinalWinner = active.FirstOrDefault();
            return result;
        }

        var played = PlayRound(active);
        result.PlayedCards = played;

        ResolveRound(played, result);

        result.CardCounts = _playerHands.Hands
            .ToDictionary(h => h.Key, h => h.Value.Count);

        return result;
    }

    private Dictionary<string, Card> PlayRound(List<string> players)
    {
        var played = new Dictionary<string, Card>();

        foreach (var p in players)
        {
            var hand = _playerHands.Hands[p];
            if (hand.Count == 0) continue;

            var card = hand.PlayTopCard();
            played[p] = card;
            _pot.Add(card);
        }

        return played;
    }

    private void ResolveRound(Dictionary<string, Card> played, RoundResult result)
    {
        var highest = played.Values.Max(c => c.Rank);

        var winners = played
            .Where(p => p.Value.Rank == highest)
            .Select(p => p.Key)
            .ToList();

        result.RoundWinners = winners;

        if (winners.Count == 1)
        {
            AwardPot(winners[0]);
        }
        else
        {
            HandleTie(winners);
        }
    }

    private void HandleTie(List<string> tiedPlayers)
    {
        var next = new Dictionary<string, Card>();

        foreach (var p in tiedPlayers)
        {
            var hand = _playerHands.Hands[p];
            if (hand.Count == 0) continue;

            var card = hand.PlayTopCard();
            next[p] = card;
            _pot.Add(card);
        }

        if (next.Count == 0) return;

        var highest = next.Values.Max(c => c.Rank);

        var winners = next
            .Where(p => p.Value.Rank == highest)
            .Select(p => p.Key)
            .ToList();

        if (winners.Count == 1)
            AwardPot(winners[0]);
        else
            HandleTie(winners);
    }

    private void AwardPot(string winner)
    {
        _playerHands.Hands[winner].AddToBottom(_pot);
        _pot.Clear();
    }
}