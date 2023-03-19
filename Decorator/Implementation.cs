namespace Decorator
{
    public interface IMailService
    {
        bool SendMail(string message);
    }

    public class CloudMailService : IMailService
    {
        public bool SendMail(string message) 
        {
            Console.WriteLine($"Message \"{message}\" sent via {nameof(CloudMailService)}.");
            return true;
        }
    }

    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" sent via {nameof(OnPremiseMailService)}.");
            return true;
        }
    }

    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService) { }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}.");
            return base.SendMail(message);
        }
    }

    public class MesasgeDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new();

        public MesasgeDatabaseDecorator(IMailService mailService) : base(mailService) { }

        public override bool SendMail(string message)
        {
            if(base.SendMail(message))
            {
                SentMessages.Add(message);
                return true;
            }

            return false;
        }
    }

}
