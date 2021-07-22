import axios from 'axios';
import Requests from './requestable';

axios.defaults.baseURL = 'https://localhost:5001/api';

axios.interceptors.request.use(config => {

        const accessToken = window.localStorage.getItem('accessToken');

        if (accessToken) 
            config.headers.Authorization = `Bearer ${accessToken}`;

        return config;

    }, 

    error => Promise.reject(error)
);

export default Requests;



