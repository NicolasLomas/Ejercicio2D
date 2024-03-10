using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int puntuacion = 0;
    private int dianasRestantes = 8; // Ajusta el número total de dianas en tu escena
    private string puntuacionKey = "Puntuacion";
    private string tiempoRestanteKey = "TiempoRestante";
    public Image fade;
    public Color alpha;


    // Start is called before the first frame update
    void Start()
    {
        ReiniciarPuntuacion();
        alpha = fade.color;

    }

    // Update is called once per frame
    void Update()
    {
               
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AgregarPuntuacion(int puntos)
    {
        puntuacion += puntos;
    }

    public int ObtenerPuntuacion()
    {
        return puntuacion;
    }
    public void DisminuirDianasRestantes()
    {
        dianasRestantes--;
        if (dianasRestantes <= 0)
        {
            CargarEscenaGameOver();
        }
    }
    
    public void ReiniciarPuntuacion()
    {
        puntuacion = 0;
    }
    public void CargarEscenaGameOver()
    {
        StartCoroutine("Fade");
    }
    public int ObtenerDianasRestantes()
    {
        return dianasRestantes;
    }
    public void ReiniciarDianas()
    {
        dianasRestantes = 8;
    }
    IEnumerator Fade()
    {
        while (alpha.a < 1)
        {
            alpha.a += 0.1f;
            fade.color = alpha;
            yield return new WaitForSeconds(0.1f);
        }
        PlayerPrefs.SetInt(puntuacionKey, puntuacion);
        PlayerPrefs.SetFloat(tiempoRestanteKey, FindObjectOfType<Temporizador>().tiempo);
        SceneManager.LoadScene("GameOver");

    }


}
