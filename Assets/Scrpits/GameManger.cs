using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private GameObject chips;
    [SerializeField] private Transform Row1;
    private int time = 2;

    void Start()
    {
        StartCoroutine(spawnChips());
    }

    private IEnumerator spawnChips()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(chips, Row1.transform.position, Quaternion.Euler(90f, 0f, 0f));
            yield return new WaitForSeconds(time);
        }
    }

}
