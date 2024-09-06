using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : /*NetworkBehaviour*/MonoBehaviour
{
    
    [Header("Assign Games Variable")]
    public int StartingCC = 5;
    public int StartingSC = 3;
    public int StarterWood;
    public int StarterMetal;
    public int StarterConcrete;
    public int StarterStone;
    
    [Header("Assign GameObjects")]
    public string attackPosTag;
    [SerializeField] private GameObject[] attackposition;
    public string playerPosTag;
    [SerializeField] private GameObject[] playerposition;
    public string changeUITag;
    public ChangeUI[] changeUI;
    public string CardUITag;
    public InventoryManager[] cardUI;
    public Camera[] Playercam;
    [SerializeField] private protected Player[] player;
    private  protected Clickableblock[] clickableblocks;
    [SerializeField] private protected Construction[] construction;
    private protected PassiveSkill[] passiveSkill;
    public PopUpScript popUpScript;
    [Header("Game Phase")]
    public bool changing;
    public float changeTime = 10f;
    public bool Attacking;
    public float attackTime = 60f;
    public int AttackingPhaseCount;
    public bool Building;
    public float buildingTime = 60f;
    public int BuildingPhaseCount;
    public int FreeAttackperround;
    /*[SyncVar]*/public float Timerunner;
    public enum GamePhase {None, Building, Attacking}
    public enum SkillPhase {Build , Attack}
    /*[SyncVar]*/ public GamePhase currentPhase;

    public virtual void FixedUpdate()
    {
        clickableblocks = FindObjectsOfType<Clickableblock>();
        player = FindObjectsOfType<Player>();
        Playercam = FindObjectsOfType<Camera>();
        playerposition = GameObject.FindGameObjectsWithTag(playerPosTag); //need player position after all prefab are spawning
        attackposition = GameObject.FindGameObjectsWithTag(attackPosTag); //need attack Pos to shuffle between 2 player
        construction = FindObjectsOfType<Construction>();
        passiveSkill = FindObjectsOfType<PassiveSkill>();
        popUpScript = FindObjectOfType<PopUpScript>();
    }
    protected virtual void Start()
    {
        StartCoroutine(Waitfor());
    }
    // void FixedUpdate()
    // {
    //     SetNewLives();
    // }
    public virtual IEnumerator Waitfor(){
        yield return new WaitUntil(Waitfor2ndPlayer);
        changeUI = FindObjectsOfType<ChangeUI>();
        cardUI = FindObjectsOfType<InventoryManager>();
        foreach (var item in changeUI)
        {
            item.gameObject.SetActive(false);
        }
        StartBuildingPhase();
        SetNewLives();
        //popUpScript.AddToQueue("Wait Finished");
    }

    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            SetNewLives();
        }
        if (!changing)
        {
            CheckPhase();
        }
    }
    public virtual bool Waitfor2ndPlayer(){
        if(Playercam.Length> 1 && Playercam[1] != null){
            return true;
        }return false;
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
        //popUpScript.AddToQueue("SetNewLives");
    }

    public virtual void SetBlock()
    {
        for (int i = 0; i < clickableblocks.Length; i++)
        {
            clickableblocks[i].Destroyed();
            clickableblocks[i].NewBlock();
        }
    }
    public virtual void SetUpCard(){
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

    public virtual bool StillAlive()
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
        WarptoBuild();
        //Debug.Log("Setting cardUI to active");
        if (cardUI != null)
        {
            //Debug.Log("cardUI is not null, activating");
            for(int i = 0;i< cardUI.Length;i++){
                cardUI[i].gameObject.SetActive(true);
            }
        }
        else
        {
            //Debug.Log("cardUI is null, cannot activate");
        }
        for(int j = 0;j< changeUI.Length ;j++){
            changeUI[j].gameObject.SetActive(false);
        }
        Building = true;
        Attacking = false;
        currentPhase = GamePhase.Building;
        Timerunner = 0f; //Start Counting
        //Debug.Log("Building Phase Started");
        return true;
    }
    public virtual void WarptoBuild(){
        for(int i = 0;i< Playercam.Length;i++){ //Not Supporting Own player building position
            Warpto(i , playerposition[i]);
        }
    }
    private protected virtual void SwapAttackPositions()
    {
        if (attackposition.Length >= 2)
        {
            GameObject temp = attackposition[0];
            attackposition[0] = attackposition[1];
            attackposition[1] = temp;
        }
    }
    public virtual void StartAttackPhase()
    {
        AttackingPhaseCount += 1;
        ResetAnySkill();
        for(int i = 0;i< player.Length; i++){
            player[i].ResetAttackCount(0);
        }
        if(AttackingPhaseCount <= 1){
            SwapAttackPositions();
        }
        WarptoAttack();
        UseConstructPerk(SkillPhase.Attack);

        if (cardUI != null)
        {
            for(int i = 0 ;i< cardUI.Length;i++){
                cardUI[i].gameObject.SetActive(false);
            }
        }
        for(int j = 0;j< changeUI.Length ;j++){
            changeUI[j].gameObject.SetActive(false);
        }
        Building = false;
        Attacking = true;
        currentPhase = GamePhase.Attacking;
        Timerunner = 0f; // Start Count
    }
    public virtual void WarptoAttack(){
        for(int i = 0;i< Playercam.Length ; i++){ //Not Supporting Enemy multiple attack position / shuffing attack pos
            Warpto(i , attackposition[i]);
        }
    }

    public void EndGame()
    {
        // Code to handle end game logic
        SceneManager.LoadScene(0);
        Debug.Log("Game Ended");
    }

    public IEnumerator ChangePhaseAfterDelay(GamePhase newPhase)
    {
        changing = true;
        //Debug.Log("Waiting for change time...");
        for(int j = 0;j< changeUI.Length ;j++){
            changeUI[j].gameObject.SetActive(true);
        }
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

    public void Warpto(int index,GameObject position)
    {
        Playercam[index].transform.position = position.transform.position;
        Playercam[index].transform.rotation = position.transform.rotation;
    }

    private protected void UseConstructPerk(SkillPhase skillPhase){
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