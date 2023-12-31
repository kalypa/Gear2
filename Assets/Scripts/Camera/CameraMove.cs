using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera() //플레이어 따라서 카메라 이동
    {
        if (target != null && !GetComponent<ShakeCamera>().isShaking)
        {
            Vector3 desiredPosition = target.position;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            smoothedPosition.y = Mathf.Clamp(desiredPosition.y, -6f, 0.1f);
            smoothedPosition.x = Mathf.Clamp(desiredPosition.x, -17f, 17f);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
