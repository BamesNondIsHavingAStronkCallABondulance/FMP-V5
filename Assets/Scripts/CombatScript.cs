using UnityEngine;
using HarryGame;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class CombatScript : MonoBehaviour
{
    public const string PLAYER_HEALTH = "Player Health";
    public const string PLAYER_DEFENCE = "Player Defence";

    public GameObject enemyPosition;

    public TMP_Text enemyHealthText;
    public TMP_Text enemyDefenceText;
    public TMP_Text enemyAttackText;


    public EnemyIndex currentEnemy;
    public EnemyIndex deathCultist;
    public EnemyIndex otherEnemy;
    public TMP_Text playerHealthText;
    public TMP_Text playerDefenceText;
    public TMP_Text turnTrackerText;

    int playerHealth;
    int playerDefence;

    int currentAttack;
    int currentDefend;

    //bool enemyTurn;
    bool playerTurn;
    public bool playerActionTaken;
    bool dontSkip = false;

    CardIndex cardData;
    EnemyIndex enemyData;
    public PlayCards playCardsScript;
    public HandManager handManagerScript;

    bool enemyIsDead;

    private void Start()
    {
        playerHealth = PlayerPrefs.GetInt(PLAYER_HEALTH, 30);
        playerDefence = 0;

        ResetEnemies();

        SpawningNewEnemy();

        enemyHealthText.text = currentEnemy.health.ToString();
        playerHealthText.text = playerHealth.ToString();
        playerDefenceText.text = playerDefence.ToString(); 

        playerTurn = false;

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
            bool turnStart = true;

            if (turnStart)
            {
                playerActionTaken = false;
            }

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

            enemyHealthText.text = currentEnemy.health.ToString();
            enemyDefenceText.text = currentDefend.ToString();
            enemyAttackText.text = currentAttack.ToString();
        }

        void Card1Logic()
        {
            if (handManagerScript.card1Type.text == "Attack")
            {
                int accountForEnemyShield = currentDefend - handManagerScript.cardData1.damage;

                if (accountForEnemyShield < 0)
                {
                    currentEnemy.health += accountForEnemyShield;
                    currentDefend = 0;
                }
                else
                {
                    currentDefend -= handManagerScript.cardData1.damage;
                }

                playerActionTaken = true;
            }

            if (handManagerScript.card1Type.text == "Skill")
            {
                playerDefence += handManagerScript.cardData1.block;
                playerDefenceText.text = playerDefence.ToString();

                playerActionTaken = true;
            }
        }

        void Card2Logic()
        {
            if (handManagerScript.card2Type.text == "Attack")
            {
                int accountForEnemyShield = currentDefend - handManagerScript.cardData2.damage;

                if (accountForEnemyShield < 0)
                {
                    currentEnemy.health += accountForEnemyShield;
                    currentDefend = 0;
                }
                else
                {
                    currentDefend -= handManagerScript.cardData2.damage;
                }

                playerActionTaken = true;
            }

            if (handManagerScript.card2Type.text == "Skill")
            {
                playerDefence += handManagerScript.cardData2.block;
                playerDefenceText.text = playerDefence.ToString();

                playerActionTaken = true;
            }
        }

        void Card3Logic()
        {
            if (handManagerScript.card3Type.text == "Attack")
            {
                int accountForEnemyShield = currentDefend - handManagerScript.cardData3.damage;

                if (accountForEnemyShield < 0)
                {
                    currentEnemy.health += accountForEnemyShield;
                    currentDefend = 0;
                }
                else
                {
                    currentDefend -= handManagerScript.cardData3.damage;
                }

                playerActionTaken = true;
            }

            if (handManagerScript.card3Type.text == "Skill")
            {
                playerDefence += handManagerScript.cardData3.block;
                playerDefenceText.text = playerDefence.ToString();

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
    }

    #endregion

    #region Enemy attacks

    public void EnemyAttackLogic()
    {

        if (!playerTurn)
        {

            if (dontSkip)
            {
                int accountForShield = playerDefence - currentAttack;

                if (accountForShield < 0)
                {
                    playerHealth += accountForShield;
                }
                else
                {
                    playerDefence -= currentAttack;
                }

                StartCoroutine(EnemyDelay());


                playerDefence = 0;

                playerHealthText.text = playerHealth.ToString();
                playerDefenceText.text = playerDefence.ToString();
            }

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

            if (!dontSkip)
            {
                playerTurn = true;
            }

            dontSkip = true;

            // enemyDefenceText.text = currentDefend.ToString();
            // enemyAttackText.text = currentAttack.ToString();
        }

        //Goal is to randomly select 1 attack and one defnd from each array
        //If both options are null, select again until at least one option is not null;
        //COMPLETED

    }

    IEnumerator EnemyDelay()
    {
        print("before");

        yield return new WaitForSeconds(3);

        print("after");

        playerTurn = true;
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
