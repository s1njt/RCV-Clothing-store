namespace RCVAPI4.Models.ClotheFolder
{
    public class Clothe
    {
        public Guid Id { get; set; }
        public string clothe_name { get; set; }

        public int clothe_price { get; set; }

        public string clothe_description { get; set; }

        public string clothe_size { get; set; }

        public int clothe_type { get; set; }

        public string clothe_image { get; set; }

        public string clothe_color { get; set; }

        public string clothe_textile { get; set; }
    }
}
