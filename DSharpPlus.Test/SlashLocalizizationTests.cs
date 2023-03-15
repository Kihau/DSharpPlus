// This file is part of the DSharpPlus project.
//
// Copyright (c) 2015 Mike Santiago
// Copyright (c) 2016-2023 DSharpPlus Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.Test
{
    public class SlashLocalizizationTests : ApplicationCommandModule
    {
        [SlashCommand("cool_command", "This is the default description of the command, written in English.")]

        [NameLocalization(Localization.German, "cooles_kommando")]
        [DescriptionLocalization(Localization.German, "Dies ist die Standardbeschreibung des Befehls in deutscher Sprache.")]

        [NameLocalization(Localization.French, "commande_cool")]
        [DescriptionLocalization(Localization.French, "Ceci est la description par défaut de la commande, écrite en français.")]

        [NameLocalization(Localization.Spanish, "comando_cool")]
        [DescriptionLocalization(Localization.Spanish, "Esta es la descripción por defecto de la orden, escrita en español.")]
        public async Task CoolCommand
        (
            InteractionContext ctx,

            [Option("some_option", "This is the default description of the option, written in English.")]

            [NameLocalization(Localization.German, "einige_optionen")]
            [DescriptionLocalization(Localization.German, "Dies ist die Standardbeschreibung des Argumentes, in Deutsch.")]

            [NameLocalization(Localization.French, "une_option")]
            [DescriptionLocalization(Localization.French, "Ceci est la description par défaut de l'argument, écrite en français.")]

            [NameLocalization(Localization.Spanish, "alguna_opción")]
            [DescriptionLocalization(Localization.Spanish, "Esta es la descripción por defecto del argumento, escrita en español.")]
            string argument = null
        )
        {
            var locale = ctx.Interaction.Locale is null ? Localization.AmericanEnglish : LocaleHelper.StringsToLocale[ctx.Interaction.Locale];

            await ctx.CreateResponseAsync(
                locale switch {
                    Localization.German => "Du hast die Sache gemacht!",
                    Localization.French => "Vous avez fait la chose!",
                    Localization.Spanish => "Has hecho la cosa!",
                    _ => "You did the thing!"
                });
        }

    }
}
