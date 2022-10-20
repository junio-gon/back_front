//Página criar usuarios do sistema
/**
 * Campos E-mail  e senha obrigatórios
 * Tipo será usado para tratar as Claims
 */
import React, { FormEvent, useState } from "react";
import { useHistory } from "react-router-dom";
import Input from "../../components/input/input";
import Text from "../../components/input/Text";
import Sidebar from "../../components/sidebar/sidebar";
import api from "../../services/api";
import '../../styles/Pages/page-contacts.css';

export default function CreateUser() {
  const history = useHistory();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmpassword, setConfirmPassword] = useState('');
  const [loading, setLoading] = useState(Boolean);

  async function handleSubmit(event: FormEvent){
    event.preventDefault();
    if (email != '' && password != '' && confirmpassword != '') {
      if (password.length < 6) {
        alert('A senha precisa ter pelo menos 6 caracteres');
        return;
      }
      if(password === confirmpassword){
        const data = {
          'email': email,
          'password': password,
          'tipo': 1
        };
        try {
          setLoading(true);
          var resp = await api.post('api/Auth/register', data);
          if (resp.status === 201) {
            console.log(resp);//implementar arquivo de log
            alert('cadastro realizado com sucesso');
            history.push('/login');
          }
          else{
            alert('Ocorreu um erro no cadastro, caso o erro persista, procure o administrador');
          }
        } catch (error) {
          alert('Erro de validação. A senha precisar ter ao menos uma letra Maiúscula, Miníscula, Número e Caractere especial (! @ # $ % & * ...)');
          console.log(error)
          return
        }
        setLoading(false);
      }
      else{
        alert('Os valores de senha e confirmação de senha não são iguais');
        setLoading(false);
        return;
      }
    }
    else{
      alert('Os campos e-mail, Senha e Confirme a Senha são obrigatórios');
      setLoading(false);
      return;
    }
  }

  return (
    <div id="page-contacts">
      <Sidebar/>

      <main>
        <form onSubmit={handleSubmit} className="page-contatcs-form">
          <fieldset>
            <legend>Cadastrar Usuário</legend>
            {loading ? <progress style={{top : 615, position : 'absolute', width : 539}}>CARREGANDO CONTATO</progress> : ''}
            <div className="input-block">
              <Text 
                id="email"
                type="email"
                label="Email:"
                name="email"
                flex={1}
                value={email} 
                required
                onChange={ 
                  (event: any) => 
                  setEmail(event.target.value)
                } 
              /> <br /><br />
              <Text 
                id="password"
                type="password"
                label="Senha:"
                name="password"
                flex={1}
                required
                value={password} 
                onChange={ 
                  (event: any) => 
                  setPassword(event.target.value)
                } 
              /><br /><br />
              <Text 
                id="confirmPassword"
                type="password"
                label="Confirme a Senha:"
                name="confirmPassword"
                flex={1}
                value={confirmpassword} 
                onChange={ 
                  (event: any) => 
                  setConfirmPassword(event.target.value)
                } 
              /> <br />
            </div>
          </fieldset>
          <div id="progress"></div>
          <button className="confirm-button" type="submit">
            Cadastrar
          </button>
        </form>
      </main>
    </div>
  );
}