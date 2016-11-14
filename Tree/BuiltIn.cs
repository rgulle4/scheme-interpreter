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

        // This is overridden only in classes BuiltIn and Closure.
        // TODO: finish this
        public override Node apply(Node args) {
            String name = symbol.getName();

            // 1. get args
            // 2. return the actual result, depending on the name,
            //    using a monster if statement, making sure to get
            //    it right for all the BuiltIns listed in 
            //    Scheme4101.getBuiltInEnv()
            //
            // e.g. (b+ x y) returns IntLit(x + y)... (b+ x) should error
            // etc.

            // +-------------------------+-----------------+
            // | id                      | numArgs         |
            // +=========================+=================+
            // | symbol?                 | 1               |
            // +-------------------------+-----------------+
            // | number?                 | 1: int          |
            // +-------------------------+-----------------+
            // | b+                      | 2: int, int     |
            // +-------------------------+-----------------+
            // | b-                      | 2: int, int     |
            // +-------------------------+-----------------+
            // | b*                      | 2: int int      |
            // +-------------------------+-----------------+
            // | b/                      | 2: int int      |
            // +-------------------------+-----------------+
            // | b=                      | 2: int int      |
            // +-------------------------+-----------------+
            // | b<                      | 2: int int      |
            // +-------------------------+-----------------+
            // | car                     | 1: list         |
            // +-------------------------+-----------------+
            // | cdr                     | 1: list         |
            // +-------------------------+-----------------+
            // | cons                    | 1: list         |
            // +-------------------------+-----------------+
            // | set-car!                | 1: list         |
            // +-------------------------+-----------------+
            // | set-cdr!                | 1: list         |
            // +-------------------------+-----------------+
            // | null?                   | 1: node         |
            // +-------------------------+-----------------+
            // | pair?                   | 1: node         |
            // +-------------------------+-----------------+
            // | eq?                     | 2: node         |
            // +-------------------------+-----------------+
            // | procedure?              | 1: node         |
            // +-------------------------+-----------------+
            // | read                    | 0               |
            // +-------------------------+-----------------+
            // | write                   | 1: StringLit?   |
            // +-------------------------+-----------------+
            // | display                 | 1: StringLit?   |
            // +-------------------------+-----------------+
            // | newline                 | 0               |
            // +-------------------------+-----------------+
            // | eval                    | 2: List Env     |
            // +-------------------------+-----------------+
            // | apply                   | 2: Closure List |
            // +-------------------------+-----------------+
            // | interaction-environment | 0               |
            // +-------------------------+-----------------+
            // | load                    | 1: filename     |
            // +-------------------------+-----------------+
            
            return new StringLit("Error: BuiltIn.apply not yet implemented");

        }
    }    
}

