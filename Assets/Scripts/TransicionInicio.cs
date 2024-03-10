using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TransicionInicio : MonoBehaviour
{
    public Image fade;
    public Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        alpha = fade.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClicBoton()
    {
        StartCoroutine("Fade");
                       
    }
    IEnumerator Fade()
    {
        while (alpha.a < 1)
        {
            alpha.a += 0.1f;
            fade.color = alpha;
            yield return new WaitForSeconds(0.1f);
        }
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.ReiniciarPuntuacion();
            gameManager.ReiniciarDianas();
        }
        else
        {
            Debug.LogError("No se encontró un GameManager en la escena.");
        }
        SceneManager.LoadScene("Escena01");
    }
}
