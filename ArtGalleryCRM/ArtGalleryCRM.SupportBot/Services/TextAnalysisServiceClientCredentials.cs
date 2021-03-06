﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace ArtGalleryCRM.SupportBot.Services
{
    public class TextAnalysisServiceClientCredentials : ServiceClientCredentials
    {
        private readonly string subKey;

        public TextAnalysisServiceClientCredentials(string subscriptionKey)
        {
            if(string.IsNullOrEmpty(subscriptionKey))
            {
                throw new NullReferenceException("You need to add your Cognitive Services Subscription Key. Visit https://azure.microsoft.com/en-us/try/cognitive-services/ to get started.");
            }

            this.subKey = subscriptionKey;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.subKey);

            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}