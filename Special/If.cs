// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree {
    public class If : Special {
        public If() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }

        public override void print(Node t, int n, bool p) {
            Printer.printIf(t, n, p);
        }
    }
}

