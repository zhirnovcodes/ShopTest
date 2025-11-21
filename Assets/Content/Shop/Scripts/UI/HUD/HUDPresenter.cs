public class HUDPresenter
{
    private readonly IPlayerAllData PlayerAllData;
    private readonly HUDView View;
    private readonly IPlayerDataObserver DataObserver;
    private readonly IPlayerData PlayerData;

    public HUDPresenter(IPlayerAllData playerAllData, HUDView view, IPlayerDataObserver dataObserver, IPlayerData playerData)
    {
        PlayerAllData = playerAllData;
        View = view;
        DataObserver = dataObserver;
        PlayerData = playerData;
    }

    public void Enable()
    {
        View.Enable();
        View.AddButtonClicked += HandleAddClicked;
        AddCards();

        DataObserver.DataChanged += HandleDataChanged;
    }

    public void Disable()
    {
        View.AddButtonClicked -= HandleAddClicked;
        View.Disable();
        DataObserver.DataChanged += HandleDataChanged;
    }

    private void HandleAddClicked(int itemIndex)
    {
        int index = 0;

        foreach (var element in PlayerAllData.GetAllData())
        {
            if (itemIndex == index)
            {
                element.TestAdd();
                break;
            }
            index++;
        }

        PlayerData.Update();
    }

    private void AddCards()
    {
        int index = 0;
        foreach (var element in PlayerAllData.GetAllData())
        {
            View.AddElement(index, element.GetName());
            View.SetValue(index, element.GetStringValue());
            index++;
        }
    }

    private void UpdateAllValues()
    {
        int index = 0;
        foreach (var element in PlayerAllData.GetAllData())
        {
            var value = element.GetStringValue();
            View.SetValue(index, value);
            index++;
        }
    }

    private void HandleDataChanged()
    {
        UpdateAllValues();
    }
}