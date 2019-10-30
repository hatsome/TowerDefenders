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
    
    private IHealth health;

    // Start is called before the first frame update
    private void Awake()
    {
        health = GetComponentInParent<IHealth>();
        health.OnHealthPCTChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(changeToPct(pct));
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
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    private void OnDestroy()
    {
        health.OnHealthPCTChanged -= HandleHealthChanged;
    }
}
