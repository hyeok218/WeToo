using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cshFPCameraMobile : MonoBehaviour, IDragHandler
{
    public Transform targetObjTrans;

    public float xAngle = 0f;
    public float yAngle = 0f;

    public void OnDrag(PointerEventData eventData)
    {
        xAngle += eventData.delta.x * Time.deltaTime * 4f;
        yAngle += eventData.delta.y * Time.deltaTime * 4f;

        //xAngle = Mathf.Clamp(xAngle, -80, 80);

        targetObjTrans.eulerAngles = new Vector3(yAngle, xAngle, 0);
    }

}
