using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddServices.MailService;

namespace AddServices.MailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailInfo emailInfo);
        Task SendEmailTemplateAsync(EmailSource emailSource);
    }
}
