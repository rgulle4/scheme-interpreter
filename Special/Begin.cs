// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree {
    public class Begin : Special {
        public Begin() { }

        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }

        public override void print(Node t, int n, bool p) {
            Printer.printBegin(t, n, p);
        }
    }
}

