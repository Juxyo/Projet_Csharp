
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeliveryPerson : Person {

    public DeliveryPerson()
    {
        firstName = AppView.AskUser<string>("Enter a first name");
        lastName = AppView.AskUser<string>("Enter a last name");
    }
    public DeliveryPerson(string fname, string lname)
    {
        firstName = fname;
        lastName = lname;
    }
    public async void deliverFood(Order ord)
    {
        occupied = true;
        Random rand = new Random();
        await Task.Delay(rand.Next(1000, 5000));
        ord.endTimer();
        AppView.DisplayTextY("The delivery person has arrived at the delivery point");
        if (ord.getCashState() == "Paid")
        {
            AppView.DisplayTextG("Customer paid: "+ord.calcOrderPrice()+"\nOrder Completed in: "+ord.getDeliveryTime());
        }
        else
        {
            AppView.DisplayError("Customer did not pay\nOrder Completed in: " + ord.getDeliveryTime());
        }
        Restaurant.msgManager.sendMessage(Restaurant.findPerson(ord.getClerkName()), "order delivered", ord);
        occupied = false;
    }
    public bool isOccupied() { return occupied; }
    /// <summary>
    /// number of deliveries completed
    /// </summary>
    private int deliveriesNum;
    private bool occupied = false;
}