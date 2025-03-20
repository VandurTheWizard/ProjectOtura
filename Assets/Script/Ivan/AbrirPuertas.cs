using UnityEngine;
using System.Collections;

public class AbrirPuertas : MonoBehaviour
{
    [Header("General")]
    public float rotacionY = 90;
    public float velocidadRotacion = 1;

    private bool puertaAbierta = false;

    public void AbrirPuerta()
    {
        if (!puertaAbierta)
        {
            StartCoroutine(RotarPuerta());
        }
    }

    private IEnumerator RotarPuerta()
    {
        puertaAbierta = true;
        float rotacionActual = transform.rotation.eulerAngles.y;
        float rotacionFinal = rotacionActual + rotacionY;
        float tiempo = 0;

        while (tiempo < 1)
        {
            tiempo += Time.deltaTime * velocidadRotacion;
            float anguloY = Mathf.Lerp(rotacionActual, rotacionFinal, tiempo);
            transform.rotation = Quaternion.Euler(0, anguloY, 0);
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, rotacionFinal, 0);
    }
}
