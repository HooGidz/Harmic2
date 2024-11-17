namespace Harmic.Utilities
{
    public class Function
    {
        public static string TitleSlugGenerationAlias(string tiltle)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(tiltle);
        }
    }
}
