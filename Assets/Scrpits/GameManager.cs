using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private TextMeshProUGUI playerText;

    private Coroutine ai;
    private float cooldownDuration = 2f;

    public bool isAiTurn = false;

    private void Update()
    {
        if(!isAiTurn)
        {
            playerText.text = "Your Turn";
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
