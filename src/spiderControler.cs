using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderControler : MonoBehaviour
{
    public monsterControler monster;
    public float RayDistance = 4f;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        monster.nearSpiders += checkForMonster;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void checkForMonster() {
        GameObject monster = GameObject.FindWithTag("Monster");
        Vector3 directionMonster = monster.transform.position - gameObject.transform.position;
        directionMonster.y = 0.5f;
        //Debug.DrawRay(gameObject.transform.position,directionMonster, Color.red);
        directionMonster = getUnitVector(directionMonster);
        RaycastHit hit;
        timer += Time.deltaTime;
        if (Physics.Raycast(gameObject.transform.position, directionMonster, out hit, RayDistance)) {
            if (hit.transform.tag == "Monster") {
                if (timer > 2) {
                    timer = 0;
                    monsterControler monsterControler = monster.GetComponent<monsterControler>();
                    if (monsterControler.HP > 0) monsterControler.HP--;
                    if (monsterControler.HP == 0) {
                        Debug.Log("¡Has muerto! Game over");
                    } else {
                        Debug.Log("Dañado! La vida restante es " + monsterControler.HP);
                    }
                }
            }
        }
    }
    private Vector3 getUnitVector(Vector3 vector) {
        float modulo = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2));
        return new Vector3(vector.x / modulo, vector.y / modulo, vector.z / modulo);
    }
}
