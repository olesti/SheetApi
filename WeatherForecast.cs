namespace SheetApi
{
    
    public class Item
    {
        public string? Id { get; set; }
        public string Image => "https://ssdweb.co/ssdweb/hd/imaged/" + StoneId + "/still.jpg";
        public string Video => "https://ssdweb.co/ssdweb/hd/Vision360.html?d=" + StoneId + "&zoomslide=1&z=1&i=http://ssdweb.co/ssdweb/BasicInfo.aspx?STONELIST=" + StoneId + "&ISCONFIRM=0";
        public string Cert { get; set; }
        public string StoneId { get; set; }
        public string CertNo { get; set; }
        public string TYPE { get; set; }
        public string Carat { get; set; }
        public string Shape { get; set; }
        public string Clarity { get; set; }
        public string Color { get; set; }
        public string Cut { get; set; }
        public string Price { get; set; }
     
    }
}