using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private GameObject[] chips;
    [SerializeField] private Transform Row1;
    private int time = 1;

    void Start()
    {
        StartCoroutine(spawnChips());
    }

    private IEnumerator spawnChips()
    {
        //Instantiate(chips[Random.Range(0, chips.Count)], Row1.transform.position, Quaternion.Euler(90f, 0f, 0f));
        yield return new WaitForSeconds(time);
        StartCoroutine(spawnChips());
    }

}
