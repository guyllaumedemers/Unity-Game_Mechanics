using System;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum WallState
{
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8,
    VISITED = 128
}

public struct Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

public struct Neighbour
{
    public Position position;
    public WallState sharedwall;
}

public static class Maze
{
    private static List<Neighbour> GetUnvisitedNeighbours(Position pos, WallState[,] maze)
    {
        var list = new List<Neighbour>();
        if (pos.X > 0 && !maze[pos.X - 1, pos.Y].HasFlag(WallState.VISITED))
        {
            list.Add(new Neighbour { position = new Position(pos.X - 1, pos.Y), sharedwall = WallState.LEFT });
        }
        if (pos.X < maze.GetLength(0) - 1 && !maze[pos.X + 1, pos.Y].HasFlag(WallState.VISITED))
        {
            list.Add(new Neighbour { position = new Position(pos.X + 1, pos.Y), sharedwall = WallState.RIGHT });
        }
        if (pos.Y > 0 && !maze[pos.X, pos.Y - 1].HasFlag(WallState.VISITED))
        {
            list.Add(new Neighbour { position = new Position(pos.X, pos.Y - 1), sharedwall = WallState.DOWN });
        }
        if (pos.Y < maze.GetLength(1) - 1 && !maze[pos.X, pos.Y + 1].HasFlag(WallState.VISITED))
        {
            list.Add(new Neighbour { position = new Position(pos.X, pos.Y + 1), sharedwall = WallState.UP });
        }
        return list;
    }

    private static WallState OppositeSide(WallState shared)
    {
        switch (shared)
        {
            case WallState.LEFT:
                return WallState.RIGHT;
            case WallState.RIGHT:
                return WallState.LEFT;
            case WallState.UP:
                return WallState.DOWN;
            case WallState.DOWN:
                return WallState.UP;
            case WallState.VISITED:
                throw new InvalidOperationException();
            default:
                throw new InvalidOperationException();
        }
    }

    public static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze)
    {
        var rng = new System.Random();                                                                      // generate a random value 
        var positionStack = new Stack<Position>();                                                          // create a stack that will be pop thru during the recursive process
        var position = new Position(rng.Next(0, maze.GetLength(0)), rng.Next(0, maze.GetLength(1)));        // generate the inital position from which to process neighbours

        positionStack.Push(position);                                                                       // add to the stack
        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();                                                              // pop the last position added
            maze[current.X, current.Y] |= WallState.VISITED;                                                // flag the initial position as visited
            var neighbours = GetUnvisitedNeighbours(current, maze);                                         // check all neighbours

            if (neighbours.Count > 0)
            {
                positionStack.Push(current);                                                                // add the current position so you can process other neighbours

                var rndIndex = rng.Next(0, neighbours.Count);                                               // retrieve a random index in the neighbours array
                var rndNeighbours = neighbours[rndIndex];                                                   // get neighbour

                maze[current.X, current.Y] &= ~rndNeighbours.sharedwall;                                    // remove shared flag from the maze so we dont process it twice

                var nPosition = rndNeighbours.position;                                                     // get position of the rnd neighbour selected
                maze[nPosition.X, nPosition.Y] &= ~OppositeSide(rndNeighbours.sharedwall);                  // remove the opposite side from the active index

                positionStack.Push(nPosition);
            }
        }
        return maze;
    }

    public static WallState[,] Generate(uint width, uint height)
    {
        WallState[,] maze = new WallState[width, height];
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                maze[i, j] = WallState.LEFT | WallState.RIGHT | WallState.UP | WallState.DOWN;
            }
        }
        return ApplyRecursiveBacktracker(maze);
    }
}
