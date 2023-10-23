
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Kitchen {

    public static async void prepareOrder(Order ord) {
        AppView.DisplayTextY("Order n"+ord.getOrdernum()+" in preparation in the kitchen");
        Random rand = new Random();
        //await Task.Delay(rand.Next(1000,5000));
        Restaurant.findDeliveryPerson().deliverFood(ord);
        Restaurant.msgManager.sendMessage(Restaurant.findPerson(ord.getCliName()), "your order is being delivered", ord);
        ord.setStatus("In delivery");
    }

}