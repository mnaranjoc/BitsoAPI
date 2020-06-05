using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitsoAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BitsoAPI.Controllers
{
    public class TickersController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickers
        public ActionResult Index()
        {
            List<Ticker> currentTicker = getTicker();

            return View(currentTicker);
        }

        List<Ticker> getTicker()
        {
            List<Ticker> tickerList = new List<Ticker>();

            using (WebClient webClient = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var json = webClient.DownloadString("https://api.bitso.com/v3/ticker/?book=btc_mxn");
                var ticker = JsonConvert.DeserializeObject<Ticker>(json);

                tickerList.Add(ticker);
            }

            return tickerList;
        }
    }
}
