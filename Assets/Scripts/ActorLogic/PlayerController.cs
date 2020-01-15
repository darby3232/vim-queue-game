using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public struct KeyMap
    {
        public KeyCode key;
        public string direction; //Up, Down, Left, Right
    }

    private enum Direction
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    public ControlsManager controlsManager;
    public InputQueueUI inputQueueUI;
    
    public GameObject bombPrefab;

    /*----Player Moving Data----*/
    public float playerSpeed;
    private bool playerMoving;
    private Vector3 playerStartingPosition;
    private Vector3 playerDestination;
    /*--------------------------*/
    
    private KeyMap[] km = new KeyMap[4];
    private KeyCode lastPress = KeyCode.None;

    /*----Player Scene Data---*/
    private MySceneManager sm;
    private Player player;
    private PlayerStats ps;
    /*------------------------*/

    /*----Player Input Logic----*/
    private bool acceptingInputs;
    private KeyCode [] acceptedInputs = { KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.B, KeyCode.D };
    private Queue<KeyCode> inputQueue = new Queue<KeyCode>();
    /*--------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        //populate km with starting values
        km[0].key = KeyCode.H;
        km[0].direction = "Left";

        km[1].key = KeyCode.J;
        km[1].direction = "Up";

        km[2].key = KeyCode.K;
        km[2].direction = "Down";

        km[3].key = KeyCode.L;
        km[3].direction = "Right";

        controlsManager.UpdateImages(km);

        GameObject sceneObj = GameObject.Find("SceneManager");
        if (sceneObj is null)
            Debug.LogError("No SceneManager in scene.");
        sm = sceneObj.GetComponent<MySceneManager>();

        ps = GetComponent<PlayerStats>();

        player = GetComponent<Player>();
        acceptingInputs = true;
        playerMoving = false;
    }

    
    private void Update()
    {
        //Accumulate Inputs
        if (acceptingInputs)
        {
            foreach (KeyCode kc in acceptedInputs)
                if (CheckKeyCode(kc))
                {
                    if (inputQueue.Count == 0)
                        ps.StartTimer();

                    inputQueue.Enqueue(kc);
                }

            if (Input.GetKeyDown(KeyCode.Return))
                acceptingInputs = false;
        }
    }

    private void FixedUpdate()
    {
        if(!acceptingInputs)
        {
            //Parse Inputs, Move Player and Begin to Accept Inputs Once More
            if (playerMoving)
                MovePlayer();
            else if (inputQueue.Count > 0)
                UseInput(inputQueue.Dequeue());
            else
                acceptingInputs = true;
        }
    }

    private void MovePlayer()
    {
        Vector3 moveVector = (playerDestination - playerStartingPosition) * playerSpeed * Time.deltaTime;
        transform.position += moveVector;
        
        if((playerDestination - playerStartingPosition).magnitude <= (transform.position - playerStartingPosition).magnitude)
        {
            transform.position = playerDestination;
            playerMoving = false;
        }

    }

    private void UseInput(KeyCode kc)
    {
        ps.AddStep();

        bool actionTaken = false;

        if (!actionTaken)
            actionTaken = PlaceBomb(kc);
        
        if (!actionTaken)
            actionTaken = MoveInput(kc);

        if (actionTaken)
            sm.UpdateScene();
    }

    private bool CheckKeyCode(KeyCode kc)
    {
        if (Input.GetKeyDown(kc))
        {
            inputQueueUI.AddInput(kc.ToString().ToCharArray()[0]);
            return true;
        }

        return false;
    }

    private void CreateBomb(Direction dir)
    {
        Vector3 offset;
        switch (dir)
        {
            case Direction.UP:
                offset = Vector2.up;
                break;
            case Direction.DOWN:
                offset = Vector2.down;
                break;
            case Direction.RIGHT:
                offset = Vector2.right;
                break;
            case Direction.LEFT:
                offset = Vector2.left;
                break;
            default:
                offset = new Vector3(0, 0, 0);
                break;
        }
        LitBomb bomb;
        bomb = Instantiate(bombPrefab, transform.position + offset, Quaternion.identity).GetComponent<LitBomb>();
        sm.AddBomb(bomb);
    }

    private bool PlaceBomb(KeyCode kc)
    {
        if (lastPress == KeyCode.B)
        {
            for (int i = 0; i < 4; i++)
            {
                if (kc == km[i].key)
                {
                    switch (km[i].direction)
                    {
                        case "Left":
                            if(CanPlaceBomb(Direction.LEFT))
                                CreateBomb(Direction.LEFT);
                            lastPress = KeyCode.None;
                            return true;
                        case "Right":
                            if (CanPlaceBomb(Direction.RIGHT))
                                CreateBomb(Direction.RIGHT);
                            lastPress = KeyCode.None;
                            return true;
                        case "Up":
                            if (CanPlaceBomb(Direction.UP))
                                CreateBomb(Direction.UP);
                            lastPress = KeyCode.None;
                            return true;
                        case "Down":
                            if (CanPlaceBomb(Direction.DOWN))
                                CreateBomb(Direction.DOWN);
                            lastPress = KeyCode.None;
                            return true;
                    }
                }
            }
        }
        else if (kc == KeyCode.B)
        {
            inputQueueUI.AddInput('b');
            lastPress = KeyCode.B;
            return true;
        }
        return false;
    }

    private bool CanPlaceBomb(Direction md)
    {
        if (!player.TryUseBomb())
            return false;

        Vector2 vec;
        switch (md)
        {
            case Direction.UP:
                vec = Vector2.up;
                break;
            case Direction.DOWN:
                vec = Vector2.down;
                break;
            case Direction.LEFT:
                vec = Vector2.left;
                break;
            case Direction.RIGHT:
                vec = Vector2.right;
                break;
            default:
                vec = Vector2.up;
                break;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec, 1.0f);

        // return if hit collides w/ something
        if (hit.collider != null)
            return false;
        else
            return true;
    }

    private bool MoveInput(KeyCode kc)
    {

        float xTransform = 0f;
        float yTransform = 0f;

        //Check if key down
        for (int i = 0; i < 4; i++)
        {
            if (kc == km[i].key)
            {
                switch (km[i].direction)
                {
                    case "Left":
                        if(CanMove(Direction.LEFT))
                            xTransform -= 1.0f;
                        break;
                    case "Right":
                        if (CanMove(Direction.RIGHT))
                            xTransform += 1.0f;
                        break;
                    case "Up":
                        if (CanMove(Direction.UP))
                            yTransform += 1.0f;
                        break;
                    case "Down":
                        if (CanMove(Direction.DOWN))
                            yTransform -= 1.0f;
                        break;
                }
            }
        }

        playerStartingPosition = transform.position;
        playerDestination = new Vector3(transform.position.x + xTransform, transform.position.y + yTransform, 0f);

        playerMoving = true;

        return xTransform != 0 || yTransform != 0;
    }
    
    public void ReceiveExplosion(Vector2 vec)
    {
        if (CanMove(vec))
            transform.Translate(vec);
    }


    private bool CanMove(Vector2 vec)
    {
        if (vec == Vector2.up)
            return CanMove(Direction.UP);

        if (vec == Vector2.down)
            return CanMove(Direction.DOWN);

        if (vec == Vector2.left)
            return CanMove(Direction.LEFT);

        if (vec == Vector2.right)
            return CanMove(Direction.RIGHT);

        return false;
    }

    private bool CanMove(Direction md)
    {

        Vector2 vec;
        switch (md)
        {
            case Direction.UP:
                vec = Vector2.up;
                break;
            case Direction.DOWN:
                vec = Vector2.down;
                break;
            case Direction.LEFT:
                vec = Vector2.left;
                break;
            case Direction.RIGHT:
                vec = Vector2.right;
                break;
            default:
                vec = Vector2.up;
                break;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec, .6f);

        // return if hit collides w/ something
        if (hit.collider != null)
        {
            if(hit.collider.tag == "WalkableTile" || hit.collider.tag == "Item")
            {
                return true;
            }

            if(hit.collider.tag == "Actor")
            {
                


            }

            if(hit.collider.tag == "UnwalkableTile")
            {
                //Moving Wall Tile
                MovableBlock mb = hit.transform.gameObject.GetComponent<MovableBlock>();
                if (mb != null)
                    return mb.AcceptCollision(vec);


                //Wall
                return false;
            }            
        }

        return true;
    }

    public string GetKeyDirection(KeyCode keycode)
    {
        for(int i = 0; i < 4; i++)
            if(km[i].key == keycode)          
                return km[i].direction;
          
        return null;
    }
}
