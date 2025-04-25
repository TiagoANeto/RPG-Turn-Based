using UnityEngine;

public enum BattleState{START,PLAYERTURN,ENEMYTURN,WINBATTLE,LOSEBATTLE};

public class BattleTurnSystem : MonoBehaviour
{
    //isso aqui tinha que ser um array ou uma lista mas tava dando treta pra fazer o spawn
    //vou pensar em uma forma melhor de estruturar isso, usando events talvez, por hora vai ficar assim
    //apenas para fins de teste do loop de jogo, dito isso, vai ser refatorado no futuro...
    [Header("Referências do player e inimigo a ser spawnado")] [Space(10)]
    public GameObject playerTeamPrefab; 
    public GameObject enemyTeamPrefab;

    [Header("Referências ponto de spawn do player e inimigo")] [Space(10)]
    public Transform playerTeamPoint;
    public Transform enemyTeamPoint;

    [Header("Estados de Batalha")] [Space(10)]
    public BattleState battleState;

    [Header("Referências das HUDS player e inimigo")] [Space(10)]
    public BattleHUDControl playerHUD;
    public BattleHUDControl enemyHUD;

    private CharacterStats playerCharacter;
    private CharacterStats enemyCharacter;

    private void Start()
    {
        battleState = BattleState.START;
        BattleSetupControl();
    }

    public void BattleSetupControl()
    {
        GameObject playerGO = Instantiate(playerTeamPrefab, playerTeamPoint);
        playerCharacter = playerGO.GetComponent<CharacterStats>();
        
        GameObject enemyGO = Instantiate(enemyTeamPrefab, enemyTeamPoint);
        enemyCharacter = enemyGO.GetComponent<CharacterStats>();

        playerHUD.SetHud(playerCharacter);
        enemyHUD.SetHud(enemyCharacter);
    }
}

