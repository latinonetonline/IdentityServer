﻿using Microsoft.Extensions.Localization;

using System.Collections.Generic;

namespace Project4.STS.Identity.Helpers.Localization
{
    public interface IGenericControllerLocalizer<out T>
    {
        LocalizedString this[string name] { get; }

        LocalizedString this[string name, params object[] arguments] { get; }

        IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures);
    }
}







