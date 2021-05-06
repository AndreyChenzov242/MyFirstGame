using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject money;
    public GameObject healthPotions;

    private int posX;
    private int posZ;
    private int moneyCount;
    private float gravity = 20.0F;
    private int healthPotionsCounter;

    public int maxMoneyCount = 20;
    public int maxHealthPotionsCounter = 5;

    void Start()
    {
        StartCoroutine(MoneyDrop());
        StartCoroutine(healthPotionsDrop());
    }
    
    public IEnumerator MoneyDrop()
    {
        while (moneyCount < maxMoneyCount)
        {
            posX = Random.Range(5, 95);
            posZ = Random.Range(5, 95);
            RaycastHit hit;
            Physics.SphereCast(new Vector3(posX, 40.0f, posZ), 0.06354f / 2.0f, Vector3.down, out hit);
            Vector3 position = hit.point;
            money.tag = "Money";
            if (hit.point.y <= 10.0f & hit.point.y > 9.9f)
            {
                Instantiate(money, position, Quaternion.identity);
                yield return new WaitForSeconds(0.01f);
                moneyCount += 1;
            }
        }
    }
    public IEnumerator healthPotionsDrop()
    {
        while (healthPotionsCounter < maxHealthPotionsCounter)
        {
            posX = Random.Range(5, 95);
            posZ = Random.Range(5, 95);
            RaycastHit hit;
            Physics.SphereCast(new Vector3(posX, 40.0f, posZ), 0.06354f / 2.0f, Vector3.down, out hit);
            Vector3 position = hit.point;
            if (hit.point.y <= 10.0f & hit.point.y > 9.9f)
            {
                Instantiate(healthPotions, position, Quaternion.identity);
                yield return new WaitForSeconds(0.01f);
                healthPotionsCounter += 1;
            }
        }
    }
}
