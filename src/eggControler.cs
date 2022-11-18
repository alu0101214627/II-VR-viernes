using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggControler : MonoBehaviour
{
    public monsterControler monster;
    // Start is called before the first frame update
    void Start()
    {
        monster.Aumentar += Increase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Increase() {
        gameObject.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
    }
}
