using UnityEngine;

public static class DebugTooles
{
    public static void SoutMassive(System.Object[,] massive)
    {
        string Log = "";
        for (int i = 0; i < massive.GetLength(0); i++)
        {
            for (int j = 0; j < massive.GetLength(1); j++)
            {
                Log += massive[i, j].ToString()[..7] + " ";
            }
            Log += "\n";
        }
        Debug.Log(Log);
    }
}
