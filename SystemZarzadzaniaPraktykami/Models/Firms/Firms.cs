namespace SystemZarzadzaniaPraktykami.Models.Firms
{
    public class Firms
    {
        public Firms() : base() { }

        public Firms(Guid id, string name, string phone_contact, string mail, int nip, int regon, int krs, Guid address)
        {
            this.id = id;
            this.name = name;
            this.phone_contact = phone_contact;
            this.mail = mail;
            this.nip = nip;
            this.regon = regon;
            this.krs = krs;
            this.address = address;
        }


        public virtual Guid id { get; set; }
        public virtual string name { get; set; }
        public virtual string phone_contact { get; set; }
        public virtual string mail { get; set; }
        public virtual int nip { get; set; }
        public virtual int regon { get; set; }
        public virtual int krs { get; set; }
        public virtual Guid address { get; set; }
    }
}
