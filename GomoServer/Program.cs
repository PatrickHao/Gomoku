using System;

namespace GomoServer {
    class Program {
        static void Main(string[] args) {
            ServerControl serverControl = new ServerControl();
            serverControl.Start();
            Console.ReadKey();
        }
    }
}