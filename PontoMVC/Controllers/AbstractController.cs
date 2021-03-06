using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PontoMVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
        protected const string SESSION_CLIENTE_ID = "cliente_id";
        protected string ObterUsuarioEmailSession()
        {
            var email = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            if (!string.IsNullOrEmpty(email))
            {
                return email;
            } 
            else
            {
                return "";
            }
        }
        protected string ObterUsuarioNomeSession()
        {
            var nome = HttpContext.Session.GetString(SESSION_CLIENTE_NOME);
            if (!string.IsNullOrEmpty(nome))
            {
                return nome;
            } 
            else
            {
                return "";
            }
        }
        protected string ObterIDUsuarioSession()
        {
            var id = HttpContext.Session.GetString(SESSION_CLIENTE_ID);
            if (id != null)
            {
                return id;
            } 
            else
            {
                return null;
            }
        }
    }
}