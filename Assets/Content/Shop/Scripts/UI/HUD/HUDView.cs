using System;
using System.Collections.Generic;
using UnityEngine;

public class HUDView : MonoBehaviour
{
    public event Action<int> AddButtonClicked = (int index) => { };

    public HUDElementView Prefab;

    private List<HUDElementView> Elements = new List<HUDElementView>();

    public void Enable()
    {

    }

    public void Disable()
    {

    }

    public void AddElement(string name)
    {

    }

    public void SetValue (int index, string value)
    {

    }
}
