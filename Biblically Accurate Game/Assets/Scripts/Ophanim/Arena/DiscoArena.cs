using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoArena : MonoBehaviour
{
    public DiscoArenaPad[][] discoArenaPads;
    public GameObject discoArenaPadPrefab;

    int arenaWidth = 9;
    int arenaHeight = 6;
    float padWidth = 4f/3;
    float padHeight = 4f/3;
    float padOffsetX = 4f * 4f / 3;
    float padOffsetY = 2.5f * 4f / 3;

    public void Awake()
    {
        discoArenaPads = new DiscoArenaPad[arenaWidth][];
        for (int i = 0; i < arenaWidth; i++)
        {
            discoArenaPads[i] = new DiscoArenaPad[arenaHeight];
            for (int j = 0; j < arenaHeight; j++)
            {
                GameObject discoArenaPadObject = Instantiate(discoArenaPadPrefab, new Vector3(i * padWidth - padOffsetX, j * padHeight - padOffsetY, 0), Quaternion.identity);
                discoArenaPadObject.transform.parent = transform;
                discoArenaPads[i][j] = discoArenaPadObject.GetComponent<DiscoArenaPad>();
            }
        }
    }

    public void RandomActivation(int activateCount)
    {
        List<DiscoArenaPad> availablePads = new List<DiscoArenaPad>();
        for (int i = 0; i < arenaWidth; i++)
        {
            for (int j = 0; j < arenaHeight; j++)
            {
                if (!discoArenaPads[i][j].isActivated)
                {
                    availablePads.Add(discoArenaPads[i][j]);
                }
            }
        }

        for (int i = 0; i < activateCount; i++)
        {
            int randomIndex = Random.Range(0, availablePads.Count);
            availablePads[randomIndex].PrepareActivation();
            availablePads.RemoveAt(randomIndex);
        }
    }
}
