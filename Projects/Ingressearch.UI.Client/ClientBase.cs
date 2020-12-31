using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingressearch.UI.Client
{
    public abstract class ClientBase
    {

        private readonly IConfiguration _configuration;

        public ClientBase(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected string BaseUrl => $"{_configuration.GetSection("server_baseurl").Value}/api/v1";

    }
}
