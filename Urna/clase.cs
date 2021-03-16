using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class voto
    {
        public String matricula { get; set; }

        public bool Procurar (string matricula) {
            bool controll = false;
            string linha;
            StreamReader reader_doc = new StreamReader("candidato.txt");

            while(!reader_doc.EndOfStream)
            {
                linha = reader_doc.ReadLine();
                if(linha.Substring(0 , 4) == matricula)
                {
                    string[] candidato = linha.Split(";");
                    Console.WriteLine("{0}", candidato[1]);                                       
                    controll = true;
                    break;
                }
            }

            reader_doc.Close();
            return controll;
        }
        public void Listar () {           
            string linha = "";
            StreamReader reader_doc = new StreamReader("candidato.txt");
           
            Console.Clear();
            while(!reader_doc.EndOfStream) {
                linha = reader_doc.ReadLine();
                Console.WriteLine(linha);                
            }            
            reader_doc.Close();
            Console.ReadKey();            
        }

         public bool ComputarVoto(string matricula) {   
            string linha = "";
            int voto = 0;
            bool controll = false;
            StreamReader reader_doc = new StreamReader("candidato.txt");         
            StreamWriter gravar = new StreamWriter("candidatoAux.txt", false);           

            while(!reader_doc.EndOfStream) {
                linha = reader_doc.ReadLine();
                if(linha.Substring(0 , 4) == matricula) {
                    string[] quantVotos = linha.Split(";");
                    voto = int.Parse(quantVotos[2]);
                    voto = voto + 1;
                    linha = quantVotos[0] + ";" + quantVotos[1] + ";" + voto;                                                     
                    controll = true;                   
                }
                gravar.WriteLine(linha);
            }
            
            reader_doc.Close();
            gravar.Close();
            File.Delete("candidato.txt");
            File.Copy("candidatoAux.txt", "candidato.txt");
            File.Delete("candidatoAux.txt");
            return controll;
        }
    }
}
