using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.UI.Models
{
    class Moto : Veiculo
    {

        //Construtor 
        public Moto(string nome) : base(nome)
        {
            //no Java seria
            //super();
        }

        //Propriedades(Gets/Sets)
        public int Cilindros { get; set; }
        
    }
}
