using UnityEngine;

public class RandomNumbersGenerator : MonoBehaviour
{
    private static readonly System.Random s_random = new System.Random();

    public static int GenerateRandomNumber(int min, int max)
    {
        return s_random.Next(min, max);
    }

    public static int GenerateRandomNumber(int max)
    {
        return s_random.Next(max);
    }
}
