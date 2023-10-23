
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clerk : Person {
    public Clerk(string fname,string lname)
    {
        firstName = fname;
        lastName = lname;
    }
    public Clerk()
    {
        firstName = AppView.AskUser<string>("Enter a first name");
        lastName = AppView.AskUser<string>("Enter a last name");
    }

    public void newOrder(Order ord)
    {
        AppView.DisplayTextY("clerk: "+firstName+" "+lastName+" took the call");
        ord.setClerkName(this.getFullName());
        Kitchen.prepareOrder(ord);
        Restaurant.msgManager.sendMessage(Restaurant.findPerson(ord.getCliName()),"your order is in preparation",ord);
        ord.setStatus("In preparation");
        activeOrders += 1;
        managedOrders += 1;
    }
    private int activeOrders = 0;
    public int getManagedOrders() { return managedOrders; }
    public int getActiveOrders() { return activeOrders; }
    /// <summary>
    /// number of orders a clerk has managed
    /// </summary>
    private int managedOrders=0;
    public void sendMessageTo(string msg, Order ord)
    {
        AppView.DisplayText("msg: \"" + msg + "\" received by " + firstName + " " + lastName + " for order n" + ord.getOrdernum());
        activeOrders -= 1;
    }

}