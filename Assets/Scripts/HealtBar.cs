using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.2f;
    [SerializeField]
    private float criticalAmount = 0.5f;

    private int maxHealth = 0;
    
    private IHealth health;

    // Start is called before the first frame update
    private void Awake()
    {
        health = GetComponentInParent<IHealth>();
        health.OnMaxHealthChanged += HandleMaxHealthChanged;
        health.OnHealthPCTChanged += HandleHealthChanged;
    }

    private void HandleMaxHealthChanged(int mHealth)
    {
        maxHealth = mHealth;
        HandleHealthChanged(maxHealth);
    }

    private void HandleHealthChanged(int currentHealth)
    {
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        StartCoroutine(changeToPct(currentHealthPct));
    }

    private IEnumerator changeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;



        while(elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            float amount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            foregroundImage.fillAmount = amount;
            if (amount < criticalAmount)
                foregroundImage.color = Color.red;
            yield return null;
        }
        foregroundImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void OnDestroy()
    {
        health.OnMaxHealthChanged -= HandleMaxHealthChanged;
        health.OnHealthPCTChanged -= HandleHealthChanged;
    }
}
