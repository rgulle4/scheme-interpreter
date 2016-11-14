// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree {
    public class Regular : Special {
        public Regular() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printRegular(t, n, p);
        }
    }
}


