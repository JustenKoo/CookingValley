using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour, GameStateManager.StateListener
{
    public GameObject InventoryMenu;
    public GameObject CookingMenu;
    public GameObject DialogueBox;

    public CookingController cc;
    private NPCController npc_c;
    public PlayerInventory playerInv;
    public ThirdPersonCameraController playerCam;

    // HUD FOR DISPLAYING TIME
    private TimeManager tm;
    public TextMeshProUGUI timeText;

    // Food Variables //

    // CAKE VARIABLES //
    // Cake Ingredient TMPro for Inventory
    public TextMeshProUGUI cakeInvText;

    public TextMeshProUGUI eggInvTextForCake;
    public TextMeshProUGUI pimpkinInvTextForCake;
    public TextMeshProUGUI lemonInvTextForCake;

    // Cake Inredient TMPro for Cooking Menu
    public TextMeshProUGUI eggTextForCake;
    public TextMeshProUGUI pumpkinTextForCake;
    public TextMeshProUGUI lemonTextForCake;

    // ICECREAM VARIABLES // 
    // Icecream Ingredient TMPro for Inventory
    public TextMeshProUGUI icecreamInvText;

    public TextMeshProUGUI yogurtInvTextForIC;
    public TextMeshProUGUI lemonInvTextForIC;
    public TextMeshProUGUI orangeInvTextForIC;

    // Icecream Ingredient TMPro for Cooking Menu
    public TextMeshProUGUI yogurtTextForIC;
    public TextMeshProUGUI lemonTextForIC;
    public TextMeshProUGUI orangeTextForIC;

    void Start()
    {
        GameStateManager.AddListener(this);

        // Managers + Controllers
        tm = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        npc_c = GameObject.Find("NPC").GetComponent<NPCController>();

        // Menus
        InventoryMenu = GameObject.Find("InventoryMenu");
        CookingMenu = GameObject.Find("CookingMenu");
        DialogueBox = GameObject.Find("DialogueBox");
        CookingMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        DialogueBox.SetActive(false);

        // Player GameObjects
        playerInv = GameObject.Find("PlayerInventory").GetComponent<PlayerInventory>();
        playerCam = GameObject.Find("ThirdPersonCameraController").GetComponent<ThirdPersonCameraController>();

        // Initialize HUD
        timeText.text = "Day " + tm.gameDay + " | Time " + tm.gameTime + " | " + tm.gameTimeCategory;

        eggTextForCake.text = "Eggs x3 / x" + playerInv.getFoodNum("egg");
        pumpkinTextForCake.text = "Pumpkin x3 / x" + playerInv.getFoodNum("pumpkin");
        lemonInvTextForCake.text = "Lemon x3 / x" + playerInv.getFoodNum("lemon");

        // Initialize Inventory
        yogurtInvTextForIC.text = "x" + playerInv.getFoodNum("yogurt");
        lemonInvTextForCake.text = "x" + playerInv.getFoodNum("lemon");
        orangeInvTextForIC.text = "x" + playerInv.getFoodNum("orange");

        cakeInvText.text = "x" + playerInv.getFoodNum("cake");
        icecreamInvText.text = "x" + playerInv.getFoodNum("icecream");

        // Icecream Ingredient TMPro for Cooking Menu
        yogurtTextForIC.text = "Yogurt x1 / x" + playerInv.getFoodNum("yogurt");
        lemonTextForCake.text = "Lemon x1 / x" + playerInv.getFoodNum("lemon");
        orangeTextForIC.text = "Orange x1 / x" + playerInv.getFoodNum("orange");
    }

    void Update()
    {
        timeText.text = "Day " + tm.gameDay + " | Time " + Mathf.Floor(tm.gameTime) + " | " + tm.gameTimeCategory;
        // Opens + Closes the Inventory Menu
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (GameStateManager.currScreen != GameStateManager.activeScreen.INVENTORY)
            {
                updateInventoryText();
                InventoryMenu.SetActive(true);
                GameStateManager.ChangeActiveScreen(GameStateManager.activeScreen.INVENTORY);
            }

            else
                ExitAllMenus();

            OnStateChange(GameStateManager.currScreen);
        }

        // Opens + Closes the Cooking Menu
        if(Input.GetKeyDown("f"))
        {
            if (cc.getPlayerNearFire() && GameStateManager.currScreen != GameStateManager.activeScreen.COOKING)
            {
                updateAllIngredients();
                CookingMenu.SetActive(true);
                GameStateManager.ChangeActiveScreen(GameStateManager.activeScreen.COOKING);
            }

            else if (npc_c.getPlayerNearNPC() && GameStateManager.currScreen != GameStateManager.activeScreen.DIALOGUE)
            {
                DialogueBox.SetActive(true);
                GameStateManager.ChangeActiveScreen(GameStateManager.activeScreen.DIALOGUE);
            }

            else
                ExitAllMenus();

            OnStateChange(GameStateManager.currScreen);
        }
    }

    public void ExitAllMenus()
    {
        playerCam.freezePlayerMouse(false);
        InventoryMenu.SetActive(false);
        CookingMenu.SetActive(false);
        DialogueBox.SetActive(false);
        GameStateManager.ChangeActiveScreen(GameStateManager.activeScreen.IN_GAME);
    }

    public void updateInventoryText()
    {
        eggInvTextForCake.text = "Egg x" + playerInv.getFoodNum("egg");
        pimpkinInvTextForCake.text = "Pumpkin x" + playerInv.getFoodNum("pumpkin");
        lemonInvTextForCake.text = "Lemon x" + playerInv.getFoodNum("lemon");
        orangeInvTextForIC.text = "Orange x" + playerInv.getFoodNum("orange");
        yogurtInvTextForIC.text = "Yogurt x" + playerInv.getFoodNum("yogurt");
        cakeInvText.text = "Cake x" + playerInv.getFoodNum("cake");
        icecreamInvText.text = "Icecream x" + playerInv.getFoodNum("icecream");
    }

    public void updateAllIngredients()
    {
        updateCakeIngredients(playerInv.getFoodNum("egg"),playerInv.getFoodNum("pumpkin"),playerInv.getFoodNum("lemon"));
        updateIcecreamIngredients(playerInv.getFoodNum("yogurt"), playerInv.getFoodNum("lemon"), playerInv.getFoodNum("orange"));
    }

    public void updateCakeIngredients(int egg, int pumpkin, int lemon)
    {
        eggTextForCake.text = "Eggs x3 / x" + egg;
        pumpkinTextForCake.text = "Pumpkin x1 / x" + pumpkin;
        lemonTextForCake.text = "Lemon x1 / x" + lemon;
    }

    public void updateIcecreamIngredients(int yogurt, int lemon, int orange)
    {
        yogurtTextForIC.text = "Yogurt x1 / x" + yogurt;
        lemonTextForIC.text = "Lemon x1 / x" + lemon;
        orangeTextForIC.text = "Orange x1 / x" + orange;
    }

    public void OnStateChange(GameStateManager.activeScreen newScreen)
    {
        if (newScreen == GameStateManager.activeScreen.COOKING || newScreen == GameStateManager.activeScreen.DIALOGUE || newScreen == GameStateManager.activeScreen.INVENTORY)
        {
            playerCam.freezePlayerMouse(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            FindObjectOfType<AudioManager>().Play("Click");
        }

        else if (newScreen == GameStateManager.activeScreen.IN_GAME)
        {
            playerCam.freezePlayerMouse(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
