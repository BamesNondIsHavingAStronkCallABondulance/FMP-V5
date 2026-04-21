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
    PlayCards PlayCardsScript;
    HandManager handManagerScript;

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
        if (PlayCardsScript.enemyIsSelected)
        {
            //check type of card played (needs to be added to hand manager) COMPLETED
            Card1Logic();


            //if ()
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
            //currentEnemy.health -= handManagerScript.cardData1.damage.;
        }
    }
}
