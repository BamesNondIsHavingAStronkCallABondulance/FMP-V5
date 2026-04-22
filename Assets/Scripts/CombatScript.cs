using UnityEngine;
using HarryGame;
using TMPro;
using Unity.VisualScripting;

public class CombatScript : MonoBehaviour
{
    public const string PLAYER_HEALTH = "Player Health";
    public const string PLAYER_DEFENCE = "Player Defence";

    public GameObject enemyPosition;
    public TMP_Text enemyHealth;
    public EnemyIndex currentEnemy;
    public EnemyIndex deathCultist;
    public EnemyIndex otherEnemy;

    CardIndex cardData;
    EnemyIndex enemyData;
    public PlayCards playCardsScript;
    public HandManager handManagerScript;

    int playerHealth = 20;
    int mana = 3;

    private void Start()
    {
        PlayerPrefs.GetFloat(PLAYER_HEALTH);

        enemyHealth.text = deathCultist.health.ToString();

    }

    #region Spawning random enemy
    //Some of this may be in start?
    //Ignore until combat is finished
    
    //This needs to affect currentEnemy

    


    #endregion

    #region Attacking enemy

    private void Update()
    {
        if (playCardsScript.enemyIsSelected)
        {
            if (playCardsScript.card1Selected)
            {
                Card1Logic();
            }
            if (playCardsScript.card2Selected)
            {
                Card2Logic();
            }
            if (playCardsScript.card3Selected)
            {
                Card3Logic();
            }
        }
    }

    #endregion

    #region Rewards


    #endregion

    #region Go to next screen


    #endregion

    void Card1Logic()
    {
        if (handManagerScript.card1Type.text == "attack")
        {
            currentEnemy.health -= handManagerScript.cardData1.damage;
            enemyHealth.text = deathCultist.health.ToString();
        }
    }

    void Card2Logic()
    {
        if (handManagerScript.card2Type.text == "attack")
        {
            currentEnemy.health -= handManagerScript.cardData2.damage;
            enemyHealth.text = deathCultist.health.ToString();
        }
    }

    void Card3Logic()
    {
        if (handManagerScript.card3Type.text == "attack")
        {
            currentEnemy.health -= handManagerScript.cardData3.damage;
            enemyHealth.text = deathCultist.health.ToString();

            print("I DOING THINGS");
        }
    }
}
