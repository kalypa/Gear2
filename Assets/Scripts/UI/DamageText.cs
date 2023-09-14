using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float floatSpeed = 1.0f;
    public float duration = 1.0f;

    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        TextEffect();
    }

    void TextEffect()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        Color textColor = text.color;
        textColor.a = Mathf.Lerp(1.0f, 0.0f, timer / duration);
        text.color = textColor;
    }

    public void SetText(string dmgText)
    {
        text.text = dmgText;
    }
}
