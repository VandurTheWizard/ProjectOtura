using UnityEngine;

public interface EnemiesStatus
{
    public void onPatroll();
    public void onVision();
    public void onAttack();

    public void onStay();

    public bool isStay();
    public void onHandling();

    public bool isHandling();
}
