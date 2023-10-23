
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
        else { AppView.DisplayError("Error: the Pizza size must be 1, 2 or 3 (3 being the largest) not:"+pSize); }
    }
    public PizzaSize()
    {
        int pSize = AppView.AskUser<int>("Choose the pizza size:\n1=small\n2=medium\n3=large");
        if (pSize == 1 || pSize == 2 || pSize == 3) { size = pSize; }
        else
        {
            while (pSize < 1 || pSize > 3)
            {
                AppView.DisplayError("Error: the Pizza size must be 1, 2 or 3 (3 being the largest)");
                pSize = AppView.AskUser<int>("Choose the pizza size:\n1=small\n2=medium\n3=large");
            }
            size = pSize;
        }
    }
    public int getSize() { return size; }
    override
    public string ToString()
    {
        switch (size)
        {
            case 1: return "Small";
            case 2: return "Medium";
            case 3: return "Large";
        }
        return "unknown error";
    }
}