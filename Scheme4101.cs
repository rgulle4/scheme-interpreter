// Scheme4101 -- The main program of the Scheme interpreter

using System;
using Parse;
using Tokens;
using Tree;

public class Scheme4101
{
    public static int Main(string[] args)
    {
        // Create scanner that reads from standard input
        Scanner scanner = new Scanner(Console.In);
        
        if (args.Length > 1 || 
                (args.Length == 1 && ! args[0].Equals("-d")))
        {
            Console.Error.WriteLine("Usage: mono SPP [-d]");
            return 1;
        }
        
        // If command line option -d is provided, debug the scanner.
        if (args.Length == 1 && args[0].Equals("-d"))
        {
            Token tok = scanner.getNextToken();
            while (tok != null)
            {
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
        Parser parser = new Parser(scanner, builder);

        // TODO: Create and populate the built-in environment
        Tree.Environment builtInEnv = new Tree.Environment();

        // create the top-level environment
        Tree.Environment env = new Tree.Environment(builtInEnv);

        // Read-eval-print loop

        // Print prompt and TODO: evaluate the expression
        Console.Write("> ");
        Node root = (Node) parser.parseExp();
        while (root != null) 
        {
            root.print(0);
            Console.Write("> ");
            root = (Node) parser.parseExp();
        }

        return 0;
    }
}
