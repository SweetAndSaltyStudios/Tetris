using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Grid_Tile_Prefab;
    public GameObject Grid_Border_Prefab;
    public GameObject Tetromino_Block_Prefab;

    private readonly GameObject[] tetrominos = new GameObject[7];
    private readonly int grid_Width = 12;
    private readonly int grid_Height = 18;
    private GameObject[] grid;

    private bool isGameOver;

    private void Start()
    {
        CreateTetrominos();

        CreateGrid();

    }

    private void Update()
    {
        if(isGameOver)
            return;


    }

    private void CreateTetrominos()
    {
        var tetrominosParent = new GameObject("Tetrominos").transform;

        var I_tetromino = new GameObject("I").transform;
        I_tetromino.SetParent(tetrominosParent);
        tetrominos[0] = SpawnPrefabInstnace(Tetromino_Block_Prefab, I_tetromino, new Vector2(0, 0));
        tetrominos[0] = SpawnPrefabInstnace(Tetromino_Block_Prefab, I_tetromino, new Vector2(0, 0));
        tetrominos[0] = SpawnPrefabInstnace(Tetromino_Block_Prefab, I_tetromino, new Vector2(0, 0));
        tetrominos[0] = SpawnPrefabInstnace(Tetromino_Block_Prefab, I_tetromino, new Vector2(0, 0));

        var O_tetromino = new GameObject("O").transform;
        O_tetromino.SetParent(tetrominosParent);
        tetrominos[1] = SpawnPrefabInstnace(Tetromino_Block_Prefab, O_tetromino, new Vector2(0, 0));
        tetrominos[1] = SpawnPrefabInstnace(Tetromino_Block_Prefab, O_tetromino, new Vector2(0, 0));
        tetrominos[1] = SpawnPrefabInstnace(Tetromino_Block_Prefab, O_tetromino, new Vector2(0, 0));
        tetrominos[1] = SpawnPrefabInstnace(Tetromino_Block_Prefab, O_tetromino, new Vector2(0, 0));

        var T_tetromino = new GameObject("T").transform;
        T_tetromino.SetParent(tetrominosParent);
        tetrominos[2] = SpawnPrefabInstnace(Tetromino_Block_Prefab, T_tetromino, new Vector2(0, 0));
        tetrominos[2] = SpawnPrefabInstnace(Tetromino_Block_Prefab, T_tetromino, new Vector2(0, 0));
        tetrominos[2] = SpawnPrefabInstnace(Tetromino_Block_Prefab, T_tetromino, new Vector2(0, 0));
        tetrominos[2] = SpawnPrefabInstnace(Tetromino_Block_Prefab, T_tetromino, new Vector2(0, 0));

        var J_tetromino = new GameObject("J").transform;
        J_tetromino.SetParent(tetrominosParent);
        tetrominos[3] = SpawnPrefabInstnace(Tetromino_Block_Prefab, J_tetromino, new Vector2(0, 0));
        tetrominos[3] = SpawnPrefabInstnace(Tetromino_Block_Prefab, J_tetromino, new Vector2(0, 0));
        tetrominos[3] = SpawnPrefabInstnace(Tetromino_Block_Prefab, J_tetromino, new Vector2(0, 0));
        tetrominos[3] = SpawnPrefabInstnace(Tetromino_Block_Prefab, J_tetromino, new Vector2(0, 0));

        var L_tetromino = new GameObject("L").transform;
        L_tetromino.SetParent(tetrominosParent);
        tetrominos[4] = SpawnPrefabInstnace(Tetromino_Block_Prefab, tetrominosParent, new Vector2(0, 0));
        tetrominos[4] = SpawnPrefabInstnace(Tetromino_Block_Prefab, tetrominosParent, new Vector2(0, 0));
        tetrominos[4] = SpawnPrefabInstnace(Tetromino_Block_Prefab, tetrominosParent, new Vector2(0, 0));
        tetrominos[4] = SpawnPrefabInstnace(Tetromino_Block_Prefab, tetrominosParent, new Vector2(0, 0));

        var S_tetromino = new GameObject("S").transform;
        S_tetromino.SetParent(tetrominosParent);
        tetrominos[5] = SpawnPrefabInstnace(Tetromino_Block_Prefab, S_tetromino, new Vector2(0, 0));
        tetrominos[5] = SpawnPrefabInstnace(Tetromino_Block_Prefab, S_tetromino, new Vector2(0, 0));
        tetrominos[5] = SpawnPrefabInstnace(Tetromino_Block_Prefab, S_tetromino, new Vector2(0, 0));
        tetrominos[5] = SpawnPrefabInstnace(Tetromino_Block_Prefab, S_tetromino, new Vector2(0, 0));

        var Z_tetromino = new GameObject("Z").transform;
        Z_tetromino.SetParent(tetrominosParent);
        tetrominos[6] = SpawnPrefabInstnace(Tetromino_Block_Prefab, Z_tetromino);
        tetrominos[6] = SpawnPrefabInstnace(Tetromino_Block_Prefab, Z_tetromino);
        tetrominos[6] = SpawnPrefabInstnace(Tetromino_Block_Prefab, Z_tetromino);
        tetrominos[6] = SpawnPrefabInstnace(Tetromino_Block_Prefab, Z_tetromino);
    }

    private void CreateGrid()
    {
        grid = new GameObject[grid_Width * grid_Height];
        var gridParent = new GameObject("Grid").transform;
        gridParent.SetParent(transform);

        for(int x = 0; x < grid_Width; x++)
        {
            for(int y = 0; y < grid_Height; y++)
            {
                grid[y * grid_Width + x] = SpawnPrefabInstnace(
                    (x == 0 || x == grid_Width - 1 || y == 0) ? Grid_Border_Prefab : Grid_Tile_Prefab,
                    gridParent,
                    new Vector2(x, y),
                    Quaternion.identity);
            }
        }
    }

    private GameObject SpawnPrefabInstnace(GameObject Prefab, Transform parent = null, Vector2 position = new Vector2(), Quaternion rotation = new Quaternion())
    {     
         var newPrefabInstance = Instantiate(Prefab, position, rotation, parent);
             newPrefabInstance.name = Prefab.name + " (" + position.x + " , " + position.y + " )";
        return newPrefabInstance;
    }
}
