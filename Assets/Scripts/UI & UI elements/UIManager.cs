using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    // Start is called before the first frame update
    public TextMeshProUGUI levelCount;
    public LevelManager levelManager;
    public ScoreManager scoreManager;
    public Button nextlevelbutton;
    public Button Restartevelbutton;
    public GameObject RestartCanvas;
    public GameObject NextLevelCanvas;
    public TextMeshProUGUI coinCount;
    public PlayerCollitions player;
    public GameObject failpanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = scoreManager.GameScore.ToString();

        
    }
}
