using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentSwapPrompt : MonoBehaviour
{

    public Button replaceEquipment1Button;
    public Button replaceEquipment2Button;

    [SerializeField] private EquipmentBehavior equipmentBehavior; 
    private GameObject newEquipment;
    private void Start()
    {
        //replaceEquipment1Button.gameObject.SetActive(false);    
       // replaceEquipment2Button.gameObject.SetActive(false) ;

        

       // newEquipment = GameObject.FindGameObjectWithTag("Equipment");

        //replaceEquipment1Button.onClick.AddListener(() => equipmentBehavior.ReplaceEquipment(0, newEquipment));
       // replaceEquipment2Button.onClick.AddListener(() => equipmentBehavior.ReplaceEquipment(1, newEquipment));
    }


}
 