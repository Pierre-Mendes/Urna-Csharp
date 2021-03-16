using System;

namespace urna
{
    class Program
    {
        static void Main(string[] args)
        {
            voto Voto = new voto();
            int matricula = 0;
            string matriculaAux = "";
            string textConf = " Aperte 1 para Cofirmar seu Voto || Ou 2 para Corrigir seu Voto: ";
            string textFalha = " Error 404!! Contacte um Mesário! ";
            int conf = 0;
            bool aux = false;
            bool aux1 = false;
            do{
                try {
                    Console.Clear();
                    Console.WriteLine(" ****ELEIÇÕES 2020**** ");
                    Console.WriteLine(" ****URNA ELETRÔNICA 2020**** ");
                    Console.WriteLine(" **** SEJA BEM VINDO!!! **** ");
                    Console.WriteLine(" Para Votar em BRANCO digite 0000 no Terminal ");
                    Console.WriteLine(" Digite o número de um candidato inesxistente para anular seu voto ");
                    Console.WriteLine();
                    Console.Write(" Digite o número do candidato: ");
                    matriculaAux = Console.ReadLine();
                    matricula = int.Parse(matriculaAux);                   

                    if(matricula != 9999) {
                        if(matriculaAux.Length == 4 || matricula == 0000) {
                            if(matricula == 0000) {
                                Console.WriteLine(" Seu voto sera contabilizado como branco,{0}", textConf);
                                conf = int.Parse(Console.ReadLine());
                                if(conf == 1) {
                                     aux1 = Voto.ComputarVoto(matriculaAux);
                                        if(aux1) {
                                            Console.WriteLine(" Seu Voto foi computado com Sucesso! ");
                                            Console.ReadKey();
                                        } else {
                                            Console.WriteLine(textFalha);
                                        }
                                } else if(conf != 2) {
                                    Console.WriteLine(" Operação Invalida! ");
                                }
                            } else if(matricula == 8888) {
                                Voto.Listar();
                            } else {
                                aux = Voto.Procurar(matriculaAux);
                                if(aux) {
                                    Console.WriteLine(textConf);
                                    conf = int.Parse(Console.ReadLine());
                                    if(conf == 1) {
                                        aux1 = Voto.ComputarVoto(matriculaAux);
                                        if(aux1) {
                                            Console.WriteLine(" Seu Voto foi computado com Sucesso! ");
                                            Console.ReadKey();
                                        } else {
                                            Console.WriteLine(textFalha);
                                            Console.ReadKey(); 
                                        }                                      
                                    } else if(conf != 2) {
                                        Console.WriteLine(" Operação Invalida! ");
                                        Console.ReadKey();
                                    }
                                }else {
                                    matriculaAux = "9999";
                                    Console.WriteLine(" Você deseja anular seu voto, {0}", textConf);
                                    conf = int.Parse(Console.ReadLine());
                                    if(conf == 1) {
                                        aux1 = Voto.ComputarVoto(matriculaAux);
                                        if(aux1) {
                                           Console.WriteLine(" Seu Voto foi computado com Sucesso! ");
                                           Console.ReadKey(); 
                                        }else {
                                            Console.WriteLine(textFalha);
                                            Console.ReadKey();
                                        }
                                    } else if(conf != 2) {
                                        Console.WriteLine(" Operação Invalida! ");
                                        Console.ReadKey();
                                    }                                           
                                }   
                            }                            
                        } else {                       
                            Console.WriteLine(" O Número do candidato informado é inválido, a matricula do candidato deve conter 4 digitos!" );
                            Console.ReadKey();
                        }
                    }
                }catch {
                    Console.Clear();
                    Console.WriteLine(" A matrícula do candidato informada é inválida, a matricula deve ser formada por números! ");
                    Console.ReadKey();
                }
            }while(matricula != 9999);
            
        }
    }
}
