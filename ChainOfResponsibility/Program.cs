using ChainOfResponsibility;

Console.Title = "Chain of Responsibility";

var validDocument = new Document("How to avoid Java development", DateTime.Now, true, true);

var invalidDocument = new Document("How to avoid Java development", DateTime.Now, false, true);

var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain.SetSuccessor(new DocumentLastModifiedHandler())
                    .SetSuccessor(new DocumentApprovedByLitigationHandler())
                    .SetSuccessor(new DocumentApprovedByManagementHandler());

try 
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("Valid document is valid");
    documentHandlerChain.Handle(invalidDocument);
    Console.WriteLine("Invalid document is valid");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();
