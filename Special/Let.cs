// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree {
    public class Let : Special {
        public Let() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printLet(t, n, p);
        }
    }
}


