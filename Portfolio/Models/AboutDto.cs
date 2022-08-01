namespace Portfolio.Models
{
    public class AboutDto
    {
        public int Id { get; set; }

        public string Biography { get; set; }

        public AboutDto(string biography)
        {
            Biography = biography;
        }
    }
}
