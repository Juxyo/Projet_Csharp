
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Structure that contains all the pizzea sizes
/// </summary>
public class PizzaType {
    private int type = 1;
    /// <summary>
    /// Structure that contains all the pizzea sizes (1,2,3)
    /// </summary>
    public PizzaType(int pType) {
        if(pType == 1 || pType == 2 || pType == 3 || pType == 4 || pType == 5) { type = pType; }
        else { AppView.DisplayError("Error: the Pizza Type must be 1, 2, 3, 4 or 5, not:"+pType); }
    }
    public PizzaType()
    {
        int pType = AppView.AskUser<int>("Choose the pizza type:\n1=Tomato\n2=Cheese sauce\n3=Vegetarian\n4=All dressed\n5=Peperoni");
        if (pType>0 && pType<6) { type = pType; }
        else {
            while (pType < 1 || pType > 5) {
                AppView.DisplayError("Error: the Pizza type must be a number between 1 and 5");
                pType = AppView.AskUser<int>("Choose the pizza type:\n1=Tomato\n2=Cheese sauce\n3=Vegetarian\n4=All dressed\n5=Peperoni");
            }
            type = pType;
        }
    }
    public int getType() { return type; }
    override
    public string ToString()
    {
        switch (type)
        {
            case 1: return "Tomato";
            case 2: return "Cheese sauce";
            case 3: return "Vegetarian";
            case 4: return "All dressed";
            case 5: return "Peperoni";
        }
        return "unknown error";
    }
}