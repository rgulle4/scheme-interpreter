// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree {
    public class Cond : Special {
        public Cond() { }

        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            if (Node.countNodes(exp) < 1)
                return Node.nilNodeWithErrorMsg(
                    "Error: invalid expression");
            return evalRecursive(exp.getCdr(), env);
        }

        private Node evalRecursive(Node exp, Environment env) {
            // Console.WriteLine(" -- Entered evalRecursive() -- ");
            // exp.print(0);
            if (exp.isNull()) {
                StringLit.SHOULD_PRINT_QUOTES = true;
                return new StringLit("#{Unspecific}", false);
            }

        
            Node branch = exp.getCar();

            Node branchCond = branch.getCar();
            // Console.Write("branchCond: ");
            // branchCond.print(0);

            Node branchExpr = branch.getCdr();
            // Console.Write("branchExpr: ");
            // branchExpr.print(0);
            
            Node rest = exp.getCdr();
            // Console.Write("rest: ");
            // rest.print(0);

            // eval else
            if (branchCond.getName().Equals("else")) {
                return branchExpr.getCar().eval(env);
            }
            // Node branchCondEvald = branchCond.eval(env);
            // Console.Write("branchCondEval: ");
            // branchCondEvald.print(0);

            // Node branchExprEvald = branchExpr.getCar().eval(env);
            // Console.Write("branchExprEvald: ");
            // branchExprEvald.print(0);

            if (branchCond.eval(env) == BoolLit.getInstance(true)) {
                return branchExpr.getCar().eval(env);
            }

            return evalRecursive(rest, env);
        }

        public override void print(Node t, int n, bool p) {
            Printer.printCond(t, n, p);
        }
    }
}

// (cond 
//   ((b< 2 3) 'a)
//   ((b< 3 2) 'b))
