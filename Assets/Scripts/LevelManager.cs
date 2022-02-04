using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> levels = new List<GameObject>();
    public GameObject Player;
    public GameObject target;
    public int levelCount = 1;
    public bool NextLevel;
    public GameObject HeartBar;
    public TextMeshProUGUI level;
    public TextMeshProUGUI dolar;
    public TextMeshProUGUI handdolar;
    public UIManager uı;
    public VehicleController vehicle;

    public PlayerCollitions player;



    private void Awake()
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateLevel()
    {


        NextLevel = true;
        levelCount += 1;
        Player.transform.DOMove(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), 0.5f);
        GameManager.Instance.GameActive = true;
        target.gameObject.SetActive(true);


        level.text = "Level" + levelCount.ToString();
        dolar.text = 0.ToString();
        handdolar.text = 0.ToString();




        for (int i = 0; i <= levels.Count-1; i++)
        {
            if (i == levelCount-1)
            {
                levels[i].SetActive(true);
            }
            else
                levels[i].SetActive(false);
        }

       
    }

    public void RestartGame()
    {
        GameManager.Instance.StartGame();
        Player.transform.DOMove(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), 0.5f);
        target.gameObject.SetActive(true);
        uı.RestartCanvas.gameObject.SetActive(false);
        levels[levelCount - 1].gameObject.SetActive(true);
        

        if (player.cycle.gameObject != null)
        {
            vehicle.SetVehicleFalse(player.cycle);



        }
        if (player.motor.gameObject != null)
        {
            vehicle.SetVehicleFalse(player.motor);
        }

        if (player.skateActive)
        {
            player.skateActive = false;
            player.Skate(false);
        }

    }

}
