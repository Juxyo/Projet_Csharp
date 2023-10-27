
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
    private static Order[] orders = new Order[0];
    private static ArrayList pers;
    public static MessageManager msgManager= new Messager();
    private bool displayMenu = true;
    private bool autoorder = false;
    public Restaurant() {
        MenuView.DisplayText("Who is the new clerk?");
        clerks[0] = new Clerk();
        MenuView.DisplayText("Who is the new client?");
        cli[0] = new Client(autoorder);
        MenuView.DisplayText("Who is the new delivery person?");
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
                switch (MenuView.AskUser<int>(
                    "Choose action:\n" +
                    "1- See restaurant actions\n" +
                    "2- Toggle auto order creation (" + autoorder + ")\n" +
                    "3- Create an order\n" +
                    "4- Create a Client\n" +
                    "5- Create a Clerk\n" +
                    "6- Create a Delivery man\n" +
                    "7- Display orders mandaged by clerk\n" +
                    "8- Display delivery person by delivery\n"+
                    "9- Display orders by time\n"+
                    "10- Display average order price\n"+
                    "11- Display average accounts receivable\n"+
                    "12- Display all orders\n"+
                    "13- Display all Client\n"+
                    "14- Quit\n"
                    ))
                {
                    case 4:
                        {
                            Client[] ncli = new Client[cli.Length + 1];
                            for (int i = 0; i < cli.Length; i++)
                            {
                                ncli[i] = cli[i];
                            }
                            ncli[ncli.Length - 1] = new Client(autoorder);
                            cli = ncli;
                            pers = getPersons();
                            break;
                        }
                    case 5:
                        {
                            Clerk[] nclerks = new Clerk[clerks.Length + 1];
                            for (int i = 0; i < clerks.Length; i++)
                            {
                                nclerks[i] = clerks[i];
                            }
                            nclerks[nclerks.Length - 1] = new Clerk();
                            clerks = nclerks;
                            pers = getPersons();
                            break;
                        }
                    case 6:
                        {
                            DeliveryPerson[] ndeliv = new DeliveryPerson[delivpers.Length + 1];
                            for (int i = 0; i < delivpers.Length; i++)
                            {
                                ndeliv[i] = delivpers[i];
                            }
                            ndeliv[ndeliv.Length - 1] = new DeliveryPerson();
                            delivpers = ndeliv;
                            pers = getPersons();
                            break;
                        }
                    case 1:
                        {
                            displayMenu = false;
                            AppView.setDisplay(true);
                            MenuView.setDisplay(false);
                            break;
                        }
                    case 2:
                        {
                            foreach (Client c in cli) { c.toggleAutoOrder(); }
                            autoorder = !autoorder;
                            break;
                        }
                    case 3:
                        {
                            int cid = MenuView.AskUser<int>("Choose a client:", personsToString(cli));
                            if (cid < cli.Length && cid >= 0)
                            {
                                Client c = cli[cid];
                                displayMenu = false;
                                AppView.setDisplay(true);
                                MenuView.setDisplay(false);
                                c.orderFood();
                            }
                            break;
                        }
                    case 7:
                        {
                            displayOrdersByClerk();
                            break;
                        }
                    case 8:
                        {
                            displayDeliveryPersonByDeliveries();
                            break;
                        }
                    case 9:
                        {
                            displayOrdersByTime();
                            break;
                        }
                    case 10:
                        {
                            displayAvgOrdersPrice();
                            break;
                        }
                    case 11:
                        {
                            displayAvgAccRec();
                            break;
                        }
                    case 12:
                        {
                            displayOrders();
                            break;
                        }
                    case 13:
                        {
                            displayClients();
                            break;
                        }
                    case 14: { return; }
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
        while (!ordered && clerks.Length > 1)
        {
            for(int i = 1; i < clerks.Length; i++)
            {
                if (clerks[i - 1].getManagedOrders() < clerks[i].getManagedOrders()) {
                    Clerk c = clerks[i];
                    clerks[i] = clerks[i - 1];
                    clerks[i - 1] = c;
                    break;
                }
                if (i >= clerks.Length - 1) { ordered = true; }
                if (i >= clerks.Length - 1) { ordered = true; }
            }
        }
        for (int i = 1; i < tab.Length; i++) { tab[i] = clerks[i-1].getFullName()+"\t"+clerks[i-1].getManagedOrders(); }
        tab[0] = "Orders by Clerks";
        MenuView.DisplayTab(tab);
    }

    public void displayDeliveryPersonByDeliveries() {
        string[] tab = new string[delivpers.Length + 1];
        bool ordered = false;
        
        while (!ordered && delivpers.Length>1)
        {
            for (int i = 1; i < delivpers.Length; i++)
            {
                if (delivpers[i - 1].getDeliveriesNum() < delivpers[i].getDeliveriesNum())
                {
                    DeliveryPerson d = delivpers[i];
                    delivpers[i] = delivpers[i - 1];
                    delivpers[i - 1] = d;
                    break;
                }
                if (i >= delivpers.Length - 1) { ordered = true; }
            }
        
        }
        for (int i = 1; i < tab.Length; i++) { tab[i] = delivpers[i - 1].getFullName() + "\t" + delivpers[i - 1].getDeliveriesNum(); }
        tab[0] = "Delivery Person By Deliveries";
        MenuView.DisplayTab(tab);
    }

    public void displayOrdersByTime() {
        string[] tab = new string[orders.Length + 1];
        bool ordered = false;
        while (!ordered && orders.Length > 1)
        {
            for (int i = 1; i < orders.Length; i++)
            {
                if (orders[i - 1].getOrderTime() < orders[i].getOrderTime())
                {
                    Order o = orders[i];
                    orders[i] = orders[i - 1];
                    orders[i - 1] = o;
                    break;
                }
                if (i >= orders.Length - 1) {ordered = true; }
            }
        }
        for (int i = 1; i < tab.Length; i++) { tab[i] = orders[i - 1].getOrdernum() + "\t" + orders[i - 1].getOrderTime().ToString(); }
        tab[0] = "Orders :";
        MenuView.DisplayTab(tab);
    }

    public void displayAvgOrdersPrice()
    {
        if (orders.Length == 0) { MenuView.DisplayText("Avg order price: 0.00$"); return; }
        double total = 0;
        foreach (Order ord in orders)
        {
            total += ord.calcOrderPrice();
        }
        MenuView.DisplayText("Avg order price: " + Math.Round(total / orders.Length, 2) + "$");
    }

    public void displayAvgAccRec()
    {
        double[] totals = new double[cli.Length];
        double avg = 0.00;
        string[] disp = new string[cli.Length + 1];
        for (int i = 0; i < orders.Length; i++)
        {
            Order o = (Order)orders[i];
            totals[findCliID(o.getCliName())] = o.calcOrderPrice();
        }
        for (int i = 0; i < totals.Length; i++)
        {
            avg += totals[i];
            disp[i + 1] = cli[i].getFullName() + ": " + Math.Round(totals[i], 2) + "$";
        }
        avg = avg / cli.Length;
        disp[0] = "Average accounts receivable: " + Math.Round(avg, 2);
        MenuView.DisplayTab(disp);
    }

    public void displayOrders()
    {
        string[] tab = new string[orders.Length+1];
        for (int i = 0; i < orders.Length; i++)
        {
            tab[i+1] = orders[i].ToString();
        }
        tab[0] = "Orders : ";
        MenuView.DisplayTab(tab);
    }

    public void displayClients()
    {
        string[] tab = new string[cli.Length + 1];
        for (int i = 0; i < cli.Length; i++)
        {
            tab[i + 1] = cli[i].ToString();
        }
        tab[0] = "Clients : ";
        MenuView.DisplayTab(tab);
    }


    private int findCliID(string name)
    {
        for (int i = 0; i < cli.Length; i++)
        {
            if (cli[i].getFullName() == name)
            {
                return i;
            }
        }
        return -1;
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
            Order[] norder = new Order[orders.Length + 1];
            for (int i = 0; i < orders.Length; i++)
            {
                norder[i] = orders[i];
            }
            norder[norder.Length - 1] = ord;
            orders = norder;
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
}