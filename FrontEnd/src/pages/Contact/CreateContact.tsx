//Página criar contato
/**
 * Campos Nome e E-mail obrigatórios
 */
import React, { FormEvent, useState } from "react";
import { useHistory } from "react-router-dom";
import '../../styles/Pages/page-contacts.css';
import Sidebar from "../../components/sidebar/sidebar";
import api from "../../services/api";

export default function CreateUser(this: any) {
  const history = useHistory();
  const [nome, setNome] = useState('');
  const [nascimento, setNascimento] = useState('');
  const [email, setEmail] = useState('');
  const [loading, setLoading] = useState(Boolean);

  async function handleSubmit(event: FormEvent) {
    event.preventDefault();
    const data = {
      'nome': nome,
      'nascimento': nascimento,
      'email': email
    };
    if (nome != '' && email != '') {
      const erro = 'Ocorreu um erro ao adicionar o contato! Se o problema persitir, contate o administrador';
      setLoading(true);
      await api.post('api/contatos', data)
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
    else {
      alert('Nome e E-mail são campos obrigatórios');
      return;
    }
  }

  return (
    <div id="page-contacts">
      <Sidebar />

      <main>
        <form onSubmit={handleSubmit} className="page-contatcs-form">
          <fieldset>
            <legend>Dados</legend>
            {loading ? <progress style={{top : 612, position : 'absolute', width : 542}}></progress> : ''}
            <div className="input-block">
              <label htmlFor="nome">Nome</label>
              <input id="nome" required
                value={nome}
                onChange={
                  event =>
                    setNome(event.target.value)
                }
              />
            </div>
            <div className="input-block">
              <label htmlFor="nascimento">Data Nascimento</label>
              <input id="nascimento" type="date"
                value={nascimento}
                onChange={
                  event =>
                    setNascimento(event.target.value)
                }
              />
            </div>
            <div className="input-block">
              <label htmlFor="email">E-mail</label>
              <input id="email" type="email" required
                value={email}
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