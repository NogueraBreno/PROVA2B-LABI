using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppPB2___Breno_nogueira__.Models;

namespace WebAppPB2___Breno_nogueira__.Controllers
{
    public class EventosController : Controller
    {
        private EventoContext db = new EventoContext();

        // GET: Eventos
        public ActionResult Index(string ordenacao, int? pagina)
        {
            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.TituloParam = String.IsNullOrEmpty(ordenacao) ? "Titulo_desc" : "";
            ViewBag.DescricaoParam = ordenacao == "Tipo" ? "Tipo_desc" : "Tipo";

            var eventos = from e in db.Eventos select e;

            int tamanhoPagina = 3;
            int numeroPagina = pagina ?? 1;

            switch (ordenacao)
            {
                case "Titulo_desc":
                    eventos = eventos.OrderByDescending(s => s.Titulo);
                    break;
                case "Descricao":
                    eventos = eventos.OrderBy(s => s.Descricao);
                    break;
                case "Descricao_desc":
                    eventos = eventos.OrderByDescending(s => s.Descricao);
                    break;

            }


            return View(eventos.ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            TempData["MensagemC"] = "Evento Cadastrado com Sucesso!";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descricao")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            TempData["MensagemU"] = "Evento Atualizado com Sucesso!";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descricao")] Evento evento)
        {


            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            TempData["MensagemD"] = "Evento Excluido com Sucesso!";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
