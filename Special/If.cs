// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree {
    public class If : Special {
        public If() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Node condition = exp.getCdr().getCar();
            Node ifTrue = exp.getCdr().getCdr().getCar();
            Node ifFalse = exp.getCdr().getCdr().getCdr().getCar();

            if(condition.eval(env) == BoolLit.getInstance(true))
                return ifTrue.eval(env);
            else return ifFalse.eval(env);
        }

        public override void print(Node t, int n, bool p) {
            Printer.printIf(t, n, p);
        }
    }
}

