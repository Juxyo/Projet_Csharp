
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Messager : MessageManager {

    /// <summary>
    /// @param target 
    /// @param text 
    /// @param ord
    /// </summary>
    public void sendMessage(Person target, string text, Order ord) {
        target.sendMessageTo(text, ord);
    }

}