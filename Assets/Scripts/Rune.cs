using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{


    // Spawner
    [SerializeField]
    private GameObject m_runeSpawner;

    // rune prefab
    [SerializeField]
    private GameObject m_rune1;



    // rune prefab
    [SerializeField]
    private GameObject m_rune2;


    // rune prefab
    [SerializeField]
    private GameObject m_rune3;




    // spawn seconds until next spawn
    public float m_spawnTime = 20.0f;

    // counts runes
    public int m_runeCounter;

    // bool check to see if spawned
    public bool m_isSpawned = true;

    // when rune is picked up
    public bool m_isRunePickedUp = false;

    // when placed at the rune spot
    public bool m_isRunePlaced = false;

    // sets when rune spawns
    public bool m_isRuneActive = false;


    private void Update()
    {
        SpawnRune();

    }


    private IEnumerator RuneSpawnCoroutine()
    {

        while(true)
        {
            // creating object
            GameObject rune = Instantiate(m_rune1) as GameObject;

            rune.transform.position = m_runeSpawner.transform.position;
            rune.transform.rotation = m_runeSpawner.transform.rotation;

            m_isRuneActive = true;
            yield return new WaitForSeconds(m_spawnTime);
        }
    }



    public void SpawnRune()
    {
        if(m_isSpawned)
        {
            StartCoroutine(RuneSpawnCoroutine());
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            Destroy(m_rune1);
            m_runeCounter++;
            Debug.Log("Rune picked up!!");
            m_isRunePickedUp = true;
            m_isRuneActive = false;
        }
    }






}
