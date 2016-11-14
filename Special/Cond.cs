// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree {
    public class Cond : Special {
        public Cond() { }

        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }

        public override void print(Node t, int n, bool p) {
            Printer.printCond(t, n, p);
        }
    }
}


