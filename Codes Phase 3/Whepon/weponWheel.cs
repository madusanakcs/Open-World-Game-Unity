using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace StarterAssets
{
public class weponWheel : MonoBehaviour
{
    public int  ID;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image SelectItem;
       public Image SelectItem1; 
    public bool isSelected=false;
    public Sprite icon; 



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isSelected)
        {
            SelectItem.sprite = icon;
            SelectItem1.sprite = icon;
            itemText.text = itemName;

        }
        
    }

    public void Select()
    {
        isSelected = true;
        SelectedWhepenWheelContrller.WeaponID = ID;
    }

    public void Deselect()
    {
        isSelected = false;
        SelectedWhepenWheelContrller.WeaponID = 0;
    }

    public void HoverEnter()
    {
        anim.SetBool("hover", true);
        itemText.text = itemName;
    }

    public void HoverExit()
    {
        anim.SetBool("hover", false);
        itemText.text = "";
    }
}
}
    