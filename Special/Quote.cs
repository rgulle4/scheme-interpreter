// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree {
    public class Quote : Special {
        public Quote() { }
        
        public override Node eval(Node exp, Environment env) {
            return exp.getCdr().getCar();
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printQuote(t, n, p);
        }
    }
}

