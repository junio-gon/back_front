import React, { Component } from 'react';
import Routes from './routes';
import { AuthProvider } from './Context/AuthContext'
import './styles/global.css';
import 'leaflet/dist/leaflet.css';

function App() {
  
  console.log('%cSistema Agenda [Teste Técnico]', 'font-size: 200%; color: #0083a9;');
  console.log('%cDesenvolvido por Junio Santos', 'color: rgba(255, 255, 255, 0.5); font-size: 75%');
  console.log('');
  return (
    <AuthProvider>
      <Routes />
    </AuthProvider>
  );
}

export default App;
