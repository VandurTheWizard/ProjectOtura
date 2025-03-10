using UnityEngine;
using UnityEngine.AI;

public interface Attack
{
    public void onAttack();
    public void resetAttack();
    public void stopAttackFor(float seconds);

}