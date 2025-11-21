using System;

public interface IPlayerDataChangeHandler
{
    event Action DataChanged;
}

