using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Transform target;
    private void Update() => SetPos();

    void SetPos() //위치 세팅
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        healthSlider.transform.position = screenPos + new Vector3(0, 70f, 0);
    }
    public void SetHealth(float currentHealth, float maxHealth) //몬스터 체력바 체력 설정
    {
        healthSlider.value = currentHealth;
        healthSlider.maxValue = maxHealth;
    }
}
