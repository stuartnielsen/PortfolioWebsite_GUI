using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.IU.Wasm
{
    public class Auth0AuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public Auth0AuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager, IConfiguration config) : base(provider, navigationManager)
        {
            this.ConfigureHandler(
                authorizedUrls: new[] { config["HttpClientBaseAddress"], "http://localhost:5000" }//, "https://portfolio-snow-jallen.herokuapp.com/", "https://portfolio2.snow.edu" }
            );
        }
    }
}
