using System;
using UnityEngine;
using UnityEngine.UI;

public class CardSceneView : MonoBehaviour
{
    public event Action CloseClicked = () => { };

    public ShopCardView Card;
    public GameObject Content;
    public Button Close;

    public void Enable()
    {
        Content.SetActive(true);
        Card.Enable();

        Close.onClick.AddListener(HandleCloseClicked);
    }

    public void Disable()
    {
        Card.Disable();
        Content.SetActive(false);
        Close.onClick.RemoveListener(HandleCloseClicked);
    }

    public ShopCardView GetCard()
    {
        return Card;
    }

    private void HandleCloseClicked()
    {
        CloseClicked();
    }
}