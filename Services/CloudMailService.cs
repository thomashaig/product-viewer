using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace product_viewer.Services {
    public class CloudMailService : IMailService {

        private ILogger<CloudMailService> _logger;

        private string _MailTo = "test@example.com";
        private string _MailFrom = "noreply@example.com";

        public CloudMailService(ILogger<CloudMailService> logger) {
            _logger = logger;
        }

        public void Send(string subject, string message) {
            _logger.LogInformation("Sending Mail In The Cloud");
        }
    }
}