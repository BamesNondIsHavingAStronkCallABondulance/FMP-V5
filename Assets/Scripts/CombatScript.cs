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

    bool enemyIsDead;

    int playerHealth = 20;
    int mana = 3;

    private void Start()
    {
        PlayerPrefs.GetFloat(PLAYER_HEALTH);

        ResetEnemies();

        SpawningNewEnemy();

        enemyHealth.text = currentEnemy.health.ToString();

    }

    private void Update()
    {
        AttackingEnemy();
        IsEnemyDead();
    }



    #region Spawning random enemy
    //Some of this may be in start?
    //Ignore until combat is finished

    //This needs to affect currentEnemy

    public void SpawningNewEnemy()
    {
        currentEnemy.health = deathCultist.health;
    }

    public void SpawnDeathCultist()
    {
        currentEnemy.health = deathCultist.health;
        currentEnemy.enemySprite = deathCultist.enemySprite;
    }
    
    public void ResetEnemies() //reset each scriptable object
    {
        deathCultist.health = 25;
    }

    #endregion

    #region Attacking enemy

    public void AttackingEnemy()
    {

        if (playCardsScript.enemyIsSelected)
        {
            if (playCardsScript.card1Selected && playCardsScript.cardIsPlayed)
            {
                Card1Logic();
            }
            if (playCardsScript.card2Selected && playCardsScript.cardIsPlayed)
            {
                Card2Logic();
            }
            if (playCardsScript.card3Selected && playCardsScript.cardIsPlayed)
            {
                Card3Logic();
            }
        }
    }

    public void IsEnemyDead()
    {
        if (currentEnemy.health <= 0)
        {
            enemyIsDead = true;
        }
    }

    #endregion

    #region Rewards

    private void CombatEndRewards()
    {
        if (enemyIsDead)
        {

        }
    }
    #endregion

    #region Go to next screen


    #endregion

    void Card1Logic()
    {
        if (handManagerScript.card1Type.text == "attack")
        {
            currentEnemy.health -= handManagerScript.cardData1.damage;
            enemyHealth.text = currentEnemy.health.ToString();
        }
    }

    void Card2Logic()
    {
        if (handManagerScript.card2Type.text == "attack")
        {
            currentEnemy.health -= handManagerScript.cardData2.damage;
            enemyHealth.text = currentEnemy.health.ToString();
        }
    }

    void Card3Logic()
    {
        if (handManagerScript.card3Type.text == "Attack")
        {
            currentEnemy.health -= handManagerScript.cardData3.damage;
            enemyHealth.text = currentEnemy.health.ToString();
        }
    }
}
