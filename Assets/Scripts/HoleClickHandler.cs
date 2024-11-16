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

    public void PutNailHere()
    {
        GameObject selectedNail = NailManager.Instance.GetSelectedNail();
        if (selectedNail != null)
        {
            selectedNail.transform.SetParent(gameObject.transform, false);
            NailManager.Instance.SelectNail(null);
        }
    }

    private void OnMouseDown()
    {
        if (CanPutNail())
        {
            Debug.Log("못을 박을 수 있습니다!");
            PutNailHere();
        }
    }
}