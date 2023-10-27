
using AppProjectS7.src.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Client : Person {
    private bool auto;
    public Client(bool autoOrder,string fname, string lname,int phoneNumber,string addr)
    {
        auto = autoOrder;
        firstName=fname;
        lastName=lname;
        phoneNum = phoneNumber;
        address = addr;
        if (auto) { orderFood(); }
    }
    public Client(bool autoOrder)
    {
        auto = autoOrder;
        firstName = MenuView.AskUser<string>("Enter a first name");
        lastName = MenuView.AskUser<string>("Enter a last name");
        phoneNum = MenuView.AskUser<int>("Enter a phone number");
        address = MenuView.AskUser<string>("Enter a full address");
        if (auto) { orderFood(); }
    }

    public async Task orderFood()
    {
        if (!auto) {
            AppView.DisplayTextG("| New order from " + ToString() + " |");
            Restaurant.createOrder(new Order(this));
        }
        Random random = new Random();
        while (auto)
        {
            int delayMilliseconds = random.Next(7000, 10001);
            await Task.Delay(delayMilliseconds); 
            ordersNum += 1;
            AppView.DisplayTextG("| New order from "+ToString()+" |");
            Restaurant.createOrder(new Order(this));
        }
        
    }

    /// <summary>
    /// number of orders a client has created
    /// </summary>
    private int ordersNum=0;

    private int phoneNum;

    private string address;
    public string getAddr() { return address; }
    public bool toggleAutoOrder() {
        if (auto) { 
            auto = false;
            return false; 
        } 
        else {
            auto = true;
            orderFood();
            return true; 
        } 
    }
    override
    public string ToString()
    {
        return firstName + " " + lastName + " living at " + address + " Phone: " + phoneNum;
    }
}