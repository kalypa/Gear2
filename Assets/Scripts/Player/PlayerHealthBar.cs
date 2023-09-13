using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthImage;

    void Start()
    {
        
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {
        healthImage.fillAmount = currentHealth / maxHealth;
    }
}
