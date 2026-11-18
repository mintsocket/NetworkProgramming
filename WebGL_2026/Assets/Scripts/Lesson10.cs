using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    [ContextMenu("계단")]
    void Stairs()
    {
        string line = "";
        for (int row = 1; row <= 3; row++)
        {
            for (int col = 0; col < row; col++)
            {
                line += "*";
            }
            line+="\n";
        }

        Debug.Log(line);
    }

    [ContextMenu("뒤집힌 계단")]
    void ReverseStairs()
    {
        int height = 4;
        string result = "";
        for (int row = height; row > 0; row--)
        {
            for (int i = 0; i < row; i++)
            {
                result += "*";
            }
            result += "\n";
        }
        Debug.Log(result);
    }

    [ContextMenu("오른 계단")]
    void RightStairs()
    {
        int height = 4;
        string result = "";
        for (int row = height; row > 0; row--)
        {
            for (int i = 0; i < row - 1; i++)
            {
                result += " ";
            }

            for (int i = 0; i < height - row + 1 ; i++)
            {
                result += "*";
            }
            result += "\n";
        }
        Debug.Log(result);
    }

        [ContextMenu("격자")]
    void Grid()
    {
        string text = "";
        for (int row = 1; row <= 2; row++)
        {
            for (int col = 1; col <= 3; col++)
            {
                text += row + "-" + col + " ";
            }
            text += "\n";
        }
        Debug.Log(text);
    }

}
