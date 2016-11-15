// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree {
    public class Cond : Special {
        public Cond() { }

        public override Node eval(Node exp, Environment env) {
            if (Node.countNodes(exp) < 1)
                return Node.nilNodeWithErrorMsg(
                    "Error: invalid expression");
            return evalRecursive(exp.getCdr(), env);
        }

        // TODO: handle bad inputs better
        private Node evalRecursive(Node exp, Environment env) {
            if (exp.isNull()) {
                StringLit.SHOULD_PRINT_QUOTES = true;
                return new StringLit("#{Unspecific}", false);
            }
            Node branch = exp.getCar();
            Node branchCond = branch.getCar();
            Node branchExpr = branch.getCdr();
            if (branchCond.getName().Equals("else"))
                return branchExpr.getCar().eval(env);
            if (branchCond.eval(env) == BoolLit.getInstance(true))
                return branchExpr.getCar().eval(env);
            Node rest = exp.getCdr();
            return evalRecursive(rest, env);
        }

        public override void print(Node t, int n, bool p) {
            Printer.printCond(t, n, p);
        }
    }
}
