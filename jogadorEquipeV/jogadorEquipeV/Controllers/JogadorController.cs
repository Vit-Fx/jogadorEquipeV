using jogadorEquipeV.Dados;
using jogadorEquipeV.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jogadorEquipeV.Controllers
{
    public class JogadorController : Controller
    {
        acoesJogador acJog = new acoesJogador();
        acoesEquipe acEq = new acoesEquipe();
        // GET: Jogador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadJogador()
        {
            ViewBag.Posicoes = new SelectList
            (
                acJog.GetPosicao(),
                   "cdPosicao",
                   "dsPosicao"
            );
            return View();
        }

        [HttpPost]
        public ActionResult CadJogador(modelJogador cmJog, HttpPostedFileBase file)
        {
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/Imagens/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            file.SaveAs(_path);
            cmJog.cdPosicao = Request["Posicoes"];
            cmJog.ftJog = file2;
            acJog.cadJogador(cmJog);
            ViewBag.msg = "Cadastro realizado com sucesso.";
            return CadJogador();
        }

        public ActionResult EditJogador(string id)
        {
           return View(acJog.GetJogador().Find(model => model.cdJog == id));
        }

        [HttpPost]
        public ActionResult EditJogador(int id, modelJogador cmJog, HttpPostedFileBase file)
        {
            acJog.CarregaTododsJogadores();

            if (file == null)
            {
                cmJog.cdJog = id.ToString();
                acJog.atualizaJogadorSemFoto(cmJog);
                ViewBag.msg = "Cadastro atualizado com sucesso";
            }
            else {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/Imagens/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
                file.SaveAs(_path);
                cmJog.ftJog = file2;
                cmJog.cdJog = id.ToString();
                acJog.editJogador(cmJog);
                ViewBag.msg = "Cadastro atualizado com sucesso.";
            }
            return View();
        }

        public ActionResult ListarJogador()
        {
            acJog.GetPosicao();
           return View(acJog.GetJogador());
        }

       

        //public ActionResult ExcluirJogador()
        //    {
        //        return View();
        //    }

    }
}