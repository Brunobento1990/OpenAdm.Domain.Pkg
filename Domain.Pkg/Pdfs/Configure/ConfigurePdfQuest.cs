using QuestPDF.Infrastructure;

namespace Domain.Pkg.Pdfs.Configure;

public static class ConfigurePdfQuest
{
    public static void ConfigureQuest()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }
}
