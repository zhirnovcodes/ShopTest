using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDElementView : MonoBehaviour
{
    public event Action<int> AddClicked = (int index) => { };

    public GameObject Content;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI ValueText;
    public Button AddButton;

    private int Index;

    public void Enable()
    {
        Content.SetActive(true);
        AddButton.onClick.AddListener(HandleAddButtonClicked);
    }

    public void Disable()
    {
        Content.SetActive(false);
        AddButton.onClick.RemoveListener(HandleAddButtonClicked);
    }

    public void SetIndex(int index)
    {
        Index = index;
    }

    public void SetName(string name)
    {
        NameText.text = name;
    }

    public void SetValue(string value)
    {
        ValueText.text = value;
    }

    private void HandleAddButtonClicked()
    {
        AddClicked.Invoke(Index);
    }
}