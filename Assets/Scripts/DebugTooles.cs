using UnityEngine;

public static class DebugTooles
{
    public static void SoutMassive(System.Object[,] massive) {
        string Log = "";
        if (massive != null) {
            for (int i = 0; i < massive.GetLength(0); i++) {
                for (int j = 0; j < massive.GetLength(1); j++) {
                    if (massive[i, j] != null) {
                        Log += massive[i, j].ToString()[..7] + " ";
                    } else {
                        Log += "NULL";
                    }
                }
                Log += "\n";
            }
            Debug.Log(Log);
        }else {
            Debug.Log("NULL");
        }
    }
}
