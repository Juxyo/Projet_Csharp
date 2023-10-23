
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface MessageManager {
    void sendMessage(Person target, string text, Order ord);
}