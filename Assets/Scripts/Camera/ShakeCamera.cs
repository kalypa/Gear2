using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShakeCamera : MonoSingleton<ShakeCamera>
{
    private Vector3 originalPosition;
    private float shakeDuration = 0f; 
    private float shakeMagnitude = 0.15f; 
    public bool isShaking = false;

    private void Update() => ShakingCamera();

    public void Shake() //ī�޶� ���� �ð� ����
    {
        shakeDuration = 0.5f; 
    }

    void ShakingCamera() //ī�޶� ����
    {
        if (shakeDuration > 0)
        {
            originalPosition = transform.position;
            isShaking = true;
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            if (isShaking) transform.position = originalPosition;
            isShaking = false;
            shakeDuration = 0f;
        }
    }
}
