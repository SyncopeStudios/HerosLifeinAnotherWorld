using Game.Scripts.Extra;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HouseManager : Singelton<HouseManager>
{
    [SerializeField]private HouseInteraction selectedHouse;
    

    public void SelectHouse(HouseInteraction house)
    {
        selectedHouse = house;
        ChangeScene(house.HouseType);
    }

    public void DeselectHouse()
    {
        selectedHouse = null;
    }

    public void ChangeScene(string houseType)
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
}