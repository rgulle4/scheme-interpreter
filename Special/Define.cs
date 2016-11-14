// Define -- Parse tree node strategy for printing the special form define

using System;
using System.Collections.Generic;

namespace Tree {
    public class Define : Special {
        public Define() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            List<Node> argsList = Node.getArgsList(exp.getCdr());
            int numArgs = argsList.Count;

            if (numArgs < 2) 
                return Node.nilNodeWithErrorMsg("Error: invalid expression");
             
             if (argsList[0].isSymbol() && numArgs == 2) {
                 Node id = argsList[0];
                 Node val = argsList[1].eval(env);
                 env.define(id, val);
                 StringLit.SHOULD_PRINT_AT_ALL = false;
                 return new StringLit("");
             }


            return Node.nilNodeWithErrorMsg("Error: invalid expression");
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printDefine(t, n, p);
        }
    }
}


