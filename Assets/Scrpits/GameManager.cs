using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerText;

    public int currentPlayer = 1;

    private void Update()
    {
        if(currentPlayer == 1)
        {
            playerText.text = "Player 1";
            playerText.color = Color.red;
        }
        
        if(currentPlayer == 2)
        {
            playerText.text = "Player 2";
            playerText.color = Color.yellow;
        }
    }
    public void NextPlayerTurn()
    {
        currentPlayer = 3 - currentPlayer;
    }
}
