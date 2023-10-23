
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Drink : Item {

    public Drink() {
        name = "Oasis";
        Volume = 33;
    }
    public override double getPrice()
    {
        return (Volume*0.1+ 5);
    }
    public Drink(string n,int vol)
    {
        name = n;
        Volume = vol;
    }
    private string name;
    private int Volume;

}