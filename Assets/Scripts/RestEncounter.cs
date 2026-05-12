using UnityEngine;
using UnityEngine.SceneManagement;

public class RestEncounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HonkMiMiMi()
    {
        int tempInt;
        tempInt = PlayerPrefs.GetInt("playerhealth");

        tempInt += 10;

        PlayerPrefs.SetInt("playerHealth", tempInt);
    }

    public void GoToCrossroads()
    {
        SceneManager.LoadScene(2);
    }

}
