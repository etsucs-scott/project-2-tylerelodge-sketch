using System;
using System.Collections.Generic;

namespace WarGame.Core;

public class Deck
{
    private Stack<Card> _cards;
    private static readonly Random _random = new();

    public int Count => _cards.Count;

    public Deck()
    {
        Initialize();
        Shuffle();
    }

    private void Initialize()
    {
        var temp = new List<Card>();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                temp.Add(new Card(suit, rank));
            }
        }

        _cards = new Stack<Card>(temp);
    }

    public void Shuffle()
    {
        var list = new List<Card>(_cards);
        _cards.Clear();

        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }

        _cards = new Stack<Card>(list);
    }

    public Card Draw()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException("Deck is empty");

        return _cards.Pop();
    }
}