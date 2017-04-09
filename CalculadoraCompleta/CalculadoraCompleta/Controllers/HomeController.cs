using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //inicializar valores
            ViewBag.Visor = 0;
            //ViewBag.Visor = "0";
            Session["PrimeiroOperador"] = true;
            return View();
        }

        //string op1, op2, operador;
        //int resultado;

        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {
            switch (bt)
            {
                case "0": 
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    //determinar se o visor só existe um zero
                    if (visor.Equals("0")) visor = bt;
                    else visor += bt; //visor=visor+bt;
                    break;
                case ",":
                    if (!visor.Contains(",")) visor += ",";
                    break;
                case "+/-":
                    //visor = Convert.ToDouble(visor)*-1+"";   //visor é uma string, converte para double, e adiciona string para tornar de novo uma string
                    if (visor.StartsWith("-")) visor = visor.Replace("-", "");
                    else
                        if(!visor.Equals("0"))
                            visor = "-" + visor;
                    break;
                case "C":
                    visor = "0";
                    Session["PrimeiroOperador"] = true;
                    break;
                case "+":
                case "-":
                case "x":
                case ":":
                    if((bool)Session["PrimeiroOperador"]) { 
                        //guardar o valor do visor
                        //op1 = visor;
                        Session["operando"] = visor;
                        //limpar o visor
                        visor = "0";
                        //guardar o operador
                        //operador = bt;
                        Session["operador"] = bt;
                        //marcar como tendo utilizado o operador
                        Session["PrimeiroOperador"] = false;
                    }
                    else
                    {
                        //se não é a primeira vez que se clica num operador, 
                        //vou utilizar os valores anteriores
                        switch ((string)Session["operador"])
                        {
                            //recuperador código da primeira calculador
                        }
                        //guardar os novos valores...

                    }
                    break;

                default:
                    break;
            }
            //entregar o novo valor à vew
            ViewBag.Visor = visor;
            return View();
        }
    }
}