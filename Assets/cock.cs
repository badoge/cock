using UnityEngine;
using TMPro;
using System.Collections;
using Steamworks;
using Steamworks.Data;



public class Cock : MonoBehaviour
{
    public ulong cocks = 0;

    public TMP_Text cockCount;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            SteamClient.Init(3059750);
            SteamInventory.LoadItemDefinitions();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            // Couldn't init for some reason (steam is closed etc)
        }

        //InvokeRepeating("asd", 5.0f, 5.0f);


    }//Start

    // Update is called once per frame
    void Update()
    {
        SteamClient.RunCallbacks();
    }//Update




    void OnApplicationQuit()
    {
        SteamClient.Shutdown();
    }//OnApplicationQuit




    public void UpdateCount()
    {
        cockCount.text = $"{++cocks:n0}";

        if (cocks == 1)
        {
            TriggerAchievement("1_cock");
            SteamInventory.TriggerItemDropAsync(1);
        }

    }//UpdateCount


    public void TriggerAchievement(string achievement)
    {
        var ach = new Achievement(achievement);
        ach.Trigger();
    }//TriggerAchievement

}
