using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject panel2;
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldButtomY = -6f;
    public float energyShieldRadius = 1.5f;
    public List<GameObject> basketList;
 
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 1; i <= numEnergyShield; i++)
        {
            GameObject tBasketGo =
                Instantiate<GameObject>(energyShieldPrefab);
            tBasketGo.transform.position = new Vector3(0,
                energyShieldButtomY, 0);
            tBasketGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            basketList.Add(tBasketGo);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("_0Scene");
    }
    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray =
            GameObject.FindGameObjectsWithTag("DragonEgg");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count-1; 
        GameObject tBasketGo = basketList[basketIndex]; 
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);
        
        GameObject[] Dragon =
            GameObject.FindGameObjectsWithTag("Green");
        if (basketList.Count == 0)
        {
            foreach (GameObject tGO in Dragon)
            {
                Destroy(tGO);
            }
            panel2.SetActive(true);
            StartCoroutine(ExampleCoroutine());
            
        }
    }
}
