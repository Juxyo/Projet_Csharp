
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Structure that contains all the pizzea sizes
/// </summary>
public class PizzaSize {
    private int size = 1;
    /// <summary>
    /// Structure that contains all the pizzea sizes (1,2,3)
    /// </summary>
    public PizzaSize(int pSize) {
        if(pSize==1 || pSize==2 || pSize==3) { size = pSize; }
        else { AppView.DisplayError("Error: the Pizza size must be 1, 2 or 3 (3 being the largest)"); }
    }
    public PizzaSize()
    {
        string pSize = AppView.AskUser<string>("Choose the pizza size (1=small, 2=medium and 3=large):");
        if (pSize == 1 || pSize == 2 || pSize == 3) { size = pSize; }
        else { AppView.DisplayError("Error: the Pizza size must be 1, 2 or 3 (3 being the largest)"); }
    }

}