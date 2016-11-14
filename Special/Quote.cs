// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree {
    public class Quote : Special {
        public Quote() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printQuote(t, n, p);
        }
    }
}

