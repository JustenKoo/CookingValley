using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{ 
    // Food Items
    private int egg = 0;
    private int pumpkin = 0;
    private int lemon = 0;
    private int yogurt = 0;
    private int orange = 0;

    private int cake = 0;
    private int icecream = 0;

    // Dishes
    private GameObject eggObj;
    private GameObject pumpkinObj;
    private GameObject lemonObj;
    private GameObject yogurtObj;
    private GameObject orangeObj;
    private GameObject cakeObj;
    private GameObject icecreamObj;

    private GameObject player;
    private HudManager hud;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hud = GameObject.Find("HUDManager").GetComponent<HudManager>();

        eggObj = (GameObject)Resources.Load("Prefabs/egg", typeof(GameObject));
        pumpkinObj = (GameObject)Resources.Load("Prefabs/pumpkin", typeof(GameObject));
        lemonObj = (GameObject)Resources.Load("Prefabs/lemon", typeof(GameObject));
        yogurtObj = (GameObject)Resources.Load("Prefabs/yogurt", typeof(GameObject));
        orangeObj = (GameObject)Resources.Load("Prefabs/orange", typeof(GameObject));
        cakeObj = (GameObject)Resources.Load("Prefabs/cake", typeof(GameObject));
        icecreamObj = (GameObject)Resources.Load("Prefabs/icecream", typeof(GameObject));
    }
    
    // Functions for updating food items
    public void updateFood(string foodName, int n)
    {
        if (foodName == "egg" || foodName == "egg(Clone)")
            egg += n;
        if (foodName == "pumpkin" || foodName == "pumpkin(Clone)")
            pumpkin += n;
        if (foodName == "lemon" || foodName == "lemon(Clone)")
            lemon += n;
        if (foodName == "yogurt" || foodName == "yogurt(Clone)")
            yogurt += n;
        if (foodName == "orange" || foodName == "orange(Clone)")
            orange += n;
        if (foodName == "cake" || foodName == "cake(Clone)")
            cake += n;
        if (foodName == "icecream" || foodName == "icecream(Clone)")
            icecream += n;
    }

    public int getFoodNum(string foodName)
    {
        int num = 0;
        if (foodName == "egg" || foodName == "egg(Clone)")
            num = egg;
        if (foodName == "pumpkin" || foodName == "pumpkin(Clone)")
            num = pumpkin;
        if (foodName == "lemon" || foodName == "pumpkin(Clone)")
            num = lemon;
        if (foodName == "yogurt" || foodName == "yogurt(Clone)")
            num = yogurt;
        if (foodName == "orange" || foodName == "orange(Clone)")
            num = orange;
        if (foodName == "cake" || foodName == "cake(Clone)")
            num = cake;
        if (foodName == "icecream" || foodName == "icecream(Clone)")
            num = icecream;
        return num;
    }

    public void dropFood(string foodName)
    {
        float offset = Random.Range(1f, 3f);
        int foodNum = 0;
        if (foodName == "egg" && egg >= 1)
        {
            Instantiate(eggObj, new Vector3(player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z + offset), Quaternion.identity);
            foodNum = egg;
            egg -= 1;
        }
        if (foodName == "pumpkin" && pumpkin >= 1)
        {
            Instantiate(pumpkinObj, new Vector3(player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z + offset), Quaternion.identity);
            foodNum = pumpkin;
            pumpkin -= 1;
        }
        if (foodName == "lemon" && lemon >= 1)
        {
            Instantiate(lemonObj, new Vector3(player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z + offset), Quaternion.identity);
            foodNum = lemon;
            lemon -= 1;
        }
        if (foodName == "yogurt" && yogurt >= 1)
        {
            Instantiate(yogurtObj, new Vector3(player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z + offset), Quaternion.identity);
            foodNum = yogurt;
            yogurt -= 1;
        }
        if (foodName == "orange" && orange >= 1)
        {
            Instantiate(orangeObj, new Vector3(player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z + offset), Quaternion.identity);
            foodNum = orange;
            orange -= 1;
        }
        if (foodName == "cake" && cake >= 1)
        {
            Instantiate(cakeObj, new Vector3(player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z + offset), Quaternion.identity);
            foodNum = cake;
            cake -= 1;
        }
        if (foodName == "icecream" && icecream >= 1)
        {
            Instantiate(icecreamObj, new Vector3(player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z + offset), Quaternion.identity);
            foodNum = icecream;
            icecream -= 1;
        }
        hud.updateInventoryText();
        if(foodNum >= 1)
            FindObjectOfType<AudioManager>().Play("Click");
        else
            FindObjectOfType<AudioManager>().Play("Fail");
    }

    public void cookDish(GameObject dish)
    {
        if(dish.name == "cake")
        {
            if (egg >= 3 && pumpkin >= 1 && lemon >= 1)
            {
                updateFood("egg", -3);
                updateFood("pumpkin", -1);
                updateFood("lemon", -1);
                updateFood("cake", 1);
                hud.updateCakeIngredients(egg, pumpkin, lemon);
            }
            else
            {
                // notify player that they don't have enough resources

            }
        }

        if (dish.name == "icecream")
        {
            if (yogurt >= 1 && orange >= 1 && lemon >= 1)
            {
                updateFood("yogurt", -1);
                updateFood("orange", -1);
                updateFood("lemon", -1);
                updateFood("icecream", 1);
                hud.updateIcecreamIngredients(yogurt, lemon, orange);
            }
            else
            {
                // notify player that they don't have enough resources

            }
        }
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
