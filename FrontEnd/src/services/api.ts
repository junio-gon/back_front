import axios from 'axios';

axios.defaults.headers = {
    'Content-Type': 'application/json',
    Authorization: `Bearer ${sessionStorage.getItem('token')}`
}

const api = axios.create({
    baseURL: 'https://localhost:44341'
});

//401 --> não autorizado

export default api;