using UnityEngine;
using System.Collections;

public class Makeship : MonoBehaviour {
    public GameObject ship;
    Vector3 locationship = new Vector3(0,0,0);
    int randumlocation;
    public static Makeship makeshipinstan;
    float datalocation;
    // Use this for initialization
    void Start () {
        locationship.z = 40;
        StartCoroutine(inthecreate(30));
        makeshipinstan = this;
	}
	public IEnumerator inthecreate(int value)
    {
        yield return new WaitForSeconds(1f);
        locationship.x = 0;
        locationship.y = 1.6f;
        locationship.z = 60;
        // locationship = Makesupway.location;
        for (int i = 0; i < value; i++)
        {
            locationship.z = datalocation + 8 * i;
            if (i==0||i==5||i==10||i==15||i==20||i==25||i==29)
            {
                randumship();
            }
            yield return new WaitForSeconds(0.01f);
        }
        datalocation = locationship.z;
    }
    int locationz;
    void randumship()
    {
        randumlocation = Random.Range(0, 3);
        Debug.Log("cho ra "+randumlocation);
        if (randumlocation == 0)
        {
            Getlocationy();
            Instantiate(ship, locationship, transform.rotation);
        }
        else if (randumlocation == 1)
        {
            Getlocationy();
            for (int j = 0; j < 3; j++)
            {
                Instantiate(ship, locationship, transform.rotation);
                locationship.z += 8;
            }
        }
        else if (randumlocation == 2)
        {
            Getlocationy();
            for (int j = 0; j < 5; j++)
            {
                Instantiate(ship, locationship, transform.rotation);
                locationship.z += 8;
            }
        }
    }
    void Getlocationy()
    {
        locationz = Random.Range(0, 3);
        switch (locationz)
        {
            case 0:
                locationship.x = 0f;
                break;
            case 1:
                locationship.x = -2.5f;
                break;
            case 2:
                locationship.x = 2.5f;
                break;
            default:
                break;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
