using UnityEngine;

public class FirstBossKilled : MonoBehaviour
{
    public bool _hasTreantBeenKilled = false;      

    private void OnDisable()
    {
        FirstBossDeath();
    }

    private void FirstBossDeath()
    {        
         _hasTreantBeenKilled = true;
    }
}
