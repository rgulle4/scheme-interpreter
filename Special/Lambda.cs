// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree {
    public class Lambda : Special {
        public Lambda() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }

        public override void print(Node t, int n, bool p) {
            Printer.printLambda(t, n, p);
        }
    }
}

