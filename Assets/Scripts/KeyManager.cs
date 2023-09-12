using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;

    [System.NonSerialized] public bool[] keyStatus = new bool[4];
    private float repeatTime = 2f;
    private int index;
    private PlayerManager playerManagercs;

    void Start()
    {
        StartCoroutine(RandomKey());
        playerManagercs = GetComponent<PlayerManager>();
    }
    

    private IEnumerator RandomKey()
    {        
        yield return new WaitForSeconds(0.5f);

        index = Random.Range(0, 4);
        keys[index].SetActive(false);
        keyStatus[index] = true;
    
        if (Random.Range(0,2) == 0)
        {
            if (repeatTime > 1f)
            {
                repeatTime -= 0.05f;
            }
        }
        
        yield return new WaitForSeconds(repeatTime);
        
        ResetKey();
        playerManagercs.score--;
        playerManagercs.SetScore(false);
    }

    public void ResetKey()
    {
        StopAllCoroutines();
        keyStatus[index] = false;
        keys[index].SetActive(true);
        StartCoroutine(RandomKey());
    }

}
