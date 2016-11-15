// BuiltIn -- the data structure for built-in functions

// Class BuiltIn is used for representing the value of built-in functions
// such as +.  Populate the initial environment with
// (name, new BuiltIn(name)) pairs.

// The object-oriented style for implementing built-in functions would be
// to include the C# methods for implementing a Scheme built-in in the
// BuiltIn object.  This could be done by writing one subclass of class
// BuiltIn for each built-in function and implementing the method apply
// appropriately.  This requires a large number of classes, though.
// Another alternative is to program BuiltIn.apply() in a functional
// style by writing a large if-then-else chain that tests the name of
// the function symbol.

using System;
using System.Collections.Generic;

namespace Tree {
    public class BuiltIn : Node {
        private Node symbol;  // the Ident for the built-in function

        public BuiltIn(Node s) { symbol = s; }

        public Node getSymbol() { return symbol; }

        // The method isProcedure() should be defined in
        // class Node to return false.
        public override bool isProcedure() { return true; }

        public override void print(int n) {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write("#{Built-in Procedure ");
            if (symbol != null)
                symbol.print(-Math.Abs(n));
            Console.Write('}');
            if (n >= 0)
                Console.WriteLine();
        }

        private static Node todo(String name) {
            return Node.nilNodeWithErrorMsg(
                "BuiltIn " + name + "not implemented yet.");
        }

        // This is overridden only in classes BuiltIn and Closure.
        public override Node apply(Node args) {
            String name = symbol.getName().ToLower();

            List<Node> argsList = Node.getArgsList(args);
            int numArgs = argsList.Count;

            if (false) {
                // noop, for now
            } else if (name.Equals("symbol?") && numArgs == 1) {
                return BoolLit.getInstance(argsList[0].isSymbol());
            } else if (name.Equals("number?") && numArgs == 1) {
                return BoolLit.getInstance(argsList[0].isNumber());
            } else if (name.Equals("b+") && numArgs == 2) {
                Node arg1 = argsList[0];
                Node arg2 = argsList[1];
                if (arg1.isNumber() && arg2.isNumber()) {
                    int result = arg1.getIntVal() + arg2.getIntVal();
                    return new IntLit(result);
                }
            } else if (name.Equals("b-") && numArgs == 2) {
                Node arg1 = argsList[0];
                Node arg2 = argsList[1];
                if (arg1.isNumber() && arg2.isNumber()) {
                    int result = arg1.getIntVal() - arg2.getIntVal();
                    return new IntLit(result);
                }
            } else if (name.Equals("b*") && numArgs == 2) {
                Node arg1 = argsList[0];
                Node arg2 = argsList[1];
                if (arg1.isNumber() && arg2.isNumber()) {
                    int result = arg1.getIntVal() * arg2.getIntVal();
                    return new IntLit(result);
                }
            } else if (name.Equals("b/") && numArgs == 2) {
                Node arg1 = argsList[0];
                Node arg2 = argsList[1];
                if (arg1.isNumber() && arg2.isNumber()) {
                    int result = arg1.getIntVal() / arg2.getIntVal();
                    return new IntLit(result);
                }
            } else if (name.Equals("b=") && numArgs == 2) {
                Node arg1 = argsList[0];
                Node arg2 = argsList[1];
                if (arg1.isNumber() && arg2.isNumber()) {
                    bool result = arg1.getIntVal() == arg2.getIntVal();
                    return BoolLit.getInstance(result);
                }
            } else if (name.Equals("b<") && numArgs == 2) {
                Node arg1 = argsList[0];
                Node arg2 = argsList[1];
                if (arg1.isNumber() && arg2.isNumber()) {
                    bool result = arg1.getIntVal() < arg2.getIntVal();
                    return BoolLit.getInstance(result);
                }
            } else if (name.Equals("car") && numArgs == 1) {
                return argsList[0].getCar();
            } else if (name.Equals("cdr") && numArgs == 1) {
                return argsList[0].getCdr();
            } else if (name.Equals("cons") && numArgs == 1) {
                return new Cons(
                    argsList[0], argsList[1]);
            } else if (name.Equals("set-car!") && numArgs == 1) {
                argsList[0].setCar(argsList[1]);
                return new StringLit("#{Unspecific}", false);
            } else if (name.Equals("set-cdr!") && numArgs == 1) {
                argsList[0].setCdr(argsList[1]);
                return new StringLit("#{Unspecific}", false);
            } else if (name.Equals("null?") && numArgs == 1) {
                return BoolLit.getInstance(argsList[0].isNull());
            } else if (name.Equals("pair?") && numArgs == 1) {
                return BoolLit.getInstance(argsList[0].isPair());
            } else if (name.Equals("eq?") && numArgs == 2) {
                Node arg1 = argsList[0];
                Node arg2 = argsList[1];
                bool result = (arg1 == arg2);
                if (arg1.isSymbol() && arg2.isSymbol())
                    result = arg1.getName().Equals(arg2.getName());
                return BoolLit.getInstance(result);
            } else if (name.Equals("procedure?") && numArgs == 1) {
                return BoolLit.getInstance(argsList[0].isProcedure());
            } else if (name.Equals("read") && numArgs == 0) {
                return (Node) Scheme4101.parser.parseExp();
            } else if (name.Equals("write") && numArgs == 1) {
                argsList[0].print(0);
                return new StringLit("#{Unspecific}", false);
            } else if (name.Equals("display") && numArgs == 1) {
                StringLit.SHOULD_PRINT_QUOTES = false;
                argsList[0].print(-1);
                StringLit.SHOULD_PRINT_QUOTES = true;
                return new StringLit("#{Unspecific}", false);
            } else if (name.Equals("newline") && numArgs == 0) {
                Console.WriteLine();
                return new StringLit("#{Unspecific}", false);
            } else if (name.Equals("eval") && numArgs == 2) {
                return argsList[0].eval(argsList[1] as Environment);
            } else if (name.Equals("apply") && numArgs == 2) {
                return argsList[0].apply(argsList[1] as Environment);
            } else if (name.Equals("interaction-environment") && numArgs == 0) {
                return Scheme4101.interactionEnv;
            } else if (name.Equals("load") && numArgs == 1) {
                return todo(name);
            }
            return Node.nilNodeWithErrorMsg("Error: wrong number of arguments");

            // 1. get args
            // 2. return the actual result, depending on the name,
            //    using a monster if statement, making sure to get
            //    it right for all the BuiltIns listed in
            //    Scheme4101.getBuiltInEnv()
            //
            // e.g. (b+ x y) returns IntLit(x + y)... (b+ x) should error
            // etc.

            // +---+-------------------------+-----------------+
            // |   | id                      | numArgs         |
            // +===+=========================+=================+
            // | x | symbol?                 | 1               |
            // +---+-------------------------+-----------------+
            // | x | number?                 | 1: int          |
            // +---+-------------------------+-----------------+
            // | x | b+                      | 2: int, int     |
            // +---+-------------------------+-----------------+
            // | x | b-                      | 2: int, int     |
            // +---+-------------------------+-----------------+
            // | x | b*                      | 2: int int      |
            // +---+-------------------------+-----------------+
            // | x | b/                      | 2: int int      |
            // +---+-------------------------+-----------------+
            // | x | b=                      | 2: int int      |
            // +---+-------------------------+-----------------+
            // | x | b<                      | 2: int int      |
            // +---+-------------------------+-----------------+
            // | x | car                     | 1: list         |
            // +---+-------------------------+-----------------+
            // | x | cdr                     | 1: list         |
            // +---+-------------------------+-----------------+
            // | x | cons                    | 1: list         |
            // +---+-------------------------+-----------------+
            // | x | set-car!                | 1: list         |
            // +---+-------------------------+-----------------+
            // | x | set-cdr!                | 1: list         |
            // +---+-------------------------+-----------------+
            // | x | null?                   | 1: node         |
            // +---+-------------------------+-----------------+
            // | x | pair?                   | 1: node         |
            // +---+-------------------------+-----------------+
            // | x | eq?                     | 2: node         |
            // +---+-------------------------+-----------------+
            // | x | procedure?              | 1: node         |
            // +---+-------------------------+-----------------+
            // | x | read                    | 0               |
            // +---+-------------------------+-----------------+
            // | x | write                   | 1: StringLit?   |
            // +---+-------------------------+-----------------+
            // | x | display                 | 1: StringLit?   |
            // +---+-------------------------+-----------------+
            // | x | newline                 | 0               |
            // +---+-------------------------+-----------------+
            // | x | eval                    | 2: List Env     |
            // +---+-------------------------+-----------------+
            // | x | apply                   | 2: Closure List |
            // +---+-------------------------+-----------------+
            // | x | interaction-environment | 0               |
            // +---+-------------------------+-----------------+
            // |   | load                    | 1: filename     |
            // +---+-------------------------+-----------------+
        }
    }
}

