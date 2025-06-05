using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

public class SyntaxReceiver : ISyntaxReceiver
{
    public List<ClassDeclarationSyntax> MarkedClasses { get; } = new();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        // Simply collect ALL classes for testing
        if (syntaxNode is ClassDeclarationSyntax classDecl)
        {
            MarkedClasses.Add(classDecl);
        }
    }
}