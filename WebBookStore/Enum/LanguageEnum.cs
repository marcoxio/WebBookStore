using System.ComponentModel.DataAnnotations;

namespace WebBookStore.Enum
{
    public enum LanguageEnum
    {
        [Display(Name="Hindi Language")]
        Hindi = 10,
        [Display(Name="English Language")]
        English = 11,
        [Display(Name="German Language")]
        German = 12,
        [Display(Name="Chinese Language")]
        Chinese = 13,
        [Display(Name="Urdu Language")]
        Urdu =14
    }
}