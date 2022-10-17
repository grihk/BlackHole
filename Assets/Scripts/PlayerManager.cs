using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public Material collectedObjMat;
    public PlayerState playerState;
    public LevelState levelState;
    public TextMeshProUGUI scoreText;
    private int Score;
    public Transform partcilePrefab;
   
    public List<GameObject> collidedList;

    public Transform collectedPoolTransform;
   
    public void Start()
    {
        Score = 0;
        UpdateScore(0); 
    }
    public enum PlayerState
    {
        Stop,
        Move
    }
    public enum LevelState
    {
        NotFinished,
        Finished
    }

    public void CallMakeSphere()
    {
        foreach (GameObject obj in collidedList)
        {
            UpdateScore(10);
            obj.GetComponent<CollectedObjController>().MakeSphere();    
        }
    }

    void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Score: " + Score;
        if (Score >= 160)
        {
            Invoke("Test", 4);
        }  
    }
    void Test()
    {
        SceneManager.LoadScene("Level1");  
    }      
}

