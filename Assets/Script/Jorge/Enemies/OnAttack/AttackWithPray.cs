using System.Collections;
using UnityEngine;

public class AttackWithPray : MonoBehaviour, Attack, CompatibleSeeBack
{
    public int[] prayTime = {5, 10};
    public int damage = 5;

    private bool attack = false;
    private EnemiesStatus enemiesStatus;

    private Coroutine coroutine;
    
    private AudioGestions gestions;
    public AudioClip music;

    private AudioSource audioResp;

    private GameObject player;

    private bool ended;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesStatus = GetComponent<EnemiesStatus>();
        player = GameObject.FindGameObjectWithTag("Player");
        gestions = GetComponent<AudioGestions>();
    }

    public void onAttack()
    {
        if (attack)
        {
            return;
        }
        attack = true;
        int waitTime = Random.Range(prayTime[0], prayTime[1]);
        enemiesStatus.onStay(waitTime);
        audioResp = gestions.deleteMyself(music);
        coroutine = StartCoroutine(pray(waitTime));
    }

    private IEnumerator pray(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.LookAt(player.transform.position);
        player.GetComponent<LifeUsage>().loseLife(damage);
        Destroy(audioResp);
        audioResp = null;
        attack = false;
        ended = true;
    }

    public void resetAttack()
    {
        
        Destroy(audioResp);
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        
        audioResp = null;
        attack = false;
    }


    public void stopAttackFor(float seconds)
    {
      
    }

    public bool isEnded()
    {
        return ended;
    }

    public void resetEnded()
    {
        ended = false;
    }
}
