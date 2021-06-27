namespace Entity_User
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Award(){}

        public Award(string title)
        {
            this.Title = title;
        }
        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
}