
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza : Item {
    public Pizza(PizzaSize size,PizzaType type) { psize = size;ptype = type; }
    public Pizza() {
        psize = new PizzaSize();
        ptype = new PizzaType();
    }

    /// <summary>
    /// size of the pizza
    /// </summary>
    private PizzaSize psize;

    /// <summary>
    /// type of the pizza
    /// </summary>
    private PizzaType ptype;

    public override double getPrice()
    {
        return (5 * psize.getSize() + ptype.getType() + 5);
    }
    override
    public string ToString()
    {
        return psize.ToString()+ " " + ptype.ToString().ToLower() + " pizza :\t" + getPrice()+"$";
    }
}