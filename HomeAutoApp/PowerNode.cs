using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeAutoApp
{
    public class PowerNode
    {
        #region Constructor
        public PowerNode(string baseUrl, int numChannels)
        {
            BaseUrl = baseUrl;
            NumChannels = numChannels;
        }
        #endregion

        string BaseUrl { set; get; }
        int NumChannels { set; get; }

        public List<bool> getStates() 
        {
            List<bool> states = new List<bool>();

            string html = Scraper.getHtml($"{BaseUrl}/relay_states");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var query = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
                        from row in table.SelectNodes("tr").Cast<HtmlNode>()
                        from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                        select new { Table = table.Id, CellText = cell.InnerText };

            /* Looping this way to discard headers */
            foreach(int index in Enumerable.Range(NumChannels, NumChannels))
            {
                var cell = query.ElementAt(index);
                bool val = Convert.ToBoolean(Int32.Parse(cell.CellText));
                states.Add(val);
            }

            return states;
        }

        public void channelOn(int channel)
        {
            if(channel > 0 && channel < NumChannels)
            {
                Scraper.getHtml($"{BaseUrl}/relay_{channel}_on");
            }
        }

        public void channelOff(int channel)
        {
            if (channel > 0 && channel < NumChannels)
            {
                Scraper.getHtml($"{BaseUrl}/relay_{channel}_off");
            }
        }
    }
}
