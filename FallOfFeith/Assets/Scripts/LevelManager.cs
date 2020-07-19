using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager sharedInstance;
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    public List<LevelBlock> currentLevelBlock = new List<LevelBlock>();
    public Transform levelStartPosition;


    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateInitialBlocks()
    {
        for(int i = 0; i < 5; i++)
        {
            AddLevelBlock();
        }
    }

    public void AddLevelBlock()
    {

        int randID = Random.Range(0, allTheLevelBlocks.Count);
        LevelBlock blok;
        Vector3 spawnPosition = Vector3.zero;
        if (currentLevelBlock.Count == 0)
        {
            blok = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
        }
        else
        {
            blok = Instantiate(allTheLevelBlocks[randID]);
            spawnPosition = currentLevelBlock[currentLevelBlock.Count - 1].EndPoint.position;
        }
        blok.transform.SetParent(this.transform, false);
        Vector3 correction = new Vector3(spawnPosition.x - blok.startPoint.position.x,
                                         spawnPosition.y - blok.startPoint.position.y, 0);
        blok.transform.position = correction;
        currentLevelBlock.Add(blok);

    }

    public void RemoveLevelBlock()
    {
        LevelBlock oldBlok = currentLevelBlock[0];
        currentLevelBlock.Remove(oldBlok);
        Destroy(oldBlok.gameObject);
    }

    public void RemoveAllLevelBlocks()
    {
        while(currentLevelBlock.Count > 0)
        {
            RemoveLevelBlock();
        }
    }
}
