using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCardView : MonoBehaviour
{
    public event Action<int> BuyButtonClicked = (int index) => { };
    public event Action<int> InfoButtonClicked = (int index) => { };

    public GameObject Content;
    public Button BuyButton;
    public Button InfoButton;
    public TextMeshProUGUI Text;
    public Image WaitingImage;

    private int Index;

    public void Enable()
    {
        Content.SetActive(true);
        BuyButton.onClick.AddListener(HandleBuyButtonClicked);
        InfoButton.onClick.AddListener(HandleInfoButtonClicked);
    }

    public void Disable()
    {
        Content.SetActive(false);
        BuyButton.onClick.RemoveListener(HandleBuyButtonClicked);
        InfoButton.onClick.RemoveListener(HandleInfoButtonClicked);
    }

    public void SetIndex(int index)
    {
        Index = index;
    }

    public void SetName(string name)
    {
        Text.text = name;
    }

    public void SetBuyClickable()
    {
        BuyButton.interactable = true;
    }

    public void SetBuyUnlickable()
    {
        BuyButton.interactable = false;
    }

    public void SetBuy()
    {
        BuyButton.gameObject.SetActive(true);
        WaitingImage.gameObject.SetActive(false);
    }

    public void SetWaiting()
    {
        BuyButton.gameObject.SetActive(false);
        WaitingImage.gameObject.SetActive(true);
    }

    public void ShowInfoButton()
    {
        InfoButton.gameObject.SetActive(true);
    }

    public void HideInfoButton()
    {
        InfoButton.gameObject.SetActive(false);
    }

    private void HandleBuyButtonClicked()
    {
        BuyButtonClicked.Invoke(Index);
    }

    private void HandleInfoButtonClicked()
    {
        InfoButtonClicked.Invoke(Index);
    }
}