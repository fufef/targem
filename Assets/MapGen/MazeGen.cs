using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Shuffle(List<(int, int)> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool[,] GetMaze(int size, int x, int y)
    {
        var free = new bool[size, size];
        free[x, y] = true;
        var nonVisitedNeighbours = GetWalls(x, y, free).ToList();
        if (nonVisitedNeighbours.Count == 0)
        {
            return free;
        }

        Shuffle(nonVisitedNeighbours);
        var toTake = Random.Range(1, nonVisitedNeighbours.Count);
        nonVisitedNeighbours = nonVisitedNeighbours.Take(toTake).ToList();
        if (nonVisitedNeighbours.Count > 0)
        {
            foreach (var neighbour in nonVisitedNeighbours)
            {
                var xDiff = (neighbour.Item1 - x) / 2;
                var yDiff = (neighbour.Item2 - y) / 2;
                free[x + xDiff, y + yDiff] = true;
                GetMaze(free, size, neighbour.Item1, neighbour.Item2);
            }
        }

        return free;
    }

    private void GetMaze(bool[,] free, int size, int x, int y)
    {
        free[x, y] = true;
        var nonVisitedNeighbours = GetWalls(x, y, free).ToList();
        if (nonVisitedNeighbours.Count == 0)
        {
            return;
        }

        Shuffle(nonVisitedNeighbours);
        var toTake = Random.Range(1, nonVisitedNeighbours.Count);
        nonVisitedNeighbours = nonVisitedNeighbours.Take(toTake).ToList();
        if (nonVisitedNeighbours.Count > 0)
        {
            foreach (var neighbour in nonVisitedNeighbours)
            {
                var xDiff = (neighbour.Item1 - x) / 2;
                var yDiff = (neighbour.Item2 - y) / 2;
                free[x + xDiff, y + yDiff] = true;
                GetMaze(free, size, neighbour.Item1, neighbour.Item2);
            }
        }
    }

    private List<(int, int)> dirs = new List<(int, int)>() { (-2, 0), (2, 0), (0, 2), (0, -2) };

    private (int, int)[] GetWalls(int x, int y, bool[,] field)
    {
        var size = field.GetLength(0);
        var points = dirs.Select(z => (z.Item1 + x, z.Item2 + y)).Where(z => z.Item1 >= 0 && z.Item1 < size && z.Item2 >= 0 && z.Item2 < size && !field[z.Item1, z.Item2]).ToArray();
        return points;
    }

    private (int, int)[] GetNs(int x, int y, bool[,] field)
    {
        var size = field.GetLength(0);
        var points = dirs.Select(z => (z.Item1 + x, z.Item2 + y)).Where(z => z.Item1 >= 0 && z.Item1 < size && z.Item2 >= 0 && z.Item2 < size && field[z.Item1, z.Item2]).ToArray();
        return points;
    }

    private (int, int)[] Get(int x, int y, bool[,] field)
    {
        var size = field.GetLength(0);
        var points = dirs.Select(z => (z.Item1 + x, z.Item2 + y)).Where(z => z.Item1 >= 0 && z.Item1 < size && z.Item2 >= 0 && z.Item2 < size).ToArray();
        return points;
    }
}