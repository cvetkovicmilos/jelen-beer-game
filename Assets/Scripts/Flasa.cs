using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flasa : MonoBehaviour
{
    SpawnManager menadzer;
    public float speed = 20f;
    float tezina = 1;

    private void Start()
    {
        menadzer = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed * tezina);
        //speed += 0.005f;

        if (menadzer.rezultat >= 100 * tezina)
        {
            tezina += 0.2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gajba"))
        {
            Destroy(gameObject);
            menadzer.DodajPoen(10);
        }

        if (collision.gameObject.CompareTag("Granica"))
        {
            if (menadzer.brPreostalih > 0)
            {
                Destroy(gameObject);
                menadzer.brPreostalih--;
            }
            else
            {
                menadzer.promasena = true;
                Destroy(gameObject);
            }
        }
    }
}
