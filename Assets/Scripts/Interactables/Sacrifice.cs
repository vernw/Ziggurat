using UnityEngine;
using System.Collections;

public class Sacrifice : MonoBehaviour, IInteractable {

    [SerializeField]
    private GameObject _altar;
    public GameObject altar
    {
        get { return _altar; }
        set { _altar = value; }
    }

    // Toggled by interact call
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

    // Toggled by player interact hitbox collision
    [SerializeField]
    private bool _selected;
    public bool selected
    {
        get { return _selected; }
        set { _selected = value; }
    }

    void Start()
    {
        // Keeps sacrifice floating until dropped onto altar
        GetComponent<Rigidbody>().useGravity = false;
        selected = false;
    }
	
	public void dropToAltar()
    {
        // Warps to altar
        gameObject.transform.position = altar.transform.position + new Vector3(0, 2, 0);
    }

    public void interact()
    {
            GetComponent<Rigidbody>().useGravity = true;
            drop = true;
            Debug.Log("Drop!");
    }

    void Update()
    {
        // Drops sacrifice onto Altar on key down
        if (Input.GetKeyDown(KeyCode.E) && selected)
        {
            interact();
        }
    }
}
