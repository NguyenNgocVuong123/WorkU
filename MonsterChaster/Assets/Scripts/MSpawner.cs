using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] MonsterRef;

    [SerializeField] private Transform leftPos, rightPos;
    private GameObject spawnMonster;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            //random thoi gian tao monster
            yield return new WaitForSeconds(Random.Range(1, 5));
            //random monster
            randomIndex = Random.Range(0, MonsterRef.Length);
            //random monster spawn
            randomSide = Random.Range(0, 2);
            //ham copy lai obj - monster
            spawnMonster = Instantiate(MonsterRef[randomIndex]);

            //spawn tu ben trai
            if (randomSide == 0)
            {
                spawnMonster.transform.position = leftPos.position;
                spawnMonster.GetComponent<Monster>().speed = Random.Range(4, 9);
            }
            else //ben phai
            {
                spawnMonster.transform.position = rightPos.position;
                spawnMonster.GetComponent<Monster>().speed = Random.Range(-4, -9);
                spawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}

