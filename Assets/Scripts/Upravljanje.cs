using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upravljanje : MonoBehaviour
{
    Rigidbody2D gajbaRb;
    float pozicijaY = 1f;

    float granicaLevo = -6.8f;
    float granicaDesno = 2.9f;

    // Start is called before the first frame update
    void Start()
    {
        gajbaRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector3(mousePosition.x, pozicijaY, 0);

        if (transform.position.x < granicaLevo)
        {
            transform.position = new Vector3(granicaLevo, pozicijaY, 0);
        }

        if (transform.position.x > granicaDesno)
        {
            transform.position = new Vector3(granicaDesno, pozicijaY, 0);
        }
    }
}
