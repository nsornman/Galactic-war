using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    
    [Header("Assign Games Variable")]
    public int StartingCC = 5;
    public int StartingSC = 3;
    public int StarterWood;
    public int StarterMetal;
    public int StarterConcrete;
    public int StarterStone;
    
    [Header("Assign GameObjects")]
    public GameObject attackposition;
    public GameObject playerposition;
    public GameObject ChangeUI;
    public GameObject cardUI;
    public GameObject Playerself;
    [SerializeField] private Player[] player;
    private Clickableblock[] clickableblocks;
    [SerializeField] private Construction[] construction;
    private PassiveSkill[] passiveSkill;
    [Header("Game Phase")]
    public bool changing;
    public float changeTime = 30f;
    public bool Attacking;
    public float attackTime = 60f;
    public int AttackingPhaseCount;
    public bool Building;
    public float buildingTime = 60f;
    public int BuildingPhaseCount;
    public int FreeAttackperround;
    [SerializeField] private float Timerunner;
    private enum GamePhase { None, Building, Attacking }
    private enum SkillPhase {Build , Attack}
    private GamePhase currentPhase;

    void Awake()
    {
        clickableblocks = FindObjectsOfType<Clickableblock>();
        player = FindObjectsOfType<Player>();
    }

    void Start()
    {
        StartCoroutine(Waitfor());
    }
    // void FixedUpdate()
    // {
    //     SetNewLives();
    // }
    IEnumerator Waitfor(){
        yield return new WaitUntil(StartBuildingPhase);
        SetNewLives();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            SetNewLives();
        }
        if (!changing)
        {
            CheckPhase();
        }
    }
    void FixedUpdate(){
        construction = FindObjectsOfType<Construction>();
        passiveSkill = FindObjectsOfType<PassiveSkill>();
    }
    

    public void SetMats()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].ResetMat();
            player[i].Recieve(StarterWood, StarterMetal, StarterConcrete, StarterStone);
        }
    }

    public void SetNewLives()
    {
        SetBlock();
        SetMats();
        SetUpCard();
    }

    public void SetBlock()
    {
        for (int i = 0; i < clickableblocks.Length; i++)
        {
            clickableblocks[i].Destroyed();
            clickableblocks[i].NewBlock();
        }
    }
    public void SetUpCard(){
        for(int i = 0;i< player.Length;i++){
            if(player[i].inventoryManager != null){
                player[i].SetCard(StartingCC , StartingSC);
               // Debug.Log("Seting up the card......");
            }
        }
    }

    public void CheckPhase()
    {
        Timerunner += Time.deltaTime;
        switch (currentPhase)
        {
            case GamePhase.Building:
                if (Timerunner >= buildingTime)
                {
                    if (StillAlive())
                    {
                        StartCoroutine(ChangePhaseAfterDelay(GamePhase.Attacking));
                    }
                    else
                    {
                        EndGame();
                    }
                }
                break;

            case GamePhase.Attacking:
                if (Timerunner >= attackTime)
                {
                    StartCoroutine(ChangePhaseAfterDelay(GamePhase.Building));
                }
                break;
        }
    }

    public bool StillAlive()
    {
        for (int i = 0; i < clickableblocks.Length; i++)
        {
            if (clickableblocks[i].gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    public bool StartBuildingPhase()
    {
        BuildingPhaseCount +=1;
        UseConstructPerk(SkillPhase.Build);
        for(int i= 0;i<player.Length;i++){
            player[i].GainMultiplier =1;
        }
        Warpto(playerposition);
        //Debug.Log("Setting cardUI to active");
        if (cardUI != null)
        {
            //Debug.Log("cardUI is not null, activating");
            cardUI.SetActive(true);
        }
        else
        {
            //Debug.Log("cardUI is null, cannot activate");
        }
        ChangeUI.SetActive(false);
        Building = true;
        Attacking = false;
        currentPhase = GamePhase.Building;
        Timerunner = 0f; //Start Counting
        //Debug.Log("Building Phase Started");
        return true;
    }

    public void StartAttackPhase()
    {
        AttackingPhaseCount += 1;
        ResetAnySkill();
        for(int i = 0;i< player.Length; i++){
            player[i].ResetAttackCount(0);
        }
        Warpto(attackposition);
        UseConstructPerk(SkillPhase.Attack);

        if (cardUI != null)
        {
            cardUI.SetActive(false);
        }
        ChangeUI.SetActive(false);
        Building = false;
        Attacking = true;
        currentPhase = GamePhase.Attacking;
        Timerunner = 0f; // Start Count
    }

    public void EndGame()
    {
        // Code to handle end game logic
        Debug.Log("Game Ended");
    }

    private IEnumerator ChangePhaseAfterDelay(GamePhase newPhase)
    {
        changing = true;
        //Debug.Log("Waiting for change time...");
        ChangeUI.SetActive(true);
        yield return new WaitForSeconds(changeTime);
        //Debug.Log("Change time elapsed. Changing phase.");
        changing = false;

        if (newPhase == GamePhase.Building)
        {
            StartBuildingPhase();
        }
        else if (newPhase == GamePhase.Attacking)
        {
            StartAttackPhase();
        }
    }

    private void Warpto(GameObject position)
    {
        Playerself.transform.position = position.transform.position;
        Playerself.transform.rotation = position.transform.rotation;
    }

    private void UseConstructPerk(SkillPhase skillPhase){
        foreach (Construction construction in construction)
        {
            switch (skillPhase)
            {
                case SkillPhase.Build:
                    if (construction.preBuild)
                    {
                        construction.OnUse();
                    }
                    break;

                case SkillPhase.Attack:
                    if (construction.preAttack)
                    {
                        construction.OnUse();
                    }
                    break;
            }
        }
    }
    public void ResetAnySkill(){
            for (int i = 0; i < passiveSkill.Length; i++)
        {
            if (passiveSkill[i] != null)
            {
                Destroy(passiveSkill[i].gameObject);
            }
        }

        // Clean up the array to remove null references
        passiveSkill = passiveSkill.Where(skill => skill != null).ToArray();
    }
}