
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Order {

    public Order() {
    }

    /// <summary>
    /// Time taken to end the order
    /// </summary>
    public int deliveryTime = 0;

    /// <summary>
    /// List of the order Products
    /// </summary>
    public ArrayList products = null;

    /// <summary>
    /// delivery address
    /// </summary>
    public string address = "";

    /// <summary>
    /// id of the order
    /// </summary>
    public int orderNum;

    public int orderTime;

    public Date orderDate;

    public string cusName;

    public string cleName;

    public string status;

    public string cashStatus;

    /// <summary>
    /// @param orderNb
    /// </summary>
    public static void calcOrderPrice(int orderNb) {
        // TODO implement here
    }

    /// <summary>
    /// @param orderNb
    /// </summary>
    public static void toString(int orderNb) {
        // TODO implement here
    }

}