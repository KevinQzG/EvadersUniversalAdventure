using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;

    [Header (" Elements ")]
    [SerializeField] private LevelSO[] levels;

    //Luego de incluir Levels/ ya no son necesarios
    //[SerializeField] private Chunk[] chunkPrefabs;
    // [SerializeField] private Chunk[] levelChunk;
    private GameObject finishLine;

    private void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
        } else{
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        finishLine = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateLevel()
    {
        int currentLevel = GetLevel();

        currentLevel = currentLevel % levels.Length;

        LevelSO level = levels[currentLevel];
        CreateLevel(level.chunks);
    }

    //Metodos antes de Levels/
    private void CreateLevel(Chunk[] levelChunks)
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];

            if(i>0){
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity,transform);
            chunkPosition.z += chunkInstance.GetLength()/2;
        }
    }



    public float GetFinishZ()
    {
        return finishLine.transform.position.z;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level", 0);
    }

    //Metodos antes de Levels/
    // private void CreateOrderedLevel()
    // {
    //     Vector3 chunkPosition = Vector3.zero;
    //     for (int i = 0; i < levelChunk.Length; i++)
    //     {
    //         Chunk chunkToCreate = levelChunk[i];

    //         if(i>0){
    //             chunkPosition.z += chunkToCreate.GetLength() / 2;
    //         }
    //         Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity,transform);
    //         chunkPosition.z += chunkInstance.GetLength()/2;
    //     }
    // }

    // private void CreateRandomLevel()
    // {
    //     Vector3 chunkPosition = Vector3.zero;
    //     for (int i = 0; i < 5; i++)
    //     {
    //         Chunk chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

    //         if(i>0){
    //             chunkPosition.z += chunkToCreate.GetLength() / 2;
    //         }
    //         Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity,transform);
    //         chunkPosition.z += chunkInstance.GetLength()/2;
    //     }
    // }
}