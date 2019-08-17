

public class CommonMethods 
{
    public static int HURTBOX = 11;
    public static int HITBOX = 12;


    public static float  getValueInRange(float multiplier, float min, float max)
    {
        return multiplier * (max - min) + min;
    }


}
