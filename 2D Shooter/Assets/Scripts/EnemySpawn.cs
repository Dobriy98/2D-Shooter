using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemys = new List<GameObject>();
    private float indent = 2;
    private float frequency;

    private void Start() {
        frequency = GameSettings.GetInstance().spawnFrequency;
        StartCoroutine("Spawner");
    }

    IEnumerator Spawner(){
        while(true){
            Vector2 randPos = RandomPosition();
            GameObject enemy = RandomEnemy();
            Instantiate(enemy, randPos,Quaternion.identity);
            yield return new WaitForSeconds(frequency);
        }
    }

    private Vector2 RandomPosition(){
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));

        float randX = Random.Range(screenBounds.x + indent, -screenBounds.x - indent);
        float randY = 0;

        if(randX <= screenBounds.x && randX >= -screenBounds.x){
            float randYTop = Random.Range(screenBounds.y,screenBounds.y + indent);
            float randYBottom = Random.Range(-screenBounds.y,-screenBounds.y - indent);
            List<float> randTopBott = new List<float>(){randYTop,randYBottom};
            randY = randTopBott[Random.Range(0,randTopBott.Count)];
        } else {
            randY = Random.Range(screenBounds.y + indent, -screenBounds.x - indent);
        }

        Vector2 randPos = new Vector2(randX,randY);
        return randPos;
    }

    private GameObject RandomEnemy(){
        int randomNumber = Random.Range(0,enemys.Count);
        return enemys[randomNumber];
    }
}
