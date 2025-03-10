using UnityEngine;

public class EfectoAlma : MonoBehaviour
{
    [Header("Ajustes Básicos")]
    public float speed = 5.0f;
    public int experience = 40;

    public AudioClip music;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Hace que siga al jugador A
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        // Hace que mire siempre a player
        transform.LookAt(player.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<AudioGestions>().playAudio(music);
            player.GetComponent<ExperienceUsage>().exp += experience;
            ManaUsage mana = player.GetComponent<ManaUsage>();
            mana.recieveMana(mana.maxMana / 10);
            Destroy(gameObject);
        }
    }
}
