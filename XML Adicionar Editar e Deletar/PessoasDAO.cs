using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArquivoXML
{
    class Pessoas
    {
        public List<Pessoa> ListarPessoas()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            XElement xml = XElement.Load("Pessoa.xml");
            foreach (var x in xml.Elements())
            {
                Pessoa p = new Pessoa()
                {
                    codigo = int.Parse(x.Attribute("codigo").Value),
                    nome = x.Attribute("nome").Value,
                    telefone = x.Attribute("telefone").Value
                };
                pessoas.Add(p);

            }
            return pessoas;
        }
        public void AdicionarPessoas(Pessoa p)
        {
            XElement x = new XElement("pessoas");
            x.Add(new XAttribute("codigo", p.codigo.ToString()));
            x.Add(new XAttribute("nome", p.nome));
            x.Add(new XAttribute("telefone", p.telefone));
            XElement xml = XElement.Load("Pessoa.xml");
            xml.Add(x);
            xml.Save("pessoa.xml");
        }
       public void ExcluirPessoa(int codigo)
        {
            XElement xml = XElement.Load("Pessoa.xml");
            XElement x = xml.Elements().Where(p => p.Attribute("codigo").Value.Equals(codigo.ToString())).First();
            if (x != null)
            {
                x.Remove();
            }
            xml.Save("Pessoa.xml");
        }



        public void EditarPessoa(Pessoa pessoa)
        {
            XElement xml = XElement.Load("Pessoa.xml");
            XElement x = xml.Elements().Where(p => p.Attribute("codigo").Value.
            Equals(pessoa.codigo.ToString())).First();
            if(x != null)
            {
                x.Attribute("nome").SetValue(pessoa.nome);
                x.Attribute("telefone").SetValue(pessoa.telefone);
            }
            xml.Save("Pessoa.xml");
        }
    }
}
