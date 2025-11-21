using System.Collections.Generic;
using UnityEngine;

public class ShopBoardView : MonoBehaviour
{
    public ShopCardView ShopCardPrefab;

    public GameObject Content;
    public Transform CardsParent;

    private List<ShopCardView> Cards = new List<ShopCardView>();

    public void Enable()
    {
        Content.SetActive(true);
    }
    public void Disable()
    {
        Content.SetActive(false);

        var count = GetCardsCount();
        for (int i = 0; i < count; i++)
        {
            var button = Cards[Cards.Count - 1];
            Cards.RemoveAt(Cards.Count - 1);
            GameObject.Destroy(button.gameObject);
        }
    }

    public ShopCardView AddCard()
    {
        var go = GameObject.Instantiate(ShopCardPrefab.gameObject);
        var com = go.GetComponent<ShopCardView>();
        Cards.Add(com);
        go.transform.SetParent(CardsParent, false);
        return com;
    }

    public ShopCardView GetCard(int index)
    {
        return Cards[index];
    }

    public int GetCardsCount()
    {
        return Cards.Count;
    }
}
