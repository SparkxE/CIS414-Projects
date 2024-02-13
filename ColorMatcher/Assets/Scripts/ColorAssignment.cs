using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ColorAssignment : MonoBehaviour
{

 
    public List<Material> availableMaterials;
    public GameObject[] gameObjects;
  
 
    void Start()
    {
      //  availableMaterials = new Material[] { Mat1, Mat2, Mat3, Mat4, Mat5, Mat6, Mat7, Mat8, Mat9, Mat10};
      

        RandomizeMaterials();
    }

    void RandomizeMaterials()
    {
       for(int i= 0; i< gameObjects.Length - 1; i++)
        {
            int r = Random.Range(i, gameObjects.Length);
            
            GameObject temp = gameObjects[i];
            gameObjects[i] = gameObjects[r];
            gameObjects[r] = temp;

        }
        for(int i = 0; i<gameObjects.Length; i+=2) 
        {
            Material randomMaterial = availableMaterials[Random.Range(0, availableMaterials.Count)];

            AssignColor(i, randomMaterial);
            AssignColor(i+1, randomMaterial);
          

        }
    }

    void AssignColor(int cube , Material aMaterial)
    {

        Renderer renderer = gameObjects[cube].GetComponent<Renderer>();
        if (renderer != null)
        {
       
            renderer.material = aMaterial;
            Debug.Log("Assigning color " + aMaterial + " to " + (cube+1));
           
        }


    }


}
