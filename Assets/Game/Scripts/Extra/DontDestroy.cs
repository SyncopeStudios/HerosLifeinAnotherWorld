using Game.Scripts.Extra;
using UnityEngine;

public class DontDestroy : Singelton<DontDestroy>
{
  private void Awake()
  {
    
    base.Awake();
    DontDestroyOnLoad(gameObject);
    
  }
}
