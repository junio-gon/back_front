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
  

  return (
    <div id="page-contacts">
      <Sidebar/>
      <main>
      <form className="page-contatcs-form-list">
        <fieldset>
          <legend>Bem Vindo</legend>
        </fieldset>
        <h1>{sessionStorage?.getItem('user')}</h1><br />
        <span>Utilize o menú a esquerda para navegar na aplicação.</span>
      </form>
      </main>
    </div>
  );
}