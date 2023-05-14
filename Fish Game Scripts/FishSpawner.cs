// This script handles spawning fish game objects in a Unity game. It does this by reducing the
// time between each spawn and randomly choosing a fish to spawn within a given range of y values.

public class FishSpawner : MonoBehaviour
{
    // Vector to store the spawn position
    private Vector2 _spawnPosition;

    // Variables to store the max and minimum y position
    private float _spawnMaxY = 7.5f, _spawnMinY = -3.5f;

    // Public array of fish game objects
    [SerializeField] GameObject[] fish;

    // Timer variables to reduce the spawn timer
    private float _spawnTimer;
    private float _reduceSpawnTimeTimer;
    private float _reduceSpawnTime;
    private float _reduceSpawnTimeMax;

    // Random value for the fish array
    private int _spawnRandomFish;

    void Awake()
    {
        // Getting this transform's position and storing it in the spawnPosition
        _spawnPosition = transform.position;

        // Initializing the time and timer variables
        _spawnTimer = 10f;
        _reduceSpawnTimeTimer = 8f;
        _reduceSpawnTime = 0f;
        _reduceSpawnTimeMax = _spawnTimer - 1.2f;
    }

    void Update()
    {
        // If the reduceSpawnTimeTimer variable is less than 0 and the reduceSpawnTime is less 
        // the max amount of time we want to reduce the spawnTimer variable
        _reduceSpawnTimeTimer -= Time.deltaTime;
        if (_reduceSpawnTimeTimer < 0 && _reduceSpawnTime < _reduceSpawnTimeMax)
        {
            // reset the reduceSpawnTimeTimer variable and increase the amount of time we want
            // subtract from the spawn timer.
            _reduceSpawnTimeTimer = 8f;
            _reduceSpawnTime += .2f;
        }

        // if the spawn timer is less than 0
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            // Instantiate a random fish between a random range on the y axis           
            _spawnRandomFish = Random.Range(1, 20);
            _spawnPosition.y = Random.Range(_spawnMaxY, _spawnMinY);
            Instantiate(fish[_spawnRandomFish], _spawnPosition, transform.transform.rotation);
            // reset and reduce the spawnTimer
            _spawnTimer = 10f - _reduceSpawnTime;
        }
    }
}
