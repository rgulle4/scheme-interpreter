// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree {
    public class Begin : Special {
        public Begin() { }

        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Node expList = exp.getCdr();
            Node last = expList.getCar().eval(env);
            if(expList == Nil.getInstance())
            {
                return last;
            }
            expList = expList.getCdr();
            return expList.getCar().eval(env);
        }

        public override void print(Node t, int n, bool p) {
            Printer.printBegin(t, n, p);
        }
    }
}

