
using AppProjectS7.src.Vue;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Restaurant {
    private static Clerk[] clerks = new Clerk[1];
    private static DeliveryPerson[] delivpers = new DeliveryPerson[1];
    private static Client[] cli = new Client[1];
    private static ArrayList pers;
    public static MessageManager msgManager= new Messager();
    private bool displayMenu = true;
    private bool autoorder = false;
    public Restaurant() {
        MenuView.DisplayText("Who is the new clerk?");
        clerks[0] = new Clerk();
        MenuView.DisplayText("Who is the new client?");
        cli[0] = new Client(autoorder);
        MenuView.DisplayText("Who is the new client?");
        delivpers[0] = new DeliveryPerson();
        pers = getPersons();
        managePrompt();
    }
    public Restaurant(Clerk[] rclerks,Client[] clients,DeliveryPerson[] deliverypers)
    {
        cli = clients;
        delivpers = deliverypers;
        clerks = rclerks;
        pers=getPersons();
        managePrompt();
    }

    private void managePrompt()
    {
        MenuView.DisplayText("The Restaurant is open!");
        while (true)
        {
            if (displayMenu)
            {
                switch(MenuView.AskUser<int>(
                    "Choose action:\n" +
                    "1- See restaurant actions\n"+
                    "2- Toggle auto order creation ("+autoorder+")\n"+
                    "3- Create an order\n"+
                    "4- Display orders mandaged by clerk\n"+
                    "5- Quit\n"
                    ))
                {
                    case 1:
                        {
                            displayMenu = false;
                            AppView.setDisplay(true);
                            MenuView.setDisplay(false);
                            break;
                        }
                    case 2:
                        {
                            foreach(Client c in cli) { c.toggleAutoOrder(); }
                            autoorder = !autoorder;
                            break;
                        }
                    case 3:
                        {
                            int cid = MenuView.AskUser<int>("Choose a client:", personsToString(cli));
                            if (cid < cli.Length && cid >= 0) {
                                Client c = cli[cid];
                                displayMenu = false;
                                AppView.setDisplay(true);
                                MenuView.setDisplay(false);
                                c.orderFood();
                            }
                            break;
                        }
                    case 4:
                        {
                            displayOrdersByClerk();
                            break;
                        }
                    case 5: { return; }
                }
            }
            else
            {
                AppView.AskUser<string>("Press enter to stop\n");
                displayMenu = true;
                AppView.setDisplay(false);
                MenuView.setDisplay(true);
            }
        }
    }

    private string[] personsToString(Person[] tab)
    {
        string[] res = new string[tab.Length];
        for (int i=0;i < tab.Length;i++) { res[i] = tab[i].getFullName(); }
        return res;
    }
    public static ArrayList getPersons()
    {
        ArrayList res = new ArrayList();
        foreach(Person p in clerks) { res.Add(p); }
        foreach (Person p in cli) { res.Add(p); }
        foreach (Person p in delivpers) { res.Add(p); }
        return res;
    }

    public static Person findPerson(string fullname) {
        for(int i = 0; i < pers.Count; i++)
        {
            if (((Person)pers[i]).getFullName() == fullname)
            {
                return (Person)pers[i];
            }
        }
        return null;
    }

    public void displayOrdersByClerk() {
        string[] tab = new string[clerks.Length+1];
        bool ordered = false;
        while (!ordered)
        {
            for(int i = 1; i < clerks.Length; i++)
            {
                if (clerks[i - 1].getManagedOrders() < clerks[i].getManagedOrders()) {
                    Clerk c = clerks[i];
                    clerks[i] = clerks[i - 1];
                    clerks[i - 1] = c;
                    break;
                }
                ordered = true;
            }
        }
        for (int i = 1; i < tab.Length; i++) { tab[i] = clerks[i-1].getFullName()+"\t"+clerks[i-1].getManagedOrders(); }
        tab[0] = "Orders by Clerks";
        MenuView.DisplayTab(tab);
    }

    public void displayDeliveryPersonByDeliveries() {
        // TODO implement here
    }

    public void displayOrdersByTime() {
        // TODO implement here
    }

    public void displayAvgOrdersPrice() {
        // TODO implement here
    }

    public void displayAvgAccRec() {
        // TODO implement here
    }

    public static void createOrder(Order ord) {
        Clerk minClerk=null;
        int min=-1;
        foreach (Clerk c in clerks)
        {
            if(min==-1 || c.getActiveOrders()<min || c.getActiveOrders() == 0)
            {
                min = c.getActiveOrders();
                minClerk = c;
            }
        }
        if (minClerk!=null)
        {
            minClerk.newOrder(ord);
        }
    }

    public static DeliveryPerson findDeliveryPerson() {
        bool found = false;
        DeliveryPerson dp=null;
        while (!found)
        {
            foreach (DeliveryPerson c in delivpers)
            {
                if (!c.isOccupied())
                {
                    dp = c;
                    found = true;
                }
            }
        }
        return dp;
    }

    public void endOrder() {
        // TODO implement here
    }

}