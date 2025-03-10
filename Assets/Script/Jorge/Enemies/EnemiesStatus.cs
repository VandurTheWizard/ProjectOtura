using UnityEngine;

public interface EnemiesStatus
{
    public void onPatroll();
    public void onVision();

    public void onStay(int time);

    public bool isStay();

    public void onAttack();

    public bool isPlayerVisible();
}
