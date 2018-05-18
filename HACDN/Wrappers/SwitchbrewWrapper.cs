using HACDN.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace HACDN.Wrappers
{
    public class SwitchbrewWrapper
    {
        private static HttpClient client = new HttpClient();

        public SwitchbrewWrapper()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Dalvik/1.6.0 (Linux; U; Android 4.4.4; SAMSUNG-SGH-I337 Build/KTU84P) RabbitAndroid/3.0.9369.1");
        }

        public async Task<List<Title>> GetTitlesAsync()
        {
            List<Title> result = new List<Title>();
            var response = await client.GetAsync("http://switchbrew.org/api.php?action=parse&page=Title_list/Games&format=json").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var table = ParseTable(responseData);
                foreach (var row in table.Rows)
                {
                    if (row.isHeader)
                        continue;

                    var title = new Title();
                    title.TitleID = row.Columns[0].Trim();
                    title.Description = row.Columns[1].Trim();
                    title.Region = row.Columns[2].Trim();
                    title.RequiredOS = row.Columns[3].Trim();
                    title.TitleVersions = row.Columns[4].Trim();
                    title.CartridgeDescription = row.Columns[5].Trim();
                    title.Type = row.Columns[6].Trim();
                    result.Add(title);
                }
            }
            else
            {
                const string msg = "The last request didnt work out!.";
                Debug.WriteLine($"------\nError: {msg}\n------\n");
                throw new Exception($"Error: {msg}");
            }
            return result;
        }

        public Table ParseTable(string response)
        {
            var page = SwitchbrewPage.FromJson(response);
            //Here we find the first table
            var tmp = page.Parse.Text.Empty;
            tmp = tmp.Substring(tmp.IndexOf("<tr>\n<th>"));
            tmp = tmp.Substring(0, tmp.IndexOf("</table>"));

            return new Table(tmp);
        }
    }
}