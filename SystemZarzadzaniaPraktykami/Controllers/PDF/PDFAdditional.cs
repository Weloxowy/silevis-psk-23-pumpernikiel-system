namespace SystemZarzadzaniaPraktykami.Controllers.PDF;

public class PDFAdditional
{
    public PDFAdditional() : base()
    {
        
    }
    public virtual string argument { get; set; }
    public virtual string profile { get; set; }
    public virtual string job { get; set; }
    public virtual string hours { get; set; }
    public virtual string duty { get; set; }
    public virtual string coordinator { get; set; }
    public virtual string notes { get; set; }
}