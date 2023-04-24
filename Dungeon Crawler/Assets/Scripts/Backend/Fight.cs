using System;

public class Fight
{
   
    static int roll20()
    {
        Random rnd = new Random();
        return rnd.Next(1, 20);
    }
    // successful attack returns true. unsuccessful attack returns false
    public static bool Attack(Inhabitant attacker, Inhabitant defender)
    {
        int result = roll20();
        if (result >= defender.getArmorClass())
        {
            defender.takeDamage(attacker.getDamage());
            return true;
        }

        return false;
       

    }
}
