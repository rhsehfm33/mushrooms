using UnityEngine;
using System;

public class NailManager : MonoBehaviour
{
    public static NailManager Instance { get; private set; }
    public event Action OnNailSelectEvent;
    public GameObject selectedNail;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SelectNail(GameObject nail)
    {
        selectedNail = nail;
        OnNailSelectEvent?.Invoke();
    }
}
