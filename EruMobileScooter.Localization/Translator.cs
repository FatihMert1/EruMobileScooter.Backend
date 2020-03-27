using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace EruMobileScooter.Localization
{
    public class Translator
    {

        private readonly IStringLocalizer<SharedResource> localizer;

        public Translator(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }


        public string GetString(string title)
        {
            return localizer[title];
        }

        public string GetString(string title, params object[] arguments)
        {
            return localizer[title, arguments];
        }
    }
}
