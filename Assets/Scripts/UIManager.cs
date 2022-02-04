using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI levelCount;
    public LevelManager levelManager;
    public ScoreManager scoreManager;
    public Button nextlevelbutton;
    public Button Restartevelbutton;
    public Canvas RestartCanvas;
    public Canvas NextLevelCanvas;
    public TextMeshProUGUI coinCount;
    public PlayerCollitions player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = (player.coinNum*10).ToString();
        
    }
}
