using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseDoor : MonoBehaviour //IPointerClickHandler
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject bossDoor;

    public GameObject leftCombatImage, leftBossImage, leftRestImage, leftEventImage, rightCombatImage, rightBossImage, rightRestImage, rightEventImage;

    string leftDoorOption;
    int leftDoorOptionInt;

    string rightDoorOption;
    int rightDoorOptionInt;

    bool combatEncounter, eventEncounter, bossEncounter, restEncounter;

    int floorNumber;

    string[] possibleEncounterStrings =
    {
        "combat", "event", "rest", "boss"
    };

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            EncounterSetsLogic();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EncounterSetsLogic();
        }
    }

    public void ButtonTest()
    {
        print("hello");
    }

    void EncounterSetsLogic()
    {
        floorNumber = 2;
        bool rerollEncounter = true;

        if (floorNumber == 1)
        {
            leftDoorOptionInt = Random.Range(0, possibleEncounterStrings.Length - 2);
            leftDoorOption = possibleEncounterStrings[leftDoorOptionInt];
            print(leftDoorOption);

            while (rerollEncounter)
            {
                rightDoorOptionInt = Random.Range(0, possibleEncounterStrings.Length - 2);
                if (rightDoorOptionInt != leftDoorOptionInt)
                {
                    rerollEncounter = false;
                    rightDoorOption = possibleEncounterStrings[rightDoorOptionInt];
                    print(rightDoorOption);
                }
                else
                {
                    rerollEncounter = true;
                }
            }
        }

        if (floorNumber > 1 && floorNumber < 5)
        {
            leftDoorOptionInt = Random.Range(0, possibleEncounterStrings.Length - 1);
            leftDoorOption = possibleEncounterStrings[leftDoorOptionInt];
            print(leftDoorOption);


            while (rerollEncounter)
            {
                rightDoorOptionInt = Random.Range(0, possibleEncounterStrings.Length - 1);

                if (rightDoorOptionInt != leftDoorOptionInt)
                {
                    rerollEncounter = false;
                    rightDoorOption = possibleEncounterStrings[rightDoorOptionInt];
                    print(rightDoorOption);
                }
                else
                {
                    rerollEncounter = true;
                }
            }
        }

        if (floorNumber == 5)
        {
            bossEncounter = true;

            leftDoorOptionInt = 3;
            leftDoorOption = possibleEncounterStrings[leftDoorOptionInt];

            rightDoorOptionInt = 3;
            rightDoorOption = possibleEncounterStrings[rightDoorOptionInt];
        }

        leftDoorSpriteLogic();
        rightDoorSpriteLogic();

        UpdateRightEncounterBools();
        UpdateLeftEncounterBools();
    }

    #region SpriteAndSceneLogic
    void leftDoorSpriteLogic()
    {
        if (leftDoorOption == "combat")
        {
            leftCombatImage.SetActive(true);
            leftEventImage.SetActive(false);
            leftRestImage.SetActive(false);
            leftBossImage.SetActive(false);
        }
        if (leftDoorOption == "boss")
        {
            leftCombatImage.SetActive(false);
            leftEventImage.SetActive(false);
            leftRestImage.SetActive(false);
            leftBossImage.SetActive(true);
        }
        if (leftDoorOption == "rest")
        {
            leftCombatImage.SetActive(false);
            leftEventImage.SetActive(false);
            leftRestImage.SetActive(true);
            leftBossImage.SetActive(false);
        }
        if (leftDoorOption == "event")
        {
            leftCombatImage.SetActive(false);
            leftEventImage.SetActive(true);
            leftRestImage.SetActive(false);
            leftBossImage.SetActive(false);
        }
    }

    void rightDoorSpriteLogic()
    {
        if (rightDoorOption == "combat")
        {
            rightCombatImage.SetActive(true);
            rightEventImage.SetActive(false);
            rightRestImage.SetActive(false);
            rightBossImage.SetActive(false);
        }
        if (rightDoorOption == "boss")
        {
            rightCombatImage.SetActive(false);
            rightEventImage.SetActive(false);
            rightRestImage.SetActive(false);
            rightBossImage.SetActive(true);
        }
        if (rightDoorOption == "rest")
        {
            rightCombatImage.SetActive(false);
            rightEventImage.SetActive(false);
            rightRestImage.SetActive(true);
            rightBossImage.SetActive(false);
        }
        if (rightDoorOption == "event")
        {
            rightCombatImage.SetActive(false);
            rightEventImage.SetActive(true);
            rightRestImage.SetActive(false);
            rightBossImage.SetActive(false);
        }
    }

    public void UpdateScene()
    {
        if (combatEncounter == true)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void UpdateLeftEncounterBools()
    {
        if (leftDoorOption == "combat")
        {
            combatEncounter = true;
            bossEncounter = false;
            restEncounter = false;
            eventEncounter = false;
        }
        if (leftDoorOption == "boss")
        {
            combatEncounter = false;
            bossEncounter = true;
            restEncounter = false;
            eventEncounter = false;
        }
        if (leftDoorOption == "rest")
        {
            combatEncounter = false;
            bossEncounter = false;
            restEncounter = true;
            eventEncounter = false;
        }
        if (leftDoorOption == "event")
        {
            combatEncounter = false;
            bossEncounter = false;
            restEncounter = false;
            eventEncounter = true;
        }
    }

    public void UpdateRightEncounterBools()
    {
        if (rightDoorOption == "combat")
        {
            combatEncounter = true;
            bossEncounter = false;
            restEncounter = false;
            eventEncounter = false;
        }
        if (rightDoorOption == "boss")
        {
            combatEncounter = false;
            bossEncounter = true;
            restEncounter = false;
            eventEncounter = false;
        }
        if (rightDoorOption == "rest")
        {
            combatEncounter = false;
            bossEncounter = false;
            restEncounter = true;
            eventEncounter = false;
        }
        if (rightDoorOption == "event")
        {
            combatEncounter = false;
            bossEncounter = false;
            restEncounter = false;
            eventEncounter = true;
        }
    }
    #endregion 
}
