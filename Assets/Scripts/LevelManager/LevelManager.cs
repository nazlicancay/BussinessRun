using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> levels = new List<GameObject>();
    public GameObject Player;
    public int levelCount = 1;
    public int levelCountDisplay = 1;
    public bool NextLevel;
    public GameObject HeartBar;
    public TextMeshProUGUI dolar;
    public TextMeshProUGUI handdolar;
    public UIManager uı;
    public VehicleController vehicle;
    public PlayerCollitions player;
    public PlayerMovement playerMovement;
    public BoxCollider bx;
    public GameManager gameManager;
    public bool nextlevel;



    private void Awake()
    {
    }
    void Start()
    {
        levelCount = PlayerPrefs.GetInt("levelCount");
        if (levelCount >= levels.Count)
        {
            levelCount = 0;
            PlayerPrefs.SetInt("levelCount", levelCount);
        }
        levelCountDisplay = PlayerPrefs.GetInt("levelDisplay");
        uı.levelCount.text = "Level " + levelCountDisplay;
        Instantiate(levels[levelCount]);
        if (nextlevel)
        {
            GameManager.Instance.StartImange.SetActive(false);
        }

        //levels[levelCount].gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLevel()
    {
        
        nextlevel = true;
        levelCount++;
        levelCountDisplay++;
        Debug.Log(levelCountDisplay);
        PlayerPrefs.SetInt("levelCount", levelCount);
        PlayerPrefs.SetInt("levelDisplay", levelCountDisplay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.StartGame();
        uı.RestartCanvas.gameObject.SetActive(false);
        if(levelCount == 0)
        {
            levels[levelCount].gameObject.SetActive(true);
        }
        else
        {
            levels[levelCount - 1].gameObject.SetActive(true);

        }

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
