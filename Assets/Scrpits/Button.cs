using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject[] chips;
    [SerializeField] private Transform[] rows;
    [SerializeField] private int rowIndex;

    private float cooldownDuration = 1f;
    private bool isOnCooldown = false;

    public void OnClick()
    {
        if (isOnCooldown) return;

        if(!gameManager.isAiTurn)
        {
            PlayersTurn();
        }

        if (gameManager.isAiTurn)
        {
            AiTurn();
        }

        StartCooldown();
    }

    private void PlayersTurn()
    {
        GameObject chipToSpawn = chips[0];
        Transform targetRow = rows[rowIndex];
        Instantiate(chipToSpawn, targetRow.transform.position, targetRow.transform.rotation);
    }

    private void AiTurn()
    {
        GameObject chipToSpawn = chips[1];
        Transform targetRow = rows[rowIndex];
        Instantiate(chipToSpawn, targetRow.transform.position, targetRow.transform.rotation);
    }

    private void StartCooldown()
    {
        isOnCooldown = true;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        gameManager.NextPlayerTurn();
        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
    }
}
