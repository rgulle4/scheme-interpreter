// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree {
    public class Set : Special {
        public Set() { }
                
        public override Node eval(Node exp, Environment env) {
            Node varName = exp.getCdr().getCar();
            Node newVarValue = exp.getCdr().getCdr().getCar();
            env.assign(varName, newVarValue.eval(env));
            StringLit.SHOULD_PRINT_AT_ALL = false;
            return new StringLit("");
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printSet(t, n, p);
        }
    }
}

