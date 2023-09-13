using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Transform target;
    public MonsterEvent monsterEvent;
    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        healthSlider.transform.position = screenPos + new Vector3(0, 70f, 0);
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {
        healthSlider.value = currentHealth;
        healthSlider.maxValue = maxHealth;
    }
}
