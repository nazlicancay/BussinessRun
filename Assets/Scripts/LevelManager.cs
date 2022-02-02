using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> levels = new List<GameObject>();
    public Transform targets;
    public GameObject Player;
    public GameObject target;
    public int levelCount = 1;
    public bool NextLevel;
    public GameObject HeartBar;
    public TextMeshProUGUI level;
    public TextMeshProUGUI dolar;
    public TextMeshProUGUI handdolar;



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


        HeartBar.SetActive(true);
        NextLevel = true;
        levelCount += 1;

        target.transform.DOMove(new Vector3(Player.transform.position.x, Player.transform.position.y-0.5f, Player.transform.position.z-0.2f), 0.01f);
        target.transform.parent = Player.transform;

        Player.transform.DOMove(new Vector3(targets.transform.position.x, targets.transform.position.y, targets.transform.position.z), 0.5f);
        GameManager.Instance.GameActive = true;
        target.gameObject.SetActive(true);

        HeartBar.gameObject.SetActive(false);

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
}
