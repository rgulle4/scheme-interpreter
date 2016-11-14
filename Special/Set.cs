// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree {
    public class Set : Special {
        public Set() { }
                
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printSet(t, n, p);
        }
    }
}

