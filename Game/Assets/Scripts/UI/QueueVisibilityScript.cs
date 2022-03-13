using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QueueVisibilityScript : MonoBehaviour
{
    private GameObject slot;
    public GameObject textObject;
    public int queueSlot;
    public int currentSize;
    public TextMeshProUGUI text;
    public Queue[] queue;
    private string id;

    

    // Start is called before the first frame update
    void Start()
    {
        queue = Resources.LoadAll<Queue>("Data/Queue");
        slot = this.gameObject;
        text = textObject.GetComponent<TextMeshProUGUI>();
        currentSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentSize = queue[0].getQueueSize();

        if (currentSize < queueSlot) {
            this.transform.localScale = new Vector3(0, 0, 0);
        } else {
            this.transform.localScale = new Vector3(1, 1, 1);
        }

        text.text = queue[0].getId(queueSlot);
    }
}
