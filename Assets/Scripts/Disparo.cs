using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Disparo : MonoBehaviour
{
    public GameObject SpawnAttack;
    public GameObject Bala;
    public Animator AnimDisp;
    public Vector2 dirDisp = Vector2.right; //direccion de la bala
    public float velBala = 20;
    public float tiempoVidaBala = 4f; // Tiempo en segundos antes de que la bala se destruya automáticamente
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //actualizar direccion de el disparo 
        if (Input.GetKey(KeyCode.A))
        {
            dirDisp = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dirDisp = Vector2.right;
        }

        if (Input.GetMouseButtonDown(0))
        {
            AnimDisp.SetTrigger("Attack");
                        
        }
    }

    public void SetDirection(Vector2 direction)
    {
        transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);
    }

    public void Attack()
    {
        GameObject newBala = Instantiate(Bala, SpawnAttack.transform.position, Quaternion.identity);
        newBala.transform.localScale = transform.localScale; // Escala de la bala
        newBala.GetComponent<Rigidbody2D>().velocity = transform.localScale.x > 0 ? Vector2.right * velBala : Vector2.left * velBala;
        Destroy(newBala, tiempoVidaBala);
    }
    
}
