using System;
using Senai.ToDo.MVC.Utils;
using Senai.ToDo.MVC.ViewController;
using Senai.ToDo.MVC.ViewModel;

namespace Senai.ToDo.MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcaoDeslogado = 0;

            do
            {
                MenuUtils.MenuDeslogado();
                opcaoDeslogado = int.Parse(Console.ReadLine());
                switch (opcaoDeslogado)
                {
                    case 1:
                    //Cadastro usuario
                    UsuarioViewController.CadastrarUsuario();
                    break;
                    case 2:
                    //Login
                    UsuarioViewModel usuarioRecuperado = UsuarioViewController.Login();
                    if (usuarioRecuperado != null)
                    {
                        System.Console.WriteLine($"Seja Bem Vindo {usuarioRecuperado.Nome}");
                        System.Console.WriteLine("Pressione ENTER para continuar");
                        Console.ReadLine();
                        
                    }
                    break;
                    default:
                        System.Console.WriteLine("Digite uma opção válida");
                    break;
                }
            } while (opcaoDeslogado != 0);
        }
    }
}
