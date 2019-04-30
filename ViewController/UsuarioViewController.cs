using System;
using Senai.ToDo.MVC.Repositorio;
using Senai.ToDo.MVC.Utils;
using Senai.ToDo.MVC.ViewModel;

namespace Senai.ToDo.MVC.ViewController
{
    public class UsuarioViewController
    {
        static UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        public static void CadastrarUsuario ()
        {
            string nome, email, senha, confirmaSenha, tipo;

            do
            {
                System.Console.WriteLine("Digite seu nome");
                nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome))
                {
                    System.Console.WriteLine("Nome Inválido");
                }
            } while (string.IsNullOrEmpty(nome));
            do
            {
                System.Console.WriteLine("Digite seu E-mail");
                email = Console.ReadLine();
                if (!ValidacaoUtil.ValidarEmail(email))
                {
                    System.Console.WriteLine("E-mail Inválido");
                }
            } while (!ValidacaoUtil.ValidarEmail(email));
            do
            {
                System.Console.WriteLine("Digite sua senha");
                senha = Console.ReadLine();
                if (!ValidacaoUtil.ValidacaoSenha(senha))
                {
                    System.Console.WriteLine("Senha inválida");
                }
            } while (!ValidacaoUtil.ValidacaoSenha(senha));
            do
            {
                System.Console.WriteLine("Confirme sua senha");
                confirmaSenha = Console.ReadLine();
                if (senha != confirmaSenha)
                {
                    System.Console.WriteLine("As senhas não condizem");
                }
            } while (senha != confirmaSenha);
            do
            {
                System.Console.WriteLine("Você é um USUARIO ou ADMIN?");
                tipo = Console.ReadLine();
                if (!tipo.Equals("usuario") || tipo.Equals("admin"))
                {
                    System.Console.WriteLine("Tipo inválido");
                }
            } while (!tipo.Equals("usuario") || tipo.Equals("admin"));

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Nome = nome;
            usuarioViewModel.Email = email;
            usuarioViewModel.Senha = senha;
            usuarioViewModel.Tipo = tipo;

            usuarioRepositorio.Inserir(usuarioViewModel);
            System.Console.WriteLine("Cadastro efetuado com sucesso");
        }
        public static UsuarioViewModel Login()
        {
            string email, senha;
            do
            {
               System.Console.WriteLine("Digite seu E-mail"); 
               email = Console.ReadLine();
               if (!ValidacaoUtil.ValidarEmail(email))
               {
                   System.Console.WriteLine("Email inválido");
               }
            } while (!ValidacaoUtil.ValidarEmail(email));
            System.Console.WriteLine("Digite sua senha");
            senha = Console.ReadLine();
            UsuarioViewModel usuarioRecuperado = usuarioRepositorio.BuscarUsuario(email, senha);
            if (usuarioRecuperado != null)
            {
                return usuarioRecuperado;
            }else
            {
                System.Console.WriteLine("E-mail ou senha inválida");
                return null;
            }
        }
    }
}