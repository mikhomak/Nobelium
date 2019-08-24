

using UnityEngine;

public class CommonMethods
{
    public static int HURTBOX_PLAYER = 10;
    public static int HURTBOX = 11;
    public static int HITBOX = 12;


    public static float  getValueInRange(float multiplier, float min, float max)
    {
        return multiplier * (max - min) + min;
    }


    public static Color GetNextPseudoRandomColor(Color current)
    {
        int keep = new System.Random().Next(0, 2);
        float red = UnityEngine.Random.Range(0f, 1f);
        float green = UnityEngine.Random.Range(0f, 1f);
        float blue = UnityEngine.Random.Range(0f, 1f);
        Color c = new Color(red, green, blue);
        float fixedComp = c[keep] + 0.5f;
        c[keep] = fixedComp - Mathf.Floor(fixedComp);
        return c;
    }

}
