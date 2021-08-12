using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading.Tasks;
using WindowsService.DbContext;
using WindowsService.Entities;
using IdentityModel.Client;
using Newtonsoft.Json;
using WindowsService.Api;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private ServiceDbContext _db = new ServiceDbContext();
        public Service1()
        {
            InitializeComponent(); 

            this.CanStop = true; 
            this.CanPauseAndContinue = true; 
            this.AutoLog = true;    
        }

        protected override async void OnStart(string[] args)
        {
            var logger = new EventLog {Source = "Application"};

            logger.WriteEntry("I'm here",EventLogEntryType.SuccessAudit,101,1);

            var client = await ApiClient.GetClient("client","secret","api1", "https://localhost:5001/");

            var response = await client.GetAsync("https://localhost:5001/api/getbooks");

            var books = JsonConvert.DeserializeObject<List<Book>>(await response.Content.ReadAsStringAsync());

            foreach (var book in books)
            {
               _db.Books.Add(book);
            }

        }

        protected override void OnStop()
        {
        }
    }
}
