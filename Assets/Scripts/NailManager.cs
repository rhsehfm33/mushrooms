using UnityEngine;
using System;

public class NailManager : MonoBehaviour
{
    public static NailManager Instance { get; private set; }
    public event Action OnNailSelectEvent;
    private GameObject _selectedNail;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

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
