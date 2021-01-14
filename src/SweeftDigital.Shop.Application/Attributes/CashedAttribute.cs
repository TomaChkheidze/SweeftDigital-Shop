using System;

namespace SweeftDigital.Shop.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CachedAttribute : Attribute
    {
        public CachedAttribute(int minutes)
        {
            Duration = TimeSpan.FromMinutes(minutes);
        }

        public TimeSpan Duration { get; set; }
    }
}
