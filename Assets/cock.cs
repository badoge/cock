using UnityEngine;
using TMPro;
using System.Collections;
using Steamworks;
using Steamworks.Data;



public class Cock : MonoBehaviour
{
    public ulong cocks = 0;

    public TMP_Text cockCount;

    private IEnumerator luckyCockCoroutine;
    private IEnumerator dropCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

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

        luckyCockCoroutine = LuckyCock();
        dropCoroutine = Drop();
        StartCoroutine(luckyCockCoroutine);
        StartCoroutine(dropCoroutine);

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
        }

        if (cocks == 69)
        {
            TriggerAchievement("69_cocks");
        }

        if (cocks == 420)
        {
            TriggerAchievement("420_cocks");
        }

        if (cocks == 1337)
        {
            TriggerAchievement("1337_cocks");
        }

    }//UpdateCount



    private IEnumerator LuckyCock()
    {
        while (true)
        {
            if (Random.Range(0, 1000000) == 69)
            {
                TriggerAchievement("1_in_1mil");
                StopCoroutine(luckyCockCoroutine);
            }
            yield return new WaitForSeconds(1);
        }
    }//LuckyCock


    private IEnumerator Drop()
    {
        while (true)
        {
            SteamInventory.TriggerItemDropAsync(1);
            yield return new WaitForSeconds(600);
        }
    }//Drop


    public void TriggerAchievement(string achievement)
    {
        var ach = new Achievement(achievement);
        ach.Trigger();
        SteamInventory.TriggerItemDropAsync(1);
    }//TriggerAchievement

}
