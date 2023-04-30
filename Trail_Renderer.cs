
using UnityEngine;

public class Trail_Renderer : MonoBehaviour
{
    [SerializeField] private float timer, resetTimer;
    [SerializeField] GameObject trailObject;
    private void Start()
    {
        trailObject.transform.position = gameObject.transform.position;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        Instantiate(trailObject);
        if(timer < 0)
        {
            trailObject.transform.position += new Vector3(0f, .2f, 0f) * Time.deltaTime * 2f;
            //trailObject.transform.Translate(new Vector2(0f, .2f));
            timer = resetTimer;
        }
        
    }
}
