using UnityEngine;

public class SecondBossKilled : MonoBehaviour
{
    public bool _hasSecondBossBeenKilled = false;

    private void OnDisable()
    {
        BossDeath();
    }

    private void BossDeath()
    {
        _hasSecondBossBeenKilled = true;
    }
}
