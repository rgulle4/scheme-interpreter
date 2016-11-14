// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree {
    public class Regular : Special {
        public Regular() { }
        
        public override Node eval(Node exp, Environment env) {
            if (exp.isNull() || env.isNull()) { 
                Console.Error.WriteLine("ERROR: cant eval regular");
                return Nil.getInstance();
            }
            Node car = exp.getCar();
            Node cdr = exp.getCdr();
            // TODO: finish Regular.eval().
            Console.Error.WriteLine("ERROR: cant eval regular");
            return Nil.getInstance();
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printRegular(t, n, p);
        }
    }
}


