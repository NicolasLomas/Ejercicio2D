using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public TMP_Text Contador;
    public float tiempo = 60;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ManageContador");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator ManageContador()
    {
        while(tiempo > 0)
        {
            Contador.text = Mathf.Round(tiempo).ToString();
            yield return new WaitForSeconds(1f);
            tiempo--;
        }
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.CargarEscenaGameOver();
        }
        else
        {
            Debug.LogError("No se encontró un GameManager en la escena.");
        }

        yield return null;
    }
}
