using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HoleClickHandler : MonoBehaviour
{
    private Collider2D myCollider;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    // 못을 넣을 수 있는지 체크
    public bool CanPutNail()
    {
        // 감지된 Collider를 저장할 배열
        Collider2D[] colliders = new Collider2D[10]; // 최대 10개까지 감지
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Nail", "Plank1"));
        int nailAndPlankCount = myCollider.OverlapCollider(filter, colliders);
        return nailAndPlankCount == 0;
    }

    // 못을 뺄 수 있는지 체크
    public bool CanPickNail()
    {
        // 감지된 Collider를 저장할 배열
        Collider2D[] colliders = new Collider2D[1]; // 최대 1개까지 감지
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Nail"));
        int nailCount = myCollider.OverlapCollider(filter, colliders);
        return nailCount == 1;
    }

    private void OnMouseDown()
    {
        if (CanPutNail())
        {
            Debug.Log("못을 박을 수 있습니다!");
        }
        if (CanPickNail())
        {
            Debug.Log("못을 뺄 수 있습니다!");
        }
    }
}
