// Scheme4101 -- The main program of the Scheme interpreter

using System;
using Parse;
using Tokens;
using Tree;
using Environment = Tree.Environment;

public class Scheme4101 {

    public static Parser parser;
    public static Environment interactionEnv;

    public static int Main(string[] args) {
        // Create scanner that reads from standard input
        Scanner scanner = new Scanner(Console.In);

        if (args.Length > 1 ||
                (args.Length == 1 && ! args[0].Equals("-d"))) {
            Console.Error.WriteLine("Usage: mono SPP [-d]");
            return 1;
        }

        // If command line option -d is provided, debug the scanner.
        if (args.Length == 1 && args[0].Equals("-d")) {
            Token tok = scanner.getNextToken();
            while (tok != null) {
                TokenType tt = tok.getType();

                Console.Write(tt);
                if (tt == TokenType.INT)
                    Console.WriteLine(", intVal = " + tok.getIntVal());
                else if (tt == TokenType.STRING)
                    Console.WriteLine(", stringVal = " + tok.getStringVal());
                else if (tt == TokenType.IDENT)
                    Console.WriteLine(", name = " + tok.getName());
                else
                    Console.WriteLine();
                tok = scanner.getNextToken();
            }
            return 0;
        }

        // Create parser
        TreeBuilder builder = new TreeBuilder();
        parser = new Parser(scanner, builder);

        // Create and populate the built-in environment and
        // create the top-level environment
        Environment builtInEnv = getBuiltInEnv();
        interactionEnv = new Environment(builtInEnv);

        // Read-eval-print loop

        // Print prompt and evaluate the expression
        Console.Write("> ");
        Node root = (Node) parser.parseExp();
        while (root != null)  {
            StringLit.SHOULD_PRINT_QUOTES = true;
            StringLit.SHOULD_PRINT_AT_ALL = true;
            root.eval(interactionEnv).print(0);
            Console.Write("> ");
            StringLit.SHOULD_PRINT_QUOTES = true;
            StringLit.SHOULD_PRINT_AT_ALL = true;
            root = (Node) parser.parseExp();
        }

        return 0;
    }

    private static Environment getBuiltInEnv() {
        Environment e = new Environment();
        addIdentToEnv(e, "symbol?");
        addIdentToEnv(e, "number?");
        addIdentToEnv(e, "b+");
        addIdentToEnv(e, "b-");
        addIdentToEnv(e, "b*");
        addIdentToEnv(e, "b/");
        addIdentToEnv(e, "b=");
        addIdentToEnv(e, "b<");
        // addIdentToEnv(e, "b>");
        addIdentToEnv(e, "car");
        addIdentToEnv(e, "cdr");
        addIdentToEnv(e, "cons");
        addIdentToEnv(e, "set-car!");
        addIdentToEnv(e, "set-cdr!");
        addIdentToEnv(e, "null?");
        addIdentToEnv(e, "pair?");
        addIdentToEnv(e, "eq?");
        addIdentToEnv(e, "procedure?");
        addIdentToEnv(e, "read");
        addIdentToEnv(e, "write");
        addIdentToEnv(e, "display");
        addIdentToEnv(e, "newline");
        addIdentToEnv(e, "eval");
        addIdentToEnv(e, "apply");
        addIdentToEnv(e, "interaction-environment");
        addIdentToEnv(e, "load");
        return e;
    }

    private static void addIdentToEnv(Environment e, String identName) {
        Ident ident = new Ident(identName);
        e.define(ident, new BuiltIn(ident));
    }
}
