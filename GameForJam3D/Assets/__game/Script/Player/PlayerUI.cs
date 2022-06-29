using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text artefactCountText;
    
    [SerializeField] GameObject damageImage;
    [SerializeField] GameObject healthUpImage;
    [SerializeField] GameObject pressEGo;

    public void CanInteractWithObject(bool boolValue)  // E
    {
        pressEGo.SetActive(boolValue);
    }

    public void ChangeHealthText(int health)  // жизни
    {
        healthText.text = health.ToString();
    }

    public void ChangeArtefactText(int artefact) // артефакт
    {
        artefactCountText.text = artefact.ToString();
    }

    public void DamageUIActivate() // урон
    {
        damageImage.SetActive(true);
        StartCoroutine(damageOff());
    }

    public void HealthUIActivate() // хилка
    {
        healthUpImage.SetActive(true);
        StartCoroutine(healthUpOff());
    }

    IEnumerator damageOff()
    {
        yield return new WaitForSeconds(0.1f);
        damageImage.SetActive(false);
    }

    IEnumerator healthUpOff()
    {
        yield return new WaitForSeconds(0.1f);
        healthUpImage.SetActive(false);
    }
}