using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace DarioCazabat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComoFunciona()
        {
            
            return View();
        }

        public ActionResult PreguntasFrecuentes()
        {
           
            return View();
        }

        public ActionResult Contacto()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contacto(string nombre, string email, string consulta)
        {
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            //clienteSmtp.Host = "smtp.gmail.com";
            //clienteSmtp.Port = 587;
            clienteSmtp.Credentials = new NetworkCredential("dario.cazabat@gmail.com", "rivermivida14*-");
            clienteSmtp.EnableSsl = true;

            //mail para el dueño de la aplicación
            MailMessage mensajeParaAplicacion = new MailMessage();
            mensajeParaAplicacion.From = new MailAddress("dario.cazabat@gmail.com", "Mensaje desde Venado MARKER");
            mensajeParaAplicacion.To.Add("dario.cazabat@gmail.com");
            mensajeParaAplicacion.Subject = "Mensaje desde Venado MARKER";
            mensajeParaAplicacion.Body = nombre + " (" + email + ") te contactó desde la aplicación Venado MARKER y dejó la siguiente consulta: " + consulta;

            clienteSmtp.Send(mensajeParaAplicacion);

            //mail para el usuario
            MailMessage mensajeParaUsuario = new MailMessage();
            mensajeParaUsuario.From = new MailAddress("dario.cazabat@gmail.com", "Tu mensaje fue enviado");
            mensajeParaUsuario.To.Add(email);
            mensajeParaUsuario.Subject = "Gracias por comunicarte con Venado MARKER!";
            mensajeParaUsuario.IsBodyHtml = true;
            mensajeParaUsuario.Body = "Hola " + nombre + ", <br>Gracias por contactarte con nosotros!<br>Tu mensaje fue: <b>" + consulta + "</b><br>Saludos!!!!<br><b>El equipo del blog</b><br><img src=\"http://statictycf5b.tycsports.com/sites/default/files/styles/landscape_642_366/public/nota_periodistica/16-02-2016_buenos_aires_mariano_pavone_festeja.jpg\">";

            clienteSmtp.Send(mensajeParaUsuario);

            //return RedirectToAction("Index");
            ViewBag.Nombre = nombre;
            return View();
        }

    }
}