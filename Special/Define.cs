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
            
            // define a variable
            if (argsList[0].isSymbol() && numArgs == 2) {
                Node id = argsList[0];
                Node val = argsList[1].eval(env);
                env.define(id, val);
                StringLit.SHOULD_PRINT_AT_ALL = false;
                return new StringLit("");
            }

            // TODO: finish define a function
            if (argsList[0].isPair() && numArgs == 2) {
                Node fnSignature = argsList[0];
                Node fnBody = argsList[1];

                Node fnId = fnSignature.getCar();
                Node fnArgs = fnSignature.getCdr();
                List<Node> fnArgsList = Node.getArgsList(fnArgs); 

                if (!fnId.isSymbol() || fnArgsAreNotValid(fnArgsList))
                    return Node.nilNodeWithErrorMsg("Error: ill-formed definition");

                Node id = fnId;
                Node val = (new Cons(
                    new Ident("lambda"),
                    new Cons(fnArgs, fnBody)
                )).eval(env);

                env.define(id, val);                
                StringLit.SHOULD_PRINT_AT_ALL = false;
                return new StringLit("");
            }

            return Node.nilNodeWithErrorMsg("Error: invalid expression");
        }

        private bool fnArgsAreNotValid(List<Node> fnArgsList) {
            return !fnArgsAreAllValid(fnArgsList);
        }

        private bool fnArgsAreAllValid(List<Node> fnArgsList) {
            bool ok = true;
            foreach (Node arg in fnArgsList) {
                if (!arg.isSymbol())
                    return false;
            }
            return ok;
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printDefine(t, n, p);
        }
    }
}


