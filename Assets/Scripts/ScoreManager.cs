using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{
    // Start is called before the first frame update
    public int GameScore;
    public TextMeshProUGUI StackText;
    public PlayerCollitions player;
    public int StackScore = 0;

    void Start()
    {

    }

    private void Update()
    {
        GameScore = player.coinNum * 10;
    }







}
