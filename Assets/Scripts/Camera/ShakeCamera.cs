using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShakeCamera : MonoSingleton<ShakeCamera>
{
    private Vector3 originalPosition; // ī�޶� ���� ��ġ
    private float shakeDuration = 0f; // ��鸲 ���� �ð�
    private float shakeMagnitude = 0.2f; // ��鸲�� ũ��
    public bool isShaking = false;

    private void Update()
    {
        if (shakeDuration > 0)
        {
            originalPosition = transform.position;
            isShaking = true;
            // �������� ī�޶� ��ġ�� ����
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            // shakeDuration�� �ٿ����� ��鸲 ȿ���� ������ ������� ��
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            if(isShaking) transform.position = originalPosition;
            isShaking = false;
            shakeDuration = 0f;
        }
    }

    // �ܺο��� ȣ���Ͽ� ī�޶� ��鵵�� �ϴ� �Լ�
    public void Shake()
    {
        Debug.Log("ī�޶� ����");
        shakeDuration = 0.5f; // ��鸲 ���� �ð�
    }
}
