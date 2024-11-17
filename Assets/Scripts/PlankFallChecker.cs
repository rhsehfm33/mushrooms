using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankFallChecker : MonoBehaviour
{
    [SerializeField]
    private PlankCounter _plankCounter;

    void Start()
    {
        _plankCounter.IncreaseNailedPlank();
    }

    void FixedUpdate()
    {
        if (transform.position.y <= -6f)
        {
            _plankCounter.DecreaseNailedPlank();
            Destroy(gameObject);
        }
    }
}
