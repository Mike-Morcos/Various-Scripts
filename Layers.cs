using UnityEngine;

public class Layers : MonoBehaviour {

    public Rigidbody2D rb;
    public Transform[] Target;
    public Transform Player;
    public SpriteRenderer[] target;

    private int count = 0;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
    {
        while (count < 2)
        {
            if (Target[count].position.y < Player.position.y)
                target[count].sortingLayerName = "2";
                //target[count].sortingOrder = 2;
            else
                //target[count].sortingOrder = 0;
                target[count].sortingLayerName = "0";

            count++;
        }
        count = 0;
    }
}
