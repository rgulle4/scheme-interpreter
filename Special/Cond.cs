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
            return Node.nilNodeWithErrorMsg("TODO:Cond.eval");
        }

        public override void print(Node t, int n, bool p) {
            Printer.printCond(t, n, p);
        }
    }
}

// (cond 
//   ((b< 2 3) 'a)
//   ((b< 3 2) 'b))
