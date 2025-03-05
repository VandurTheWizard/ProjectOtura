using System.Collections;
using UnityEngine;

public class TeletransportSpell : MonoBehaviour, ManaSpell
{
    public int manaValue;
    public int spellValue;
    public bool enable = true;
    public int laserDistance = 9999;
    public LayerMask pentagramaLayer;

    public Camera mainCamera;
    public Camera secondCamera;

    private Transform player;
    private GameObject pentagrama;
    private ManaUsage mana;
    private float waitTime = 0.001f;


    private void Start()
    {
        player = GetComponent<Transform>();
        mana = GetComponent<ManaUsage>();
    }
    public int getManaSpell()
    {
        return manaValue;
    }

    public int getSpellValue()
    {
        return spellValue;
    }

    public void SpellAttack()
    {
        enable = false;
        StartCoroutine(CreateRayCast());
    }

    private IEnumerator CreateRayCast()
    {
        changeCamera(false);
        while (true)
        {
            yield return new WaitForSeconds(waitTime);


            Vector3 mousePosition = Input.mousePosition;

            Ray ray = secondCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, laserDistance, pentagramaLayer))
            {

                pentagrama = hit.collider.gameObject;

            }

            
            if (Input.GetKeyDown(KeyCode.Mouse0) && pentagrama != null)
            {
                player.transform.position = new Vector3(pentagrama.transform.position.x, player.position.y + pentagrama.transform.position.y, pentagrama.transform.position.z);
                pentagrama = null;
                enable = true;
                mana.mana -= manaValue;
                mana.isCasting = false;
                changeCamera(true);
                yield break;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                pentagrama = null;
                enable = true;
                mana.isCasting = false;
                changeCamera(true);
                yield break;
            }
        }


    }


    private void changeCamera(bool isMainCamera)
    {
        mainCamera.gameObject.SetActive(isMainCamera);
        secondCamera.gameObject.SetActive(!isMainCamera);
    }

    public bool isEnable()
    {
        return enable;
    }

    public void setEnable(bool enable)
    {
       this.enable = enable;
    }
}