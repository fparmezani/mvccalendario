using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace MvcCalendario.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");
        }

        public static string FormataCEP(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"00000\-000");
        }

        public static string FormataTelefone(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"(00) \0000\-000");
        }
        public static string FormataCelular(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"(00) \00000\-0000");
        }
    }
}
