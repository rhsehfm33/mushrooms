using UnityEngine;
using System;

public class NailManager : MonoBehaviour
{
    public event Action OnNailSelectEvent;
    private GameObject _selectedNail;

    public GameObject GetSelectedNail()
    {
        return _selectedNail;
    }

    public void SelectNail(GameObject nail)
    {
        _selectedNail = nail;
        OnNailSelectEvent?.Invoke();
    }
}
