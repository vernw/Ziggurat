using UnityEngine;
using System.Collections;

public class Sacrifice : MonoBehaviour {

    [SerializeField]
    private GameObject _altar;
    public GameObject altar
    {
        get { return _altar; }
        set { _altar = value; }
    }

    private bool _drop;
    public bool drop
    {
        get { return _drop; }
        set
        {
            _drop = value;
            if (_drop == true)
                dropToAltar();
        }
    }

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().useGravity = true;
            drop = true;
            Debug.Log("Drop!");
        }
    }
	
	public void dropToAltar()
    {
        gameObject.transform.position = altar.transform.position + new Vector3(0, 2, 0);
    }
}
