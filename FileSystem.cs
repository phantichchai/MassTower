using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileSystem
{
    private List<(int, int)> xy = new List<(int, int)>();
    public void LoadPathWaypoints()
    {
        string path = Application.dataPath + "/Scripts/pathwaypoints.txt";
        StreamReader wf = File.OpenText(path);
        
        string line;
        if (File.Exists(path))
        {
            while((line = wf.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                xy.Add((int.Parse(data[0]), int.Parse(data[1])));
            }
        }
    }

    public (int, int) getXY(int index)
    {
        return xy[index];
    }
    
    public int getLengthXY()
    {
        return xy.Count;
    }
}
