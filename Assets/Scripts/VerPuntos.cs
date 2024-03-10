using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class VerPuntos : MonoBehaviour
{
    public TMP_Text puntuacionText;
    private string puntuacionKey = "Puntuacion";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(puntuacionKey))
        {
            int puntuacion = PlayerPrefs.GetInt(puntuacionKey);
            puntuacionText.text = "Puntuación: " + puntuacion.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
