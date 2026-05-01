using UnityEngine;
using HarryGame;
using TMPro;
using Unity.VisualScripting;

public class CombatScript : MonoBehaviour
{
    public const string PLAYER_HEALTH = "Player Health";
    public const string PLAYER_DEFENCE = "Player Defence";

    public GameObject enemyPosition;
    public TMP_Text enemyHealthText;
    public TMP_Text enemyDefenceText;
    public EnemyIndex currentEnemy;
    public EnemyIndex deathCultist;
    public EnemyIndex otherEnemy;
    public TMP_Text playerHealthText;
    public TMP_Text turnTrackerText;

    int playerHealth;
    int playerDefence;

    int currentAttack;
    int currentDefend;

    bool enemyTurn;
    bool playerTurn;
    bool playerActionTaken;

    CardIndex cardData;
    EnemyIndex enemyData;
    public PlayCards playCardsScript;
    public HandManager handManagerScript;

    bool enemyIsDead;

    private void Start()
    {
        playerHealth = PlayerPrefs.GetInt(PLAYER_HEALTH, 30);

        ResetEnemies();

        SpawningNewEnemy();

        enemyHealthText.text = currentEnemy.health.ToString();

        playerTurn = true;

    }

    private void Update()
    {
        AttackingEnemy();
        EnemyAttackLogic();
        IsEnemyDead();
        TurnTracking();
    }

    public void TurnTracking()
    {
        if (playerTurn)
        {
            turnTrackerText.text = ("Player Turn");
        }
        else
        {
            turnTrackerText.text = ("Enemy Turn");
            print("anemone");
        }
    }


    #region Spawning random enemy
    //Some of this may be in start?
    //Ignore until combat is finished

    //This needs to affect currentEnemy

    public void SpawningNewEnemy()
    {
        currentEnemy.health = deathCultist.health;

        currentEnemy.attack1 = deathCultist.attack1;
        currentEnemy.attack2 = deathCultist.attack2;
        currentEnemy.attack3 = deathCultist.attack3;
        currentEnemy.attack4 = deathCultist.attack4;

        currentEnemy.defend1 = deathCultist.defend1;
        currentEnemy.defend2 = deathCultist.defend2;
        currentEnemy.defend3 = deathCultist.defend3;
        currentEnemy.defend4 = deathCultist.defend4;
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
        if (playerTurn)
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

            void Card1Logic()
            {
                if (handManagerScript.card1Type.text == "attack")
                {
                    currentEnemy.health -= handManagerScript.cardData1.damage;
                    enemyHealthText.text = currentEnemy.health.ToString();

                    playerActionTaken = true;
                }
            }

        void Card2Logic()
        {
            if (handManagerScript.card2Type.text == "attack")
            {
                currentEnemy.health -= handManagerScript.cardData2.damage;
                enemyHealthText.text = currentEnemy.health.ToString();

                playerActionTaken = true;
            }
        }

        void Card3Logic()
        {
            if (handManagerScript.card3Type.text == "Attack")
            {
                int accountForEnemyShield = handManagerScript.cardData3.damage - currentDefend;

                if (accountForEnemyShield > 0)
                {
                    currentEnemy.health -= accountForEnemyShield;
                }

                enemyHealthText.text = currentEnemy.health.ToString();

                playerActionTaken = true;
            }
        }

        IsEnemyDead();
    }

    public void IsEnemyDead()
    {
        if (currentEnemy.health <= 0)
        {
            enemyIsDead = true;
        }
    }

    public void EndPlayerTurn()
    {
        playerTurn = false;
        enemyTurn = true;
    }

    #endregion

    #region Enemy attacks

    public void EnemyAttackLogic()
    {

        if (enemyTurn)
        {
            enemyTurn = false;
            enemyDefenceText.text = "0";

            int[] possibleEnemyAttacks =
{
            currentEnemy.attack1, currentEnemy.attack2, currentEnemy.attack3, currentEnemy.attack4
            };

            int[] possibleEnemyDefends =
            {
            currentEnemy.defend1, currentEnemy.defend2, currentEnemy.defend3, currentEnemy.defend4
            };

            bool validAttack = false;
            bool validDefend = false;
            bool validAction = false;

            while (!validAction)
            {
                int currentAttackSelection = Random.Range(0, possibleEnemyAttacks.Length);
                currentAttack = possibleEnemyAttacks[currentAttackSelection];

                int currentDefendSelection = Random.Range(0, possibleEnemyAttacks.Length);
                currentDefend = possibleEnemyAttacks[currentDefendSelection];

                if (currentAttack != 0)
                {
                    validAttack = true;
                }
                if (currentDefend != 0)
                {
                    validDefend = true;
                }

                if (validAttack || validDefend)
                {
                    validAction = true;
                }
            }

            playerHealthText.text = (playerHealth - currentAttack).ToString();
            playerHealth -= currentAttack;

            enemyDefenceText.text = currentDefend.ToString();

            playerTurn = true;
        }

        //Goal is to randomly select 1 attack and one defnd from each array
        //If both options are null, select again until at least one option is not null;
        //COMPLETED

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
}
