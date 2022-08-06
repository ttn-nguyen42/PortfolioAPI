using System.Text;

namespace Portfolio.Utils
{
    public static class FileNameGenerator
    {
        public static string RandomName()
        {
            Random random = new Random();
            const int size = 10;
            StringBuilder builder = new StringBuilder(size);
            const int start = 'a';
            const int letterOffset = 26;
            for (int i = 0; i < size; i += 1)
            {
                builder.Append((char) random.Next(start, start + letterOffset));
            }
            return builder.ToString();
        }
    }
}
