using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankFallChecker : MonoBehaviour
{
    void Start()
    {
        PlankCounter.Instance.IncreaseNailedPlank();
    }

    void FixedUpdate()
    {
        if (transform.position.y <= -6f)
        {
            PlankCounter.Instance.DecreaseNailedPlank();
            Destroy(gameObject);
        }
    }
}
