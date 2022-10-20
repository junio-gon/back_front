//função para ser usada com o JWT
import { useState, useEffect } from 'react';

import api from '../../services/api';
//import history from '../../history';

export default function useAuth() {
  const [authenticated, setAuthenticated] = useState(false);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const token = sessionStorage.getItem('token');

    if (token) {
      //api.defaults.headers.Authorization = `Bearer ${JSON.parse(token)}`;
      setAuthenticated(true);
    }

    setLoading(false);
  }, []);
  
  async function handleLogin() {
    //const { data: { token } } = await api.post('api/Auth/signin');

    //sessionStorage.setItem('token', JSON.stringify(token));
    //api.defaults.headers.Authorization = `Bearer ${token}`;
    if(sessionStorage.getItem('user') && sessionStorage.getItem('token')){
      setAuthenticated(true);
    }
    //history.push('/users');
  }

  function handleLogout() {
    setAuthenticated(false);
    sessionStorage.removeItem('token');
    api.defaults.headers.Authorization = undefined;
    //history.push('/login');
  }
  
  return { authenticated, loading, handleLogin, handleLogout };
}