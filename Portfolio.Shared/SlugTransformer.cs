using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class SlugTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            return value?.ToString().ToSlug();
        }
    }
}
