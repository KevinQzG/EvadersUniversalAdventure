using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Chunk[] chunksPrefabs;
    [SerializeField] private Chunk[] levelChunks;

    // Start is called before the first frame update
    void Start()
    {
        CreateOrderedLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateOrderedLevel()
    {
        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];

            if (i > 0)
                chunkPosition.z += chunkToCreate.GetLength() / 2;

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }

    private void CreateRandomLevel()
    {
        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            Chunk chunkToCreate = chunksPrefabs[Random.Range(0, chunksPrefabs.Length)];

            if (i > 0)
                chunkPosition.z += chunkToCreate.GetLength() / 2;

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }
}
