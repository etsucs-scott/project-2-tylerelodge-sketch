namespace WarGame.Core;

public class Hand
{
    private Queue<Card> _cards = new();

    public int Count => _cards.Count;

    public void AddToBottom(IEnumerable<Card> cards)
    {
        foreach (var card in cards)
            _cards.Enqueue(card);
    }

    public void AddToBottom(Card card)
    {
        _cards.Enqueue(card);
    }

    public Card PlayTopCard()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException("No cards left");

        return _cards.Dequeue();
    }
}