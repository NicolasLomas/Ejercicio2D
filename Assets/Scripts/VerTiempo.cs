using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerTiempo : MonoBehaviour
{
    public TMP_Text textoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        MostrarTiempo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MostrarTiempo()
    {
        float tiempoRestante = PlayerPrefs.GetFloat("TiempoRestante", 0);
        if (tiempoRestante > 0)
        {
            textoTiempo.text = "Tiempo restante: " + tiempoRestante.ToString("F1");
        }
        else
        {
            textoTiempo.gameObject.SetActive(false); // Desactiva el texto del tiempo si el tiempo se agotó
        }
    }
}
