using System.Net.Http.Headers;

namespace SheetApi
{
    public class Pro
    {
        static IList<object> valuesnew;
        static Item item;

        public static List<Item> MapFromRangeData(IList<IList<object>> values)
        {

            var items = new List<Item>();
            foreach (var value in values)
            {
                if (value.Count < 12)
                {
                    valuesnew[0] = value[0];
                    valuesnew[1] = value[3];
                    valuesnew[2] = value[4];
                    valuesnew[3] = value[5];
                    valuesnew[4] = value[7];
                    valuesnew[5] = value[9];
                    valuesnew[6] = value[10];
                    valuesnew[7] = value[11];
                    valuesnew[8] = value[12];
                    valuesnew[9] = value[13];
                    valuesnew[10] = value[20];
                    item = new()
                    {

                        Id = valuesnew[0].ToString(),
                        Cert = valuesnew[1].ToString(),
                        StoneId = valuesnew[2].ToString(),
                        CertNo = valuesnew[3].ToString(),
                        TYPE = valuesnew[4].ToString(),
                        Carat = valuesnew[5].ToString(),
                        Shape = valuesnew[6].ToString(),
                        Clarity = valuesnew[7].ToString(),
                        Color = valuesnew[8].ToString(),
                        Cut = valuesnew[9].ToString(),
                        Price = valuesnew[10].ToString(),
                    };
                }
                else
                {
                    item = new()
                    {

                        Id = value[0].ToString(),
                        Cert = value[3].ToString(),
                        StoneId = value[4].ToString(),
                        CertNo = value[5].ToString(),
                        TYPE = value[7].ToString(),
                        Carat = value[9].ToString(),
                        Shape = value[10].ToString(),
                        Clarity = value[11].ToString(),
                        Color = value[12].ToString(),
                        Cut = value[13].ToString(),
                        Price = value[20].ToString(),
                    };
                }
                 

                items.Add(item);
                
            }

            return items;
        }

        public static IList<IList<object>> MapToRangeData(Item item)
        {
            var objectList = new List<object>() { item.Id,item.StoneId,item.CertNo, item.Image, item.Video,item.Carat,item.Cert,item.TYPE,item.Clarity,item.Shape,item.Color,item.Cut, item.Price };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
        
       
    }
}
