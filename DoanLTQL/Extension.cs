using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public static class Extension
     {
             /*Tắt user control khi nó được gán nhờ một form*/
            public static void Close(this UserControl user,DialogResult result)
            {
                var parent = (ShowUserControl)user.Parent;
                parent.DialogResult = result;
                parent.Close();
                
            }

            public static void PrintColor(this string text)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.White;   
            }        
       
    }
}
