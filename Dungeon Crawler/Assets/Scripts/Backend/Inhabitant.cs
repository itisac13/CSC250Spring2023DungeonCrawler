using System;

public class Inhabitant
{
    protected string name;

    protected int maxHitpoints;
    protected int hitpoints;
    protected int armorClass;
    protected int damage;
    public Inhabitant(string name) 
    { 
        this.name = name;

        Random rnd = new Random();

        this.maxHitpoints = rnd.Next(20, 50);
        this.hitpoints = this.maxHitpoints;
        this.armorClass = rnd.Next(6, 14);
        this.damage = rnd.Next(5, 10);

    }

    public string getName()
    {
        return this.name;
    }

    public string getData()
    {
        string statsString = "Stats for " + this.name + ":\nHitpoints: " + this.hitpoints.ToString() + "\nArmor Class: " + this.armorClass.ToString() + "\nDamage: " + this.damage.ToString();
        return statsString;
    }

    public void takeDamage(int damage)
    {
        if (damage > 0)
        {
            this.hitpoints -= damage;
        }
        
    }
    public int getHitpoints()
    { return this.hitpoints; }
    public int getMaxHitpoints()
    { return this.maxHitpoints; }
    public int getArmorClass()
    { return this.armorClass; }
    public int getDamage()
    { return this.damage; }

    public void heal(int amount)
    {
        this.hitpoints += amount;
        if (this.hitpoints > this.maxHitpoints)
        {
            this.hitpoints = this.maxHitpoints;
        }
    }

    public void resetStats()
    {
        Random rnd = new Random();

        this.hitpoints = rnd.Next(20, 50);
        this.armorClass = rnd.Next(6, 14);
        this.damage = rnd.Next(5, 10);
    }
}
