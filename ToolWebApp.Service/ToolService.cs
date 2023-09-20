using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Linq.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToolWebApp.Dao;
using ToolWebApp.Domain;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace ToolWebApp.Service
{
    public class ToolService/* : IService<Tool>*/
    {

        ToolRepository toolrepository = new ToolRepository();


        public async Task<Tool> GetById(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.0.59:51699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Tool tool = null;
                HttpResponseMessage response = await client.GetAsync($"api/tool/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tool = JsonConvert.DeserializeObject<Tool>(content);
                }

                return tool;
            }
        }

        public async Task<List<Tool>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.0.59:51699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<Tool> tools = new List<Tool>();
                HttpResponseMessage response = await client.GetAsync("/api/tool");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tools = JsonConvert.DeserializeObject<List<Tool>>(content);
                }

                return tools;
            }
        }





        //public Tool GetById(string id)
        //{

        //    var dao = new ToolRepository();

        //    return dao.GetById(id);
        //}

        public async Task<HttpStatusCode> Remove(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.0.59:51699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"api/tool/{id}");



                return response.StatusCode;
            }
        }


        //    public void Remove(string id)
        //{

        //    var dao = new ToolRepository();
        //    dao.Delete(id);
        //}







        public async Task SaveTool(Tool tool)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.0.59:51699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                // Verifica se il tool esiste già
                var existingTool = await GetById(tool.IdTool);

                if (existingTool != null)
                {
                    // Esegue una richiesta di aggiornamento
                    var json = JsonConvert.SerializeObject(tool);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PutAsync($"api/tool/{tool.IdTool}", content);
                }
                else
                {
                    // Esegue una richiesta di inserimento
                    var json = JsonConvert.SerializeObject(tool);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync("api/tool", content);
                }

                response.EnsureSuccessStatusCode();
            }
        }





        public List<KeyValuePair<string, string>> GetAllTurretCodes()
        {
            ToolRepository dao = new ToolRepository();
            return dao.GetAllTurretCodes();
        }





        //public List<Tool> Search(string id, string turretCode)
        //{
        //    ToolRepository toolRepository = new ToolRepository();
        //    return toolRepository.Search(id, turretCode);

        //}

        public async Task<List<Tool>> Search(string id, string turretCode)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.0.59:51699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                List<Tool> tool = null;
                HttpResponseMessage response = await client.GetAsync($"api/tool/search?id={id}&turretCode={turretCode}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tool = JsonConvert.DeserializeObject<List<Tool>>(content);
                }

                return tool;
            }
        }
    }
}