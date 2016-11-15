// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree {
    public class Regular : Special {
        public Regular() { }

        private Node evalRecursive(Node exp, Environment env) {
            if (exp.isNull()) 
                return Nil.getInstance();
            Node car = exp.getCar();
            Node cdr = exp.getCdr();
            return new Cons(
                car.eval(env), 
                evalRecursive(cdr, env)
            );
        }
        
        // TODO: figure out if this is really done
        // rn, get to this by 
        // (eval '(b+ 3 4) (interaction-environment)) => 7 
        public override Node eval(Node exp, Environment env) {
            if (exp.isNull() || env.isNull())
                return Node.nilNodeWithErrorMsg("Error: invalid expression (TODO see Regular)");
            Node car = exp.getCar();
            Node cdr = exp.getCdr();
            return car.eval(env).apply(evalRecursive(cdr, env));
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printRegular(t, n, p);
        }
    }
}


