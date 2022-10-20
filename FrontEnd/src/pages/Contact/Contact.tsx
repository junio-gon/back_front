//Página editar contato
/**
 * Campos Nome e E-mail obrigatórios
 * id do jseon deve ser tipo numérico
 */
import React, { FormEvent, useState, useEffect } from "react";
import { useHistory, useParams } from "react-router-dom";
import { Contato } from "../../Interfaces/IContact";
import { ContatoParams } from "../../Interfaces/IContatoParams";
import Sidebar from "../../components/sidebar/sidebar";
import api from "../../services/api";
import '../../styles/Pages/page-contacts.css';

export default function Contact() {
  const history = useHistory();
  const [nome, setNome] = useState('');
  const [nascimento, setNascimento] = useState('');
  const [email, setEmail] = useState('');
  const [contato, setContato] = useState<Contato>();
  const params = useParams<ContatoParams>();
  const [loading, setLoading] = useState(Boolean);
  
  //chamada da api get -> controller/parâmetro
  useEffect(() => {
      api.get(`api/contatos/${params.id}`).then( response =>{
          setContato(response.data);
      });
  }, [params.id]);

  // if(!contato){
  //   return <progress>CARREGANDO CONTATO</progress>
  // }

  async function handleSubmit(event: FormEvent){
    event.preventDefault();
    if (
        document.getElementById('id')?.getAttribute("value") && 
        (nome != '' || document.getElementById('nome')?.getAttribute("value") != '') &&
        (email != '' || document.getElementById('email')?.getAttribute("value") != '')
        ) {
      const data = {
        'id': Number(document.getElementById('id')?.getAttribute("value")),
        'nome': nome ? nome : document.getElementById('nome')?.getAttribute("value"),
        'nascimento': nascimento ? nascimento : document.getElementById('nascimento')?.getAttribute("value"),
        'email': email ? email : document.getElementById('email')?.getAttribute("value")
      };
      
      //chamada da api put -> controller/{}
      const erro = 'Ocorreu um erro ao adicionar o contato! Se o problema persitir, contate o administrador';
      setLoading(true);
      await api.put('api/contatos', data)
        .then(async response => {
          if (!response.data) {
            alert(erro);
            console.error(`${erro} ==> ${data}`);
            return Promise.reject(`${erro} ${data}`);//salvar no arquivo de log
          }
          else {
            console.log(`${response.data} ${nome} ${nascimento} ${email} `);//salvar no arquivo de log
            alert(response.data);
            history.push('/contact/contacts');
          }
        })
        .catch(error => {
          alert(erro);
          console.error(`${error} ==> ${erro}`);//salvar no arquivo de log
        });
        setLoading(false);
    }
    else{
      alert('Os campos Nome e Email são obrigatórios');
      return;
    }
  }

  return (
    <div id="page-contacts">
      <Sidebar/>
      <main>
        <form onSubmit={handleSubmit} className="page-contatcs-form">
          <fieldset>
            <legend>Dados</legend>
            {loading ? <progress style={{top : 612, position : 'absolute', width : 542}}></progress> : ''}
            {!contato ? <progress style={{top : 182, position : 'absolute', width : 540}}></progress> : ''}
            <input type="hidden" id="id" 
                defaultValue={contato && contato.id} 
              />
            <div className="input-block">
              <label htmlFor="nome">Nome</label>
              <input id="nome" required
                defaultValue={contato && contato.nome} 
                onChange={ 
                  event => 
                  setNome(event.target.value)
                } 
              />
            </div>
            <div className="input-block">
              <label htmlFor="nascimento">Data Nascimento</label>
              <input id="nascimento" type="date"
                defaultValue={contato && contato.nascimento.substring(0,10)} 
                onChange={ 
                  event => 
                  setNascimento(event.target.value)
                } 
              />
            </div>
            <div className="input-block">
              <label htmlFor="email">E-mail</label>
              <input id="email" type="email" required
                defaultValue={contato && contato.email} 
                onChange={ 
                  event => 
                  setEmail(event.target.value)
                } 
              />
            </div>
          </fieldset>
          <button className="confirm-button" type="submit">
            Cadastrar
          </button>
        </form>
      </main>
    </div>
  );
}