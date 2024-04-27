using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TankPreview : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tankName;

    [SerializeField] private Slider tankDamage;
    [SerializeField] private Slider tankSpeed;
    [SerializeField] private Slider tankHealth;

    [SerializeField] private Transform tankHolder;

    public void DisplayTank(CharacterSO tankCharacter)
    {
        tankName.text = tankCharacter.characterName;

        tankDamage.value = tankCharacter.characterDamage;
        tankSpeed.value = tankCharacter.characterSpeed;
        tankHealth.value = tankCharacter.characterHP;

        if(tankHolder.childCount > 0)
        {
            Destroy(tankHolder.GetChild(0).gameObject);
        }
        Instantiate(tankCharacter.characterPrefab, tankHolder.position, tankCharacter.characterPrefab.transform.rotation, tankHolder);
    }
}
