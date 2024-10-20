using Game.Scripts.Extra;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HouseManager : Singelton<HouseManager>
{
    [SerializeField]private HouseInteraction selectedHouse;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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
      
    }
}