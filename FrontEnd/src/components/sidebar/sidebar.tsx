// menú sidebar
import React from 'react';
import { FiArrowLeft } from 'react-icons/fi';
import { FaUsers, FaUserPlus } from 'react-icons/fa';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import mapMarkerImg from '../../images/user-male.png';
import ReactTooltip from 'react-tooltip';
import './_Sidebar.css';

export default function Sidebar(){
    const { goBack } = useHistory();
    return(
        <aside className="app-sidebar">
        <Link to={'/login'}><img src={mapMarkerImg} alt="App" data-tip="Voltar para a página de login" /></Link>
        <footer>
        
        <Link to={'/contact/contacts/'}><button type="button" data-tip="Listar Contatos">
            <FaUsers size={24} color="#FFF" />
          </button></Link>
          <Link to={'/contact/create/'}><button type="button" data-tip="Adicionar Contatos">
          <FaUserPlus size={24} color="#FFF" />
          </button></Link>
          <button type="button" onClick={goBack} data-tip="Voltar">
            <FiArrowLeft size={24} color="#FFF" />
          </button>
          <ReactTooltip />
        </footer>
      </aside>
    );
}