
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Order {
    private static int nborders=0;
    private Chronometer chrono = new Chronometer();
    public Order(Client c) {
        Random rand = new Random();
        int nbProd = rand.Next(1, 5);
        for(int i = 0; i < nbProd; i++)
        {
            if (i % 2 == 0)
            {
                products.Add(new Pizza(new PizzaSize(rand.Next(1, 4)), new PizzaType(rand.Next(1, 6))));
            }
            else
            {
                products.Add(new Drink());
            }
        }
        nborders += 1;
        address = c.getAddr();
        orderNum = nborders;
        orderTime = DateTime.Now;
        cusName = c.getFullName();
        status = "Created";
        chrono.Start();
    }
    public void endTimer()
    {
        chrono.Stop();
        status = "delivered";
        if(new Random().Next(1, 100) > 10) { cashStatus = "Paid"; }
        else { cashStatus = "Unpaid"; }
        deliveryTime = chrono.ElapsedTime();
    }
    public DateTime getDeliveryTime() { return orderTime; }
    public string getCashState() { return cashStatus; }
    public string getCliName() { return cusName; }
    public string getClerkName() { return cleName; }
    /// <summary>
    /// Time taken to end the order
    /// </summary>
    private TimeSpan deliveryTime;

    /// <summary>
    /// List of the order Products
    /// </summary>
    private ArrayList products = new ArrayList();

    /// <summary>
    /// delivery address
    /// </summary>
    private string address = "";

    /// <summary>
    /// id of the order
    /// </summary>
    private int orderNum;

    private DateTime orderTime;

    private string cusName;

    private string cleName;

    private string status;

    private string cashStatus;

    public DateTime getOrderTime() { return orderTime; }
    public void setClerkName(string name) { cleName = name; }
    public void setStatus(string stat) { status = stat; }

    public int getOrdernum() { return orderNum; }

    /// <summary>
    /// @param orderNb
    /// </summary>
    public double calcOrderPrice() {
        double price = 0;
        foreach(Item elem in products)
        {
            price += elem.getPrice();
        }
        return price;
    }

    /// <summary>
    /// @param orderNb
    /// </summary>
    public String ToString() {
        if (status == "delivered")
        {
            return "num : " + orderNum + " - price :" + Math.Round(calcOrderPrice(), 2) + "$ - ordered by : " + cusName + " - served by : " + cleName + " - devlivered in : " + deliveryTime.ToString();
        }
        else
        {
            return "num : " + orderNum + " - price :" + Math.Round(calcOrderPrice(), 2) + "$ - ordered by : " + cusName + " - served by : " + cleName + " - not yet delivered ";
        }
    }

}