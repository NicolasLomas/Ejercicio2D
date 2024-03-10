using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscena2 : MonoBehaviour
{
    public string nombreEscena02ACargar = "Escena02";
    public string nombreEscena03ACargar = "Escena03";
    public Transform puntoCargaDerecha;
    public Transform puntoCargaIzquierda;
    public float distanciaActivacion = 5f;

    private bool escena02Cargada = false;
    private bool escena03Cargada = false;
    private float xInicialJugador;

    // Start is called before the first frame update
    void Start()
    {
        xInicialJugador = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        float distanciaAlPuntoDerecha = Vector2.Distance(transform.position, puntoCargaDerecha.position);
        float distanciaAlPuntoIzquierda = Vector2.Distance(transform.position, puntoCargaIzquierda.position);

        if (distanciaAlPuntoDerecha <= distanciaActivacion && !escena02Cargada)
        {
            CargarEscena02();
        }
        else if (distanciaAlPuntoDerecha > distanciaActivacion && escena02Cargada)
        {
            if (transform.position.x < xInicialJugador)
            {
                DesactivarEscena02();
            }
        }

        if (distanciaAlPuntoIzquierda <= distanciaActivacion && !escena03Cargada)
        {
            CargarEscena03();
        }
        else if (distanciaAlPuntoIzquierda > distanciaActivacion && escena03Cargada)
        {
            if (transform.position.x > xInicialJugador)
            {
                DesactivarEscena03();
            }
        }
    }

    void CargarEscena02()
    {
        SceneManager.LoadScene(nombreEscena02ACargar, LoadSceneMode.Additive);
        escena02Cargada = true;
    }

    void DesactivarEscena02()
    {
        SceneManager.UnloadSceneAsync(nombreEscena02ACargar);
        escena02Cargada = false;
    }

    void CargarEscena03()
    {
        SceneManager.LoadScene(nombreEscena03ACargar, LoadSceneMode.Additive);
        escena03Cargada = true;
    }

    void DesactivarEscena03()
    {
        SceneManager.UnloadSceneAsync(nombreEscena03ACargar);
        escena03Cargada = false;
    }

}
