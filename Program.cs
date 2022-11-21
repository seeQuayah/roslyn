using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;
using System.Linq;

namespace Testparser
{
    class Program
    {
        public static void Main()
        {
            var parsed = CSharpSyntaxTree.ParseText(File.ReadAllText(@"C:\Users\Jc\source\repos\Testparser\Test.cs"));
            CompilationUnitSyntax root = parsed.GetCompilationUnitRoot();
            MemberDeclarationSyntax firstMember = root.Members[0];
            var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
            var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
            foreach (MethodDeclarationSyntax member in programDeclaration.Members.Where(x => x.GetType() == typeof(MethodDeclarationSyntax)))
            {
                Console.WriteLine(member);
                var x = member.Body.Statements[1].DescendantNodes().OfType<BinaryExpressionSyntax>().ToList(); //InitializerExpressionSyntax
                var childNode = member.Body.Statements[0].DescendantNodes().ElementAt(0); //VariableDeclarationSyntax
                foreach (var c in childNode.DescendantNodes())
                {
                    Console.WriteLine(c.GetType());
                }

            }
            foreach (var member in programDeclaration.Members.Where(x => x.GetType() == typeof(StructDeclarationSyntax)))
            {
                //Console.WriteLine(member.ToString());
            }
            /*var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[0];
            Console.WriteLine($"The return type of the {mainDeclaration.Identifier} method is {mainDeclaration.ReturnType}.");
            Console.WriteLine($"The method has {mainDeclaration.ParameterList.Parameters.Count} parameters.");
            foreach (ParameterSyntax item in mainDeclaration.ParameterList.Parameters)
                Console.WriteLine($"The type of the {item.Identifier} parameter is {item.Type}.");
            Console.WriteLine($"The body text of the {mainDeclaration.Identifier} method follows:");
            Console.WriteLine(mainDeclaration.Body.ToFullString());
            foreach (StatementSyntax statement in mainDeclaration.Body.Statements)
            {
                Console.WriteLine(statement.ToString());
            }
            Console.ReadLine();*/
        }
    }
}
