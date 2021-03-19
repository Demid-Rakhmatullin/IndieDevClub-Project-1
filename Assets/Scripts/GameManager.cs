using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int ModulesCount = 1;
    public int Score { get; private set; }
    public Text ScoreText;
    public bool IsLastModule { get; private set; }

    private int _createdModulesCount = 1;

    void Awake()
    {
        if (Instance == null)
            Instance = gameObject.GetComponent<GameManager>();
    }
   
    public void IncreaseScore(int amount)
    {
        Score += amount;
        ScoreText.text = Score.ToString();
    }

    public void CreateModule(string resourceName, Vector3 position, Quaternion rotation)
    {
        if (_createdModulesCount < ModulesCount)
        {
            Debug.Log("Next Module");
            var prefab = Resources.Load(resourceName);
            Instantiate(prefab, position, rotation);
            _createdModulesCount++;
        }
        else
        {
            IsLastModule = true;
        }
    }
}
