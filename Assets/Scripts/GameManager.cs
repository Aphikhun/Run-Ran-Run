using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    private float time;
    [SerializeField] private Text hp_txt;
    [SerializeField] private Text score_txt;
    [SerializeField] private Text result_txt;

    private bool isPause;
    [SerializeField] private GameObject PausePanel;

    private bool isShowInventory = true;
    [SerializeField] private GameObject InventoryPanel;

    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private Text[] card_txt;
    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        time = 0;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
        SetCardAmount();
        PlayerDie();

        hp_txt.text = PlayerHealth.instance.hp.ToString();
        score_txt.text = score.ToString();

        if(Input.GetKeyDown(KeyCode.Escape) && !PlayerHealth.instance.isDie)
        {
            if(!isPause)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }

        if(Input.GetKeyDown(KeyCode.I) && !PlayerHealth.instance.isDie && !isPause)
        {
            if (isShowInventory)
            {
                HideInventory();
            }
            else
            {
                ShowInventory();
            }
        }
    }

    private void CountScore()
    {
        if (time < 1)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            score += 1;
        }
    }
    private void SetCardAmount()
    {
        int i = 0;
        foreach(var cards in PlayerInventory.instance.Cards)
        {
            card_txt[i].text = cards.Value.ToString();
            i++;
        }
    }
    private void PlayerDie()
    {
        if (PlayerHealth.instance.isDie)
        {
            Time.timeScale = 0f;
            result_txt.text = score.ToString();
            GameOverPanel.SetActive(true);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
        PausePanel.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        isPause = false;
        PausePanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void ShowInventory()
    {
        isShowInventory= true;
        InventoryPanel.SetActive(true);
    }
    private void HideInventory()
    {
        isShowInventory= false;
        InventoryPanel.SetActive(false);
    }
}
