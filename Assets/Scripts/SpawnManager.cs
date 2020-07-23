using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    public GameObject flasa;
    public GameObject[] preostale = new GameObject[3];
    public GameObject[] slike = new GameObject[10];

    float granicaX = 6;
    float granicaY = 9;
    float granicaZ = 0;

    float granicaLevo = -6.8f;
    float granicaDesno = 2.9f;

    float time = 1f;
    float repeatTime = 1;

    public int rezultat;
    int tezina = 1;

    public bool promasena;

    public TextMeshProUGUI brojPoena;
    public TextMeshProUGUI poruka;

    public int brPreostalih = 3;
    int index = 2;
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("KreirajFlasu", time, repeatTime);

        //flasaSkripta = GameObject.Find("Flasa").GetComponent<Flasa>();

        //if (!promasena)
        //{
        //    InvokeRepeating("KreirajFlasu", time, repeatTime);
        //    //StopCoroutine(KreirajFlasu());
        //}

        StartCoroutine(KreirajFlase());
        DodajPoen(0);
        slike[0].SetActive(true);
    }

    private void Update()
    {
        if (rezultat >= 100 * tezina)
        {
            repeatTime -= 0.05f;
            tezina++;
            slike[i].SetActive(true);
            i++;
        }


        if (brPreostalih == index)
        {
            Destroy(preostale[index]);
            index--;
        }

        if (promasena)
        {
            var preostaleFlase = GameObject.FindGameObjectsWithTag("Flasa");
            foreach (var flasa in preostaleFlase)
            {
                Destroy(flasa);
            }
            StartCoroutine(PrikaziKrajnjuScenu());
        }

        if ((rezultat > 1500) && !promasena)
        {
            var preostaleFlase = GameObject.FindGameObjectsWithTag("Flasa");
            foreach (var flasa in preostaleFlase)
            {
                Destroy(flasa);
            }
            PrikaziPredjenuScenu();
        }
    }

    //void KreirajFlasu()
    //{
    //    Vector3 pozicija = new Vector3(Random.Range(-granicaX, granicaX), granicaY, granicaZ);
    //    Instantiate(flasa, pozicija, flasa.transform.rotation);
    //}

    IEnumerator KreirajFlase()
    {
        while (!promasena)
        {
            Vector3 pozicija = new Vector3(Random.Range(granicaLevo, granicaDesno), granicaY, granicaZ);
            Instantiate(flasa, pozicija, flasa.transform.rotation);
            yield return new WaitForSeconds(repeatTime);
        }
    }

    public void DodajPoen(int rez)
    {
        rezultat += rez;
        brojPoena.text = rezultat.ToString();
    }

    IEnumerator PrikaziKrajnjuScenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Krajnja");
    }

    void PrikaziPredjenuScenu()
    {
        SceneManager.LoadScene("Predjena");
    }
}
