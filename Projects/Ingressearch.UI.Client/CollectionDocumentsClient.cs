using Ingressearch.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ingressearch.UI.Client
{
    public class CollectionDocumentsClient: ClientBase
    {

        public CollectionDocumentsClient(IConfiguration configuration)
            : base(configuration) { }

    }

}
