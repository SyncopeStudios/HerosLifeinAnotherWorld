using System.Collections;
using UnityEngine;

namespace Game.Scripts.Extra
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private string interactType;  // e.g., "Shop", "Inn", etc.
        [SerializeField] private GameObject interactionBox;

        public string InteractType => interactType;

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
               SceneHandlerManager.Instance.DeselesctInteract();
                interactionBox.SetActive(false);
            }
        }

        private IEnumerator WaitForInput()
        {
            while (isPlayerInRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneHandlerManager.Instance.ExteriorScenes(InteractType);
                }
                yield return null; // Wait until the next frame
            }
        }
    }
}