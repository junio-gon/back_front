//Página editar contato
/**
 * Campos Nome e E-mail obrigatórios
 * id do jseon deve ser tipo numérico
 */
import React, { useState, useEffect } from "react";
import { Link, useHistory } from 'react-router-dom';
import { FaUserEdit, FaUserMinus, FaAngleLeft, FaAngleRight } from 'react-icons/fa';
//import { Contato } from "../../Interfaces/IContact";
import { ContactPage } from "../../Interfaces/IContactPage";
import Sidebar from "../../components/sidebar/sidebar";
import api from "../../services/api";
import '../../styles/Pages/page-contatcs-list.css';
//import { config } from "process";
//import { relative } from "path";

export default function Contacts() {
  const [pages, setPage] = useState<ContactPage[]>([]);
  const [id, setId] = useState('');
  const history = useHistory();
  var pageatual = 1;
  const [isUltima, setIsUltima] = useState(false);
  const [isPrimeira, setIsPrimeira] = useState(false);

  useEffect(() => {
    let isMounted = true;
    api.get('api/contatos').then(response => {
      if (isMounted) {
        setPage(response.data);
      }
    })
    return () => { isMounted = false};
  }, [id]);

  //função para exclusão do usuário
  async function deleteContato(contato: string) {
    if (window.confirm("Tem certeza que deseja excluir este contato?")) {
      await api.delete(`api/contatos/${contato}`);
      console.log('Excluido contato: ' + contato); //criar arquivo de log
      setId(contato);
    }
    return;
  }

  function prevPage() {
    var page = sessionStorage?.getItem('page') ?? 0;
    if (page > 1) {
      pageatual = +page;
      sessionStorage.setItem('page', String(pageatual - 1));
    }
    if (Number(page) <= 2) {
      setIsPrimeira(true);
    }
  };

  function nextPage() {
    var page = sessionStorage?.getItem('page') ?? 0;
    if (page < pages[pages.length - 1].pagina) {
      pageatual = +page;
      sessionStorage.setItem('page', String(pageatual + 1));
    }
    if (Number(pageatual) >= Number(pages[pages.length - 1].pagina) - 1) {
      setIsUltima(true);
    }

  };

  return (
    <div id="page-contacts">
      <Sidebar />
      <main>
        <form className="page-contatcs-form-list">
          <fieldset>
            <legend>Contatos</legend>
            {/* {contatos.length == 0 ? <progress style={{top : 180, position : 'absolute', width : 910}}></progress> : ''} */}
            <table>
              <thead>
                <tr>
                  <th className="id">ID</th>
                  <th className="nome">Nome</th>
                  <th className="nascimento">Nascimento</th>
                  <th className="email">Email</th>
                  <th className="acoes">Ações</th>
                </tr>
              </thead>
              <tbody>

                {pages.map(page => {
                  var pagina = sessionStorage?.getItem('page') ?? 0;
                  pageatual = +pagina;
                  if (page.pagina == pageatual) {
                    return (
                      <tr key={page.contato.id}>
                        <td>{page.contato.id}</td>
                        <td>{page.contato.nome}</td>
                        <td>{
                          page.contato.nascimento.substring(8, 10) + '/' + page.contato.nascimento.substring(5, 7) + '/' + page.contato.nascimento.substring(0, 4)
                        }</td>
                        <td>{page.contato.email}</td>
                        <td><Link to={`/contact/create/${page.contato.id}`}>
                          <button id="edit-contact"><FaUserEdit size={20} color="blue" /></button>
                        </Link>
                          <button id="delete-contact" onClick={() => deleteContato(page.contato.id)} value={page.contato.id}><FaUserMinus size={20} color="red" /></button>
                        </td>
                      </tr>
                    )
                  }
                })}
              </tbody>
            </table>
          </fieldset><br />
          {!isPrimeira && <button onClick={prevPage}><FaAngleLeft size={22} color="gray" data-tip="Página Anterior" /></button>}
               {!isPrimeira && <span id="nav">...</span>}
          {!isUltima && <button onClick={nextPage}><FaAngleRight size={22} color="gray" data-tip="Próxima Página"/></button>}
          
        </form>
      </main>
    </div>
  );
}