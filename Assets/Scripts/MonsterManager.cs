using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float spawnXRight, spawnXLeft, spawnY;

    [Space(10)]

    public GameObject monsterPrefab;
    public GameManager gameManager;

    float spawnIntervalLeft;
    float spawnIntervalRight;

    private GameObject leftMonster, rightMonster;
    private bool isSpawningFromFirstPos = true; // Flag to alternate spawn positions
    private void OnEnable()
    {
        spawnIntervalLeft = Random.Range(0, 1);
        spawnIntervalRight = Random.Range(0, 1);

        StartCoroutine(SpawnLeftMonster());
        StartCoroutine(SpawnRightMonster());
    }
    private IEnumerator SpawnLeftMonster()
    {
        while (true)
        {
            // Spawn a monster on the left side
            leftMonster = Instantiate(monsterPrefab, SpawnPosition(spawnXLeft, spawnY), Quaternion.identity);

            // Wait for the current left-side monster to disappear
            yield return new WaitUntil(() => leftMonster == null);

            // Wait for the specified interval before spawning the next left-side monster
            yield return new WaitForSeconds(spawnIntervalLeft);
        }
    }
    private IEnumerator SpawnRightMonster()
    {
        while (true)
        {
            // Spawn a monster on the right side
            rightMonster = Instantiate(monsterPrefab, SpawnPosition(spawnXRight, spawnY), Quaternion.identity);

            // Wait for the current right-side monster to disappear
            yield return new WaitUntil(() => rightMonster == null);

            // Wait for the specified interval before spawning the next right-side monster
            yield return new WaitForSeconds(spawnIntervalRight);
        }
    }
    private Vector2 SpawnPosition(float x, float y)
    {
        return new Vector2(x, y);
    }
}