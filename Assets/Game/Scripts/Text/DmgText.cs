using TMPro;
using UnityEngine;

public class DmgText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI damageTMP;

    public void SetDamgeText(float damage)
    {
        damageTMP.text = damage.ToString();
    }

    public void DestroyText()
    {
        
        Destroy(gameObject);
        
    }

}
