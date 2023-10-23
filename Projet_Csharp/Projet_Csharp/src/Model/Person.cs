
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Person {

    public string firstName;

    public string lastName;

    public void sendMessageTo(string msg,Order ord)
    {
        AppView.DisplayText("msg: \"" + msg + "\" received by " + firstName + " " + lastName+" for order n"+ord.getOrdernum());
    }
    public string getFullName() { return firstName + ";" + lastName; }
}