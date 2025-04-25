using UnityEngine;

public enum BattleState{START,PLAYERTURN,ENEMYTURN,WINBATTLE,LOSEBATTLE};

public class BattleTurnSystem : MonoBehaviour
{
    //isso aqui tinha que ser um array ou uma lista mas tava dando treta pra fazer o spawn
    //vou pensar em uma forma melhor de estruturar isso, usando events talvez, por hora vai ficar assim
    //apenas para fins de teste do loop de jogo, dito isso, vai ser refatorado no futuro...
    public GameObject playerTeamPrefab; 
    public GameObject enemyTeamPrefab;

    public Transform playerTeamPoint;
    public Transform enemyTeamPoint;

    public BattleState battleState;
    public Character character;

    private void Start()
    {
        battleState = BattleState.START;
        BattleSetupControl();
    }

    public void BattleSetupControl()
    {
        GameObject playerGO = Instantiate(playerTeamPrefab, playerTeamPoint);
        character = playerGO.GetComponent<Character>();
        
        GameObject enemyGO = Instantiate(enemyTeamPrefab, enemyTeamPoint);
        character = enemyGO.GetComponent<Character>();

    }
}

