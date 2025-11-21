using System;
using System.Collections.Generic;
using UnityEngine;

public class HUDView : MonoBehaviour
{
    public event Action<int> AddButtonClicked = (int index) => { };

    public GameObject Content;
    public Transform ItemParent;
    public HUDElementView Prefab;

    private List<HUDElementView> Elements = new List<HUDElementView>();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Enable()
    {
        Content.SetActive(true);
    }

    public void Disable()
    {
        Content.SetActive(false);
        foreach (var element in Elements)
        {
            element.Disable();
            Destroy(element.gameObject);
        }
        Elements.Clear();
    }

    public void AddElement(int index, string name)
    {
        var element = Instantiate(Prefab);
        element.transform.SetParent(ItemParent, false);
        element.SetIndex(index);
        element.SetName(name);
        element.AddClicked += HandleAddClicked;
        element.Enable();
        Elements.Add(element);
    }

    public void SetValue(int index, string value)
    {
        var element = Elements[index];
        element.SetValue(value);
    }

    private void HandleAddClicked(int index)
    {
        AddButtonClicked.Invoke(index);
    }
}