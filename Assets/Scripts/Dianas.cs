using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dianas : MonoBehaviour
{
    public int puntosPorDiana = 10;
    public TMP_Text textoPuntuacion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BalaJugador"))
        {
            IncrementarPuntuacion();
            Destroy(other.gameObject); // Destruye la bala al impactar la diana
            DestruirDiana();
        }
    }

    void IncrementarPuntuacion()
    {
        // Incrementa la puntuación y actualiza el texto en la pantalla
        GameManager.instance.AgregarPuntuacion(puntosPorDiana);
        textoPuntuacion.text = "Puntuación: " + GameManager.instance.ObtenerPuntuacion().ToString();
    }
    void DestruirDiana()
    {
        // Notificar al GameManager que una diana ha sido destruida
        GameManager.instance.DisminuirDianasRestantes();

        // Destruir la diana
        Destroy(gameObject);
    }
}
