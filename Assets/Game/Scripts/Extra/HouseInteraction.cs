using System.Collections;
using UnityEngine;

public class HouseInteraction : MonoBehaviour
{
    [SerializeField] private string houseType;  // e.g., "Shop", "Inn", etc.
    [SerializeField] private GameObject interactionBox;

    public string HouseType => houseType;

    private bool isPlayerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
             interactionBox.SetActive(true);
             StartCoroutine(WaitForInput());
            
           
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            SceneHandlerManager.Instance.DeselectHouse();
            interactionBox.SetActive(false);
        }
    }

    private IEnumerator WaitForInput()
    {
        while (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneHandlerManager.Instance.InteriorScenes(houseType);
            }
            yield return null; // Wait until the next frame
        }
    }
}
