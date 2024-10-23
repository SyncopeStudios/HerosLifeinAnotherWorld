
    using Game.Scripts.Extra;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneHandlerManager : Singelton<SceneHandlerManager>
    {
        [SerializeField] private HouseInteraction houseType;
        [SerializeField] private Interaction interact;
        

        public void SelectedHouse(HouseInteraction house)
        {
            houseType = house;
            InteriorScenes(house.HouseType);
            
        }
        public void SelectedInteract(Interaction type)
        {
            interact = type;
            
        }

        public void DeselectHouse()
        {
            houseType = null;
        }

        public void DeselesctInteract()
        {
            interact = null;
        }

        public void InteriorScenes(string houseType)
        {
            string sceneToLoad = "";

            // Logic to determine which scene to load based on the house type
            switch (houseType)
            {
                case "Shop":
                    sceneToLoad = "ShopScene"; // Replace with the actual scene name
                    break;
                case "Inn":
                    sceneToLoad = "InnScene"; // Replace with the actual scene name
                    break;
                default:
                    sceneToLoad = "HerosHouse"; // Replace with the default scene name
                    break;
            }

            // Load the selected scene
            SceneManager.LoadScene(sceneToLoad);
        }
        public void ExteriorScenes(string interactionType)
        {
            string sceneToLoad = "";

            // Logic to determine which scene to load based on the house type
            switch (interactionType)
            {
                case "Sewer":
                    sceneToLoad = "Sewer"; // Replace with the actual scene name
                    break;
                case "Inn":
                    sceneToLoad = "InnScene"; // Replace with the actual scene name
                    break;
                default:
                    sceneToLoad = "Level01"; // Replace with the default scene name
                    break;
            }

            // Load the selected scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
