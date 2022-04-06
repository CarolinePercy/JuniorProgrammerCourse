using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    public Text BestScoreText;
    public InputField submittedNameInput;

    private bool m_Started = false;
    private int m_Points;

    private int m_BestPoints;
    private string m_BestPlayer = "Name";
    
    private bool m_GameOver = false;
    private bool beatHighScore = false;


    // Start is called before the first frame update

    private void Awake()
    {
        LoadScore();
    }

    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SaveScore();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        if (m_Points > m_BestPoints)
        {
            m_BestPoints = m_Points;
            submittedNameInput.gameObject.SetActive(true);
            beatHighScore = true;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int points;
        public string name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();

        if (submittedNameInput.text != "")
        {
            m_BestPlayer = submittedNameInput.text;
        }

        else if (beatHighScore)
        {
            m_BestPlayer = "Name";
        }

        data.points = m_BestPoints;
        data.name = m_BestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_BestPoints = data.points;
            m_BestPlayer = data.name;
        }

        UpdateText();
    }

    void UpdateText()
    {
        BestScoreText.text = $"Best Score : {m_BestPlayer} : {m_BestPoints}";
    }
}
