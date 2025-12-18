using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] TextMeshProUGUI playerText;

    private Coroutine ai;
    private float cooldownDuration = 1f;

    public bool isAiTurn = false;

    private void Update()
    {
        if(!isAiTurn)
        {
            playerText.text = "Player 1";
            playerText.color = Color.red;
        }
        
        if(isAiTurn)
        {
            playerText.text = "Ai's turn";
            playerText.color = Color.yellow;
        }
    }
    public void NextPlayerTurn()
    {
        isAiTurn = !isAiTurn;

        if(!isAiTurn) {return;}

        if (isAiTurn)
        {
            ai = StartCoroutine(AiTurn());
        }
    }

    private IEnumerator AiTurn()
    {
        yield return new WaitForSeconds(cooldownDuration);

        int randomIndex = Random.Range(0, buttons.Length);
        Button randomButton = buttons[randomIndex];

        randomButton.OnClick();

        StopCoroutine(ai);
    }
}
