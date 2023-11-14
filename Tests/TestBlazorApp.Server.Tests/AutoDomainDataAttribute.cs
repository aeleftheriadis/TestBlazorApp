using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Server.Tests
{
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute()
          : base(() => new Fixture().Customize(new AutoNSubstituteCustomization { ConfigureMembers = true }))
        {
        }
    }
}