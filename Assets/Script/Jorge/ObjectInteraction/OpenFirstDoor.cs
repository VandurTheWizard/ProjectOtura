using Unity.VisualScripting;
using UnityEngine;

public class OpenFirstDoor : MonoBehaviour, ObjectOpened
{
    public int rotation = 0;
    public AudioClip audioRotation;


    private int timeToRotation = 3;
    private int finalRotation;
    private AudioGestions gestions;
    private bool isOpen = false;
    private float time = 0;
    private void Start()
    {
        finalRotation = rotation / timeToRotation;
       gestions = GetComponent<AudioGestions>();
    }

    private void Update()
    {
        if (!isOpen)
            return;

        time += Time.deltaTime;
        transform.Rotate(0,0, finalRotation * Time.deltaTime);

        if(time >= timeToRotation){
            FloorUsages.resetPlane();
            Destroy(this);
        }
    }

    public void onOpen()
    {
        isOpen = true;
        gestions.playAudio(audioRotation);





       
    }
}
