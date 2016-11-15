// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree {
    public class Let : Special {
        public Let() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Node bindings = exp.getCdr().getCar();
            Environment next = new Environment(env);
            while (bindings != Nil.getInstance())
            {
                Node pair = bindings.getCar();
                next.define(pair.getCar(), pair.getCdr().getCar().eval(next));
                bindings = bindings.getCdr();
            }
            Node function = exp.getCdr().getCdr().getCar();
            return function.eval(next);
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printLet(t, n, p);
        }
    }
}


