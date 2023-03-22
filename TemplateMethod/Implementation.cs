namespace TemplateMethod
{ 
    public abstract class MailParser
    {
        public virtual void FindServer()
        {
            Console.WriteLine("Finding server ...");
        }

        public abstract void AuthenticateToServer();

        public string ParseHtmlMailBody(string identifier)
        {
            Console.WriteLine("Parsing HTML mail body ..");
            return $"This is body of mail with id {identifier}";
        }

        // Template method
        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing mail body (in templte method) ...");
            FindServer();
            AuthenticateToServer();
            return ParseHtmlMailBody(identifier);
        }
    }

    public class ExchangeMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Exchange");
        }
    }

    public class ApacheMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Apache");
        }
    }

    public class EudoreMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Eudora");
        }

        public override void FindServer()
        {
            Console.WriteLine("Finding Eudora server through a custom algorithm ...");
        }
    }
}
