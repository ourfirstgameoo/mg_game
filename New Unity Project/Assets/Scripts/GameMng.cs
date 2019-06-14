using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    public Slider hpSlider;
    public float hp = 10;
    public float totalHp = 10;
    public GameObject endUI;
    public Text endMessage;
    public static GameMng Instance;
    private EnemySpawner enemySpawner;

    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
        	other.GetComponent<Enemy>().Die();
            if(hp <= 0) GameOver();
	        hp -= 1;
	        hpSlider.value = hp / totalHp;
	        if(hp <= 0)
	        {
	            GameOver();
	        };
        }
    }

    public void Win()
    {
    	endUI.SetActive(true);
        endMessage.text = "胜 利";
    }

    public void GameOver()
    {
    	enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "失 败";
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene(0);
    }

}
