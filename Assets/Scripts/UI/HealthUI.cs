using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image[] imageRenderers;
   // [SerializeField] PlayerHealthController playerHealthController;
    List<Image> activeHealth = new List<Image>();
    List<Image> passiveHealth = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
       // playerHealthController.UpdateHealth += OnUpdatedHealth;
    }

    private void ResetHealth(){
        passiveHealth.Clear();
        foreach (var sprite in imageRenderers)
        {
            sprite.gameObject.SetActive(true);
            activeHealth.Add(sprite);
        }
    }
    public void DecreaseHealth(){
        if(activeHealth.Count == 0)return;
        Image healthSpriteRenderer = activeHealth[activeHealth.Count - 1];
        passiveHealth.Add(healthSpriteRenderer);
        activeHealth.RemoveAt(activeHealth.Count - 1);
        healthSpriteRenderer.gameObject.SetActive(false);
    }
    private void OnUpdatedHealth(int currentHealth){
        DecreaseHealth();
    }
    void OnDestroy()
    {
       // playerHealthController.UpdateHealth -= OnUpdatedHealth;
    }
}
