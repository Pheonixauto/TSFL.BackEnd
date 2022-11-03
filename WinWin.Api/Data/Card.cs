namespace WinWin.Api.Data
{
    public class Card
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string PathContent { get; set; } = string.Empty;
        public string PathImage { get; set; } = string.Empty;

    }
}
