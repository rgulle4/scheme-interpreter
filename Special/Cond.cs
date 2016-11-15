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
            Console.WriteLine(" -- Entered evalRecursive() -- ");
            Node rest = exp.getCdr();

            Node branch = exp.getCar();
            if (branch.isNull()) {
                StringLit.SHOULD_PRINT_QUOTES = true;
                return new StringLit("#{Unspecific}", false);
            }

            Node branchCond = branch.getCar();
            Node branchExpr = branch.getCdr();

            if (branchCond.getName().Equals("else")) {
                Console.Write("eval else... ");
                branchExpr.print(0); 
                return Node.nilNodeWithErrorMsg(
                    "Error: invalid expression");
                // return branchExpr.eval(env);
            }
            if (branchCond.eval(env) == BoolLit.getInstance(true)) {
                Console.Write("eval... ");
                branchExpr.print(0);     
                return Node.nilNodeWithErrorMsg(
                    "Error: invalid expression");                          
                // return branchExpr.eval(env);
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
