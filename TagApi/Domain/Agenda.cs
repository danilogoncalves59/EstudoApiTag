namespace TagApi.Domain
{
    public sealed class Agenda
    {
        public long? id { get; set; }
        public string id_agenda { get; set; }
        public string bandeira { get; set; }
        public double valor { get; set; }
        public int fk_user { get; set; }
    }
}
