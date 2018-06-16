using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace product_viewer.Services {
    public class LocalMailService : IMailService {

        private ILogger<LocalMailService> _logger;

        private string _MailTo = "nosend@example.com";
        private string _MailFrom = "noreply@example.com";

        public LocalMailService(ILogger<LocalMailService> logger) {
            _logger = logger;
        }

        public void Send(string subject, string message) {
            _logger.LogInformation($"Sending Mail to {_MailTo}");
        }
    }
}