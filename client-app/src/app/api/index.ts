import axios from 'axios';
import Requests from './requestable';

axios.defaults.baseURL = 'http://localhost:5000/api';

axios.interceptors.request.use(options => {

        const accessToken = window.localStorage.getItem('accessToken');

        if (accessToken) 
            options.headers.Authorization = `Bearer ${accessToken}`;

        return options;

    }, 

    error => Promise.reject(error)
);

export default Requests;



