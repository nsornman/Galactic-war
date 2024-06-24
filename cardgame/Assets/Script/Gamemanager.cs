using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject attackposition;
    public GameObject playerposition;
    public GameObject ChangeUI;
    public GameObject cardUI;
    public GameObject Playerself;
    public Player[] player;
    public Clickableblock[] clickableblocks;
    public int StarterWood;
    public int StarterMetal;
    public int StarterConcrete;
    public int StarterStone;
    [Header("For Debug")]
    public bool changing;
    public float changeTime = 30f;
    public bool Attacking;
    public float attackTime = 60f;
    public bool Building;
    public float buildingTime = 60f;
    [SerializeField] private float Timerunner;
    private enum GamePhase { None, Building, Attacking }
    private GamePhase currentPhase;

    void Awake()
    {
        clickableblocks = FindObjectsOfType<Clickableblock>();
        player = FindObjectsOfType<Player>();
    }

    void Start()
    {
        SetNewLives();
        StartBuildingPhase();
    }

    void Update()
    {
        if (!changing)
        {
            CheckPhase();
        }
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
    }

    public void SetBlock()
    {
        for (int i = 0; i < clickableblocks.Length; i++)
        {
            clickableblocks[i].Destroyed();
            clickableblocks[i].NewBlock();
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

    public void StartBuildingPhase()
    {
        Warpto(playerposition);
        Debug.Log("Setting cardUI to active");
        if (cardUI != null)
        {
            Debug.Log("cardUI is not null, activating");
            cardUI.SetActive(true);
        }
        else
        {
            Debug.Log("cardUI is null, cannot activate");
        }
        ChangeUI.SetActive(false);
        Building = true;
        Attacking = false;
        currentPhase = GamePhase.Building;
        Timerunner = 0f;
        Debug.Log("Building Phase Started");
    }

    public void StartAttackPhase()
    {
        Warpto(attackposition);
        Debug.Log("Setting cardUI to inactive");
        if (cardUI != null)
        {
            Debug.Log("cardUI is not null, deactivating");
            cardUI.SetActive(false);
        }
        else
        {
            Debug.Log("cardUI is null, cannot deactivate");
        }
        ChangeUI.SetActive(false);
        Building = false;
        Attacking = true;
        currentPhase = GamePhase.Attacking;
        Timerunner = 0f;
        Debug.Log("Attack Phase Started");
    }

    public void EndGame()
    {
        // Code to handle end game logic
        Debug.Log("Game Ended");
    }

    private IEnumerator ChangePhaseAfterDelay(GamePhase newPhase)
    {
        changing = true;
        Debug.Log("Waiting for change time...");
        ChangeUI.SetActive(true);
        yield return new WaitForSeconds(changeTime);
        Debug.Log("Change time elapsed. Changing phase.");
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
    }
}