using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public GameObject healthUIPrefab;
    public Transform target;

    private Transform ui;
    private Image healthSlider;
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
        SpawnHealthUI();
    }

    public void SpawnHealthUI()
    {
        foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            if (c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(healthUIPrefab, c.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                break;
            }
        }
        GetComponent<BaseCharacterHealth>().HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(float maxHealth, float currentHealth)
    {
        if (ui == null) return;
        float healthPercent = currentHealth / maxHealth;
        healthSlider.fillAmount = healthPercent;
        if (currentHealth <= 0)
        {
            Destroy(ui.gameObject);
        }

    }

    private void LateUpdate()
    {
        if (ui == null) return;
        ui.position = target.position + offset;
        ui.rotation = cam.transform.rotation;
    }
}
