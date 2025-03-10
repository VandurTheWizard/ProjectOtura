using UnityEngine;

public class LifeUsage : MonoBehaviour
{
    public float life = 50;
    public float maxLife = 100;
    public const int  MINLIFE = 1;

    private DyingScript dying;

    private void Start()
    {
        dying = GetComponent<DyingScript>();
    }

    public void Update()
    {
        if(life < MINLIFE)
        {
            dying.onDying();
        }
    }

    public void loseLife(int life)
    {
        this.life  -= life;
    }

    public void recieveLife(int life)
    {
        if (this.life + life >= maxLife)
        {
            this.life = maxLife;

        }
        else
        {
            this.life += life;
        }
        
    }

}
