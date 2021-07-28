using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    private uint width = 20;
    private uint height = 20;

    private void Awake()
    {
        var maze = Maze.Generate(width, height);
        Draw(maze);
    }

    private void Draw(WallState[,] maze)
    {
        for (int i = 0; i < maze.GetLength(0); ++i)
        {
            for (int j = 0; j < maze.GetLength(1); ++j)
            {
                var position = new Vector3(-width / 2 + i, 0.0f, -height / 2 + j);
                var node = maze[i, j];

                if (node.HasFlag(WallState.UP))
                {
                    Transform newT = Instantiate(prefab, null);
                    newT.position = position + new Vector3(prefab.localScale.x / 2, 0.0f, prefab.localScale.x);
                }
                if (node.HasFlag(WallState.LEFT))
                {
                    Transform newT = Instantiate(prefab, null);
                    newT.position = position + new Vector3(0.0f, 0.0f, prefab.localScale.x / 2);
                    newT.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                }
                if (j == 0 && node.HasFlag(WallState.DOWN))
                {
                    Transform newT = Instantiate(prefab, null);
                    newT.position = position + new Vector3(prefab.localScale.x / 2, 0.0f, 0.0f);
                }
                if (i == maze.GetLength(1) - 1 && node.HasFlag(WallState.RIGHT))
                {
                    Transform newT = Instantiate(prefab, null);
                    newT.position = position + new Vector3(prefab.localScale.x, 0.0f, prefab.localScale.x / 2);
                    newT.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                }
            }
        }
    }
}
