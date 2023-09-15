using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShakeCamera : MonoSingleton<ShakeCamera>
{
    private Vector3 originalPosition; // 카메라 원래 위치
    private float shakeDuration = 0f; // 흔들림 지속 시간
    private float shakeMagnitude = 0.2f; // 흔들림의 크기
    public bool isShaking = false;

    private void Update()
    {
        if (shakeDuration > 0)
        {
            originalPosition = transform.position;
            isShaking = true;
            // 무작위로 카메라 위치를 흔들기
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            // shakeDuration을 줄여가며 흔들림 효과를 서서히 사라지게 함
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            if(isShaking) transform.position = originalPosition;
            isShaking = false;
            shakeDuration = 0f;
        }
    }

    // 외부에서 호출하여 카메라를 흔들도록 하는 함수
    public void Shake()
    {
        Debug.Log("카메라 흔들기");
        shakeDuration = 0.5f; // 흔들림 지속 시간
    }
}
